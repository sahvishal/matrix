namespace Falcon.App.Core.Users.Domain
{
    public class CallCenterRep : User
    {
        public long CallCenterRepId { get; set; }

        public CallCenterRep()
        {}

        public CallCenterRep(long userId)
            : base(userId)
        {}

        public bool CanRefund { get; set; }

        public bool CanChangeNotes { get; set; }
    }
}