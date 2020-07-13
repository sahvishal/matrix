using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class BiWeeklyMicroAlbuminFobtReportViewModel : ViewModelBase
    {
        [DisplayName("Market")]
        public string Market { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("GMPI")]
        public string Gmpi { get; set; }

        [DisplayName("Member First Name")]
        public string FirstName { get; set; }

        [DisplayName("Member Last Name")]
        public string LastName { get; set; }

        [DisplayName("Event Date")]
        public string EventDate { get; set; }

        [DisplayName("FOBT Kit")]
        public string FobtKit { get; set; }

        [DisplayName("Microalbumin Kit")]
        public string MicroalbuminKit { get; set; }

        [DisplayName("Lab Account Number")]
        public string LabAccountNumber { get; set; }

        [DisplayName("HF Comment")]
        public string HfComment { get; set; }
    }
}
