using Falcon.App.Core.Scheduling.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Events
{
    public class EventTestMapper : DomainEntityMapper<EventTest, EventTestEntity>
    {

        protected override void MapDomainFields(EventTestEntity entity, EventTest domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventTestId;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.TestId = entity.TestId;
            domainObjectToMapTo.Price = entity.Price;
            domainObjectToMapTo.HealthAssessmentTemplateId = entity.HafTemplateId;
            domainObjectToMapTo.WithPackagePrice = entity.WithPackagePrice;
            domainObjectToMapTo.GroupId = entity.GroupId;
            domainObjectToMapTo.ReimbursementRate = entity.ReimbursementRate;
            domainObjectToMapTo.IsTestReviewableByPhysician = entity.IsTestReviewableByPhysician;
            domainObjectToMapTo.RefundPrice = entity.RefundPrice;
            domainObjectToMapTo.PreQualificationQuestionTemplateId = entity.PreQualificationQuestionTemplateId;

            domainObjectToMapTo.ResultEntryTypeId = entity.ResultEntryTypeId;
        }

        protected override void MapEntityFields(EventTest domainObject, EventTestEntity entityToMapTo)
        {
            entityToMapTo.EventTestId = domainObject.Id;
            entityToMapTo.DateCreated = domainObject.DateCreated;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.TestId = domainObject.TestId;
            entityToMapTo.Price = domainObject.Price;
            if (domainObject.DateModified.HasValue)
            {
                entityToMapTo.DateModified = domainObject.DateModified.Value;
            }
            entityToMapTo.HafTemplateId = domainObject.HealthAssessmentTemplateId;
            entityToMapTo.WithPackagePrice = domainObject.WithPackagePrice;
            entityToMapTo.GroupId = domainObject.GroupId;
            entityToMapTo.ReimbursementRate = domainObject.ReimbursementRate;
            entityToMapTo.IsTestReviewableByPhysician = domainObject.IsTestReviewableByPhysician;
            entityToMapTo.RefundPrice = domainObject.RefundPrice;
            entityToMapTo.PreQualificationQuestionTemplateId = domainObject.PreQualificationQuestionTemplateId;
            entityToMapTo.Fields["PreQualificationQuestionTemplateId"].IsChanged = true;

            entityToMapTo.ResultEntryTypeId = domainObject.ResultEntryTypeId;
            entityToMapTo.Fields["ResultEntryTypeId"].IsChanged = true;
        }
    }
}