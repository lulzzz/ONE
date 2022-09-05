
using ONE.Common.Helpers;
using ONE.Silo.Grains.EventProcessor.Audio;
using ONE.Silo.Grains.EventProcessor.TextToSpeech;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_function_text_to_speech")]
    public class TextToSpeechFunctionBlock : ONEConfigurationOutputBlock<MemoryStream>
    {
        [BlocklyConfigurationValueInfo(ValueName = "textToSpeak")]
        public ONEConfigurationOutputBlock<string> TextToSpeak { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "millisecondsToTrimFromStart")]
        public int MillisecondsToTrimFromStart { get; set; }

        [BlocklyConfigurationFieldInfo(FieldName = "millisecondsToTrimFromEnd")]
        public int MillisecondsToTrimFromEnd { get; set; }

        public override MemoryStream GetOutput()
        {
            try
            {
                //Logger.Instance.LogDebug($"Executing TextToSpeechFunctionBlock");

                //Create the output stream
                MemoryStream outputStream = new MemoryStream();

                //Get the output text
                string textToSpeakOutput = TextToSpeak.GetOutput();

                //Get a regex match collection of all of the prerecorded audio tokens that are in the text to speech string
                MatchCollection prerecordedAudioTokenMatches = Regex.Matches(textToSpeakOutput, @"(\[PAC:.*?\])");

                //Set text position index to 0, this keeps track of where we are in string while we are parsing out the tokens and the straight text-to-speech parts
                int textPositionIndex = 0;

                //Create a list of audio stream generators
                List<IAudioStreamGenerator> audioStreamGenerators = new List<IAudioStreamGenerator>();

                if (prerecordedAudioTokenMatches.Count > 0)
                {
                    for (int matchIndex = 0; matchIndex < prerecordedAudioTokenMatches.Count; matchIndex++)
                    {
                        Match prerecordedAudioTokenMatch = prerecordedAudioTokenMatches[matchIndex];

                        //The start of the string is a token
                        if (prerecordedAudioTokenMatch.Index == 0)
                        {
                            //audioStreamGenerators.Add(TextToSpeechManager.Instance.GetPrerecordedAudioClipAudioStreamGenerator(prerecordedAudioTokenMatch.Value, Guid.Empty));
                            //Add the audio clip
                            //audioStreamGenerators.Add(new PrerecordedAudioClipAudioStreamGenerator { TextToSpeechReplacementToken = prerecordedAudioTokenMatch.Value });

                            //Move the text position to the end of the match result
                            textPositionIndex = prerecordedAudioTokenMatch.Length;
                        }
                        else
                        {
                            //The match is somewhere in the middle of the string
                            //Get the preamble text first
                            string textToSpeak = textToSpeakOutput.Substring(textPositionIndex, prerecordedAudioTokenMatch.Index - textPositionIndex);

                            audioStreamGenerators.Add(TextToSpeechManager.Instance.GetTextToSpeechAudioStreamGenerator(textToSpeak, MillisecondsToTrimFromStart, MillisecondsToTrimFromEnd));

                            //audioStreamGenerators.Add(new TextToSpeechAudioStreamGenerator { TextToSpeak = textToSpeak, MillisecondsToTrimFromStart = MillisecondsToTrimFromStart, MillisecondsToTrimFromEnd = MillisecondsToTrimFromEnd });

                            //Move the text position
                            textPositionIndex = prerecordedAudioTokenMatch.Index + prerecordedAudioTokenMatch.Length;

                            // audioStreamGenerators.Add(TextToSpeechManager.Instance.GetPrerecordedAudioClipAudioStreamGenerator(prerecordedAudioTokenMatch.Value, Guid.Empty));

                            //Add the audio clip
                            //audioStreamGenerators.Add(new PrerecordedAudioClipAudioStreamGenerator { TextToSpeechReplacementToken = prerecordedAudioTokenMatch.Value });
                        }

                        //Check to see if this is the last match
                        if (matchIndex + 1 == prerecordedAudioTokenMatches.Count)
                        {
                            //Determine if there is any more of the string that is just text for text to speech, and if so, add it
                            if (textToSpeakOutput.Length > textPositionIndex)
                            {
                                audioStreamGenerators.Add(TextToSpeechManager.Instance.GetTextToSpeechAudioStreamGenerator(textToSpeakOutput.Substring(textPositionIndex, textToSpeakOutput.Length - textPositionIndex), MillisecondsToTrimFromStart, MillisecondsToTrimFromEnd));


                                //audioStreamGenerators.Add(new TextToSpeechAudioStreamGenerator { TextToSpeak = textToSpeakOutput.Substring(textPositionIndex, textToSpeakOutput.Length - textPositionIndex), MillisecondsToTrimFromStart = MillisecondsToTrimFromStart, MillisecondsToTrimFromEnd = MillisecondsToTrimFromEnd });
                            }
                        }
                    }
                }
                else
                {
                    audioStreamGenerators.Add(TextToSpeechManager.Instance.GetTextToSpeechAudioStreamGenerator(textToSpeakOutput, MillisecondsToTrimFromStart = MillisecondsToTrimFromStart, MillisecondsToTrimFromEnd = MillisecondsToTrimFromEnd));

                    //There were no tokens so just add a text to speech audio stream generator 
                    //audioStreamGenerators.Add(new TextToSpeechAudioStreamGenerator { TextToSpeak = textToSpeakOutput, MillisecondsToTrimFromStart = MillisecondsToTrimFromStart, MillisecondsToTrimFromEnd = MillisecondsToTrimFromEnd });
                }

                //Create a list of memory streams and add the two audio inputs
                List<MemoryStream> audioStreams = new List<MemoryStream>();

                //Iterate all of the stream and concatenate them as the output stream
                foreach (IAudioStreamGenerator generator in audioStreamGenerators)
                {
                    //Get a stream from the generator
                    MemoryStream generatorStream = generator.GenerateAudioStream();

                    //Check to make sure the generator stream is not null
                    if (generatorStream != null)
                    {
                        audioStreams.Add(generatorStream);
                    }
                }

                //Check to make sure that we have at least one 
                if (audioStreams.Count > 0)
                {
                    //Make sure there is more than one audio stream before we use the concatentation 
                    if (audioStreams.Count > 1)
                    {
                        //More than one audio stream, use the concatenator
                        //Get an audio file helper
                        AudioFileHelper audioFileHelper = new AudioFileHelper();

                        //Concatenate the streams
                        outputStream = audioFileHelper.ConcatenateAudioStreams(audioStreams);
                    }
                    else
                    {
                        //There is only one audio stream, so just make it the outputs stream
                        outputStream = audioStreams.First();
                    }

                    //Reset the stream position
                    outputStream.Position = 0;
                }

                //Return the output stream
                return outputStream;
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError("Error in GetOutput method of TextToSpeechFunctionBlock", ex);
            }
            return null;
        }
    }
}
