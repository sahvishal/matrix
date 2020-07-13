using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Operations.Mappers
{
    public class CdContentGeneratorTrackingMapper : DomainEntityMapper<CdContentGeneratorTracking, CdcontentGeneratorTrackingEntity>
    {
        protected override void MapDomainFields(CdcontentGeneratorTrackingEntity entity, CdContentGeneratorTracking domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CdcontentGeneratorTrackingId;
            domainObjectToMapTo.EventCustomerResultId = entity.EventCustomerResultId;
            domainObjectToMapTo.IsContentGenerated = entity.IsContentGenerated;
            domainObjectToMapTo.IsContentDownloaded = entity.IsContentDownloaded;
            domainObjectToMapTo.DownloadedByOrgRoleUserId = entity.DownloadedByOrgRoleUserId;
            domainObjectToMapTo.DownloadedDate = entity.DownloadedDate;
            domainObjectToMapTo.ContentGeneratedDate = entity.ContentGeneratedDate;
        }

        protected override void MapEntityFields(CdContentGeneratorTracking domainObject, CdcontentGeneratorTrackingEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerResultId = domainObject.EventCustomerResultId;
            entityToMapTo.IsContentGenerated = domainObject.IsContentGenerated;
            entityToMapTo.IsContentDownloaded = domainObject.IsContentDownloaded;
            entityToMapTo.DownloadedByOrgRoleUserId = domainObject.DownloadedByOrgRoleUserId;
            entityToMapTo.DownloadedDate = domainObject.DownloadedDate;
            entityToMapTo.CdcontentGeneratorTrackingId = domainObject.Id;
            entityToMapTo.ContentGeneratedDate = domainObject.ContentGeneratedDate;
            entityToMapTo.IsNew = !(domainObject.Id > 0);
        }
    }
}
