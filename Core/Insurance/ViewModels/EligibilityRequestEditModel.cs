using System;
using System.ComponentModel;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibilityRequestEditModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime? Dob { get; set; }

        [DisplayName("Insurance Company")]
        public long InsuranceCompanyId { get; set; }
    }
}
