using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class DatabaseVersionScript
    {
        public Guid ScriptGuid { get; set; }
        public string ScriptPath { get; set; }
    }
}
