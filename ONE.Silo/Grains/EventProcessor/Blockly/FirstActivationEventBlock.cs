using ONE.Silo.Grains.OdinEventProcessorService.Blocks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_event_first_activation")]
    public class FirstActivationEventBlock : ONEConfigurationEventBlock
    {
        protected override void Execute()
        {
            // Logger.Instance.LogDebug($"Executing FirstActivationEventBlock");

        }
    }

}
