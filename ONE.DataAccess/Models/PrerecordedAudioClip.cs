using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PrerecordedAudioClip
    {
        public Guid PrerecordedAudioClipGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// This text token can be used in text to speech operations to replace a phrase with precorded audio.  E.G.  &quot;Please leave a message at the sound of the [BEEP]&quot;.  &quot;[BEEP]&quot; would be the text token representing the beep WAV file.  The text string would remove this text token and concatenate the beep wav file to the end of the text to speech.
        /// </summary>
        public string TextToSpeechReplacementToken { get; set; }
        public bool IsAudioLibraryItem { get; set; }
        public Guid? CreatedBySystemUserGuid { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual SystemUser CreatedBySystemUserGu { get; set; }
    }
}
