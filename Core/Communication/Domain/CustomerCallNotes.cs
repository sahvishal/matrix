using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Communication.Domain
{
    public class CustomerCallNotes : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long? EventId { get; set; }
        public string Notes { get; set; }
        public string ReasonName { get; set; }
        public CustomerRegistrationNotesType NotesType { get; set; }
        public long? ReasonId { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long ProspectCustomerId { get; set; }

        public CustomerCallNotes() { }

        public CustomerCallNotes(long customerRegistrationNotesId)
            : base(customerRegistrationNotesId)
        { }

        public string CreatedBy { get; set; }
    }
}