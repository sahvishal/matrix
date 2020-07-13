namespace Falcon.App.Core.Medical.Domain
{
    public class AwvCarotidTestReadings
    {
        public ResultReading<decimal?> CCAProximalPSV { get; set; }
        public ResultReading<decimal?> CCAProximalEDV { get; set; }

        public ResultReading<decimal?> CCADistalPSV { get; set; }
        public ResultReading<decimal?> CCADistalEDV { get; set; }

        public ResultReading<decimal?> BulbPSV { get; set; }
        public ResultReading<decimal?> BulbEDV { get; set; }

        public ResultReading<decimal?> ExtCarotidArtPSV { get; set; }

        public ResultReading<decimal?> ICAProximalPSV { get; set; }
        public ResultReading<decimal?> ICAProximalEDV { get; set; }

        public ResultReading<decimal?> ICADistalPSV { get; set; }
        public ResultReading<decimal?> ICADistalEDV { get; set; }

        public ResultReading<decimal?> VertebralArtPSV { get; set; }
        public ResultReading<decimal?> VertebralArtEDV { get; set; }

        public StandardFinding<decimal> Finding { get; set; }
    }
}
