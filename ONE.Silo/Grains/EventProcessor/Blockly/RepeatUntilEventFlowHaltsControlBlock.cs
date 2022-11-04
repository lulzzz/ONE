using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "one_controls_repeat_until_event_flow_halts")]
    public class RepeatUntilEventFlowHaltsControlBlock : ONEConfigurationStatementBlock
    {
        [BlocklyConfigurationStatementInfoAttribute(StatementName = "elementsToRepeat")]
        public ONEConfigurationBlockStatement ElementsToRepeatStatement { get; set; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        protected override async Task Execute()
        {
            await SetActiveEventFlowExecutionBlockState();

            //Repeat utnil this event flow is halted
            while (!this.RootEventBlock.IsEventFlowHalted)
            {
                // Check to see if the first statement block is available, and if so, execute the flow
                if (ElementsToRepeatStatement.FirstStatementBlock != null)
                {
                    await ElementsToRepeatStatement.FirstStatementBlock.ExecuteFlow();
                }


            }
        }

    }

}
