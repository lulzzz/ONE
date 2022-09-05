using System;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public class BlocklyConfigurationFieldInfoAttribute : Attribute
    {
        public string FieldName { get; set; }
    }
}
