
using System.ComponentModel;
namespace Falcon.App.Core.Medical.ViewModels
{
    public class PatientWithNoCustomTagViewModel
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }
        [DisplayName("Pre-approved Test")]
        public string PreapprovedTest { get; set; }
        [DisplayName("Corporate Tag")]
        public string CorporateTag { get; set; }
    }
}
