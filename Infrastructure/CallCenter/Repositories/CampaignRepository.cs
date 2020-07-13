using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.CallCenter.ViewModels;
using System.Collections.Generic;
using Falcon.App.Core;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{

    [DefaultImplementation]
    public class CampaignRepository : PersistenceRepository, ICampaignRepository
    {
        public Campaign GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from cu in linqMetaData.Campaign where cu.Id == id select cu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<Campaign>(id);

                return AutoMapper.Mapper.Map<CampaignEntity, Campaign>(entity);
            }
        }

        public Campaign Save(Campaign domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<Campaign, CampaignEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save campaign");

                return AutoMapper.Mapper.Map<CampaignEntity, Campaign>(entity);
            }
        }

        public IEnumerable<Campaign> GetCampaignDetails(int pageNumber, int pageSize, CampaignListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cu in linqMetaData.Campaign select cu);

                if (filter != null)
                {
                    if (filter.IsPublished)
                        query = (from cu in query where cu.IsPublished == filter.IsPublished select cu);

                    if (!string.IsNullOrEmpty(filter.Name))
                    {
                        query = (from cu in query where cu.Name.ToLower().Contains(filter.Name.ToLower()) select cu);
                    }

                    if (filter.CampaignTypeId.HasValue && filter.CampaignTypeId.Value > 0)
                    {
                        query = (from cu in query where cu.TypeId == filter.CampaignTypeId select cu);
                    }

                    if (filter.CampaignModeId.HasValue && filter.CampaignModeId.Value > 0)
                    {
                        query = (from cu in query where cu.ModeId == filter.CampaignModeId select cu);
                    }

                    if (filter.StartDate.HasValue)
                    {
                        query = (from cu in query where cu.StartDate.Date >= filter.StartDate.Value.Date select cu);
                    }

                    if (filter.EndDate.HasValue)
                    {
                        query = (from cu in query where cu.EndDate.Date <= filter.EndDate.Value.Date select cu);
                    }

                    if (filter.AccountId.HasValue && filter.AccountId.Value > 0)
                    {
                        query = (from cu in query where cu.AccountId == filter.AccountId select cu);
                    }
                }

                totalRecords = query.Count();
                var entities = query.OrderByDescending(p => p.ModifiedOn).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(entities);

            }
        }
        public IEnumerable<Campaign> GeCotporateCampaignForCallQueue(DateTime callDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var querey = (from c in linqMetaData.Campaign
                              join ca in linqMetaData.CampaignActivity on c.Id equals ca.CampaignId
                              where c.IsPublished && ca.TypeId == (long)CampaignActivityType.OutboundCall && c.TypeId == (long)CampaignType.Corporate
                              && ca.ActivityDate.Date == callDate.Date
                              select c).Distinct().ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(querey);
            }
        }

        public IEnumerable<Campaign> GetCampaignIdsForCallQueue(CampaignCallQueueFilter filter, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueCampaignIds = (from cqc in linqMetaData.CallQueueCustomer where cqc.CampaignId.HasValue && cqc.CallQueueId == filter.CallQueueId select cqc.CampaignId.Value);

                var query = (from hpca in linqMetaData.HealthPlanCriteriaAssignment
                             join hpcqc in linqMetaData.HealthPlanCallQueueCriteria on hpca.HealthPlanCriteriaId equals hpcqc.Id
                             join c in linqMetaData.Campaign on hpcqc.CampaignId equals c.Id
                             where c.IsPublished && c.TypeId == (long)CampaignType.Corporate && c.EndDate >= DateTime.Today && hpca.AssignedToOrgRoleUserId == filter.AssignedToOrgRoleUserId && hpcqc.HealthPlanId == filter.HealthPlanId && hpcqc.CampaignId.HasValue
                              && callQueueCampaignIds.Contains(hpcqc.CampaignId.Value)
                             select c);

                if (filter.StartDate.HasValue)
                    query = (from q in query where q.StartDate >= filter.StartDate.Value select q);

                if (filter.EndDate.HasValue)
                    query = (from q in query where q.EndDate <= filter.EndDate.Value select q);

                var campaignWithCriteria = (from c in query
                                            join hpcqc in linqMetaData.HealthPlanCallQueueCriteria on c.Id equals hpcqc.CampaignId.Value
                                            where hpcqc.CampaignId.HasValue && hpcqc.CampaignId.Value > 0
                                            select new { c, hpcqc }
                    );

                totalRecords = campaignWithCriteria.Count();
                var campaignQuery = campaignWithCriteria.OrderByDescending(q => q.hpcqc.DateModified).ThenByDescending(o => o.hpcqc.DateCreated).Select(q => q.c);

                var entities = campaignQuery.TakePage(filter.PageNumber, pageSize);

                return AutoMapper.Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(entities);
            }
        }

        public bool IsCampaignCodeUnique(string campaignCode, long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var campaignWithSameCode = (from c in linqMetaData.Campaign
                                            where c.CampaignCode.ToLower() == campaignCode.ToLower() && c.Id != campaignId
                                            select c).Count();

                return campaignWithSameCode == 0;
            }
        }

        public bool IsCampaignNameUnique(string campaignName, long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var campaignWithSameName = (from c in linqMetaData.Campaign
                                            where c.Name.ToLower() == campaignName.ToLower() && c.Id != campaignId
                                            select c).Count();

                return campaignWithSameName == 0;
            }
        }

        public Campaign GetCampaignByName(string campaignName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from c in linqMetaData.Campaign
                              where c.Name.ToLower() == campaignName.ToLower()
                              select c).SingleOrDefault();

                return AutoMapper.Mapper.Map<CampaignEntity, Campaign>(entity);
            }
        }

        public IEnumerable<Campaign> GetByIds(IEnumerable<long> campaignIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cu in linqMetaData.Campaign where campaignIds.Contains(cu.Id) select cu).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(entities);
            }
        }

        public IEnumerable<Campaign> GetCampaignsByHealthPlanId(long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from c in linqMetaData.Campaign where c.AccountId == healthPlanId && c.IsPublished select c).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(entities);
            }
        }

        public IEnumerable<OrderedPair<long?, long>> GetCriteriaIdsForCampaigns(IEnumerable<long> campaignIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                        where hpcqc.CampaignId.HasValue && campaignIds.Contains(hpcqc.CampaignId.Value)
                        select new OrderedPair<long?, long> { FirstValue = hpcqc.CampaignId, SecondValue = hpcqc.Id }).ToArray();
            }
        }

        public IEnumerable<Campaign> GetCotporateCampaignForNotGenerated()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var querey = (from c in linqMetaData.Campaign
                              join hpcq in linqMetaData.HealthPlanCallQueueCriteria on c.Id equals hpcq.CampaignId
                              where c.IsPublished && hpcq.IsQueueGenerated == false
                              select c).Distinct().ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CampaignEntity>, IEnumerable<Campaign>>(querey);
            }
        }

        public bool IsCampaignAlreadyPublished(long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from c in linqMetaData.Campaign where c.Id == campaignId select c.IsPublished).SingleOrDefault();
            }
        }
    }
}
