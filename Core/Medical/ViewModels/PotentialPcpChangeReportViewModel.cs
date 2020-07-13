using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PotentialPcpChangeReportViewModel : ViewModelBase
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

        [DisplayName("Existing Provider Full Name")]
        public string ExistingPcpFullName { get; set; }
        [DisplayName("Existing Provider Address 1 ")]
        public string ExistingPcpAddress1 { get; set; }
        [DisplayName("Existing Provider Address 2 ")]
        public string ExistingPcpAddress2 { get; set; }
        [DisplayName("Existing Provider City")]
        public string ExistingPcpCity { get; set; }
        [DisplayName("Existing Provider State")]
        public string ExistingPcpState { get; set; }
        [DisplayName("Existing Provider Zip")]
        public string ExistingPcpZip { get; set; }


        [DisplayName("New Provider Full Name")]
        public string NewPcpFullName { get; set; }
        [DisplayName("New Provider Address 1")]
        public string NewPcpAddress1 { get; set; }
        [DisplayName("New Provider Address 2")]
        public string NewPcpAddress2 { get; set; }
        [DisplayName("New Provider City")]
        public string NewPcpCity { get; set; }
        [DisplayName("New Provider State")]
        public string NewPcpState { get; set; }
        [DisplayName("New Provider Zip")]
        public string NewPcpZip { get; set; }

        [DisplayName("HF Comment")]
        public string HfComment { get; set; }
    }
}
