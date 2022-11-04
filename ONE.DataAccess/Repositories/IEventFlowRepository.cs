using ONE.Models.Domain;
using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Repositories
{
    public interface IEventFlowRepository
    {
        List<EventFlowInfo> GetAllEventFlows();
        EventFlowInfo GetEventFlowInfoByEventFlowGuid(Guid eventFlowGuid);
    }
}
