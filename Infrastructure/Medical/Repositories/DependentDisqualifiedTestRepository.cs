using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    [DefaultImplementation]
    public class DependentDisqualifiedTestRepository : PersistenceRepository, IDependentDisqualifiedTestRepository
    {
        public IEnumerable<DependentDisqualifiedTest> GetAllByEventCustomerId(long customerId, long eventId, int version = 1)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.DependentDisqualifiedTest.Where(x => x.CustomerId == customerId && x.EventId == eventId && x.Version == version && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<DependentDisqualifiedTestEntity>, IEnumerable<DependentDisqualifiedTest>>(entities);
            }
        }

        public int GetLatestVersion(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from ecqa in linqMetaData.DependentDisqualifiedTest
                               where ecqa.CustomerId == customerId && ecqa.EventId == eventId
                               orderby ecqa.Version descending
                               select ecqa.Version).FirstOrDefault();

                return version;
            }
        }

        public void Save(IEnumerable<DependentDisqualifiedTest> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<DependentDisqualifiedTest>, IEnumerable<DependentDisqualifiedTestEntity>>(answers);
                var collection = new EntityCollection<DependentDisqualifiedTestEntity>();
                collection.AddRange(entities);
                if (adapter.SaveEntityCollection(collection) <= 0)
                {
                    throw new PersistenceFailureException();
                }

            }
        }

        public bool DeleteDependentDisqualifiedTests(long customerId, long eventId, long orgUserId)
        {
            var dependentDisqualifiedTestEntity = new DependentDisqualifiedTestEntity() { IsActive = false };
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(DependentDisqualifiedTestFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(DependentDisqualifiedTestFields.EventId == eventId);

                return (adapter.UpdateEntitiesDirectly(dependentDisqualifiedTestEntity, bucket) > 0) ? true : false;
            }
        }

        public IEnumerable<long> GetLatestVersionTestId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return linqMetaData.DependentDisqualifiedTest.Where(
                        x => x.CustomerId == customerId && x.EventId == eventId && x.IsActive)
                        .Select(x => x.TestId)
                        .ToArray();
            }
        }
        public bool DeleteDependentDisqualifiedTests(long customerId, long[] eventIds, long orgUserId)
        {
            var dependentDisqualifiedTestEntity = new DependentDisqualifiedTestEntity() { IsActive = false };
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(DependentDisqualifiedTestFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(DependentDisqualifiedTestFields.EventId == eventIds);

                return (adapter.UpdateEntitiesDirectly(dependentDisqualifiedTestEntity, bucket) > 0) ? true : false;
            }
        }
    }
}
