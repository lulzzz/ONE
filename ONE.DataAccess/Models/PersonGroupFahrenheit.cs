using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class PersonGroupFahrenheit
    {
        public Guid PersonGroupFahrenheitGuid { get; set; }
        public Guid PersonGroupGuid { get; set; }
        public bool? IsBadgePrinting { get; set; }
        public bool? IsAdditionalEntryDetailRequired { get; set; }
        public string KioskScreenLabel { get; set; }
        public bool? IsSurveyQuestionnaireRequired { get; set; }
        public string ExitScreeningExpiryTime { get; set; }
        public int? FahrenheitIdentificationTypeCode { get; set; }
        public int? ReasonForEntryTypeCode { get; set; }

        public virtual FahrenheitIdentificationType FahrenheitIdentificationTypeCodeNavigation { get; set; }
        public virtual PersonGroup PersonGroupGu { get; set; }
        public virtual ReasonForEntryType ReasonForEntryTypeCodeNavigation { get; set; }
    }
}
