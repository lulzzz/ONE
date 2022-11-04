using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "one_event_first_activation")]
    public class FirstActivationEventBlock : ONEConfigurationEventBlock
    {
        protected override async Task Execute()
        {
            // Logger.Instance.LogDebug($"Executing FirstActivationEventBlock");
            await Task.CompletedTask;

        }
    }

}
