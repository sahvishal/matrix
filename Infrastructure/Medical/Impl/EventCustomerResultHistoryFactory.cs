using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class EventCustomerResultHistoryFactory : IEventCustomerResultHistoryFactory
    {
        public EventCustomerResultHistoryEntity CreateEnity(EventCustomerResultEntity entity)
        {
            return new EventCustomerResultHistoryEntity
            {
                EventCustomerResultId = entity.EventCustomerResultId,
                CustomerId = entity.CustomerId,
                EventId = entity.EventId,
                IsClinicalFormGenerated = entity.IsClinicalFormGenerated,
                IsResultPdfgenerated = entity.IsResultPdfgenerated,
                IsPartial = entity.IsPartial,
                ResultState = entity.ResultState,
                ResultSummary = entity.ResultSummary,
                PathwayRecommendation = entity.PathwayRecommendation,
                RegenerationDate = entity.RegenerationDate,
                RegeneratedBy = entity.RegeneratedBy,
                IsFasting = entity.IsFasting,
                DateCreated = entity.DateCreated,
                CreatedByOrgRoleUserId = entity.CreatedByOrgRoleUserId,

                DateModified = entity.DateModified,
                ModifiedByOrgRoleUserId = entity.ModifiedByOrgRoleUserId,

                IsRevertedToEvaluation = entity.IsRevertedToEvaluation,
                IsPennedBack = entity.IsPennedBack,

                SignedOffBy = entity.SignedOffBy,
                SignedOffOn = entity.SignedOffOn,

                VerifiedBy = entity.VerifiedBy,
                VerifiedOn = entity.VerifiedOn,

                CodedBy = entity.CodedBy,
                CodedOn = entity.CodedOn,

                AcesApprovedOn = entity.AcesApprovedOn,
                InvoiceDateUpdatedBy = entity.InvoiceDateUpdatedBy,
                IsIpResultGenerated = entity.IsIpResultGenerated,

                ChatPdfReviewedByPhysicianId = entity.ChatPdfReviewedByPhysicianId,
                ChatPdfReviewedByPhysicianDate = entity.ChatPdfReviewedByPhysicianDate,
                ChatPdfReviewedByOverreadPhysicianId = entity.ChatPdfReviewedByOverreadPhysicianId,
                ChatPdfReviewedByOverreadPhysicianDate = entity.ChatPdfReviewedByOverreadPhysicianDate
            };
        }

        public EventCustomerResultHistory CreateDomain(EventCustomerResult domain)
        {
            return new EventCustomerResultHistory
            {

                EventCustomerResultId = domain.Id,
                CustomerId = domain.CustomerId,
                EventId = domain.EventId,
                IsClinicalFormGenerated = domain.IsClinicalFormGenerated,
                IsResultPdfGenerated = domain.IsResultPdfGenerated,
                IsPartial = domain.IsPartial,
                ResultState = domain.ResultState,
                ResultSummary = domain.ResultSummary,
                PathwayRecommendation = domain.PathwayRecommendation,
                RegenerationDate = domain.RegenerationDate,
                RegeneratedBy = domain.RegeneratedBy,
                IsFasting = domain.IsFasting,
                DataRecorderMetaData = domain.DataRecorderMetaData,

                IsRevertedToEvaluation = domain.IsRevertedToEvaluation,
                IsPennedBack = domain.IsPennedBack,

                SignedOffBy = domain.SignedOffBy,
                SignedOffOn = domain.SignedOffOn,

                VerifiedBy = domain.VerifiedBy,
                VerifiedOn = domain.VerifiedOn,

                CodedBy = domain.CodedBy,
                CodedOn = domain.CodedOn,

                AcesApprovedOn = domain.AcesApprovedOn,
                InvoiceDateUpdatedBy = domain.InvoiceDateUpdatedBy,
                IsIpResultGenerated = domain.IsIpResultGenerated,

                ChatPdfReviewedByPhysicianId = domain.ChatPdfReviewedByPhysicianId,
                ChatPdfReviewedByPhysicianDate = domain.ChatPdfReviewedByPhysicianDate,
                ChatPdfReviewedByOverreadPhysicianId = domain.ChatPdfReviewedByOverreadPhysicianId,
                ChatPdfReviewedByOverreadPhysicianDate = domain.ChatPdfReviewedByOverreadPhysicianDate
            };
        }
    }
}