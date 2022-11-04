using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "one_controls_repeat")]
    public class RepeatControlBlock : ONEConfigurationStatementBlock
    {
        [BlocklyConfigurationFieldInfo(FieldName = "timesToRepeat")]
        public int TimesToRepeat { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "RepeatedTimes")]
        public int RepeatedTimes { get; set; }

        [BlocklyConfigurationStatementInfoAttribute(StatementName = "elementsToRepeat")]
        public ONEConfigurationBlockStatement ElementsToRepeatStatement { get; set; }



        /// <summary>
        /// Executes this instance.
        /// </summary>
        protected override async Task Execute()
        {

            //ONEEventFlowVariable oneEventFlowVariable = null;
            //this.RootEventBlock.ONEEventFlowVariableDictionary.TryGetValue(this.Id, out oneEventFlowVariable);
            //var repeatControlBlock = oneEventFlowVariable.GetValue() as RepeatControlBlock;

            while (RepeatedTimes <= TimesToRepeat)
            {
                SetActiveEventFlowExecutionBlockState();

                //Check to make sure that this event isn't halted
                if (!this.RootEventBlock.IsEventFlowHalted)
                {
                    //Check to see if the first statement block is available, and if so, execute the flow
                    if (ElementsToRepeatStatement.FirstStatementBlock != null)
                    {
                        await ElementsToRepeatStatement.FirstStatementBlock.ExecuteFlow();
                    }

                    RepeatedTimes += 1;
                }
                else
                {
                    //Exit since this event flow has been halted
                    return;
                }


            }
        }
    }

}
