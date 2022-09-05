using ONE.Models.Domain;
using ONE.Models.MessageContracts;
using Orleans;
using Orleans.Streams;
using System.Threading.Tasks;

namespace ONE.GrainInterfaces.EventInterpreter
{
    public interface IEchoStreamEventInterpreter : IGrainWithStringKey, IAsyncObserver<EchoStreamMessage>
    {
        Task SendEventMessageForProcessing(IONEEventMessage initiatorEventFlowTrackingItemInfo);
    }
}
