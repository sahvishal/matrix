using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class PreAssessmentReportingFactory : IPreAssessmentReportingFactory
    {

        public IEnumerable<PreAssessmentReportViewModel> Create(IEnumerable<PreAssessmentCallCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<EventBasicInfoViewModel> events, IEnumerable<Call> calls,
              IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<CorporateAccount> healthPlans, IEnumerable<OrderedPair<long, string>> restrictionIdNamePairs,
              IEnumerable<OrderedPair<long, string>> confirmedByIdNamePairs, IEnumerable<OrderedPair<long, string>> calledByAgentNameIdPairs)
        {
            var collection = new List<PreAssessmentReportViewModel>();

            foreach (var cqc in callQueueCustomers)
            {
                var customer = customers.First(x => x.CustomerId == cqc.CustomerId);

                var eventData = events.FirstOrDefault(x => x.Id == cqc.EventId);

                var callIds = callQueueCustomers.Where(x => x.CustomerId == cqc.CustomerId).Select(x => x.CallId);
                
                var customerCalls = calls.Where(x => callIds.Contains(x.Id)).OrderByDescending(x => x.DateCreated);
                if (!customerCalls.Any())
                {
                    customerCalls = calls.Where(x => x.CalledCustomerId == cqc.CustomerId && x.EventId == cqc.EventId).OrderByDescending(x => x.DateCreated);
                }

                var eventCustomer = cqc.EventCustomerID.HasValue ? eventCustomers.First(x => x.Id == cqc.EventCustomerID.Value) : null;
                if (eventCustomer == null)
                {
                    eventCustomer = eventCustomers.FirstOrDefault(x => x.CustomerId == cqc.CustomerId && x.EventId == cqc.EventId);
                }

                var appointment = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? appointments.First(x => x.Id == eventCustomer.AppointmentId.Value) : null;

                var outcome = string.Empty;
                var disposition = string.Empty;
                var calledBy = string.Empty;

                var healthPlan = cqc.HealthPlanId.HasValue ? healthPlans.First(x => x.Id == cqc.HealthPlanId.Value) : null;
                var restrictedTo = healthPlan != null && restrictionIdNamePairs != null ? restrictionIdNamePairs.Where(x => x.FirstValue == healthPlan.Id).Select(x => x.SecondValue).Distinct() : null;

                var confirmedBy = eventCustomer != null && eventCustomer.ConfirmedBy.HasValue ? confirmedByIdNamePairs.First(x => x.FirstValue == eventCustomer.ConfirmedBy.Value).SecondValue : "";

                if (customerCalls.Any())
                {
                    outcome = EnumExtension.GetDescription(((CallStatus)customerCalls.First().Status));

                    ProspectCustomerTag prospectCustomerTag;
                    Enum.TryParse(customerCalls.First().Disposition, out prospectCustomerTag);
                    var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), prospectCustomerTag);
                    disposition = customerCalls.First().Disposition != string.Empty && isDefined ? EnumExtension.GetDescription(prospectCustomerTag) : "N/A";

                    calledBy = calledByAgentNameIdPairs.First(x => x.FirstValue == customerCalls.First().CreatedByOrgRoleUserId).SecondValue;
                }

                var model = new PreAssessmentReportViewModel
                {
                    PatientId = customer.CustomerId,
                    Name = customer.Name.FullName,
                    EventID = eventData.Id,
                    EventAddress = eventData.HostAddress,
                    EventDate = eventData.EventDate,
                    AppointmentTime = appointment != null ? eventData.EventDate.Add(appointment.StartTime.TimeOfDay) : (DateTime?)null,
                    BookingDate = eventCustomer != null ? eventCustomer.DataRecorderMetaData.DateCreated : (DateTime?)null,
                    LastContactedDate = customerCalls.Any() ? customerCalls.First().DateCreated : (DateTime?)null,
                    Outcome = outcome,
                    Disposition = disposition,
                    CallCount = customerCalls.Count(),
                    IsRestricted = healthPlan != null && healthPlan.RestrictHealthPlanData ? "Yes" : "No",
                    RestrictedTo = !restrictedTo.IsNullOrEmpty() ? string.Join(", ", restrictedTo) : "N/A",
                    CalledBy = calledBy
                };

                collection.Add(model);
            }

            return collection;
        }


    }
}
