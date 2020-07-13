using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Geo
{
    public interface IAddressFactory
    {
        List<Address> CreateAddresses(AddressViewTypedView addressViewTypedView);
        Address CreateAddress(AddressViewRow addressViewRow);
        AddressEntity CreateAddressEntity(Address address);

        Address CreateAddressDomain(AddressEntity addressEntity);
    }
}