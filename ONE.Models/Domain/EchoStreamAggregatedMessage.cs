using ONE.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONE.Models.Domain
{
    public class EchoStreamAggregatedMessage : EchoStreamMessage
    {

        public List<EchoStreamMessage> AggregatedMessages = new List<EchoStreamMessage>();
        public EchoStreamAggregatedMessage()
        {

        }

        public EchoStreamAggregatedMessage(byte[] messageData)
        {            /*  
                This payload message is delivered by the RF Gateway to your application controller.

                [0x72] - Header for inbound payload message.

                [LEN] - Message length, excluding checksum.

                [UID (4) originator] - Unique ID of device originating message.

                [UID (4) first hop] - Unique ID of the device which received
                original message, as well as the signal level and margin. If the
                UID begins with 00, then the RF gateway is the first hop; if the
                UID begins with 01, then the repeater is the first hop.

                [Trace count (1)] - Number of trace unique IDs that follow. The
                default is zero, indicating no trace data.

                [Trace UID1 (4)]...[Trace UIDn (4)] - Unique ID of each device that
                repeats this message.

                [Hop count (1)] - The number of times this message was relayed by a
                device.

                [0x02] - Message class byte for an aggregated message.
                [Payload] - Variable size, application dependent.
                [Message count] - The number of individual messages contained
                in the packet. The value is three in this example.

                [Length 1] - Message length for the first message in the packet,
                excluding checksum

                [UID 1 (4)] - Unique ID of device originating the first message
                in the packet.

                [Payload 1] - Payload for the first message in the packet.
                Variable size, 85 bytes maximum.

                [Level 1] - Signal level for the first message in the packet as
                measured by the first hop device.

                [Margin 1] - Signal margin for the first message in the packet
                as measured by the first hop device.

                [Length 2] - Message length for the second message in the
                packet, excluding checksum

                [UID 2 (4)] - Unique ID of device originating the second message
                in the packet.

                [Payload 2] - Payload for the second message in the packet.
                Variable size, 85 bytes maximum.

                [Level 2] - Signal level for the second message in the packet as
                measured by the first hop device, or by the gateway if survey
                information did not exist in the message.

                [Margin 2] - Signal margin for the second message in the packet
                as measured by the first hop device, or by the gateway if survey
                information did not exist in the message.

                [Length 3] - Message length for the third message in the packet,
                excluding checksum

                [UID 3(4)] - Unique ID of device originating the third message
                in the packet.

                [Payload 3] - Payload for the third message in the packet.
                Variable size, 85 bytes maximum.

                [Level 3] - Signal level for the third message in the packet as
                measured by the first hop device, or by the gateway if survey
                information did not exist in the message.

                [Margin 3] - Signal margin for the third message in the packet
                as measured by the first hop device, or by the gateway if survey
                information did not exist in the message.

                [Level] - Signal level of message as measured by the first hop
                device, or by the gateway if survey information did not exist in
                the message.

                [Margin] - Signal margin of message as measured by the first hop
                device, or by the gateway if survey information did not exist in
                the message.

                [CKSUM] - Checksum.
             */

            try
            {

                //Take the raw echostream message data and use it to construct our object
                Header = messageData[0];
                Len = messageData[1];
                OriginatorMarketId = (InovonicsMarketId)messageData[2];
                OriginatorUniqueId = GetUniqueId(messageData, 3);
                FirstHopDevice = (EchoStreamFirstHopDevice)messageData[6];
                FirstHopUniqueId = GetUniqueId(messageData, 7);
                TraceCount = messageData[10];
                HopCount = messageData[11];
                MessageClassByte = messageData[12];

                string hexData = BitConverter.ToString(messageData).Replace("-", "");
                //Logger.Instance.LogDebug(String.Format("EchoStream bytes: {0}", hexData));

                //Construct a list of included EchoStreamMessages
                int messageCount = messageData[13];

                //Operates under the assumption that all payloads in aggregated messages are of message class security data
                //Therefore each payload is 11 bytes long [Length(1)], [UID(4)], [Payload(4)], [Level(1)], [Margin(1)]
                //The first 14 bytes of the message are the header, those are skipped
                foreach (int startBit in Enumerable.Range(0, messageCount).Select(x => x * 11 + 14))
                {

                    //Create proper EchoStreamMessage byte array
                    byte[] echoStreamMessage = new byte[19];

                    //Header and length
                    echoStreamMessage[0] = Header;
                    echoStreamMessage[1] = 18;

                    int messageLength = messageData[startBit];
                    if (messageLength != 11)
                    {
                        throw new Exception($"Unexpected message length in EchoStreamAggregatedMessage constructor: {messageLength} instead of 11");
                    }

                    if ((InovonicsMarketId)messageData[startBit + 1] == InovonicsMarketId.HighPowerRepeaters)
                    {
                        //Skip messages from repeaters
                        continue;
                    }

                    //OriginatorUniqueId
                    echoStreamMessage[2] = messageData[startBit + 1];
                    echoStreamMessage[3] = messageData[startBit + 2];
                    echoStreamMessage[4] = messageData[startBit + 3];
                    echoStreamMessage[5] = messageData[startBit + 4];

                    //FirstHopDevice/UniqueId
                    echoStreamMessage[6] = messageData[2];
                    echoStreamMessage[7] = messageData[3];
                    echoStreamMessage[8] = messageData[4];
                    echoStreamMessage[9] = messageData[5];

                    //TraceCount/HopCount
                    echoStreamMessage[10] = TraceCount;
                    echoStreamMessage[11] = HopCount;

                    //MCB, PTI, Application/Primary status flags
                    echoStreamMessage[12] = messageData[startBit + 5];
                    echoStreamMessage[13] = messageData[startBit + 6];
                    echoStreamMessage[14] = messageData[startBit + 7];
                    echoStreamMessage[15] = messageData[startBit + 8];

                    //Signal level/margin
                    echoStreamMessage[16] = messageData[startBit + 9];
                    echoStreamMessage[17] = messageData[startBit + 10];

                    //Calculate checksum (Modulo 256 is automatic for bytes)
                    byte checksum = 0;
                    for (int i = 0; i < echoStreamMessage.Length; i++)
                    {
                        checksum += echoStreamMessage[i];
                    }
                    echoStreamMessage[18] = checksum;

                    AggregatedMessages.Add(new EchoStreamMessage(echoStreamMessage));
                }

                IsValidMessage = true;
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError("Error in EchoStreamAggregatedMessage Constructor", ex);
            }
        }
    }

}
