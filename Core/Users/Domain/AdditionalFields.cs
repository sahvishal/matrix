using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Users.Domain
{
    public class AdditionalFields : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedBy { get; set; }
    }
}
