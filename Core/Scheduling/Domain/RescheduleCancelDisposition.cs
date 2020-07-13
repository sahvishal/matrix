using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class RescheduleCancelDisposition : DomainObjectBase
    {
        public long LookupId { get; set; }
        public string Alias { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int RelativeOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public long DataRecorderCreatorID { get; set; }
        public bool IsActive { get; set; }
    }
}
