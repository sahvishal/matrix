using System.Collections.Generic;
using System.Linq;
using AuthorizeNet;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class ChaseCampaignRepository : PersistenceRepository, IChaseCampaignRepository
    {
        public ChaseCampaign GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cc in linqMetaData.ChaseCampaign where cc.ChaseCampaignId == id select cc).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseCampaignEntity, ChaseCampaign>(entity);
            }
        }

        public IEnumerable<ChaseCampaign> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cc in linqMetaData.ChaseCampaign where ids.Contains(cc.ChaseCampaignId) select cc).ToArray();

                return Mapper.Map<IEnumerable<ChaseCampaignEntity>, IEnumerable<ChaseCampaign>>(entities);
            }
        }

        public ChaseCampaign Save(ChaseCampaign domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaseCampaign, ChaseCampaignEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ChaseCampaignEntity, ChaseCampaign>(entity);
            }
        }

        public IEnumerable<CustomerChaseCampaign> GetCustomerChaseCampaignsByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccc in linqMetaData.CustomerChaseCampaign where ccc.CustomerId == customerId select ccc).ToArray();

                return Mapper.Map<IEnumerable<CustomerChaseCampaignEntity>, IEnumerable<CustomerChaseCampaign>>(entities);
            }
        }

        public IEnumerable<CustomerChaseCampaign> GetCustomerChaseCampaignsByCustomerIds(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccc in linqMetaData.CustomerChaseCampaign where customerIds.Contains(ccc.CustomerId) && ccc.IsActive select ccc).ToArray();

                return Mapper.Map<IEnumerable<CustomerChaseCampaignEntity>, IEnumerable<CustomerChaseCampaign>>(entities);
            }
        }

        public CustomerChaseCampaign SaveCustomerChaseCampaign(CustomerChaseCampaign domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerChaseCampaign, CustomerChaseCampaignEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CustomerChaseCampaignEntity, CustomerChaseCampaign>(entity);
            }
        }

        public void DeactivateAllCustomerCampaigns(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(CustomerChaseCampaignFields.CustomerId == customerId);
                adapter.UpdateEntitiesDirectly(new CustomerChaseCampaignEntity { IsActive = false }, relationPredicateBucket);
            }
        }
    }
}
