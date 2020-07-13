namespace Falcon.App.Core.Scheduling.ViewModels
{ 
    public class OnlineSelectedEventEditModel
    {
        public long EventId { get; set; }
        public string Guid { get; set; }
        public string ZipCode { get; set; }
        public string InvitationCode { get; set; }
        public string CorpCode { get; set; }
        public int? Radius { get; set; }
        public string CouponCode { get; set; }
        public string RequestUrl { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
    }
}
