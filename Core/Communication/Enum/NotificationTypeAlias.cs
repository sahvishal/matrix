namespace Falcon.App.Core.Communication.Enum
{
    public sealed class NotificationTypeAlias
    {
        private NotificationTypeAlias()
        { }

        public const string GlobalException = "GlobalException";
        public const string CustomerWelcomeEmailWithUsername = "CustomerWelcomeEmailWithUsername";
        public const string CustomerWelcomeEmailWithResetMail = "CustomerWelcomeEmailWithPassword";
        public const string EmployeeWelcomeEmailWithUsername = "EmployeeWelcomeEmailWithUsername";
        public const string EmployeeWelcomeEmailWithResetMail = "EmployeeWelcomeEmailWithPassword";
        public const string AppointmentConfirmationWithEventDetails = "AppointmentConfirmationWithEventDetails";
        public const string ResetMail = "ResetPassword";
        public const string LoginIssuesSendUsername = "LoginIssuesSendUsername";
        public const string LoginIssuesSendResetMail = "LoginIssuesSendPassword";
        public const string ChangeIdentification = "ChangePassword";
        public const string ScreeningReminderMail = "ScreeningReminderMail";
        public const string GiftCertificateClaimCodeEmail = "GiftCertificateClaimCodeEmail";
        public const string GiftCertificateAcknowledgmentEmail = "GiftCertificateAcknowledgmentEmail";
        public const string ResultsReady = "ResultsReady";

        public const string AppointmentBookedInTwentyFourHours = "AppointmentBookedInTwentyFourHours";
        public const string CriticalCustomer = "CriticalCustomer";
        public const string EvaluationReminder = "EvaluationReminder";
        public const string AmountRefundNotification = "AmountRefundNotification";

        public const string ThirtyDaysFromAnnualAnniversaryEmailer = "30DaysFromAnnualAnniversaryEmailer";
        public const string OneWeekAfter30DayReminder = "1WeekAfter30DayReminder";
        public const string TwoWeekAfter30DayReminder = "2WeeksAfter30DayReminder";
        public const string OnOneYearAnniversaryDate = "OnOneYearAnniversaryDate";

        public const string SurveyEmailNotification = "SurveyEmailNotification";

        public const string OneDayAfterProspectCreationFollowup = "OneDayAfterProspectCreationFollowup";
        public const string OneWeekAfterProspectCreationFollowup = "OneWeekAfterProspectCreationFollowup";
        public const string TwoWeekAfterProspectCreationFollowup = "TwoWeekAfterProspectCreationFollowup";
        public const string ThreeWeekAfterProspectCreationFollowup = "ThreeWeekAfterProspectCreationFollowup";
        public const string FourWeekAfterProspectCreationFollowup = "FourWeekAfterProspectCreationFollowup";
        public const string FiveWeekAfterProspectCreationFollowup = "FiveWeekAfterProspectCreationFollowup";
        public const string SixWeekAfterProspectCreationFollowup = "SixWeekAfterProspectCreationFollowup";
        public const string SevenWeekAfterProspectCreationFollowup = "SevenWeekAfterProspectCreationFollowup";
        public const string EventFillingNotification = "EventFillingNotification";
        public const string PurchaseShippingNotification = "PurchaseShippingNotification";

        public const string UrgentCustomer = "UrgentCustomer";
        public const string TestUpsellNotification = "TestUpsellNotification";
        public const string EventResultReadyNotification = "EventResultReadyNotification";
        public const string CannedMessageNotification = "CannedMessageNotification";
        public const string TwoHoursBeforeAppointment = "TwoHoursBeforeAppointment";
        public const string KynFirstNotification = "KynFirstNotification";
        public const string KynSecondNotification = "KynSecondNotification";
        public const string AppointmentReminder = "AppointmentReminder";
        public const string AppointmentConfirmation = "AppointmentConfirmation";
        public const string PhysicianPartnerCustomerResultFaxNotification = "PhysicianPartnerCustomerResultFaxNotification";
        public const string PhysicianPartnerSurveyEmailNotification = "PhysicianPartnerSurveyEmailNotification";
        public const string PhysicianPartnersCustomerResultReady = "PhysicianPartnersCustomerResultReady";
        public const string AwvCustomerResultFaxNotification = "AWVCustomerResultFaxNotification";
        public const string EventFullNotification = "EventFullNotification";
        public const string PriorityInQueueCustomer = "PriorityInQueueCustomer";
        public const string LoginOtpEmailNotification = "LoginOTPEmailNotification";
        public const string LoginOtpSmsNotification = "LoginOTPSmsNotification";
        public const string CustomerTagUpdated = "CustomerTagUpdated";
        public const string EventLocked = "EventLocked";
        public const string NoShowCustomer = "NoShowCustomer";
        public const string CorporateUploadNotification = "CorporateUpload";
        public const string DirectMailActivityNotification = "DirectMailActivityNotification";
        public const string IneligibleCustomerAppointmentNotification = "IneligibleCustomerAppointmentNotification";
        public const string ExportToCsvNotification = "ExportToCsvNotification";
        public const string CancelRescheduleAppointmentNotification = "CancelRescheduleAppointmentNotification";
        public const string PatientLeftNotification = "PatientLeftNotification";
        public const string CustomEventSmsNotification = "CustomEventSmsNotification";
        public const string RecordSendBackForCorrection = "RecordSendBackForCorrection";

        public const string HourlyNotificationAppointmentBookedReport = "HourlyNotificationAppointmentBookedReport";
        public const string HourlyNotificationOutreachCallReport = "HourlyNotificationOutreachCallReport";
        public const string OptumNVScreeningAppointmentReminder = "OptumNVScreeningAppointmentReminder";
        public const string OptumNVAppointmentConfirmation = "OptumNVAppointmentConfirmation";
        public const string HCPCAAppointmentConfirmation = "HCPCAAppointmentConfirmation";
        public const string HCPCAAppointmentReminder = "HCPCAAppointmentReminder";
        public const string AppointmentConfirmationFromAnthemBlueCross = "AppointmentConfirmationFromAnthemBlueCross";
        public const string AppointmentReminderFromAnthemBlueCross = "AppointmentReminderFromAnthemBlueCross";
        public const string AppointmentConfirmationFromBlueShieldOfGeorgia = "AppointmentConfirmationFromBlueShieldOfGeorgia";
        public const string AppointmentReminderFromBlueShieldOfGeorgia = "AppointmentReminderFromBlueShieldOfGeorgia";
        public const string AppointmentConfirmationFromConnectiCareMA = "AppointmentConfirmationFromConnectiCareMA";
        public const string AppointmentReminderFromConnectiCareMA = "AppointmentReminderFromConnectiCareMA";
        public const string AppointmentConfirmationFromNTSP = "AppointmentConfirmationFromNTSP";
        public const string AppointmentReminderFromNTSP = "AppointmentReminderFromNTSP";

        public const string WellcomeSmsMessage = "WellcomeSmsMessage";
        public const string WrongSmsReponse = "WrongSmsReponse";

        public const string MergeCustomer = "MergeCustomer";

        public const string FileNotPosted = "FileNotPosted";

        public const string TestNotPerformedSupplyIssue = "TestNotPerformedSupplyIssue";
        public const string TestNotPerformedEquipmentMalfunction = "TestNotPerformedEquipmentMalfunction";
        public const string ReTestNotification = "ReTestNotification";
        public const string NonTargetedMemberRegistrationNotification = "NonTargetedMemberRegistrationNotification";

        public const string MammoPatientRegistrationOnNonMammoEventNotification = "MammoPatientRegistrationOnNonMammoEventNotification";

        public const string SingleTestOverrideNotification = "SingleTestOverrideNotification";

        public const string NPfordiagnosingwithlinkNotification = "NPfordiagnosingwithlinkNotification";

        public const string CoverLetterTemplate = "CoverLetterTemplate";
        public const string ListWithoutCustomTags = "ListWithoutCustomTags";

        public const string AbsenceByMember = "AbsenceByMember";

        //TODO Will Activate on need basis
        //public const string ContactPrimaryCarePhysician = "ContactPrimaryCarePhysician";
        //public const string NewRoleConfirmation = "NewRoleConfirmation";
        //public const string PublicContactUs = "PublicContactUs";
        //public const string Affiliate = "Affiliate";
        //public const string ResultsNotUploaded = "ResultsNotUploaded";
        //public const string ResultsReady = "ResultsReady";
        //public const string AddRole = "AddRole";
        //public const string CorporateWellness = "CorporateWellness";
        //public const string HostScreeningWorkshop = "HostScreeningWorkshop";
        //public const string AffiliateCampaign = "AffiliateCampaign";
        //public const string FranchiseeRegistrationApplication = "FranchiseeRegistrationApplication";
        //public const string MedicalVendorRegistrationApplication = "MedicalVendorRegistrationApplication";
        //public const string SubscriptionRequest = "SubscriptionRequest";
        //public const string ProspectCustomerNotifiy = "ProspectCustomerNotifiy";
        //public const string EmergencyContact = "EmergencyContact";
        //public const string SalesRepPerformanceEventNotifiy = "SalesRepPerformanceEventNotifiy";
        //public const string SalesRepEventSlotFullNotifiy = "SalesRepEventSlotFullNotifiy";
        //public const string EventSuspensation = "EventSuspensation";
        //public const string EventCancelation = "EventCancelation";
        //public const string GiftCertificateClaimCodeEmail = "GiftCertificateClaimCodeEmail";
        //public const string GiftCertificateAcknowledgementEmail = "GiftCertificateAcknowledgementEmail";
        //public const string EventCancelation_Suspensation = "EventCancelation/Suspensation";
        //public const string PrintOrderItemReceived = "PrintOrderItemReceived";
        //public const string CRCResultsReadyReport = "CRCResultsReadyReport";
        //public const string DeliveryFailureNotifiation = "DeliveryFailureNotifiation";
        //public const string NonStandardEventTime = "NonStandardEventTime";
        //public const string HostSiteFeedback = "HostSiteFeedback";
        //public const string HSCProspectCustomerNotification = "HSCProspectCustomerNotification";
        //public const string ResultReadyReminder = "ResultReadyReminder";

    }
}
