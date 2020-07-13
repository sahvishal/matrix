using Falcon.App.Core.Marketing;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Sql;

namespace Falcon.App.Infrastructure.Marketing.Repositories
{
    public class AffiliateCommisionGenerationRepository : PersistenceRepository, IAffiliateCommisionGenerationRepository
    {
        public bool SaveEventAffiliate(long eventCustomerId, long? callId)
        {
            long returnParameter = 0;
            var returnValue =
                ActionProcedures.SaveEventAffiliate(eventCustomerId, callId.HasValue ? callId.Value : 0,
                                                    ref returnParameter);
            return true;
        }
    }
}