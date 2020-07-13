using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class DisqualifiedTestRepository : PersistenceRepository, IDisqualifiedTestRepository
    {
        public IEnumerable<DisqualifiedTest> GetAllByEventCustomerId(long customerId, long eventId, int version = 1)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.DisqualifiedTest.Where(x => x.CustomerId == customerId && x.EventId == eventId && x.Version == version && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<DisqualifiedTestEntity>, IEnumerable<DisqualifiedTest>>(entities);
            }
        }

        public long GetLatestVersion(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var version = (from dt in linqMetaData.DisqualifiedTest
                               where dt.CustomerId == customerId
                               //&& dt.EventId == eventId
                               orderby dt.Version descending
                               select dt.Version).FirstOrDefault();

                return version;
            }
        }

        public void SaveAnswer(IEnumerable<DisqualifiedTest> answers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<DisqualifiedTest>, IEnumerable<DisqualifiedTestEntity>>(answers);
                var collection = new EntityCollection<DisqualifiedTestEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        public bool DeleteDisqualifiedTests(long customerId, long eventId, long orgUserId)
        {
            var disqualifiedTestEntity = new DisqualifiedTestEntity() { IsActive = false, UpdatedBy = orgUserId, UpdatedDate = DateTime.Now };
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(DisqualifiedTestFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(DisqualifiedTestFields.EventId == eventId);
                return (adapter.UpdateEntitiesDirectly(disqualifiedTestEntity, bucket) > 0) ? true : false;
            }
        }

        public IEnumerable<DisqualifiedTestModel> GetByFilter(DisqualifiedTestReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var disqualifiedTests = from dt in linqMetaData.DisqualifiedTest
                                        where dt.IsActive
                                        group dt by new { dt.CustomerId, dt.EventId, dt.TestId } into dts
                                        select new { dts.Key.CustomerId, dts.Key.EventId, dts.Key.TestId, Version = dts.Max(x => x.Version), DateCreated = dts.Max(x => x.CreatedDate) };

                if (filter.CustomerId.HasValue && filter.CustomerId > 0 && filter.EventId==null)
                {
                    disqualifiedTests = (from q in disqualifiedTests
                                         where q.CustomerId == filter.CustomerId 
                                         select q);
                }
                else
                {
                    if (filter.AccountId > 0)
                    {
                        var tag = (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a.Tag).Single();

                        var customerIds = (from cp in linqMetaData.CustomerProfile
                                           where cp.Tag == tag
                                           select cp.CustomerId);

                        disqualifiedTests = (from q in disqualifiedTests
                                             where customerIds.Contains(q.CustomerId)
                                             select q);
                    }

                    if (filter.EventId > 0)
                    {
                        disqualifiedTests = (from q in disqualifiedTests
                                             where q.EventId == filter.EventId
                                             select q);
                    }

                    if (filter.TestId > 0)
                    {
                        disqualifiedTests = (from q in disqualifiedTests
                                             where q.TestId == filter.TestId
                                             select q);
                    }
                }

                totalRecords = disqualifiedTests.Count();

                var pagedDisqualifiedTests = disqualifiedTests.OrderByDescending(x => x.DateCreated).TakePage(pageNumber, pageSize).ToArray();

                return pagedDisqualifiedTests.Select(x => new DisqualifiedTestModel
                {
                    CustomerId = x.CustomerId,
                    EventId = x.EventId,
                    TestId = x.TestId,
                    Version = x.Version,
                    DateCreated = x.DateCreated.Value
                });
            }
        }

        public IEnumerable<DisqualifiedTest> GetAllByEventIdCustomerId(IEnumerable<long> customerIds, IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.DisqualifiedTest.Where(x => customerIds.Contains(x.CustomerId) && eventIds.Contains(x.EventId) && x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<DisqualifiedTestEntity>, IEnumerable<DisqualifiedTest>>(entities);
            }
        }

        public IEnumerable<long> GetLatestVersionTestId(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return linqMetaData.DisqualifiedTest.Where(x => x.CustomerId == customerId && x.EventId == eventId && x.IsActive)
                        .Select(x => x.TestId)
                        .ToArray();
            }
        }
        public bool DeleteDisqualifiedTests(long customerId, long[] eventIds, long orgUserId)
        {
            var disqualifiedTestEntity = new DisqualifiedTestEntity() { IsActive = false, UpdatedBy = orgUserId, UpdatedDate = DateTime.Now };
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(DisqualifiedTestFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(DisqualifiedTestFields.EventId == eventIds);
                return (adapter.UpdateEntitiesDirectly(disqualifiedTestEntity, bucket) > 0) ? true : false;
            }
        }
    }
}
