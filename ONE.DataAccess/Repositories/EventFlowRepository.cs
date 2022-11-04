using ONE.DataAccess.Models;
using ONE.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONE.DataAccess.Repositories
{
    public class EventFlowRepository : IEventFlowRepository
    {

        private readonly ONEContext _oneContext;

        public EventFlowRepository(ONEContext oneDBContext)
        {
            _oneContext = oneDBContext;
        }

        /// <summary>
        /// This gets all eventflows. 
        /// </summary>
        /// <returns></returns>
        public List<EventFlowInfo> GetAllEventFlows()
        {
            var eventFlows = (from e in _oneContext.EventFlows
                              where e.IsActive
                              select new EventFlowInfo
                              {
                                  EventFlowGuid = e.EventFlowGuid,
                                  EventFlowXML = e.EventFlowXml
                              }).ToList();

            return eventFlows;
        }



        public EventFlowInfo GetEventFlowInfoByEventFlowGuid(Guid eventFlowGuid)
        {
            var eventFlowInfo = (from e in _oneContext.EventFlows
                                 where e.EventFlowGuid == eventFlowGuid
                                 select new EventFlowInfo
                                 {
                                     EventFlowGuid = e.EventFlowGuid,
                                     EventFlowXML = e.EventFlowXml
                                 }).FirstOrDefault();

            return eventFlowInfo;
        }
    }
}
