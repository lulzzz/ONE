using System;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public abstract class ONEConfigurationOutputBlock<T> : ONEConfigurationBlock
    {

        protected override void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual T GetOutput()
        {
            return default(T);
        }
    }

}
