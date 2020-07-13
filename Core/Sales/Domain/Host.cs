using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Sales.Domain
{
    public class Host : DomainObjectBase
    {
        public Address Address { get; set; }
        public string OrganizationName { get; set; }
        public string Notes { get; set; }
        public Email Email { get; set; }
        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }
        public PhoneNumber OtherPhoneNumber { get; set; }
        public HostStatus Status { get; set; }
        public HostProspectType Type { get; set; }
        public string TaxIdNumber { get; set; }
        public List<HostImage> Images { get; set; }
        public PhoneNumber FaxNumber { get; set; }
        public Address MailingAddress { get; set; }
        public bool IsHost { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public Host()
        { }

        public Host(long hostId)
            : base(hostId)
        { }
    }
}


