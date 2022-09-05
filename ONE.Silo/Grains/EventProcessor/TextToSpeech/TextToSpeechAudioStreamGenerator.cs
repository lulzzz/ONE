using ONE.Common.Helpers;
using ONE.Silo.Grains.EventProcessor.Audio;
using System;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;

namespace ONE.Silo.Grains.EventProcessor.TextToSpeech
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Odin.Compute.WinServices.OdinEventProcessorService.Audio.IAudioStreamGenerator" />
    public class TextToSpeechAudioStreamGenerator : IAudioStreamGenerator
    {
        SpeechSynthesizer _speechSynthesizer { get; set; }

        /// <summary>
        /// Gets or sets the text to speak.
        /// </summary>
        /// <value>
        /// The text to speak.
        /// </value>
        public string TextToSpeak { get; set; }

        /// <summary>
        /// Gets or sets the milliseconds to trim from start after the text to speech is generated
        /// </summary>
        /// <value>
        /// The milliseconds to trim from start.
        /// </value>
        public int MillisecondsToTrimFromStart
        {
            get
            {
                return _millisecondsToTrimFromStart;
            }
            set
            {
                _millisecondsToTrimFromStart = value;
            }
        }
        private int _millisecondsToTrimFromStart = 100;

        /// <summary>
        /// Gets or sets the milliseconds to trim from end after the text to speech is generated
        /// </summary>
        /// <value>
        /// The milliseconds to trim from end.
        /// </value>
        public int MillisecondsToTrimFromEnd
        {
            get
            {
                return _millisecondsToTrimFromEnd;
            }
            set
            {
                _millisecondsToTrimFromEnd = value;
            }
        }
        private int _millisecondsToTrimFromEnd = 760;

        public TextToSpeechAudioStreamGenerator()
        {
            _speechSynthesizer = new SpeechSynthesizer();
            //Get the speech rate from the system configuration if it exists, otherwise default to 0
            int speechSynthesizerRate = 0;


            //Try to parse it otherwise set it to zero
            if (!Int32.TryParse("0", out speechSynthesizerRate))
            {
                speechSynthesizerRate = 0;
            }
            // Logger.Instance.LogDebug($"TextToSpeechAudioStreamGenerator: SpeechSynthesizerRate: {speechSynthesizerRate}");



            //Set the speech synthesizer rate
            _speechSynthesizer.Rate = speechSynthesizerRate;

            //Get all of the installed voices
            var installedVoices = _speechSynthesizer.GetInstalledVoices();
            //Logger.Instance.LogDebug($"Installed Voices");
            //Throw an exception if the installed voices don't exist
            if (installedVoices == null || installedVoices.Count == 0)
            {
                throw new Exception("There are no installed voices for text to speech generation.");
            }

            //Set the default voice to the first installed voice name
            string textToSpeechVoiceName = installedVoices[0].VoiceInfo.Name;

            // Logger.Instance.LogDebug($"textToSpeechVoiceName: {textToSpeechVoiceName}");

            //Make sure this voice exists in the installed voices
            if (installedVoices.Count(x => x.VoiceInfo.Name == "Microsoft Zira Desktop") > 0)
            {
                //It does, so use it
                // Logger.Instance.LogDebug($"textToSpeechVoiceNameSystemCongfigurationType: {textToSpeechVoiceNameSystemCongfigurationType.Value}");
                textToSpeechVoiceName = "Microsoft Zira Desktop";
            }

            try
            {
                //Logger.Instance.LogDebug($"TextToSpeechAudioStreamGenerator: TextToSpeechVoiceName: {textToSpeechVoiceName}");

                //Select the voice
                // Logger.Instance.LogDebug($"Start synthesizer SelectVoice: {textToSpeechVoiceNameSystemCongfigurationType.Value}");
                _speechSynthesizer.SelectVoice(textToSpeechVoiceName);
                //Logger.Instance.LogDebug($"Finish synthesizer SelectVoice:");
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError($"Error occurred when trying to select text-to-speech voice: {textToSpeechVoiceName}.  Error: {ex.ToString()}");
                throw;
            }
        }

        public MemoryStream GenerateAudioStream()
        {
            MemoryStream trimmedStream = new MemoryStream();
            try
            {
                // Logger.Instance.LogDebug($"TextToSpeechAudioStreamGenerator: Generate Audio Stream for Text");

                //Instantiate a new output stream
                MemoryStream outputStream = new MemoryStream();

                //Create a WAV stream with the TTS
                //Logger.Instance.LogDebug($"Start synthesizer.SetOutputToWaveStream");
                _speechSynthesizer.SetOutputToWaveStream(outputStream);
                //Logger.Instance.LogDebug($"Finish synthesizer.SetOutputToWaveStream:");

                //Play the message into the wav file
                _speechSynthesizer.Speak(TextToSpeak);
                //Logger.Instance.LogDebug($"synthesizer.Speak:");

                //Reset the stream position to zero
                outputStream.Position = 0;

                //Trim the generated audio file using the audio file helper
                AudioFileHelper audioFileHelper = new AudioFileHelper();
                trimmedStream = audioFileHelper.Trim(outputStream, this.MillisecondsToTrimFromStart, this.MillisecondsToTrimFromEnd);

                //Reset the stream position to zero
                trimmedStream.Position = 0;
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError($"[TextToSpeechAudioStreamGenerator] - Error occurred on GenerateAudioStream method.  Error: {ex.ToString()}");
            }
            //Return the stream
            return trimmedStream;
        }
    }
}
