using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class TestNotPerformedRepository : PersistenceRepository, ITestNotPerformedRepository
    {
        public IEnumerable<TestNotPerformed> GetTestNotPerformedForHealthPlan(TestNotPerformedListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter.EventDateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value.Date : DateTime.Now.AddMonths(-1).Date;
                filter.EventDateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value.Date : DateTime.Now.Date;

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join ces in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals ces.EventCustomerResultId
                             join cets in linqMetaData.CustomerEventTestState on ces.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                             join tnep in linqMetaData.TestNotPerformed on ces.CustomerEventScreeningTestId equals tnep.CustomerEventScreeningTestId
                             join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue && (filter.TechnicianId > 0 ? cets.ConductedByOrgRoleUserId == filter.TechnicianId : true) && cets.ConductedByOrgRoleUserId.HasValue
                                   && e.EventDate <= DateTime.Today
                             select new { ecr, tnep, e.EventDate, ces.TestId });

                if (filter.EventId > 0)
                {
                    query = (from q in query where q.ecr.EventId == filter.EventId select q);
                }
                else
                {
                    if (filter.EventDateFrom.HasValue || filter.EventDateTo.HasValue)
                    {
                        query = (from q in query
                                 where (filter.EventDateFrom != null ? q.EventDate >= filter.EventDateFrom.Value : true)
                                     && (filter.EventDateTo != null ? q.EventDate <= filter.EventDateTo.Value : true)
                                 select q);
                    }

                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        var podEventIds = (from ep in linqMetaData.EventPod
                                           join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                           where ep.IsActive && p.Name.Contains(filter.Pod)
                                           select ep.EventId);

                        query = (from q in query where podEventIds.Contains(q.ecr.EventId) select q);
                    }

                    if (filter.HealthPlanId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);

                        query = (from q in query where eventIds.Contains(q.ecr.EventId) select q);
                    }

                    if (filter.TestId > 0)
                    {
                        query = (from q in query where q.TestId == filter.TestId select q);
                    }
                }
                var testNotPerformedQuery = (from q in query
                                             orderby q.EventDate, q.ecr.EventId, q.ecr.CustomerId
                                             select q.tnep);

                totalRecords = testNotPerformedQuery.Count();
                var entities = testNotPerformedQuery.TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<TestNotPerformedEntity>, IEnumerable<TestNotPerformed>>(entities);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEventCusromerResultIdTestIdPairs(IEnumerable<long> eventCustomerResultIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecr in linqMetaData.EventCustomerResult
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join tnp in linqMetaData.TestNotPerformed on cest.CustomerEventScreeningTestId equals tnp.CustomerEventScreeningTestId
                        select new OrderedPair<long, long>(ecr.EventCustomerResultId, cest.TestId)).ToArray();
            }
        }

        public IEnumerable<EventCustomerResultTestNotPerformedViewModel> GetEventCustomerResultTestNotPerformed(IEnumerable<long> eventCustomerResultIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerResultTestNotPerformed = (from ecr in linqMetaData.EventCustomerResult
                                                           join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                           join tnp in linqMetaData.TestNotPerformed on cest.CustomerEventScreeningTestId equals tnp.CustomerEventScreeningTestId
                                                           select new EventCustomerResultTestNotPerformedViewModel
                                                           {
                                                               EventCustomerResultId = ecr.EventCustomerResultId,
                                                               Notes = tnp.Notes,
                                                               TestId = cest.TestId,
                                                               ReasonId = tnp.TestNotPerformedReasonId
                                                           }).ToArray();

                return eventCustomerResultTestNotPerformed;
            }
        }

        public bool IsTestNotPerformed(long eventCustomerResultId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecr in linqMetaData.EventCustomerResult
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join tnp in linqMetaData.TestNotPerformed on cest.CustomerEventScreeningTestId equals tnp.CustomerEventScreeningTestId
                        where ecr.EventCustomerResultId == eventCustomerResultId && cest.TestId == testId
                        select cest).Any();
            }
        }
    }
}