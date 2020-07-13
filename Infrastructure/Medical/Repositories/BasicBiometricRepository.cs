using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation(Interface = typeof(IBasicBiometricRepository))]
    public class BasicBiometricRepository : PersistenceRepository, IRepository<BasicBiometric>, IBasicBiometricRepository
    {
        public BasicBiometric Get(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.EventCustomerBasicBioMetric.Where(m => m.EventCustomerId == id && m.IsActive).SingleOrDefault();

                if (entity == null) return null;

                return AutoMapper.Mapper.Map<EventCustomerBasicBioMetricEntity, BasicBiometric>(entity);
            }
        }

        public IEnumerable<BasicBiometric> Get(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.EventCustomerBasicBioMetric.Where(m => ids.Contains(m.EventCustomerId) && m.IsActive).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<EventCustomerBasicBioMetricEntity>, IEnumerable<BasicBiometric>>(entities);
            }
        }

        private BasicBiometric GetActiveorDeactivate(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.EventCustomerBasicBioMetric.Where(m => m.EventCustomerId == id).SingleOrDefault();

                if (entity == null) return null;

                return AutoMapper.Mapper.Map<EventCustomerBasicBioMetricEntity, BasicBiometric>(entity);
            }
        }

        public BasicBiometric Get(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from bbm in linqMetaData.EventCustomerBasicBioMetric
                              join ec in linqMetaData.EventCustomers on bbm.EventCustomerId equals ec.EventCustomerId
                              where ec.EventId == eventId && ec.CustomerId == customerId && bbm.IsActive
                              select bbm).SingleOrDefault();

                if (entity == null) return null;

                return AutoMapper.Mapper.Map<EventCustomerBasicBioMetricEntity, BasicBiometric>(entity);
            }
        }

        public IEnumerable<BasicBiometric> GetAll(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from bbm in linqMetaData.EventCustomerBasicBioMetric
                              join ec in linqMetaData.EventCustomers on bbm.EventCustomerId equals ec.EventCustomerId
                              where ec.CustomerId == customerId && bbm.IsActive
                              select bbm).ToArray();

                if (entity.Count() < 1) return null;

                return AutoMapper.Mapper.Map<IEnumerable<EventCustomerBasicBioMetricEntity>, IEnumerable<BasicBiometric>>(entity);
            }
        }

        public BasicBiometric Save(BasicBiometric domainObject)
        {
            if (domainObject == null) return null;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<BasicBiometric, EventCustomerBasicBioMetricEntity>(domainObject);
                var alreadyInDb = GetActiveorDeactivate(domainObject.Id);

                entity.IsActive = true;
                entity.IsNew = alreadyInDb == null;

                if(!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
                
                return AutoMapper.Mapper.Map<EventCustomerBasicBioMetricEntity, BasicBiometric>(entity);
            }
        }

        public void Delete(BasicBiometric domainObject)
        {
            if (domainObject == null) return;
            Delete(domainObject.Id);
        }

        public void Delete(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var alreadyInDb = Get(eventId, customerId);
                if (alreadyInDb == null) return;

                adapter.UpdateEntitiesDirectly(new EventCustomerBasicBioMetricEntity { IsActive = false },
                                               new RelationPredicateBucket(
                                                   EventCustomerBasicBioMetricFields.EventCustomerId == alreadyInDb.Id));
            }
        }

        public void Delete(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var alreadyInDb = Get(id);
                if (alreadyInDb == null) return;

                adapter.UpdateEntitiesDirectly(new EventCustomerBasicBioMetricEntity {IsActive = false},
                                               new RelationPredicateBucket(
                                                   EventCustomerBasicBioMetricFields.EventCustomerId == id));
            }
        }

        public void Delete(IEnumerable<BasicBiometric> domainObjects)
        {
            if (domainObjects == null || domainObjects.Count() < 1)
                return;

            foreach (var basicBiometric in domainObjects)
            {
                Delete(basicBiometric);
            }
        }
    }
}