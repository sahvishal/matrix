using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;

namespace Falcon.App.Infrastructure.Users.Services
{
    [DefaultImplementation]
    public class CustomerWarmTransferService : ICustomerWarmTransferService
    {
        private readonly ICustomerWarmTransferRepository _customerWarmTransferRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;

        public CustomerWarmTransferService(ICustomerWarmTransferRepository customerWarmTransferRepository, ICustomerProfileHistoryRepository customerProfileHistoryRepository,
            IEventCustomerRepository eventCustomerRepository, ICustomerEligibilityRepository customerEligibilityRepository)
        {
            _customerWarmTransferRepository = customerWarmTransferRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
        }

        public void Save(long customerId, int forYear, bool? isWarmTransfer, long createdBy, Core.Interfaces.ILogger logger, bool isUpload = false)
        {
            var customerWarmTransfer = _customerWarmTransferRepository.GetByCustomerIdAndYear(customerId, forYear);
            if (customerWarmTransfer == null)
            {
                var domain = new CustomerWarmTransfer
                {
                    CustomerId = customerId,
                    WarmTransferYear = forYear,
                    IsWarmTransfer = isWarmTransfer,
                    CreatedBy = createdBy,
                    DateCreated = DateTime.Now
                };
                _customerWarmTransferRepository.Save(domain);
                logger.Info("Inserted new data for Customer WarmTransfer, CustomerId :" + customerId + ", Year: " + forYear);
            }
            else
            {
                bool? oldIsWarmTransfer = null;
                oldIsWarmTransfer = customerWarmTransfer.IsWarmTransfer;
                if (oldIsWarmTransfer != isWarmTransfer)
                {
                    var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customerId, forYear);
                    logger.Info("Customer WarmTransfer,  Creating History , CustomerId :" + customerId + ", Year: " + forYear);
                    var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(customerId, createdBy, customerEligibility);
                    _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(customerId, customerProfileHistoryId);
                    logger.Info("History Created , CustomerId :" + customerId + ", Year: " + forYear);
                }

                customerWarmTransfer.IsWarmTransfer = isWarmTransfer;
                customerWarmTransfer.DateModified = DateTime.Now;
                customerWarmTransfer.ModifiedBy = createdBy;

                _customerWarmTransferRepository.Save(customerWarmTransfer);
                logger.Info("Updated Customer WarmTransfer, CustomerId :" + customerId + ", Year: " + forYear);
            }
        }
    }
}
