using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Application;

namespace Falcon.App.Infrastructure.Mappers.Screening
{
    [DefaultImplementation(Interface = typeof(IMapper<EventCustomerResult, EventCustomerResultEntity>))]
    public class EventCustomerResultMapper : DomainEntityMapper<EventCustomerResult, EventCustomerResultEntity>
    {
        protected override void MapDomainFields(EventCustomerResultEntity entity, EventCustomerResult domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventCustomerResultId;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.IsClinicalFormGenerated = entity.IsClinicalFormGenerated;
            domainObjectToMapTo.IsResultPdfGenerated = entity.IsResultPdfgenerated;
            domainObjectToMapTo.IsPartial = entity.IsPartial;
            domainObjectToMapTo.ResultState = entity.ResultState;
            domainObjectToMapTo.ResultSummary = entity.ResultSummary;
            domainObjectToMapTo.PathwayRecommendation = entity.PathwayRecommendation;
            domainObjectToMapTo.RegenerationDate = entity.RegenerationDate;
            domainObjectToMapTo.RegeneratedBy = entity.RegeneratedBy;
            domainObjectToMapTo.IsFasting = entity.IsFasting;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(entity.CreatedByOrgRoleUserId), entity.DateCreated, entity.DateModified)
                                                           {
                                                               DataRecorderModifier = entity.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.ModifiedByOrgRoleUserId.Value) : null
                                                           };
            domainObjectToMapTo.IsRevertedToEvaluation = entity.IsRevertedToEvaluation;
            domainObjectToMapTo.IsPennedBack = entity.IsPennedBack;

            domainObjectToMapTo.SignedOffBy = entity.SignedOffBy;
            domainObjectToMapTo.SignedOffOn = entity.SignedOffOn;

            domainObjectToMapTo.VerifiedBy = entity.VerifiedBy;
            domainObjectToMapTo.VerifiedOn = entity.VerifiedOn;

            domainObjectToMapTo.CodedBy = entity.CodedBy;
            domainObjectToMapTo.CodedOn = entity.CodedOn;

            domainObjectToMapTo.AcesApprovedOn = entity.AcesApprovedOn;
            domainObjectToMapTo.InvoiceDateUpdatedBy = entity.InvoiceDateUpdatedBy;
            domainObjectToMapTo.IsIpResultGenerated = entity.IsIpResultGenerated;

            domainObjectToMapTo.ChatPdfReviewedByPhysicianId = entity.ChatPdfReviewedByPhysicianId;
            domainObjectToMapTo.ChatPdfReviewedByPhysicianDate = entity.ChatPdfReviewedByPhysicianDate;
            domainObjectToMapTo.ChatPdfReviewedByOverreadPhysicianId = entity.ChatPdfReviewedByOverreadPhysicianId;
            domainObjectToMapTo.ChatPdfReviewedByOverreadPhysicianDate = entity.ChatPdfReviewedByOverreadPhysicianDate;
        }

        protected override void MapEntityFields(EventCustomerResult domainObject, EventCustomerResultEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerResultId = domainObject.Id;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.IsClinicalFormGenerated = domainObject.IsClinicalFormGenerated;
            entityToMapTo.IsResultPdfgenerated = domainObject.IsResultPdfGenerated;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.PathwayRecommendation = domainObject.PathwayRecommendation;
            entityToMapTo.IsFasting = domainObject.IsFasting;
            entityToMapTo.ResultState = domainObject.ResultState > 0 ? domainObject.ResultState : (int)TestResultStateNumber.NoResults;
            entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified.HasValue
                                             ? domainObject.DataRecorderMetaData.DateModified.Value
                                             : DateTime.Now;

            entityToMapTo.ModifiedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderModifier == null
                                                        ? null
                                                        : (long?)domainObject.DataRecorderMetaData.DataRecorderModifier.Id;

            entityToMapTo.RegenerationDate = domainObject.RegenerationDate;
            entityToMapTo.RegeneratedBy = domainObject.RegeneratedBy;
            entityToMapTo.IsRevertedToEvaluation = domainObject.IsRevertedToEvaluation;
            entityToMapTo.IsPennedBack = domainObject.IsPennedBack;

            entityToMapTo.SignedOffBy = domainObject.SignedOffBy;
            entityToMapTo.Fields["SignedOffBy"].IsChanged = true;

            entityToMapTo.SignedOffOn = domainObject.SignedOffOn;
            entityToMapTo.Fields["SignedOffOn"].IsChanged = true;

            entityToMapTo.VerifiedBy = domainObject.VerifiedBy;
            entityToMapTo.Fields["VerifiedBy"].IsChanged = true;

            entityToMapTo.VerifiedOn = domainObject.VerifiedOn;
            entityToMapTo.Fields["VerifiedOn"].IsChanged = true;

            entityToMapTo.CodedBy = domainObject.CodedBy;
            entityToMapTo.Fields["CodedBy"].IsChanged = true;

            entityToMapTo.CodedOn = domainObject.CodedOn;
            entityToMapTo.Fields["CodedOn"].IsChanged = true;

            entityToMapTo.AcesApprovedOn = domainObject.AcesApprovedOn;
            entityToMapTo.Fields["AcesApprovedOn"].IsChanged = true;

            entityToMapTo.InvoiceDateUpdatedBy = domainObject.InvoiceDateUpdatedBy;
            entityToMapTo.Fields["InvoiceDateUpdatedBy"].IsChanged = true;

            entityToMapTo.IsIpResultGenerated = domainObject.IsIpResultGenerated;

            entityToMapTo.ChatPdfReviewedByPhysicianId = domainObject.ChatPdfReviewedByPhysicianId;
            entityToMapTo.ChatPdfReviewedByPhysicianDate = domainObject.ChatPdfReviewedByPhysicianDate;
            entityToMapTo.ChatPdfReviewedByOverreadPhysicianId = domainObject.ChatPdfReviewedByOverreadPhysicianId;
            entityToMapTo.ChatPdfReviewedByOverreadPhysicianDate = domainObject.ChatPdfReviewedByOverreadPhysicianDate;
            entityToMapTo.Fields["ChatPdfReviewedByPhysicianId"].IsChanged = true;
            entityToMapTo.Fields["ChatPdfReviewedByPhysicianDate"].IsChanged = true;
            entityToMapTo.Fields["ChatPdfReviewedByOverreadPhysicianId"].IsChanged = true;
            entityToMapTo.Fields["ChatPdfReviewedByOverreadPhysicianDate"].IsChanged = true;
        }
    }
}