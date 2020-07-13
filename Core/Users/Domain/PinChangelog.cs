using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Users.Domain
{
    public class PinChangelog : DomainObjectBase
    {
        public long TechnicianId { get; set; }
        public string Pin { get; set; }
        public int Sequence { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
    }
}
