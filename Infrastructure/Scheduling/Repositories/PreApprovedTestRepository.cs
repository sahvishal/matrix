using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
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
    public class PreApprovedTestRepository : PersistenceRepository, IPreApprovedTestRepository
    {
        public IEnumerable<PreApprovedTest> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from pat in linqMetaData.PreApprovedTest where pat.IsActive && pat.CustomerId == customerId select pat).ToArray();

                return Mapper.Map<IEnumerable<PreApprovedTestEntity>, IEnumerable<PreApprovedTest>>(enetities);
            }
        }

        public void SavePreApprovedTests(long customerId, IEnumerable<long> testIds, long createdByOrgRoleUserId)
        {
            DeactivePreApprovedTests(customerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<PreApprovedTestEntity>();
                foreach (var testId in testIds)
                {
                    entities.Add(new PreApprovedTestEntity
                    {
                        CustomerId = customerId,
                        TestId = testId,
                        DateCreated = DateTime.Now,
                        CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                        IsActive = true,
                        IsNew = true
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        private void DeactivePreApprovedTests(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = new PreApprovedTestEntity()
                {
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(PreApprovedTestFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(PreApprovedTestFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetPreApprovedTests(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pat in linqMetaData.PreApprovedTest
                        join t in linqMetaData.Test on pat.TestId equals t.TestId
                        where pat.IsActive && customerIds.Contains(pat.CustomerId)
                        select new OrderedPair<long, string>(pat.CustomerId, t.Name)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetPreApprovedTestIdsByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pat in linqMetaData.PreApprovedTest
                        where pat.IsActive && customerIds.Contains(pat.CustomerId)
                        select new OrderedPair<long, long>(pat.CustomerId, pat.TestId)).ToArray();
            }
        }

        public bool CheckPreApprovedTestForCustomer(long customerId, IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var preApprovedTests = (from pat in linqMetaData.PreApprovedTest
                                        where pat.CustomerId == customerId && pat.IsActive
                                        && testIds.Contains(pat.TestId)
                                        select pat).ToArray();

                if (preApprovedTests.Any()) return true;

                var preApprovedPackage = (from pap in linqMetaData.PreApprovedPackage
                                          join pt in linqMetaData.PackageTest on pap.PackageId equals pt.PackageId
                                          where pap.CustomerId == customerId && pap.IsActive
                                          && testIds.Contains(pt.TestId)
                                          select pap).ToArray();

                if (preApprovedPackage.Any()) return true;

                return false;
            }
        }

        public IEnumerable<string> GetPreApprovedTests(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pat in linqMetaData.PreApprovedTest
                        join t in linqMetaData.Test on pat.TestId equals t.TestId
                        where pat.IsActive && pat.CustomerId == customerId
                        select t.Name).ToArray();
            }
        }
    }
}
