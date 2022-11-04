using ONE.Models.MessageContracts;
using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;

namespace ONE.GrainInterfaces.EventProcessor
{
    public interface IEventProcessor : IGrainWithStringKey
    {
        [AlwaysInterleave]
        Task ProcessExecutionFlow(IONEEventMessage oneEventMessage);
    }
}
