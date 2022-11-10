using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class EventFlowLogDetail
    {
        public Guid EventFlowLogDetailGuid { get; set; }
        public Guid EventFlowLogGuid { get; set; }
        public string EventFlowLogDetailXml { get; set; }

        public virtual EventFlowLog EventFlowLogGu { get; set; }
    }
}
