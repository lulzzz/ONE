using ONE.GrainInterfaces.EventInterpreter;
using ONE.Models.Domain;
using ONE.Models.Enumerations;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_action_remove_event_from_dashboard")]
    public class ClearEventFromDashboardActionBlock : ONEConfigurationBlock
    {
        private ChannelEventInfo _channelEventInfo { get; set; }

        protected override async Task Execute()
        {
            try
            {

                await SetChannelEventInfo();

                //Transmit over radio
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



            //If the current event type is an activation, and if this block is added to execute after activation time out. 
            //we need to manually set the event type as Clear.
            if (this.RootEventBlock.EventFlow.EventType == EventType.FirstActivation)
            {
                _channelEventInfo.Name = EventType.FirstActivationClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.SecondActivation)
            {
                _channelEventInfo.Name = EventType.SecondActivationClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.ThirdActivation)
            {
                _channelEventInfo.Name = EventType.ThirdActivationClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.FourthActivation)
            {
                _channelEventInfo.Name = EventType.FourthActivationClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.CheckinFailure)
            {
                _channelEventInfo.Name = EventType.CheckinFailureClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.InternalLowBattery)
            {
                _channelEventInfo.Name = EventType.InternalLowBatteryClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.PrimaryLowBattery)
            {
                _channelEventInfo.Name = EventType.PrimaryLowBatteryClear.ToString();
            }
            else if (this.RootEventBlock.EventFlow.EventType == EventType.Tamper)
            {
                _channelEventInfo.Name = EventType.TamperClear.ToString();
            }

            string applianceGuid = "6bf6f5a3-7d89-465d-b083-9641b493053d";
            var grain = this.RootEventBlock.GrainFactory.GetGrain<IEventInterpreterRouterGrain>($"{applianceGuid}_EventInterpreterRouter");

            InitiatorInfo initiatorInfo = await grain.GetInitiatorInfo(this.RootEventBlock.ONEEventMessage.InitiatorGUID);
            string location = initiatorInfo.CustomerLocationSectionName;


            DashboardEventInfo dashboardEventInfo = new DashboardEventInfo()
            {
                // InitiatorInfo = initiatorInfo,
                EventType = this.RootEventBlock.EventFlow.EventType.ToString(),
                ActivationTime = DateTime.UtcNow,
                CustomerGuid = initiatorInfo.CustomerGuid,
                CustomerLocationGuid = initiatorInfo.CustomerLocationGuid,
                ActivationTimeUTCMilliseconds = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds,
                IsClearEvent = true
            };


            _channelEventInfo.GlobalTrackingGuid = this.RootEventBlock.ONEEventMessage.GlobalTrackingGuid;
            _channelEventInfo.InitiatorGuid = initiatorInfo.InitiatorGuid;
            _channelEventInfo.Data = dashboardEventInfo;
        }

        private async Task SendRequestToEndPoint(string serverBaseUrl)
        {
            //Build the URL 
            string clearEventFromDashboardUrl = String.Format("{0}api/Dashboard/ClearEventFromDashboard", serverBaseUrl);


            //Create a new HTTP client
            using (var client = new HttpClient())
            {
                //Create the url for the server
                client.BaseAddress = new Uri(serverBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = await client.PostAsJsonAsync(clearEventFromDashboardUrl, _channelEventInfo);

                //Check if we were successful, if so, deserialize, otherwise throw execptions
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    throw new Exception($"Failed trying to clear event from Cloud dashboard");
                }
            }
        }


    }
}
