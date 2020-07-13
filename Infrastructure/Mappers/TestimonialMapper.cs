using System;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class TestimonialMapper : DomainEntityMapper<Testimonial, TestimonialEntity>
    {
        
        protected override void MapDomainFields(TestimonialEntity entity, Testimonial domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.TestimonialId;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.TestimonialText = entity.TestimonialText;
            if (entity.FileId.HasValue)
                domainObjectToMapTo.TestimonialVideo = new File(entity.FileId.Value);
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;
            domainObjectToMapTo.IsAccepted = entity.IsAccepted;
            domainObjectToMapTo.Rank = entity.Rank;
            domainObjectToMapTo.ReviewedBy = entity.ReviewedBy;
            domainObjectToMapTo.ReviewedOn = entity.ReviewedOn;
        }

        protected override void MapEntityFields(Testimonial domainObject, TestimonialEntity entityToMapTo)
        {
            entityToMapTo.TestimonialId = domainObject.Id;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.TestimonialText = domainObject.TestimonialText;
            entityToMapTo.FileId = domainObject.TestimonialVideo != null
                                       ? domainObject.TestimonialVideo.Id
                                       : (long?) null;
            entityToMapTo.DateCreated = domainObject.Id > 0 ? domainObject.DateCreated : DateTime.Now;
            entityToMapTo.DateModified = DateTime.Now;
            entityToMapTo.IsAccepted = domainObject.IsAccepted;
            entityToMapTo.Rank = domainObject.Rank;
            entityToMapTo.ReviewedBy = domainObject.ReviewedBy;
            entityToMapTo.ReviewedOn = domainObject.ReviewedOn;
        }
    }
}
