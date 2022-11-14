using ONE.DataAccess.Models;
using ONE.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONE.DataAccess.Repositories
{
    public class ActiveEventFlowExecutionTrackingRepository : IActiveEventFlowExecutionTrackingRepository
    {

        private readonly ONEContext _oneContext;

        public ActiveEventFlowExecutionTrackingRepository(ONEContext oneDBContext)
        {
            _oneContext = oneDBContext;
        }

        public void AddActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTracking)
        {
            try
            {

                ActiveEventFlowExecutionTracking eventFlowActivationBlockTrack = new ActiveEventFlowExecutionTracking()
                {
                    ActiveEventFlowExecutionTrackingGuid = System.Guid.NewGuid(),
                    InitiatorGuid = activeEventFlowExecutionTracking.InitiatorGuid,
                    EventFlowGuid = activeEventFlowExecutionTracking.EventFlowGuid,
                    EventTypeCode = activeEventFlowExecutionTracking.EventTypeCode,
                    EventFlowXml = activeEventFlowExecutionTracking.EventFlowXml,
                    GlobalTrackingGuid = activeEventFlowExecutionTracking.GlobalTrackingGuid,
                    EventInstanceGuid = activeEventFlowExecutionTracking.EventInstanceGuid,
                    EventData = activeEventFlowExecutionTracking.EventData,
                    TriggeredByEventFlowInstanceGuid = activeEventFlowExecutionTracking.EventInstanceGuid,
                    EventFlowLogDetailXml = activeEventFlowExecutionTracking.EventFlowLogDetailXml,
                    HaltedByEventFlowInstanceGuid = activeEventFlowExecutionTracking.HaltedByEventFlowInstanceGuid,
                    StopAudioOnEventFlowHalt = activeEventFlowExecutionTracking.StopAudioOnEventFlowHalt

                };

                _oneContext.ActiveEventFlowExecutionTrackings.Add(eventFlowActivationBlockTrack);
                _oneContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        public void UpdateActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            try
            {
                ActiveEventFlowExecutionTracking activeEventFlowExecutionTracking = _oneContext.ActiveEventFlowExecutionTrackings.Where(x => x.InitiatorGuid == activeEventFlowExecutionTrackingInfo.InitiatorGuid
                                                                               && x.EventFlowGuid == activeEventFlowExecutionTrackingInfo.EventFlowGuid
                                                                               && x.EventTypeCode == activeEventFlowExecutionTrackingInfo.EventTypeCode).FirstOrDefault();
                activeEventFlowExecutionTracking.EventFlowState = activeEventFlowExecutionTrackingInfo.EventFlowState;
                _oneContext.SaveChanges();
            }
            catch
            {
                throw;
            }

        }



        public ActiveEventFlowExecutionTrackingInfo GetActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            ActiveEventFlowExecutionTrackingInfo ActiveEventFlowExecutionTrack = (from efabt in _oneContext.ActiveEventFlowExecutionTrackings
                                                                                  where efabt.InitiatorGuid == activeEventFlowExecutionTrackingInfo.InitiatorGuid
                                                                                  && efabt.EventFlowGuid == activeEventFlowExecutionTrackingInfo.EventFlowGuid
                                                                                  && efabt.EventTypeCode == activeEventFlowExecutionTrackingInfo.EventTypeCode
                                                                                  select new ActiveEventFlowExecutionTrackingInfo
                                                                                  {
                                                                                      EventFlowActivationBlockTrackGuid = efabt.ActiveEventFlowExecutionTrackingGuid,
                                                                                      InitiatorGuid = efabt.InitiatorGuid,
                                                                                      EventFlowGuid = efabt.EventFlowGuid,
                                                                                      EventTypeCode = efabt.EventTypeCode,
                                                                                      EventFlowXml = efabt.EventFlowXml,
                                                                                      EventFlowState = efabt.EventFlowState,
                                                                                      GlobalTrackingGuid = new Guid(efabt.GlobalTrackingGuid.ToString()),
                                                                                      EventInstanceGuid = new Guid(efabt.EventInstanceGuid.ToString()),
                                                                                      EventData = efabt.EventData,
                                                                                      TriggeredByEventFlowInstanceGuid = efabt.EventInstanceGuid,
                                                                                      EventFlowLogDetailXml = efabt.EventFlowLogDetailXml,
                                                                                      HaltedByEventFlowInstanceGuid = efabt.HaltedByEventFlowInstanceGuid,
                                                                                      StopAudioOnEventFlowHalt = efabt.StopAudioOnEventFlowHalt
                                                                                  }).FirstOrDefault();

            return ActiveEventFlowExecutionTrack;
        }

        public List<ActiveEventFlowExecutionTrackingInfo> GetActiveEventFlowExecutionTracking()
        {
            List<ActiveEventFlowExecutionTrackingInfo> ActiveEventFlowExecutionTracks = (from efabt in _oneContext.ActiveEventFlowExecutionTrackings

                                                                                         select new ActiveEventFlowExecutionTrackingInfo
                                                                                         {
                                                                                             EventFlowActivationBlockTrackGuid = efabt.ActiveEventFlowExecutionTrackingGuid,
                                                                                             InitiatorGuid = efabt.InitiatorGuid,
                                                                                             EventFlowGuid = efabt.EventFlowGuid,
                                                                                             EventTypeCode = efabt.EventTypeCode,
                                                                                             EventFlowXml = efabt.EventFlowXml,
                                                                                         }).ToList();

            return ActiveEventFlowExecutionTracks;
        }


        public void DeleteActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {
            try
            {
                ActiveEventFlowExecutionTracking activeEventFlowExecutionTracking = _oneContext.ActiveEventFlowExecutionTrackings.Where(x => x.InitiatorGuid == activeEventFlowExecutionTrackingInfo.InitiatorGuid
                                                                               && x.EventFlowGuid == activeEventFlowExecutionTrackingInfo.EventFlowGuid
                                                                               && x.EventTypeCode == activeEventFlowExecutionTrackingInfo.EventTypeCode).FirstOrDefault();
                if (activeEventFlowExecutionTracking != null)
                {
                    _oneContext.ActiveEventFlowExecutionTrackings.Attach(activeEventFlowExecutionTracking);
                    _oneContext.ActiveEventFlowExecutionTrackings.Remove(activeEventFlowExecutionTracking);
                    _oneContext.SaveChanges();
                }

            }
            catch
            {
                throw;
            }

        }

    }
}
