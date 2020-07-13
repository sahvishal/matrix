using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomTestPerformedViewModel : ViewModelBase
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("HICN")]
        public string HICN { get; set; }

        [DisplayName("Date Of Birth")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Market")]
        public string Market { get; set; }

        [DisplayName("Testing Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Services Performed")]
        public string ServicesPerformed { get; set; }
    }
}