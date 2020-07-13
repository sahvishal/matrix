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
    public class PcpDispositionRepository : PersistenceRepository, IPcpDispositionRepository
    {
        public void Save(PcpDisposition pcpAppointment)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PcpDisposition, PcpDispositionEntity>(pcpAppointment);

                adapter.SaveEntity(entity, true);
            }
        }

        public IEnumerable<PcpDisposition> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pa in linqMetaData.PcpDisposition where pa.EventCustomerId == eventCustomerId select pa);

                return Mapper.Map<IEnumerable<PcpDispositionEntity>, IEnumerable<PcpDisposition>>(entities);
            }
        }

        public IEnumerable<PcpDisposition> GetByCustomerIdEventId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pa in linqMetaData.PcpDisposition
                              join ec in linqMetaData.EventCustomers on pa.EventCustomerId equals ec.EventCustomerId
                              where ec.EventId == eventId && ec.CustomerId == customerId
                              select pa);

                return Mapper.Map<IEnumerable<PcpDispositionEntity>, IEnumerable<PcpDisposition>>(entities);
            }
        }

        public IEnumerable<PcpDisposition> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pa in linqMetaData.PcpDisposition where eventCustomerIds.Contains(pa.EventCustomerId) select pa);

                return Mapper.Map<IEnumerable<PcpDispositionEntity>, IEnumerable<PcpDisposition>>(entities);
            }
        }
    }
}