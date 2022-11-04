using Newtonsoft.Json;
using ONE.Models.Domain;
using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public abstract class ONEConfigurationBlock
    {
        public ONEConfigurationEventBlock? RootEventBlock { get; set; }

        public ONEConfigurationBlock? NextBlock { get; set; }
        public string Id { get; set; }
        protected abstract Task Execute();

        public virtual async Task ExecuteFlow()
        {
            try
            {
                //Make sure the current event flow is not halted
                if (!this.RootEventBlock.IsEventFlowHalted)
                {
                    //Logger.Instance.SetGlobalTrackingId(this.RootEventBlock.EventFlow.GlobalTrackingGuid.ToString());
                    await this.Execute();
                    //Make sure the current event flow is not halted
                    if (!this.RootEventBlock.IsEventFlowHalted)
                    {
                        //Execute the next block if it is available
                        if (this.NextBlock != null)
                        {
                            await this.NextBlock.ExecuteFlow();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }





        public virtual Task SetActiveEventFlowExecutionBlockState()
        {
            ONEEventFlowVariable<string> oneEventFlowVariable = new ONEEventFlowVariable<string>();
            if (this.NextBlock != null)
            {
                oneEventFlowVariable.Value = this.NextBlock.Id;

                foreach (var element in this.GetType().GetProperties())
                {
                    if (element.GetValue(this, null)?.GetType() == typeof(ONEConfigurationBlockStatement))
                    {
                        ONEConfigurationBlockStatement oneConfigurationBlockStatement = element.GetValue(this, null) as ONEConfigurationBlockStatement;
                        oneEventFlowVariable.Value = oneConfigurationBlockStatement.FirstStatementBlock.Id;
                    }
                }

            }
            else
            {
                oneEventFlowVariable.Value = this.Id;
            }
            this.RootEventBlock.ONEEventFlowVariableDictionary.AddOrUpdate("ActiveEventFlowExecutionTrackingId", oneEventFlowVariable, (key, oldValue) => oneEventFlowVariable);


            Type type = Type.GetType(this.GetType().FullName, true);
            object instance = Activator.CreateInstance(type);
            foreach (var element in this.GetType().GetProperties())
            {

                if (element.GetCustomAttribute(typeof(BlocklyConfigurationFieldInfoAttribute)) != null)
                {
                    PropertyInfo propertyInfo = type.GetProperty(element.Name);
                    propertyInfo.SetValue(instance, element.GetValue(this, null), null);
                }
            }


            Type shellPropertyType = typeof(ONEEventFlowVariable<>).MakeGenericType(type);
            object oneEventFlowVariableInstance = Activator.CreateInstance(shellPropertyType);

            PropertyInfo oneEventFlowVariableProp = oneEventFlowVariableInstance.GetType().GetProperty("Value");
            oneEventFlowVariableProp.SetValue(oneEventFlowVariableInstance, instance, null);

            this.RootEventBlock.ONEEventFlowVariableDictionary.AddOrUpdate(this.Id, oneEventFlowVariableInstance as ONEEventFlowVariable, (key, oldValue) => oneEventFlowVariableInstance as ONEEventFlowVariable);

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var eventFlowStateJson = JsonConvert.SerializeObject(this.RootEventBlock.ONEEventFlowVariableDictionary, jsonSerializerSettings);
            UpdateActiveEventFlowExecutionBlockState(eventFlowStateJson);

            return Task.CompletedTask;
        }


        public void UpdateActiveEventFlowExecutionBlockState(string eventFlowStateJson)
        {



            ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo = new ActiveEventFlowExecutionTrackingInfo();
            activeEventFlowExecutionTrackingInfo.InitiatorGuid = this.RootEventBlock.ONEEventMessage.InitiatorGUID;
            activeEventFlowExecutionTrackingInfo.EventFlowGuid = this.RootEventBlock.ONEEventMessage.EventFlowGUID;
            activeEventFlowExecutionTrackingInfo.EventTypeCode = (int)this.RootEventBlock.ONEEventMessage.EventType;
            activeEventFlowExecutionTrackingInfo.EventFlowState = eventFlowStateJson;

            //ONEContext oneDBContext = new ONEContext();
            //IActiveEventFlowExecutionTrackingRepository activeEventFlowExecutionTrackingRepository = new ActiveEventFlowExecutionTrackingRepository(oneDBContext);
            //ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrack = activeEventFlowExecutionTrackingRepository.GetActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);





            string activeEventFlowExecutionUrl = $"http://localhost:5000/api/ActiveEventFlowExecution/UpdateActiveEventFlowExecutionBlockState";


            //Create a new HTTP client
            using (var client = new HttpClient())
            {
                //Create the url for the server
                client.BaseAddress = new Uri("http://localhost:5000/api/");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = client.PostAsJsonAsync(activeEventFlowExecutionUrl, activeEventFlowExecutionTrackingInfo).Result;
            }

            //activeEventFlowExecutionTrackingRepository.UpdateActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);
        }

    }
}
