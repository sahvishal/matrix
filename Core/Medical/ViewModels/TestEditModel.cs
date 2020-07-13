using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long TestId { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Price (In package)")]
        public decimal PackagePrice { get; set; }

        [DisplayName("Refund Price")]
        public decimal RefundPrice { get; set; }

        [DisplayName("Refund Price (In package)")]
        public decimal PackageRefundPrice { get; set; }

        [DisplayName("Relative Order")]
        public int RelativeOrder { get; set; }

        [DisplayName("CPT Code")]
        public string CPTCode { get; set; }

        public bool IsRecordable { get; set; }

        public bool IsReviewable { get; set; }

        public bool ShowinCustomerPdf { get; set; }

        [DisplayName("Minimum Age")]
        public int? MinAge { get; set; }

        [DisplayName("Maximum Age")]
        public int? MaxAge { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public IEnumerable<long> AvailableToRoleIds { get; set; }

        public IEnumerable<OrderedPair<long, string>> Roles { get; set; }

        [DisplayName("Diagnosis Code")]
        public string DiagnosisCode { get; set; }

        public bool ShowInAlaCarte { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        [DisplayName("Screening Time")]
        public int ScreeningTime { get; set; }

        [DisplayName("Health Assessment Template")]
        public long? HealthAssessmentTemplateId { get; set; }

        public bool IsSelectedByDefaultforEvent { get; set; }

        public bool IsTestCoveredByInsurance { get; set; }

        [DisplayName("Billing Account")]
        public long? BillingAccountId { get; set; }

        public long Gender { get; set; }

        [DisplayName("Group")]
        public long GroupId { get; set; }

        [DisplayName("Reimbursement Rate")]
        public decimal ReimbursementRate { get; set; }

        [DisplayName("With Package Price")]
        public decimal WithPackagePrice { get; set; }

        [DisplayName("DefaultSelectionForPackage")]
        public bool IsDefaultSelectionForPackage { get; set; }

        [DisplayName("Default Selection For Order")]
        public bool IsDefaultSelectionForOrder { get; set; }

        [DisplayName("Media Url")]
        public string MediaUrl { get; set; }

        [DisplayName("Is Billable To Health Plan")]
        public bool? IsBillableToHealthPlan { get; set; }

        [DisplayName("Pre Qualification Question Template")]
        public long? PreQualificationQuestionTemplateId { get; set; }

        [DisplayName("Result Entry Type")]
        public long? ResultEntryTypeId { get; set; }

        [DisplayName("CHAT Start Date")]
        public DateTime? ChatStartDate { get; set; }

        public bool NotValidateChatStartDate { get; set; }
    }
}
