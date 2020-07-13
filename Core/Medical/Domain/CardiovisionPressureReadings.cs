namespace Falcon.App.Core.Medical.Domain
{
    public class CardiovisionPressureReadings
    {
        public ResultReading<int?> SystolicRightArm { get; set; }
        public ResultReading<int?> DiastolicRightArm { get; set; }
        public ResultReading<int?> SystolicLeftArm { get; set; }
        public ResultReading<int?> DiastolicLeftArm { get; set; }
        public ResultReading<int?> PulsePressure { get; set; }
        public ResultReading<int?> Pulse { get; set; }
    }
}
