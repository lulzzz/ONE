namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public abstract class ONEConfigurationStatementBlock : ONEConfigurationBlock
    {
        /// <summary>
        /// Executes the flow
        /// </summary>
        public override void ExecuteFlow()
        {
            this.Execute();

            if (this.NextBlock != null)
            {
                this.NextBlock.RootEventBlock = this.RootEventBlock;
                this.NextBlock.ExecuteFlow();
            }
        }
    }

}
