using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class PcpAppointmentViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Member Id")]
        public string InsuranceId { get; set; }

        [DisplayName("HICN Number")]
        public string Hicn { get; set; }

        [DisplayName("MBI Number")]
        public string Mbi { get; set; }

        [DisplayName("IsEligible")]
        public string IsEligible { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomerTag { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Pod Name")]
        public string Pod { get; set; }

        [DisplayName("Pcp Name")]
        public string PcpName { get; set; }

        [DisplayName("Phone Number")]
        public string PcpPhoneNumber { get; set; }

        [DisplayName("Fax Number")]
        public string PcpFax { get; set; }

        [DisplayName("Appointment Date And Time")]
        public DateTime? AppointmentDateTime { get; set; }

        [DisplayName("Appointment Created On")]
        [Format("MM/dd/yyyy")]
        public DateTime? AppointmentCreatedOn { get; set; }

        [DisplayName("Appointment Created By")]
        public string AgentName { get; set; }

        [DisplayName("Appointment Modified On")]
        [Format("MM/dd/yyyy")]
        public DateTime? AppointmentModifiedOn { get; set; }

        [DisplayName("Appointment Modified By")]
        public string ModifiedByAgentName { get; set; }

        [DisplayName("PCP Dispositions")]
        public string PcpDisposition { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        [DisplayName("Dispositions Created On")]
        [Format("MM/dd/yyyy")]
        public DateTime? DispositionsCreatedOn { get; set; }

        [DisplayName("Dispositions Created By")]
        public string DispositionsCreatedBy { get; set; }
    }
}
