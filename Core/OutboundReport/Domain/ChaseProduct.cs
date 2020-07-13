using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class ChaseProduct : DomainObjectBase
    {
        public string Name { get; set; }
        public long ProductLevel { get; set; }

        public ChaseProduct(long chaseProductId)
            : base(chaseProductId)
        {

        }

        public ChaseProduct()
        {

        }
    }
}
