using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MedicareGroupDependencyRule : DomainObjectBase
    {
        public long QuestionId { get; set; }
        public long DependentGroupId { get; set; }
        public string DependencyValue { get; set; }
    }
}