using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CustomerNotesService : ICustomerNotesService
    {
        private readonly IUniqueItemRepository<CustomerCallNotes> _customerNotesRepository;

        public CustomerNotesService(IUniqueItemRepository<CustomerCallNotes> customerNotesRepository)
        {
            _customerNotesRepository = customerNotesRepository;
        }

        public CustomerCallNotes SaveCustomerNotes(long customerId, long eventId, string notes, long createdByOrgRoleUserId, CustomerRegistrationNotesType notesType, long? reasonId = null)
        {
            var customerRegistrationNotes = new CustomerCallNotes
            {
                CustomerId = customerId,
                EventId = eventId > 0 ? eventId : (long?)null,
                Notes = notes,
                NotesType = notesType,
                ReasonId = reasonId,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(createdByOrgRoleUserId)
                }
            };

            
            customerRegistrationNotes = _customerNotesRepository.Save(customerRegistrationNotes);
            return customerRegistrationNotes;
        }

        public CustomerCallNotes SavePhoneNumberUpdatedMessage(long customerId, long createdByOrgRoleUserId)
        {
            //var notes = string.Format("Phone number was updated on {0} at {1}.", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            var notes = "Phone number was updated.";
            return SaveCustomerNotes(customerId, 0, notes, createdByOrgRoleUserId, CustomerRegistrationNotesType.CustomerNote);
        }
    }
}
