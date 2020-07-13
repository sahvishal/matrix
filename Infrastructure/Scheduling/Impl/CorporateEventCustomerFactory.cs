using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CorporateEventCustomerFactory : ICorporateEventCustomerFactory
    {
        public CorporateEventViewModel Create(EventVolumeModel eventModel)
        {
            var corporateEventCustomerModel = new CorporateEventViewModel
            {
                EventId = eventModel.EventCode,
                EventDate = eventModel.EventDate,
                Address = eventModel.Address,
                Location = eventModel.Location,
                Pod = eventModel.Pod,
                CustomerCount = eventModel.AppointmentsBooked,
              };

            return corporateEventCustomerModel;
        }


        public CorporateEventCustomerListModel CreateCustomerScheduleModelforEvent(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, long eventId,
                IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests)
        {
            var customerModels = new List<CorporateEventCustomersModel>();
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

                    customerModels.Add(new CorporateEventCustomersModel
                    {
                        AppointmentTime = appointments.Where(a => ec.AppointmentId.Value == a.Id).FirstOrDefault().StartTime,
                        CustomerId = ec.CustomerId,
                        MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? string.Empty : customer.InsuranceId,
                        Package = customerPurchased,
                        PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                        PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : string.Empty,
                        PhoneBusiness = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.ToString() : string.Empty,
                    });
                }
            });
            var model = new CorporateEventCustomerListModel { Collection = customerModels };
            return model;
        }
    }
}
