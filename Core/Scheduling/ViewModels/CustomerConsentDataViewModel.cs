using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerConsentDataViewModel : ViewModelBase
    {
        [DisplayName("AcesId")]
        public string AcesId { get; set; }

        [DisplayName("TelephoneNumber")]
        public string TelephoneNumber { get; set; }

        [DisplayName("ConsentType")]
        public string ConsentType { get; set; }

        [DisplayName("DateOfConsent")]
        [Format("MM/dd/yyyy hh:mm tt")]
        public DateTime? ConsentDateTime { get; set; }
    }
}
