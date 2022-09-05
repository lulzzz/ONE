using Microsoft.Extensions.Logging;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.EventInterpreter;
using ONE.GrainInterfaces.SystemInput;
using ONE.Models.Domain;
using Orleans;
using Orleans.Concurrency;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.SystemInput
{
    [ImplicitStreamSubscription(ONEStreams.EN4000_RECEIVERE_SYSTEM_INPUT)]
    public class EN4000ReceiverSystemInputGrain : GrainBase, IEN4000ReceiverSystemInputGrain
    {
        private int _packetCount = 0;

        private IDisposable? _timer;
        private static readonly object padlock = new object();

        //These are the tracked messages to allow us to only send a single item at a time
        private List<TrackedEchoStreamMessage> _trackedEchoStreamMessages = new List<TrackedEchoStreamMessage>();

        public override async Task OnActivateAsync()
        {
            _timer = RegisterTimer(CheckMessagesReadyToPublish, null, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(2));

            await base.OnActivateAsync();

            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var stream = streamProvider.GetStream<Immutable<byte[]>>(this.GetPrimaryKey(), ONEStreams.EN4000_RECEIVERE_SYSTEM_INPUT);
            await stream.SubscribeAsync(OnNextAsync);
        }

        public override Task OnDeactivateAsync()
        {
            Logger.LogDebug("Grain deactivated");
            _timer?.Dispose();
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
            EchoStreamMessageExtractor echoStreamMessageExtractor = new EchoStreamMessageExtractor();
            List<EchoStreamMessage> echoStreamMessages = echoStreamMessageExtractor.GetEchoStreamMessagesFromData(item.Value);
            ProcessNewMessagesToPublish(echoStreamMessages);
        }



        private void ProcessNewMessagesToPublish(List<EchoStreamMessage> candidateEchoStreamMessagesToPublish)
        {

            //Iterate all of the candidates and see if they already exist in the tracked items
            foreach (EchoStreamMessage candidateEchoStreamMessageToPublish in candidateEchoStreamMessagesToPublish)
            {

                //Set Global Tracking Guid
                Guid globalTrackingGuid = Guid.NewGuid();

                candidateEchoStreamMessageToPublish.GlobalTrackingGuid = globalTrackingGuid;

                lock (padlock)
                {
                    //Try to find matching unpublished messages in tracked messages
                    List<TrackedEchoStreamMessage> matchingTrackedItems = _trackedEchoStreamMessages.Where(
                    x => x.EchoStreamMessage.OriginatorUniqueId == candidateEchoStreamMessageToPublish.OriginatorUniqueId
                    && x.PublishedTime == default).ToList();

                    //Determine if we've found a match
                    if (matchingTrackedItems.Count == 0)
                    {
                        //This message is not currently in the tracked items, so add it to the tracked items

                        _trackedEchoStreamMessages.Add(new TrackedEchoStreamMessage
                        {
                            EchoStreamMessage = candidateEchoStreamMessageToPublish,
                            PublishedTime = default,
                            TimeToPublish = DateTime.UtcNow.AddMilliseconds(10)

                        });
                    }
                    else
                    {
                        //A new message with different primary or secondary status flags are set
                        //Publish the candidateEchoStreamMessageToPublish and add candidateEchoStreamMessageToPublish to the tracking                        

                        //Add the new message to the tracked messages. 
                        _trackedEchoStreamMessages.Add(new TrackedEchoStreamMessage
                        {
                            EchoStreamMessage = candidateEchoStreamMessageToPublish,
                            PublishedTime = default,
                            TimeToPublish = DateTime.UtcNow.AddMilliseconds(10)

                        });

                    }
                }

            }
        }



        /// <summary>
        ///  Check whether there are any messages to publish
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private async Task CheckMessagesReadyToPublish(object arg)
        {
            try
            {
                foreach (TrackedEchoStreamMessage trackedMessage in _trackedEchoStreamMessages.ToList())
                {
                    //Messages in the tracking items should transmitted to RabbitMQ when the current UTC time is greater than the tracked item's TimeToPublish value.
                    //When the TimeToPublish has been reached, set the PublishedTime to DateTime.UtcNow and send this message to RabbitMQ
                    if (trackedMessage.PublishedTime == default && DateTime.UtcNow >= trackedMessage.TimeToPublish)
                    {
                        //Set published time to prevent duplicate publishing
                        trackedMessage.PublishedTime = DateTime.UtcNow;
                        EchoStreamMessage echoStreamMessageToPublish = trackedMessage.EchoStreamMessage;
                        Logger.LogInformation($"PublishedTime: {trackedMessage.PublishedTime}");
                    }

                    //Gets the matching event interpreter based on the serial number, to route the message. 
                    string eventInterpreterName = await GetTargetEventInterpreterGrain(trackedMessage);

                    if (!string.IsNullOrEmpty(eventInterpreterName))
                    {
                        //A tracked message is removed from the list of tracked items when the following condition is met:                            
                        //The PublishedTime value + 5 seconds is <= DateTime.UtcNow
                        _trackedEchoStreamMessages.Remove(trackedMessage);


                        Logger.LogInformation($"Message is being routed to : {eventInterpreterName}");
                        var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
                        var eventStream = streamProvider.GetStream<EchoStreamMessage>(GrainIdAsGuid, eventInterpreterName);
                        await eventStream.OnNextAsync(trackedMessage.EchoStreamMessage);

                    }

                }

            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in CheckMessagesReadyToPublish {ex} : GrainId:{this.GrainId}");
            }

        }

        private async Task<string> GetTargetEventInterpreterGrain(TrackedEchoStreamMessage trackedMessage)
        {
            var eventInterpreterRouterGrain = GrainFactory.GetGrain<IEventInterpreterRouterGrain>($"{GrainIdAsGuid}_EventInterpreterRouter");
            string eventInterpreterName = await Task.FromResult(eventInterpreterRouterGrain.GetMatchingEventInterpreterName(trackedMessage.EchoStreamMessage.OriginatorUniqueId)).Result;
            return eventInterpreterName;
        }
    }
}
