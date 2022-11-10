using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using System;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_action_set_variable")]
    public class SetVariableActionBlock : ONEConfigurationBlock
    {
        [BlocklyConfigurationFieldInfo(FieldName = "variableName")]
        public string VariableName { get; set; }

        [BlocklyConfigurationValueInfo(ValueName = "variableInput")]
        public ONEConfigurationOutputBlock<string> VariableInput { get; set; }

        protected override async Task Execute()
        {
            try
            {
                //Get the output of value input
                string valueOfVariable = await VariableInput.GetOutput();
                ONEEventFlowVariable<string> odinEventFlowVariable = new ONEEventFlowVariable<string>();
                odinEventFlowVariable.Value = valueOfVariable;
                this.RootEventBlock.ONEEventFlowVariableDictionary.TryAdd(VariableName, odinEventFlowVariable);

                await SetActiveEventFlowExecutionBlockState();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
