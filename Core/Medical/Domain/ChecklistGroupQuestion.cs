using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class ChecklistGroupQuestion : DomainObjectBase
    {
        public long GroupId { get; set; }
        public long QuestionId { get; set; }
        public long? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}
