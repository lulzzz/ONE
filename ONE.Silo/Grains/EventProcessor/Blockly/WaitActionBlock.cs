using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "one_action_wait")]
    public class WaitActionBlock : ONEConfigurationBlock
    {
        [BlocklyConfigurationFieldInfo(FieldName = "secondsToWait")]
        public int SecondsToWait { get; set; }

        protected override async Task Execute()
        {

            // await SetActiveEventFlowExecutionBlockState();

            //Try to sleep every amount of time
            //Check to make sure that this event flow is still active
            if (!this.RootEventBlock.IsEventFlowHalted)
            {
                // System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(SecondsToWait));
                await Task.Delay(System.TimeSpan.FromSeconds(SecondsToWait));
            }

        }
    }
}