using NAudio.Utils;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

namespace ONE.Common.Helpers
{
    public class AudioFileHelper
    {

        /// <summary>
        /// Concatenate audio streams using N audio
        /// </summary>
        /// <param name="audioStreams">The audio streams.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Can't concatenate WAV Files that don't share the same format</exception>
        public MemoryStream ConcatenateAudioStreams(List<MemoryStream> audioStreams)
        {
            //Logger.Instance.LogDebug($"AudioFileHelper: Concatenate audio streams using N audio.");

            //Create a buffer for the audio streams
            byte[] buffer = new byte[1024];

            //Create an NAudio wave file writer
            WaveFileWriter waveFileWriter = null;

            //Create an outputstream;
            MemoryStream outputStream = new MemoryStream();

            try
            {
                //Iterate the audio stream concatenate them together
                foreach (MemoryStream audioStream in audioStreams)
                {
                    //Reset the stream to zero position
                    audioStream.Position = 0;

                    //Read the stream
                    using (WaveFileReader reader = new WaveFileReader(audioStream))
                    {
                        //Check if the wave file writer is null, create it if it is
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(new IgnoreDisposeStream(outputStream), reader.WaveFormat);
                        }
                        else
                        {
                            //Not null, check to make sure the the WAV files are compatible
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                            {
                                throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                            }
                        }

                        //Read and write the buffer
                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            waveFileWriter.Write(buffer, 0, read);
                        }
                    }
                }
            }
            finally
            {
                //Make sure the wave fill writer is null and disposed
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

            //Reset the output stream to zero.
            outputStream.Position = 0;

            //Return the stream
            return outputStream;
        }

        public MemoryStream Trim(MemoryStream wavAudioStream, int millisecondsToTrimFromStart, int millisecondsToTrimFromEnd)
        {
            //Logger.Instance.LogDebug($"AudioFileHelper: Trimming the generated audio.");

            //Create a buffer for the audio streams
            byte[] buffer = new byte[1024];

            //Create an NAudio wave file writer
            WaveFileWriter waveFileWriter = null;

            //Create an outputstream;
            MemoryStream outputStream = new MemoryStream();

            try
            {
                //Reset the stream to zero position
                wavAudioStream.Position = 0;

                //Read the stream
                using (WaveFileReader reader = new WaveFileReader(wavAudioStream))
                {
                    //Check if the wave file writer is null, create it if it is
                    if (waveFileWriter == null)
                    {
                        // first time in create new Writer
                        waveFileWriter = new WaveFileWriter(new IgnoreDisposeStream(outputStream), reader.WaveFormat);
                    }
                    else
                    {
                        //Not null, check to make sure the the WAV files are compatible
                        if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                        {
                            throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                        }
                    }

                    //Determine the bytes per millisend
                    int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                    //Determine the starting position
                    int wavFileDataStartIndex = millisecondsToTrimFromStart * bytesPerMillisecond;
                    wavFileDataStartIndex = wavFileDataStartIndex - wavFileDataStartIndex % reader.WaveFormat.BlockAlign;

                    //Determine the ending position based upon the number of bytes to remove from the end
                    int bytesToTrimFromEnd = millisecondsToTrimFromEnd * bytesPerMillisecond;
                    bytesToTrimFromEnd = bytesToTrimFromEnd - bytesToTrimFromEnd % reader.WaveFormat.BlockAlign;
                    int wavFileDataEndIndex = (int)reader.Length - bytesToTrimFromEnd;


                    //Check to make sure we are not overtrimming. We cant trim 2 seconds of audio from the begining and 2 seconds of audio from the end, if we only have two second audio stream
                    if (wavFileDataStartIndex > 0 && wavFileDataStartIndex < (int)reader.Length && wavFileDataEndIndex <= (int)reader.Length && wavFileDataEndIndex > wavFileDataStartIndex)
                    {
                        //Read and write the buffer
                        int read = 0;
                        int wavFileDataIndex = 0;

                        //Create the wav file data array - this will contain the entire wav file that is generated.  I did this because we're looking at most about 200k per second of audio, and this was easier
                        //than the algorithm required to track a direct buffered write to the wave file writer
                        byte[] wavFileData = new byte[reader.Length];

                        //Read all of the data into the wav file data array
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            Array.Copy(buffer, 0, wavFileData, wavFileDataIndex, read);
                            wavFileDataIndex += read;
                        }

                        //Write the data to the wave file writer
                        waveFileWriter.Write(wavFileData, wavFileDataStartIndex, wavFileDataEndIndex);

                    }
                    else
                    {
                        //Logger.Instance.LogWarning("Trying to overtrim audio stream in method Trim of audiohelper");
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogDebug($"AudioFileHelper: Error in Trim method. Exception:{ex}");
            }
            finally
            {
                //Make sure the wave fill writer is null and disposed
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

            //Reset the output stream to zero.
            outputStream.Position = 0;

            //Return the stream
            return outputStream;
        }
    }

}
