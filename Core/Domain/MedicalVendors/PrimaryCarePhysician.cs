using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;
using System;

namespace Falcon.App.Core.Domain.MedicalVendors
{
    public class PrimaryCarePhysician : DomainObjectBase
    {
        public PrimaryCarePhysician(long primaryCarePhysicianId)
            : base(primaryCarePhysicianId)
        { }

        public Name Name { get; set; }
        public long CustomerId { get; set; }
        public Address Address { get; set; }
        public Address MailingAddress { get; set; }
        public PhoneNumber Primary { get; set; }
        public PhoneNumber Secondary { get; set; }

        public Email Email { get; set; }
        public Email SecondaryEmail { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public string Website { get; set; }
        public string Npi { get; set; }
        public PhoneNumber Fax { get; set; }

        public string PrefixText { get; set; }
        public string SuffixText { get; set; }
        public string CredentialText { get; set; }
        public long? PhysicianMasterId { get; set; }
        public bool IsActive { get; set; }
        public bool? IsPcpAddressVerified { get; set; }
        public long? PcpAddressVerifiedBy { get; set; }
        public DateTime? PcpAddressVerifiedOn { get; set; }
        public long? Source { get; set; }

        public PrimaryCarePhysician()
        { }
    }
}