namespace Falcon.App.Core.Medical.Domain
{
    public class HospitalPartnerPackage
    {
        public long HospitalPartnerId { get; set; }
        public long PackageId { get; set; }
        public bool IsRecommended { get; set; }
    }
}