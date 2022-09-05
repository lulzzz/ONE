using Orleans;
using Orleans.Concurrency;
using Orleans.Streams;

namespace ONE.GrainInterfaces.SystemInput
{
    public interface IFrequencyAgileSystemInputGrain : IGrainWithStringKey, IAsyncObserver<Immutable<byte[]>>
    {
    }
}
