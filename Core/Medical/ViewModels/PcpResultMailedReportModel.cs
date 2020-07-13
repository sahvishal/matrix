using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpResultMailedReportModel: ViewModelBase
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("Date of Birth")]
        [Format("MM/dd/yyyy")]
        public DateTime? Dob { get; set; }

        public string Market { get; set; }

        [DisplayName("PCP Name")]
        public string PcpName { get; set; }

        [DisplayName("PCP Address")]
        public string PcpAddress { get; set; }

        [DisplayName("PCP Phone Number")]
        public string PcpPhoneNumber { get; set; }

        [DisplayName("PCP Results Mailed Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? PcpResultMailedDate { get; set; }
    }
}
