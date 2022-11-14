using Newtonsoft.Json;
using ONE.GrainInterfaces.EventInterpreter;
using ONE.Models.Domain;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_action_add_event_to_dashboard")]
    public class AddEventToDashboardActionBlock : ONEConfigurationBlock
    {
        [BlocklyConfigurationValueInfo(ValueName = "locationName")]
        public ONEConfigurationOutputBlock<string> LocationName { get; set; }

        private ChannelEventInfo _channelEventInfo { get; set; }
        protected override async Task Execute()
        {
            try
            {

                await SetChannelEventInfo();

                string serverBaseUrl = "http://localhost/Odin.Compute.Web.API/";

                await SendRequestToEndPoint(serverBaseUrl);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task SetChannelEventInfo()
        {
            _channelEventInfo = new ChannelEventInfo();

            _channelEventInfo.Name = this.RootEventBlock.EventFlow.EventType.ToString();

            string applianceGuid = "6bf6f5a3-7d89-465d-b083-9641b493053d";
            var grain = this.RootEventBlock.GrainFactory.GetGrain<IEventInterpreterRouterGrain>($"{applianceGuid}_EventInterpreterRouter");

            InitiatorInfo initiatorInfo = await grain.GetInitiatorInfo(this.RootEventBlock.ONEEventMessage.InitiatorGUID);
            string location = initiatorInfo.CustomerLocationSectionName;

            string json = JsonConvert.SerializeObject(initiatorInfo);
            DashboardEventInfo dashboardEventInfo = new DashboardEventInfo()
            {
                EventType = this.RootEventBlock.EventFlow.EventType.ToString(),
                LocationSectionName = location,
                InitiatorInfo = null,
                ActivationTime = DateTime.UtcNow,
                CustomerGuid = initiatorInfo.CustomerGuid,
                CustomerLocationGuid = initiatorInfo.CustomerLocationGuid,
                CustomerLocationName = initiatorInfo.CustomerLocationName,
                ActivationTimeUTCMilliseconds = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds,
                CurrentServerTime = DateTime.UtcNow,
                CurrentServerTimeUTCMilliseconds = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds,

            };
            _channelEventInfo.InitiatorGuid = initiatorInfo.InitiatorGuid;



            _channelEventInfo.GlobalTrackingGuid = this.RootEventBlock.ONEEventMessage.GlobalTrackingGuid;
            _channelEventInfo.Data = dashboardEventInfo;


        }

        private async Task SendRequestToEndPoint(string serverBaseUrl)
        {

            //Build the URL 
            string addEventToDashboardUrl = String.Format("{0}api/Dashboard/AddEventToDashboard", serverBaseUrl);

            //Create a new HTTP client
            using (var client = new HttpClient())
            {
                //Create the url for the server
                client.BaseAddress = new Uri(serverBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.PostAsJsonAsync(addEventToDashboardUrl, _channelEventInfo);

                //Check if we were successful, if so, deserialize, otherwise throw execptions
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    throw new Exception($"Failed trying to add event to dashboard");
                }
            }
        }


    }
}
