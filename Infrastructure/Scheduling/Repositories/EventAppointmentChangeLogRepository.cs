using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventAppointmentChangeLogRepository : PersistenceRepository, IEventAppointmentChangeLogRepository
    {
        public EventAppointmentChangeLog Save(EventAppointmentChangeLog domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventAppointmentChangeLog, EventAppointmentChangeLogEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EventAppointmentChangeLogEntity, EventAppointmentChangeLog>(entity);
            }
        }

        public IEnumerable<EventAppointmentChangeLog> GetRescheduledAppointment(int pageNumber, int pageSize, RescheduleApplointmentListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventAppointmentChangeLogEntity> entities;

                if (filter == null)
                {
                    filter = new RescheduleApplointmentListModelFilter { RescheduleFrom = DateTime.Now.Date.AddDays(-30), RescheduleTo = DateTime.Now.Date };
                }
                filter.RescheduleFrom = filter.RescheduleFrom.HasValue ? filter.RescheduleFrom.Value : DateTime.Now.Date.AddDays(-30);
                filter.RescheduleTo = filter.RescheduleTo.HasValue ? filter.RescheduleTo.Value : DateTime.Now.Date;

                var query = (from eacl in linqMetaData.EventAppointmentChangeLog select eacl);

                if (filter.CustomerId > 0)
                {
                    query = (from q in query
                             join ec in linqMetaData.EventCustomers on q.EventCustomerId equals ec.EventCustomerId
                             where ec.CustomerId == filter.CustomerId
                             select q);
                }
                else
                {
                    query = (from q in query
                             where q.DateCreated >= filter.RescheduleFrom.Value
                                   && q.DateCreated <= filter.RescheduleTo.Value.AddHours(23).AddMinutes(59)
                             select q);


                    //if (filter.EventFrom.HasValue || filter.EventTo.HasValue || !string.IsNullOrEmpty(filter.CustomerName))
                    //{
                    //    var queryForFilter = (from q in query
                    //                          join ec in linqMetaData.EventCustomers on q.EventCustomerId equals ec.EventCustomerId
                    //                          join e in linqMetaData.Events on ec.EventId equals e.EventId
                    //                          select new { q, ec, e });

                    //    if (filter.EventFrom.HasValue || filter.EventTo.HasValue)
                    //    {
                    //        if (filter.EventFrom.HasValue)
                    //        {
                    //            queryForFilter = (from q in queryForFilter where q.e.EventDate >= filter.EventFrom.Value select q);
                    //        }

                    //        if (filter.EventTo.HasValue)
                    //        {
                    //            queryForFilter = (from q in queryForFilter where q.e.EventDate <= filter.EventTo.Value select q);
                    //        }
                    //    }

                    //    if (!string.IsNullOrEmpty(filter.CustomerName))
                    //    {
                    //        queryForFilter = (from q in queryForFilter
                    //                          join oru in linqMetaData.OrganizationRoleUser on q.ec.CustomerId equals oru.OrganizationRoleUserId
                    //                          join u in linqMetaData.User on oru.UserId equals u.UserId
                    //                          where (u.FirstName + (u.MiddleName.Trim().Length > 0 ? (" " + u.MiddleName + " ") : " ") + u.LastName).Contains(filter.CustomerName)
                    //                          select q);
                    //    }

                    //    query = (from q in queryForFilter select q.q);
                    //}

                    if (filter.HospitalPartnerId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventHospitalPartner where ea.HospitalPartnerId == filter.HospitalPartnerId select ea.EventId);

                        query = (from q in query
                                 where (eventIds.Contains(q.OldEventId) || eventIds.Contains(q.NewEventId))
                                 select q);
                    }

                    if (filter.CorporateAccountId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.CorporateAccountId select ea.EventId);

                        query = (from q in query
                                 where (eventIds.Contains(q.OldEventId) || eventIds.Contains(q.NewEventId))
                                 select q);
                    }

                    if (!string.IsNullOrEmpty(filter.CustomerName))
                    {
                        query = (from q in query
                                 join ec in linqMetaData.EventCustomers on q.EventCustomerId equals ec.EventCustomerId
                                 join oru in linqMetaData.OrganizationRoleUser on ec.CustomerId equals oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where (u.FirstName + (u.MiddleName.Trim().Length > 0 ? (" " + u.MiddleName + " ") : " ") + u.LastName).Contains(filter.CustomerName)
                                 select q);
                    }


                    query = (from q in query orderby q.DateCreated descending select q);
                }

                totalRecords = query.Count();
                entities = query.TakePage(pageNumber, pageSize).ToList();

                return Mapper.Map<IEnumerable<EventAppointmentChangeLogEntity>, IEnumerable<EventAppointmentChangeLog>>(entities);
            }
        }

        public IEnumerable<EventAppointmentChangeLog> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from eacl in linqMetaData.EventAppointmentChangeLog
                                where eventCustomerIds.Contains(eacl.EventCustomerId)
                                select eacl).ToArray();
                return Mapper.Map<IEnumerable<EventAppointmentChangeLogEntity>, IEnumerable<EventAppointmentChangeLog>>(entities);
            }
        }

        public IEnumerable<long> GetEventCustomerIdByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from eacl in linqMetaData.EventAppointmentChangeLog
                        join ecl in linqMetaData.EventCustomers on eacl.EventCustomerId equals ecl.EventCustomerId
                        where eacl.OldEventId == eventId && eacl.NewEventId != eventId && ecl.EventId != eventId
                        select eacl.EventCustomerId).Distinct().ToArray();
            }
        }

        public List<OrderedPair<long, int>> GetCustomerMovedOutEventOnDayOfEvent(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from eacl in linqMetaData.EventAppointmentChangeLog
                                                        where eacl.OldEventId == e.EventId && eacl.DateCreated >= e.EventDate
                                                        select eacl.EventCustomerId).Count())).ToList();                             
            }
        }
    }
}
