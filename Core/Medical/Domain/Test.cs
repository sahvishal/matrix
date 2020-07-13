using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class Test : DomainObjectBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public OrderItemType OrderItemType
        {
            get { return OrderItemType.EventTestItem; }
        }

        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public decimal Price { get; set; }
        public decimal PackagePrice { get; set; }
        public decimal RefundPrice { get; set; }
        public decimal PackageRefundPrice { get; set; }

        public string Alias { get; set; }
        public int RelativeOrder { get; set; }

        public string CPTCode { get; set; }

        public bool IsRecordable { get; set; }
        public bool IsReviewable { get; set; }
        public bool ShowinCustomerPdf { get; set; }

        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public IEnumerable<long> AvailableToRoleIds { get; set; }

        public string DiagnosisCode { get; set; }

        public bool ShowInAlaCarte { get; set; }

        public long? HealthAssessmentTemplateId { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        public int ScreeningTime { get; set; }

        public bool IsSelectedByDefaultforEvent { get; set; }

        public decimal WithPackagePrice { get; set; }

        public long Gender { get; set; }

        public long GroupId { get; set; }

        public decimal ReimbursementRate { get; set; }

        public bool IsDefaultSelectionForPackage { get; set; }

        public bool IsDefaultSelectionForOrder { get; set; }

        public string MediaUrl { get; set; }

        public bool? IsBillableToHealthPlan { get; set; }

        public long? PreQualificationQuestionTemplateId { get; set; }

        public long? ResultEntryTypeId { get; set; }

        public DateTime? ChatStartDate { get; set; }

        public Test()
        { }

        public Test(long testId)
            : base(testId)
        { }

    }
}