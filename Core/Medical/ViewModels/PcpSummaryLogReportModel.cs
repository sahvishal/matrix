using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpSummaryLogReportModel : ViewModelBase
    {
        [DisplayName("VENDOR_CODE")]
        public string VendorCode { get; set; }

        [DisplayName("MEDICARE_NO")]
        public string MedicareNumber { get; set; }

        [DisplayName("LINE_OF_BUSINESS")]
        public string LineOfBusiness { get; set; }

        [DisplayName("MBR_STATE")]
        public string MemberState { get; set; }

        [DisplayName("MBR_COUNTY")]
        public string MemberCounty { get; set; }

        [DisplayName("SEQ_MEMB_ID")]
        public string MemberID { get; set; }

        [DisplayName("SUBSCRIBER_ID")]
        public string SubscriberID { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime? DOB { get; set; }

        [DisplayName("GENDER")]
        public string Gender { get; set; }

        [DisplayName("MBR_FIRST_NAME")]
        public string MemberFirstName { get; set; }

        [DisplayName("MBR_LAST_NAME")]
        public string MemberLastName { get; set; }

        [DisplayName("PCP_FIRST_NAME")]
        public string PcpFirstName { get; set; }

        [DisplayName("PCP_LAST_NAME")]
        public string PcpLastName { get; set; }

        [DisplayName("PCP_PHONE_NUMBER")]
        public string PcpPhoneNumber { get; set; }

        [DisplayName("PCP_ADDRESS_1")]
        public string PcpAddress1 { get; set; }

        [DisplayName("PCP_ADDRESS_2")]
        public string PcpAddress2 { get; set; }

        [DisplayName("PCP_CITY")]
        public string PcpCity { get; set; }

        [DisplayName("PCP_STATE")]
        public string PcpState { get; set; }

        [DisplayName("PCP_ZIP")]
        public string PcpZIP { get; set; }

        [DisplayName("EVENT_DATE")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [Hidden]
        public long EventId { get; set; }

        [DisplayName("PCP_MAILED_DATE")]
        [Format("MM/dd/yyyy")]
        public DateTime? PcpMailedDate { get; set; }

        [DisplayName("RESULTS_FILE_NAME")]
        public string ResultFileName { get; set; }

    }
}
