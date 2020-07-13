using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class RescheduleApplointmentModelFactory : IRescheduleApplointmentModelFactory
    {
        public RescheduleApplointmentListModel Create(IEnumerable<EventAppointmentChangeLog> rescheduledAppointments, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Event> events,
                                                    IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, EventVolumeListModel eventsVolumeWithSponsoredBy)
        {
            var model = new RescheduleApplointmentListModel();
            var collection = new List<RescheduleApplointmentModel>();

            rescheduledAppointments.ToList().ForEach(ra =>
                {
                    var eventCustomer = eventCustomers.Single(ec => ec.Id == ra.EventCustomerId);
                    var customer = customers.Single(c => c.CustomerId == eventCustomer.CustomerId);
                    var oldEvent = events.Single(e => e.Id == ra.OldEventId);
                    var newEvent = events.Single(e => e.Id == ra.NewEventId);

                    var oldEventsVolumeWithSponsoredBy = eventsVolumeWithSponsoredBy.Collection.Where(e => e.EventCode == ra.OldEventId).FirstOrDefault();
                    var newEventsVolumeWithSponsoredBy = eventsVolumeWithSponsoredBy.Collection.Where(e => e.EventCode == ra.NewEventId).FirstOrDefault();

                    var oldEventSponsoredByName = string.Empty;
                    var newEventSponsoredByName = string.Empty;

                    if (oldEventsVolumeWithSponsoredBy != null)
                    {
                        oldEventSponsoredByName = oldEventsVolumeWithSponsoredBy.EventType.ToLower() == EventType.Corporate.ToString().ToLower() ? oldEventsVolumeWithSponsoredBy.CorporateAccount : oldEventsVolumeWithSponsoredBy.HospitalPartner;
                    }
                    if (newEventsVolumeWithSponsoredBy != null)
                    {
                        newEventSponsoredByName = newEventsVolumeWithSponsoredBy.EventType.ToLower() == EventType.Corporate.ToString().ToLower() ? newEventsVolumeWithSponsoredBy.CorporateAccount : newEventsVolumeWithSponsoredBy.HospitalPartner;
                    }

                    var registeredBy = agents.Single(a => a.Id == ra.CreatedByOrgRoleUserId);

                    var agentRole = roles.Single(r => r.Id == registeredBy.RoleId).DisplayName;
                    var agentName = agentIdNamePairs.Single(ap => ap.FirstValue == registeredBy.Id).SecondValue;

                    var rescheduleModel = new RescheduleApplointmentModel
                        {
                            CustomerId = customer.CustomerId,
                            CustomerName = customer.Name.FullName,
                            OldEventId = oldEvent.Id,
                            OldEventName = oldEvent.Name,
                            OldEventDate = oldEvent.EventDate,
                            OldAppointmentTime = ra.OldAppointmentTime,
                            NewEventId = newEvent.Id,
                            NewEventName = newEvent.Name,
                            NewEventDate = newEvent.EventDate,
                            NewAppointmentTime = ra.NewAppointmentTime,
                            RescheduledOn = ra.DateCreated,
                            RescheduledBy = agentName + "(" + agentRole + ")",
                            Reason = ra.ReasonId.HasValue && ra.ReasonId > 0 ? ((RescheduleAppointmentReason)ra.ReasonId.Value).GetDescription() : "N/A",
                            SubReason = ra.SubReasonId.HasValue && ra.SubReasonId > 0 ? ((RescheduleAppointmentSubReason)ra.SubReasonId.Value).GetDescription() : string.Empty,
                            Notes = ra.Notes,
                            NewEventSponsoredBy = newEventSponsoredByName,
                            OldEventSponsoredBy = oldEventSponsoredByName,
                        };
                    collection.Add(rescheduleModel);

                });

            model.Collection = collection;
            return model;
        }

        public IEnumerable<EventRescheduleAppointmentViewModel> CreateEventRescheduleAppointment(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers)
        {
            var list = new List<EventRescheduleAppointmentViewModel>();
            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.First(c => c.CustomerId == eventCustomer.CustomerId);
                var model = new EventRescheduleAppointmentViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.NameAsString,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    PhoneNumber = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                    EventId = eventCustomer.EventId,
                    EventCustomerId = eventCustomer.Id
                };
                list.Add(model);
            }

            return list;
        }
    }
}
