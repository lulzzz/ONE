using ONE.EdgeCompute.TransportLayer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "one_action_play_over_default_audio_output")]
    public class PlayOverDefaultAudioOutputActionBlock : ONEConfigurationBlock
    {
        [BlocklyConfigurationValueInfo(ValueName = "audioInput")]
        public ONEConfigurationOutputBlock<MemoryStream> AudioInput { get; set; }
        MqttTransportHelper _mqttTransportHelper;


        protected override async Task Execute()
        {
            try
            {

                //Transmit over radio
                await PlayAudioInputOverDefaultAudioOutput();
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError("Error trying to play audio input over radio.", ex);
            }
        }

        /// <summary>
        /// Sends the text to speech over radio.
        /// </summary>
        public async Task PlayAudioInputOverDefaultAudioOutput()
        {
            try
            {
                await SetActiveEventFlowExecutionBlockState();

                //Get an output from the audio input
                using (MemoryStream audioMemoryStream = await this.AudioInput.GetOutput())
                {
                    _mqttTransportHelper = new MqttTransportHelper();
                    _mqttTransportHelper.OpenMqttTransportConnection(Guid.NewGuid().ToString());
                    await _mqttTransportHelper.Publish(audioMemoryStream.ToArray(), "a19a61ab-8535-46b8-a2c5-0c2ddc71c398");
                }
            }
            catch (Exception ex)
            {
                // Logger.Instance.LogError("Error in PlayAudioInputOverDefaultAudioOutput method", ex);
            }
        }
    }
}
