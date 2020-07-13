using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class ScreeningAuthorization : DomainObjectBase
    {
        public string Initials { get; set; }
        public DateTime DateCreated { get; set; }
        public string Signature { get; set; }
        public long PhysicianId { get; set; }
    }
}
