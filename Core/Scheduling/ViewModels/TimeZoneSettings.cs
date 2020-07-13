namespace Falcon.App.Core.Scheduling.ViewModels
{
    public sealed class TimeZoneSettings
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string Name { get; set; }
        public bool IsNegative { get; set; }
        public string Id { get; set; }
        public bool IsDayLightSaving { get; set; }
    }
}
