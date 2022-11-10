using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class XmldataTemplate
    {
        public Guid XmldataTemplateGuid { get; set; }
        public string XmldataTemplateName { get; set; }
        public string Description { get; set; }
        public string Xmldata { get; set; }
        public string AuxillaryXmldata { get; set; }
    }
}
