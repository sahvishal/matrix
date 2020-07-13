using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventAppointmentCancellationLogRepository : PersistenceRepository, IEventAppointmentCancellationLogRepository
    {
        public EventAppointmentCancellationLog Save(EventAppointmentCancellationLog domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventAppointmentCancellationLog, EventAppointmentCancellationLogEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EventAppointmentCancellationLogEntity, EventAppointmentCancellationLog>(entity);
            }
        }

        public IEnumerable<EventAppointmentCancellationLog> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from eacl in linqMetaData.EventAppointmentCancellationLog
                                where eventCustomerIds.Contains(eacl.EventCustomerId)
                                select eacl).ToArray();

                return Mapper.Map<IEnumerable<EventAppointmentCancellationLogEntity>, IEnumerable<EventAppointmentCancellationLog>>(entities);
            }
        }

        public IEnumerable<EventAppointmentCancellationLog> GetByEventIdCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from eacl in linqMetaData.EventAppointmentCancellationLog
                                join ec in linqMetaData.EventCustomers on eacl.EventCustomerId equals ec.EventCustomerId
                                where ec.EventId == eventId && ec.CustomerId == customerId
                                select eacl);


                return Mapper.Map<IEnumerable<EventAppointmentCancellationLogEntity>, IEnumerable<EventAppointmentCancellationLog>>(entities);
            }
        }

        public IEnumerable<EventAppointmentCancellationLog> GetCancellationByCusomerIds(IEnumerable<long> customerIds, DateTime cancellationDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from eacl in linqMetaData.EventAppointmentCancellationLog
                                join ec in linqMetaData.EventCustomers on eacl.EventCustomerId equals ec.EventCustomerId
                                where customerIds.Contains(ec.CustomerId) && eacl.DateCreated > cancellationDate
                                select eacl).ToArray();

                return Mapper.Map<IEnumerable<EventAppointmentCancellationLogEntity>, IEnumerable<EventAppointmentCancellationLog>>(entities);
            }
        }
    }
}