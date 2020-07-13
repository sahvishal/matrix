
using System;
namespace Falcon.App.Core.Domain.MedicalVendors
{
    public class EventCustomerPrimaryCarePhysician 
    {
        public long EventCustomerId { get; set; }
        public long PrimaryCarePhysicianId { get; set; }
        public bool? IsPcpAddressVerified { get; set; }
        public long? PcpAddressVerifiedBy { get; set; }
        public DateTime? PcpAddressVerifiedOn { get; set; }
    }
}
