using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class CustomerOrderHistoryService : ICustomerOrderHistoryService
    {
        private readonly ICustomerOrderHistoryRepository _customerOrderHistoryRepository;

        public CustomerOrderHistoryService(ICustomerOrderHistoryRepository customerOrderHistoryRepository)
        {
            _customerOrderHistoryRepository = customerOrderHistoryRepository;
        }

        public void SaveCustomerOrderHistory(EventCustomer eventCustomer, long corporateUploadId, long oldEventPackageId, long newEventPackageId,
            IEnumerable<long> oldEventTestIds, IEnumerable<long> newEventTestIds)
        {
            var customerOrderHistories = new List<CustomerOrderHistory>();

            if (oldEventPackageId > 0)
            {
                var model = new CustomerOrderHistory
                {
                    UploadId = corporateUploadId,
                    EventCustomerId = eventCustomer.Id,
                    EventId = eventCustomer.EventId,
                    CustomerId = eventCustomer.CustomerId,
                    EventPackageId = oldEventPackageId,
                    OrderItemStatusId = (long)OrderItemStatus.Old,
                };
                customerOrderHistories.Add(model);
            }

            if (newEventPackageId > 0)
            {
                var model = new CustomerOrderHistory
                {
                    UploadId = corporateUploadId,
                    EventCustomerId = eventCustomer.Id,
                    EventId = eventCustomer.EventId,
                    CustomerId = eventCustomer.CustomerId,
                    EventPackageId = newEventPackageId,
                    OrderItemStatusId = (long)OrderItemStatus.New,
                };
                customerOrderHistories.Add(model);
            }

            if (oldEventPackageId > 0 && newEventPackageId <= 0)
            {
                var model = new CustomerOrderHistory
                {
                    UploadId = corporateUploadId,
                    EventCustomerId = eventCustomer.Id,
                    EventId = eventCustomer.EventId,
                    CustomerId = eventCustomer.CustomerId,
                    EventPackageId = oldEventPackageId,
                    OrderItemStatusId = (long)OrderItemStatus.Existing,
                };
                customerOrderHistories.Add(model);
            }

            if (oldEventTestIds != null && oldEventTestIds.Any())
            {
                foreach (var eventTestId in oldEventTestIds)
                {
                    var model = new CustomerOrderHistory
                    {
                        UploadId = corporateUploadId,
                        EventCustomerId = eventCustomer.Id,
                        EventId = eventCustomer.EventId,
                        CustomerId = eventCustomer.CustomerId,
                        EventTestId = eventTestId,
                        OrderItemStatusId = (long)OrderItemStatus.Old,
                    };
                    customerOrderHistories.Add(model);
                }
            }

            if (newEventTestIds != null && newEventTestIds.Any())
            {
                foreach (var eventTestId in newEventTestIds)
                {
                    var model = new CustomerOrderHistory
                    {
                        UploadId = corporateUploadId,
                        EventCustomerId = eventCustomer.Id,
                        EventId = eventCustomer.EventId,
                        CustomerId = eventCustomer.CustomerId,
                        EventTestId = eventTestId,
                        OrderItemStatusId = oldEventTestIds != null && oldEventTestIds.Any() && oldEventTestIds.Contains(eventTestId) ? (long)OrderItemStatus.Existing : (long)OrderItemStatus.New,
                    };
                    customerOrderHistories.Add(model);
                }
            }

            _customerOrderHistoryRepository.Save(customerOrderHistories);
        }
    }
}
