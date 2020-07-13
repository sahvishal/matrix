using System.Collections.Generic;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICustomerEventRegistrationViewDataRepository
    {
        List<CustomerEventRegistrationViewData> GetCustomerEventRegistrationViewData(long customerId);
    }
}