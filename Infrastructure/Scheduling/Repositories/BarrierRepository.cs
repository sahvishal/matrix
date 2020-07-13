using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class BarrierRepository : PersistenceRepository, IBarrierRepository
    {
        public void Save(EventCustomerBarrier model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecb in linqMetaData.EventCustomerBarrier
                              where ecb.EventCustomerId == model.EventCustomerId
                              select ecb).SingleOrDefault();
                if (entity == null)
                {
                    var customerBarrierEntity = Mapper.Map<EventCustomerBarrier, EventCustomerBarrierEntity>(model);
                    if (!adapter.SaveEntity(customerBarrierEntity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }
                else
                {
                    var eventCustomerBarrier = new EventCustomerBarrierEntity() { BarrierId = model.BarrierId, Reason = model.Reason, Resolution = model.Resolution };
                    var eventCustomerBarrierRelationPredicateBucket = new RelationPredicateBucket(EventCustomerBarrierFields.EventCustomerId == model.EventCustomerId);

                    adapter.UpdateEntitiesDirectly(eventCustomerBarrier, eventCustomerBarrierRelationPredicateBucket);
                }
            }
        }

        public IEnumerable<OrderedPair<string, long>> GetBarrierCategoryIdNamePairs()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Barrier.Where(x => x.IsActive).
                        Select(x => new OrderedPair<string, long>(x.Name, x.Id)).ToArray().OrderBy(x => x.FirstValue);
            }
        }

        public EventCustomerBarrier GetCustomerBarrierByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecb in linqMetaData.EventCustomerBarrier
                              where ecb.EventCustomerId == eventCustomerId
                              select ecb).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<EventCustomerBarrierEntity, EventCustomerBarrier>(entity);
            }
        }



        public IEnumerable<EventCustomerBarrier> GetCustomerBarrierByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecb in linqMetaData.EventCustomerBarrier
                                where eventCustomerIds.Contains(ecb.EventCustomerId)
                                select ecb).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerBarrierEntity>, IEnumerable<EventCustomerBarrier>>(entities);
            }
        }

        public IEnumerable<EventCustomerBarrier> GetForBarrierInboundReport(BarrierInboundFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = filter.AccountId > 0 ? (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault() : null;

                var query = (from ecb in linqMetaData.EventCustomerBarrier
                             join ec in linqMetaData.EventCustomers on ecb.EventCustomerId equals ec.EventCustomerId
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                             where (filter.StartDate == null || e.EventDate >= filter.StartDate)
                             && (filter.EndDate == null || e.EventDate <= filter.EndDate)
                             && (account == null || cp.Tag == account.Tag)
                             select new { ecb, ec.CustomerId });

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                    query = (from q in query where customTagCustomersIds.Contains(q.CustomerId) select q);
                }

                var entities = (from q in query select q.ecb);

                totalRecords = entities.Count();
                var result = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerBarrierEntity>, IEnumerable<EventCustomerBarrier>>(result);
            }
        }

        public IEnumerable<Barrier> GetByIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from b in linqMetaData.Barrier where ids.Contains(b.Id) select b);

                return Mapper.Map<IEnumerable<BarrierEntity>, IEnumerable<Barrier>>(entities);
            }
        }
    }
}
