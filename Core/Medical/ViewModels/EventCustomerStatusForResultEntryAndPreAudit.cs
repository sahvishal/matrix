namespace Falcon.App.Core.Medical.ViewModels
{
    public class EventCustomerStatusForResultEntryAndPreAudit
    {
        public bool IsNewResultFlow { get; set; }
        public bool IsResultEntry { get; set; }
        public bool IsMarkedNoShowAndLeftWithoutScreening { get; set; }
        public bool IsChartSignedOff { get; set; }
    }
}
