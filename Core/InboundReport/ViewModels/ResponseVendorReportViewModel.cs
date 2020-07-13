using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class ResponseVendorReportViewModel : ViewModelBase
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
        [DisplayName("Campaign_Type")]
        public string CampaignType { get; set; }
        [DisplayName("Chart_Number")]
        public string ChartNumber { get; set; }

        [DisplayName("First_Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle_Initial")]
        public string MiddleInitial { get; set; }
        [DisplayName("Last_Name")]
        public string LastName { get; set; }
        [DisplayName("Gender_Code")]
        public string GenderCode { get; set; }
        [DisplayName("Birth_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? BirthDate { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        [DisplayName("Eligibility_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EligibilityDate { get; set; }

        [DisplayName("Care_Referral")]
        public string CareReferral { get; set; }
        [DisplayName("Non_Targeted_Member")]
        public string NonTargetedMember { get; set; }
        [DisplayName("Call_Disposition")]
        public string CallDisposition { get; set; }

        [DisplayName("Health_Assess_Place_of_Service")]
        public string HealthAssessPlaceOfService { get; set; }
        [DisplayName("Health_Assess_Comp")]
        public string HealthAssessComp { get; set; }
        [DisplayName("Health_Assess_Comp_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? HealthAssessCompDate { get; set; }

        [DisplayName("Campaign_Outcome")]
        public string CampaignOutcome { get; set; }

        public string Race { get; set; }
        public string Ethnicity { get; set; }

        [DisplayName("Language_Preference_Update")]
        public string LanguagePreferenceUpdate { get; set; }

        public string Disability { get; set; }

        [DisplayName("Member_Phone_Preference")]
        public string MemberPhonePreference { get; set; }
        [DisplayName("Member_Second_Phone_Preference")]
        public string MemberSecondPhonePreference { get; set; }
        [DisplayName("Member_Email_Preference")]
        public string MemberEmailPreference { get; set; }

        [DisplayName("Provider_Change_Indicator")]
        public string ProviderChangeIndicator { get; set; }
        [DisplayName("Provider_Change_Effective_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ProviderChangeEffectiveDate { get; set; }
        [DisplayName("New_Provider_Name")]
        public string NewProviderName { get; set; }
        [DisplayName("New_Provider_Id")]
        public string NewProviderId { get; set; }

        [DisplayName("Care_Barrier_1")]
        public string CareBarrier1 { get; set; }
        [DisplayName("Care_Barrier_2")]
        public string CareBarrier2 { get; set; }
        [DisplayName("Care_Barrier_3")]
        public string CareBarrier3 { get; set; }
        [DisplayName("Care_Barrier_4")]
        public string CareBarrier4 { get; set; }

        [DisplayName("Appt_Scheduled")]
        public string ApptScheduled { get; set; }
        
        [DisplayName("Appt_Scheduled_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ApptScheduledDate { get; set; }
        [DisplayName("Appt_Scheduled_Time")]
        [Format("HH:mm:ss")]
        public DateTime? ApptScheduledTime { get; set; }
        [DisplayName("Appt_Scheduled_Provider_Name")]
        public string ApptScheduledProviderName { get; set; }
        [DisplayName("Appt_Scheduled_Provider_Id")]
        public string ApptScheduledProviderId { get; set; }
        [DisplayName("Appt_Reminder")]
        public string ApptReminder { get; set; }
        
        [DisplayName("Appt_Reminder_Call_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ApptReminderCallDate { get; set; }
        
        [DisplayName("Appt_Reminder_Email_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ApptReminderEmailDate { get; set; }
        
        [DisplayName("Appt_Confirm")]
        public string ApptConfirm { get; set; }
        
        [DisplayName("Appt_Confirm_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ApptConfirmDate { get; set; }
        
        [DisplayName("Confirm_Appt_Reminder_Email")]
        public string ConfirmApptReminderEmail { get; set; }
        
        [DisplayName("Confirm_Appt_Reminder_Email_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ConfirmApptReminderEmailDate { get; set; }

        [DisplayName("Response_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public string ResponseDatetime { get; set; }

        [DisplayName("Service_Code")]
        public string ServiceCode { get; set; }
        [DisplayName("Service_Status")]
        public string ServiceStatus { get; set; }
        
        [DisplayName("Service_Status_Time")]
        [Format("HH:mm:ss")]
        public DateTime? ServiceStatusTime { get; set; }
        
        [DisplayName("Service_Start_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ServiceStartDate { get; set; }
        
        [DisplayName("Service_End_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? ServiceEndDate { get; set; }

        /*[DisplayName("Diagnosis_Code")]
        public string DiagnosisCode { get; set; }*/
        [DisplayName("Comment_Category")]
        public string CommentCategory { get; set; }
        [DisplayName("Risk_Adjustment_Indicator")]
        public string RiskAdjustmentIndicator { get; set; }
        [DisplayName("Length_of_Call")]
        public string LengthOfCall { get; set; }
        [DisplayName("Do_Not_Contact")]
        public string DoNotContact { get; set; }
        [DisplayName("Do_Not_Call")]
        public string DoNotCall { get; set; }

        [DisplayName("Call_Attempt1_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt1Datetime { get; set; }

        [DisplayName("Call_Attempt2_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt2Datetime { get; set; }

        [DisplayName("Call_Attempt3_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt3Datetime { get; set; }

        [DisplayName("Call_Attempt4_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt4Datetime { get; set; }

        [DisplayName("Call_Attempt5_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt5Datetime { get; set; }

        [DisplayName("Call_Attempt6_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt6Datetime { get; set; }

        [DisplayName("Call_Attempt7_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt7Datetime { get; set; }

        [DisplayName("Call_Attempt8_Datetime")]
        [Format("MM/dd/yyyyHH:mm")]
        public DateTime? CallAttempt8Datetime { get; set; }

        [DisplayName("Form_Submitted")]
        public string FormSubmitted { get; set; }
        [DisplayName("Medical_Case_Mgr_Code")]
        public string MedicalCaseMgrCode { get; set; }

        [DisplayName("Call_Transfer_Indicator")]
        public string CallTransferIndicator { get; set; }
        [DisplayName("Call_Transfer_Types")]
        public string CallTransferTypes { get; set; }
        [DisplayName("Call_Transfer_Reason_Type")]
        public string CallTransferReasonType { get; set; }
        [DisplayName("Call_Transfer_Location")]
        public string CallTransferLocation { get; set; }

        [DisplayName("Member_Called_Back")]
        public string MemberCalledBack { get; set; }
        [DisplayName("No_Response")]
        public string NoResponse { get; set; }

        [DisplayName("Template_Name")]
        public string TemplateName { get; set; }

        [DisplayName("Accepted_Schedule_Assistance")]
        public string AcceptedScheduleAssistance { get; set; }

        [DisplayName("Accepted_Schedule_Assistance_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? AcceptedScheduleAssistanceDate { get; set; }

        public string Assisted { get; set; }

        [DisplayName("Appointment_Not_Required")]
        public string AppointmentNotRequired { get; set; }
        [DisplayName("Prior_Appointment")]
        public string PriorAppointment { get; set; }
        [DisplayName("Already_Visited")]
        public string AlreadyVisited { get; set; }
        [DisplayName("Preferred_Contact_Method")]
        public string PreferredContactMethod { get; set; }
        [DisplayName("Future_Visit")]
        public string FutureVisit { get; set; }

        public ResponseVendorReportViewModel()
        {
            Weight = "";
            CallTransferIndicator = "";
            CallTransferTypes = "NA";
            CallTransferReasonType = "NA";
            CallTransferLocation = "NA";
            TemplateName = "NA";
        }
    }
}
