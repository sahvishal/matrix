using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class Barrier : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
