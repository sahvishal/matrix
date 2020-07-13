using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.Data.Linq;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class PackageRepository : UniqueItemRepository<Package, PackageEntity>, IPackageRepository
    {
        public PackageRepository()
            : base(new PackageMapper(new TestMapper()))
        { }


        protected override EntityField2 EntityIdField
        {
            get { return PackageFields.PackageId; }
        }

        public IEnumerable<Package> Get(PackageListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    totalRecords = linqMetaData.Package.Count();
                    var entities = linqMetaData.Package.OrderByDescending(p => p.IsActive).OrderBy(p => p.PackageName).TakePage(pageNumber, pageSize).ToArray();

                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    var query = from p in linqMetaData.Package where ((filter.Active ? p.IsActive : true) && (filter.Inactive ? !p.IsActive : true)) select p;
                    if (!string.IsNullOrEmpty(filter.Name))
                        query = from p in query where p.PackageName.Contains(filter.Name) select p;

                    if (filter.PackageType > 0)
                    {
                        query = from p in query where p.PackageTypeId == filter.PackageType select p;
                    }

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.IsActive).OrderBy(p => p.PackageName).TakePage(pageNumber, pageSize).ToArray();

                    return Mapper.MapMultiple(entities);
                }
            }
        }

        public List<Package> GetAll()
        {//Its nothing more than All Open Packages which are currently being offered in Events.
            var packageEntities = GetAllOpenPackageEntities();
            return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                .ToList();
        }

        public Package GetByName(string packageName)
        {
            return GetByPredicate(new PredicateExpression(PackageFields.PackageName == packageName)).SingleOrDefault();
        }

        public List<Package> GetCorporatePackages()
        {
            List<PackageEntity> packageEntities = GetAllOpenPackageEntities().Where(pck => pck.PackageTypeId == (long)PackageType.Corporate).ToList();
            return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                .ToList();

        }

        public List<OrderedPair<string, int>> GetPackageCustomerCountForEvent(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var packageCustomerCount = from ec in linqMetaData.EventCustomers
                                           join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId
                                               equals ecod.EventCustomerId
                                           join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals
                                               od.OrderDetailId
                                           join epoi in linqMetaData.EventPackageOrderItem on od.OrderItemId equals
                                               epoi.OrderItemId
                                           join epd in linqMetaData.EventPackageDetails on epoi.EventPackageId equals
                                               epd.EventPackageId
                                           join p in linqMetaData.Package on epd.PackageId equals p.PackageId
                                           where ec.AppointmentId.HasValue && ecod.IsActive &&
                                                 ec.EventId == eventId
                                           group p by p.PackageName
                                               into packageGroup
                                               select
                                               new OrderedPair<string, int>(packageGroup.Key, packageGroup.Count());

                return packageCustomerCount.ToList();
            }
        }

        public new Package GetById(long packageId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var packageEntity = linqMetaData.Package.
                    WithPath(prefetchPath => prefetchPath.
                                                 Prefetch(package => package.TestCollectionViaPackageTest)).
                    Where(package => package.PackageId == packageId).FirstOrDefault();

                if (packageEntity == null)
                {
                    throw new ObjectNotFoundInPersistenceException<Package>(packageId);
                }

                //var tests = linqMetaData.Test.Where(test => packageEntity.TestCollectionViaPackageTest.Select(t => t.TestId).Contains(test.TestId));

                //foreach (var testPrice in packageEntity.TestPriceCollectionViaPackageTest)
                //{
                //    testPrice.Test = tests.Where(test => test.TestId == testPrice.TestId).
                //        SingleOrDefault();
                //}

                return Mapper.Map(packageEntity);
            }
        }

        public new IEnumerable<Package> GetByIds(IEnumerable<long> packageIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var packageEntities = linqMetaData.Package.
                    WithPath(prefetchPath => prefetchPath.
                                                 Prefetch(package => package.TestCollectionViaPackageTest)).
                    Where(package => packageIds.Contains(package.PackageId)).ToArray();

                if (packageEntities.Count() < 1)
                {
                    return null;
                }

                //var tests = linqMetaData.Test.Where(test => packageEntities.SelectMany(p => p.TestPriceCollectionViaPackageTest.Select(t => t.TestId)).Contains(test.TestId)).Distinct().ToArray();

                //foreach (var package in packageEntities)
                //{
                //    foreach (var testPrice in package.TestPriceCollectionViaPackageTest)
                //    {
                //        testPrice.Test = tests.Where(test => test.TestId == testPrice.TestId).
                //            SingleOrDefault();
                //    }
                //}

                return Mapper.MapMultiple(packageEntities);
            }
        }

        private IEnumerable<PackageEntity> GetAllOpenPackageEntities()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                IEnumerable<PackageEntity> packageEntities = linqMetaData.Package.
                    WithPath(prefetchPath => prefetchPath.
                                                 Prefetch(package => package.TestCollectionViaPackageTest)).
                    Where(package => package.IsActive).ToArray();

                //var testIds =
                //    packageEntities.SelectMany(p => p.TestPriceCollectionViaPackageTest.Select(t => t.TestId).ToArray())
                //        .Distinct();

                //var tests = linqMetaData.Test.Where(t => testIds.Contains(t.TestId)).ToArray();

                //foreach (var package in packageEntities)
                //{
                //    foreach (var testPrice in package.TestPriceCollectionViaPackageTest)
                //    {
                //        TestPriceEntity entity = testPrice;
                //        testPrice.Test = tests.Where(test => test.TestId == entity.TestId).SingleOrDefault();
                //    }
                //}
                return packageEntities;
            }
        }

        public IEnumerable<Package> GetPackagesByAccount(long accountId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);


                var packageEntities = (from pck in linqMetaData.Package
                                       join ac in linqMetaData.AccountPackage on pck.PackageId equals ac.PackageId
                                       where ac.AccountId == accountId
                                       select pck).ToList();

                return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                    .ToList();

            }
        }

        public IEnumerable<Package> GetPackagesByHospitalPartner(long hospitalPartnerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);


                var packageEntities = (from pck in linqMetaData.Package
                                       join hp in linqMetaData.HospitalPartnerPackage on pck.PackageId equals hp.PackageId
                                       where hp.HospitalpartnerId == hospitalPartnerId
                                       select pck).ToList();

                return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                    .ToList();

            }
        }

        public IEnumerable<Package> GetPackagesByTerritory(long territoryId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);


                var packageEntities = (from pck in linqMetaData.Package
                                       join tp in linqMetaData.TerritoryPackage on pck.PackageId equals tp.PackageId
                                       where tp.TerritoryId == territoryId
                                       select pck).Distinct().ToList();

                return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                    .ToList();

            }
        }

        public IEnumerable<Package> GetPackagesByEventType(EventType eventType)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                long packageTypeId = 0;
                if (eventType == EventType.Retail)
                    packageTypeId = (long)PackageType.Retail;
                else if (eventType == EventType.Corporate)
                    packageTypeId = (long)PackageType.Corporate;

                var linqMetaData = new LinqMetaData(myAdapter);

                var packageEntities =
                    linqMetaData.Package.Where(pck => pck.PackageTypeId == packageTypeId && (pck.IsActive));
                return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                    .ToArray();
            }
        }

        public IEnumerable<Package> GetAllOpenPackages()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var packageEntities =
                    linqMetaData.Package.Where(pck => (pck.IsActive));
                return Mapper.MapMultiple(packageEntities.OrderBy(package => package.RelativeOrder))
                    .ToArray();
            }
        }

        public IEnumerable<long> GetRoleswithGivenPackageAvailability(long packageId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.PackageAvailabilityToRoles.Where(pa => pa.PackageId == packageId).Select(pa => pa.RoleId).ToArray();
            }
        }

        public void SaveRolesforGivenPackageAvailability(long packageId, IEnumerable<long> roleIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("PackageAvailabilityToRolesEntity", new RelationPredicateBucket(PackageAvailabilityToRolesFields.PackageId == packageId));
                if (roleIds == null || roleIds.Count() < 1) return;
                var roles = roleIds.Select(roleId => new PackageAvailabilityToRolesEntity { RoleId = roleId, PackageId = packageId }).ToArray();
                var entityCollection = new EntityCollection<PackageAvailabilityToRolesEntity>();
                entityCollection.AddRange(roles);

                adapter.SaveEntityCollection(entityCollection);
            }
        }

        public void SetPackageIsActiveState(long packageId, bool isActive)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new PackageEntity { IsActive = isActive },
                                               new RelationPredicateBucket(PackageFields.PackageId == packageId));
            }
        }


        public IEnumerable<Package> GetPackagesByHealthPlanId(long healthPlanId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var packageEntities = (from pck in linqMetaData.Package
                                       join ap in linqMetaData.AccountPackage on pck.PackageId equals ap.PackageId
                                       where pck.IsActive && ap.AccountId == healthPlanId
                                       orderby pck.PackageId
                                       select pck);

                return Mapper.MapMultiple(packageEntities).ToArray();
            }
        }
    }
}
