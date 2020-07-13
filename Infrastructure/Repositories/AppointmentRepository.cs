using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class AppointmentRepository : PersistenceRepository, IAppointmentRepository
    {
        private readonly IMapper<Appointment, EventAppointmentEntity> _mapper;

        public AppointmentRepository()
            : this(new AppointmentMapper())
        { }

        public AppointmentRepository(IMapper<Appointment, EventAppointmentEntity> mapper)
        {
            _mapper = mapper;
        }

        public Appointment GetById(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(EventAppointmentFields.AppointmentId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<Appointment>(id);
            }
        }

        public IEnumerable<Appointment> GetByIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(EventAppointmentFields.AppointmentId == ids.ToArray()));
        }

        private IEnumerable<Appointment> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var appointmentEntities = new EntityCollection<EventAppointmentEntity>();

                var prefetchPath = new PrefetchPath2(EntityType.EventAppointmentEntity) { EventAppointmentEntity.PrefetchPathEventSlotAppointment };

                adapter.FetchEntityCollection(appointmentEntities, expressionBucket, prefetchPath);

                var appointments = _mapper.MapMultiple(appointmentEntities);

                return appointments.OrderBy(es => es.StartTime).ToArray();
            }
        }

        public IEnumerable<Appointment> GetAllAppointmentsForEvent(long eventId)
        {
            return Get(new RelationPredicateBucket(EventAppointmentFields.EventId == eventId));
        }

        public IEnumerable<Appointment> GetAppointmentsForEvents(IEnumerable<long> eventIds)
        {
            return Get(new RelationPredicateBucket(EventAppointmentFields.EventId == eventIds.ToArray())).OrderBy(a => a.EventId).OrderBy(a => a.StartTime);
        }

        public Appointment Save(Appointment domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    if (domainObject.SlotIds.IsNullOrEmpty()) throw new InvalidOperationException("No Slots attached.");

                    if (domainObject.Id > 0)
                    {
                        var inDb = this.GetById(domainObject.Id);

                        if (!inDb.SlotIds.IsNullOrEmpty())
                        {
                            adapter.DeleteEntitiesDirectly(typeof(EventSlotAppointmentEntity), new RelationPredicateBucket(EventSlotAppointmentFields.SlotId == inDb.SlotIds.ToArray()));
                        }
                    }

                    var entity = _mapper.Map(domainObject);
                    entity.EventSlotAppointment.AddRange(domainObject.SlotIds.Select(s => new EventSlotAppointmentEntity(s)));

                    if (!adapter.SaveEntity(entity, true, true))
                    {
                        throw new PersistenceFailureException();
                    }

                    scope.Complete();
                    return _mapper.Map(entity);
                }
            }
        }

        public void Delete(Appointment domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    adapter.DeleteEntitiesDirectly(typeof(EventSlotAppointmentEntity), new RelationPredicateBucket(EventSlotAppointmentFields.AppointmentId == domainObject.Id));

                    adapter.DeleteEntitiesDirectly(typeof(EventAppointmentEntity), new RelationPredicateBucket(EventAppointmentFields.AppointmentId == domainObject.Id));

                    scope.Complete();
                }
            }
        }

        public void Delete(IEnumerable<Appointment> domainObjects)
        {
            foreach (var domainObject in domainObjects)
            {
                Delete(domainObject);
            }
        }

        public IEnumerable<Appointment> GetBlockedAppointmentsForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var appointments = from ea in linqMetaData.EventAppointment
                                   where
                                       (ea.ScheduledByOrgRoleUserId.HasValue && ea.ScheduledByOrgRoleUserId.Value > 0) &&
                                       ea.EventId == eventId
                                   select ea;

                var bookedAppointments = from ec in linqMetaData.EventCustomers
                                         where ec.AppointmentId.HasValue && ec.EventId == eventId
                                         select ec.AppointmentId;

                var blockedAppointments =
                    appointments.Where(a => !bookedAppointments.Contains(a.AppointmentId)).ToList();

                return _mapper.MapMultiple(blockedAppointments);
            }
        }

        public Appointment GetEventCustomerAppointment(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventAppointmentEntity = (from ea in linqMetaData.EventAppointment
                                              join ec in linqMetaData.EventCustomers on ea.AppointmentId equals
                                                  ec.AppointmentId
                                              where
                                                  ec.AppointmentId.HasValue && ec.EventId == eventId &&
                                                  ec.CustomerId == customerId
                                              select ea).SingleOrDefault();

                if (eventAppointmentEntity == null) return null;
                return _mapper.Map(eventAppointmentEntity);
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetBookedAppointmentCount(long[] eventIds)
        {
            
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        where eventIds.Contains(ec.EventId) 
                        group ec by ec.EventId
                            into bookedAppointment
                            select new OrderedPair<long, int>(bookedAppointment.Key, bookedAppointment.Count())).ToArray();

            }
        }

    }
}
