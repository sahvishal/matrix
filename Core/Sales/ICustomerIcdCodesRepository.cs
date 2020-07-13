using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ICustomerIcdCodesRepository
    {
        CustomerIcdCode GetCustomerIcdByCustomerIdCodeName(long customerId, string codeName);
        CustomerIcdCode Save(CustomerIcdCode customerIcdCode);
        void Save(IEnumerable<CustomerIcdCode> customerIcdCodes, long customerId);
        IEnumerable<CustomerIcdCode> GetIcdByCustomerId(long customerId);
    }
}