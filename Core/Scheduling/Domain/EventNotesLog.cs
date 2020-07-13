using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventNotesLog : DomainObjectBase
    {
        public long EventNoteId { get; set; }
        public long EventId { get; set; }
    }
}
