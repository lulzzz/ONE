using System;

namespace ONE.Models.MessageContracts
{

    public interface IONEEventOutputMessage
    {
        public Guid DeviceId { get; set; }
        public byte[] Payload { get; set; }
    }
}
