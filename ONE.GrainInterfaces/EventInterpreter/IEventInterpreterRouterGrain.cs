using ONE.Models.Domain;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ONE.GrainInterfaces.EventInterpreter
{
    public interface IEventInterpreterRouterGrain : IGrainWithStringKey
    {
        Task<List<InitiatorInfo>> GetInterpreterInitiatorInfos();
        Task<string> GetMatchingEventInterpreterName(int serialNumber);
    }
}
