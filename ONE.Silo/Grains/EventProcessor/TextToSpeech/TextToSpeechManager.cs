using ONE.Silo.Grains.EventProcessor.Audio;

namespace ONE.Silo.Grains.EventProcessor.TextToSpeech
{
    public class TextToSpeechManager
    {
        /// <summary>
        /// Gets singleton instance of the TextToSpeechManager 
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static TextToSpeechManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private static readonly TextToSpeechManager _instance = new TextToSpeechManager();

        private TextToSpeechAudioStreamGenerator _textToSpeechAudioStreamGenerator = null;



        private TextToSpeechManager()
        {
            InitializeAudioStreamGenerators();
        }

        private void InitializeAudioStreamGenerators()
        {
            _textToSpeechAudioStreamGenerator = new TextToSpeechAudioStreamGenerator();
        }

        public IAudioStreamGenerator GetTextToSpeechAudioStreamGenerator(string textToSpeak, int millisecondsToTrimFromStart, int millisecondsToTrimFromEnd)
        {
            _textToSpeechAudioStreamGenerator.TextToSpeak = textToSpeak;
            _textToSpeechAudioStreamGenerator.MillisecondsToTrimFromStart = millisecondsToTrimFromStart;
            _textToSpeechAudioStreamGenerator.MillisecondsToTrimFromEnd = millisecondsToTrimFromEnd;
            return _textToSpeechAudioStreamGenerator;
        }
    }

}
