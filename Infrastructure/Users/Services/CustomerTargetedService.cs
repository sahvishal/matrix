using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;

namespace Falcon.App.Infrastructure.Users.Services
{
    [DefaultImplementation]
    public class CustomerTargetedService : ICustomerTargetedService
    {
        private readonly ICustomerTargetedRepository _customerTargetedRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;

        public CustomerTargetedService(ICustomerTargetedRepository customerTargetedRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
            ICustomerProfileHistoryRepository customerProfileHistoryRepository, IEventCustomerRepository eventCustomerRepository, ICustomerEligibilityRepository customerEligibilityRepository)
        {
            _customerTargetedRepository = customerTargetedRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
        }

        public void Save(long customerId, int forYear, bool? isTargeted, long createdBy)
        {
            var customerTargeted = _customerTargetedRepository.GetByCustomerIdAndYear(customerId, forYear);
            bool? oldIsTargated = null;

            if (customerTargeted == null)
            {
                var domain = new CustomerTargeted
                {
                    CustomerId = customerId,
                    ForYear = forYear,
                    IsTargated = isTargeted,
                    CreatedBy = createdBy,
                    DateCreated = DateTime.Now
                };
                _customerTargetedRepository.Save(domain);
            }
            else
            {
                oldIsTargated = customerTargeted.IsTargated;
                if (oldIsTargated != isTargeted)
                {
                    var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customerId, DateTime.Today.Year);
                    var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(customerId, createdBy, customerEligibility);
                    _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(customerId, customerProfileHistoryId);
                }

                customerTargeted.IsTargated = isTargeted;
                customerTargeted.DateModified = DateTime.Now;
                customerTargeted.ModifiedBy = createdBy;

                _customerTargetedRepository.Save(customerTargeted);
            }

            if (DateTime.Today.Year == forYear && (customerTargeted == null || oldIsTargated != isTargeted))
            {
                _callQueueCustomerRepository.UpdateCallQueueCustomerTargeted(customerId, forYear, isTargeted);
            }
        }
    }
}
