using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using FluentValidation;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{

    public class EventStaffAssignmentRepository : PersistenceRepository, IRepository<EventStaffAssignment>, IEventStaffAssignmentRepository
    {

        private readonly IValidator<EventStaffAssignment> _validator;

        public EventStaffAssignmentRepository(IPersistenceLayer persistenceLayer, IValidator<EventStaffAssignment> validator)
            : base(persistenceLayer)
        {
            _validator = validator;
        }


        public EventStaffAssignment Save(EventStaffAssignment domainObject)
        {
            _validator.ValidateAndThrow(domainObject);

            var eventStaffAssignmentEntity = Mapper.Map<EventStaffAssignment, EventStaffAssignmentEntity>(domainObject);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(eventStaffAssignmentEntity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
            return Mapper.Map<EventStaffAssignmentEntity, EventStaffAssignment>(eventStaffAssignmentEntity);
        }



        public void Delete(EventStaffAssignment domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<EventStaffAssignment> domainObjects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventStaffAssignment> GetForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeta = new LinqMetaData(adapter);
                var eventStaffAssignmentEntities = linqMeta.EventStaffAssignment.Where(esa => esa.IsActive && esa.EventId == eventId).ToList();
                var eventStaffAssignments = Mapper.Map<IEnumerable<EventStaffAssignmentEntity>, IEnumerable<EventStaffAssignment>>(eventStaffAssignmentEntities);
                return eventStaffAssignments;
            }

        }

        public IEnumerable<long> GetTechblockedforSomeotherEventonthesameDayofGivenEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventDate = linqMetaData.Events.Where(se => se.EventId == eventId).Single().EventDate;
                var eventsOnSameDay = linqMetaData.Events.Where(e => e.EventId != eventId && e.EventDate == eventDate && e.IsActive
                                                                    && e.EventStatus == (long)EventStatus.Active).Select(e => e.EventId).ToArray();

                return (from p in linqMetaData.PodDefaultTeam
                        join ep in linqMetaData.EventPod on p.PodId equals ep.PodId
                        join esa in linqMetaData.EventStaffAssignment on ep.EventId equals esa.EventId
                            into queryableStaff
                        from qs in queryableStaff.DefaultIfEmpty()
                        where eventsOnSameDay.Contains(ep.EventId)
                        select
                             ((qs.ActualStaffOrgRoleUserId == null && qs.ScheduledStaffOrgRoleUserId == null)
                                 ? p.OrgnizationRoleUserId
                                 : (qs.ActualStaffOrgRoleUserId ?? qs.ScheduledStaffOrgRoleUserId))).Distinct().ToArray();

            }
        }

        public void DeleteFor(long eventId)
        {

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(EventStaffAssignmentFields.EventId == eventId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.DeleteEntitiesDirectly(typeof(EventStaffAssignmentEntity), predicateBucket); //just delete anything that exists.
            }

        }

        public void DeleteFor(long eventId, long podId)
        {

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(EventStaffAssignmentFields.EventId == eventId);
            predicateBucket.PredicateExpression.AddWithAnd(EventStaffAssignmentFields.PodId == podId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.DeleteEntitiesDirectly(typeof(EventStaffAssignmentEntity), predicateBucket); //just delete anything that exists.
            }

        }

        public bool IsTechnicianAssignedForFutureEvent(long technicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from esa in linqMetaData.EventStaffAssignment
                        join e in linqMetaData.Events on esa.EventId equals e.EventId
                        where esa.IsActive
                              && (esa.ActualStaffOrgRoleUserId.HasValue
                                      ? esa.ActualStaffOrgRoleUserId.Value
                                      : esa.ScheduledStaffOrgRoleUserId) == technicianId
                              && e.EventDate > DateTime.Today.AddDays(-1)
                        select esa).Any();
            }
        }

        public IEnumerable<EventStaffAssignment> GetForEvents(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeta = new LinqMetaData(adapter);
                var eventStaffAssignmentEntities =
                    (from esa in linqMeta.EventStaffAssignment
                     where esa.IsActive && eventIds.Contains(esa.EventId)
                     select esa).ToArray();

                var eventStaffAssignments = Mapper.Map<IEnumerable<EventStaffAssignmentEntity>, IEnumerable<EventStaffAssignment>>(eventStaffAssignmentEntities);
                return eventStaffAssignments;
            }

        }
    }
}