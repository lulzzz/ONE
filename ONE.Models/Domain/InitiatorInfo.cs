using System;

namespace ONE.Models.Domain
{
    public class InitiatorInfo
    {
        public Guid InitiatorGuid { get; set; }
        public int ApplicationTypeCode { get; set; }
        public string ApplicationType { get; set; }
        public int InitiatorTypeCode { get; set; }
        public string InitiatorTypeName { get; set; }
        public string InitiatorTypeEnumName { get; set; }
        public string SerialNumber { get; set; }
        public Guid EventFlowGuid { get; set; }
        public int? CheckInWindowMinutes { get; set; }
        public string EventFlow { get; set; }
        public Guid CustomerLocationSectionGuid { get; set; }
        public string Status { get; set; }
        public Guid CustomerLocationGuid { get; set; }
        public string CustomerLocationSectionName { get; set; }
        public string CustomerLocationSectionReportAs { get; set; }
        public int ProtocolTypeCode { get; set; }
        public string ProtocolTypeEnumName { get; set; }
        public string EventInterpreterTypeEnumName { get; set; }
        public string InitiatorConfigurationDataXML { get; set; }
        public bool IsDoubleLocked { get; set; }
        public Object ConfigurationData { get; set; }
    }
}
