using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IAddEventNoteFactory
    {
        AddNotesListModel Create(IEnumerable<EventBasicInfoViewModel> events, EventNote eventNote, IEnumerable<EventNotesLog> eventNotesLogs, IEnumerable<OrderedPair<long, string>> eventIdCorporateAccountNamePairs);

        EventNotesListModel CreateListModel(IEnumerable<EventNote> eventNotes, IEnumerable<EventNotesLog> eventNotesLogs, IEnumerable<OrderedPair<long,string>> organizationRoleUsers);
    }
}
