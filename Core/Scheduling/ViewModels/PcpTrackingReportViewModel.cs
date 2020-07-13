using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class PcpTrackingReportViewModel : ViewModelBase
    {
        [DisplayName("Patient ID")]
        public long PatientId { get; set; }

        [DisplayName("Name")]
        public string PatientName { get; set; }

        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        [DisplayName("PCP Name")]
        public string PcpName { get; set; }

        [DisplayName("PCP Address")]
        public string PcpAddress { get; set; }

        [DisplayName("PCP Email")]
        public string PcpEmail { get; set; }

        [DisplayName("PCP Phone")]
        public string PcpPhone { get; set; }

        [DisplayName("Is Updated")]
        public string IsUpdated { get; set; }

        [DisplayName("New PCP Name")]
        public string NewPcpName { get; set; }

        [DisplayName("New PCP Address")]
        public string NewPcpAddress { get; set; }

        [DisplayName("New PCP Email")]
        public string NewPcpEmail { get; set; }

        [DisplayName("New PCP Phone")]
        public string NewPcpPhone { get; set; }
    }
}
