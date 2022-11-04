using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using System;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{

    [BlocklyConfigurationBlockInfo(BlockTypeName = "one_controls_for_loop")]
    public class ForLoopControlBlock : ONEConfigurationStatementBlock
    {
        [BlocklyConfigurationFieldInfo(FieldName = "counterVariableName")]
        public string CounterVariableName { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "counterInitialValue")]
        public string CounterInitialValue { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "counterMaxValue")]
        public string CounterMaxValue { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "incrementValue")]
        public string IncrementValue { get; set; }


        [BlocklyConfigurationStatementInfoAttribute(StatementName = "elementsToRepeat")]
        public ONEConfigurationBlockStatement ElementsToRepeatStatement { get; set; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        protected override async Task Execute()
        {
            try
            {
                string counterVariableName = CounterVariableName;
                int counter = Convert.ToInt32(CounterInitialValue);
                int counterMaxValue = Convert.ToInt32(CounterMaxValue);
                int incrementer = Convert.ToInt32(IncrementValue);


                ONEEventFlowVariable<string> oneEventFlowVariable = new ONEEventFlowVariable<string>();
                oneEventFlowVariable.Value = string.Empty;
                this.RootEventBlock.ONEEventFlowVariableDictionary.TryAdd(counterVariableName, oneEventFlowVariable);

                for (int i = counter; i <= counterMaxValue; i = i + incrementer)
                {
                    if (!this.RootEventBlock.IsEventFlowHalted)
                    {
                        await SetActiveEventFlowExecutionBlockState();

                        //Get the dictionary item from OdinEventFlowVariableDictionary
                        ONEEventFlowVariable variableToUpdate = null;
                        this.RootEventBlock.ONEEventFlowVariableDictionary.TryGetValue(counterVariableName, out variableToUpdate);

                        //Update oneEventFlowVariable dictionary variable item
                        oneEventFlowVariable.Value = i.ToString();
                        this.RootEventBlock.ONEEventFlowVariableDictionary.TryUpdate(counterVariableName, oneEventFlowVariable, variableToUpdate);

                        //Check to see if the first statement block is available, and if so, execute the flow
                        if (ElementsToRepeatStatement.FirstStatementBlock != null)
                        {
                            await ElementsToRepeatStatement.FirstStatementBlock.ExecuteFlow();
                        }
                    }
                    else
                    {
                        //Exit since this event flow has been halted
                        break;
                    }
                }

                ONEEventFlowVariable variableToRemove = null;
                this.RootEventBlock.ONEEventFlowVariableDictionary.TryRemove(counterVariableName, out variableToRemove);
            }
            catch (Exception ex)
            {
            }

        }
    }
}
