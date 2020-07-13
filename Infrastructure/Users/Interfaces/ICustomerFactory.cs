using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface ICustomerFactory
    {
        CustomerProfileEntity CreateCustomerEntity(Customer customer, long organizationRoleUserId);
        Customer CreateCustomer(Customer customer, Address billingAddress, CustomerProfileEntity customersEntity);
    }
}
