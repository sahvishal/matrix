namespace Falcon.App.Core.Users.Domain
{
    public class SalesRepresentative : User
    {
        public long SalesRepresentativeId { get; set; }
        public long FranchiseeId { get; set; }

        public SalesRepresentative()
        {}

        public SalesRepresentative(long userId)
            : base(userId)
        {}
    }
}