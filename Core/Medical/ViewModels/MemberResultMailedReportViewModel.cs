using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MemberResultMailedReportViewModel : ViewModelBase
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

        [DisplayName("Member Address")]
        public string MemberAddress { get; set; }

        [DisplayName("Member Results Mailed Date")]
        [Format("MM/dd/yyyy")]
        public DateTime ResultsMailedDate { get; set; }
    }
}
