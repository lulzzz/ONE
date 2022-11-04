using System;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public abstract class ONEConfigurationOutputBlock<T> : ONEConfigurationBlock
    {

        protected override Task Execute()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetOutput()
        {
            return Task.FromResult(default(T));
        }
    }

}
