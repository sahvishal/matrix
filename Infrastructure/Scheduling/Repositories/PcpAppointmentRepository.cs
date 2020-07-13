using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class PcpAppointmentRepository : PersistenceRepository, IPcpAppointmentRepository
    {
        public void Save(PcpAppointment pcpAppointment)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var inPersistence = (from pa in linqMetaData.PcpAppointment where pa.EventCustomerId == pcpAppointment.EventCustomerId select pa).SingleOrDefault();
                var entity = Mapper.Map<PcpAppointment, PcpAppointmentEntity>(pcpAppointment);
                entity.IsNew = inPersistence == null;

                adapter.SaveEntity(entity, true);
            }
        }

        public PcpAppointment GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from pa in linqMetaData.PcpAppointment where pa.EventCustomerId == eventCustomerId select pa).SingleOrDefault();

                return Mapper.Map<PcpAppointmentEntity, PcpAppointment>(entity);
            }
        }

        public PcpAppointment GetByCustomerIdEventId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from pa in linqMetaData.PcpAppointment
                              join ec in linqMetaData.EventCustomers on pa.EventCustomerId equals ec.EventCustomerId
                              where ec.EventId == eventId && ec.CustomerId == customerId
                              select pa).SingleOrDefault();

                return Mapper.Map<PcpAppointmentEntity, PcpAppointment>(entity);
            }
        }

        public IEnumerable<PcpAppointment> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pa in linqMetaData.PcpAppointment where eventCustomerIds.Contains(pa.EventCustomerId) select pa).ToArray();

                return Mapper.Map<IEnumerable<PcpAppointmentEntity>, IEnumerable<PcpAppointment>>(entities);
            }
        }

        public void DeleteAppointmentForEventCustomers(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(PcpAppointmentFields.EventCustomerId == eventCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(PcpAppointmentEntity), bucket);
            }
        }
    }
}
