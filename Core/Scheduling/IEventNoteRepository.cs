using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventNoteRepository
    {
        EventNote GetById(long id);

        IEnumerable<EventNote> GetByIds(long[] ids);

        IEnumerable<EventNote> GetByEventIds(long[] eventIds);

        IEnumerable<EventNotesLog> GetEventNoteLogByIds(long[] ids);

        IEnumerable<EventNotesLog> GetEventNoteLogByEventIds(long[] eventIds);

        EventNote Save(EventNote domain);

        EventNotesLog SaveEventNotesLog(EventNotesLog domain);

        void DeleteEventNotesLog(long id);

        IEnumerable<EventNote> GetEventNotes(int pageNumber, int pageSize, EventNotesModelFilter eventNotesModelFilter, out int totalRecords);
    }
}
