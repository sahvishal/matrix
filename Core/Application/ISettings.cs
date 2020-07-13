using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface ISettings
    {
        string LargeLogoFileName { get; }
        string MediumLogoFileName { get; }
        string SmallLogoFileName { get; }

        string ConnectionString { get; }
        int MaximumPictureCount { get; }

        /// <summary>
        ///  This logo is used in Public Website_Homepage, Confirmation Page, Notification Mails, Confirmation Receipt, Small Receipt and Event Schedule
        /// </summary>
        string LargeLogo { get; }

        /// <summary>
        ///  This logo is used in Login Page, Clinical Form
        /// </summary>
        string MediumLogo { get; }

        /// <summary>
        ///  This logo is used in App Users_All Pages, Event Roster
        /// </summary>
        string SmallLogo { get; }

        string ProductName { get; }

        string EmailNotificationLogoRelativePath { get; }


        /// <summary>
        ///  It will store the path of Provacy Statement of the Licensee
        /// </summary>
        string PrivacyPolicyUrl { get; }

        /// <summary>
        /// It will store the Path to Terms and Conditions of the licensee
        /// </summary>
        string TermsConditionsUrl { get; }

        string CopyrightText { get; }

        /// <summary>
        /// It will store the Path to Test Preparation URL
        /// </summary>
        string TestPreparationInstructions { get; }


        /// <summary>
        /// URL of the site
        /// </summary>
        string SiteUrl { get; }

        string LoginUrl { get; }
        string AppUrl { get; }

        string CompanyName { get; }

        string FullBusinessName { get; }


        string PhoneTollFree { get; }
        Email SupportEmail { get; }

        Email EmailNotificationIssuedFrom { get; }
        string NameNotificationissuedFrom { get; }

        string AuthorizeNetECheckUrl { get; }
        string AuthorizeNetECheckLogin { get; }
        string AuthorizeNetECheckTransactionKey { get; }
        string AuthorizeNetECheckTransactionType { get; }
        string AuthorizeNetECheckMerchantEmail { get; }

        string UploadResultPath { get; }
        string UploadImagePath { get; }

        // Organization Address
        string Address1 { get; }
        string Address2 { get; }
        string City { get; }
        string State { get; }
        string ZipCode { get; }

        bool IsAuthorizationRequired { get; }
        decimal PrePayPercentage { get; }
        bool EnableCallPop { get; }


        string MediaUrl { get; }
        string MediaLocation { get; }

        int DefaultPageSizeForReports { get; }
        bool IsRefundQueueEnabled { get; }

        string BusinessTaxId { get; }

        string GiftCertificateImagePath { get; }
        string GiftCertificateThumbnailPath { get; }


        string ProcessorLogin { get; }
        string ProcessorTransactionKey { get; }
        bool ProcessorUseTestUrl { get; }
        bool ProcessorUseTestTransaction { get; }
        bool CapturePrimaryCarePhysician { get; }
        bool EnableSurveyForCorporateEvents { get; }

        bool IsEccEnabled { get; }

        string ResultMediaLocationPrefix { get; }
        string ResultMediaUrlPrefix { get; }

        bool EnableMassRegistration { get; }

        bool ShowPartnerRelease { get; }

        string SiteConfigurableContentPath { get; }
        string LargeLogoLocation { get; }
        string MediumLogoLocation { get; }
        string SmallLogoLocation { get; }

        string TemplatePremiumVersionLocation { get; }
        string TemplateClinicalFormLocation { get; }
        string TemplateIndexPageLocation { get; }
        string TemplateCoverLetterLocation { get; }
        string TemplatePaperBackPremiumVersionLocation { get; }
        string TemplateBloodLetterLoaction { get; }
        string TemplateCorporateCoverLetterLocation { get; }
        string TemplatePremiumVersionWithImagesLocation { get; }

        bool CopyOverMediainPremiumResultReport { get; }
        bool IncludeHealthAssesmentForm { get; }
        bool IncludeCustomerSectioninPremiumResultReport { get; }

        string HealthAssessmentFormUrl { get; }

        string CompanyCustomizedLetter { get; }
        string ContentPages { get; }
        string DoctorLetter { get; }

        int ResultArchiveWaitDays { get; }
        string ResultArchiveSharedDrivePath { get; }

        bool IsStrokeInferenceForPHS { get; }

        DateTime EvaluationReminderSchedulingTime { get; }
        DateTime ScreeningReminderSchedulingTime { get; }

        string BloodWorksAccountDetails { get; }

        string EkgParserFolderRepresentation { get; }
        string EkgParsertoUse { get; }
        string AaaParsertoUse { get; }

        bool EnableResultDeliveryNotification { get; }
        bool CleanUpHtmlFiles { get; }

        int IntervalResultDelivery { get; }
        int IntervalResultDeliveryBuffer { get; }

        string CustomerPortalPhoneTollFree { get; }

        int DaysBeforeScreeningReminder { get; }

        string AnnualReminderPhoneTollFree { get; }
        int DaysBeforeAnnualDate { get; }
        int MaxNumberOfRecordsToFetch { get; }
        int ShowNoOfRecords { get; }
        string AnnualReminderSourceCode { get; }
        string CheckOutUrl { get; }
        DateTime AnnualReminderSchedulingTime { get; }
        DateTime SurveyEmailSchedulingTime { get; }
        DateTime ProspectCustomerFollowUpSchedulingTime { get; }
        bool HideEkgSection { get; }
        DateTime? StrokeFindingChangeDate { get; }
        bool CheckShippingPurchase { get; }

        bool CaptureEmployeeId { get; }
        bool CaptureInsuranceId { get; }

        DateTime TestUpsellSchedulingTime { get; }

        int DaysAfterResultReady { get; }
        DateTime SecondResultReadyNotificationSchedulingTime { get; }

        DateTime EventResultReadyNotificationSchedulingTime { get; }
        int IntervalEventResultReady { get; }

        bool HideShippingOption { get; }
        bool SelectFreeShippingByDefault { get; }

        int HoursBeforeSecondScreeningReminder { get; }
        int IntervalSecondScreeningReminder { get; }

        bool HideResultPurchase { get; }
        bool HideProductPurchase { get; }
        DateTime? OsteoChangeDate { get; }

        DateTime KynFirstNotificationSchedulingTime { get; }
        int DaysAfterRegistrationKynFirstNotification { get; }
        int HoursBeforeKynSecondNotification { get; }
        int IntervalKynSecondNotification { get; }

        bool EligibilityTestMode { get; }
        string EligibilityApiKey { get; }
        string EligibilityProviderFirstName { get; }
        string EligibilityProviderLastName { get; }
        string EligibilityProviderNpi { get; }

        DateTime InsuranceEncounterSchedulingTime { get; }
        DateTime InsuranceClaimSchedulingTime { get; }
        int DaysAfterGetClaim { get; }

        int CallQueueServiceInterval { get; }
        int PullBackCallQueueCustomerInterval { get; }
        string KynTemplate { get; }
        string LipidTemplate { get; }
        string KynDataTemplate { get; }
        string TemplateImageLocation { get; }

        int GenerateKynXmlInterval { get; }

        int HoursBeforeScreeningReminderViaSms { get; }
        int SmsInterval { get; }
        string SmsSystemIdentification { get; }
        string SmsAuthorizationToken { get; }
        string SmsFromNumber { get; }
        DateTime DoNotSendSmsBeforeTime { get; }
        DateTime SendSmsBeforeTime { get; }

        string EFaxAccountId { get; }
        string EFaxUserName { get; }
        string EFaxPassword { get; }
        string EFaxDispositionRecipient { get; }
        string EFaxDispositionEmail { get; }
        int FaxServiceInvokeInterval { get; }

        DateTime FaxResultNotificationQueueTime { get; }
        DateTime FaxResultNotificationPushTime { get; }
        string TemplatePcpCoverLetterWithDianosisCodeLocation { get; }

        string PhysicianPartnerResultPdfDownloadSettings { get; }
        int PhysicianPartnerResultPdfDownloadInterval { get; }
        DateTime PhysicianPartnerResultPdfDownloadTime { get; }
        string PhysicianPartnerResultPdfDownloadPath { get; }
        string PhysicianPartnerResultTiffDownloadPath { get; }

        string PhysicianPartnerAppointmentBookedReportDownloadSettings { get; }
        int PhysicianPartnerAppointmentBookedReportDownloadInterval { get; }
        DateTime PhysicianPartnerAppointmentBookedReportDownloadTime { get; }
        string PhysicianPartnerAppointmentBookedReportDownloadPath { get; }

        string PhysicianPartnerResultReportDownloadSettings { get; }
        int PhysicianPartnerResultReportDownloadInterval { get; }
        DateTime PhysicianPartnerResultReportDownloadTime { get; }
        string PhysicianPartnerResultReportDownloadPath { get; }

        string EmergencyFaxNumber { get; }

        TimeSpan TimeIntervalToPingApi { get; }
        TimeSpan MaximumTimeToWaitApi { get; }
        int FaxPushToApiServiceInterval { get; }

        long PhysicianPartnerAccountId { get; }

        int KynXmlIntervalInMinutes { get; }

        int KynXmlIntervalInHours { get; }
        int MinimumAgeForScreening { get; }

        int AwvFaxServiceInvokeInterval { get; }

        int AwvPcpImportInterval { get; }
        DateTime AwvPcpImportScheduleTime { get; }
        string AwvPcpImportSourcePath { get; }
        string AwvPcpImportArchivePath { get; }

        int MaximumDataRowCountLimitForCsvParser { get; }
        string TemplatePcpCoverLetterLocation { get; }

        bool CaptureBloodTest { get; }

        int WarningMessageTime { get; }
        IEnumerable<long> ShowScannedDocumentHospitalPartnerIds { get; }

        string ApplicatoinDomainUrl { get; }

        string BloodTestFolderLocation { get; }
        string BloodTestArchiveFolderLocation { get; }

        int BloodTestResultParserInterval { get; }

        DateTime BloodTestChangeDate { get; }
        DateTime ShowHideRepeatStudyDate { get; }
        DateTime BasicBiometricCutOfDate { get; }
        int DaysToCheckPriorityInQueue { get; }
        int PriorityInQueueInterval { get; }
        int DynamicSchedulingMaximumScreeningTime { get; }
        int DynamicSchedulingMinimumScreeningTime { get; }
        DateTime? HemoglobinChangeDate { get; }
        string DomainUrl { get; }
        string AngularAppUrl { get; }

        int SystemGeneratedCallQueueGenerationInterval { get; }
        DateTime SystemGeneratedCallQueueGenerationScheduleTime { get; }

        int SystemGeneratedCallQueuePastEventDeleteInterval { get; }
        DateTime SystemGeneratedCallQueuePastEventDeleteScheduleTime { get; }

        string BloodLabFolderLocation { get; }
        string BloodLabArchiveFolderLocation { get; }
        int NoOfDaysToIncludeRemovedFromQueue { get; }

        int PullBackCallQueueCustomerServiceInterval { get; }

        DateTime ShowHideRepeatVisionConfrontationDate { get; }

        DateTime? AwvAaaFindingChangeDate { get; }

        string DiabeticRetinopathyFolderLocation { get; }
        string DiabeticRetinopathyArchiveFolderLocation { get; }
        int DiabeticRetinopathyNoOfDaysToCheckForEvent { get; }
        int DiabeticRetinopathyResultParserInterval { get; }

        IEnumerable<long> PcpResultPdfDownloadAccountIds { get; }
        string PcpResultPdfDownloadSettings { get; }
        string PcpResultPdfDownloadPath { get; }

        IEnumerable<long> PcpAppointmentBookedReportDownloadAccountIds { get; }
        string PcpAppointmentBookedReportDownloadSettings { get; }
        string PcpAppointmentBookedReportDownloadPath { get; }

        IEnumerable<long> PcpResultReportDownloadAccountIds { get; }
        string PcpResultReportDownloadSettings { get; }
        string PcpResultReportDownloadPath { get; }

        DateTime PcpDownloadCutOfDate { get; }

        string WellmedSftpHost { get; }
        string WellmedSftpUserName { get; }
        string WellmedSftpPassword { get; }
        long WellmedAccountId { get; }
        bool SendReportToWellmedSftp { get; }

        string WellmedResultPdfDownloadSettings { get; }
        string WellmedResultPdfDownloadPath { get; }
        string WellmedSftpResultPdfDownloadPath { get; }

        string WellmedAppointmentBookedReportDownloadSettings { get; }
        string WellmedAppointmentBookedReportDownloadPath { get; }
        string WellmedSftpAppointmentBookedReportDownloadPath { get; }

        string WellmedResultReportDownloadSettings { get; }
        string WellmedResultReportDownloadPath { get; }
        string WellmedSftpResultReportDownloadPath { get; }

        long HcpCaliforniaAccountId { get; }
        string HcpCaliforniaResultPdfDownloadSettings { get; }
        string HcpCaliforniaResultPdfDownloadPath { get; }

        string MongoDbConnectionString { get; }
        string DefaultMongoDatabase { get; }
        string DefaultMongoDatabaseCollection { get; }
        bool AuditEnabled { get; }

        string ArchiveResultDataSettingsPath { get; }
        int ArchiveResultDataForOlderThanDays { get; }
        int ArchiveResultDataIntervalHrs { get; }
        DateTime ArchiveResultDataScheduleTime { get; }
        string ArchiveMediaUrl { get; }
        string ArchiveMediaLocation { get; }
        string ApplicationIdentity { get; }
        DateTime? Phq9ChangeDate { get; }
        DateTime? QualityMeasuresChangeDate { get; }
        DateTime? AwvEchoFindingChangeDate { get; }

        long MolinaAccountId { get; }
        string MolinaAppointmentBookedReportDownloadSettings { get; }
        string MolinaAppointmentBookedReportDownloadPath { get; }
        string MolinaResultPdfDownloadSettings { get; }
        string MolinaResultPdfDownloadPath { get; }

        string MolinaResultReportDownloadSettings { get; }
        string MolinaResultReportDownloadPath { get; }

        bool DeleteFileAfterPgpEcnryption { get; }

        int RedisDatabaseKey { get; }

        DateTime UnlockCorporateEventsScheduleTime { get; }

        int UnlockCorporateEventsScheduleInterval { get; }

        int ParseLockedEventFileSchduleInterval { get; }

        DateTime LockCorporateEventScheduleTime { get; }

        int LockCorporateEventScheduleInterval { get; }

        string WellmedLockCorporateEventFolderLocation { get; }
        int MinutesAfterAppointmentTime { get; }

        int NoShowCustomerScheduleInterval { get; }

        int NoPastAppointmentInDays { get; }

        int HealthPlanCallQueueGenerationInterval { get; }
        DateTime HealthPlanCallQueueGenerationScheduleTime { get; }

        int HealthPlanCustomerListExportScheduleInterval { get; }
        DateTime HealthPlanIncorrectPhoneExportScheduleTime { get; }

        DateTime HealthPlanHomeVisitRequestedExportScheduleTime { get; }

        string HealthPlanIncorrectPhoneExportDownloadPath { get; }
        string HealthPlanHomeVisitRequestExportDownloadPath { get; }

        DateTime HealthPlanCustomerExportCutoffDate { get; }
        int PageSizeHealthPlanExport { get; }

        DayOfWeek HealthPlanCustomerExportIntervalDay { get; }

        string MolinaSftpHost { get; }
        string MolinaSftpUserName { get; }
        string MolinaSftpPassword { get; }
        string MolinaLockCorporateEventFolderLocation { get; }

        string RedisServerHost { get; }
        string RedisChannelQueuePrefix { get; }

        DateTime? AttachAttestationFormDate { get; }

        string WellmedWeeklyAppointmentBookedReportPath { get; }
        string WellmedSftpWeeklyAppointmentBookedReportPath { get; }
        DayOfWeek WellmedWeeklyAppointmentBookedReportIntervalDay { get; }
        DateTime WellmedWeeklyAppointmentBookedReportTime { get; }

        bool StopMediaArchiveService { get; }
        DateTime? MammogramChangeDate { get; }

        DateTime HealthPlanFillEventCallQueueGenerationScheduleTime { get; }

        int NeverBeenCalledInDays { get; }
        int NoPastAppointmentInDaysUncontactedCustomers { get; }
        DateTime HealthPlanUncontactedCustomersGenerationScheduleTime { get; }

        int CallUploadParserInterval { get; }
        int ApplyRulesOnLockedCustomersInterval { get; }

        DateTime HealthPlanCriteriaForDeletionScheduleTime { get; }
        int HealthPlanCriteriaForDeletionInterval { get; }

        DateTime DirectMailActivityReminderScheduleTime { get; }

        int DirectMailActivityReminderInterval { get; }

        IEnumerable<long> NtspAccountIds { get; }
        string NtspResultPdfDownloadSettings { get; }

        string NtspResultPdfDownloadPath { get; }

        DateTime? IFobtChangeDate { get; }

        DateTime? UrineMicroalbuminChangeDate { get; }

        int NoOfDaysAfterDeleteReports { get; }

        bool IsDevEnvironment { get; }

        int SendCancelRescheduleNotificationBeforeDays { get; }

        string TemplateTestNotPerformedLocation { get; }

        string HcpCaliforniaSftpHost { get; }
        string HcpCaliforniaSftpUserName { get; }
        string HcpCaliforniaSftpPassword { get; }
        bool SendReportToHcpCaliforniaSftp { get; }
        string HcpCaliforniaSftpResultPdfDownloadPath { get; }

        string HealthPlanTestNotPerformedExportDownloadPath { get; }
        int HealthPlanTestNotPerformedExportScheduleInterval { get; }
        DateTime HealthPlanTestNotPerformedExportScheduleTime { get; }

        DayOfWeek HealthPlanTestNotPerformedIntervalDay { get; }
        DateTime HealthPlanTestNotPerformedCutOfDate { get; }


        string HealthPlanOutreachReportExportDownloadPath { get; }
        int HealthPlanOutreachReportExportScheduleInterval { get; }
        DateTime HealthPlanOutreachReportExportScheduleTime { get; }
        DayOfWeek HealthPlanOutreachReportIntervalDay { get; }
        DateTime HealthPlanOutreachReportCutOfDate { get; }
        IEnumerable<long> HealthPlanOutreachReportAccountIds { get; }
        long MartinPointAccountId { get; }

        string MartinPointAppointmentBookedReportPath { get; }
        DateTime MartinPointAppointmentBookedReportScheduleTime { get; }

        IEnumerable<long> PatientInputFileAccountIds { get; }

        string PatientInputFileReportPath { get; }
        DateTime PatientInputFileScheduleTime { get; }

        int PatientInputFileScheduleInterval { get; }

        DateTime HealthPlanLanguageBarrierScheduleTime { get; }

        DateTime? FluShotChangeDate { get; }
        DateTime? AwvFluShotChangeDate { get; }
        DateTime? PneumococcalChangeDate { get; }
        DateTime? ChangeLeadReadingDate { get; }

        IEnumerable<long> BcbsAccountIds { get; }
        string EventStaffRole { get; }

        long HealthPlanMemberStatusReportAccountId { get; }
        string HealthPlanMemberStatusReportFileReportPath { get; }
        DateTime HealthPlanMemberStatusReportScheduleTime { get; }
        int HealthPlanMemberStatusReportScheduleInterval { get; }
        string BcbsSouthCarolinaCustomTag { get; }

        string BcbsResultPdfDownloadPath { get; }

        long HcpNvAccountId { get; }
        string HcpNvLockCorporateEventFolderLocation { get; }
        string HraQuestionerAppUrl { get; }
        string OrganizationNameForHraQuestioner { get; }
        string MedicareApiUrl { get; }
        string MedicareTokenKeyName { get; }

        int RapsUploadParserInterval { get; }

        string FloridaBlueAccountId { get; }

        DateTime? ChlamydiaChangeDate { get; }

        int DiabeticRetinopathyParserReportNumberOfDays { get; }

        string DiabeticRetinopathylogExportDownloadPath { get; }

        DayOfWeek DiabeticRetinopathylogIntervalDay { get; }

        DateTime DiabeticRetinopathylogSchedule { get; }

        int DiabeticRetinopathylogInterval { get; }

        long HealthNowAccountId { get; }

        string HealthNowSftpHost { get; }

        string HealthNowSftpUserName { get; }

        string HealthNowSftpPassword { get; }

        bool SendPdfToHealthNowSftp { get; }

        string HealthNowSftpPath { get; }

        DateTime? FastingStatusDate { get; }

        int DashboardEventListingPageSize { get; }


        IEnumerable<long> WellCareAccountIds { get; }

        IEnumerable<long> WellCareEasyChoiceAccountIds { get; }

        string WellCareSftpHost { get; }

        string WellCareSftpUserName { get; }

        string WellCareSftpPassword { get; }

        bool SendPdfToWellCareSftp { get; }

        string WellCareSftpPath { get; }

        DateTime? CorporateEventResultReadyCutoffDate { get; }

        DateTime CorporateEventResultReadyNotificationSchedulingTime { get; }

        int IntervalCorporateEventResultReady { get; }

        DateTime OutboundChaseParseScheduleTime { get; }

        int OutboundChaseParseIntervalHours { get; }

        DateTime OutboundFileImportScheduleTime { get; }

        int OutboundFileImportIntervalHours { get; }

        string OutboundSourceFileLocation { get; }

        DateTime OutboundCareCodingParseScheduleTime { get; }

        int OutboundCareCodingParseIntervalHours { get; }

        DateTime ResponseVendorReportScheduleTime { get; }

        int ResponseVendorReportInterval { get; }

        DateTime ConditionInboundReportScheduleTime { get; }

        int ConditionInboundReportInterval { get; }

        DateTime CorporateTagSchedulingTime { get; }

        int CorporateTagIntervalHrs { get; }

        DateTime BarrierInboundReportScheduleTime { get; }

        int BarrierInboundReportInterval { get; }

        DateTime LabsInboundReportScheduleTime { get; }

        int LabsInboundReportInterval { get; }

        DateTime InterviewInboundReportScheduleTime { get; }

        int InterviewInboundReportInterval { get; }

        DateTime CrosswalkInboundReportScheduleTime { get; }

        int CrosswalkInboundReportInterval { get; }

        string FloridaBlueInboundReportPath { get; }

        string FloridaBlueSettingResourcePath { get; }

        DateTime FloridaBlueReportCutOfDate { get; }

        long BcbsScAccountId { get; }
        string BcbsScResultPdfDownloadPath { get; }

        IEnumerable<long> OptumResultPdfDownloadAccountIds { get; }
        string OptumResultPdfDownloadPath { get; }

        IEnumerable<long> OptumResultReportDownloadAccountIds { get; }
        string OptumResultReportDownloadPath { get; }

        IEnumerable<long> OptumAppointmentBookedReportDownloadAccountIds { get; }
        string OptumAppointmentBookedReportDownloadPath { get; }

        IEnumerable<long> OptumZipFolderDownloadAccountIds { get; }
        DateTime OptumZipScheduledTime { get; }
        int OptumZipScheduledInterval { get; }
        string OptumZipFolderDownloadFromPath { get; }
        string OptumZipFolderPostToPath { get; }

        int PatientDetailParseIntervalHours { get; }
        int DiagnosisReportParseIntervalHours { get; }

        DateTime CrosswalkLabInboundReportScheduleTime { get; }
        int CrosswalkLabInboundReportInterval { get; }

        int MarkResultArchiveFailedAfterHours { get; }
        DateTime MarkResultArchiveFailedScheduledTime { get; }
        int MarkResultArchiveFailedInterval { get; }
        string AcePdfSourceLocation { get; }
        long MedicareSyncUserId { get; }
        long MedicareSyncRoleId { get; }
        long MedicareSyncOrganizationId { get; }
        string MedicareSyncCustomSettingsPath { get; }

        int MedicareCustomerIntervalHour { get; }
        int MedicareResultIntervalHour { get; }
        int MedicareResultIntervalMinute { get; }
        int MedicareCustomerIntervalMinute { get; }
        DateTime MedicareCustomerScheduleTime { get; }
        DateTime MedicareHealthPlanScheduleTime { get; }
        DateTime MedicareResultScheduleTime { get; }

        int MedicareEventTestIntervalHour { get; }
        int MedicareEventTestIntervalMinute { get; }
        DateTime MedicareEventTestScheduleTime { get; }

        int MedicareCredentialIntervalHour { get; }
        int MedicareCredentialIntervalMinute { get; }
        DateTime MedicareCredentialScheduleTime { get; }

        string ReportDestinationPath { get; }
        int DayOfMonthServiceRun { get; }

        DateTime TestPerformReportScheduleTime { get; }

        int TestPerformReportInterval { get; }
        int NoOfDaysToPickWhenWithoutSetting { get; }

        string NtspSftpHost { get; }
        string NtspSftpUserName { get; }
        string NtspSftpPassword { get; }
        bool SendReportToNtspSftp { get; }
        string NtspSftpResultReportDownloadPath { get; }

        int LastLoggedInBeforeDays { get; }
        DateTime UserDeactivationScheduleTime { get; }

        long BcbsMnAccountId { get; }
        string BcbsMnSftpHost { get; }
        string BcbsMnSftpUserName { get; }
        string BcbsMnSftpPassword { get; }
        bool SendReportToBcbsMn { get; }
        string BcbsMnSftpResultReportDownloadPath { get; }

        long MonarchAccountId { get; }

        long AnthemAccountId { get; }
        DateTime AnthemDownloadCutOfDate { get; }

        DateTime? DpnChangeDate { get; }

        bool UseSentinel { get; }

        DateTime PatientDetailParseScheduleTime { get; }
        DateTime DiagnosisReportParseScheduleTime { get; }

        string HcpNvSftpHost { get; }
        string HcpNvSftpUserName { get; }
        string HcpNvSftpPassword { get; }
        bool SendReportToHcpNv { get; }
        string HcpNvSftpResultReportDownloadPath { get; }

        DateTime MonarchAttestationScheduleTime { get; }
        int MonarchAttestationIntervalHours { get; }

        IEnumerable<long> DailyPatientRecapReportDownloadAccountIds { get; }
        string DailyPatientRecapReportDestinationPath { get; }
        IEnumerable<DayOfWeek> DaysOfWeekToRunDailyPatientRecapReport { get; }
        DateTime DailyPatientRecapReportScheduleTime { get; }
        int DailyPatientRecapReportInterval { get; }
        string SftpResouceFilePath { get; }

        IEnumerable<long> AccountIdsForEventFileImport { get; }
        DateTime EventFileImportScheduleTime { get; }
        int EventFileImportIntervalHours { get; }

        long BcbsMiAccountId { get; }
        string BcbsMiResultReportDownloadPath { get; }
        string BcbsMiResultPdfDownloadPath { get; }
        string[] BcbsMiRiskPatientTags { get; }
        string[] BcbsMiGapPatinetTags { get; }

        IEnumerable<long> MonarchAccountIds { get; }

        DayOfWeek BcbsMiIncorrectPhoneExportDay { get; }
        DayOfWeek BcbsMiHomeVisitExportDay { get; }
        DateTime IncorrectPhoneExportDownloadTime { get; }
        DateTime HomeVisitExportDownloadTime { get; }
        string ServiceReportSettingPath { get; }

        DateTime BcbsMiServiceReportScheduleTime { get; }
        int BcbsMiServiceReportIntervalHours { get; }
        DayOfWeek BcbsMiReportingServiceDayOfWeek { get; }

        string BcbsMiPcpResultMailedReportSettingPath { get; }
        DateTime BcbsMiPcpResultMailedReportScheduleTime { get; }
        int BcbsMiPcpResultMailedReportIntervalHours { get; }
        DayOfWeek BcbsMiPcpResultMailedReportDayOfWeek { get; }

        string BcbsMiMemberResultMailedReportSettingPath { get; }
        DateTime BcbsMiMemberResultMailedReportScheduleTime { get; }
        int BcbsMiMemberResultMailedReportIntervalHours { get; }
        DayOfWeek BcbsMiMemberResultMailedReportDayOfWeek { get; }

        IEnumerable<long> OptumHomeVisitRequesedAccountIds { get; }
        string OptumHomeVisitRequesedDownloadPath { get; }

        IEnumerable<long> OptumIncorrectPhoneNumberAccountIds { get; }
        string OptumIncorrectPhoneNumberDownloadPath { get; }

        IEnumerable<long> DoNotSendHomeVistIncorrectPhoneNumberAccountIds { get; }

        string MonarchZipFolderPostToPath { get; }

        string BcbsmiHomeVisitRequestedSettingPath { get; }
        string BcbsmiIncorrectPhoneNumberSettingPath { get; }

        string MonarchWellmedPdfPath { get; }
        string MonarchWelledPdfSfptPath { get; }
        string CustomerWithNoGmpiPath { get; }

        bool SendPdfToWellmed { get; }

        long MartinsPointExclusiveAccountId { get; }

        string WellCarePcpSummaryLogDownloadPath { get; }
        string WellCarePcpSummaryLogReportSettingPath { get; }
        DayOfWeek WellCarePcpSummaryLogReportDayOfWeek { get; }
        DateTime WellCarePcpSummaryLogReportScheduleTime { get; }
        int WellCarePcpSummaryLogReportIntervalHours { get; }
        DateTime WellCarePcpSummaryLogCutOfDate { get; }

        int StartYear { get; }

        long ExcellusAccountId { get; }
        string[] ExcellusCustomTags { get; }

        string[] AnthemCustomTags { get; }

        string[] HealthNowCustomTags { get; }
        DayOfWeek ExcellusExportResultReportDayOfWeek { get; }

        string AnthemDownloadPath { get; }
        string[] AnthemCustomTagStates { get; }

        IEnumerable<long> GiftCertificateReportDownloadAccountIds { get; }
        DateTime GiftCertificateReportCutOffDate { get; }
        IEnumerable<DayOfWeek> GiftCertificateReportDaysOfWeek { get; }
        string GiftCertificateReportDownloadPath { get; }
        DateTime GiftCertificateReportScheduleTime { get; }
        bool HideQuantaFloAbiSection { get; }

        string LoincLabDataPath { get; }
        string LoincCrosswalkPath { get; }
        DateTime LoincLabDataParseScheduleTime { get; }
        DateTime LoincCrosswalkParseScheduleTime { get; }

        string HourlyAppointmentBookedResoucePath { get; }
        string HourlyAppointmentBookedDownloadPath { get; }

        DateTime HourlyAppointmentBookedScheduleTime { get; }
        int HourlyAppointmentBookedIntervalHours { get; }
        int HourlyAppointmentBookedStartTime { get; }

        DayOfWeek FloridaBlueReportsDayOfWeek { get; }
        string[] FloridaBlueMedicareCustomTags { get; }
        string[] FloridaBlueCommercialCustomTags { get; }
        long FloridaBlueCommercialId { get; }

        string ResultPostedToPlanPath { get; }

        string HourlyOutreachCallReportDownloadPath { get; }
        DateTime HourlyOutreachCallReportScheduleTime { get; }
        int HourlyOutreachCallReportIntervalHours { get; }
        int HourlyOutreachCallReportStartTime { get; }

        DateTime PatientKareoIntegrationSchedulingTime { get; }

        string GiftCertificateSettingResourcePath { get; }

        DateTime FromDateForGapPatient { get; }

        int CustomerReturnInCallQueue { get; }

        string MonarchResultPdfArchive { get; }

        int ZipRangeInMiles { get; }

        DateTime HealthPlanEventZipScheduleTime { get; }

        int HealthPlanEventZipInterval { get; }

        DateTime HealthPlanEventZipQueueNotGeneratedScheduleTime { get; }

        int HealthPlanEventZipQueueNotGeneratedInterval { get; }

        DateTime HkynGenerationDate { get; }

        string HealthPlanDownloadPath { get; }

        long MedMutualAccountId { get; }
        int MedMutualExportDay { get; }

        string ClinicalDoumentPath { get; }

        IEnumerable<long> ClinicalDoumentAccountIds { get; }

        string ClinicalDoumentSettingPath { get; }

        int RefusedCustomerReturnInCallQueue { get; }

        string HkynParsePdfPath { get; }

        int HkynParsePdfIntervalInMinutes { get; }

        string EkgCardioCardParserFolderRepresentation { get; }

        int MailRoundLeftVoiceMailDefault { get; }

        int MailRoundAllCallDefault { get; }

        int FillEventAllCallDefault { get; }

        int FillEventRefusedCustomerDefault { get; }

        int CallQueueMaxAttemptDefault { get; }

        string PdfLogFilePath { get; }
        long AppleCareAccountId { get; }
        DayOfWeek AppleCareAppointmentBookedReportDayOfWeek { get; }

        IEnumerable<long> AttestionFormParseAccountIds { get; }
        string AppleCareAttestationFormsPath { get; }

        long ConnecticareAccountId { get; }
        long BcbsAlAccountId { get; }
        string BcbsAlSftpDownloadPath { get; }
        long ConnecticareMaAccountId { get; }

        string[] WellCareToWellMedCustomTags { get; }

        DateTime HealthPlanConfirmationCallQueueGenerationScheduleTime { get; }
        DateTime NewHkynEventDate { get; }

        long OptumNvAccountId { get; }

        string TraleUrl { get; }
        string ProfileId { get; }
        string TraleApiKey { get; }

        string TraleKey { get; }
        string TraleIv { get; }
        string BioCheckAssessmentFailedListPath { get; }

        int MedicareRapsSyncIntervalHour { get; }
        int MedicareRapsSyncIntervalMinute { get; }
        DateTime MedicareRapsSyncScheduleTime { get; }

        DateTime OptumNvResultPdfNamingChangeDate { get; }

        DateTime PhoneNumberUpdateScheduleTime { get; }

        int MergeCustomerInterval { get; }
        int PhoneNumberUpdateIntervalHours { get; }

        string DailyVolumeReportPath { get; }
        DateTime DailyVolumeReportScheduleTime { get; }

        int DailyVolumeReportIntervalInHour { get; }


        string EventListGmsReportPath { get; }
        DateTime EventListGmsReportIntervalHour { get; }

        bool StopTrailService { get; }
        string CustomerWithNoMrnPath { get; }
        string GmsCustomerReportPath { get; }
        IEnumerable<long> GmsAccountIds { get; }
        DateTime GmsEventReportScheduleTime { get; }
        int GmsEventReportIntervalMinutes { get; }
        DateTime GmsCustomerReportScheduleTime { get; }
        int GmsCustomerReportIntervalHours { get; }
        int GmsMaxCustomerCount { get; }
        string GmsSftpHost { get; }
        string GmsSftpUserName { get; }
        string GmsSftpPassword { get; }
        bool SendReportToGmsSftp { get; }
        string GmsSftpPath { get; }
        int GmsEventStartTime { get; }
        int GmsEventEndTime { get; }

        string TwilioFilePath { get; }

        string GmsDialerFilePath { get; }
        DateTime GmsDialerFileParsingScheduleTime { get; }

        IEnumerable<long> EventScheduleAccountIds { get; }
        int EventScheduleAccountInterval { get; }
        DateTime EventScheduleAccountScheduleTime { get; }
        string EventScheduleReportPath { get; }

        string MailRoundCustomersReportDestinantionPath { get; }
        DateTime MailRoundCustomersReportScheduleTime { get; }
        int MailRoundCustomersReportIntervalHours { get; }

        string GmsUserName { get; }
        int GmsDialerFileParsingIntervalHours { get; }
        string ResultNotPostedToPlanPath { get; }

        string BiWeeklyMicroAlbuminFobtReportPath { get; }
        bool SendBiWeeklyMicroAlbuminFobtReportToSftp { get; }
        DateTime BiWeeklyMicroAlbuminFobtCutoffDate { get; }
        IEnumerable<long> BiWeeklyMicroAlbuminFobtReportRunDates { get; }
        string BiWeeklyMicroAlbuminFobtSftpPath { get; }
        DateTime BiWeeklyMicroAlbuminFobtScheduleTime { get; }
        int BiWeeklyMicroAlbuminFobtIntervalHours { get; }

        string EventScheduleReportSftpPath { get; }

        bool SendNonTargetableReportToSftp { get; }
        string NonTargetableReportSftpPath { get; }
        string NonTargetableReportPath { get; }
        DateTime NonTargetableCutoffDate { get; }
        int NonTargetableReportRunDate { get; }
        DateTime NonTargetableReportScheduleTime { get; }
        int NonTargetableReportIntervalHours { get; }

        string AppointmentEncounterReportPath { get; }
        DateTime AppointmentEncounterScheduleTime { get; }
        int AppointmentEncounterIntervalHours { get; }

        bool SendPcpChangeReportToSftp { get; }
        string PcpChangeReportSftpPath { get; }
        string PcpChangeReportPath { get; }
        DateTime PcpChangeReportCutoffDate { get; }
        int PcpChangeReportRunDate { get; }
        DateTime PcpChangeReportScheduleTime { get; }
        int PcpChangeReportIntervalHours { get; }
        string PcpChangeReportSettings { get; }


        string HousecallOutreachReportExportDownloadPath { get; }
        int HousecallOutreachReportExportScheduleInterval { get; }
        DateTime HousecallOutreachReportExportScheduleTime { get; }
        DateTime HousecallOutreachReportCutOfDate { get; }
        IEnumerable<long> HousecallPlanOutreachReportAccountIds { get; }
        string HousecallOutreachSettings { get; }
        string HousecallHafResultReportDownloadSettings { get; }
        string HousecallHafResultReportDownloadPath { get; }
        DateTime HousecallHafResultReportDownloadTime { get; }
        int HousecallHafResultReportDownloadInterval { get; }

        long WellmedWellCareAccountId { get; }

        int EventSuspentionCutoffDays { get; }

        string WellmedMemberStatusReportPath { get; }
        DateTime WellmedMemberStatusReportScheduleTime { get; }
        int WellmedMemberStatusReportScheduleInterval { get; }
        int WellmedMemberStatusReportDayOfMonth { get; }
        string WellmedMemberStatusReportSftpPath { get; }
        bool WellmedMemberStatusReportSendToSftp { get; }

        IEnumerable<long> WellCareToWellmedAccountId { get; }

        IEnumerable<long> WellmedReportAccountIds { get; }
        int EligibilityUploadIntervalMinutes { get; }

        IEnumerable<long> AnthemAccountIds { get; }
        int StaffEventScheduleParseIntervalMinutes { get; }

        IEnumerable<long> GmsCampaignIds { get; }
        int MedicareMedicationSyncIntervalMinute { get; }
        int MedicationFileParserIntervalMinute { get; }

        int CustomerForMedicationSyncCutoffDays { get; }

        string[] FloridaBlueMammoCustomTags { get; }
        long FloridaBlueMammoId { get; }

        int NumberOfMaximumPrintInProgress { get; }

        string UniversalMemberFilePath { get; }

        string ParsePatientDataSftpPath { get; }
        DateTime ParsePatientDataScheduleTime { get; }
        int ParsePatientDataIntervalHours { get; }

        int UniversalMemberReportInterval { get; }
        DateTime UniversalMemberReportScheduleTime { get; }

        string UniversalProviderFilePath { get; }
        int UniversalProviderReportInterval { get; }
        DateTime UniversalProviderReportScheduleTime { get; }
        DateTime EodGcCutoffDate { get; }
        DateTime ChecklistChangeDate { get; }

        string OptumUtCustomTagsForGms { get; }

        long OptumUtAccountId { get; }
        IEnumerable<long> OptumAccountIds { get; }

        string CustomerConsentDataFilePath { get; }
        DateTime CustomerConsentDataReportScheduleTime { get; }
        int CustomerConsentDataReportInterval { get; }
        string CustomerConsentDataReportSftpPath { get; }
        bool CustomerConsentDataReportSendToSftp { get; }
        string CustomerConsentDataReportSettingPath { get; }
        string MatrixSftpHost { get; }
        string MatrixSftpUserName { get; }
        string MatrixSftpPassword { get; }

        string ConsentHeaderFormUrl { get; }

        DateTime GmsExcludeCustomerReportDownloadTime { get; }
        int GmsExcludeReportDownloadCustomerIntervalInHours { get; }
        string GmsExcludeReportDownloadCustomerPath { get; }

        DateTime MedicareSuspectConditionSyncScheduleTime { get; }
        int MedicareSuspectConditionSyncIntervalHour { get; }
        int MedicareSuspectConditionSyncIntervalMinute { get; }

        IEnumerable<long> AppointmentEncounterReportAccountIds { get; }

        IEnumerable<long> GiftCerificateOptumAccountIds { get; }
        DateTime GiftCerificateOptumScheduledTime { get; }
        int GiftCerificateOptumScheduledInterval { get; }
        long GiftCerificateOptumDayServiceRun { get; }
        string GiftCerificateOptumDownloadPath { get; }

        DateTime AccountZipSubstituteRegenerationScheduleTime { get; }
        int AccountZipSubstituteRegenerationInterval { get; }
        int AccountZipSubstituteStartTime { get; }
        int AccountZipSubstituteEndTime { get; }
        bool RegenerateAccountEventZip { get; }
        string AccountZipRegenerationResourcePath { get; }
        int CustomerForSuspectSyncCutoffDays { get; }

        long OptumNvMedicareAccountId { get; }
        IEnumerable<long> OptumNVSettingAccountIds { get; }

        string[] FloridaBlueGapsCustomTags { get; }
        long FloridaBlueGapsId { get; }

        string BcbsmiDateAddedIncorrectPhoneNumberSettingPath { get; }

        string UniversalMemberFileSftpPath { get; }
        string UniversalProviderFileSftpPath { get; }

        string LabReportTestResultPath { get; }
        string LabReportArchivedTestResultPath { get; }
        int LabReportParserInterval { get; }

        string UniversalMemberArchivedFilePath { get; }

        string UniversalProviderArchivedFilePath { get; }

        string LabReportClientLogPath { get; }

        long BcbsScAssessmentAccountId { get; }
        IEnumerable<long> BcbsScResultPdfAccountIds { get; }
        DateTime ResultFlowChangeDate { get; }

        IEnumerable<long> HealthPlanMemberStatusReportAccountIds { get; }
        string HealthPlanExportRootPath { get; }
        DayOfWeek ConnecticareEventScheduleExportDay { get; }

        string WellmedResultPdfCatalystDownloadPath { get; }
        string WellmedSftpResultPdfCatalystDownloadPath { get; }
        string WellmedCustomerGroupName { get; }

        int IntervalForSendNotificationToNursePractitioner { get; }
        string MedicareAppUrl { get; }

        int FillEventZipRadius { get; }
        int SyncResultsReadyForCodingInterval { get; }

        DayOfWeek BcbsMiGapResultExportIntervalDay { get; }
        DayOfWeek BcbsMiResultPdfDownloadIntervalDay { get; }

        string SignatureForCoverLetterRelativePath { get; }

        string FloridaBlueSftpHost { get; }
        string FloridaBlueSftpUserName { get; }
        string FloridaBlueSftpPassword { get; }
        bool SendReportToFloridaBlueSftp { get; }
        string FloridaBlueSftpPath { get; }
        long FloridaBlueFepAccountId { get; }
        DayOfWeek FloridaBlueFepExportDayOfWeek { get; }

        string KareoIntegrationSettingResourcePath { get; }
        DateTime KareoIntegrationCutOffDate { get; }

        string CumulativeResultExportsPath { get; }
        string IncrementalResultExportsPath { get; }
        string AnthemAdditionalFieldValues { get; }
        DayOfWeek AppleCareGiftCertificateDayOfWeek { get; }

        string[] AcesClientIds { get; }
        string HiptoAcesCrossWalkReportFilePath { get; }
        int HiptoAcesCrossWalkReportInterval { get; }
        DateTime HiptoAcesCrossWalkReportScheduleTime { get; }

        string MemberUploadbyAcesSourceFolderPath { get; }
        string MemberUploadbyAcesDestinationFolderPath { get; }

        string CustomerEligibilityUploadSftpPath { get; }
        DateTime CustomerEligibilityUploadScheduleTime { get; }
        int CustomerEligibilityUploadIntervalHours { get; }

        DateTime MemberUploadbyAcesReportScheduleTime { get; }
        int MemberUploadbyAcesReportInterval { get; }

        double MedicareSessionValidityDuration { get; }

        string GiftCertificateReportInternalLocation { get; }
        string IpResultSftpFolderLocation { get; }
        int IpResultPdfIntervalInMinutes { get; }
        DateTime AnthemCutOfDateForSendingReport { get; }
        int BatchPageSize { get; }

        bool StopCustomerEligibilityUpload { get; }
        bool StopMemberUploadbyAces { get; }

        string CrosswalkFilePath { get; }
        int CrosswalkFileYear { get; }

        long PPAccountId { get; }
        DateTime PPEventCutOfDate { get; }

        string ChatQuestionerAppUrl { get; }

        long NammAccountId { get; }
        string NammAttestationFormsPath { get; }
        string NammSourceDirectory { get; }
        string NammSftpHost { get; }
        string NammSftpUserName { get; }
        string NammSftpPassword { get; }
        bool IsSftpEnableforNaamAccount { get; }
        DateTime? SyncStartDate { get; }
        DateTime? SyncEndDate { get; }
        DateTime StopSendingPdftoHealthPlanDate { get; }
        string ResultPacketLocation { get; }
        IEnumerable<long> IpSendMediaFilesForTestIds { get; }

        string SendTestMediaFilesClientLocation { get; }

        IEnumerable<long> AdditionalTestIdToSendMediaFiles { get; }

        string BloodResultFolderLocation { get; }
        string BloodResultArchiveFolderLocation { get; }
        string ClientSftpPathForHipToAces { get; }

        bool StopHansonResultParse { get; }

        string ChatAssessmentPdfUrl { get; }
        string ChatAssessmentPdfUserName { get; }
        string ChatAssessmentPdfPassword { get; }

        int CustomerActivityTypeUploadIntervalMinutes { get; }

        int MemberUploadParseIntervalMinutes { get; }

        string ChaperoneFormUrl { get; }

        string HighImageQuality { get; }

        DateTime StopSendingMediaFileDate { get; }
        int PullBackPreAssessmentCallQueueCustomerInterval { get; }

        bool SyncWithHra { get; }
        string WellmedTxFocPath { get; }
        string WellmedFlFocPath { get; }
        long WellmedTxAccountId { get; }

        string WellmedTxLockCorporateEventFolderLocation { get; }
        string WellmedFlLockCorporateEventFolderLocation { get; }
        DateTime WellmedParseLockedEventScheduleTime { get; }
        int WellmedParseLockedEventIntervalHours { get; }

        string WellmedTxCatalystGroupName { get; }


        long WellmedGiftCertificateDayOfWeek { get; }
        DateTime WellmedGiftCertificateScheduleTime { get; }
        int WellmedGiftCertificateIntervalHours { get; }
        DayOfWeek WellmedIncorrectPhoneNumberDayOfWeek { get; }


        string OutTakeReportPath { get; }

        string WellmedTxFolder { get;  }
        string WellmedFlFolder { get;  }
        string BcbsScFolder { get; }
        string HcpNvFolder { get; }

        string LockCorporateEventFolderLocation { get; }

        DateTime EventZipProductTypePollingAgentRegenerationScheduleTime { get; }
        int EventZipProductTypePollingAgentRegenerationInterval { get; }
        DateTime EventZipProductTypeSubstitutePollingAgentRegenerationScheduleTime { get; }
        int EventZipProductTypeSubstitutePollingAgentRegenerationInterval { get; }
        long HcpNvIncorrectPhoneNumberDayOfWeek { get; }
    }
}