using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.ACL.Domain;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class Role : DomainObjectBase
    {        
        public long OrganizationTypeId { get; set; }
        public string DisplayName { get; set; }
        public string Alias { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Description { get; set; }
        public string DefaultPage { get; set; }
        public string ShellType { get; set; }

        public Role Parent { get; set; }
        public long? ParentId { get; set; }

        public IEnumerable<RoleScopeOption> RoleScopeOptions { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystemRole { get; set; }
        public bool IsTwoFactorAuthrequired { get; set; }
        public bool IsPinRequired { get; set; }
        public IEnumerable<RoleScopeOption> GetRoleScopeOptions()
        {
            if (RoleScopeOptions == null || !RoleScopeOptions.Any())
            {
                if (Parent != null) return Parent.RoleScopeOptions;
            }

            return RoleScopeOptions;
        }

        public Role()
        {}

        public Role(long organizationId)
            : base(organizationId)
        {}
    }
}