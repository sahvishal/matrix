using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class IcdCode : DomainObjectBase
    {
        public string CodeName { get; set; }
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public bool IsActive { get; set; }
    }
}
