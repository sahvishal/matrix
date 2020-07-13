using System.Linq;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class CustomCampaignContentRepository : PersistenceRepository, ICustomCampaignContentRepository
    {
        private readonly IMarketingMaterialRepository _marketingMaterialRepository;

        public CustomCampaignContentRepository()
            : this(new MarketingMaterialRepository())
        { }
        
        public CustomCampaignContentRepository(IMarketingMaterialRepository marketingMaterialRepository)
        {
            _marketingMaterialRepository = marketingMaterialRepository;
        }

        public MarketingMaterial GetCustomContent(long campaignId, string tag)
        {                    
            IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomCampaignContentFields.CampaignId == campaignId);
            bucket.PredicateExpression.Add(CustomCampaignContentFields.Tag == tag);
        
            var campaignContentEntities = new EntityCollection<CustomCampaignContentEntity>();

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(campaignContentEntities, bucket);
            }

            if (campaignContentEntities.Any())
            {
                return _marketingMaterialRepository.GetMarketingMaterialById(campaignContentEntities.First().MarketingMaterialId);                
            }
            
            return null;
        }
    }
}