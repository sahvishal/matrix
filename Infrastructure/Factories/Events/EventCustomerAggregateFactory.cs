using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Events
{
    [DefaultImplementation]
    public class EventCustomerAggregateFactory : IEventCustomerAggregateFactory
    {
        private readonly IUniqueItemRepository<Event> _eventRepository = new EventRepository();
        private readonly IHostRepository _hostRepository = new HostRepository();
        private readonly ICustomerRepository _customerRepository = new CustomerRepository();
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IUniqueItemRepository<Appointment> _appointmentRepository = new AppointmentRepository();
        private readonly IEventPackageRepository _packageRepository = new EventPackageRepository();
        private readonly IOrderController _orderController = new OrderController();
        private readonly ISourceCodeRepository _sourceCodeRepository = new SourceCodeRepository();
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public List<EventCustomerAggregate> CreateAggregatesFromTypedViewCollection
            (CustomerEventBasicInfoTypedView customerEventBasicInfoTypedView)
        {
            if (customerEventBasicInfoTypedView == null)
            {
                throw new ArgumentNullException("customerEventBasicInfoTypedView",
                                                "CustomerEventBasicInfoTypedView given cannot be null.");
            }
            var eventCustomers = new List<EventCustomerAggregate>();
            if (customerEventBasicInfoTypedView.Count == 0)
            {
                return eventCustomers;
            }

            var currentEventCustomerId = customerEventBasicInfoTypedView.First().EventCustomerId;
            var eventCustomersByEventCustomerId = new List<CustomerEventBasicInfoRow>();
            foreach (var customerEventInfo in (customerEventBasicInfoTypedView.OrderBy(c => c.EventCustomerId)))
            {
                if (customerEventInfo.EventCustomerId != currentEventCustomerId)
                {
                    eventCustomersByEventCustomerId.Clear();
                    currentEventCustomerId = customerEventInfo.EventCustomerId;
                }

                if (!customerEventInfo.IsPodActive)
                {
                    continue;
                }

                bool skip = false;
                foreach (var customerEventBasicInfoRow in eventCustomersByEventCustomerId)
                {
                    if (customerEventInfo.EventName == customerEventBasicInfoRow.EventName &&
                        customerEventInfo.DrOrCr == customerEventBasicInfoRow.DrOrCr &&
                        customerEventInfo.PaymentTotalAmount == customerEventBasicInfoRow.PaymentTotalAmount)
                    {
                        skip = true;
                        break;
                    }
                }

                if (skip)
                {
                    continue;
                }
                eventCustomersByEventCustomerId.Add(customerEventInfo);

                EventCustomerAggregate eventCustomer = GetEventCustomerAggregateFromTypedViewRow(customerEventInfo);
                var customerInfoForEventCustomerId = eventCustomers.Where(e => e.EventCustomerId == eventCustomer.EventCustomerId);
                int multiplier = customerEventInfo.DrOrCr ? -1 : 1;
                if (customerInfoForEventCustomerId.Count() > 0)
                {
                    customerInfoForEventCustomerId.Single().PaymentAmount += eventCustomer.PaymentAmount * multiplier;
                    continue;
                }
                eventCustomer.PaymentAmount *= multiplier;
                eventCustomers.Add(eventCustomer);
            }
            return eventCustomers;
        }

        public EventCustomerAggregate GetEventCustomerAggregateFromTypedViewRow(CustomerEventBasicInfoRow customerEventInfo)
        {
            if (customerEventInfo == null)
            {
                throw new ArgumentNullException("customerEventInfo", "CustomerEventBasicInfoRow given cannot be null.");
            }

            var signUpMode = customerEventInfo.EventSignupMode != 0 ? (CustomerEventSignUpMode)customerEventInfo.EventSignupMode :
                                                                                                                                     CustomerEventSignUpMode.Online;

            var customerAddress = new Address
                                      {
                                          StreetAddressLine1 = customerEventInfo.Address1,
                                          StreetAddressLine2 = customerEventInfo.Address2,
                                          City = customerEventInfo.City,
                                          State = customerEventInfo.State,
                                          ZipCode = new ZipCode { Zip = customerEventInfo.ZipCode }
                                      };

            return new EventCustomerAggregate
                       {
                           CustomerId = customerEventInfo.CustomerId,
                           CustomerSignupDate = customerEventInfo.CustomerSignupDate,
                           EventCustomerId = customerEventInfo.EventCustomerId,
                           EventDate = customerEventInfo.EventDate,
                           EventId = customerEventInfo.EventId,
                           EventName = customerEventInfo.EventName,
                           EventSignupDate = customerEventInfo.EventSignupDate,
                           FirstName = customerEventInfo.FirstName.Trim(),
                           LastName = customerEventInfo.LastName.Trim(),
                           IncomingPhoneNumber = customerEventInfo.IncomingPhoneLine,
                           IsPaid = customerEventInfo.IsPaid,
                           SignUpMarketingSource = string.Empty,
                           MarketingSource = customerEventInfo.MarketingSource,
                           PackageName = customerEventInfo.PackageName,
                           PaymentAmount = customerEventInfo.PaymentTotalAmount,
                           PodName = customerEventInfo.PodName,
                           SignUpMode = signUpMode,
                           SourceCode = customerEventInfo.CouponCode,
                           CustomerAddress = customerAddress,

                           PaymentNet = customerEventInfo.PaymentNet,
                           PaidAmount = customerEventInfo.PaidAmount,
                           UnpaidAmount = customerEventInfo.UnpaidAmount
                       };
        }

        public EventCustomerAggregate CreateEventCustomerAggregate(EventCustomer eventCustomer)
        {
            // Collect all the required data from different repositories.
            var eventData = _eventRepository.GetById(eventCustomer.EventId);
            var eventHost = _hostRepository.GetHostForEvent(eventCustomer.EventId);
            var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);
            var order = _orderRepository.GetOrder(customer.CustomerId, eventData.Id);
            var activeOrderDetail = _orderController.GetActiveOrderDetail(order);

            if (eventHost == null || appointment == null || order == null || activeOrderDetail == null)
                return null;

            var package = _packageRepository.GetById(activeOrderDetail.OrderItem.ItemId);
            string packageName = "";
            if (package != null) packageName = package.Package.Name;

            var sourceCode = activeOrderDetail.SourceCodeOrderDetail != null ? _sourceCodeRepository.GetSourceCodeById(activeOrderDetail.SourceCodeOrderDetail.SourceCodeId) : null;

            var paymentTypes = string.Join(",", order.PaymentsApplied.Select(pa => pa.PaymentType.Name).ToArray());

            CustomerEventSignUpMode signUpMode = GetEventSignUpMode(eventCustomer);

            return new EventCustomerAggregate
                       {
                           AppointmentId = eventCustomer.AppointmentId.Value,
                           AppointmentTime = appointment.StartTime,
                           CustomerAddress = customer.Address,
                           CustomerId = customer.CustomerId,
                           CustomerSignupDate = customer.DateCreated,
                           EventAddress = eventHost.Address,
                           EventCustomerId = eventCustomer.Id,
                           EventDate = eventData.EventDate,
                           EventId = eventData.Id,
                           EventName = eventData.Name,
                           EventSignupDate =
                               eventCustomer.DataRecorderMetaData != null
                                   ? eventCustomer.DataRecorderMetaData.DateCreated
                                   : default(DateTime),
                           EventStatus = eventData.Status,
                           FirstName = customer.Name != null ? customer.Name.FirstName : string.Empty,
                           IsPaid = order.TotalAmountPaid >= order.DiscountedTotal,
                           LastName = customer.Name != null ? customer.Name.LastName : string.Empty,
                           MarketingSource = eventCustomer.MarketingSource,
                           MiddleName = customer.Name != null ? customer.Name.MiddleName : string.Empty,
                           PackageName = packageName,
                           PackageCost = activeOrderDetail.Price,
                           PaidAmount = order.TotalAmountPaid,
                           PaymentAmount = order.UndiscountedTotal,
                           PaymentNet = order.DiscountedTotal,
                           PaymentType = paymentTypes,
                           SignUpMarketingSource = eventCustomer.MarketingSource,
                           SignUpMode = signUpMode,
                           SourceCode = sourceCode != null ? sourceCode.CouponCode : string.Empty,
                           UnpaidAmount = order.TotalAmountPaid - order.DiscountedTotal
                       };
        }

        private CustomerEventSignUpMode GetEventSignUpMode(EventCustomer eventCustomer)
        {
            var roleId = GetParentRoleIdByRoleId(eventCustomer.DataRecorderMetaData.DataRecorderCreator.RoleId);
            switch ((Roles)roleId)
            {
                case Roles.Technician:
                    return CustomerEventSignUpMode.WalkIn;
                case Roles.CallCenterRep:
                    return CustomerEventSignUpMode.CallCenter;
                case Roles.Customer:
                    return CustomerEventSignUpMode.Online;
                default:
                    throw new NotSupportedException("The sign up mode is not authorized.");
            }
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value :  roleId;
        }
    }
}