using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventCustomerPreApprovedTestRepository : PersistenceRepository, IEventCustomerPreApprovedTestRepository
    {
        private void DeletePreApprovedTests(long eventcustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCustomerPreApprovedTestFields.EventCustomerId == eventcustomerId);

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPreApprovedTestEntity), relationPredicateBucket);
            }
        }


        public void Save(long eventcustomerId, IEnumerable<long> testIds)
        {
            DeletePreApprovedTests(eventcustomerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<EventCustomerPreApprovedTestEntity>();

                foreach (var testId in testIds)
                {
                    entities.Add(new EventCustomerPreApprovedTestEntity(eventcustomerId, testId)
                    {
                        IsNew = true
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<EventCustomerPreApprovedTest> GetEventCustomerResultForGapsClosure(int pageNumber, int pageSize, GapsClosureModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter = filter ?? new GapsClosureModelFilter();

                var query = (from vecpat in linqMetaData.VwEventCustomerPreApprovedTestList
                             join ecr in linqMetaData.EventCustomerResult on vecpat.EventCustomerId equals ecr.EventCustomerResultId
                             join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where ec.AppointmentId != null && ec.NoShow == false && ec.LeftWithoutScreeningReasonId == null
                             select new { vecpat, ec });

                if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                {
                    var eventIds = (from e in linqMetaData.Events
                                    where (filter.FromDate != null ? filter.FromDate <= e.EventDate : true)
                                        && (filter.ToDate != null ? filter.ToDate >= e.EventDate : true)
                                    select e.EventId);

                    query = (from q in query where eventIds.Contains(q.ec.EventId) select q);
                }

                if (filter.AccountId > 0)
                {
                    var eventids = (from a in linqMetaData.EventAccount where a.AccountId == filter.AccountId select a.EventId);

                    query = (from q in query where eventids.Contains(q.ec.EventId) select q); ;
                }

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);
                    query = (from q in query where customTagCustomerIds.Contains(q.ec.CustomerId) select q);
                }

                var finalQuery = (from q in query orderby q.ec.DateCreated descending select q.vecpat);

                totalRecords = finalQuery.Count();
                var entities = finalQuery.TakePage(pageNumber, pageSize).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<VwEventCustomerPreApprovedTestListEntity>, IEnumerable<EventCustomerPreApprovedTest>>(entities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetCustomerIdPreApprovedTests(IEnumerable<long> eventcustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecpat in linqMetaData.EventCustomerPreApprovedTest
                        join t in linqMetaData.Test on ecpat.TestId equals t.TestId
                        join ec in linqMetaData.EventCustomers on ecpat.EventCustomerId equals ec.EventCustomerId
                        where eventcustomerId.Contains(ecpat.EventCustomerId)
                        select new OrderedPair<long, string>(ec.CustomerId, t.Name)).ToArray();
            }
        }

        public IEnumerable<long> GetPreApprovedTestByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecpat in linqMetaData.EventCustomerPreApprovedTest
                        where ecpat.EventCustomerId == eventCustomerId
                        select ecpat.TestId).Distinct().ToArray();

            }
        }

        public IEnumerable<string> GetPreApprovedTestNameByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ecpat in linqMetaData.EventCustomerPreApprovedTest
                        join t in linqMetaData.Test on ecpat.TestId equals t.TestId
                        where ecpat.EventCustomerId == eventCustomerId
                        select t.Name).Distinct().ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetPreApprovedTestIdsByCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecpat in linqMetaData.EventCustomerPreApprovedTest
                        join t in linqMetaData.Test on ecpat.TestId equals t.TestId
                        join ec in linqMetaData.EventCustomers on ecpat.EventCustomerId equals ec.EventCustomerId
                        where eventCustomerIds.Contains(ecpat.EventCustomerId)
                        select new OrderedPair<long, long>(ec.EventCustomerId, t.TestId)).ToArray();
            }
        }

        public IEnumerable<string> GetPreApprovedTest(long eventcustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecpat in linqMetaData.EventCustomerPreApprovedTest
                        join t in linqMetaData.Test on ecpat.TestId equals t.TestId
                        where ecpat.EventCustomerId == eventcustomerId
                        select t.Name).ToArray();
            }
        }
    }
}