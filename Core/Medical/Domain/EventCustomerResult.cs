using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    // TODO: This has to be completed just using fields which are currently required.
    public class EventCustomerResult : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public bool IsClinicalFormGenerated { get; set; }
        public bool IsResultPdfGenerated { get; set; }
        public bool IsPartial { get; set; }
        public int ResultState { get; set; }
        public long? ResultSummary { get; set; }

        public long? PathwayRecommendation { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public DateTime? RegenerationDate { get; set; }
        public long? RegeneratedBy { get; set; }
        public bool? IsFasting { get; set; }

        public bool IsRevertedToEvaluation { get; set; }
        public bool IsPennedBack { get; set; }

        public long? SignedOffBy { get; set; }
        public DateTime? SignedOffOn { get; set; }

        public long? VerifiedBy { get; set; }
        public DateTime? VerifiedOn { get; set; }

        public long? CodedBy { get; set; }
        public DateTime? CodedOn { get; set; }

        public DateTime? AcesApprovedOn { get; set; }
        public long? InvoiceDateUpdatedBy { get; set; }
        public bool IsIpResultGenerated { get; set; }

        public long? ChatPdfReviewedByPhysicianId { get; set; }
        public DateTime? ChatPdfReviewedByPhysicianDate { get; set; }
        public long? ChatPdfReviewedByOverreadPhysicianId { get; set; }
        public DateTime? ChatPdfReviewedByOverreadPhysicianDate { get; set; }
    }
}