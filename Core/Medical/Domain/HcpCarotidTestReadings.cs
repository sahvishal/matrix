namespace Falcon.App.Core.Medical.Domain
{
    public class HcpCarotidTestReadings
    {
        public ResultReading<decimal?> ICAPSV { get; set; }
        public ResultReading<decimal?> ICAEDV { get; set; }
        public ResultReading<decimal?> CCAPSV { get; set; }
        public StandardFinding<decimal> Finding { get; set; }
    }
}