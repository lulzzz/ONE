using ONE.Models.Enumerations;
using ONE.Models.MessageContracts;
using System;

namespace ONE.Models.Domain
{
    [Serializable]
    public class ONEEventOutputMessage : IONEEventOutputMessage
    {
        public Guid DeviceId { get; set; }
        public OutputActionType OutputMessageType { get; set; }
        public byte[] Payload { get; set; }
    }
}
