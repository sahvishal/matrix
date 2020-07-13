namespace Falcon.App.Core.Medical.Domain
{
    public class PRTAxis
    {
        public ResultReading<int?> QRSFront { get; set; }
        public ResultReading<int?> PFront { get; set; }
        public ResultReading<int?> TFront { get; set; }
    }
}