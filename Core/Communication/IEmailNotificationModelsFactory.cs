using System;
using System.Collections.Generic;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IEmailNotificationModelsFactory
    {
        WelcomeWithUserNameNotificationModel GetWelcomeWithUserNameNotificationModel(string userName, string fullName,
                                                                                     DateTime signUpDate);

        WelcomeWithPasswordNotificationModel GetWelcomeWithPasswordNotificationModel(string fullName, string password, string resetPasswordQueryString, long userId = 0);

        ResetPasswordNotificationModel GetResetNotificationModel(long userId, string fullName,
                                                                 string resetPasswordQueryString);
        AppointmentConfirmationViewModel GetAppointmentConfirmationModel(long eventId, long customerId);

        AppointmentBookedInTwentyFourHoursNotificationModel GetAppointmentBookedInTwentyFourHoursModel(long eventId, long customerId);

        ResultReadyNotificationViewModel GetResultReadyModel(string customerName, string userName, bool isPaperCopyPurchased, long eventId);

        SentBackForCorrectionNotificationViewModel GetSentBackForCorrectionModel(long eventId, long customerId);

        WelcomeWithUserNameNotificationModel GetDummyDataWelcomeWithUserNameNotificationModel();
        WelcomeWithPasswordNotificationModel GetDummyDataWelcomeWithPasswordNotificationModel();
        ResetPasswordNotificationModel GetDummyDataResetModificationModel();
        AppointmentConfirmationViewModel GetDummyDataAppointmentConfirmationModel();

        GiftCertificateNotificationModel GetGiftCertificateNotificationModel(string claimCode, string fromName, string toName, string message, decimal value);
        GiftCertificateNotificationModel GetDummyDataGiftCertificateNotificationModel();
        CriticalCustomerNotificationViewModel GetCriticalCustomerNotificationModel(long eventId, long customerId, long testId = 0);
        EvaluationReminderNotificationViewModel GetEvaluationReminderNotificationModel(long physicianId);

        AmountRefundNotificationViewModel GetAmountRefundNotificationViewModel(string fullName, decimal amountRefunded);

        AmountRefundNotificationViewModel GetDummyAmountRefundNotificationViewModel();

        ResultReadyNotificationViewModel GetDummyResultReadyModel();

        EvaluationReminderNotificationViewModel GetDummyEvaluationReminderNotificationModel();

        CriticalCustomerNotificationViewModel GetDummyCriticalCustomerNotificationModel();

        AppointmentBookedInTwentyFourHoursNotificationModel GetDummyAppointmentBookedInTwentyFourHoursModel();

        AnnualReminderNotificationViewModel GetAnnualReminderNotificationViewModel(Customer customer, string sourceCode, string checkOutUrl, string annualReminderPhoneTollFree, IEnumerable<OnlineSchedulingEventViewModel> events);
        AnnualReminderNotificationViewModel GetDummyAnnualReminderNotificationViewModel();

        SurveyEmailNotificationModel GetSurveyNotificationModel(Customer customer, Event @event, IEnumerable<Pod> pods);
        SurveyEmailNotificationModel GetDummySurveyNotificationModel();

        ProspectCustomerFollowupNotificationViewModel GetProspectCustomerFollowupNotificationViewModel(string fullName, string checkoutUrl, IEnumerable<OnlineSchedulingEventViewModel> events);
        ProspectCustomerFollowupNotificationViewModel GetDummyProspectCustomerFollowupNotificationViewModel();

        EventFillingNotificationViewModel GetEventFillingNotificationViewModel(long eventId, int totalSlots, int availableSlots);
        EventFillingNotificationViewModel GetDummyEventFillingNotificationViewModel();

        PurchaseShippingNotificationViewModel GetPurchaseShippingNotificationViewModel(long eventId, long customerId);
        PurchaseShippingNotificationViewModel GetDummyPurchaseShippingNotificationViewModel();

        UrgentCustomerNotificationViewModel GetUrgentCustomerNotificationModel(long eventId, long customerId, IEnumerable<TestResultStatusViewModel> urgentTests);
        UrgentCustomerNotificationViewModel GetDummyUrgentCustomerNotificationModel();

        TestUpsellNotificationModel GetTestUpsellNotificationModel(Customer customer, IEnumerable<Test> tests);
        TestUpsellNotificationModel GetDummyTestUpsellNotificationModel();

        EventResultReadyNotificationViewModel GetEventResultReadyNotificationViewModel(User user, EventHostViewData eventHostViewData);
        EventResultReadyNotificationViewModel GetDummyEventResultReadyNotificationViewModel();

        KynNotificationViewModel GetKynNotificationViewModel(Customer customer, EventHostViewData eventHostViewData, Appointment appointment, bool isDemographicInfoFilled, bool isHafFilled);
        KynNotificationViewModel GetDummyKynNotificationViewModel();

        PpCustomersResultReadyEmailNotificationModel GetPpCustomerResultNotificationModel(Customer customer, PrimaryCarePhysician primaryCarePhysician);
        PpCustomersResultReadyEmailNotificationModel GetDummyPpCustomerResultNotificationModel();

        EventFullNotificationViewModel GetEventFullNotificationViewModel(long eventId, int totalSlots);
        EventFullNotificationViewModel GetDummyEventFullNotificationViewModel();

        PriorityInQueueNotificationViewModel GetPriorityInQueueNotificationModel(long eventId, long customerId, string note, long eventCustomerResultId);

        PriorityInQueueNotificationViewModel GetDummyPriorityInQueueNotificationModel();
        LoginOtpEmailNotificationViewModel GetLoginOtpEmailNotificationViewModel(long userId, string otp, string expirationMin);
        LoginOtpEmailNotificationViewModel GetDummyLoginOtpEmailNotificationViewModel();
        CustomerTagChangeNotificationViewModel GetCustomerTagChangeNotificationViewModel(long oldEventId, long newEventId, long customerId, string previousTag);
        CustomerTagChangeNotificationViewModel GetDummyCustomerTagChangeNotificationViewModel();

        EventLockedNotificationViewModel GetEventLockedNotificationViewModel(User user, EventHostViewData eventHostViewData);
        EventLockedNotificationViewModel GetDummyEventLockedNotificationViewModel();
        NoShowCustomerNotificationViewModel GetDummyNoShowCustomerNotificationViewModel();

        NoShowCustomerNotificationViewModel GetNoShowCustomerNotificationViewModel(EventCustomer eventCustomer, Appointment appointment);

        CorporateUploadNotificationViewModel GetDummyCorporateUploadNotificationViewModel();
        CorporateUploadNotificationViewModel GetCorporateUploadNotificationViewModel(string corporateName, string uploadedBy, long totalCustomers, long uploadedCustomers, long failedCustomers);

        DirectMailActivityNotificationViewModel GetDummyDirectMailActivityNotificationViewModel();

        DirectMailActivityNotificationViewModel GetDirectMailActivityNotificationViewModel(string userName, string campaignName, string healthPlan, string customTags);

        IneligibleCustomerAppointmentNotificationViewModel GetDummyIneligibleCustomerAppointmentNotificationViewModel();
        IneligibleCustomerAppointmentNotificationViewModel GetIneligibleCustomerAppointmentNotificationViewModel(Customer customer, Event eventInfo);

        CustomerExportableReportsNotificationViewModel GetDummyCustomerExportableReportsNotificationViewModel();
        CustomerExportableReportsNotificationViewModel GetCustomerExportableReportsNotificationViewModel(string name, string exportableReport);
        CancelRescheduleAppointmentNotification GetDummyCancelRescheduleAppointmentNotificationViewModel();

        CancelRescheduleAppointmentNotification GetCancelRescheduleAppointmentNotificationViewModel(string customerName,
            long eventId, long newEventId, DateTime? newEventDate, bool isCancelAppointment, string reason, string subReason);

        PatientLeftNotificationViewModel GetPatientLeftNotificationViewModel(long eventCustomerId, long? leftWithoutScreeningReasonId, string notes, long currentUserId);
        PatientLeftNotificationViewModel GetDummyPatientLeftNotificationModel();

        RecordSendBackForCorrectionNotificationViewModel GetRecordSendBackForCorrectionNotificationViewModel(long customerID, long eventID, long physicianId, string reasonNote);

        RecordSendBackForCorrectionNotificationViewModel GetDummyRecordSendBackForCorrectionNotificationViewModel();

        HourlyAppointmentBookedReportNotificationViewModel GetDummyHourlyAppointmentBookedReportNotificationViewModel();

        HourlyAppointmentBookedReportNotificationViewModel GetHourlyAppointmentBookedReportNotificationViewModel(string reportName, string exportPath);

        HourlyOutreachNotificationViewModel GetDummyHourlyOutreachNotificationViewModel();

        HourlyOutreachNotificationViewModel GetHourlyOutreachNotificationViewModel(string reportName, string exportPath);

        MergeCustomerNotificationViewModel GetDummyMergeCustomerViewModel();
        MergeCustomerNotificationViewModel GetMergeCustomerViewModel(long uploadId, DateTime uploadTime, string fileName);

        FileNotPostedNotificationViewModel GetDummyFileNotPostedViewModel();
        FileNotPostedNotificationViewModel GetFileNotPostedViewModel(string tag, int failedCustomerCounth);

        TestNotPerformedEmailNotificationViewModel GetDummyTestNotPerformedEmailNotificationViewModel();
        TestNotPerformedEmailNotificationViewModel GetTestNotPerformedEmailNotificationViewModel(long customerId, long eventId, string reason, IEnumerable<TestNotPerformedNotificationTestViewModel> testNameSavedByPairs);

        ReTestNotificationViewModel GetDummyReTestNotificationViewModel();
        ReTestNotificationViewModel GetReTestNotificationViewModel(long patientId, long eventId, long[] testIds);

        NonTargetedMemberRegistrationNotificationViewModel GetDummyNonTargetedMemberRegistrationNotificationViewModel();
        NonTargetedMemberRegistrationNotificationViewModel GetNonTargetedMemberRegistrationNotificationViewModel(Customer customer, Event eventData, CorporateAccount account);

        MammoPatientRegistrationOnNonMammoEventNotificationViewModel GetDummyMammoPatientRegestrationOnNonMammoEventViewModel();
        MammoPatientRegistrationOnNonMammoEventNotificationViewModel GetMammoPatientRegestrationOnNonMammoEventViewModel(Customer customer, Event eventData);

        SingleTestOverrideNotificationViewModel GetDummySingleTestOverrideNotificationViewModel();
        SingleTestOverrideNotificationViewModel GetSingleTestOverrideNotificationViewModel(long customerId, long eventId);

        NPfordiagnosingwithlinkNotificationViewModel GetDummyNPfordiagnosingwithlinkNotificationViewModel();
        NPfordiagnosingwithlinkNotificationViewModel GetNPfordiagnosingwithlinkNotificationViewModel(long customerId, long eventId, string UrlTestDocumentation, string UrlUnlockAssessment, string UrlTriggersReadyForCodingStatus);

        CoverLetterTemplateViewModel GetDummyCoverLetterTemplateViewModel();
        CoverLetterTemplateViewModel GetCoverLetterTemplateViewModel(string customerName, string doctorSignatureFilePath, string pcpName, DateTime? letterDate);

        ListWithoutCustomTagsNotificationViewModel GetDummyListWithoutCustomTagsViewModel();
        ListWithoutCustomTagsNotificationViewModel GetListWithoutCustomTagsViewModel(string patientwithoutCustomTagFileLocation, string failedCustomerRecordFileLocation, string adjustOrderFileLocation);

        AbsenceByMemberNotificationViewModel GetDummyAbsenceByMemberPostedViewModel();
        AbsenceByMemberNotificationViewModel GetAbsenceByMemberViewModel(string tag, long CorporateUploadId);
        
    }
}