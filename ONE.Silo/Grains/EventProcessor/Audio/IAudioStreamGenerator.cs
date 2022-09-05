using System.IO;

namespace ONE.Silo.Grains.EventProcessor.Audio
{
    public interface IAudioStreamGenerator
    {
        MemoryStream GenerateAudioStream();
    }
}
