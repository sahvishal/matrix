
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    //TODO: This should be just a lookup??
    public class HostType : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public HostType()
        { }

        public HostType(long hostTypeId)
            : base(hostTypeId)
        { }
    }
}


