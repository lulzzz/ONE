using ONE.GrainInterfaces.EventProcessor;
using ONE.Models.Enumerations;
using ONE.Silo.Grains.OdinEventProcessorService.Blocks;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_event_first_activation_clear")]
    public class FirstActivationClearEventBlock : ONEConfigurationEventBlock
    {
        protected override async Task Execute()
        {
            var grainId = $"{this.RootEventBlock.ONEEventMessage.InitiatorGUID}/{this.RootEventBlock.ONEEventMessage.EventFlowGUID}/{(int)EventType.FirstActivation}";

            IEventProcessor eventProcessorGrain = GrainFactory.GetGrain<IEventProcessor>(grainId);
            await eventProcessorGrain.UnregisterGrainReminder($"{grainId}/reminder");
        }
    }
}
