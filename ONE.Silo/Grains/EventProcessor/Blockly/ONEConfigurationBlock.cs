using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using System;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public abstract class ONEConfigurationBlock
    {
        public ONEConfigurationEventBlock? RootEventBlock { get; set; }

        public ONEConfigurationBlock? NextBlock { get; set; }

        protected abstract void Execute();

        public virtual void ExecuteFlow()
        {
            try
            {
                //Make sure the current event flow is not halted
                if (!this.RootEventBlock.IsEventFlowHalted)
                {
                    //Logger.Instance.SetGlobalTrackingId(this.RootEventBlock.EventFlow.GlobalTrackingGuid.ToString());

                    this.Execute();

                    //Make sure the current event flow is not halted
                    if (!this.RootEventBlock.IsEventFlowHalted)
                    {
                        //Execute the next block if it is available
                        if (this.NextBlock != null)
                        {
                            this.NextBlock.ExecuteFlow();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
