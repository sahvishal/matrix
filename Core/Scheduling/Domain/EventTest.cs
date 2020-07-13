using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventTest : DomainObjectBase, IOrderable
    {
        public long EventId { get; set; }
        public long TestId { get; set; }

        public Test Test { get; set; }
        
        public decimal Price { get; set; }

        public string Description { get { return string.Format("Test for {0:C} ", Price); } }

        public OrderItemType OrderItemType
        {
            get
            {
                return OrderItemType.EventTestItem;
            }
        }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public long? HealthAssessmentTemplateId { get; set; }

        public decimal WithPackagePrice { get; set; }

        public long GroupId { get; set; }

        public decimal ReimbursementRate { get; set; }
        public bool? IsTestReviewableByPhysician { get; set; }

        public decimal RefundPrice { get; set; }
        public bool ShowInAlaCarte { get; set; }
        public long Gender { get; set; }
        public long? PreQualificationQuestionTemplateId { get; set; }

        public long? ResultEntryTypeId { get; set; }

        public EventTest()
        { }

        public EventTest(long eventTestId)
            : base(eventTestId)
        { }

    }
}