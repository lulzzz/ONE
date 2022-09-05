using System;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    public class BlocklyConfigurationStatementInfoAttribute : Attribute
    {
        public string StatementName { get; set; }
    }
}
