using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Marketing.Repositories
{
    [DefaultImplementation(Interface = typeof(IMarketingSourceRepository))]
    public class MarketingSourceRepository : UniqueItemRepository<MarketingSource, MarketingSourceEntity>, IMarketingSourceRepository
    {

        public MarketingSourceRepository(IMapper<MarketingSource, MarketingSourceEntity> mapper)
            : base(mapper)
        { }

        public List<string> GetAll()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return
                    linqMetaData.MarketingSource.Where(ms => ms.IsActive).OrderBy(ms => ms.Label).Select(ms => ms.Label)
                        .ToList();
            }
        }

        public IEnumerable<string> GetMarketingSourceByTerritory(long[] territoryId, bool showOnline = false)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from m in linqMetaData.MarketingSource
                        join mt in linqMetaData.MarketingSourceTerritory
                            on m.MarketingSourceId equals mt.MarketingSourceId
                        where territoryId.Contains(mt.TerritoryId) && m.IsActive && (showOnline ? m.ShowOnline : true)
                        orderby m.Label
                        select m.Label.Trim()).ToArray().Distinct();
            }
        }


        public IEnumerable<string> GetGlobalMarketingSources(bool showOnline = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var queryForMswithTerritories = (from mst in linqMetaData.MarketingSourceTerritory
                                                 select mst.MarketingSourceId);

                var queryForMSwithoutZIp = from ms in linqMetaData.MarketingSource
                                           where !queryForMswithTerritories.Contains(ms.MarketingSourceId) && ms.IsActive
                                                && (showOnline ? ms.ShowOnline : true)
                                           select ms.Label.Trim();

                return queryForMSwithoutZIp.ToArray();
            }
        }

        public IEnumerable<MarketingSource> GetPagedRecords(int pageNumber, int pageSize, MarketingSourceListModelFilter filter, out int totalRecords)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                if (filter == null)
                {

                    totalRecords = linqMetaData.MarketingSource.Where(ms => ms.IsActive).Count();
                    return
                        Mapper.MapMultiple(
                            linqMetaData.MarketingSource.Where(ms => ms.IsActive).TakePage(pageNumber, pageSize).ToArray
                                ());
                }

                var query = from ms in linqMetaData.MarketingSource
                            where ms.IsActive
                            select ms;

                if (!string.IsNullOrEmpty(filter.MarketingSourceName))
                    query = query.Where(q => q.Label.Contains(filter.MarketingSourceName));

                query = from q in query
                        orderby q.Label
                        select q;

                totalRecords = query.Count();
                return Mapper.MapMultiple(query.TakePage(pageNumber, pageSize).ToArray());
            }
        }

        public void SaveMarketingSourceTerritories(long marketingSourceId, IEnumerable<long> territoryIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeleteMarketingSourceTerritories(marketingSourceId);

                if (territoryIds == null || territoryIds.Count() < 1) return;

                var entities = new EntityCollection<MarketingSourceTerritoryEntity>();
                foreach (var territoryId in territoryIds)
                {
                    entities.Add(new MarketingSourceTerritoryEntity(marketingSourceId, territoryId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();


            }
        }

        public void DeleteMarketingSourceTerritories(long marketingSourceId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("MarketingSourceTerritoryEntity",
                                               new RelationPredicateBucket(
                                                   MarketingSourceTerritoryFields.MarketingSourceId == marketingSourceId));
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetMarketingSourceTerritories(IEnumerable<long> marketingSourceIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from mst in linqMetaData.MarketingSourceTerritory
                        where marketingSourceIds.Contains(mst.MarketingSourceId)
                        select new OrderedPair<long, long>(mst.MarketingSourceId, mst.TerritoryId)).ToArray();
            }
        }

        public void Deactivate(long marketingSourceId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new MarketingSourceEntity() { IsActive = false };
                adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(MarketingSourceFields.MarketingSourceId == marketingSourceId));
            }
        }

        protected override EntityField2 EntityIdField
        {
            get { return MarketingSourceFields.MarketingSourceId; }
        }
    }
}
