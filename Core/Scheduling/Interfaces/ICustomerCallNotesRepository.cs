using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface ICustomerCallNotesRepository
    {
        IEnumerable<CustomerCallNotes> GetEventCustomerAppointmentNotes(long customerId, long eventId);
        IEnumerable<CustomerCallNotes> GetCustomerNotes(long customerId, bool includeBlankNotes = false);
        IEnumerable<CustomerCallNotes> GetCustomerNotes(long eventId, IEnumerable<long> customerIds);

        bool Delete(long customerRegistrationNotesId);
        bool UpdateNotes(long customerRegistrationNotesId, string notes);
        IEnumerable<CustomerCallNotes> GetNotes(IEnumerable<long> customerIds, CustomerRegistrationNotesType notesType);
        void Update(IEnumerable<CustomerCallNotes> customerCallNoteses);
        IEnumerable<CustomerCallNotes> GetProspectCustomerNotes(IEnumerable<long> prospectCustomerIds);
    }
}
