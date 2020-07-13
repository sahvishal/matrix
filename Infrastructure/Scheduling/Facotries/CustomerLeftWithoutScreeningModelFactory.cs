using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class CustomerLeftWithoutScreeningModelFactory : ICustomerLeftWithoutScreeningModelFactory
    {
        public CustomerLeftWithoutScreeningListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel,
            IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<CustomerCallNotes> patientLeftNotes, IEnumerable<CorporateAccount> corporateAccounts)
        {
            var model = new CustomerLeftWithoutScreeningListModel();
            var customerLeftWithoutScreeningModels = new List<CustomerLeftWithoutScreeningModel>();

            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = eventListModel.Collection.Where(e => e.EventCode == ec.EventId).FirstOrDefault();
                var order = orders.Where(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId).FirstOrDefault();
                var customer = customers.Where(c => c.CustomerId == ec.CustomerId).FirstOrDefault();
                var package = packages.Where(p => p.FirstValue == order.Id).FirstOrDefault();
                var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                var productPurchased = string.Empty;

                if (package != null && !test.IsNullOrEmpty())
                    productPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (!test.IsNullOrEmpty())
                    productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (package != null)
                    productPurchased = package.SecondValue;

                var scheduledBy = ec.DataRecorderMetaData.DataRecorderCreator.Id == ec.CustomerId ? "Self" : idNamePairs.Where(p => p.FirstValue == ec.DataRecorderMetaData.DataRecorderCreator.Id).First().SecondValue;
                var registeredBy = (ec.DataRecorderMetaData == null || ec.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.Where(a => a.Id == ec.DataRecorderMetaData.DataRecorderCreator.Id).FirstOrDefault());

                var agentRole = string.Empty;

                var pcpAppointment = pcpAppointments.SingleOrDefault(m => m.EventCustomerId == ec.Id);

                if (registeredBy != null)
                {
                    agentRole = registeredBy.RoleId == (long)Roles.Customer ? "Internet" : roles.Where(r => r.Id == registeredBy.RoleId).FirstOrDefault().DisplayName;
                }

                var appointment = ec.AppointmentId.HasValue ? appointments.FirstOrDefault(a => a.Id == ec.AppointmentId.Value) : null;

                var note = string.Empty;
                if (ec.LeftWithoutScreeningNotesId.HasValue)
                {
                    var patientLeftNotesForCustomer = patientLeftNotes.FirstOrDefault(x => x.Id == ec.LeftWithoutScreeningNotesId.Value);
                    note = patientLeftNotesForCustomer != null ? patientLeftNotesForCustomer.Notes : string.Empty;
                }
                var account = corporateAccounts.IsNullOrEmpty() ? null : corporateAccounts.SingleOrDefault(x => x.Tag == customer.Tag);

                var customerLeftWithoutScreeningModel = new CustomerLeftWithoutScreeningModel()
                {
                    Address = customer.Address,
                    CustomerCode = customer.CustomerId.ToString(),
                    AmountPaid = order.TotalAmountPaid,
                    AppointmentTime = appointment != null ? (DateTime?)appointment.StartTime : null,
                    CheckInTime = (appointment != null && appointment.CheckInTime.HasValue) ? (DateTime?)appointment.CheckInTime.Value : null,
                    CheckOutTime = (appointment != null && appointment.CheckOutTime.HasValue) ? (DateTime?)appointment.CheckOutTime.Value : null,
                    CustomerId = ec.CustomerId,
                    CustomerName = customer.NameAsString,
                    DateofBirth = customer.DateOfBirth,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    EventId = eventModel.EventCode,
                    EventDate = eventModel.EventDate,
                    Pod = eventModel.Pod,
                    Gender = customer.Gender.ToString(),
                    Host = eventModel.Location,
                    HostAddress = eventModel.Address,
                    Package = productPurchased,
                    PhoneBusiness = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.ToString() : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : string.Empty,
                    PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                    TotalAmount = order.DiscountedTotal,
                    AdSource = ec.MarketingSource,
                    PhoneOfficeExtension = customer.PhoneOfficeExtension,
                    BookingAgent = scheduledBy,
                    RegistrationMode = agentRole,
                    RegistrationDate = ec.DataRecorderMetaData != null ? (DateTime?)ec.DataRecorderMetaData.DateCreated : null,
                    PCPAppointmentDate = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null,
                    PCPAppointmentTime = pcpAppointment != null ? pcpAppointment.AppointmentOn.ToShortTimeString() : string.Empty,
                    LeftWithoutScreeningReason = ec.LeftWithoutScreeningReasonId.HasValue ? ((LeftWithoutScreeningReason)ec.LeftWithoutScreeningReasonId.Value).GetDescription() : string.Empty,
                    LeftWithoutScreeningNotes = note,
                    Healthplan = account != null ? account.Name : string.Empty,
                };

                customerLeftWithoutScreeningModels.Add(customerLeftWithoutScreeningModel);
            });
            model.Collection = customerLeftWithoutScreeningModels;
            return model;
        }
    }
}
