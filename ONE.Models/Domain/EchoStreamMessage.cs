using ONE.Common.Utility;
using ONE.Models.Enumerations;
using ONE.Models.MessageContracts;
using System;
using System.Linq;

namespace ONE.Models.Domain
{
    public class EchoStreamMessage : IEchoStreamMessage
    {
        public Guid GlobalTrackingGuid { get; set; }
        public DateTime TimeCreatedUtc { get; set; }
        public byte Header { get; set; }
        public byte Len { get; set; }
        public InovonicsMarketId OriginatorMarketId { get; set; }
        public int OriginatorUniqueId { get; set; }
        public EchoStreamFirstHopDevice FirstHopDevice { get; set; }
        public int FirstHopUniqueId { get; set; }
        public byte TraceCount { get; set; }
        public byte HopCount { get; set; }
        public byte MessageClassByte { get; set; }
        public byte ProductTypeIdentifier { get; set; }
        public byte EN1941XSSid { get; set; }
        public byte EN1941XSTid { get; set; }
        public EchoStreamApplicationStatusFlags ApplicationStatusFlags { get; set; } //This is also known as STAT1
        public EchoStreamPrimaryStatusFlags PrimaryStatusFlags { get; set; } //This is also known as STAT0
        public byte SignalLevel { get; set; }
        public byte SignalMargin { get; set; }
        public byte Checksum { get; set; }
        public bool IsValidMessage { get; set; }
        public float InternalTemperature { get; set; }
        public float ExternalTemperature { get; set; }
        public TransmissionInterval TransmissionInterval { get; set; }
        public MeasurementInterval MeasurementInterval { get; set; }
        public ExternalSensorUnits ExternalSensorUnits { get; set; }
        public TemperatureUnits TemperatureUnits { get; set; }
        public DeltaTValue DeltaTValue { get; set; }


        public int PredictedNearestOriginatorUniqueId { get; set; }

        public EchoStreamMessage()
        {
        }

        public EchoStreamMessage(byte[] messageData)
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
            //It is a binary ("Short") message
            ProductTypeIdentifier = messageData[13];
            ApplicationStatusFlags = (EchoStreamApplicationStatusFlags)messageData[14];
            PrimaryStatusFlags = (EchoStreamPrimaryStatusFlags)messageData[15];
            SignalLevel = messageData[16];
            SignalMargin = messageData[17];
            Checksum = messageData[18];
            IsValidMessage = true;
            TimeCreatedUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the uid from the message data.
        /// Inovonics UIDs are 3 bytes long, but are stored in big endian byte order in the data
        /// Do a check to ensure we are on a little endian machine, and if so, reverse the byte order of the inovonics data
        /// and get the Unique Id
        /// </summary>
        /// <param name="messageData">The message data.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns></returns>
        public int GetUniqueId(byte[] messageData, int startIndex)
        {

            //Create an array to copy in the uid data from the message data array
            byte[] uidData = new byte[4];

            //The start position of the destination array is 1 because we're copying 3 bytes into a 4 byte integer
            Array.Copy(messageData, startIndex, uidData, 1, 3);

            //Determine if this is a little endian machine and reverse the uid data array if so
            if (BitConverter.IsLittleEndian)
            {
                //reverse the order of the uid data array
                uidData = uidData.Reverse().ToArray();
            }

            //Get the unique id
            int uniqueId = BitConverter.ToInt32(uidData, 0);

            //return the result
            return uniqueId;
        }

        public byte[] GetMessageBytes()
        {
            //Determine if this is a long message, or a short message
            byte[] messageBytes = new byte[this.Len + 1];

            messageBytes[0] = this.Header;
            messageBytes[1] = this.Len;
            messageBytes[2] = (byte)this.OriginatorMarketId;

            byte[] originatorUniqueIdBytes = BitConverter.GetBytes(this.OriginatorUniqueId);
            messageBytes[3] = originatorUniqueIdBytes[2];
            messageBytes[4] = originatorUniqueIdBytes[1];
            messageBytes[5] = originatorUniqueIdBytes[0];

            messageBytes[6] = (byte)this.FirstHopDevice;

            byte[] firstHopUniqueIdBytes = BitConverter.GetBytes(this.FirstHopUniqueId);
            messageBytes[7] = firstHopUniqueIdBytes[2];
            messageBytes[8] = firstHopUniqueIdBytes[1];
            messageBytes[9] = firstHopUniqueIdBytes[0];
            messageBytes[10] = this.TraceCount;
            messageBytes[11] = this.HopCount;
            messageBytes[12] = this.MessageClassByte;

            //Determine if this is a serial ("long") message, or if this is a binary ("short") message
            if (MessageClassByte == 0x18)
            {
                //It is a serial ("long") message
                messageBytes[13] = EN1941XSSid;
                messageBytes[14] = EN1941XSTid;
                messageBytes[15] = (byte)this.ApplicationStatusFlags;
                messageBytes[16] = (byte)this.PrimaryStatusFlags;
                messageBytes[17] = SignalLevel;
                messageBytes[18] = SignalMargin;
                messageBytes[19] = (byte)messageBytes.Sum(0, messageBytes.Length - 1);
            }
            else
            {
                //It is a binary ("Short") message
                messageBytes[13] = ProductTypeIdentifier;
                messageBytes[14] = (byte)this.ApplicationStatusFlags;
                messageBytes[15] = (byte)this.PrimaryStatusFlags;
                messageBytes[16] = SignalLevel;
                messageBytes[17] = SignalMargin;
                messageBytes[18] = (byte)messageBytes.Sum(0, messageBytes.Length - 1);
            }

            return messageBytes;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            //Make sure it's a frequency agile message object
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            //Get the object as EchoStreamMessage
            EchoStreamMessage messageToCompare = obj as EchoStreamMessage;

            //Get get the message bytes for this instance and for the message to compare instance
            byte[] theseMessageBytes = this.GetMessageBytes();
            byte[] messageToCompareMessageBytes = messageToCompare.GetMessageBytes();

            //determine if they are the same length
            if (theseMessageBytes.Length == messageToCompareMessageBytes.Length)
            {
                //Make sure that everything but the last 3 bytes matchup.  We don't worry about the last 3 because the signal level, signal margin, and checksum may be different
                //Messages really only should differ in serial number, status flags / payload
                for (int i = 0; i < theseMessageBytes.Length - 3; i++)
                {
                    //Skip 6 - 11 because we don't care about the first hop UUID, the trace count, and hop count for the purposes of equality
                    if (i < 6 || i > 11)
                    {
                        //Check the bytes at current index
                        if (theseMessageBytes[i] != messageToCompareMessageBytes[i])
                        {
                            //The current indexed elements don't match, so the whole thing doesn't match. 
                            //Let's get the hell out of here.
                            return false;
                        }
                    }
                }
            }
            else
            {
                //They are not the same length so they can't be equal
                return false;
            }

            //Return true if we've made it this far
            return true;
        }

        /// <summary>
        /// Calculates the checksum.
        /// </summary>
        public void CalculateChecksum()
        {
            byte[] messageBytes = this.GetMessageBytes();

            this.Checksum = (byte)messageBytes.Take(messageBytes.Length - 1).Sum(x => x);
        }
    }

}
