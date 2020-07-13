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
    public class PreApprovedPackageRepository : PersistenceRepository, IPreApprovedPackageRepository
    {
        public IEnumerable<PreApprovedPackage> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from pat in linqMetaData.PreApprovedPackage where pat.IsActive && pat.CustomerId == customerId select pat).ToArray();

                return Mapper.Map<IEnumerable<PreApprovedPackageEntity>, IEnumerable<PreApprovedPackage>>(enetities);
            }
        }

        public void SavePreApprovedPackages(long customerId, long packageId, long createdByOrgRoleUserId)
        {
            DeactivePreApprovedPackages(customerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var newEntity = new PreApprovedPackageEntity
                {
                    PackageId = packageId,
                    CustomerId = customerId,
                    DateCreated = DateTime.Now,
                    CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                    IsActive = true,
                    IsNew = true
                };
                if (!adapter.SaveEntity(newEntity))
                {
                    throw new PersistenceFailureException();
                }

            }
        }

        private void DeactivePreApprovedPackages(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new PreApprovedPackageEntity()
                {
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(PreApprovedPackageFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(PreApprovedPackageFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public long CheckPreApprovedPackages(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var preApprovedPackage = (from pap in linqMetaData.PreApprovedPackage
                                          where pap.CustomerId == customerId && pap.IsActive
                                          select pap).SingleOrDefault();
                if (preApprovedPackage == null)
                    return 0;

                return preApprovedPackage.PackageId;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetByCustomerIds(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pap in linqMetaData.PreApprovedPackage
                        join p in linqMetaData.Package on pap.PackageId equals p.PackageId
                        where pap.IsActive && customerIds.Contains(pap.CustomerId)
                        select new OrderedPair<long, string>(pap.CustomerId, p.PackageName)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetIdByCustomerIds(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pat in linqMetaData.PreApprovedPackage
                        join p in linqMetaData.Package on pat.PackageId equals p.PackageId
                        where pat.IsActive && customerIds.Contains(pat.CustomerId)
                        select new OrderedPair<long, long>(pat.CustomerId, p.PackageId)).ToArray();
            }
        }
        public IEnumerable<OrderedPair<long, string>> GetPreApprovedPackageTestByCustomerIds(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pap in linqMetaData.PreApprovedPackage
                        join p in linqMetaData.PackageTest on pap.PackageId equals p.PackageId
                        join t in linqMetaData.Test on p.TestId equals t.TestId
                        where pap.IsActive && customerIds.Contains(pap.CustomerId)
                        select new OrderedPair<long, string>(pap.CustomerId, t.Name)).ToArray();
            }
        }
        public IEnumerable<string> GetPreApprovedPackageTest(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from pap in linqMetaData.PreApprovedPackage
                        join p in linqMetaData.PackageTest on pap.PackageId equals p.PackageId
                        join t in linqMetaData.Test on p.TestId equals t.TestId
                        where pap.IsActive && pap.CustomerId==customerId
                        select  t.Name).ToArray();
            }
        }
    }
}