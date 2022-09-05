using Microsoft.Extensions.Logging;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.SystemInput;
using ONE.Models.Domain;
using Orleans;
using Orleans.Concurrency;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.SystemInput
{
    [ImplicitStreamSubscription(ONEStreams.FREQUENCY_AGILE_SYSTEM_INPUT)]
    public class FrequencyAgileSystemInputGrain : GrainBase, IFrequencyAgileSystemInputGrain
    {
        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var stream = streamProvider.GetStream<Immutable<byte[]>>(this.GetPrimaryKey(), ONEStreams.FREQUENCY_AGILE_SYSTEM_INPUT);
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

        public async Task OnNextAsync(Immutable<byte[]> item, StreamSequenceToken? token = null)
        {
            FrequencyAgileMessage publicAddressSystemMessage = new FrequencyAgileMessage();
            publicAddressSystemMessage.Message = "ONE 4.0";

            Logger.LogInformation($"Message is being routed to : PublicAddressSystemEventInterpreterGrain");
            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var eventStream = streamProvider.GetStream<FrequencyAgileMessage>(GrainIdAsGuid, ONEStreams.PUBLIC_ADDRESS_SYSTEM_EVENT_INTERPRETER);
            await eventStream.OnNextAsync(publicAddressSystemMessage);
        }
    }
}
