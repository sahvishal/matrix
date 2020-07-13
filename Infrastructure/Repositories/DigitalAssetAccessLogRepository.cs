using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class DigitalAssetAccessLogRepository : UniqueItemRepository<DigitalAssetAccessLog, DigitalAssetAccessLogEntity>, IDigitalAssetAccessLogRepository
    {
        public DigitalAssetAccessLogRepository()
            : this(new DigitalAssetAccessLogMapper())
        { }

        public DigitalAssetAccessLogRepository(IMapper<DigitalAssetAccessLog, DigitalAssetAccessLogEntity> mapper)
            : base(mapper)
        { }

        protected override EntityField2 EntityIdField
        {
            get { return DigitalAssetAccessLogFields.DigitalAssetAccessLogId; }
        }

        public bool IsDigitalAssetAccessed(long customerId, DateTime resultReadyDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from daal in linqMetaData.DigitalAssetAccessLog
                        where daal.OrganisationRoleUserId == customerId
                              && daal.AccessedOn > resultReadyDate
                        select daal.DigitalAssetAccessLogId).Any();
            }
        }
    }
}
