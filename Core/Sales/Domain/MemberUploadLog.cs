using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class MemberUploadLog : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long CorporateUploadId { get; set; }
        public bool IsCustomerZipInvalid { get; set; }
        public bool IsPCPZipInvalid { get; set; }
        public bool IsPCPMailingZipInvalid { get; set; }

        public string NewInsertedZipIds { get; set; }
        public string NewInsertedCityIds { get; set; }
    
    }
}