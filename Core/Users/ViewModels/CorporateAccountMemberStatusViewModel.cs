namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountMemberStatusViewModel
    {
        public long EligibleCustomersCount { get; set; }
        public long MembersTestedCount { get; set; }
        public long MembersScheduledCount { get; set; }
        public long MembersCancelledCount { get; set; }
        public long MembersNoShowedCount { get; set; }
    }
}
