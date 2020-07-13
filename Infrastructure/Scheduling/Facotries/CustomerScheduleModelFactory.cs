using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class CustomerScheduleModelFactory : ICustomerScheduleModelFactory
    {

        public EventCustomerScheduleListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel,
                IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> products)
        {
            var model = new EventCustomerScheduleListModel();
            var eventCustomerModels = new List<EventCustomerScheduleModel>();
            eventListModel.Collection.ToList().ForEach(e =>
                                                                  {
                                                                      var eventCustomerModel = new EventCustomerScheduleModel
                                                                                                   {
                                                                                                       Address = e.Address,
                                                                                                       EventDate = e.EventDate,
                                                                                                       EventId = e.EventCode,
                                                                                                       Location = e.Location,

                                                                                                       Vehicle = e.Pod,
                                                                                                       CustomerCount = e.AppointmentsBooked,
                                                                                                       Customers =
                                                                                                           CreateCustomerScheduleModelforEvent(eventCustomers, appointments, orders, e.EventCode, customers, packages, tests, products)
                                                                                                   };
                                                                      eventCustomerModels.Add(eventCustomerModel);
                                                                  });
            if (eventCustomerModels != null) eventCustomerModels = eventCustomerModels.OrderBy(a => a.EventDate).ToList();
            model.Collection = eventCustomerModels;
            return model;
        }

        public EventCustomerScheduleModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeModel eventModel,
                IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> products)
        {

            var eventCustomerModel = new EventCustomerScheduleModel
            {
                Address =
                    eventModel.Address,
                EventDate =
                    eventModel.EventDate,
                EventId =
                    eventModel.EventCode,
                Location =
                    eventModel.Location,
                Vehicle =
                    eventModel.Pod,
                CustomerCount = eventModel.AppointmentsBooked,
                Customers =
                    CreateCustomerScheduleModelforEvent(eventCustomers, appointments, orders, eventModel.EventCode, customers, packages, tests, products)
            };

            if (eventCustomerModel.Customers != null && eventCustomerModel.Customers.Count() > 0)
            {
                eventCustomerModel.Customers = eventCustomerModel.Customers.OrderBy(c => c.AppointmentTime);
            }

            return eventCustomerModel;
        }

        private static IEnumerable<CustomerScheduleModel> CreateCustomerScheduleModelforEvent(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, long eventId,
                IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> products)
        {
            var customerModels = new List<CustomerScheduleModel>();
            eventCustomers.Where(ec => ec.EventId == eventId && ec.AppointmentId.HasValue).ToList().ForEach(ec =>
                                                                                   {

                                                                                       var order = orders.Where(o => o.EventId == eventId && o.CustomerId == ec.CustomerId).FirstOrDefault();

                                                                                       var customer = customers.Where(c => c.CustomerId == ec.CustomerId).FirstOrDefault();
                                                                                       if (order != null && customer != null)
                                                                                       {
                                                                                           var package = packages.Where(p => p.FirstValue == order.Id).FirstOrDefault();

                                                                                           var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                                                                                           string customerPurchased;

                                                                                           if (package != null && !test.IsNullOrEmpty())
                                                                                               customerPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                                                                                           else if (!test.IsNullOrEmpty())
                                                                                               customerPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                                                                                           else if (package != null)
                                                                                               customerPurchased = package.SecondValue;
                                                                                           else
                                                                                               customerPurchased = "";
                                                                                           var orderItemIds = order.OrderDetails.Where(od => od.IsCompleted).Select(od => od.OrderItemId).ToArray();
                                                                                           var additionalProduct = products.Where(p => orderItemIds.Contains(p.FirstValue)).ToArray();

                                                                                           customerModels.Add(new CustomerScheduleModel
                                                                                                                  {
                                                                                                                      CustomerId = ec.CustomerId,
                                                                                                                      CustomerCode = customer.CustomerId.ToString(),
                                                                                                                      CustomerName = customer.NameAsString,
                                                                                                                      AmountPaid = order.TotalAmountPaid,
                                                                                                                      AppointmentTime = appointments.Where(a => ec.AppointmentId.Value == a.Id).FirstOrDefault().StartTime,
                                                                                                                      PhoneBusiness = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.ToString() : string.Empty,
                                                                                                                      PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : string.Empty,
                                                                                                                      PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                                                                                                                      TotalAmount = order.DiscountedTotal,
                                                                                                                      Package = customerPurchased,
                                                                                                                      AdditionalProduct = additionalProduct != null ? string.Join(", ", additionalProduct.Select(ap => ap.SecondValue)) : string.Empty,
                                                                                                                      PhoneOfficeExtension = customer.PhoneOfficeExtension
                                                                                                                  });
                                                                                       }
                                                                                   });
            return customerModels;
        }
    }
}
