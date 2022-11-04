using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "text")]
    public class BlocklyTextBlock : ONEConfigurationOutputBlock<string>
    {
        [BlocklyConfigurationFieldInfo(FieldName = "TEXT")]
        public string Text { get; set; }

        public override Task<string> GetOutput()
        {
            //ITextData textData = this.RootEventBlock.EventData as ITextData;
            return Task.FromResult(this.Text);
        }
    }
}
