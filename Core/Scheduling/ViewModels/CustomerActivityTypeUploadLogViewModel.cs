using Falcon.App.Core.Application.ViewModels;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerActivityTypeUploadLogViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public string CustomerId { get; set; }


        [DisplayName("Aces Id")]
        public string AcesId { get; set; }

        [DisplayName("Activity")]
        public string ActivityType { get; set; }

        public string ErrorMessage { get; set; }
    }
}
