using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class HcpcsCode : DomainObjectBase
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public decimal? CopayCost { get; set; }

    }
}
