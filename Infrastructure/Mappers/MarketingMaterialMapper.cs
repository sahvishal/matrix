using System;
using Falcon.App.Core.Marketing.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class MarketingMaterialMapper : DomainEntityMapper<MarketingMaterial, AfmarketingMaterialEntity>
    {
        protected override void MapDomainFields(AfmarketingMaterialEntity entity, 
            MarketingMaterial domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.MarketingMaterialId;
            domainObjectToMapTo.CreatedDate = entity.CreatedDate ?? new DateTime(1900, 1, 1);
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.DisplayUrl = entity.DisplayUrl;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.HTMLText = entity.Htmltext;
            domainObjectToMapTo.HeadingText = entity.HeadingText;
            domainObjectToMapTo.ImagePath = entity.ImagePath;
            domainObjectToMapTo.IsDefault = entity.Isdefault;
            domainObjectToMapTo.IsEventSpecific = entity.IsEventSpecific;
            domainObjectToMapTo.IsInbound = entity.IsInbound;
            domainObjectToMapTo.IsInternal = entity.IsInternal;
            domainObjectToMapTo.LastModifiedDate = entity.LastModifiedDate ?? new DateTime(1900, 1, 1);
            domainObjectToMapTo.LeadingInUrl = entity.LeadingInUrl;
            domainObjectToMapTo.MarketingOfferId = entity.MarketingOfferId;
            domainObjectToMapTo.Text = entity.Text;
            domainObjectToMapTo.ThumbnailImage = entity.ThumbnailImagePath;
            domainObjectToMapTo.Title = entity.Title;
            domainObjectToMapTo.TypeId = entity.MarketingMaterialTypeId;
        }

        protected override void MapEntityFields(MarketingMaterial domainObject, 
            AfmarketingMaterialEntity entityToMapTo)
        {
            throw new NotImplementedException();
        }
    }
}