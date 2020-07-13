using System;

namespace Falcon.App.Core.OutboundReport.ViewModels
{
    public class PatientDetailReportViewModel
    {
        public string SiteName { get; set; }

        public long Id { get; set; }

        public string CmsHicn { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime AwvDate { get; set; }

        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string PrimaryCareMd { get; set; }
        public string Providers { get; set; }
        public string Medications { get; set; }
        public string Allergies { get; set; }

        public string ESignature { get; set; }

        public string MedicalRecordNo { get; set; }

        public string MaPlan { get; set; }
        public string MaPlanMemberId { get; set; }
        public string AwvStatus { get; set; }

        public string SignedDateTime { get; set; }
        public string MetalType { get; set; }
        public string SignedByNpi { get; set; }
    }
}
