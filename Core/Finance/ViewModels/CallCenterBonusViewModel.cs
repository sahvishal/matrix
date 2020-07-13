using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CallCenterBonusViewModel : ViewModelBase
    {
        [Hidden]
        public long AgentId { get; set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }

        [DisplayName("Total Calls")]
        public long TotalCalls { get; set; }

        [DisplayName("Booked Appointment")]
        public long BookedCustomers { get; set; }

        //[DisplayName("Expected Bonus($)")]
        //[Format("0.00")]
        //public decimal ExpectedBonus { get; set; }
    }
}