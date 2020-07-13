using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [Serializable]
    public class RegistrationFlowModel
    {
        public string GuId { get; set; }

        public long PreQualificationResultId { get; set; }

        public long CallId { get; set; }

        public long ProspectCustomerId { get; set; }

        public long CustomerId { get; set; }

        public long EventId { get; set; }

        public long PackageId { get; set; }

        public IEnumerable<long> TestIds { get; set; }

        public IEnumerable<long> AddOnTestIds { get; set; }

        public IEnumerable<long> AppointmentSlotIds { get; set; }

        public long ProductId { get; set; }

        public long ShippingOptionId { get; set; }

        public long ShippingDetailId { get; set; }

        public long ShippingAddressId { get; set; }

        public long SourceCodeId { get; set; }

        public string SourceCode { get; set; }

        public decimal SourceCodeAmount { get; set; }

        public decimal PackageCost { get; set; }

        public decimal TotalAmount { get; set; }

        public string MarketingSource { get; set; }

        public string CallSourceCode { get; set; }

        public string CreditCardName { get; set; }
        public string CreditCardNo { get; set; }
        public int CreditCardType { get; set; }
        public string CreditCardExpiry { get; set; }
        public string CreditCardCvv { get; set; }

        public int ScreeningTime { get; set; }

        public long EligibilityId { get; set; }

        public bool IsTestCoveredByInsurance { get; set; }

        public long ChargeCardId { get; set; }

        public long CallQueueCustomerId { get; set; }

        public long CampaignId { get; set; }

        public long? AwvVisitId { get; set; }

        public long AttempId { get; set; }

        public bool IsGmsCall { get; set; }

        public bool IsRetest { get; set; }

        public bool CanSaveConsentInfo { get; set; }

        public bool IsViciCall { get; set; }

        public bool SingleTestOverride { get; set; }

        public string CallCenterScriptUrl { get; set; }

        public string QuestionIdAnswerTestId { get; set; }

        public string DisqualifiedTest { get; set; }

        public IEnumerable<long> DependentDisqualifiedTests { get; set; }
    }
}
