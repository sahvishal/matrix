using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CustomerPhoneNumberUpdateUploadLog : DomainObjectBase
    {
        public long UploadId { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string MemberId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}