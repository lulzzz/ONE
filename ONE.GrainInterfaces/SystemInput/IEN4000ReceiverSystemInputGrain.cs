using Orleans;
using Orleans.Concurrency;
using Orleans.Streams;

namespace ONE.GrainInterfaces.SystemInput
{
    public interface IEN4000ReceiverSystemInputGrain : IGrainWithStringKey, IAsyncObserver<Immutable<byte[]>>
    {
    }
}
