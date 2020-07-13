using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Scheduling.Mappers
{
    public class CustomerCallNotesMapper : DomainEntityMapper<CustomerCallNotes, CustomerRegistrationNotesEntity>
    {
        protected override void MapDomainFields(CustomerRegistrationNotesEntity entity,CustomerCallNotes domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CustomerRegistrationNotesId;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.NotesType = entity.NoteType.HasValue
                                                ? (CustomerRegistrationNotesType) entity.NoteType.Value
                                                : CustomerRegistrationNotesType.AppointmentNote;
            domainObjectToMapTo.ReasonId = entity.ReasonId;
            domainObjectToMapTo.DataRecorderMetaData=new DataRecorderMetaData()
                                                         {
                                                             DateCreated =entity.DateCreated,
                                                             DateModified = entity.DateModified,
                                                             DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId)
                                                         };
        }

        protected override void MapEntityFields(CustomerCallNotes domainObject, CustomerRegistrationNotesEntity entityToMapTo)
        {
            entityToMapTo.CustomerRegistrationNotesId = domainObject.Id;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.NoteType = (int) domainObject.NotesType;
            entityToMapTo.ReasonId = domainObject.ReasonId;
            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified;
                if (domainObject.DataRecorderMetaData.DataRecorderCreator != null)
                    entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            }
        }
    }
}
