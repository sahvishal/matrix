namespace Falcon.App.Core.Medical.Domain
{
    public class FloChecABIReadings
    {
        public ResultReading<decimal?> BFI { get; set; }
        public ResultReading<decimal?> ABI { get; set; }
        public StandardFinding<decimal> Finding { get; set; }
    }
}