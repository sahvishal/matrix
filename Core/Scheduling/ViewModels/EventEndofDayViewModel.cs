using System;
using System.Configuration;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventEndofDayViewModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }

        public EndofDayStatus CustomerInfo { get; set; }
        public EndofDayStatus TestConductedBy { get; set; }
        public EndofDayStatus HealthAssesmentForm { get; set; }
        public EndofDayStatus CheckInTime { get; set; }
        public EndofDayStatus CheckOutTime { get; set; }
        public EndofDayStatus IsPaid { get; set; }
        public EndofDayStatus SignedHipaa { get; set; }
        public EndofDayStatus SignedPartnerRelease { get; set; }

        public EndofDayStatus CholesterolStatus { get; set; }
        public EndofDayStatus GlucoseStatus { get; set; }

        public EndofDayStatus HbA1C { get; set; }
        public EndofDayStatus BloodPressure { get; set; }
        public EndofDayStatus Kyn { get; set; }
        public EndofDayStatus HKyn { get; set; }
        public EndofDayStatus HospitalFacilityStatus { get; set; }
        // public EndofDayStatus PcpConsentStatus { get; set; }
        public EndofDayStatus MspFormFilled { get; set; }
        public EndofDayStatus SignedInsuranceRelease { get; set; }
        public EndofDayStatus HPyloriStatus { get; set; }
        public EndofDayStatus HemoglobinStatus { get; set; }

        public EndofDayStatus QualityMeasuresStatus { get; set; }
        public EndofDayStatus Phq9Status { get; set; }
        public EndofDayStatus FocAttestation { get; set; }
        public EndofDayStatus Ifobt { get; set; }

        public EndofDayStatus MybioStatus { get; set; }
        public EndofDayStatus GiftCardStatus { get; set; }

        public bool IsHkynPurchased { get; set; }

        public bool IsKynPurchased { get; set; }

        public bool IsComplete
        {
            get
            {
                return
                    !(CustomerInfo == EndofDayStatus.Missing || TestConductedBy == EndofDayStatus.Missing || HealthAssesmentForm == EndofDayStatus.Missing || CheckInTime == EndofDayStatus.Missing || CheckOutTime == EndofDayStatus.Missing ||
                    IsPaid == EndofDayStatus.Missing || SignedHipaa == EndofDayStatus.Missing || SignedPartnerRelease == EndofDayStatus.Missing || HbA1C == EndofDayStatus.Missing || BloodPressure == EndofDayStatus.Missing ||
                      Kyn == EndofDayStatus.Missing || HospitalFacilityStatus == EndofDayStatus.Missing || MspFormFilled == EndofDayStatus.Missing || SignedInsuranceRelease == EndofDayStatus.Missing || CholesterolStatus == EndofDayStatus.Missing ||
                      GlucoseStatus == EndofDayStatus.Missing || HPyloriStatus == EndofDayStatus.Missing || HemoglobinStatus == EndofDayStatus.Missing || QualityMeasuresStatus == EndofDayStatus.Missing || Phq9Status == EndofDayStatus.Missing ||
                      FocAttestation == EndofDayStatus.Missing || Ifobt == EndofDayStatus.Missing || HKyn == EndofDayStatus.Missing || MybioStatus == EndofDayStatus.Missing ||
                      (EventDate >= Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EodGcCutoffDate")).Date && GiftCardStatus == EndofDayStatus.Missing)); //||PcpConsentStatus == EndofDayStatus.Missing
            }
        }

        public bool IsKynComplete
        {
            get
            {
                return !(CustomerInfo == EndofDayStatus.Missing || TestConductedBy == EndofDayStatus.Missing || HealthAssesmentForm == EndofDayStatus.Missing || BloodPressure == EndofDayStatus.Missing || Kyn == EndofDayStatus.Missing);
            }
        }

        public bool IsHKynComplete
        {
            get
            {
                return !(CustomerInfo == EndofDayStatus.Missing || TestConductedBy == EndofDayStatus.Missing || HealthAssesmentForm == EndofDayStatus.Missing || BloodPressure == EndofDayStatus.Missing || HKyn == EndofDayStatus.Missing);
            }
        }

        public bool IsMyBioStatusComplete
        {
            get
            {
                return !(CustomerInfo == EndofDayStatus.Missing || TestConductedBy == EndofDayStatus.Missing || BloodPressure == EndofDayStatus.Missing || MybioStatus == EndofDayStatus.Missing);
            }
        }

        public DateTime EventDate { get; set; }  //Added to add check for GC required to evaluate IsComplete. if event date is greater or equal to Cutoff date , GC must be marked YES or NO
    }

    public enum EndofDayStatus
    {
        Missing = 1,
        Complete,
        NotApplicable
    }

}