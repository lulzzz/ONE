using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ONE.GrainInterfaces;
using Orleans;
using Orleans.Runtime;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ONE.Silo.Grains
{
    public class GrainBase : Grain, IGrainWithStringKey
    {
        // logger for the grain
        protected ILogger Logger { get; private set; } = NullLogger.Instance;
        private readonly IDisposable? _loggerScope;

        protected string GrainId => this.GetPrimaryKeyString() ?? this.GetPrimaryKey().ToString();

        protected Guid GrainIdAsGuid => GrainIdHelpers.GetGrainIdAsGuid(GrainId);

        // this little trick to use the grain lifecyle to create the logger instead of requiring all 
        // base classes to use constructor injection and pass it
        public override void Participate(IGrainLifecycle lifecycle)
        {
            base.Participate(lifecycle);
            lifecycle.Subscribe(this.GetType().FullName, GrainLifecycleStage.First, CreateBaseDependencies);
        }

        protected virtual Task CreateBaseDependencies(CancellationToken cancel)
        {
            var type = this.GetType();
            var loggerFactory = this.ServiceProvider.GetRequiredService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger(type);

            // TODO: add log scope properties like grain ID etc, so that they always get logged automatically?

            return Task.CompletedTask;
        }

    }
}
