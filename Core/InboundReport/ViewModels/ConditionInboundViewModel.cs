using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class ConditionInboundViewModel : ViewModelBase
    {
        [DisplayName("Tenant_Id")]
        public string TenantId { get; set; }
        [DisplayName("Client_Id")]
        public string ClientId { get; set; }
        [DisplayName("Campaign_Id")]
        public string CampaignId { get; set; }
        [DisplayName("Individual_ID_Number")]
        public string IndividualIdNumber { get; set; }
        [DisplayName("Contract_Number")]
        public string ContractNumber { get; set; }
        [DisplayName("Contract_Person_Number")]
        public string ContractPersonNumber { get; set; }
        [DisplayName("Consumer_Id")]
        public string ConsumerId { get; set; }
        [DisplayName("Vendor_Person_Id")]
        public string VendorPersonId { get; set; }

        [DisplayName("Condition_Id")]
        public string ConditionId { get; set; }
        [DisplayName("Condition_Name")]
        public string ConditionName { get; set; }
        [DisplayName("Condition_Diagnosis_Code")]
        public string ConditionDiagnosisCode { get; set; }
        [DisplayName("Condition_ICD_Indicator")]
        public string ConditionIcdIndicator { get; set; }

        public string Attribute { get; set; }
        [DisplayName("Attribute_Value")]
        public string AttributeValue { get; set; }

        [DisplayName("Drug_Name")]
        public string DrugName { get; set; }
        [DisplayName("NDC_Code")]
        public string NdcCode { get; set; }

        [DisplayName("Med_Taken_Current")]
        public string MedTakenCurrent { get; set; }
        [DisplayName("Med_Frequency")]
        public string MedFrequency { get; set; }
        [DisplayName("Med_Dosage")]
        public string MedDosage { get; set; }

        [DisplayName("Treatment_Id")]
        public string TreatmentId { get; set; }
        [DisplayName("Treatment_Name")]
        public string TreatmentName { get; set; }
        [DisplayName("Last_Treatment")]
        public string LastTreatment { get; set; }

        [DisplayName("Test_Id")]
        public string TestId { get; set; }
        [DisplayName("Test_Name")]
        public string TestName { get; set; }
        [DisplayName("Test_Timeframe")]
        public string TestTimeframe { get; set; }
        [DisplayName("Test_Results")]
        public string TestResults { get; set; }

        [DisplayName("Condition_Physician_Full_Name")]
        public string ConditionPhysicianFullName { get; set; }
        [DisplayName("Condition_Physician_Addr_Line1")]
        public string ConditionPhysicianAddrLine1 { get; set; }
        [DisplayName("Condition_Physician_Addr_Line2")]
        public string ConditionPhysicianAddrLine2 { get; set; }
        [DisplayName("Condition_Physician_City")]
        public string ConditionPhysicianCity { get; set; }
        [DisplayName("Condition_Physician_State")]
        public string ConditionPhysicianState { get; set; }
        [DisplayName("Condition_Physician_Zip_Code")]
        public string ConditionPhysicianZipCode { get; set; }

        [DisplayName("Status_of_Coding")]
        public string StatusOfCoding { get; set; }
        [DisplayName("Medical_Code")]
        public string MedicalCode { get; set; }
        [DisplayName("Medical_Code_Type")]
        public string MedicalCodeType { get; set; }
        [DisplayName("Medical_Code_Service_Date")]
        public string MedicalCodeServiceDate { get; set; }
        [DisplayName("Care_Code_Lab_Type")]
        public string CareCodeLabType { get; set; }
        [DisplayName("Care_Code_Lab_Desc")]
        public string CareCodeLabDesc { get; set; }
    }
}
