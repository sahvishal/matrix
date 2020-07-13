using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class AppointmentsShowedViewModel : ViewModelBase
    {
        [Hidden]
        public long AgentId { get; set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }

        [DisplayName("Customers Showed")]
        public long AppointmentsShowed { get; set; }

        [DisplayName("Actual Bonus($)")]
        [Format("0.00")]
        public decimal ActualBonus { get; set; }
    }
}