using System;

namespace ONE.Models.Enumerations
{
    public enum InovonicsMarketId
    {
        SecurityEndDevices = 0xB2,
        EnvironmentalEndDevices = 0xC0,
        SubmeteringProducts = 0xA0,
        HighPowerRepeaters = 0x01,
        NetworkCoordinators = 0x00
    }

    public enum EchoStreamFirstHopDevice
    {
        RFGateway = 0x00,
        Repeater = 0x01
    }


    [Flags]
    public enum EchoStreamApplicationStatusFlags
    {
        Unset = 0x00,                   //Decimal: 0
        PrimaryAlarm = 0x01,            //Decimal: 1
        SecondAlarm = 0x02,             //Decimal: 2
        ThirdAlarm = 0x04,              //Decimal: 4
        FourthAlarm = 0x08,             //Decimal: 8
        ClearByButton = 0x10,           //Decimal: 16 
        ClearByMagnet = 0x20,           //Decimal: 32
        CleanMeMessage = 0x40,          //Decimal: 64
        EndOfLineTamper = 0x80          //Decimal: 128
    }

    [Flags]
    public enum EchoStreamPrimaryStatusFlags
    {
        Unset = 0x00,                   //Decimal: 0
        SequenceBit0 = 0x01,            //Decimal: 1
        SequenceBit1 = 0x02,            //Decimal: 2
        PrimaryBatteryMissing = 0x04,   //Decimal: 4
        Reset = 0x08,                   //Decimal: 8
        NoChange = 0x10,                //Decimal: 16 - Supervisory
        Tamper = 0x20,                  //Decimal: 32
        LowBatteryPrimary = 0x40,       //Decimal: 64
        LowBatteryInternal = 0x80      //Decimal: 128
    }

    public enum TransmissionInterval
    {
        TenSecond = 0,
        ThirtySecond = 1,
        OneMinute = 2,
        TwoMinutes = 3,
        FiveMinutes = 4,
        TenMinutes = 5,
        FifteenMinutes = 6,
        ThirtyMinutes = 7,
    }


    public enum MeasurementInterval
    {
        OnlyOnTransmission = 0,
        HalfSecond = 1,
        OneSecond = 2,
        FiveSeconds = 3,
        ThirtySeconds = 4,
        OneMinutes = 5,
        TenMinutes = 6,
        FifteenMinutes = 7,
    }

    public enum ExternalSensorUnits
    {
        Resistance = 0,
        Temperature = 1,
    }
    public enum TemperatureUnits
    {
        Celsius = 0,
        Fahrenheit = 1,
    }

    public enum DeltaTValue
    {
        FeatureDisabled = 0,
        Half = 1,
        One = 2,
        Five = 3,
        Ten = 4
    }

    public enum EchoStreamMarketIdApplications
    {
        SecurityEndDevices = 0xB2,
        EnvironmentalEndDevices = 0xC0,
        SubmeteringProducts = 0xA0,
        HighPowerRepeaters = 0x01,
        NetworkCoordinator = 0x00
    }


    public enum OutputActionType
    {
        PlayOverDefaultAudioOutput,
        PlayOverRadioOutput,
        AddEventToDashboardOutput
    }

}
