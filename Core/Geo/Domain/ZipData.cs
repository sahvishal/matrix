namespace Falcon.App.Core.Geo.Domain
{
    public class ZipData
    {
        public long Id { get; set; }
        public string ZipCode { get; set; }
        public string StateCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
        public string DayLightSaving { get; set; }
        public string City { get; set; }
    }
}
