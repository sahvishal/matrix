using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class Carrier : DomainObjectBase
    {
        public string Name { get; set; }    

        public Carrier()
        {}

        public Carrier(long carrierId)
            :base(carrierId)
        {}
    }
}
