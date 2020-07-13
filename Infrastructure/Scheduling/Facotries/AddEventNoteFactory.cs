using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class AddEventNoteFactory : IAddEventNoteFactory
    {
        public AddNotesListModel Create(IEnumerable<EventBasicInfoViewModel> events, EventNote eventNote, IEnumerable<EventNotesLog> eventNotesLogs, IEnumerable<OrderedPair<long, string>> eventIdCorporateAccountNamePairs)
        {
            var collection = new List<AddNotesViewModel>();

            foreach (var theEvent in events)
            {
                var eventIdCorporateAccountNamePair = eventIdCorporateAccountNamePairs.FirstOrDefault(x => x.FirstValue == theEvent.Id);
                var eventNotesLog = eventNotesLogs != null ? eventNotesLogs.FirstOrDefault(x => x.EventId == theEvent.Id) : null;

                collection.Add(new AddNotesViewModel
                {
                    EventId = theEvent.Id,
                    EventDate = theEvent.EventDate,
                    HostName = theEvent.HostName,
                    Pods = theEvent.Pods.Select(x => x.SecondValue),
                    HealthPlan = eventIdCorporateAccountNamePair != null ? eventIdCorporateAccountNamePair.SecondValue : "N/A",
                    IsSelected = eventNotesLog != null,
                });
            }

            var model = new AddNotesListModel
            {
                Collection = collection,
                TotalRecords = collection.Count,
                AllSelected = collection.All(x => x.IsSelected),
                IsPublish = eventNote != null && eventNote.IsPublished,
                Note = eventNote != null ? eventNote.Note : string.Empty
            };

            return model;
        }

        public EventNotesListModel CreateListModel(IEnumerable<EventNote> eventNotes, IEnumerable<EventNotesLog> eventNotesLogs, IEnumerable<OrderedPair<long, string>> organizationRoleUsers)
        {
            var collection = new List<EventNotesViewModel>();

            foreach (var eventNote in eventNotes)
            {
                var logs = eventNotesLogs.Where(x => x.EventNoteId == eventNote.Id);
                if (!logs.Any()) continue;

                var createdByOrgRoleUser = organizationRoleUsers.FirstOrDefault(x => x.FirstValue == eventNote.CreatedBy);
                var modifiedByOrgRoleUser = eventNote.ModifiedBy.HasValue ? organizationRoleUsers.FirstOrDefault(x => x.FirstValue == eventNote.ModifiedBy) : null;

                collection.Add(new EventNotesViewModel
                {
                    Id = eventNote.Id,
                    Note = eventNote.Note,
                    SelectedEventIds = string.Join(", ", logs.Select(x => x.EventId)),
                    HealthPlanId = eventNote.HealthPlanId,
                    EventDateFrom = eventNote.EventDateFrom,
                    EventDateTo = eventNote.EventDateTo,
                    PodId = eventNote.PodId,
                    IsPublished = eventNote.IsPublished,
                    CreatedDate = eventNote.DateCreated,
                    CreatedBy = createdByOrgRoleUser != null ? createdByOrgRoleUser.SecondValue : string.Empty,
                    ModifiedDate = eventNote.DateModified,
                    ModifiedBy = modifiedByOrgRoleUser != null ? modifiedByOrgRoleUser.SecondValue : string.Empty
                });
            }

            return new EventNotesListModel
            {
                Collection = collection
            };
        }
    }
}
