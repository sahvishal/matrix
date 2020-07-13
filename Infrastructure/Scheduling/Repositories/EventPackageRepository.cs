using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    public class EventPackageRepository : PersistenceRepository, IEventPackageRepository
    {
        private IMapper<EventPackage, EventPackageDetailsEntity> _mapper;
        private IMapper<Package, PackageEntity> _packageMapper;
        private IEventTestRepository _eventTestRepository;
        private readonly ISettings _settings;

        public EventPackageRepository()
            : this(new EventPackageMapper(), new PackageMapper(new TestMapper()), new EventTestRepository(), new Settings())
        { }

        public EventPackageRepository(IMapper<EventPackage, EventPackageDetailsEntity> mapper, IMapper<Package, PackageEntity> packageMapper,
                                        IEventTestRepository eventTestRepository, ISettings settings)
        {
            _mapper = mapper;
            _packageMapper = packageMapper;
            _eventTestRepository = eventTestRepository;
            _settings = settings;
        }

        public EventPackage GetById(long id)
        {
            return Get(new RelationPredicateBucket(EventPackageDetailsFields.EventPackageId == id)).SingleOrDefault();
        }

        public IEnumerable<EventPackage> GetByIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(EventPackageDetailsFields.EventPackageId == ids.ToArray())).ToArray();
        }

        public EventPackage GetByEventAndPackageIds(long eventId, long packageId)
        {
            var expression = new RelationPredicateBucket(EventPackageDetailsFields.EventId == eventId);
            expression.PredicateExpression.AddWithAnd(EventPackageDetailsFields.PackageId == packageId);
            return Get(expression).SingleOrDefault();
        }

        public IEnumerable<EventPackage> GetPackagesForEventByRole(long eventId, long roleId, long gender = (long)Gender.Unspecified)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var packages = GetPackagesForEvent(eventId, gender);
                var packageIds = packages.Select(p => p.PackageId).ToArray();

                if (roleId == (long)Roles.Customer)
                {
                    packageIds = (from p in linqMetaData.Package
                                  join pt in linqMetaData.PackageAvailabilityToRoles on p.PackageId equals pt.PackageId
                                  where pt.RoleId == roleId && p.DescriptiononPublicWebsite
                                  && packageIds.Contains(pt.PackageId)
                                  select pt.PackageId).Distinct().ToArray();

                    return packages.Where(p => packageIds.Contains(p.PackageId) && p.AvailableThroughOnline).ToArray();
                }

                var parentRoleId = linqMetaData.Role.Where(r => r.RoleId == roleId && r.IsActive).Select(r => r.ParentId).SingleOrDefault();

                if (parentRoleId.HasValue)
                    packageIds = linqMetaData.PackageAvailabilityToRoles.Where(pa => (pa.RoleId == roleId || pa.RoleId == parentRoleId.Value) && packageIds.Contains(pa.PackageId)).Select(pa => pa.PackageId).Distinct().ToArray();
                else
                    packageIds = linqMetaData.PackageAvailabilityToRoles.Where(pa => pa.RoleId == roleId && packageIds.Contains(pa.PackageId)).Select(pa => pa.PackageId).Distinct().ToArray();

                if (roleId == (long)Roles.CallCenterRep || parentRoleId == (long)Roles.CallCenterRep)
                    return packages.Where(p => packageIds.Contains(p.PackageId) && p.AvailableThroughCallCenter).ToArray();

                if (roleId == (long)Roles.Technician || parentRoleId == (long)Roles.Technician)
                    return packages.Where(p => packageIds.Contains(p.PackageId) && p.AvailableThroughTechnician).ToArray();

                if (roleId == (long)Roles.FranchisorAdmin || parentRoleId == (long)Roles.FranchisorAdmin)
                    return packages.Where(p => packageIds.Contains(p.PackageId) && p.AvailableThroughAdmin).ToArray();

                return packages.Where(p => packageIds.Contains(p.PackageId)).ToArray();
            }
        }

        public IEnumerable<EventPackage> GetPackagesForEvent(long eventId, long gender = (long)Gender.Unspecified)
        {
            if (Gender.Unspecified == (Gender)gender)
            {
                return Get(new RelationPredicateBucket(EventPackageDetailsFields.EventId == eventId)).ToArray();
            }

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(EventPackageDetailsFields.EventId == eventId);
            predicateBucket.PredicateExpression.AddWithAnd(EventPackageDetailsFields.Gender == gender | EventPackageDetailsFields.Gender == (long)Gender.Unspecified);

            return Get(predicateBucket).ToArray();
        }

        public IEnumerable<OrderedPair<long, long>> GetEventPackageIdsForOrder(IEnumerable<long> orderIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var successOrderIds = (from tod in linqMetaData.OrderDetail
                                       join oi in linqMetaData.OrderItem on tod.OrderItemId equals oi.OrderItemId
                                       where tod.Status == (int)OrderStatusState.FinalSuccess &&
                                             oi.Type != (int)OrderItemType.CancellationFee && orderIds.Contains(tod.OrderId)
                                       select tod.OrderId).Distinct().ToArray();

                var cancelledOrderIds = orderIds.Except(successOrderIds);

                var pairs = (from od in linqMetaData.OrderDetail
                             join oi in linqMetaData.OrderItem on od.OrderItemId equals oi.OrderItemId
                             join epoi in linqMetaData.EventPackageOrderItem on oi.OrderItemId equals epoi.OrderItemId
                             where successOrderIds.Contains(od.OrderId) && od.Status == (int)OrderStatusState.FinalSuccess
                             && oi.Type == (int)OrderItemType.EventPackageItem
                             select new OrderedPair<long, long>(od.OrderId, epoi.EventPackageId)).ToList();

                if (cancelledOrderIds.IsNullOrEmpty()) return pairs;

                var query = from od in linqMetaData.OrderDetail
                            join oi in linqMetaData.OrderItem on od.OrderItemId equals oi.OrderItemId
                            where cancelledOrderIds.Contains(od.OrderId) && (od.Status == (int)OrderStatusState.FinalFailure)
                            group od by od.OrderId into g
                            select new { OrderId = g.Key, DateCreated = g.Max(od => od.DateCreated) };

                pairs.AddRange((from o in query
                                join tod in linqMetaData.OrderDetail on o.OrderId equals tod.OrderId
                                join epoi in linqMetaData.EventPackageOrderItem on tod.OrderItemId equals epoi.OrderItemId
                                where o.DateCreated == tod.DateCreated
                                select new OrderedPair<long, long>(o.OrderId, epoi.EventPackageId)).ToArray());

                return pairs;
            }
        }

        public EventPackage GetPackageForOrder(long orderId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventPackageId = (from od in linqMetaData.OrderDetail
                                      join oi in linqMetaData.OrderItem on
                                          od.OrderItemId equals oi.OrderItemId
                                      join epoi in linqMetaData.EventPackageOrderItem on oi.OrderItemId equals
                                          epoi.OrderItemId
                                      where od.OrderId == orderId && od.Status == (short)OrderStatusState.FinalSuccess
                                      select epoi.EventPackageId).SingleOrDefault();

                if (eventPackageId < 1) return null;

                return Get(new RelationPredicateBucket(EventPackageDetailsFields.EventPackageId == eventPackageId)).SingleOrDefault();
            }
        }

        public EventPackage Save(EventPackage domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(EventPackage domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<EventPackage> domainObjects)
        {
            throw new NotImplementedException();
        }

        // This is the method which gets the data from EventPackage. Rest of call this
        private IEnumerable<EventPackage> Get(IRelationPredicateBucket expression)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventPackageEntities = new EntityCollection<EventPackageDetailsEntity>();
                IPrefetchPath2 prefetchPath = new PrefetchPath2((int)EntityType.EventPackageDetailsEntity);
                prefetchPath.Add(EventPackageDetailsEntity.PrefetchPathPackage);

                myAdapter.FetchEntityCollection(eventPackageEntities, expression, prefetchPath);

                var eventPackages = new List<EventPackage>();

                var eventPackageIds = eventPackageEntities.Select(ep => ep.EventPackageId).ToArray();
                var eventPackageTestEntities = linqMetaData.EventPackageTest.Where(ept => eventPackageIds.Contains(ept.EventPackageId)).ToArray();

                var eventTestIds = eventPackageTestEntities.Select(ept => ept.EventTestId).Distinct().ToArray();

                var tests = _eventTestRepository.GetbyIds(eventTestIds);

                foreach (var entity in eventPackageEntities)
                {
                    var eventPackage = _mapper.Map(entity);
                    var currentPackageTests = eventPackageTestEntities.Where(ept => ept.EventPackageId == entity.EventPackageId);

                    var package = _packageMapper.Map(entity.Package);
                    package.Price = entity.PackagePrice;
                    package.ScreeningTime = entity.ScreeningTime ?? 0;
                    package.HealthAssessmentTemplateId = entity.HafTemplateId;

                    eventPackage.Package = package;


                    var testIds = currentPackageTests.Select(cpt => cpt.EventTestId).ToArray();
                    eventPackage.Tests = tests.Where(t => testIds.Contains(t.Id)).ToArray();

                    foreach (var test in eventPackage.Tests)
                    {
                        var eventPackageTest = eventPackageTestEntities.Where(ept => ept.EventTestId == test.Id && ept.EventPackageId == eventPackage.Id).SingleOrDefault();

                        test.Test.PackageRefundPrice = eventPackageTest.RefundPrice;
                        test.Test.PackagePrice = eventPackageTest.Price;
                    }

                    eventPackages.Add(eventPackage);
                }

                return eventPackages;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetPackageNamesForOrder(IEnumerable<long> orderIds)
        {
            var pairs = GetEventPackageIdsForOrder(orderIds);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var evetnPackageIds = pairs.Select(p => p.SecondValue).Distinct().ToArray();

                var linqMetaData = new LinqMetaData(adapter);
                var eventPackageIdAndName = (from ep in linqMetaData.EventPackageDetails
                                             join p in linqMetaData.Package on ep.PackageId equals p.PackageId
                                             where evetnPackageIds.Contains(ep.EventPackageId)
                                             select new OrderedPair<long, string>(ep.EventPackageId, p.PackageName)).ToArray();

                return (from p in pairs
                        join ep in eventPackageIdAndName on p.SecondValue equals ep.FirstValue
                        select new OrderedPair<long, string>(p.FirstValue, ep.SecondValue)).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, string>> GetEventPackageIdNamePairs(IEnumerable<long> eventPackageIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(adapter);
                return (from ep in linqMetaData.EventPackageDetails
                        join p in linqMetaData.Package on ep.PackageId equals p.PackageId
                        where eventPackageIds.Contains(ep.EventPackageId)
                        select new OrderedPair<long, string>(ep.EventPackageId, p.PackageName)).ToArray();

            }
        }

        public IEnumerable<EventPackage> GetbyEventIds(IEnumerable<long> eventIds)
        {
            return Get(new RelationPredicateBucket(EventPackageDetailsFields.EventId == eventIds.ToArray())).ToArray();
        }

        public IEnumerable<OrderedPair<long, long>> GetOrderIdEventPackageTestIdPairsForOrder(IEnumerable<long> orderIds)
        {
            var pairs = GetEventPackageIdsForOrder(orderIds);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var evetnPackageIds = pairs.Select(p => p.SecondValue).Distinct().ToArray();

                var linqMetaData = new LinqMetaData(adapter);
                var eventPackageIdAndTestId = (from ept in linqMetaData.EventPackageTest
                                               join et in linqMetaData.EventTest on ept.EventTestId equals et.EventTestId
                                               where evetnPackageIds.Contains(ept.EventPackageId)
                                               select new OrderedPair<long, long>(ept.EventPackageId, et.TestId)).ToArray();

                return (from p in pairs
                        join ep in eventPackageIdAndTestId on p.SecondValue equals ep.FirstValue
                        select new OrderedPair<long, long>(p.FirstValue, ep.SecondValue)).ToArray();

            }
        }
    }
}