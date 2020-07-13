using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Interfaces
{
    public interface IHostFactory
    {
        Host CreateHost(ProspectsEntity hostsEntity, Address address, Address mailingAddress);
        List<Host> CreateHosts(List<ProspectsEntity> hostsEntities, List<Address> addresses, List<Address> mailingAddresses);
        ProspectsEntity CreateHostEntity(Host host);
    }
}
