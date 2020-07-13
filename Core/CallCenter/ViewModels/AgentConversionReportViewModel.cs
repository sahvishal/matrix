using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class AgentConversionReportViewModel : ViewModelBase
    {
        [Hidden]
        public long Id { get; set; }

        [DisplayName("Agent")]
        public string AgentName { get; set; }

        [DisplayName("Outbound")]
        public long OutboundCalls { get; set; }

        [DisplayName("Connections")]
        public long TalkedToPatient { get; set; }

        [DisplayName("Booked")]
        public long BookedAppointment { get; set; }

        [DisplayName("Conversion")]
        public string Conversion { get; set; }
    }
}
