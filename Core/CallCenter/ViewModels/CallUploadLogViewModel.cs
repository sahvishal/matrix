using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallUploadLogViewModel : ViewModelBase
    {
        [DisplayName("Customer ID")]
        public string CustomerId { get; set; }
        [DisplayName("Outreach Type")]
        public string OutreachType { get; set; }

        [DisplayName("Outreach Date")]
        public string OutreachDate { get; set; }

        [DisplayName("Outreach Time")]
        public string OutreachTime { get; set; }

        [DisplayName("Outcome")]
        public string Outcome { get; set; }

        [DisplayName("Disposition")]
        public string Disposition { get; set; }

        [DisplayName("Refusal Reason")]
        public string Reason { get; set; }

        [DisplayName("Event ID")]
        public string EventId { get; set; }

        [DisplayName("Campaign Name")]
        public string CampaignName { get; set; }

        [DisplayName("Direct Mail Type")]
        public string DirectMailType { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("UserName")]
        public string UserName { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        [DisplayName("Is Invalid Address")]
        public string IsInvalidAddress { get; set; }

        [DisplayName("Error Message")]
        public string ErrorMessage { get; set; }
    }
}
