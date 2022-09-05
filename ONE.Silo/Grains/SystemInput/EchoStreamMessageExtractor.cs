using ONE.Models.Domain;
using ONE.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONE.Silo.Grains.SystemInput
{
    public class EchoStreamMessageExtractor
    {
        private const string _applicationSource = "EchoStreamMessageExtractor";
        private List<byte> _receivedData = new List<byte>();
        private List<byte> _dataWindow = new List<byte>();

        private const byte ECHOSTREAM_MESSAGE_HEADER = 0x72;  //This is the start of every echostream message
        private const int MINIMUM_ECHOSTREAM_MESSAGE_LENGTH = 18; //This is the length of the message minus the checksum

        public List<EchoStreamMessage> GetEchoStreamMessagesFromData(byte[] dataReadBuffer)
        {


            List<EchoStreamMessage> capturedEchoStreamMessages = new List<EchoStreamMessage>();

            //append the read data to the data window
            _dataWindow.AddRange(dataReadBuffer);

            //Get the data window count
            int dataWindowCount = _dataWindow.Count();

            try
            {
                //Do a check on the data window to see if the data window is over one thousand bytes
                if (dataWindowCount >= 1000)
                {
                    //Write this to the log
                }

                //Create a flag that keeps whether or not the whole data window has been processed
                bool stillProcessingDataWindow = true;


                //Keep processing until the data window is empty or there may be more complete messages
                while (stillProcessingDataWindow)
                {
                    //Write this to the log
                    //Logger.Instance.LogDebug(String.Format("Still processing.  Data Window Count: {0}", dataWindowCount));

                    //Premptively clean the datawindow before we do any checks.
                    //TODO:  May want to revisit this as it may be unnecessary
                    CleanDataWindow();

                    //Determine what to do
                    //Either we have no more bytes in the data window, or the first byte is a header
                    if (_dataWindow.Count > 0)
                    {
                        //The first byte much be a header, determine if we have a complete message, and if not, determine if we at least have a partial message
                        //Otherwise we must have a junk message, so so remove the "fake header" from the first message element and keep processing

                        //Try to extract the message from the data window.  If there is a complete message at the start of the data window
                        //Those bytes are removed from the data window and turned into an echo stream message
                        EchoStreamMessage capturedEchoStreamMessage = TryExtractEchoStreamMessageFromDataWindow();
                        if (capturedEchoStreamMessage == null)
                        {
                            //We didn't get a message, but check to see if there is still data for processing
                            //Sometimes this can happen if we get a partial message, or a bad checksum interleaved
                            if (_dataWindow.Count > 0)
                            {
                                //Double check to see if we have a complete message in the data window, if so, continue processing
                                if (IsPossibleCompleteValidMessageInDataWindow())
                                {
                                    stillProcessingDataWindow = true;
                                }
                                else
                                {
                                    //Could not capture a full message, determine if there is a possible partial message
                                    if (IsPossiblePartialValidMessageInDataWindow())
                                    {
                                        //We didn't capture a message but there may be a partial message in the window, so lets stop processing so we can get more data in the window
                                        stillProcessingDataWindow = false;
                                    }
                                    else
                                    {
                                        //Not a possible partial message, so clean the data window to clear off any garbage data
                                        CleanDataWindow(true);

                                        //Check to see if any data is left, and if so, continue processing as we may have another partial message on there.
                                        if (_dataWindow.Count > 0)
                                        {

                                            stillProcessingDataWindow = true;
                                        }
                                        else
                                        {

                                            stillProcessingDataWindow = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //No data left for processing, so exit out
                                stillProcessingDataWindow = false;
                            }
                        }
                        else
                        {
                            //Add the captured echostream message to the list of echostream messages
                            //If aggregated message, add list contents
                            if (capturedEchoStreamMessage is EchoStreamAggregatedMessage)
                            {
                                EchoStreamAggregatedMessage capturedEchoStreamMessageAggregated = (EchoStreamAggregatedMessage)capturedEchoStreamMessage;
                                capturedEchoStreamMessages.AddRange(capturedEchoStreamMessageAggregated.AggregatedMessages);
                            }
                            else
                            {
                                capturedEchoStreamMessages.Add(capturedEchoStreamMessage);
                            }

                            //Now check to see if there are more messages
                            //Check to see if there is more
                            if (IsPossibleCompleteValidMessageInDataWindow())
                            {
                                stillProcessingDataWindow = true;
                            }
                            else if (IsPossiblePartialValidMessageInDataWindow())
                            {
                                stillProcessingDataWindow = false;
                            }
                            else
                            {
                                //Not a possible partial message, but there is data in the window, so clean the data window and determine if we can stop processing
                                if (_dataWindow.Count > 0)
                                {
                                    CleanDataWindow();

                                    //Check once more to make see if anything is left after the window cleaning
                                    if (_dataWindow.Count > 0)
                                    {
                                        //There is still something left, so make sure its not valid data
                                        stillProcessingDataWindow = true;
                                    }
                                    else
                                    {
                                        //There is nothing left, so stop processing for now
                                        stillProcessingDataWindow = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //Data window is empty, so jump out
                        stillProcessingDataWindow = false;
                    }
                }

            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError("Error in GetEchoStreamMessagesFromData Method", ex);
                CleanDataWindow(true);
            }

            return capturedEchoStreamMessages;
        }


        /// <summary>
        /// Tries to capture an EchoStream message from the data window.
        /// </summary>
        /// <returns></returns>
        private EchoStreamMessage TryExtractEchoStreamMessageFromDataWindow()
        {
            /*  
                The EchoStream Protocol is defined as the following

                [HEAD] – Header for inbound complete message.
              
                [LEN] – Message length, excluding checksum.
              
                [UID (4) ORIGINATOR] – Unique ID of device originating message.
             
                    UID includes MID (1 byte) plus UID (3 bytes) of end device.
                    Market ID Applications:
                        0xB2 – Security End Devices
                        0xC0 – Environmental End Devices
                        0xA0 – Submetering Products
                        0x01 – High-Power Repeaters
                        0x00 – Network Coordinator
              
                [UID (4) FIRST HOP] – Unique ID of the device which received
                    original message, as well as the signal level and margin. If the
                    UID begins with 00, then the RF gateway is the first hop; if the
                    UID begins with 01, then the repeater is the first hop.
             
                [TRACE COUNT (1)] - Number of trace unique IDs that follow. The
                    default is zero, indicating no trace data.
             
                [HOP COUNT (1)] – The number of times this message was relayed by a device.
             
                [MCB] - Message class byte for security data.
             
                [PTI] - Product Type Identifier.
             
                [STAT1] - Application Status Flags.
             
                    Bit 7 – EOL tamper.
                    Bit 6 – EN1242 Clean Me message; reserved for all others.
                    Bit 5 – EN1221S Clear by Magnet; reserved for all others.
                    Bit 4 – EN1221S Clear by Button; reserved for all others.
                    Bit 3 – EN1224 Fourth alarm; reserved for all others.
                    Bit 2 – EN1224 Third alarm; reserved for all others.
                    Bit 1 – EN1224 or EN1941 Secondary alarm; reserved for all others.
                    Bit 0 - Primary alarm.
             
                [STAT0] - Primary Status Flags.
                    Bit 7 – Low battery (internal secondary).
                    Bit 6 - Low battery (primary).
                    Bit 5 - Tamper.
                    Bit 4 - Set when there has been no change in status since the
                    last transmission.
                    Bit 3 – Reset (alarm clear).
                    Bit 2 – EN1221S Primary battery missing; reserved for all others.
                    Bit 1 – EN1221S sequence bit 1; reserved for all others.
                    Bit 0 – EN1221S sequence bit 0; reserved for all others.
             
                [LEVEL] – Signal level of message as measured by the first hop device,
                    or by the gateway if survey information did not exist in the message.
             
                [MARGIN] – Signal margin of message as measured by the first hop device,
                    or by the gateway if survey information did not exist in the message.
             
                [CKSUM] – Checksum
             
             */


            EchoStreamMessage echoStreamMessage = null;

            //Check make sure that there is at least enough bytes to check the message length and the market id
            //That the first byte is a header byte
            //That the second byte is at least big enough to contain 
            if (IsPossibleCompleteValidMessageInDataWindow())
            {
                //So far so good, now lets extract the possible message and calculate its checksum

                //extract the bytes minus the checksum for the candidate message
                byte[] candidateMessageMinusChecksum = _dataWindow.GetRange(0, _dataWindow[1]).ToArray();

                //Get the checksum which is at the same position in the data window as the value of the message length
                byte candidateMessageChecksum = _dataWindow[_dataWindow[1]];

                //Get the sum of the message
                byte candidateMessageSum = (byte)candidateMessageMinusChecksum.Sum(x => x);

                //Determine if the sum of the message is equal to the checksum 
                if (candidateMessageSum == candidateMessageChecksum)
                {
                    //Looks like we have a winner
                    //Get the full message data with the checksum
                    byte[] messageWithChecksum = _dataWindow.GetRange(0, _dataWindow[1] + 1).ToArray();
                    byte messageClassByte = messageWithChecksum[12];


                    echoStreamMessage = new EchoStreamMessage(messageWithChecksum);


                    //Remove the message bytes from the data window
                    //Remove the message length plus one checksum byte starting at the zero position of the data window
                    _dataWindow.RemoveRange(0, _dataWindow[1] + 1);

                    if (!echoStreamMessage.IsValidMessage)
                    {
                        //Logger.Instance.LogDebug(String.Format("Not a valid message. {0}", BitConverter.ToString(messageWithChecksum)));
                        return null;
                    }
                }
                else
                {
                    //Logger.Instance.LogDebug("Candidate message sum and candidate message checksum did not match.");

                    //The checksum is not equal, so clean the data window invalid starting bytes with 
                    //a force so we can be sure any matching headers get dropped and don't cause data to "get stuck" in the window
                    CleanDataWindow(true);
                }
            }

            return echoStreamMessage;
        }

        /// <summary>
        /// Cleans the data window by removing all bytes starting at the zero index until all bytes are gone or until the first byte is a header byte, and also allows you to specify
        /// if you want to force delete the first byte.  
        /// </summary>
        private void CleanDataWindow(bool forceRemoveFirstByteInWindow)
        {
            //Sometimes you can have a valid header byte (_dataWindow[0]) in the data window, 
            //but one of the subsequent bytes like the length byte (_dataWindow[1]) is invalid,
            //In this case we have to throw this out until we find a good message
            if (forceRemoveFirstByteInWindow && _dataWindow.Count > 0)
            {
                _dataWindow.RemoveAt(0);
            }

            //Remove values in the data window until we get to another header or until there are no more messages left, whichever comes first
            while (_dataWindow.Count > 0 && _dataWindow[0] != ECHOSTREAM_MESSAGE_HEADER)
            {
                _dataWindow.RemoveAt(0);
            }
        }


        /// <summary>
        /// Cleans the data window by removing all bytes starting at the zero index until all bytes are gone or until the first byte is a header byte. 
        /// </summary>
        private void CleanDataWindow()
        {
            //Call the clean data window without a force
            CleanDataWindow(false);
        }

        /// <summary>
        /// Determines whether [is possible complete valid message in data window].
        /// </summary>
        /// <returns></returns>
        private bool IsPossibleCompleteValidMessageInDataWindow()
        {
            if (_dataWindow.Count > 3
                && _dataWindow[0] == ECHOSTREAM_MESSAGE_HEADER //This is the EchoStream message header - 0x72
                && _dataWindow[1] >= MINIMUM_ECHOSTREAM_MESSAGE_LENGTH //This makes sure the data window is at least the length of a binary echostream message
                && (_dataWindow[2] == (byte)EchoStreamMarketIdApplications.SecurityEndDevices  //These make sure this is a valid echostream market id
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.EnvironmentalEndDevices
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.SubmeteringProducts
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.HighPowerRepeaters
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.NetworkCoordinator
                    )

                && _dataWindow.Count >= _dataWindow[1] + 1 //This makes sure that the data window is same number of bytes the the message length (_dataWindow[1]) says it is, plus one byte for the checksum
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is possible partial valid message in data window].
        /// </summary>
        /// <returns></returns>
        private bool IsPossiblePartialValidMessageInDataWindow()
        {
            if (_dataWindow.Count == 0) //If there are no bytes then not possible to be a partial valid message
            {
                return false;
            }
            else if (_dataWindow.Count == 1 //If the only byte in the window is a header byte, then could be starting a new message 
                && _dataWindow[0] == ECHOSTREAM_MESSAGE_HEADER) //This is the EchoStream message header - 0x72
            {
                return true;
            }
            else if (_dataWindow.Count == 2 // if the count is 2 and the first byte is a header and the second byte looks long enough to be the minimum size for an EN message, the could be starting a new message
                && _dataWindow[0] == ECHOSTREAM_MESSAGE_HEADER //This is the EchoStream message header - 0x72
                && _dataWindow[1] >= MINIMUM_ECHOSTREAM_MESSAGE_LENGTH) //This makes sure the data window is at least the length of a binary echostream message
            {
                return true;
            }
            else if (_dataWindow.Count >= 3 //If the message is 3 or more bytes, then check all of its criteria
                && _dataWindow[0] == ECHOSTREAM_MESSAGE_HEADER //This is the EchoStream message header - 0x72
                && _dataWindow[1] >= MINIMUM_ECHOSTREAM_MESSAGE_LENGTH //This makes sure the data window is at least the length of a binary echostream message
                && (_dataWindow[2] == (byte)EchoStreamMarketIdApplications.SecurityEndDevices  //These make sure this is a valid echostream market id
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.EnvironmentalEndDevices
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.SubmeteringProducts
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.HighPowerRepeaters
                        || _dataWindow[2] == (byte)EchoStreamMarketIdApplications.NetworkCoordinator
                    )
                )
            {
                return true;
            }

            return false;
        }
    }
}
