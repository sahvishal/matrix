using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Users.ViewModels
{
    public class PatientBasicInfoViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string StateCode { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
        public string Race { get; set; }
        public string Hicn { get; set; }
        public string MedicareAdvantageNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public string MemberId { get; set; }
        public string Tag { get; set; }

        public string Height { get; set; }
        public string Weight { get; set; }

        public IEnumerable<string> PreapprovedTestList { get; set; }

        public string Mrn { get; set; }
    }
}
