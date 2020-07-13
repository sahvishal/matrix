using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class PhysicianLabTest : DomainObjectBase
    {
        public long PhysicianId { get; set; }
        public long StateId { get; set; }
        public string IfobtLicenseNo { get; set; }
        public string MicroalbumineLicenseNo { get; set; } 
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
    }
}