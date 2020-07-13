using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Users.Services
{
    [DefaultImplementation]
    public class CustomerEligibilityService : ICustomerEligibilityService
    {

        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public CustomerEligibilityService(ICustomerEligibilityRepository customerEligibilityRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
                                          ICustomerProfileHistoryRepository customerProfileHistoryRepository, IEventCustomerRepository eventCustomerRepository, ILogManager logManager)
        {
            _customerEligibilityRepository = customerEligibilityRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _eventCustomerRepository = eventCustomerRepository;
        }

        public void Save(long customerId, int forYear, bool? isEligible, long createdBy, ILogger logger, bool isUpload = false)
        {
            var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customerId, forYear);
            bool? oldIsEligible = null;

            if (customerEligibility == null)
            {
                var domain = new CustomerEligibility
                {
                    CustomerId = customerId,
                    ForYear = forYear,
                    IsEligible = isEligible,
                    CreatedBy = createdBy,
                    DateCreated = DateTime.Now
                };
                _customerEligibilityRepository.Save(domain);
                logger.Info("Inserted new data for Customer Eligibility, CustomerId :" + customerId + ", Year: " + forYear);
            }
            else
            {
                oldIsEligible = customerEligibility.IsEligible;
                if (oldIsEligible != isEligible)
                {
                    logger.Info("Customer Eligibility,  Creating History , CustomerId :" + customerId + ", Year: " + forYear);
                    var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(customerId, createdBy, customerEligibility);
                    _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(customerId, customerProfileHistoryId);
                    logger.Info("History Created , CustomerId :" + customerId + ", Year: " + forYear);
                }

                customerEligibility.IsEligible = isEligible;
                customerEligibility.DateModified = DateTime.Now;
                customerEligibility.ModifiedBy = createdBy;

                _customerEligibilityRepository.Save(customerEligibility);
                logger.Info("Updated Customer Eligibility, CustomerId :" + customerId + ", Year: " + forYear);
            }

            if (DateTime.Today.Year == forYear && (customerEligibility == null || oldIsEligible != isEligible))         //if eligibility is changed only then we'll update CallQueueCustomer
            {
                var cqcUpdated = _callQueueCustomerRepository.UpdateCallQueueCustomerEligibility(customerId, isEligible);
                if (cqcUpdated)
                    logger.Info("CallQueueCustomers Updated for CustomerId: " + customerId + " with Eligibility: " + isEligible);
                else
                    logger.Info("No CallQueueCustomer found for CustomerId: " + customerId + " with Eligibility: " + isEligible);
            }
            else
            {
                logger.Info("CallQueueCustomer not updated as Parsed data has 1)No previous eligibility or 2) Has same eligibility 3) or parsed year doesn't match with current year. CustomerId: " + customerId);
            }
        }
    }
}
