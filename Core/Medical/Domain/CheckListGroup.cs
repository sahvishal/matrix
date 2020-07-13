using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class CheckListGroup : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CheckListGroupType Type { get; set; }
        public string Alias { get; set; }
        public long? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}