using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Domain
{
    public class GuardianDetails : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public Relationship Relationship { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PhoneCell { get; set; }
        public PhoneNumber PhoneOffice { get; set; }
        public PhoneNumber PhoneHome { get; set; }
        public Email Email { get; set; }
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public bool IsActive { get; set; }
    }
}
