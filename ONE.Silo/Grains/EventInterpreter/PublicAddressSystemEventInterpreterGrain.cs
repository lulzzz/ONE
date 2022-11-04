using Microsoft.Extensions.Logging;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.EventInterpreter;
using ONE.Models.Domain;
using ONE.Models.Enumerations;
using ONE.Models.MessageContracts;
using Orleans;
using Orleans.Streams;
using System;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventInterpreter
{
    [ImplicitStreamSubscription(ONEStreams.PUBLIC_ADDRESS_SYSTEM_EVENT_INTERPRETER)]
    public class PublicAddressSystemEventInterpreterGrain : GrainBase, IPublicAddressSystemEventInterpreterGrain
    {
        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var stream = streamProvider.GetStream<FrequencyAgileMessage>(new Guid(GrainId), ONEStreams.PUBLIC_ADDRESS_SYSTEM_EVENT_INTERPRETER);
            await stream.SubscribeAsync(OnNextAsync);
        }

        public override Task OnDeactivateAsync()
        {
            Logger.LogDebug("Grain deactivated");
            return base.OnDeactivateAsync();
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

        public async Task OnNextAsync(FrequencyAgileMessage publicAddressSystemMessage, StreamSequenceToken? token = null)
        {

            IONEEventMessage oneEventMessage = new ONEEventMessage();
            oneEventMessage.EventInstanceGUID = Guid.Empty;
            oneEventMessage.Payload = "";
            oneEventMessage.InitiatorGUID = Guid.Empty;
            oneEventMessage.EventFlowGUID = Guid.Empty;
            oneEventMessage.EventType = EventType.FirstActivation;
            oneEventMessage.GlobalTrackingGuid = new Guid();
            await SendProcessorEventMessage(oneEventMessage);
        }


        public async Task SendProcessorEventMessage(IONEEventMessage oneEventMessage)
        {
            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var eventStream = streamProvider.GetStream<IONEEventMessage>(GrainIdAsGuid, ONEStreams.EVENT_PROCESSOR);
            await eventStream.OnNextAsync(oneEventMessage);
        }
    }
}
