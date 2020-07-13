using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class PasswordChangelog : DomainObjectBase
    {
        public long UserLoginId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Sequence { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
    }
}
