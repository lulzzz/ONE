using ONE.Common.Helpers;
using ONE.GrainInterfaces.EventProcessor;
using ONE.Models.Domain;
using ONE.Models.Enumerations;
using ONE.Models.MessageContracts;
using Orleans;
using System;
using System.IO;

namespace ONE.Silo.Grains.EventProcessor.Blockly
{
    [BlocklyConfigurationBlockInfo(BlockTypeName = "odin_action_play_over_default_audio_output")]
    public class PlayOverDefaultAudioOutputActionBlock : ONEConfigurationBlock
    {
        [BlocklyConfigurationValueInfo(ValueName = "audioInput")]
        public ONEConfigurationOutputBlock<MemoryStream> AudioInput { get; set; }



        protected override void Execute()
        {
            try
            {
                //Transmit over radio
                PlayAudioInputOverDefaultAudioOutput();
            }
            catch (Exception ex)
            {
                //Logger.Instance.LogError("Error trying to play audio input over radio.", ex);
            }
        }

        /// <summary>
        /// Sends the text to speech over radio.
        /// </summary>
        public async void PlayAudioInputOverDefaultAudioOutput()
        {
            try
            {
                //Get an output from the audio input
                using (MemoryStream audioMemoryStream = this.AudioInput.GetOutput())
                {

                    IONESystemOutputDistributorGrain oneSystemOutputDistributorGrain = this.RootEventBlock.GrainFactory.GetGrain<IONESystemOutputDistributorGrain>("413d3d96-3d2f-4b13-b17c-b6ebc898f47a");
                    await oneSystemOutputDistributorGrain.SendDataToSystemIO(audioMemoryStream.ToArray(), "63ee4d82-9fd2-40a5-b7e3-9c8a8c83bc64");
                }
            }
            catch (Exception ex)
            {
                // Logger.Instance.LogError("Error in PlayAudioInputOverDefaultAudioOutput method", ex);
            }
        }
    }
}
