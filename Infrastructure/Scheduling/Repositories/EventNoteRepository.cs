using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventNoteRepository : PersistenceRepository, IEventNoteRepository
    {
        public EventNote GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from en in linqMetaData.EventNote where en.Id == id select en).SingleOrDefault();

                return entity == null ? null : Mapper.Map<EventNoteEntity, EventNote>(entity);
            }
        }

        public IEnumerable<EventNote> GetByIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from en in linqMetaData.EventNote where ids.Contains(en.Id) select en);

                return Mapper.Map<IEnumerable<EventNoteEntity>, IEnumerable<EventNote>>(entity);
            }
        }

        public IEnumerable<EventNote> GetByEventIds(long[] eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventNoteIds = (from enl in linqMetaData.EventNotesLog where eventIds.Contains(enl.EventId) select enl.EventNoteId).Distinct();

                var entity = (from en in linqMetaData.EventNote
                              where eventNoteIds.Contains(en.Id)
                              select en);

                return Mapper.Map<IEnumerable<EventNoteEntity>, IEnumerable<EventNote>>(entity);
            }
        }

        public IEnumerable<EventNotesLog> GetEventNoteLogByIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from enl in linqMetaData.EventNotesLog where ids.Contains(enl.EventNoteId) select enl);

                return Mapper.Map<IEnumerable<EventNotesLogEntity>, IEnumerable<EventNotesLog>>(entity);
            }
        }

        public IEnumerable<EventNotesLog> GetEventNoteLogByEventIds(long[] eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from enl in linqMetaData.EventNotesLog where eventIds.Contains(enl.EventId) select enl);

                return Mapper.Map<IEnumerable<EventNotesLogEntity>, IEnumerable<EventNotesLog>>(entity);
            }
        }

        public EventNote Save(EventNote domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventNote, EventNoteEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<EventNoteEntity, EventNote>(entity);
            }
        }

        public EventNotesLog SaveEventNotesLog(EventNotesLog domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventNotesLog, EventNotesLogEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<EventNotesLogEntity, EventNotesLog>(entity);
            }
        }

        public void DeleteEventNotesLog(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventNotesLogFields.EventNoteId == id);

                adapter.DeleteEntitiesDirectly(typeof(EventNotesLogEntity), relationPredicateBucket);
            }
        }

        public IEnumerable<EventNote> GetEventNotes(int pageNumber, int pageSize, EventNotesModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from en in linqMetaData.EventNote
                             select en);

                if (filter != null)
                {
                    if (filter.HealthPlanId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);
                        var eventNoteIds = (from enl in linqMetaData.EventNotesLog where eventIds.Contains(enl.EventId) select enl.EventNoteId);

                        query = (from q in query where eventNoteIds.Contains(q.Id) select q);
                    }
                    if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    {
                        var eventIds = (from e in linqMetaData.Events
                                        where (filter.FromDate.HasValue || e.EventDate >= filter.FromDate)
                                        && (filter.ToDate.HasValue || e.EventDate <= filter.ToDate)
                                        select e.EventId);
                        var eventNoteIds = (from enl in linqMetaData.EventNotesLog where eventIds.Contains(enl.EventId) select enl.EventNoteId);

                        query = (from q in query where eventNoteIds.Contains(q.Id) select q);
                    }
                    if (filter.PodId > 0)
                    {
                        var eventIds = (from e in linqMetaData.Events
                                        join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                        join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                        where p.PodId == filter.PodId
                                        select e.EventId);
                        var eventNoteIds = (from enl in linqMetaData.EventNotesLog where eventIds.Contains(enl.EventId) select enl.EventNoteId);

                        query = (from q in query where eventNoteIds.Contains(q.Id) select q);
                    }
                }

                totalRecords = query.Count();

                var finalQuery = query.OrderByDescending(x => x.DateCreated).TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<EventNoteEntity>, IEnumerable<EventNote>>(finalQuery);
            }
        }
    }
}
