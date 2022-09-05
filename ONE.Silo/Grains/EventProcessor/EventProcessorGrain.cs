using Microsoft.Extensions.Logging;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.EventProcessor;
using ONE.Models.MessageContracts;
using ONE.Silo.Grains.EventProcessor.Blockly;
using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using Orleans;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ONE.Silo.Grains.EventProcessor
{
    [ImplicitStreamSubscription(ONEStreams.EVENT_PROCESSOR)]
    public class EventProcessorGrain : GrainBase, IEventProcessor
    {
        private Dictionary<string, Type> _configurationBlockTypeMap;

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var stream = streamProvider.GetStream<IONEEventMessage>(new Guid(GrainId), ONEStreams.EVENT_PROCESSOR);
            await stream.SubscribeAsync(OnNextAsync);
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


        public async Task OnNextAsync(IONEEventMessage oneEventMessage, StreamSequenceToken? token = null)
        {
            Logger.LogInformation("InitiateFlow");
            XDocument myxml = XDocument.Load(@"C:\Work\AWC\AWC 4.0\ONE\ONE.Silo\Grains\EventProcessor\TestXmlBlock\FirstActivation.xml");
            InitiateFlow(myxml.ToString(), oneEventMessage);
        }

        /// <summary>
        /// Initiates the flow.
        /// </summary>
        /// <param name="flowConfigurationXml">The flow configuration XML.</param>
        /// <param name="message">The message.</param>
        public void InitiateFlow(string flowConfigurationXml, IONEEventMessage oneEventMessage)
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
                    //Create a new event flow for the root event block and add it to the active event flows
                    EventFlow flowToInitiate = new EventFlow(rootEventBlock, oneEventMessage.GlobalTrackingGuid, oneEventMessage.EventInstanceGUID, oneEventMessage.EventFlowGUID, oneEventMessage.InitiatorGUID, oneEventMessage.EventType, flowConfigurationXml);
                    flowToInitiate.EventFlowCompleted += FlowToInitiate_EventFlowCompleted;
                    //  _activeEventFlows.Add(flowToInitiate);



                    //Initate the flow
                    flowToInitiate.EventFlowTask.Start();
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
            Type odinConfigurationBlockType = _configurationBlockTypeMap[blockTypeName];

            //Return a new instance of that type
            ONEConfigurationBlock currentBlock = Activator.CreateInstance(odinConfigurationBlockType) as ONEConfigurationBlock;

            //Check to see if there are any statement nodes, and if so build those up
            XmlNodeList statementNodes = currentNode.SelectNodes("./ns:statement", nsmgr);
            if (statementNodes != null && statementNodes.Count > 0)
            {
                //Get all of the statement properties for current block
                IEnumerable<PropertyInfo> statementProperties = odinConfigurationBlockType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BlocklyConfigurationStatementInfoAttribute)));

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
                IEnumerable<PropertyInfo> fieldProperties = odinConfigurationBlockType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BlocklyConfigurationFieldInfoAttribute)));

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
                IEnumerable<PropertyInfo> valueProperties = odinConfigurationBlockType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(BlocklyConfigurationValueInfoAttribute)));

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
                        ONEConfigurationBlock odinConfigurationBlock = BuildConfigurationBlockFlowGraph(blockNode, nsmgr);


                        PropertyInfo valueProperty;
                        if (odinConfigurationBlock != null && valueNodeProperties != null && valueNodeProperties.Count() > 1)
                        {
                            valueProperty = valueNodeProperties.Where(x => ((BlocklyConfigurationValueInfoAttribute)x.GetCustomAttribute(typeof(BlocklyConfigurationValueInfoAttribute))).ValueType == odinConfigurationBlock.GetType().BaseType.GenericTypeArguments[0]).FirstOrDefault();
                        }
                        else
                        {
                            valueProperty = valueNodeProperties.FirstOrDefault();
                        }

                        //Determine if the current block node is an Optional Input placeholder
                        //If it is, set it to null, otherwise set the current block value property to the configuration block.
                        //This gives us the ability to create optional parameters in blocks and fill in the holes
                        //with Default Input Blocks.
                        if (odinConfigurationBlock.GetType().IsSubclassOf(typeof(ONEConfigurationOutputBlock<OptionalInput>)))
                        {
                            //It is an Optional Input, so make the value property null.
                            valueProperty.SetValue(currentBlock, null);
                        }
                        else
                        {
                            //Try to set the value using a type converter
                            valueProperty.SetValue(currentBlock, odinConfigurationBlock);
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

                //Find all OdinConfigurationBlockStatement properties
                //Check to see if the FirstStatementBlock property is not null, and if not, call the SetRootEventBlock on it
                List<PropertyInfo> odinConfigurationBlockStatementProperties = currentBlock.GetType().GetProperties().Where(x => x.PropertyType == typeof(ONEConfigurationBlockStatement)).ToList();

                //Iterate all of the properties and see if the OdinConfigurationBlockStatement properties are not null
                foreach (PropertyInfo odinConfigurationBlockStatementProperty in odinConfigurationBlockStatementProperties)
                {
                    ONEConfigurationBlockStatement odinConfigurationBlockStatement = odinConfigurationBlockStatementProperty.GetValue(currentBlock) as ONEConfigurationBlockStatement;

                    if (odinConfigurationBlockStatement != null)
                    {
                        //Its not null, so see if the first statement block property is not null, and if not, set its root element
                        SetRootEventBlockAllProperties(odinConfigurationBlockStatement, rootEventBlock);
                    }
                }

                //Set the root event block for all of the inline value properties that are assignable from OdinConfigurationBlock
                SetRootEventBlockAllProperties(currentBlock, rootEventBlock);
            }
            else
            {
                //Not a statement block, so try to set the root event block on all properties that are assignable from OdinConfigurationBlock
                SetRootEventBlockAllProperties(currentBlock, rootEventBlock);
            }
        }

        /// <summary>
        /// Sets the root event block all properties that are assignable from OdinConfigurationBlock
        /// </summary>
        /// <param name="currentObject">The current object.</param>
        /// <param name="rootEventBlock">The root event block.</param>
        private void SetRootEventBlockAllProperties(object currentObject, ONEConfigurationEventBlock rootEventBlock)
        {
            //Get all of the public instance properties
            PropertyInfo[] propertyInfos = currentObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //Iterate all of the properties to find those properties that inherit from OdinConfigurationBlock
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name != "RootEventBlock")
                {
                    //Determine if this property is OdinConfigurationBlock or is inherited from OdinConfigurationBlock
                    if (typeof(ONEConfigurationBlock).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        //It is, so get the property value
                        ONEConfigurationBlock odinConfigurationBlockPropertyValue = propertyInfo.GetValue(currentObject) as ONEConfigurationBlock;

                        //Make sure the property value is not null
                        if (odinConfigurationBlockPropertyValue != null)
                        {
                            //It's not, so set the root event block for this OdinConfigurationBlock property
                            SetRootEventBlock(odinConfigurationBlockPropertyValue, rootEventBlock);
                        }
                    }
                    //Or of it is an array whose array type is OdinConfigurationBlock or is inherited from OdinConfigurationBlock
                    else if (propertyInfo.PropertyType.IsArray && typeof(ONEConfigurationBlock).IsAssignableFrom(propertyInfo.PropertyType.GetElementType()))
                    {
                        Array arrayPropertyValue = propertyInfo.GetValue(currentObject) as Array;

                        //It is an array of the correct type
                        foreach (object element in arrayPropertyValue)
                        {
                            ONEConfigurationBlock odinConfigurationBlockPropertyValue = element as ONEConfigurationBlock;

                            //Make sure the property value is not null
                            if (odinConfigurationBlockPropertyValue != null)
                            {
                                //It's not, so set the root event block for this OdinConfigurationBlock property
                                SetRootEventBlock(odinConfigurationBlockPropertyValue, rootEventBlock);
                            }
                        }
                    }
                    else if (propertyInfo.PropertyType == typeof(ONEConfigurationBlockStatement))
                    {
                        //It is, so get the property value
                        ONEConfigurationBlockStatement odinConfigurationStatementBlockPropertyValue = propertyInfo.GetValue(currentObject) as ONEConfigurationBlockStatement;

                        //Make sure the property value is not null
                        if (odinConfigurationStatementBlockPropertyValue != null)
                        {
                            //It's not, so set the root event block for this OdinConfigurationBlock property
                            SetRootEventBlock(odinConfigurationStatementBlockPropertyValue.FirstStatementBlock, rootEventBlock);
                        }
                    }

                }
            }
        }

        #endregion
    }
}
