using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    [DefaultImplementation]
    public class HealthPlanRevenueItemRepository : PersistenceRepository, IHealthPlanRevenueItemRepository
    {
        public IEnumerable<HealthPlanRevenueItem> GetAllHealthPlanRevenueItemById(long revenuId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from hpri in linqMetaData.HealthPlanRevenueItem
                                where hpri.HealthPlanRevenueId == revenuId
                                orderby revenuId
                                select hpri);
                return Mapper.Map<IEnumerable<HealthPlanRevenueItemEntity>, IEnumerable<HealthPlanRevenueItem>>(entities);
            }
        }

        public HealthPlanRevenueItem Save(HealthPlanRevenueItem domain)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<HealthPlanRevenueItem, HealthPlanRevenueItemEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save revenu Item");

                return Mapper.Map<HealthPlanRevenueItemEntity, HealthPlanRevenueItem>(entity);
            }
        }

        public IEnumerable<HealthPlanRevenueItem> GetAllHealthPlanRevenueItemByIds(IEnumerable<long> revenueIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from hpri in linqMetaData.HealthPlanRevenueItem
                                where revenueIds.Contains(hpri.HealthPlanRevenueId)
                                select hpri);

                return Mapper.Map<IEnumerable<HealthPlanRevenueItemEntity>, IEnumerable<HealthPlanRevenueItem>>(entities);
            }
        }
    }
}
