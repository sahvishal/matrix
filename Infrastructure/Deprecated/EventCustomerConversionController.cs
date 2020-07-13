using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;

namespace Falcon.App.Infrastructure.Deprecated
{
    public class EventCustomerConversionController
    {
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        private readonly IClickConversionRepository _clickConversionRepository = new ClickConversionRepository();

        public void SaveEventCustomerConversion(long customerId, long prospectCustomerId)
        {
            if (prospectCustomerId <= 0) return;
            {
                long eventCustomerId = _customerRepository.GetCustomerEventCustomerUserId(customerId);
                _clickConversionRepository.SaveEventCustomerConversion(prospectCustomerId, eventCustomerId);
            }
        }

    }
}