using System;

namespace ONE.Models.Domain
{
    public class EventFlowInfo
    {
        public string Id { get; set; }
        public Guid EventFlowGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventFlowXML { get; set; }
        public bool IsActive { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CustomerLocationGuid { get; set; }
    }
}
