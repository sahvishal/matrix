using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class NonTargetableReportModel : ViewModelBase
    {
        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("GMPI")]
        public string Gmpi { get; set; }

        [DisplayName("Member First Name")]
        public string FirstName { get; set; }

        [DisplayName("Member Last Name")]
        public string LastName { get; set; }

        [DisplayName("Member Phone")]
        public string Phone { get; set; }

        [DisplayName("Member Address 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Member Address 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Member City")]
        public string City { get; set; }

        [DisplayName("Member State")]
        public string State { get; set; }

        [DisplayName("Member Zip")]
        public string Zip { get; set; }

        [DisplayName("Market")]
        public string Market { get; set; }

        [DisplayName("HF Comment")]
        public string HfComment { get; set; }
    }
}
