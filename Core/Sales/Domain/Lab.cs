using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class Lab : DomainObjectBase
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public DateTime DateCreated { get; set; }

        public long CreatedByOrgRoleUserId { get; set; }

        public bool IsActive { get; set; }
    }
}
