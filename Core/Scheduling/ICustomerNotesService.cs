using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerNotesService
    {
        CustomerCallNotes SaveCustomerNotes(long customerId, long eventId, string notes, long createdByOrgRoleUserId, CustomerRegistrationNotesType notesType, long? reasonId = null);
        CustomerCallNotes SavePhoneNumberUpdatedMessage(long customerId, long createdByOrgRoleUserId);
    }
}
