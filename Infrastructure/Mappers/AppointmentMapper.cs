using System.Linq;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class AppointmentMapper : DomainEntityMapper<Appointment, EventAppointmentEntity>
    {
        // Todo: SRe
        protected override void MapDomainFields(EventAppointmentEntity entity, Appointment domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.AppointmentId;
            domainObjectToMapTo.StartTime = entity.StartTime;
            domainObjectToMapTo.EndTime = entity.EndTime;
            domainObjectToMapTo.ScheduledById = entity.ScheduledByOrgRoleUserId;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.CheckInTime = entity.CheckinTime;
            domainObjectToMapTo.CheckOutTime = entity.CheckoutTime;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;

            if (entity.EventSlotAppointment != null) domainObjectToMapTo.SlotIds = entity.EventSlotAppointment.Select(m => m.SlotId).ToArray();
        }

        protected override void MapEntityFields(Appointment domainObject, EventAppointmentEntity entityToMapTo)
        {
            entityToMapTo.AppointmentId = domainObject.Id;
            entityToMapTo.StartTime = domainObject.StartTime;
            entityToMapTo.EndTime = domainObject.EndTime;
            entityToMapTo.ScheduledByOrgRoleUserId = domainObject.ScheduledById;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.CheckinTime = domainObject.CheckInTime;
            entityToMapTo.CheckinTime = domainObject.CheckOutTime;
            entityToMapTo.DateCreated = domainObject.DateCreated;
            entityToMapTo.DateModified = domainObject.DateModified;
        }
    }
}
