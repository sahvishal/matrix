using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class PhysicianLicense : DomainObjectBase
    {
        public string LicenseNumber { get; set; }
        public long PhysicianId { get; set; }
        public long StateId { get; set; }
        public DateTime Expirydate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public PhysicianLicense(){}
        public PhysicianLicense(long id) : base(id) { }
    }
}
