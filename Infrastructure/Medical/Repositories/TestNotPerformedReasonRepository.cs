using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class TestNotPerformedReasonRepository : PersistenceRepository, ITestNotPerformedReasonRepository
    {
        private IEnumerable<TestNotPerformedReason> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<TestNotPerformedReasonEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var campaignActivity = Mapper.Map<IEnumerable<TestNotPerformedReasonEntity>, IEnumerable<TestNotPerformedReason>>(entities);

                return campaignActivity.OrderBy(x => x.Id).ToArray();
            }
        }

        public IEnumerable<TestNotPerformedReason> GetAll()
        {
            var relationPredicateBucket = new RelationPredicateBucket();

            return Get(relationPredicateBucket);
        }

        
    }
}
