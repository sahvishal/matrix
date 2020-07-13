using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Marketing
{
    [DefaultImplementation(Interface = typeof(IMapper<MarketingSource, MarketingSourceEntity>))]
    public class MarketingSourceMapper : DomainEntityMapper<MarketingSource, MarketingSourceEntity>
    {

        protected override void MapDomainFields(MarketingSourceEntity entity, MarketingSource domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.MarketingSourceId;
            domainObjectToMapTo.Name = entity.Label;
            domainObjectToMapTo.Description = entity.Notes;
            domainObjectToMapTo.ShowOnline = entity.ShowOnline;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData()
                                                           {
                                                               DateCreated = entity.DateCreated,
                                                               DateModified = entity.DateModified
                                                           };
        }

        protected override void MapEntityFields(MarketingSource domainObject, MarketingSourceEntity entityToMapTo)
        {
            entityToMapTo.MarketingSourceId = domainObject.Id;
            entityToMapTo.Label = domainObject.Name;
            entityToMapTo.Notes = domainObject.Description;
            entityToMapTo.ShowOnline = domainObject.ShowOnline;
            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified.HasValue
                                                 ? domainObject.DataRecorderMetaData.DateModified.Value
                                                 : DateTime.Now;
            }

        }
    }
}