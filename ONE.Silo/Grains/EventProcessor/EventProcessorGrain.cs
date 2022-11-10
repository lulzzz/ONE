using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ONE.DataAccess.Repositories;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.EventProcessor;
using ONE.Models.Domain;
using ONE.Models.MessageContracts;
using ONE.Silo.Grains.EventProcessor.Blockly;
using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ONE.Silo.Grains.EventProcessor
{
    [ImplicitStreamSubscription(ONEStreams.EVENT_PROCESSOR)]
    [StorageProvider(ProviderName = ONEStreams.EVENT_PROCESSOR)]
    public class EventProcessorGrain : GrainBase, IRemindable, IEventProcessor
    {
        private IGrainReminder _reminder = null;
        private Dictionary<string, Type> _configurationBlockTypeMap;
        private IEventFlowRepository _eventFlowRepository = null;
        private IActiveEventFlowExecutionTrackingRepository _activeEventFlowExecutionTrackingRepository = null;
        private EventFlow _eventFlow;


        public EventProcessorGrain(IEventFlowRepository eventFlowRepository,
            IActiveEventFlowExecutionTrackingRepository eventFlowActivationBlockTrackRepository)
        {
            _eventFlowRepository = eventFlowRepository;
            _activeEventFlowExecutionTrackingRepository = eventFlowActivationBlockTrackRepository;
        }

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            // var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            //var stream = streamProvider.GetStream<IONEEventMessage>(new Guid(GrainId), ONEStreams.EVENT_PROCESSOR);
            // await stream.SubscribeAsync(OnNextAsync);
        }

        public Task OnCompletedAsync()
        {
            Logger.LogInformation("Stream completed");
            return Task.CompletedTask;
        }

        public Task OnErrorAsync(Exception ex)
        {
            Logger.LogError("Stream error");
            return Task.CompletedTask;
        }


        public async Task ProcessExecutionFlow(IONEEventMessage oneEventMessage)
        {
            Logger.LogInformation("ProcessExecutionFlow");



            EventFlowInfo eventFlowInfo = _eventFlowRepository.GetEventFlowInfoByEventFlowGuid(oneEventMessage.EventFlowGUID);
            ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo = new ActiveEventFlowExecutionTrackingInfo();
            activeEventFlowExecutionTrackingInfo.InitiatorGuid = oneEventMessage.InitiatorGUID;
            activeEventFlowExecutionTrackingInfo.EventFlowGuid = oneEventMessage.EventFlowGUID;
            activeEventFlowExecutionTrackingInfo.EventTypeCode = (int)oneEventMessage.EventType;
            activeEventFlowExecutionTrackingInfo.EventFlowXml = eventFlowInfo.EventFlowXML;
            activeEventFlowExecutionTrackingInfo.GlobalTrackingGuid = oneEventMessage.GlobalTrackingGuid;
            activeEventFlowExecutionTrackingInfo.EventInstanceGuid = oneEventMessage.EventInstanceGUID;
            activeEventFlowExecutionTrackingInfo.EventData = oneEventMessage.Payload.ToString();
            activeEventFlowExecutionTrackingInfo.TriggeredByEventFlowInstanceGuid = oneEventMessage.EventInstanceGUID;
            activeEventFlowExecutionTrackingInfo.EventFlowLogDetailXml = oneEventMessage.EventFlowLogDetailXML;
            activeEventFlowExecutionTrackingInfo.HaltedByEventFlowInstanceGuid = oneEventMessage.HaltedByEventFlowInstanceGUID;
            activeEventFlowExecutionTrackingInfo.StopAudioOnEventFlowHalt = oneEventMessage.StopAudioOnEventFlowHalt;
            _activeEventFlowExecutionTrackingRepository.AddActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);

            //Not creating Reminder for Clear events

            string grainReminderName = $"{activeEventFlowExecutionTrackingInfo.InitiatorGuid}/{activeEventFlowExecutionTrackingInfo.EventFlowGuid}/{activeEventFlowExecutionTrackingInfo.EventTypeCode}/reminder";
            _reminder = await RegisterOrUpdateReminder(grainReminderName, TimeSpan.FromSeconds(3), TimeSpan.FromMinutes(1));

        }

        public async Task ReceiveReminder(string reminderName, TickStatus status)
        {
            string[] splitReminderName = reminderName.Split('/');
            string initiatorGuid = splitReminderName[0];
            string eventFlowGuid = splitReminderName[1];
            string eventTypeCode = splitReminderName[2];

            ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo = new ActiveEventFlowExecutionTrackingInfo();
            activeEventFlowExecutionTrackingInfo.InitiatorGuid = new Guid(initiatorGuid);
            activeEventFlowExecutionTrackingInfo.EventFlowGuid = new Guid(eventFlowGuid);
            activeEventFlowExecutionTrackingInfo.EventTypeCode = Convert.ToInt32(eventTypeCode);

            ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrack = _activeEventFlowExecutionTrackingRepository.GetActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);

            if (activeEventFlowExecutionTrack != null)
            {
                IONEEventMessage oneEventMessage = new ONEEventMessage();
                oneEventMessage.EventFlowGUID = activeEventFlowExecutionTrack.EventFlowGuid;
                oneEventMessage.EventFlowLogDetailXML = activeEventFlowExecutionTrack.EventFlowLogDetailXml;
                oneEventMessage.EventInstanceGUID = activeEventFlowExecutionTrack.EventInstanceGuid;
                oneEventMessage.EventType = (ONE.Models.Enumerations.EventType)activeEventFlowExecutionTrack.EventTypeCode;
                oneEventMessage.GlobalTrackingGuid = activeEventFlowExecutionTrack.GlobalTrackingGuid;
                oneEventMessage.HaltedByEventFlowInstanceGUID = activeEventFlowExecutionTrack.HaltedByEventFlowInstanceGuid;
                oneEventMessage.InitiatorGUID = activeEventFlowExecutionTrack.InitiatorGuid;
                oneEventMessage.StopAudioOnEventFlowHalt = activeEventFlowExecutionTrack.StopAudioOnEventFlowHalt;
                oneEventMessage.TriggeredByEventFlowInstanceGUID = activeEventFlowExecutionTrack.TriggeredByEventFlowInstanceGuid;
                await InitiateFlow(activeEventFlowExecutionTrack.EventFlowXml, oneEventMessage, activeEventFlowExecutionTrack);
            }
        }



        /// <summary>
        /// Initiates the flow.
        /// </summary>
        /// <param name="flowConfigurationXml">The flow configuration XML.</param>
        /// <param name="message">The message.</param>
        public async Task InitiateFlow(string flowConfigurationXml, IONEEventMessage oneEventMessage, ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrack)
        {
            try
            {
                //Extract the block type name, it should be the event type name strnig with the capitals replaced with an underscore and the odin_event prefix added
                //such that CapCodeTextMessageReceived becomes odin_event_cap_code_text_message_received
                string blockTypeName = string.Format("odin_event{0}", Regex.Replace(oneEventMessage.EventType.ToString(), "[A-Z]", "_$0").ToLower());

                //Logger.Instance.LogDebug($"Initiating Event Flow from Event: {blockTypeName}: InitiatorGUID {message.InitiatorGUID} - EventFlowGUID: {message.EventFlowGUID}");
                XmlDocument doc = new XmlDocument();

                //create the namespace manager
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ns", "http://www.w3.org/1999/xhtml");
                doc.LoadXml(flowConfigurationXml);

                //Get the root event block based upon the block type name that is created from convention using the event name
                var rootEventBlockXmlNode = doc.SelectSingleNode("//ns:block[@type=" + "'" + blockTypeName + "'" + "]", nsmgr);

                //Check to make sure we could find a root event
                if (rootEventBlockXmlNode != null)
                {
                    //Build the Configuration Block flow graph under the root event block
                    ONEConfigurationEventBlock rootEventBlock = BuildConfigurationBlockFlowGraph(rootEventBlockXmlNode, nsmgr) as ONEConfigurationEventBlock;
                    rootEventBlock.ONEEventMessage = oneEventMessage;
                    rootEventBlock.EventData = oneEventMessage.Payload;
                    rootEventBlock.StopAudioOnEventFlowHalt = oneEventMessage.StopAudioOnEventFlowHalt;
                    rootEventBlock.EventFlowLogDetailXML = oneEventMessage.EventFlowLogDetailXML;
                    rootEventBlock.GrainFactory = GrainFactory;

                    //Set the root event block for all of the child blocks
                    SetRootEventBlock(rootEventBlock, rootEventBlock);

                    if (activeEventFlowExecutionTrack.EventFlowState != null)
                    {
                        await BuildONEEventFlowVariableDictionary(rootEventBlock, activeEventFlowExecutionTrack);
                        await CreateRootEventBlock(rootEventBlock, activeEventFlowExecutionTrack);
                    }

                    //Create a new event flow for the root event block and add it to the active event flows
                    EventFlow flowToInitiate = new EventFlow(rootEventBlock, oneEventMessage.GlobalTrackingGuid, oneEventMessage.EventInstanceGUID, oneEventMessage.EventFlowGUID, oneEventMessage.InitiatorGUID, oneEventMessage.EventType, flowConfigurationXml);
                    _eventFlow = flowToInitiate;

                    flowToInitiate.EventFlowCompleted += FlowToInitiate_EventFlowCompleted;
                    //  _activeEventFlows.Add(flowToInitiate);

                    //Initate the flow
                    //  flowToInitiate.EventFlowTask.Start();

                    await flowToInitiate.ExecuteFlow();
                    await UnregisterGrainReminder($"{this.GrainId}/reminder");
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FlowToInitiate_EventFlowCompleted(object sender, EventArgs e)
        {

        }
        public async Task UnregisterGrainReminder(string grainReminderName)
        {
            string[] splitReminderName = grainReminderName.Split('/');
            string initiatorGuid = splitReminderName[0];
            string eventFlowGuid = splitReminderName[1];
            string eventTypeCode = splitReminderName[2];

            ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo = new ActiveEventFlowExecutionTrackingInfo();
            activeEventFlowExecutionTrackingInfo.InitiatorGuid = new Guid(initiatorGuid);
            activeEventFlowExecutionTrackingInfo.EventFlowGuid = new Guid(eventFlowGuid);
            activeEventFlowExecutionTrackingInfo.EventTypeCode = Convert.ToInt32(eventTypeCode);
            _activeEventFlowExecutionTrackingRepository.DeleteActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);

            this._eventFlow.RootEventBlock.IsEventFlowHalted = true;
            IGrainReminder grainReminder = await this.GetReminder(grainReminderName);
            if (grainReminder != null)
            {
                await this.UnregisterReminder(grainReminder);
            }
        }


        #region Event Flow Blocky State Building


        /// <summary>
        /// /Find the Active Block ID in rootEventBlock 
        /// Build the State and set the Next Execution Block
        /// </summary>
        /// <param name="rootEventBlock"></param>
        /// <param name="activeEventFlowExecutionTrack"></param>
        private async Task CreateRootEventBlock(ONEConfigurationEventBlock? rootEventBlock, ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrack)
        {

            await FindNextExecutionBlock(rootEventBlock, activeEventFlowExecutionTrack);

            await CreateRootEventNextBlock(rootEventBlock.NextBlock, rootEventBlock, activeEventFlowExecutionTrack);


        }

        /// <summary>
        /// If the Active Block ID not found in RootBlock
        /// Check in Next Block using Recursive function
        /// </summary>
        /// <param name="nextBlock"></param>
        /// <param name="rootEventBlock"></param>
        /// <param name="activeEventFlowExecutionTrackingInfo"></param>
        private async Task CreateRootEventNextBlock(ONEConfigurationBlock? nextBlock, ONEConfigurationEventBlock? rootEventBlock, ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            if (nextBlock != null)
            {
                await FindNextExecutionBlock(nextBlock, rootEventBlock, activeEventFlowExecutionTrackingInfo);
                await CreateRootEventNextBlock(nextBlock.NextBlock, rootEventBlock, activeEventFlowExecutionTrackingInfo);
            }
        }

        private Task FindNextExecutionBlock(ONEConfigurationBlock? nextBlock, ONEConfigurationEventBlock? rootEventBlock, ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            dynamic dynJson = JsonConvert.DeserializeObject(activeEventFlowExecutionTrackingInfo.EventFlowState);
            if (dynJson != null)
            {
                if (nextBlock.Id == dynJson["ActiveEventFlowExecutionTrackingId"].Value.ToString())
                {
                    var activeBlockTrackingJson = dynJson[dynJson["ActiveEventFlowExecutionTrackingId"].Value.ToString()];
                    if (activeBlockTrackingJson != null)
                    {
                        foreach (var element in nextBlock.GetType().GetProperties())
                        {
                            if (element.GetCustomAttribute(typeof(BlocklyConfigurationFieldInfoAttribute)) != null)
                            {
                                var converter = TypeDescriptor.GetConverter(element.PropertyType);
                                var convertedObject = converter.ConvertFromString(Convert.ToString(activeBlockTrackingJson.Value[element.Name]));
                                element.SetValue(nextBlock, convertedObject, null);
                            }
                        }

                    }
                    rootEventBlock.NextBlock = nextBlock;
                }
                else
                {
                    foreach (var element in nextBlock.GetType().GetProperties())
                    {
                        if (element.GetValue(nextBlock, null)?.GetType() == typeof(ONEConfigurationBlockStatement))
                        {
                            ONEConfigurationBlockStatement oneConfigurationBlockStatement = element.GetValue(nextBlock, null) as ONEConfigurationBlockStatement;

                            if (FindIdInConfigurationBlockStatement(oneConfigurationBlockStatement, dynJson["ActiveEventFlowExecutionTrackingId"].Value.ToString()))
                            {
                                var activeBlockTrackingJson = dynJson[nextBlock.Id].Value;

                                foreach (var statementBlock in nextBlock.GetType().GetProperties())
                                {
                                    if (statementBlock.GetCustomAttribute(typeof(BlocklyConfigurationFieldInfoAttribute)) != null)
                                    {
                                        var converter = TypeDescriptor.GetConverter(statementBlock.PropertyType);
                                        var convertedObject = converter.ConvertFromString(Convert.ToString(activeBlockTrackingJson[statementBlock.Name].Value));
                                        statementBlock.SetValue(nextBlock, convertedObject, null);
                                    }
                                }
                                rootEventBlock.NextBlock = nextBlock;
                            }
                        }
                    }
                }

            }
            return Task.CompletedTask;
        }

        public bool FindIdInConfigurationBlockStatement(ONEConfigurationBlockStatement oneConfigurationBlockStatement, string activeEventFlowExecutionTrackingId)
        {
            if (oneConfigurationBlockStatement.FirstStatementBlock.Id == activeEventFlowExecutionTrackingId)
            {
                return true;
            }
            else
            {
                if (oneConfigurationBlockStatement.FirstStatementBlock.NextBlock != null)
                {
                    return RecursiveConfigurationBlockStatement(oneConfigurationBlockStatement.FirstStatementBlock.NextBlock, activeEventFlowExecutionTrackingId);
                }
            }
            return false;
        }

        private bool RecursiveConfigurationBlockStatement(ONEConfigurationBlock nextBlock, string Id)
        {
            if (nextBlock.Id == Id)
            {
                return true;
            }
            if (nextBlock.NextBlock != null)
            {
                RecursiveConfigurationBlockStatement(nextBlock.NextBlock, Id);
            }
            return false;
        }

        private Task FindNextExecutionBlock(ONEConfigurationEventBlock? rootEventBlock, ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            dynamic dynJson = JsonConvert.DeserializeObject(activeEventFlowExecutionTrackingInfo.EventFlowState);

            if (dynJson != null)
            {
                if (rootEventBlock.Id == dynJson["ActiveEventFlowExecutionTrackingId"].Value.ToString())
                {
                    rootEventBlock = rootEventBlock;
                }
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Rebuilding ONE EventFlow Variable Dictionary
        /// </summary>
        /// <param name="rootEventBlock"></param>
        /// <param name="activeEventFlowExecutionTrackingInfo"></param>
        public Task BuildONEEventFlowVariableDictionary(ONEConfigurationEventBlock rootEventBlock, ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            dynamic dynJson = JsonConvert.DeserializeObject(activeEventFlowExecutionTrackingInfo.EventFlowState);

            if (rootEventBlock.ONEEventFlowVariableDictionary == null)
            {
                rootEventBlock.ONEEventFlowVariableDictionary = new ConcurrentDictionary<string, ONEEventFlowVariable>();
            }

            if (dynJson != null)
            {
                foreach (var item in dynJson)
                {
                    var first = item.First["Value"];
                    if (Convert.ToString(first.Type) == typeof(string).Name)
                    {
                        string value = Convert.ToString(first.Value);
                        Type shellPropertyType = typeof(ONEEventFlowVariable<>).MakeGenericType(typeof(string));
                        object oneEventFlowVariableInstance = Activator.CreateInstance(shellPropertyType);
                        PropertyInfo oneEventFlowVariableProp = oneEventFlowVariableInstance.GetType().GetProperty("Value");
                        oneEventFlowVariableProp.SetValue(oneEventFlowVariableInstance, value, null);
                        rootEventBlock.ONEEventFlowVariableDictionary.TryAdd(Convert.ToString(item.Name), oneEventFlowVariableInstance as ONEEventFlowVariable);

                    }
                }
            }
            return Task.CompletedTask;
        }

        #endregion


        #region Event Flow Blockly Block Building


        /// <summary>
        /// Builds the configuration block chain.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <param name="nsmgr">The NSMGR.</param>
        /// <returns></returns>
        private ONEConfigurationBlock BuildConfigurationBlockFlowGraph(XmlNode currentNode, XmlNamespaceManager nsmgr)
        {
            ONEConfigurationBlock currentBlock = GetBlocklyConfigurationBlock(currentNode, nsmgr);

            //Check to see if there is a next node, and if so, build that block
            if (currentNode.HasChildNodes)
            {
                XmlNode nextNode = currentNode.SelectSingleNode("./ns:next", nsmgr);

                if (nextNode != null)
                {
                    //Get the block node
                    XmlNode blockNode = nextNode.SelectSingleNode("./ns:block", nsmgr);

                    //Check to make sure it's not null, and if it isn't, then build it
                    if (blockNode != null)
                    {
                        currentBlock.NextBlock = BuildConfigurationBlockFlowGraph(blockNode, nsmgr);
                    }
                }
            }
            return currentBlock;
        }

        /// <summary>
        /// Gets the type of the blockly configuration block.
        /// </summary>
        /// <param name="blockTypeName">Name of the block type.</param>
        /// <returns></returns>
        private ONEConfigurationBlock GetBlocklyConfigurationBlock(XmlNode currentNode, XmlNamespaceManager nsmgr)
        {
            string blockTypeName = GetBlockTypeName(currentNode);

            //Get the type 
            Type oneConfigurationBlockType = _configurationBlockTypeMap[blockTypeName];

            //Return a new instance of that type
            ONEConfigurationBlock currentBlock = Activator.CreateInstance(oneConfigurationBlockType) as ONEConfigurationBlock;
            currentBlock.Id = currentNode.Attributes["id"].Value;
            //Check to see if there are any statement nodes, and if so build those up
            XmlNodeList statementNodes = currentNode.SelectNodes("./ns:statement", nsmgr);
            if (statementNodes != null && statementNodes.Count > 0)
            {
                //Get all of the statement properties for current block
                IEnumerable<PropertyInfo> statementProperties = oneConfigurationBlockType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BlocklyConfigurationStatementInfoAttribute)));

                //Iterate the statement nodes and build them up
                foreach (XmlNode statementNode in statementNodes)
                {
                    ONEConfigurationBlockStatement statement = new ONEConfigurationBlockStatement();
                    statement.StatementName = statementNode.Attributes["name"].Value;

                    //Get the block node
                    XmlNode blockNode = statementNode.SelectSingleNode("./ns:block", nsmgr);

                    //Check to make sure it's not null, and if it isn't, then build it
                    if (blockNode != null)
                    {
                        statement.FirstStatementBlock = BuildConfigurationBlockFlowGraph(blockNode, nsmgr);
                    }

                    //Try to find the statement property that matches the statement name
                    PropertyInfo statementProperty = statementProperties.Where(x => ((BlocklyConfigurationStatementInfoAttribute)x.GetCustomAttribute(typeof(BlocklyConfigurationStatementInfoAttribute))).StatementName == statement.StatementName).FirstOrDefault();

                    //If the statement property isn't null for this configuration block, then set the property with the statement
                    if (statementProperty != null)
                    {
                        statementProperty.SetValue(currentBlock, statement);
                    }
                }
            }

            //See if there are any field nodes, and if so, set those properties
            XmlNodeList fieldNodes = currentNode.SelectNodes("./ns:field", nsmgr);
            if (fieldNodes != null && fieldNodes.Count > 0)
            {

                //Get all of the field properties for current block
                IEnumerable<PropertyInfo> fieldProperties = oneConfigurationBlockType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BlocklyConfigurationFieldInfoAttribute)));

                //Iterate the field nodes and search for matching properties
                foreach (XmlNode fieldNode in fieldNodes)
                {
                    string fieldName = fieldNode.Attributes["name"].Value;

                    //Try to find the statement property that matches the statement name
                    PropertyInfo fieldProperty = fieldProperties.Where(x => ((BlocklyConfigurationFieldInfoAttribute)x.GetCustomAttribute(typeof(BlocklyConfigurationFieldInfoAttribute))).FieldName == fieldName).FirstOrDefault();

                    //Try to set the value using a type converter
                    if (fieldProperty.PropertyType.IsEnum)
                    {
                        //It is an enum type, so we can't just change type we have to parse it
                        fieldProperty.SetValue(currentBlock, Enum.Parse(fieldProperty.PropertyType, fieldNode.InnerText));
                    }
                    else
                    {
                        if (fieldProperty.PropertyType == typeof(Guid))
                        {
                            //It's a guid, so create a new guid from the string type
                            fieldProperty.SetValue(currentBlock, Convert.ChangeType(new Guid(fieldNode.InnerText), fieldProperty.PropertyType));
                        }
                        else
                        {
                            //It is not an enum type or a guid, just do a regular change type
                            fieldProperty.SetValue(currentBlock, Convert.ChangeType(fieldNode.InnerText, fieldProperty.PropertyType));
                        }

                    }
                }
            }


            XmlNodeList valueNodes = currentNode.SelectNodes("./ns:value", nsmgr);
            if (valueNodes != null && valueNodes.Count > 0)
            {
                //Get all of the field properties for current block
                IEnumerable<PropertyInfo> valueProperties = oneConfigurationBlockType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BlocklyConfigurationValueInfoAttribute)));

                //Iterate the value nodes and search for matching properties
                foreach (XmlNode valueNode in valueNodes)
                {
                    string valueName = valueNode.Attributes["name"].Value;

                    //Try to find the value property that matches the value name
                    IEnumerable<PropertyInfo> valueNodeProperties = valueProperties.Where(x => ((BlocklyConfigurationValueInfoAttribute)x.GetCustomAttribute(typeof(BlocklyConfigurationValueInfoAttribute))).ValueName == valueName).ToList();

                    if (valueNodeProperties != null)
                    {
                        //Get the block node
                        XmlNode blockNode = valueNode.SelectSingleNode("./ns:block", nsmgr);

                        //Build the block graph for the current block node.
                        ONEConfigurationBlock oneConfigurationBlock = BuildConfigurationBlockFlowGraph(blockNode, nsmgr);


                        PropertyInfo valueProperty;
                        if (oneConfigurationBlock != null && valueNodeProperties != null && valueNodeProperties.Count() > 1)
                        {
                            valueProperty = valueNodeProperties.Where(x => ((BlocklyConfigurationValueInfoAttribute)x.GetCustomAttribute(typeof(BlocklyConfigurationValueInfoAttribute))).ValueType == oneConfigurationBlock.GetType().BaseType.GenericTypeArguments[0]).FirstOrDefault();
                        }
                        else
                        {
                            valueProperty = valueNodeProperties.FirstOrDefault();
                        }

                        //Determine if the current block node is an Optional Input placeholder
                        //If it is, set it to null, otherwise set the current block value property to the configuration block.
                        //This gives us the ability to create optional parameters in blocks and fill in the holes
                        //with Default Input Blocks.
                        if (oneConfigurationBlock.GetType().IsSubclassOf(typeof(ONEConfigurationOutputBlock<OptionalInput>)))
                        {
                            //It is an Optional Input, so make the value property null.
                            valueProperty.SetValue(currentBlock, null);
                        }
                        else
                        {
                            //Try to set the value using a type converter
                            valueProperty.SetValue(currentBlock, oneConfigurationBlock);
                        }
                    }
                }

            }


            return currentBlock;
        }

        /// <summary>
        /// Gets the name of the block type.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string GetBlockTypeName(XmlNode currentNode)
        {
            //Build the block type map if it is null
            if (_configurationBlockTypeMap == null || _configurationBlockTypeMap.Count == 0)
            {
                _configurationBlockTypeMap = new Dictionary<string, Type>();

                IEnumerable<Type> blocklyConfigurationBlockTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.CustomAttributes.Where(y => y.AttributeType == typeof(BlocklyConfigurationBlockInfoAttribute)).Count() > 0);
                foreach (Type blocklyConfigurationBlockType in blocklyConfigurationBlockTypes)
                {
                    BlocklyConfigurationBlockInfoAttribute infoAtribute = blocklyConfigurationBlockType.GetCustomAttribute(typeof(BlocklyConfigurationBlockInfoAttribute)) as BlocklyConfigurationBlockInfoAttribute;
                    _configurationBlockTypeMap.Add(infoAtribute.BlockTypeName, blocklyConfigurationBlockType);
                }
            }

            string blockTypeName = currentNode.Attributes["type"].Value;

            //Check to make sure that our block type name exists in the dictionary, and throw an exception if it doesn't
            if (!_configurationBlockTypeMap.ContainsKey(blockTypeName))
            {
                throw new Exception(string.Format("Unable to locate a data type for the block type named: {0}", blockTypeName));
            }

            return blockTypeName;
        }

        /// <summary>
        /// Sets the root event block.
        /// </summary>
        /// <param name="currentBlock">The current block.</param>
        /// <param name="rootEventBlock">The root event block.</param>
        private void SetRootEventBlock(ONEConfigurationBlock currentBlock, ONEConfigurationEventBlock rootEventBlock)
        {
            currentBlock.RootEventBlock = rootEventBlock;


            //Determine if the current block is an OdinConfigurationStatementBlock, if it is, we have to handle it a bit differently
            if (currentBlock is ONEConfigurationStatementBlock)
            {
                //We need to traverse the blocks inside statements.  This works a bit differently than just the next block because we need to "get inside" the statement

                //Find all ONEConfigurationBlockStatement properties
                //Check to see if the FirstStatementBlock property is not null, and if not, call the SetRootEventBlock on it
                List<PropertyInfo> oneConfigurationBlockStatementProperties = currentBlock.GetType().GetProperties().Where(x => x.PropertyType == typeof(ONEConfigurationBlockStatement)).ToList();

                //Iterate all of the properties and see if the OdinConfigurationBlockStatement properties are not null
                foreach (PropertyInfo oneConfigurationBlockStatementProperty in oneConfigurationBlockStatementProperties)
                {
                    ONEConfigurationBlockStatement oneConfigurationBlockStatement = oneConfigurationBlockStatementProperty.GetValue(currentBlock) as ONEConfigurationBlockStatement;

                    if (oneConfigurationBlockStatement != null)
                    {
                        //Its not null, so see if the first statement block property is not null, and if not, set its root element
                        SetRootEventBlockAllProperties(oneConfigurationBlockStatement, rootEventBlock);
                    }
                }

                //Set the root event block for all of the inline value properties that are assignable from ONEConfigurationBlock
                SetRootEventBlockAllProperties(currentBlock, rootEventBlock);
            }
            else
            {
                //Not a statement block, so try to set the root event block on all properties that are assignable from ONEConfigurationBlock
                SetRootEventBlockAllProperties(currentBlock, rootEventBlock);
            }
        }

        /// <summary>
        /// Sets the root event block all properties that are assignable from ONEConfigurationBlock
        /// </summary>
        /// <param name="currentObject">The current object.</param>
        /// <param name="rootEventBlock">The root event block.</param>
        private void SetRootEventBlockAllProperties(object currentObject, ONEConfigurationEventBlock rootEventBlock)
        {
            //Get all of the public instance properties
            PropertyInfo[] propertyInfos = currentObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //Iterate all of the properties to find those properties that inherit from ONEConfigurationBlock
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name != "RootEventBlock")
                {
                    //Determine if this property is ONEConfigurationBlock or is inherited from ONEConfigurationBlock
                    if (typeof(ONEConfigurationBlock).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        //It is, so get the property value
                        ONEConfigurationBlock oneConfigurationBlockPropertyValue = propertyInfo.GetValue(currentObject) as ONEConfigurationBlock;

                        //Make sure the property value is not null
                        if (oneConfigurationBlockPropertyValue != null)
                        {
                            //It's not, so set the root event block for this OdinConfigurationBlock property
                            SetRootEventBlock(oneConfigurationBlockPropertyValue, rootEventBlock);
                        }
                    }
                    //Or of it is an array whose array type is ONEConfigurationBlock or is inherited from ONEConfigurationBlock
                    else if (propertyInfo.PropertyType.IsArray && typeof(ONEConfigurationBlock).IsAssignableFrom(propertyInfo.PropertyType.GetElementType()))
                    {
                        Array arrayPropertyValue = propertyInfo.GetValue(currentObject) as Array;

                        //It is an array of the correct type
                        foreach (object element in arrayPropertyValue)
                        {
                            ONEConfigurationBlock oneConfigurationBlockPropertyValue = element as ONEConfigurationBlock;

                            //Make sure the property value is not null
                            if (oneConfigurationBlockPropertyValue != null)
                            {
                                //It's not, so set the root event block for this OdinConfigurationBlock property
                                SetRootEventBlock(oneConfigurationBlockPropertyValue, rootEventBlock);
                            }
                        }
                    }
                    else if (propertyInfo.PropertyType == typeof(ONEConfigurationBlockStatement))
                    {
                        //It is, so get the property value
                        ONEConfigurationBlockStatement oneConfigurationStatementBlockPropertyValue = propertyInfo.GetValue(currentObject) as ONEConfigurationBlockStatement;

                        //Make sure the property value is not null
                        if (oneConfigurationStatementBlockPropertyValue != null)
                        {
                            //It's not, so set the root event block for this ONEConfigurationBlock property
                            SetRootEventBlock(oneConfigurationStatementBlockPropertyValue.FirstStatementBlock, rootEventBlock);
                        }
                    }

                }
            }
        }

        #endregion
    }
}
