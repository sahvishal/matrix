using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class UniversalProviderViewModel : ViewModelBase
    {
        [DisplayName("ClientID")]
        public string ClientID { get; set; }

        [DisplayName("ClientProviderId")]
        public string ClientProviderId { get; set; }

        [DisplayName("GroupID")]
        public string GroupId { get; set; }

        [DisplayName("GroupName")]
        public string GroupName { get; set; }

        [DisplayName("PAR")]
        public string Par { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("MiddleName")]
        public string MiddleName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Suffix")]
        public string Suffix { get; set; }

        [DisplayName("TaxonomyCode")]
        public string TaxonomyCode { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("NPI")]
        public string Npi { get; set; }

        [DisplayName("Street1")]
        public string Street1 { get; set; }

        [DisplayName("Street2")]
        public string Street2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip")]
        public string Zip { get; set; }

        [DisplayName("MailingStreet1")]
        public string MailingStreet1 { get; set; }

        [DisplayName("MailingStreet2")]
        public string MailingStreet2 { get; set; }

        [DisplayName("MailingCity")]
        public string MailingCity { get; set; }

        [DisplayName("MailingState")]
        public string MailingState { get; set; }

        [DisplayName("MailingZip")]
        public string MailingZip { get; set; }

        [DisplayName("OfficeTelephoneNumber")]
        public string TelephoneNumber1 { get; set; }

        [DisplayName("FaxTelephoneNumber")]
        public string FaxTelephoneNumber { get; set; }

        [DisplayName("SecureFaxTelephoneNumber")]
        public string SecureFaxTelephoneNumber { get; set; }

        [DisplayName("EmailAddress")]
        public string EmailAddress { get; set; }

        [DisplayName("WebSiteAddress")]
        public string WebSiteAddress { get; set; }
    }
}