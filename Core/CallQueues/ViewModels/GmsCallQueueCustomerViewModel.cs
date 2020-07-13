using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class GmsCallQueueCustomerViewModel:ViewModelBase
    {
        [DisplayName("Customer ID")]
        public long CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Home")]
        public string PhoneHome { get; set; }

        [DisplayName("Phone Office")]
        public string PhoneOffice { get; set; }

        [DisplayName("Phone Cell")]
        public string PhoneCell { get; set; }

        [DisplayName("Address Line1")]
        public string Address1 { get; set; }

        [DisplayName("Address Line2")]
        public string Address2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip")]
        public string Zip { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        //[DisplayName("Nearest Event Zips")]
        //public string NearestEventZips { get; set; }

        [DisplayName("Nearest Events")]
        public string NearestEvents { get; set; }

        [DisplayName("Caller Id")]
        public string CallerId { get; set; }

        [DisplayName("GMS Phone Number")]
        public string AdditionalField { get; set; }
    }
}
