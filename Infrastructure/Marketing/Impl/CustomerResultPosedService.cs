using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Infrastructure.Marketing.Impl
{
    [DefaultImplementation]
    public class CustomerResultPosedService : ICustomerResultPosedService
    {
        private readonly ICustomerResultPostedRepository _customerResultPostedRepository;

        public CustomerResultPosedService(ICustomerResultPostedRepository customerResultPostedRepository)
        {
            _customerResultPostedRepository = customerResultPostedRepository;
        }

        public CustomerResultPosted GetCusterResultPosted(long customerId)
        {
            var resultPosted = _customerResultPostedRepository.GetByCustomerId(customerId);
            if (resultPosted == null)
                resultPosted = _customerResultPostedRepository.Save(new CustomerResultPosted { CustomerId = customerId });

            return resultPosted;
        }
    }
}
