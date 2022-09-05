using System;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public class BlocklyConfigurationValueInfoAttribute : Attribute
    {
        public string ValueName { get; set; }
        public Type ValueType { get; set; }

    }
}
