using Microsoft.Extensions.Logging;
using ONE.GrainInterfaces;
using ONE.GrainInterfaces.EventInterpreter;
using ONE.Models.Domain;
using ONE.Models.Enumerations;
using ONE.Models.Interpeter;
using ONE.Models.MessageContracts;
using Orleans;
using Orleans.Runtime;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventInterpreter
{
    [ImplicitStreamSubscription(ONEStreams.ECHOSTREAM_EVENT_INTERPRETER)]
    public class EchoStreamEventInterpreterGrain : GrainBase, IEchoStreamEventInterpreter
    {
        private readonly IPersistentState<List<InitiatorEventFlowTrackingItem>> _initiatorEventFlowTrackingItems;

        public EchoStreamEventInterpreterGrain([PersistentState("initiatorEventFlowTrackingItems", "oneDataStore")] IPersistentState<List<InitiatorEventFlowTrackingItem>> initiatorEventFlowTrackingItems)
        {
            _initiatorEventFlowTrackingItems = initiatorEventFlowTrackingItems;
        }

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var stream = streamProvider.GetStream<EchoStreamMessage>(new Guid(GrainId), ONEStreams.ECHOSTREAM_EVENT_INTERPRETER);
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

        public async Task OnNextAsync(EchoStreamMessage echoStreamMessage, StreamSequenceToken? token = null)
        {

            var grain = GrainFactory.GetGrain<IEventInterpreterRouterGrain>($"{GrainId}_EventInterpreterRouter");
            List<InitiatorInfo> initiatorInfos = await grain.GetInterpreterInitiatorInfos();

            InitiatorInfo? initiatorInfo = initiatorInfos.Where(x => x.ConfigurationData.SerialNumber == echoStreamMessage?.OriginatorUniqueId).FirstOrDefault();

            //Set the default event type
            List<TrackedEvent> trackedEventsToPublish = new List<TrackedEvent>();

            if (initiatorInfo != null)
            {
                await InterpretMessage(initiatorInfo, echoStreamMessage, EchoStreamApplicationStatusFlags.PrimaryAlarm, EventType.FirstActivation, EventType.FirstActivationClear);

            }
        }


        public async Task InterpretMessage(InitiatorInfo initiatorInfo, EchoStreamMessage echoStreamMessage, EchoStreamApplicationStatusFlags activationStatusFlag, EventType activationEventType, EventType? activationClearEventType)
        {
            try
            {

                InitiatorEventFlowTrackingItem initiatorEventFlowTrackingItemInfo = new InitiatorEventFlowTrackingItem();
                TrackedEvent trackedEventInfo = new TrackedEvent();
                IONEEventMessage oneEventMessage = new ONEEventMessage();

                InitiatorEventFlowTrackingItem? initiatorEventFlowTrackingItem = _initiatorEventFlowTrackingItems.State.Where(x => x.InitiatorGUID == initiatorInfo.InitiatorGuid).FirstOrDefault();

                if (echoStreamMessage.ApplicationStatusFlags.HasFlag(activationStatusFlag))
                {
                    List<TrackedEvent>? trackedEvents = initiatorEventFlowTrackingItem?.ActiveEvents.Where(x => x.EventType == activationEventType).ToList();
                    if (trackedEvents == null || trackedEvents?.Count() == 0)
                    {

                        trackedEventInfo.EventType = activationEventType;
                        trackedEventInfo.EventInstanceGUID = new Guid();
                        trackedEventInfo.PublishedDateTimeUTC = DateTime.UtcNow;

                        if (initiatorEventFlowTrackingItem != null)
                        {
                            initiatorEventFlowTrackingItem.ActiveEvents.Add(trackedEventInfo);


                        }
                        else
                        {
                            initiatorEventFlowTrackingItemInfo.InitiatorGUID = initiatorInfo.InitiatorGuid;
                            initiatorEventFlowTrackingItemInfo.EventFlowGUID = initiatorInfo.EventFlowGuid;
                            initiatorEventFlowTrackingItemInfo.ActiveEvents.Add(trackedEventInfo);
                            _initiatorEventFlowTrackingItems.State.Add(initiatorEventFlowTrackingItemInfo);
                        }

                        //send to processor
                        await _initiatorEventFlowTrackingItems.WriteStateAsync();

                        oneEventMessage.EventInstanceGUID = trackedEventInfo.EventInstanceGUID;
                        oneEventMessage.Payload = "";
                        oneEventMessage.InitiatorGUID = initiatorInfo.InitiatorGuid;
                        oneEventMessage.EventFlowGUID = initiatorInfo.EventFlowGuid;
                        oneEventMessage.EventType = trackedEventInfo.EventType;
                        oneEventMessage.GlobalTrackingGuid = new Guid();
                        await SendEventMessageForProcessing(oneEventMessage);
                    }
                }
                else
                {
                    //Make sure we have the opposite event type
                    if (activationClearEventType.HasValue)
                    {
                        TrackedEvent? activationEvent = initiatorEventFlowTrackingItem?.ActiveEvents.Where(x => x.EventType == activationEventType).FirstOrDefault();
                        //The current message does not have the flag, so try go get the "has flag" event so that we can send it's opposite event
                        if (activationEvent != null)
                        {

                            initiatorEventFlowTrackingItem?.ActiveEvents.Remove(activationEvent);

                            await _initiatorEventFlowTrackingItems.WriteStateAsync();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        public async Task SendEventMessageForProcessing(IONEEventMessage oneEventMessage)
        {
            var streamProvider = GetStreamProvider(ONEStreams.DefaultProvider);
            var eventStream = streamProvider.GetStream<IONEEventMessage>(GrainIdAsGuid, ONEStreams.EVENT_PROCESSOR);
            await eventStream.OnNextAsync(oneEventMessage);
        }
    }
}
