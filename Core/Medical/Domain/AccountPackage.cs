namespace Falcon.App.Core.Medical.Domain
{
    public class AccountPackage
    {
        public long AccountId { get; set; }
        public long PackageId { get; set; }
        public bool IsRecommended { get; set; }
    }
}
