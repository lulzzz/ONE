using Orleans;
using System;
using System.Threading.Tasks;

namespace ONE.GrainInterfaces
{
    /// <summary>
    /// Base interface for grain that is to always be activated.  Initial activation must occur on booting because this grain does not 
    /// regularly receive device data 
    /// </summary>
    public interface IActiveGrain : IGrainWithStringKey
    {
        /// <summary>
        /// Simple no op endpoint to ensure the grain is activated
        /// </summary>
        /// <returns>The timestamp of when the grain was activated</returns>
        Task<DateTimeOffset> EnsureInitialized();
    }
}
