using Falcon.App.Core.Application.ViewModels;
using System.ComponentModel;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class DisqualifiedTestReportViewModel : ViewModelBase
    {
        [DisplayName("Patient Id")]
        public long CustomerId { get; set; }

        public long EventId { get; set; }

        public string HealthPlan { get; set; }

        [DisplayName("Test Rejected")]
        public string TestName { get; set; }

        public string Reason { get; set; }
    }
}
