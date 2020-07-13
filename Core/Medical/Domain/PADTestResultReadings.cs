namespace Falcon.App.Core.Medical.Domain
{
    public class PadTestReadings
    {
        public ResultReading<int?> SystolicArm { get; set; }
        public ResultReading<int?> SystolicAnkle { get; set; }
        public ResultReading<decimal?> ABI { get; set; }
        public StandardFinding<decimal> Finding { get; set; }
        public ResultReading<bool> UnabletoOcclude { get; set; }
    }
}