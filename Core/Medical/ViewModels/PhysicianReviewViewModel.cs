using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianReviewViewModel : ViewModelBase
    {
        [DisplayName("Physician Name")]
        public string PhysicianName { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        public string Vehicle { get; set; }

        [DisplayName("Screening Package + Test(s)")]
        public string Package { get; set; }

        [DisplayName("Reviewed On")]
        [Format("MM/dd/yyyy")]
        public DateTime ReviewDate { get; set; }

        [DisplayName("Review Duration")]
        public string ReviewDuration { get; set; }

        [DisplayName("Is Critical")]
        public bool IsCritical { get; set; }

        public string Study { get; set; }
        
        [Hidden]
        public bool IsPdfGenerated { get; set; }
        
    }
}
