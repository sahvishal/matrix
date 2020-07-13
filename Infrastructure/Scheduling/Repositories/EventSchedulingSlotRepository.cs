using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventSchedulingSlotRepository : PersistenceRepository, IEventSchedulingSlotRepository
    {
        private const int ExpiryTimeinMinutes = 15;

        public EventSchedulingSlotRepository()
        {
            
        }

        public EventSchedulingSlot GetbyId(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(EventSchedulingSlotFields.SlotId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<EventSchedulingSlot>(id);
            }
        }

        public IEnumerable<EventSchedulingSlot> GetbyIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(EventSchedulingSlotFields.SlotId == ids.ToArray()));
        }

        public IEnumerable<EventSchedulingSlot> GetbyEventId(long eventId)
        {
            ReleaseAllTemporarySlotsPastExpiryTime();
            return Get(new RelationPredicateBucket(EventSchedulingSlotFields.EventId == eventId));
        }

        public IEnumerable<EventSchedulingSlot> GetbyEventIds(IEnumerable<long> eventIds)
        {
            return Get(new RelationPredicateBucket(EventSchedulingSlotFields.EventId == eventIds.ToArray()));
        }

        public EventSchedulingSlot Save(EventSchedulingSlot slot)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventSchedulingSlot, EventSchedulingSlotEntity>(slot);

                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();

                return Mapper.Map<EventSchedulingSlotEntity, EventSchedulingSlot>(entity);
            }
        }

        private IEnumerable<EventSchedulingSlot> Get(IRelationPredicateBucket expression)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventSlotEntities = new EntityCollection<EventSchedulingSlotEntity>();
                adapter.FetchEntityCollection(eventSlotEntities, expression);
                var eventSlots = Mapper.Map<IEnumerable<EventSchedulingSlotEntity>, IEnumerable<EventSchedulingSlot>>(eventSlotEntities);

                return eventSlots.OrderBy(es => es.StartTime).ToArray();
            }
        }

        public bool Delete(EventSchedulingSlot slot)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventSchedulingSlot, EventSchedulingSlotEntity>(slot);

                return adapter.DeleteEntity(entity);
            }
        }

        public void ReleaseAllTemporarySlotsPastExpiryTime()
        {
            var expressionbucket = new RelationPredicateBucket(EventSchedulingSlotFields.DateModified < DateTime.Now.AddMinutes(-1 * ExpiryTimeinMinutes));
            expressionbucket.PredicateExpression.AddWithAnd(EventSchedulingSlotFields.Status == (long)AppointmentStatus.TemporarilyBooked);

            var slots = Get(expressionbucket);

            if (!slots.Any()) return;

            ReleaseSlots(slots);
        }

        public void ReleaseSlots(IEnumerable<long> ids)
        {
            var slots = GetbyIds(ids);
            slots = slots.Where(s => s.Status == AppointmentStatus.TemporarilyBooked);

            if (!slots.Any()) return;

            ReleaseSlots(slots);
        }

        public void ReleaseBookedSlots(IEnumerable<long> ids)
        {
            var slots = GetbyIds(ids);
            slots = slots.Where(s => s.Status == AppointmentStatus.Booked);

            if (!slots.Any()) return;

            ReleaseSlots(slots);
        }

        private void ReleaseSlots(IEnumerable<EventSchedulingSlot> slots)
        {
            foreach (var eventSchedulingSlot in slots)
            {
                eventSchedulingSlot.Status = AppointmentStatus.Free;
                eventSchedulingSlot.DateModified = DateTime.Now;

                Save(eventSchedulingSlot);
            }
        }

        public TimeSpan? GetAppointmentTimeExpirationTime(long id)
        {
            if (id < 1) return null;

            try
            {
                var slot = GetbyId(id);
                if (slot != null && slot.Status == AppointmentStatus.TemporarilyBooked)
                {
                    var appointmentExpirationTime = slot.DateModified.AddMinutes(ExpiryTimeinMinutes);

                    if (DateTime.Now > appointmentExpirationTime)
                    {
                        return new TimeSpan(0, 0, 0);
                    }

                    return appointmentExpirationTime.Subtract(DateTime.Now);
                }
            }
            catch (ObjectNotFoundInPersistenceException<Appointment>)
            {
                return null;
            }
            return null;
        }

        public void ExtendTemporarilyBookAppointmentExpiryTime(long id)
        {
            var slotEntity = new EventSchedulingSlotEntity(id) { Status = Convert.ToInt32(AppointmentStatus.TemporarilyBooked), DateModified = DateTime.Now.AddMinutes(-5) };
            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(EventSchedulingSlotFields.SlotId == id);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(slotEntity, predicateBucket);
            }
        }

        public void DeleteByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<EventSchedulingSlotEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(EventSchedulingSlotFields.EventId == eventId));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);
            }
        }

        public void DeleteByEventPodRoomIds(IEnumerable<long> eventPodRoomIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<EventSchedulingSlotEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(EventSchedulingSlotFields.EventPodRoomId == eventPodRoomIds.ToArray()));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);
            }
        }

        public void SaveSlots(IEnumerable<EventSchedulingSlot> slots)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<EventSchedulingSlot>, IEnumerable<EventSchedulingSlotEntity>>(slots);

                var collection = new EntityCollection<EventSchedulingSlotEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);

            }
        }

    }
}