using Falcon.App.Core.Sales;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class ActivityTemplateRepository : PersistenceRepository, IActivityTemplateRepository
    {
        public bool ActiveDeActiveTemplate(long activityTemplateId, bool activeStatus)
        {
            var eventActivityTemplateEntity = new EventActivityTemplateEntity(activityTemplateId) { IsActive = activeStatus };
            IRelationPredicateBucket relationPredicateBucket =
                new RelationPredicateBucket(EventActivityTemplateFields.EventActivityTemplateId == activityTemplateId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(eventActivityTemplateEntity, relationPredicateBucket) > 0;
            }
        }
    }
}
