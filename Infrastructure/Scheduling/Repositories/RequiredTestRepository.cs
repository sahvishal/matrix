using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class RequiredTestRepository : PersistenceRepository, IRequiredTestRepository
    {
        public IEnumerable<RequiredTest> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from rt in linqMetaData.RequiredTest where rt.IsActive && rt.CustomerId == customerId select rt).ToArray();

                return Mapper.Map<IEnumerable<RequiredTestEntity>, IEnumerable<RequiredTest>>(enetities);
            }
        }

        public void SaveRequiredTests(long customerId, IEnumerable<long> testIds, long createdByOrgRoleUserId, int forYear)
        {
            DeactiveRequiredTests(customerId, forYear);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<RequiredTestEntity>();
                foreach (var testId in testIds)
                {
                    entities.Add(new RequiredTestEntity
                    {
                        CustomerId = customerId,
                        TestId = testId,
                        CreatedDate = DateTime.Now,
                        CreatedBy = createdByOrgRoleUserId,
                        IsActive = true,
                        ForYear = forYear,
                        IsNew = true
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        private void DeactiveRequiredTests(long customerId, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = new RequiredTestEntity()
                {
                    IsActive = false,
                    EndDate = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(RequiredTestFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(RequiredTestFields.IsActive == true);
                bucket.PredicateExpression.AddWithAnd(RequiredTestFields.ForYear == forYear);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public bool IsRequiredTestAvailble(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var year = DateTime.Today.Year;
                var requiredTest = (from rt in linqMetaData.RequiredTest
                                    where rt.CustomerId == customerId && rt.IsActive
                                    && rt.ForYear >= year
                                    select rt).ToArray();
                if (requiredTest.Any()) return true;
            }
            return false;
        }
        public IEnumerable<string> GetRequiredTests(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from rt in linqMetaData.RequiredTest
                        join t in linqMetaData.Test on rt.TestId equals t.TestId
                        where rt.IsActive && rt.CustomerId == customerId
                        select t.Name).Distinct().ToArray();
            }
        }

        public IEnumerable<RequiredTest> GetByRequiredTestByCustomerIdAndYear(long customerId, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from rt in linqMetaData.RequiredTest where rt.IsActive && rt.CustomerId == customerId && rt.ForYear == forYear select rt).ToArray();

                return Mapper.Map<IEnumerable<RequiredTestEntity>, IEnumerable<RequiredTest>>(enetities);
            }
        }

    }
}
