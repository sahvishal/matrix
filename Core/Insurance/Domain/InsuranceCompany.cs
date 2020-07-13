using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Insurance.Domain
{
    public class InsuranceCompany : DomainObjectBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string EdiPayerNumber { get; set; }
        public string Address { get; set; }
        public bool InNetwork { get; set; }
        public bool IsActive { get; set; }
    }
}
