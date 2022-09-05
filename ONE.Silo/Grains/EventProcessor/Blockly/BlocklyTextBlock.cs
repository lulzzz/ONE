namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "text")]
    public class BlocklyTextBlock : ONEConfigurationOutputBlock<string>
    {
        [BlocklyConfigurationFieldInfo(FieldName = "TEXT")]
        public string Text { get; set; }

        public override string GetOutput()
        {
            //ITextData textData = this.RootEventBlock.EventData as ITextData;
            return this.Text;
        }
    }
}
