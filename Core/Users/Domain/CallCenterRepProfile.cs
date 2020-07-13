namespace Falcon.App.Core.Users.Domain
{
    public class CallCenterRepProfile : User
    {
        public long CallCenterRepId { get; set; }

        public bool CanRefund { get; set; }

        public bool CanChangeNotes { get; set; }

        public string DialerUrl { get; set; }

        public CallCenterRepProfile()
        { }

        public CallCenterRepProfile(long userId)
            :base(userId)
        { }
    }
}
