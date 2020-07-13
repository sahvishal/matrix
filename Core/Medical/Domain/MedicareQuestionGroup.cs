using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicareQuestionGroup : DomainObjectBase
    {
        public string GroupName { get; set; }
        public string GroupAlias { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
    }

}
