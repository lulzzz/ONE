using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class ThermistorProbeTypeRtcurveDataItem
    {
        public int ThermistorProbeTypeCode { get; set; }
        public int? TemperatureCelsius { get; set; }
        public int? ResistanceOhms { get; set; }

        public virtual ThermistorProbeType ThermistorProbeTypeCodeNavigation { get; set; }
    }
}
