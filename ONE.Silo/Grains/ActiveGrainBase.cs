using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ONE.GrainInterfaces;
using ONE.Models.Options;
using Orleans;
using Orleans.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ONE.Silo.Grains
{
    /// <summary>
    /// Base grain class that uses a reminder to ensure the grain is always activated. 
    /// Active Grain options class has setting for maximum time that the grain can remain inactive
    /// </summary>
    public class ActiveGrainBase : GrainBase, IGrainWithStringKey, IActiveGrain, IRemindable
    {
        private DateTimeOffset _activation;
        private IOptions<ActiveGrainOptions>? _options;
        private const string KEEP_ALIVE = "keep_alive";
        // since this is a base class and we don't want all children to have to use ctor injection for these base level dependencies we will resolve 
        // with Service provider here
        protected override Task CreateBaseDependencies(CancellationToken cancel)
        {
            _options = this.ServiceProvider.GetRequiredService<IOptions<ActiveGrainOptions>>();
            return base.CreateBaseDependencies(cancel);
        }

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            var time = _options?.Value?.KeepAliveReminderTime;

            if (time != null)
            {
                // register reminder to ensure that the grain stays active
                await this.RegisterOrUpdateReminder(KEEP_ALIVE, time.Value, time.Value);
            }

            _activation = DateTimeOffset.UtcNow;

            if (Logger.IsEnabled(LogLevel.Debug))
            {
                Logger.LogDebug("Grain activate at: {timestamp}", _activation);
            }
        }



        /// <summary>
        /// Ensures the grain is active...this is a no op, but can be used to 
        /// </summary>
        /// <returns>The time stamp of when the grain was activated</returns>
        public Task<DateTimeOffset> EnsureInitialized() => Task.FromResult(_activation);

        public Task ReceiveReminder(string reminderName, TickStatus status)
        {
            if (reminderName == KEEP_ALIVE)
            {
                if (Logger.IsEnabled(LogLevel.Debug))
                {
                    Logger.LogDebug("Keep alive reminder received");
                }
            }
            return Task.CompletedTask;
        }
    }
}
