using System.Collections.Generic;
using Falcon.App.Core.Users.ViewModels;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface ICustomerEventRegistrationViewDataFactory
    {
        List<CustomerEventRegistrationViewData> Create(CustomerOrderBasicInfoTypedView customerOrderBasicInfoTypedView);
    }
}