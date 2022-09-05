using ONE.Models.MessageContracts;
using Orleans;
using Orleans.Streams;

namespace ONE.GrainInterfaces.EventProcessor
{
    public interface IEventProcessor : IGrainWithStringKey, IAsyncObserver<IONEEventMessage>
    {

    }
}
