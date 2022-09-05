using ONE.Models.Enumerations;
using System;

namespace ONE.Models.MessageContracts
{
    public interface IEchoStreamMessage
    {
        Guid GlobalTrackingGuid { get; set; }
        DateTime TimeCreatedUtc { get; set; }
        byte Header { get; set; }
        byte Len { get; set; }
        InovonicsMarketId OriginatorMarketId { get; set; }
        int OriginatorUniqueId { get; set; }
        EchoStreamFirstHopDevice FirstHopDevice { get; set; }
        int FirstHopUniqueId { get; set; }
        byte TraceCount { get; set; }
        byte HopCount { get; set; }
        byte MessageClassByte { get; set; }
        byte ProductTypeIdentifier { get; set; }
        byte EN1941XSSid { get; set; }
        byte EN1941XSTid { get; set; }
        EchoStreamApplicationStatusFlags ApplicationStatusFlags { get; set; } //This is also known as STAT1
        EchoStreamPrimaryStatusFlags PrimaryStatusFlags { get; set; } //This is also known as STAT0
        byte SignalLevel { get; set; }
        byte SignalMargin { get; set; }
        byte Checksum { get; set; }
        float InternalTemperature { get; set; }
        float ExternalTemperature { get; set; }
        TransmissionInterval TransmissionInterval { get; set; }
        MeasurementInterval MeasurementInterval { get; set; }
        ExternalSensorUnits ExternalSensorUnits { get; set; }
        TemperatureUnits TemperatureUnits { get; set; }
        DeltaTValue DeltaTValue { get; set; }
    }
}
