using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Events
{
    [DefaultImplementation]
    public class EventFilterPredicateFactory : IEventFilterPredicateFactory
    {
        // TODO: This method should not have any argument other than the view type.
        public Func<Event, bool> CreateEventFilterPredicate(ViewType viewType, string invitationCode, DateTime? fromDate, DateTime? toDate)
        {
            switch (viewType)
            {
                case ViewType.PublicWebsite:
                    return PublicEventFilterPredicate();
                case ViewType.Technician:
                    return TechnicianEventFilterPredicate(invitationCode, fromDate, toDate);
                case ViewType.CallCenterRep:
                    return CallCenterRepEventFilterPredicate(invitationCode, fromDate, toDate);
                case ViewType.CustomerPortal:
                    return CustomerEventFilterPredicate(invitationCode, fromDate, toDate);
                default:
                    throw new NotSupportedException(string.Format("The ViewType {0} is not yet supported.", viewType));
            }
        }


        // TODO: These must have different classes for each view type defined in the system.
        private static Func<Event, bool> PublicEventFilterPredicate()
        {
            return e =>
                   e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute, e.EventEndTime.Second) >=
                   DateTime.Now && e.Status != EventStatus.Canceled && e.RegistrationMode == RegistrationMode.Public;
        }

        private static Func<Event, bool> TechnicianEventFilterPredicate(string invitationCode, DateTime? fromDate, DateTime? toDate)
        {
            fromDate = fromDate ?? DateTime.Now;
            return
                e =>
                    DateTime.Compare(
                        e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute,
                                                             e.EventEndTime.Second), fromDate.Value) >= 0 &&
                    e.Status == EventStatus.Active &&
                    (!toDate.HasValue ||
                     DateTime.Compare(
                         e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute,
                                                              e.EventEndTime.Second), toDate.Value.GetEndOfDay()) <= 0) &&
                    (string.IsNullOrEmpty(invitationCode) || e.InvitationCode == invitationCode);
        }

        private static Func<Event, bool> CallCenterRepEventFilterPredicate(string invitationCode, DateTime? fromDate, DateTime? toDate)
        {
            fromDate = fromDate ?? DateTime.Now;
            return
                e =>
                DateTime.Compare(
                    e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute,
                                                         e.EventEndTime.Second), fromDate.Value) >= 0 &&
                (!toDate.HasValue ||
                 DateTime.Compare(
                     e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute,
                                                          e.EventEndTime.Second), toDate.Value.GetEndOfDay()) <= 0) &&
                (string.IsNullOrEmpty(invitationCode) || e.InvitationCode == invitationCode);
        }

        private static Func<Event, bool> CustomerEventFilterPredicate(string invitationCode, DateTime? fromDate, DateTime? toDate)
        {
            fromDate = fromDate ?? DateTime.Now;
            return
                e =>
                DateTime.Compare(
                    e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute,
                                                         e.EventEndTime.Second), fromDate.Value) >= 0 &&
                e.Status != EventStatus.Canceled && e.RegistrationMode == RegistrationMode.Public &&
                (!toDate.HasValue ||
                 DateTime.Compare(
                     e.EventDate.GetDateWithDifferentTime(e.EventEndTime.Hour, e.EventEndTime.Minute,
                                                          e.EventEndTime.Second), toDate.Value.GetEndOfDay()) <= 0) &&
                (string.IsNullOrEmpty(invitationCode) || e.InvitationCode == invitationCode);
        }
    }
}