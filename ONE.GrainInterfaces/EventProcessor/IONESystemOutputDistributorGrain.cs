using Orleans;
using System.Threading.Tasks;

namespace ONE.GrainInterfaces.EventProcessor
{
    public interface IONESystemOutputDistributorGrain : IGrainWithStringKey
    {
        Task SendDataToSystemIO(byte[] payload, string grainKey);
    }
}
