using Falcon.App.Core.Application;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Falcon.Web.IntegrationTests.Fakes
{
    public class FakeSettings : ISettings
    {
        public string ConnectionString
        {
            get { throw new NotImplementedException(); }
        }

        public int MaximumPictureCount
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        ///  This logo is used in Public Website_Homepage, Confirmation Page, Notification Mails, Confirmation Receipt, Small Receipt and Event Schedule
        /// </summary>
        public string LargeLogo
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        ///  This logo is used in Login Page, Clinical Form
        /// </summary>
        public string MediumLogo
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        ///  This logo is used in App Users_All Pages, Event Roster
        /// </summary>
        public string SmallLogo
        {
            get { return "Small Logo"; }
        }

        public string ProductName
        {
            get { return "Business Management System."; }
        }

        public string EmailNotificationLogoRelativePath
        {
            get { return "http://qa-app.preventionhealth.org/Config/Content/Images/Logo-Small-160x60.gif"; }
        }

        /// <summary>
        ///  It will store the path of Provacy Statement of the Licensee
        /// </summary>
        public string PrivacyPolicyUrl
        {
            get { return "www.hotmail.com"; }
        }

        /// <summary>
        /// It will store the Path to Terms and Conditions of the licensee
        /// </summary>
        public string TermsConditionsUrl
        {
            get { return "www.Amazone.com"; }
        }

        public string CopyrightText
        {
            get { return "Don't even think of copying it!"; }
        }

        /// <summary>
        /// It will store the Path to Test Preparation URL
        /// </summary>
        public string TestPreparationInstructions
        {
            get { return "TestPreparation"; }
        }

        /// <summary>
        /// URL of the site
        /// </summary>
        public string SiteUrl
        {
            get { return "www.taazaa.com"; }
        }

        public string AppUrl
        {
            get { return "www.taazaa.com\app"; }
        }

        public string LoginUrl
        {
            get { return "www.taazaa.com"; }
        }

        public string CompanyName
        {
            get { return "Taazaa LLC"; }
        }

        public string FullBusinessName
        {
            get { return "Taazaa LLC"; }
        }

        public string PhoneTollFree
        {
            get { return "9871896686"; }
        }

        public Email SupportEmail
        {
            get { return new Email() { Address = "support@taazaa.com" }; }
        }

        public string SMTPserver
        {
            get { throw new NotImplementedException(); }
        }

        public string SMTPpassword
        {
            get { throw new NotImplementedException(); }
        }

        public string SMTPport
        {
            get { throw new NotImplementedException(); }
        }

        public Email EmailNotificationIssuedFrom
        {
            get { return new Email() { Address = "Support", DomainName = "taazaa.com" }; }
        }

        public string NameNotificationissuedFrom
        {
            get { return "Bidhan"; }
        }

        public string AuthorizeNetECheckUrl
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthorizeNetECheckLogin
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthorizeNetECheckTransactionKey
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthorizeNetECheckTransactionType
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthorizeNetECheckMerchantEmail
        {
            get { throw new NotImplementedException(); }
        }

        public string CyberSourceUrl
        {
            get { throw new NotImplementedException(); }
        }

        public string CyberSourceMerchant
        {
            get { throw new NotImplementedException(); }
        }

        public string CyberSourceTransactionKey
        {
            get { throw new NotImplementedException(); }
        }

        public string UploadResultPath
        {
            get { throw new NotImplementedException(); }
        }

        public string UploadImagePath
        {
            get { throw new NotImplementedException(); }
        }

        public string Address1
        {
            get { return "Address1"; }
        }

        public string Address2
        {
            get { return "Address2"; }
        }

        public string City
        {
            get { return "City"; }
        }

        public string State
        {
            get { return "State"; }
        }

        public string ZipCode
        {
            get { return "ZipCode"; }
        }

        public bool IsAuthorizationRequired
        {
            get { throw new NotImplementedException(); }
        }

        public decimal PrePayPercentage
        {
            get { throw new NotImplementedException(); }
        }

        public bool EnableCallPop
        {
            get { throw new NotImplementedException(); }
        }

        public string MediaUrl
        {
            get { return "http://media.abccare.com/"; }
        }

        public string MediaLocation
        {
            get { return Environment.GetEnvironmentVariable("MediaLocation"); }
        }

        public int DefaultPageSizeForReports
        {
            get { return 25; }
        }


        public bool IsRefundQueueEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public string BusinessTaxId
        {
            get { throw new NotImplementedException(); }
        }


        public string GiftCertificateImagePath
        {
            get { throw new NotImplementedException(); }
        }

        public string GiftCertificateThumbnailPath
        {
            get { throw new NotImplementedException(); }
        }

        public string ProcessorLogin
        {
            get { return "5Xx92Wxf"; } //hf
        }

        public string ProcessorTransactionKey
        {
            get { return "9f9sH564E68vSLg9"; } //hf
        }

        public bool ProcessorUseTestUrl
        {
            get { return false; }
        }

        public bool ProcessorUseTestTransaction
        {
            get { return false; }
        }

        public bool CapturePrimaryCarePhysician
        {
            get { return false; }
        }

        public bool EnableSurveyForCorporateEvents
        {
            get { return false; }
        }


        public bool IsEccEnabled
        {
            get { throw new NotImplementedException(); }
        }


        public string ResultMediaLocationPrefix
        {
            get { throw new NotImplementedException(); }
        }

        public string ResultMediaUrlPrefix
        {
            get { throw new NotImplementedException(); }
        }

        public bool EnableMassRegistration
        {
            get { return false; }
        }

        public bool ShowPartnerRelease
        {
            get { return false; }
        }


        public string SiteConfigurableContentPath
        {
            get { throw new NotImplementedException(); }
        }

        public string LargeLogoLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string MediumLogoLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string SmallLogoLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplatePremiumVersionLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplateClinicalFormLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplatePremiumVersionWithImagesLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplateIndexPageLocation
        {
            get { throw new NotImplementedException(); }
        }

        public string LargeLogoFileName
        {
            get { throw new NotImplementedException(); }
        }

        public string MediumLogoFileName
        {
            get { throw new NotImplementedException(); }
        }

        public string SmallLogoFileName
        {
            get { throw new NotImplementedException(); }
        }


        public bool CopyOverMediainPremiumResultReport
        {
            get { throw new NotImplementedException(); }
        }

        public bool IncludeHealthAssesmentForm
        {
            get { throw new NotImplementedException(); }
        }

        public bool IncludeCustomerSectioninPremiumResultReport
        {
            get { throw new NotImplementedException(); }
        }


        public string HealthAssessmentFormUrl
        {
            get { throw new NotImplementedException(); }
        }

        public string CompanyCustomizedLetter
        {
            get { throw new NotImplementedException(); }
        }

        public string ContentPages
        {
            get { throw new NotImplementedException(); }
        }

        public string DoctorLetter
        {
            get { throw new NotImplementedException(); }
        }


        public int ResultArchiveWaitDays
        {
            get { throw new NotImplementedException(); }
        }

        public string ResultArchiveSharedDrivePath
        {
            get { throw new NotImplementedException(); }
        }


        public bool IsStrokeInferenceForPHS
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime EvaluationReminderSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public string BloodWorksAccountDetails
        {
            get { throw new NotImplementedException(); }
        }


        public string TemplateCoverLetterLocation
        {
            get { throw new NotImplementedException(); }
        }


        public string EkgParserFolderRepresentation
        {
            get { throw new NotImplementedException(); }
        }

        public string EkgParsertoUse
        {
            get { throw new NotImplementedException(); }
        }


        public string TemplatePaperBackPremiumVersionLocation
        {
            get { throw new NotImplementedException(); }
        }


        public bool EnableResultDeliveryNotification
        {
            get { throw new NotImplementedException(); }
        }


        public string AaaParsertoUse
        {
            get { throw new NotImplementedException(); }
        }


        public bool CleanUpHtmlFiles
        {
            get { throw new NotImplementedException(); }
        }


        public int IntervalResultDelivery
        {
            get { throw new NotImplementedException(); }
        }

        public int IntervalResultDeliveryBuffer
        {
            get { throw new NotImplementedException(); }
        }

        public string CustomerPortalPhoneTollFree
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplateBloodLetterLoaction
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplateCorporateCoverLetterLocation
        {
            get { throw new NotImplementedException(); }
        }


        public DateTime ScreeningReminderSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public int DaysBeforeScreeningReminder
        {
            get { throw new NotImplementedException(); }
        }

        public string AnnualReminderPhoneTollFree
        {
            get { throw new NotImplementedException(); }
        }

        public int DaysBeforeAnnualDate
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxNumberOfRecordsToFetch
        {
            get { throw new NotImplementedException(); }
        }

        public int ShowNoOfRecords
        {
            get { throw new NotImplementedException(); }
        }

        public string AnnualReminderSourceCode
        {
            get { throw new NotImplementedException(); }
        }

        public string CheckOutUrl
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime AnnualReminderSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime SurveyEmailSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime ProspectCustomerFollowUpSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public bool HideEkgSection
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime? StrokeFindingChangeDate
        {
            get { throw new NotImplementedException(); }
        }

        public bool CheckShippingPurchase
        {
            get { return false; }
        }

        public bool CaptureEmployeeId
        {
            get { return false; }
        }

        public bool CaptureInsuranceId
        {
            get { return false; }
        }

        public DateTime TestUpsellSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public int DaysAfterResultReady
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime SecondResultReadyNotificationSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime EventResultReadyNotificationSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public int IntervalEventResultReady
        {
            get { throw new NotImplementedException(); }
        }

        public bool HideShippingOption
        {
            get { throw new NotImplementedException(); }
        }

        public bool SelectFreeShippingByDefault
        {
            get { throw new NotImplementedException(); }
        }

        public int HoursBeforeSecondScreeningReminder
        {
            get { throw new NotImplementedException(); }
        }

        public int IntervalSecondScreeningReminder
        {
            get { throw new NotImplementedException(); }
        }

        public bool HideResultPurchase
        {
            get { throw new NotImplementedException(); }
        }

        public bool HideProductPurchase
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime? OsteoChangeDate
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime KynFirstNotificationSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public int DaysAfterRegistrationKynFirstNotification
        {
            get { throw new NotImplementedException(); }
        }

        public int HoursBeforeKynSecondNotification
        {
            get { throw new NotImplementedException(); }
        }

        public int IntervalKynSecondNotification
        {
            get { throw new NotImplementedException(); }
        }

        public bool EligibilityTestMode
        {
            get { throw new NotImplementedException(); }

        }

        public string EligibilityApiKey
        {
            get { throw new NotImplementedException(); }

        }

        public string EligibilityProviderFirstName
        {
            get { throw new NotImplementedException(); }

        }

        public string EligibilityProviderLastName
        {
            get { throw new NotImplementedException(); }

        }

        public string EligibilityProviderNpi
        {
            get { throw new NotImplementedException(); }

        }

        public DateTime InsuranceEncounterSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime InsuranceClaimSchedulingTime
        {
            get { throw new NotImplementedException(); }
        }

        public int DaysAfterGetClaim
        {
            get { throw new NotImplementedException(); }
        }

        public int CallQueueServiceInterval
        {
            get { throw new NotImplementedException(); }
        }

        public int PullBackCallQueueCustomerInterval
        {
            get { throw new NotImplementedException(); }
        }

        public string LipidTemplate
        {
            get { throw new NotImplementedException(); }
        }

        public string KynDataTemplate { get; private set; }

        public string KynTemplate
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplateImageLocation
        {
            get { throw new NotImplementedException(); }
        }

        public int GenerateKynXmlInterval
        {
            get { throw new NotImplementedException(); }
        }

        public int HoursBeforeScreeningReminderViaSms
        {
            get { return 1; }
        }

        public int SmsInterval
        {
            get { throw new NotImplementedException(); }
        }

        public string SmsSystemIdentification
        {
            get { throw new NotImplementedException(); }
        }

        public string SmsAuthorizationToken
        {
            get { throw new NotImplementedException(); }
        }

        public string SmsFromNumber
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DoNotSendSmsBeforeTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("DoNotSendSmsBeforeTime")); }
        }

        public DateTime SendSmsBeforeTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("SendSmsBeforeTime")); }
        }

        public string EFaxAccountId
        {
            get { throw new NotImplementedException(); }
        }

        public int FaxServiceInvokeInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("FaxServiceInvokeInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public string EFaxUserName
        {
            get { throw new NotImplementedException(); }
        }

        public string EFaxPassword
        {
            get { throw new NotImplementedException(); }
        }

        public string EFaxDispositionRecipient
        {
            get { throw new NotImplementedException(); }
        }

        public string EFaxDispositionEmail
        {
            get { throw new NotImplementedException(); }
        }


        public DateTime FaxResultNotificationQueueTime
        {
            get { throw new NotImplementedException(); }
        }


        public DateTime FaxResultNotificationPushTime
        {
            get { throw new NotImplementedException(); }
        }

        public string TemplatePcpCoverLetterWithDianosisCodeLocation
        {
            get { throw new NotImplementedException(); }
        }


        public string PhysicianPartnerResultPdfDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicianPartnerResultPdfDownloadSettings"); }
        }

        public int PhysicianPartnerResultPdfDownloadInterval
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("PhysicianPartnerResultPdfDownloadInterval"));
            }
        }

        public DateTime PhysicianPartnerResultPdfDownloadTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PhysicianPartnerResultPdfDownloadTime"));
            }
        }

        public string PhysicianPartnerResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicianPartnerResultPdfDownloadPath"); }
        }

        public string PhysicianPartnerResultTiffDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicianPartnerResultTiffDownloadPath"); }
        }

        public string PhysicianPartnerAppointmentBookedReportDownloadSettings
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("PhysicianPartnerAppointmentBookedReportDownloadSettings");
            }
        }

        public int PhysicianPartnerAppointmentBookedReportDownloadInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(
                    ConfigurationManager.AppSettings.Get("PhysicianPartnerAppointmentBookedReportDownloadInterval"),
                    out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime PhysicianPartnerAppointmentBookedReportDownloadTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("PhysicianPartnerAppointmentBookedReportDownloadTime"));
            }
        }

        public string PhysicianPartnerAppointmentBookedReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicianPartnerAppointmentBookedReportDownloadPath"); }
        }



        public string PhysicianPartnerResultReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicianPartnerResultReportDownloadSettings"); }
        }

        public int PhysicianPartnerResultReportDownloadInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("PhysicianPartnerResultReportDownloadInterval"),
                    out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime PhysicianPartnerResultReportDownloadTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PhysicianPartnerResultReportDownloadTime"));
            }
        }

        public string PhysicianPartnerResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicianPartnerResultReportDownloadPath"); }
        }

        public string EmergencyFaxNumber
        {
            get { return ConfigurationManager.AppSettings.Get("EmergencyFaxNumber"); }
        }

        public TimeSpan TimeIntervalToPingApi
        {
            get
            {
                var timeInterval = Convert.ToInt32(ConfigurationManager.AppSettings.Get("TimeIntervalToPingAPI"));
                return new TimeSpan(0, timeInterval, 0);
            }
        }

        public TimeSpan MaximumTimeToWaitApi
        {
            get
            {
                var timeInterval = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaximumTimeToWaitApi"));
                return new TimeSpan(0, timeInterval, 0);
            }
        }

        public int FaxPushToApiServiceInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("FaxPushToApiServiceInterval")); }
        }

        public long PhysicianPartnerAccountId
        {
            get { throw new NotImplementedException(); }
        }

        public int KynXmlIntervalInMinutes
        {
            get { throw new NotImplementedException(); }
        }

        public int KynXmlIntervalInHours
        {
            get { throw new NotImplementedException(); }
        }

        public int MinimumAgeForScreening
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("minimumAgeForScreening"), out hours);
                return hours;
            }
        }

        public int AwvFaxServiceInvokeInterval
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("FaxServiceInvokeInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public int AwvPcpImportInterval
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("AwvPcpImportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime AwvPcpImportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("AwvPcpImportScheduleTime")); }
        }

        public string AwvPcpImportSourcePath
        {
            get { return ConfigurationManager.AppSettings.Get("AwvPcpImportSourcePath"); }
        }

        public string AwvPcpImportArchivePath
        {
            get { return ConfigurationManager.AppSettings.Get("AwvPcpImportArchivePath"); }
        }

        public int MaximumDataRowCountLimitForCsvParser
        {
            get
            {
                int maximumDataRowCount;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("MaximumDataRowCountLimitForCsvParser"),
                    out maximumDataRowCount);
                return maximumDataRowCount;
            }
        }

        public string TemplatePcpCoverLetterLocation
        {
            get
            {
                return SiteConfigurableContentPath + @"\ResultPacket\" +
                       ConfigurationManager.AppSettings.Get("TemplatePcpCoverLetterLocation");
            }
        }

        public bool CaptureBloodTest
        {
            get { return bool.Parse(ConfigurationManager.AppSettings.Get("CaptureBloodTest")); }
        }

        public int WarningMessageTime
        {
            get { return int.Parse(ConfigurationManager.AppSettings.Get("WarningMessageTime")); }
        }

        public IEnumerable<long> ShowScannedDocumentHospitalPartnerIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("ShowScannedDocumentHospitalPartnerIds");
                var hospitalIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return hospitalIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long hospitalId;
                    long.TryParse(hospitalIdstr, out hospitalId);
                    if (hospitalId > 0)
                    {
                        hospitalIds.Add(hospitalId);
                    }
                }

                return hospitalIds;
            }
        }

        public string ApplicatoinDomainUrl
        {
            get { return ConfigurationManager.AppSettings.Get("ApplicatoinDomainUrl"); }
        }

        public string BloodTestFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("BloodTestFolderLocation"); }
        }

        public string BloodTestArchiveFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("BloodTestArchiveFolderLocation"); }
        }

        public int BloodTestResultParserInterval
        {
            get
            {
                int minutes = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("BloodTestResultParserInterval"), out minutes);
                return (minutes < 0 ? 15 : minutes);
            }
        }

        public DateTime BloodTestChangeDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BloodTestChangeDate")); }
        }

        public DateTime ShowHideRepeatStudyDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ShowHideRepeatStudyDate")); }
        }

        public DateTime BasicBiometricCutOfDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BasicBiometricCutOfDate")); }
        }

        public int DaysToCheckPriorityInQueue
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DaysToCheckPriorityInQueue"), out days);
                return (days < 1 ? 1 : days);
            }
        }

        public int PriorityInQueueInterval
        {
            get
            {
                int minutes;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("PriorityInQueueInterval"), out minutes);
                return (minutes < 1 ? 1 : minutes);
            }
        }

        public int DynamicSchedulingMaximumScreeningTime
        {
            get
            {
                int minutes;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DynamicSchedulingMaximumScreeningTime"),
                    out minutes);
                return (minutes < 1 ? 1 : minutes);
            }
        }

        public int DynamicSchedulingMinimumScreeningTime
        {
            get
            {
                int minutes;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DynamicSchedulingMinimumScreeningTime"),
                    out minutes);
                return (minutes < 1 ? 1 : minutes);
            }
        }

        public DateTime? HemoglobinChangeDate
        {
            get
            {
                DateTime hemoglobinChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("HemoglobinChangeDate"),
                    out hemoglobinChangeDate))
                    return hemoglobinChangeDate;
                return null;
            }
        }

        public string DomainUrl
        {
            get { return ConfigurationManager.AppSettings.Get("ApplicatoinDomainUrl"); }
        }

        public string AngularAppUrl
        {
            get { return DomainUrl + "App/"; }
        }

        public int SystemGeneratedCallQueueGenerationInterval
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("SystemGeneratedCallQueueGenerationInterval"),
                    out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime SystemGeneratedCallQueueGenerationScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("SystemGeneratedCallQueueGenerationScheduleTime"));
            }
        }

        public int SystemGeneratedCallQueuePastEventDeleteInterval
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("SystemGeneratedCallQueuePastEventDeleteInterval"),
                    out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime SystemGeneratedCallQueuePastEventDeleteScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("SystemGeneratedCallQueuePastEventDeleteScheduleTime"));
            }
        }

        public string BloodLabFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("BloodLabFolderLocation"); }
        }

        public string BloodLabArchiveFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("BloodLabArchiveFolderLocation"); }
        }

        public int NoOfDaysToIncludeRemovedFromQueue
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("NoOfDaysToIncludeRemovedFromQueue"), out days);
                return (days < 1 ? 1 : days);
            }
        }

        public int PullBackCallQueueCustomerServiceInterval
        {
            get
            {
                int minutes = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("PullBackCallQueueCustomerServiceInterval"),
                    out minutes);
                return (minutes < 1 ? 1 : minutes);
            }
        }

        public DateTime ShowHideRepeatVisionConfrontationDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ShowHideRepeatVisionConfrontationDate"));
            }
        }

        public DateTime? AwvAaaFindingChangeDate
        {
            get
            {
                DateTime newAwvAaaFindingDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("AwvAaaFindingChangeDate"),
                    out newAwvAaaFindingDate))
                    return newAwvAaaFindingDate;
                return null;
            }
        }

        public string DiabeticRetinopathyFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("DiabeticRetinopathyFolderLocation"); }
        }

        public string DiabeticRetinopathyArchiveFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("DiabeticRetinopathyArchiveFolderLocation"); }
        }

        public int DiabeticRetinopathyNoOfDaysToCheckForEvent
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DiabeticRetinopathyNoOfDaysToCheckForEvent"),
                    out days);
                return (days < 1 ? 1 : days);
            }
        }

        public int DiabeticRetinopathyResultParserInterval
        {
            get
            {
                int minutes = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DiabeticRetinopathyResultParserInterval"),
                    out minutes);
                return (minutes < 0 ? 15 : minutes);
            }
        }

        public IEnumerable<long> PcpResultPdfDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("PcpResultPdfDownloadAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string PcpResultPdfDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("PcpResultPdfDownloadSettings"); }
        }

        public string PcpResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PcpResultPdfDownloadPath"); }
        }

        public IEnumerable<long> PcpAppointmentBookedReportDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("PcpAppointmentBookedReportAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string PcpAppointmentBookedReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("PcpAppointmentBookedReportDownloadSettings"); }
        }

        public string PcpAppointmentBookedReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PcpAppointmentBookedReportDownloadPath"); }
        }

        public IEnumerable<long> PcpResultReportDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("PcpResultReportDownloadAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }


        public string WellmedSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpHost"); }
        }

        public string WellmedSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpUserName"); }
        }

        public string WellmedSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpPassword"); }
        }

        public long WellmedAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("WellmedAccountId"), out accountId);
                return accountId;
            }
        }

        public bool SendReportToWellmedSftp
        {
            get
            {
                bool sendReporttoWellmed;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToWellmedSftp"), out sendReporttoWellmed);
                return sendReporttoWellmed;
            }
        }

        public string WellmedResultPdfDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedResultPdfDownloadSettings"); }
        }

        public string WellmedResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedResultPdfDownloadPath"); }
        }

        public string WellmedSftpResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpResultPdfDownloadPath"); }
        }

        public string WellmedAppointmentBookedReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedAppointmentBookedReportDownloadSettings"); }
        }

        public string WellmedAppointmentBookedReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedAppointmentBookedReportDownloadPath"); }
        }

        public string WellmedSftpAppointmentBookedReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpAppointmentBookedReportDownloadPath"); }
        }

        public string WellmedResultReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedResultReportDownloadSettings"); }
        }

        public string WellmedResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedResultReportDownloadPath"); }
        }

        public string WellmedSftpResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpResultReportDownloadPath"); }
        }


        public string PcpResultReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("PcpResultReportDownloadSettings"); }
        }

        public string PcpResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("PcpResultReportDownloadPath"); }
        }

        public DateTime PcpDownloadCutOfDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PcpDownloadCutOfDate")); }
        }

        public long HcpCaliforniaAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("HcpCaliforniaAccountId"), out accountId);
                return accountId;
            }
        }

        public string HcpCaliforniaResultPdfDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("HcpCaliforniaResultPdfDownloadSettings"); }
        }

        public string HcpCaliforniaResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HcpCaliforniaResultPdfDownloadPath"); }
        }

        public string MongoDbConnectionString
        {
            get { return ConfigurationManager.AppSettings.Get("MongoDbConnectionString"); }
        }

        public string DefaultMongoDatabase
        {
            get { return ConfigurationManager.AppSettings.Get("DefaultMongoDatabase"); }
        }

        public string DefaultMongoDatabaseCollection
        {
            get { return ConfigurationManager.AppSettings.Get("DefaultMongoDatabaseCollection"); }
        }

        public bool AuditEnabled
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("AuditEnabled")); }
        }

        public string ArchiveResultDataSettingsPath
        {
            get { return ConfigurationManager.AppSettings.Get("ArchiveResultDataSettingsPath"); }
        }

        public int ArchiveResultDataForOlderThanDays
        {
            get
            {
                int days = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("ArchiveResultDataForOlderThanDays"), out days);
                return days;
            }
        }

        public int ArchiveResultDataIntervalHrs
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("ArchiveResultDataIntervalHrs"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime ArchiveResultDataScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ArchiveResultDataScheduleTime")); }
        }

        public string ArchiveMediaUrl
        {
            get { return ConfigurationManager.AppSettings.Get("ArchiveMediaUrl"); }
        }

        public string ArchiveMediaLocation
        {
            get { return ConfigurationManager.AppSettings.Get("ArchiveMediaLocation"); }
        }

        public string ApplicationIdentity
        {
            get { return ConfigurationManager.AppSettings.Get("ApplicationIdentity"); }
        }

        public DateTime? Phq9ChangeDate
        {
            get
            {
                DateTime phq9ChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("Phq9ChangeDate"), out phq9ChangeDate))
                    return phq9ChangeDate;
                return null;
            }
        }

        public DateTime? QualityMeasuresChangeDate
        {
            get
            {
                DateTime qualityMeasuresChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("QualityMeasuresChangeDate"),
                    out qualityMeasuresChangeDate))
                    return qualityMeasuresChangeDate;
                return null;
            }
        }

        public DateTime? AwvEchoFindingChangeDate
        {
            get
            {
                DateTime newAwvEchoFindingDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("AwvEchoFindingChangeDate"),
                    out newAwvEchoFindingDate))
                    return newAwvEchoFindingDate;
                return null;
            }
        }

        public long MolinaAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("MolinaAccountId"), out accountId);
                return accountId;
            }
        }

        public string MolinaAppointmentBookedReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaAppointmentBookedReportDownloadSettings"); }
        }

        public string MolinaAppointmentBookedReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaAppointmentBookedReportDownloadPath"); }
        }

        public string MolinaResultPdfDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaResultPdfDownloadSettings"); }
        }

        public string MolinaResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaResultPdfDownloadPath"); }
        }

        public string MolinaResultReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaResultReportDownloadSettings"); }
        }

        public string MolinaResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaResultReportDownloadPath"); }
        }

        public bool DeleteFileAfterPgpEcnryption
        {
            get
            {
                bool deleteFileAfterEncryption;
                bool.TryParse(ConfigurationManager.AppSettings.Get("DeleteFileAfterPgpEcnryption"),
                    out deleteFileAfterEncryption);
                return deleteFileAfterEncryption;
            }
        }

        public int RedisDatabaseKey
        {
            get
            {
                int redisDatabaseKey = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("RedisDatabaseKey"), out redisDatabaseKey);
                return redisDatabaseKey;
            }
        }

        public DateTime UnlockCorporateEventsScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("UnlockCorporateEventsScheduleTime"));
            }
        }

        public int UnlockCorporateEventsScheduleInterval
        {
            get
            {
                int unlockCorporateEventsScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("UnlockCorporateEventsScheduleInterval"),
                    out unlockCorporateEventsScheduleInterval);
                return unlockCorporateEventsScheduleInterval;
            }
        }

        public int ParseLockedEventFileSchduleInterval
        {
            get
            {
                int parseLockedEventFileSchduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("ParseLockedEventFileSchduleInterval"),
                    out parseLockedEventFileSchduleInterval);
                return parseLockedEventFileSchduleInterval;
            }
        }

        public DateTime LockCorporateEventScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("LockCorporateEventScheduleTime")); }
        }

        public int LockCorporateEventScheduleInterval
        {
            get
            {
                int unlockCorporateEventsScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("LockCorporateEventScheduleInterval"),
                    out unlockCorporateEventsScheduleInterval);
                return unlockCorporateEventsScheduleInterval;
            }
        }

        public string WellmedLockCorporateEventFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedLockCorporateEventFolderLocation"); }
        }

        public int NoShowCustomerScheduleInterval
        {
            get
            {
                int noShowCustomerScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("NoShowCustomerScheduleInterval"),
                    out noShowCustomerScheduleInterval);
                return noShowCustomerScheduleInterval;
            }
        }

        public int MinutesAfterAppointmentTime
        {
            get
            {
                int minutesAfterAppointmentTime = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("MinutesAfterAppointmentTime"),
                    out minutesAfterAppointmentTime);
                return minutesAfterAppointmentTime;
            }
        }

        public int NoPastAppointmentInDays
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("NoPastAppointmentInDays"), out days);
                return (days < 1 ? 1 : days);
            }
        }

        public int HealthPlanCallQueueGenerationInterval
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanCallQueueGenerationInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime HealthPlanCallQueueGenerationScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanCallQueueGenerationScheduleTime"));
            }
        }

        public DateTime HealthPlanIncorrectPhoneExportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanIncorrectPhoneExportScheduleTime"));
            }
        }

        public DateTime HealthPlanHomeVisitRequestedExportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("HealthPlanHomeVisitRequestedExportScheduleTime"));
            }
        }

        public int HealthPlanCustomerListExportScheduleInterval
        {
            get
            {
                int healthPlanCustomerListExportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanCustomerListExportScheduleInterval"),
                    out healthPlanCustomerListExportScheduleInterval);
                return healthPlanCustomerListExportScheduleInterval;
            }
        }


        public string HealthPlanIncorrectPhoneExportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanIncorrectPhoneExportDownloadPath"); }
        }

        public string HealthPlanHomeVisitRequestExportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanHomeVisitRequestExportDownloadPath"); }
        }


        public DateTime HealthPlanCustomerExportCutoffDate
        {
            get
            {
                DateTime healthPlanCustomerExportCutoffDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanCustomerExportCutoffDate"),
                    out healthPlanCustomerExportCutoffDate))
                    return healthPlanCustomerExportCutoffDate;

                return DateTime.Today;
            }
        }

        public int PageSizeHealthPlanExport
        {
            get
            {
                var pageSizeHealthPlanExport = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("PageSizeHealthPlanExport"),
                    out pageSizeHealthPlanExport);
                if (pageSizeHealthPlanExport <= 25)
                    pageSizeHealthPlanExport = 25;

                return pageSizeHealthPlanExport;
            }
        }

        public DayOfWeek HealthPlanCustomerExportIntervalDay
        {
            get
            {
                try
                {
                    var healthPlanCustomerExportIntervalDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanCustomerExportIntervalDay"),
                        out healthPlanCustomerExportIntervalDay);
                    if (healthPlanCustomerExportIntervalDay >= 0 && healthPlanCustomerExportIntervalDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("HealthPlanCustomerExportIntervalDay"));
                    }
                }
                catch
                {

                }
                return DayOfWeek.Sunday;
            }
        }


        public string MolinaSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaSftpHost"); }
        }

        public string MolinaSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaSftpUserName"); }
        }

        public string MolinaSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaSftpPassword"); }
        }

        public string MolinaLockCorporateEventFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("MolinaLockCorporateEventFolderLocation"); }
        }

        public string RedisServerHost
        {
            get { return ConfigurationManager.AppSettings.Get("RedisServerHost"); }
        }

        public string RedisChannelQueuePrefix
        {
            get { return ConfigurationManager.AppSettings.Get("RedisChannelQueuePrefix"); }
        }

        public DateTime? AttachAttestationFormDate
        {
            get
            {
                DateTime attachAttestationFormDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("AttachAttestationFormDate"),
                    out attachAttestationFormDate))
                    return attachAttestationFormDate;
                return null;
            }
        }

        public string WellmedWeeklyAppointmentBookedReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedWeeklyAppointmentBookedReportPath"); }
        }

        public string WellmedSftpWeeklyAppointmentBookedReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpWeeklyAppointmentBookedReportPath"); }
        }

        public DayOfWeek WellmedWeeklyAppointmentBookedReportIntervalDay
        {
            get
            {
                try
                {
                    var wellmedWeeklyAppointmentBookedReportIntervalDay = 0;
                    int.TryParse(
                        ConfigurationManager.AppSettings.Get("WellmedWeeklyAppointmentBookedReportIntervalDay"),
                        out wellmedWeeklyAppointmentBookedReportIntervalDay);
                    if (wellmedWeeklyAppointmentBookedReportIntervalDay >= 0 &&
                        wellmedWeeklyAppointmentBookedReportIntervalDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get(
                                        "WellmedWeeklyAppointmentBookedReportIntervalDay"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public DateTime WellmedWeeklyAppointmentBookedReportTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("WellmedWeeklyAppointmentBookedReportTime"));
            }
        }

        public bool StopMediaArchiveService
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("StopMediaArchiveService")); }
        }

        public DateTime? MammogramChangeDate
        {
            get
            {
                DateTime mammogramChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("MammogramChangeDate"),
                    out mammogramChangeDate))
                    return mammogramChangeDate;
                return null;
            }
        }

        public DateTime HealthPlanFillEventCallQueueGenerationScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("HealthPlanFillEventCallQueueGenerationScheduleTime"));
            }
        }

        public int NeverBeenCalledInDays
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("NeverBeenCalledInDays"), out days);
                return (days < 1 ? 1 : days);
            }
        }

        public int NoPastAppointmentInDaysUncontactedCustomers
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("NoPastAppointmentInDaysUncontactedCustomers"),
                    out days);
                return (days < 1 ? 1 : days);
            }
        }

        public DateTime HealthPlanUncontactedCustomersGenerationScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("HealthPlanUncontactedCustomersGenerationScheduleTime"));
            }
        }

        public int CallUploadParserInterval
        {
            get
            {
                var callUploadParserInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("CallUploadParserInterval"),
                    out callUploadParserInterval);
                if (callUploadParserInterval <= 1)
                    callUploadParserInterval = 1;

                return callUploadParserInterval;
            }
        }

        public int ApplyRulesOnLockedCustomersInterval
        {
            get
            {
                var applyRulesOnLockedCustomersInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("ApplyRulesOnLockedCustomersInterval"),
                    out applyRulesOnLockedCustomersInterval);
                if (applyRulesOnLockedCustomersInterval <= 1)
                    applyRulesOnLockedCustomersInterval = 1;

                return applyRulesOnLockedCustomersInterval;
            }
        }

        public DateTime HealthPlanCriteriaForDeletionScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanCriteriaForDeletionScheduleTime"));
            }
        }

        public int HealthPlanCriteriaForDeletionInterval
        {
            get
            {
                var healthPlanCriteriaForDeletionInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanCriteriaForDeletionInterval"),
                    out healthPlanCriteriaForDeletionInterval);
                if (healthPlanCriteriaForDeletionInterval <= 1)
                    healthPlanCriteriaForDeletionInterval = 1;

                return healthPlanCriteriaForDeletionInterval;
            }
        }

        public DateTime? IFobtChangeDate
        {
            get
            {
                DateTime ifobtChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("IFobtChangeDate"), out ifobtChangeDate))
                    return ifobtChangeDate;
                return null;
            }
        }

        public DateTime? UrineMicroalbuminChangeDate
        {
            get
            {
                DateTime urineMicroalbuminChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("UrineMicroalbuminChangeDate"),
                    out urineMicroalbuminChangeDate))
                    return urineMicroalbuminChangeDate;
                return null;
            }
        }

        public DateTime DirectMailActivityReminderScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("DirectMailActivityReminderScheduleTime"));
            }
        }

        public int DirectMailActivityReminderInterval
        {
            get
            {
                var directMailActivityReminderInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("DirectMailActivityReminderInterval"),
                    out directMailActivityReminderInterval);
                if (directMailActivityReminderInterval <= 1)
                    directMailActivityReminderInterval = 1;

                return directMailActivityReminderInterval;
            }
        }

        public IEnumerable<long> NtspAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("NtspAccountIds");
                var ntspAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return ntspAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        ntspAccountIds.Add(pcpAccountId);
                    }
                }

                return ntspAccountIds;
            }
        }

        public string NtspResultPdfDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("NtspResultPdfDownloadSettings"); }
        }

        public string NtspResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("NtspResultPdfDownloadPath"); }
        }

        public int NoOfDaysAfterDeleteReports
        {
            get
            {
                int days;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("NoOfDaysAfterDeleteReports"), out days);
                return (days < 1 ? 1 : days);
            }
        }

        public bool IsDevEnvironment
        {
            get
            {
                bool isDevEnvironment;
                bool.TryParse(ConfigurationManager.AppSettings.Get("IsDevEnvironment"), out isDevEnvironment);

                return isDevEnvironment;
            }
        }

        public int SendCancelRescheduleNotificationBeforeDays
        {
            get
            {
                var cancelRescheduleNotificationBeforeDays = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("SendCancelRescheduleNotificationBeforeDays"),
                    out cancelRescheduleNotificationBeforeDays);
                if (cancelRescheduleNotificationBeforeDays <= 1)
                    cancelRescheduleNotificationBeforeDays = 1;

                return cancelRescheduleNotificationBeforeDays;
            }
        }

        public string TemplateTestNotPerformedLocation
        {
            get
            {
                return SiteConfigurableContentPath + @"\ResultPacket\" +
                       ConfigurationManager.AppSettings.Get("TemplateTestNotPerformedLocation");
            }
        }

        public string HcpCaliforniaSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("HcpCaliforniaSftpHost"); }
        }

        public string HcpCaliforniaSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("HcpCaliforniaSftpUserName"); }
        }

        public string HcpCaliforniaSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("HcpCaliforniaSftpPassword"); }
        }

        public bool SendReportToHcpCaliforniaSftp
        {
            get
            {
                bool sendReporttoHcpCalifornia;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToHcpCaliforniaSftp"),
                    out sendReporttoHcpCalifornia);
                return sendReporttoHcpCalifornia;
            }
        }

        public string HcpCaliforniaSftpResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HcpCaliforniaSftpResultPdfDownloadPath"); }
        }

        public string HealthPlanTestNotPerformedExportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanTestNotPerformedExportDownloadPath"); }
        }

        public int HealthPlanTestNotPerformedExportScheduleInterval
        {
            get
            {
                var healthPlanTestNotPerformedExportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanTestNotPerformedExportScheduleInterval"),
                    out healthPlanTestNotPerformedExportScheduleInterval);
                if (healthPlanTestNotPerformedExportScheduleInterval <= 1)
                    healthPlanTestNotPerformedExportScheduleInterval = 1;

                return healthPlanTestNotPerformedExportScheduleInterval;
            }
        }

        public DateTime HealthPlanTestNotPerformedExportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("HealthPlanTestNotPerformedExportScheduleTime"));
            }
        }

        public DayOfWeek HealthPlanTestNotPerformedIntervalDay
        {
            get
            {
                var healthPlanTestNotPerformedIntervalDay = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanTestNotPerformedIntervalDay"),
                    out healthPlanTestNotPerformedIntervalDay);
                if (healthPlanTestNotPerformedIntervalDay >= 1 && healthPlanTestNotPerformedIntervalDay <= 6)
                {
                    return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), healthPlanTestNotPerformedIntervalDay.ToString());
                }

                return DayOfWeek.Sunday;
            }
        }

        public DateTime HealthPlanTestNotPerformedCutOfDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanTestNotPerformedCutOfDate"));
            }
        }

        public string HealthPlanOutreachReportExportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanOutreachReportExportDownloadPath"); }
        }

        public int HealthPlanOutreachReportExportScheduleInterval
        {
            get
            {
                var healthPlanOutreachReportExportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanOutreachReportExportScheduleInterval"),
                    out healthPlanOutreachReportExportScheduleInterval);
                if (healthPlanOutreachReportExportScheduleInterval <= 1)
                    healthPlanOutreachReportExportScheduleInterval = 1;

                return healthPlanOutreachReportExportScheduleInterval;
            }
        }

        public DateTime HealthPlanOutreachReportExportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanOutreachReportExportScheduleTime"));
            }
        }

        public DayOfWeek HealthPlanOutreachReportIntervalDay
        {
            get
            {
                var healthPlanOutreachReportIntervalDay = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanOutreachReportIntervalDay"),
                    out healthPlanOutreachReportIntervalDay);
                if (healthPlanOutreachReportIntervalDay >= 1 && healthPlanOutreachReportIntervalDay <= 6)
                {
                    return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), healthPlanOutreachReportIntervalDay.ToString());
                }

                return DayOfWeek.Sunday;
            }
        }

        public DateTime HealthPlanOutreachReportCutOfDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanOutreachReportCutOfDate"));
            }
        }

        public IEnumerable<long> HealthPlanOutreachReportAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("HealthPlanOutreachReportAccountIds");
                var hpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpAccountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        hpAccountIds.Add(hpAccountId);
                    }
                }

                return hpAccountIds;
            }

        }

        public long MartinPointAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("MartinPointAccountId"), out accountId);
                return accountId;
            }
        }

        public string MartinPointAppointmentBookedReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("MartinPointAppointmentBookedReportPath"); }
        }

        public DateTime MartinPointAppointmentBookedReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("MartinPointAppointmentBookedReportScheduleTime"));
            }
        }

        public IEnumerable<long> PatientInputFileAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("PatientInputFileAccountIds");
                var hpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpAccountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        hpAccountIds.Add(hpAccountId);
                    }
                }

                return hpAccountIds;
            }
        }

        public string PatientInputFileReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("PatientInputFileReportPath"); }
        }

        public DateTime PatientInputFileScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PatientInputFileScheduleTime")); }
        }

        public int PatientInputFileScheduleInterval
        {
            get
            {
                var patientInputFileScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("PatientInputFileScheduleInterval"),
                    out patientInputFileScheduleInterval);
                if (patientInputFileScheduleInterval <= 1)
                    patientInputFileScheduleInterval = 1;

                return patientInputFileScheduleInterval;
            }
        }

        public DateTime HealthPlanLanguageBarrierScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanLanguageBarrierScheduleTime"));
            }
        }

        public DateTime? FluShotChangeDate
        {
            get
            {
                DateTime fluShotChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("FluShotChangeDate"), out fluShotChangeDate))
                    return fluShotChangeDate;
                return null;
            }
        }

        public DateTime? AwvFluShotChangeDate
        {
            get
            {
                DateTime awvFluShotChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("AwvFluShotChangeDate"),
                    out awvFluShotChangeDate))
                    return awvFluShotChangeDate;

                return null;
            }
        }

        public DateTime? PneumococcalChangeDate
        {
            get
            {
                DateTime pneumococcalChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("PneumococcalChangeDate"),
                    out pneumococcalChangeDate))
                    return pneumococcalChangeDate;
                return null;
            }


        }

        public DateTime? ChangeLeadReadingDate
        {
            get
            {
                DateTime changeLeadReadingDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("ChangeLeadReadingDate"),
                    out changeLeadReadingDate))
                    return changeLeadReadingDate;
                return null;
            }
        }

        public IEnumerable<long> BcbsAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("BcbsAccountIds");
                var bcbsAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return bcbsAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        bcbsAccountIds.Add(pcpAccountId);
                    }
                }

                return bcbsAccountIds;
            }
        }

        public string EventStaffRole
        {
            get { return ConfigurationManager.AppSettings.Get("EventStaffRole"); }
        }

        public long HealthPlanMemberStatusReportAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanMemberStatusReportAccountId"),
                    out accountId);
                return accountId;
            }
        }

        public string HealthPlanMemberStatusReportFileReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanMemberStatusReportFileReportPath"); }
        }

        public DateTime HealthPlanMemberStatusReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanMemberStatusReportScheduleTime"));
            }
        }

        public int HealthPlanMemberStatusReportScheduleInterval
        {
            get
            {
                var healthPlanMemberStatusReportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanMemberStatusReportScheduleInterval"),
                    out healthPlanMemberStatusReportScheduleInterval);
                if (healthPlanMemberStatusReportScheduleInterval <= 1)
                    healthPlanMemberStatusReportScheduleInterval = 1;

                return healthPlanMemberStatusReportScheduleInterval;
            }
        }

        public string BcbsSouthCarolinaCustomTag
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsSouthCarolinaCustomTag"); }
        }

        public string BcbsResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsResultPdfDownloadPath"); }
        }

        public long HcpNvAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("HcpNvAccountId"), out accountId);
                return accountId;
            }


        }

        public string HcpNvLockCorporateEventFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("HcpNvLockCorporateEventFolderLocation"); }
        }

        public string FloridaBlueAccountId
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueAccountId"); }
        }

        public DateTime? ChlamydiaChangeDate
        {
            get
            {
                DateTime chlamydiaChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("ChlamydiaChangeDate"),
                    out chlamydiaChangeDate))
                    return chlamydiaChangeDate;
                return null;
            }
        }

        public string HraQuestionerAppUrl
        {
            get { return ConfigurationManager.AppSettings.Get("HraQuestionerAppUrl"); }
        }

        public string OrganizationNameForHraQuestioner
        {
            get { return ConfigurationManager.AppSettings.Get("OrganizationNameForHraQuestioner"); }
        }

        public string MedicareApiUrl
        {
            get { return ConfigurationManager.AppSettings.Get("MedicareApiUrl"); }
        }

        public string MedicareTokenKeyName
        {
            get { return ConfigurationManager.AppSettings.Get("MedicareTokenKeyName"); }
        }

        public int RapsUploadParserInterval
        {
            get
            {
                var rapsUploadParserInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("RapsUploadParserInterval"),
                    out rapsUploadParserInterval);
                if (rapsUploadParserInterval <= 1)
                    rapsUploadParserInterval = 1;

                return rapsUploadParserInterval;
            }
        }

        public int DiabeticRetinopathyParserReportNumberOfDays
        {
            get
            {
                int diabeticRetinopathyParserReportNumberOfDays = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("DiabeticRetinopathyParserReportNumberOfDays"),
                    out diabeticRetinopathyParserReportNumberOfDays);
                return diabeticRetinopathyParserReportNumberOfDays;
            }
        }

        public string DiabeticRetinopathylogExportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("DiabeticRetinopathylogExportDownloadPath"); }
        }

        public DayOfWeek DiabeticRetinopathylogIntervalDay
        {
            get
            {
                var diabeticRetinopathylogIntervalDay = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("DiabeticRetinopathylogIntervalDay"),
                    out diabeticRetinopathylogIntervalDay);
                if (diabeticRetinopathylogIntervalDay >= 1 && diabeticRetinopathylogIntervalDay <= 6)
                {
                    return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), diabeticRetinopathylogIntervalDay.ToString());
                }
                return DayOfWeek.Sunday;
            }
        }

        public DateTime DiabeticRetinopathylogSchedule
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("DiabeticRetinopathylogSchedule")); }
        }

        public int DiabeticRetinopathylogInterval
        {
            get
            {
                int minutes = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DiabeticRetinopathylogInterval"), out minutes);
                return (minutes < 0 ? 15 : minutes);
            }
        }

        public long HealthNowAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("HealthNowAccountId"), out accountId);
                return accountId;
            }
        }

        public string HealthNowSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("HealthNowSftpHost"); }
        }

        public string HealthNowSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("HealthNowSftpUserName"); }
        }

        public string HealthNowSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("HealthNowSftpPassword"); }
        }

        public bool SendPdfToHealthNowSftp
        {
            get
            {
                bool sendReporttoWellmed;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendPdfToHealthNowSftp"), out sendReporttoWellmed);
                return sendReporttoWellmed;
            }
        }

        public string HealthNowSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthNowSftpPath"); }
        }

        public DateTime? FastingStatusDate
        {
            get
            {
                DateTime fastingStatusDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("FastingStatus"), out fastingStatusDate))
                    return fastingStatusDate;
                return null;
            }

        }

        public int DashboardEventListingPageSize
        {
            get { return 10; }
        }

        public IEnumerable<long> WellCareAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("WellCareAccountIds");
                var wellCareAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return wellCareAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        wellCareAccountIds.Add(pcpAccountId);
                    }
                }

                return wellCareAccountIds;
            }
        }

        public string WellCareSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("WellCareSftpHost"); }
        }

        public string WellCareSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("WellCareSftpUserName"); }
        }

        public string WellCareSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("WellCareSftpPassword"); }
        }

        public bool SendPdfToWellCareSftp
        {
            get
            {
                bool sendReporttoWellcare;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendPdfToWellCareSftp"), out sendReporttoWellcare);
                return sendReporttoWellcare;
            }
        }

        public string WellCareSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellCareSftpPath"); }
        }

        public DateTime? CorporateEventResultReadyCutoffDate
        {
            get
            {
                DateTime corporateEventResultReadyCutoffDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("CorporateEventResultReadyCutoffDate"),
                    out corporateEventResultReadyCutoffDate))
                    return corporateEventResultReadyCutoffDate;

                return null;
            }
        }

        public DateTime CorporateEventResultReadyNotificationSchedulingTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("CorporateEventResultReadyNotificationSchedulingTime"));
            }
        }

        public int IntervalCorporateEventResultReady
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("IntervalCorporateEventResultReady"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime OutboundChaseParseScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("OutboundChaseParseScheduleTime")); }
        }

        public int OutboundChaseParseIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("OutboundChaseParseIntervalHours"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime OutboundFileImportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("OutboundFileImportScheduleTime")); }
        }

        public int OutboundFileImportIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("OutboundFileImportIntervalHours"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public string OutboundSourceFileLocation
        {
            get { return ConfigurationManager.AppSettings.Get("OutboundSourceFileLocation"); }
        }

        public DateTime OutboundCareCodingParseScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("OutboundCareCodingParseScheduleTime"));
            }
        }

        public int OutboundCareCodingParseIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("OutboundCareCodingParseIntervalHours"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime ResponseVendorReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ResponseVendorReportScheduleTime")); }
        }

        public int ResponseVendorReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("ResponseVendorReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime ConditionInboundReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ConditionInboundReportScheduleTime"));
            }
        }

        public int ConditionInboundReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("ConditionInboundReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime CorporateTagSchedulingTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("CorporateTagSchedulingTime")); }
        }

        public int CorporateTagIntervalHrs
        {
            get
            {
                int hours;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("CorporateTagIntervalHrs"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime BarrierInboundReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BarrierInboundReportScheduleTime")); }
        }

        public int BarrierInboundReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("BarrierInboundReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime LabsInboundReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("LabsInboundReportScheduleTime")); }
        }

        public int LabsInboundReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("LabsInboundReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime InterviewInboundReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("InterviewInboundReportScheduleTime"));
            }
        }

        public int InterviewInboundReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("InterviewInboundReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public DateTime CrosswalkInboundReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("CrosswalkInboundReportScheduleTime"));
            }
        }

        public int CrosswalkInboundReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("CrosswalkInboundReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public string FloridaBlueInboundReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueInboundReportPath"); }
        }

        public string FloridaBlueSettingResourcePath
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueReportDownloadSettings"); }
        }

        public DateTime FloridaBlueReportCutOfDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("FloridaBlueReportCutOfDate")); }
        }


        public long BcbsScAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("BcbsScAccountId"), out accountId);
                return accountId;
            }
        }

        public string BcbsScResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsScResultPdfDownloadPath"); }
        }


        public IEnumerable<long> OptumResultPdfDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("OptumResultPdfDownloadAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string OptumResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("OptumResultPdfDownloadPath"); }
        }

        public IEnumerable<long> OptumResultReportDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("OptumResultReportDownloadAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string OptumResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("OptumResultReportDownloadPath"); }
        }

        public IEnumerable<long> OptumAppointmentBookedReportDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("OptumAppointmentBookedReportDownloadAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string OptumAppointmentBookedReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("OptumAppointmentBookedReportDownloadPath"); }
        }

        public IEnumerable<long> OptumZipFolderDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("OptumZipFolderDownloadAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }
        }

        public DateTime OptumZipScheduledTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("OptumZipScheduledTime")); }
        }

        public int OptumZipScheduledInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("OptumZipScheduledInterval")); }
        }

        public string OptumZipFolderDownloadFromPath
        {
            get { return ConfigurationManager.AppSettings.Get("OptumZipFolderDownloadFromPath"); }
        }

        public string OptumZipFolderPostToPath
        {
            get { return ConfigurationManager.AppSettings.Get("string OptumZipFolderPostToPath"); }
        }

        public int PatientDetailParseIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("PatientDetailParseIntervalHours")); }
        }

        public int DiagnosisReportParseIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("DiagnosisReportParseIntervalHours")); }
        }

        public DateTime CrosswalkLabInboundReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("CrosswalkLabInboundReportScheduleTime"));
            }
        }

        public int CrosswalkLabInboundReportInterval
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("CrosswalkLabInboundReportInterval"), out hours);
                return (hours < 1 ? 1 : hours);
            }
        }

        public int MarkResultArchiveFailedAfterHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MarkResultArchiveFailedAfterHours")); }
        }

        public DateTime MarkResultArchiveFailedScheduledTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MarkResultArchiveFailedScheduledTime"));
            }
        }

        public int MarkResultArchiveFailedInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MarkResultArchiveFailedInterval")); }
        }

        public string AcePdfSourceLocation
        {
            get { return ConfigurationManager.AppSettings.Get("AcePdfSourceLocation"); }
        }

        public long MedicareSyncUserId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareSyncUserId")); }
        }

        public long MedicareSyncRoleId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareSyncRoleId")); }
        }

        public long MedicareSyncOrganizationId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareSyncOrganizationId")); }
        }

        public string MedicareSyncCustomSettingsPath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("MedicareSyncCustomSettingsPath")); }
        }

        public int MedicareCustomerIntervalHour
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareCustomerIntervalHour")); }
        }

        public int MedicareResultIntervalHour
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareResultIntervalHour")); }
        }

        public int MedicareResultIntervalMinute
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareResultIntervalMinute")); }
        }

        public int MedicareCustomerIntervalMinute
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareCustomerIntervalMinute")); }
        }

        public DateTime MedicareCustomerScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareCustomerScheduleTime")); }
        }

        public DateTime MedicareHealthPlanScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareHealthPlanScheduleTime")); }

        }

        public DateTime MedicareResultScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareResultScheduleTime")); }

        }

        public int NoOfDaysToPickWhenWithoutSetting
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NoOfDaysToPickWhenWithoutSetting")); }
        }

        public string ReportDestinationPath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("ReportDestinationPath")); }
        }

        public int DayOfMonthServiceRun
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("DayOfMonthServiceRun")); }
        }

        public DateTime TestPerformReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("TestPerformReportScheduleTime")); }
        }

        public int TestPerformReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("TestPerformReportInterval")); }
        }

        public string NtspSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("NtspSftpHost"); }
        }

        public string NtspSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("NtspSftpUserName"); }
        }

        public string NtspSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("NtspSftpPassword"); }
        }

        public bool SendReportToNtspSftp
        {
            get
            {
                bool sendReporttoNtsp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToNtspSftp"), out sendReporttoNtsp);
                return sendReporttoNtsp;
            }
        }

        public string NtspSftpResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("NtspSftpResultReportDownloadPath"); }
        }

        public int LastLoggedInBeforeDays
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("LastLoggedInBeforeDays")); }
        }

        public DateTime UserDeactivationScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("UserDeactivationScheduleTime")); }

        }

        public long BcbsMnAccountId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("BcbsMnAccountId")); }
        }

        public string BcbsMnSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMnSftpHost"); }
        }

        public string BcbsMnSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMnSftpUserName"); }
        }

        public string BcbsMnSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMnSftpPassword"); }
        }

        public bool SendReportToBcbsMn
        {
            get
            {
                bool sendReporttoNtsp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToBcbsMn"), out sendReporttoNtsp);
                return sendReporttoNtsp;
            }
        }

        public string BcbsMnSftpResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMnSftpResultReportDownloadPath"); }
        }

        public long MonarchAccountId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MonarchAccountId")); }
        }

        public long AnthemAccountId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("AnthemAccountId")); }
        }

        public DateTime AnthemDownloadCutOfDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("AnthemDownloadCutOfDate")); }
        }

        public DateTime? DpnChangeDate
        {
            get
            {
                DateTime dpnChangeDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("DpnChangeDate"), out dpnChangeDate))
                    return dpnChangeDate;
                return null;
            }
        }

        public DateTime PatientDetailParseScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PatientDetailParseScheduleTime")); }

        }

        public DateTime DiagnosisReportParseScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("DiagnosisReportParseScheduleTime")); }

        }

        public bool UseSentinel
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("UseSentinel")); }
        }

        public string HcpNvSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("HcpNvSftpHost"); }
        }

        public string HcpNvSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("HcpNvSftpUserName"); }
        }

        public string HcpNvSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("HcpNvSftpPassword"); }
        }

        public bool SendReportToHcpNv
        {
            get
            {
                bool sendReporttoNtsp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToHcpNv"), out sendReporttoNtsp);
                return sendReporttoNtsp;
            }
        }

        public string HcpNvSftpResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HcpNvSftpResultReportDownloadPath"); }
        }

        public DateTime MonarchAttestationScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MonarchAttestationScheduleTime")); }
        }

        public int MonarchAttestationIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MonarchAttestationIntervalHours")); }
        }

        public IEnumerable<long> DailyPatientRecapReportDownloadAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("DailyPatientRecapReportDownloadAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        accountIds.Add(hpAccountId);
                    }
                }

                return accountIds;
            }

        }

        public string DailyPatientRecapReportDestinationPath
        {
            get { return ConfigurationManager.AppSettings.Get("DailyPatientRecapReportDestinationPath"); }
        }

        public IEnumerable<DayOfWeek> DaysOfWeekToRunDailyPatientRecapReport
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("DaysOfWeekToRunDailyPatientRecapReport");

                return configValue.Split(',').Select(x => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), x.ToString()));
            }
        }

        public IEnumerable<long> WellmedReportAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("WellmedReportAccountIds");
                var hpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpAccountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        hpAccountIds.Add(hpAccountId);
                    }
                }

                return hpAccountIds;
            }
        }

        public DateTime DailyPatientRecapReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("DailyPatientRecapReportScheduleTime"));
            }
        }

        public int DailyPatientRecapReportInterval
        {
            get
            {
                int minutes = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("DailyPatientRecapReportInterval"), out minutes);
                return (minutes < 0 ? 15 : minutes);
            }
        }

        public string SftpResouceFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("SftpResouceFilePath"); }
        }

        public IEnumerable<long> AccountIdsForEventFileImport
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("AccountIdsForEventFileImport");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        accountIds.Add(hpAccountId);
                    }
                }

                return accountIds;
            }
        }

        public DateTime EventFileImportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EventFileImportScheduleTime")); }
        }

        public int EventFileImportIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("EventFileImportIntervalHours"), out hours);
                return (hours < 0 ? 12 : hours);
            }
        }

        public long BcbsMiAccountId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("BcbsMiAccountId")); }
        }

        public string BcbsMiResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMiResultReportDownloadPath"); }
        }

        public string BcbsMiResultPdfDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMiResultPdfDownloadPath"); }
        }

        public string[] BcbsMiRiskPatientTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("BcbsMiRiskPatientTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var bcbsMiRiskPatientTags = tags.Split(',');
                bcbsMiRiskPatientTags =
                    bcbsMiRiskPatientTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return bcbsMiRiskPatientTags;
            }
        }

        public string[] BcbsMiGapPatinetTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("BcbsMiGapPatinetTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var bcbsMiRiskPatientTags = tags.Split(',');
                bcbsMiRiskPatientTags =
                    bcbsMiRiskPatientTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return bcbsMiRiskPatientTags;
            }
        }

        public IEnumerable<long> MonarchAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("MonarchAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        accountIds.Add(hpAccountId);
                    }
                }

                return accountIds;
            }
        }

        public DayOfWeek BcbsMiIncorrectPhoneExportDay
        {
            get
            {
                try
                {
                    int bcbsMiExportDay;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiIncorrectPhoneExportDay"),
                        out bcbsMiExportDay);
                    if (bcbsMiExportDay >= 0 && bcbsMiExportDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiIncorrectPhoneExportDay"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public DayOfWeek BcbsMiHomeVisitExportDay
        {
            get
            {
                try
                {
                    int bcbsMiExportDay;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiHomeVisitExportDay"), out bcbsMiExportDay);
                    if (bcbsMiExportDay >= 0 && bcbsMiExportDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiHomeVisitExportDay"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public DateTime IncorrectPhoneExportDownloadTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("IncorrectPhoneExportDownloadTime")); }
        }

        public DateTime HomeVisitExportDownloadTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HomeVisitExportDownloadTime")); }
        }

        public string ServiceReportSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("ServiceReportSettingPath"); }
        }

        public DateTime BcbsMiServiceReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BcbsMiServiceReportScheduleTime")); }
        }

        public int BcbsMiServiceReportIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiServiceReportIntervalHours"), out hours);
                return (hours < 0 ? 12 : hours);
            }
        }

        public DayOfWeek BcbsMiReportingServiceDayOfWeek
        {
            get
            {
                try
                {
                    int bcbsMiExportDay;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiReportingServiceDayOfWeek"),
                        out bcbsMiExportDay);
                    if (bcbsMiExportDay >= 0 && bcbsMiExportDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiReportingServiceDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Tuesday;
            }
        }

        public string BcbsMiPcpResultMailedReportSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMiPcpResultMailedReportSettingPath"); }
        }

        public DateTime BcbsMiPcpResultMailedReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BcbsMiPcpResultMailedReportScheduleTime"));
            }
        }

        public int BcbsMiPcpResultMailedReportIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiPcpResultMailedReportIntervalHours"),
                    out hours);
                return (hours < 0 ? 12 : hours);
            }
        }

        public DayOfWeek BcbsMiPcpResultMailedReportDayOfWeek
        {
            get
            {
                try
                {
                    int bcbsMiExportDay;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiPcpResultMailedReportDayOfWeek"),
                        out bcbsMiExportDay);
                    if (bcbsMiExportDay >= 0 && bcbsMiExportDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiReportingServiceDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Tuesday;
            }
        }

        public string BcbsMiMemberResultMailedReportSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsMiMemberResultMailedReportSettingPath"); }
        }

        public DateTime BcbsMiMemberResultMailedReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BcbsMiMemberResultMailedReportScheduleTime"));
            }
        }

        public int BcbsMiMemberResultMailedReportIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiMemberResultMailedReportIntervalHours"),
                    out hours);
                return (hours < 0 ? 12 : hours);
            }
        }

        public DayOfWeek BcbsMiMemberResultMailedReportDayOfWeek
        {
            get
            {
                try
                {
                    int bcbsMiExportDay;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiMemberResultMailedReportDayOfWeek"),
                        out bcbsMiExportDay);
                    if (bcbsMiExportDay >= 0 && bcbsMiExportDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiMemberResultMailedReportDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Tuesday;
            }
        }

        public IEnumerable<long> OptumHomeVisitRequesedAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("OptumHomeVisitRequesedAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string OptumHomeVisitRequesedDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("OptumHomeVisitRequesedDownloadPath"); }
        }

        public IEnumerable<long> OptumIncorrectPhoneNumberAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("OptumIncorrectPhoneNumberAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string OptumIncorrectPhoneNumberDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("OptumIncorrectPhoneNumberDownloadPath"); }
        }

        public IEnumerable<long> DoNotSendHomeVistIncorrectPhoneNumberAccountIds
        {
            get
            {
                var configuValue =
                    ConfigurationManager.AppSettings.Get("DoNotSendHomeVistIncorrectPhoneNumberAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }

        }

        public string MonarchZipFolderPostToPath
        {
            get { return ConfigurationManager.AppSettings.Get("MonarchZipFolderPostToPath"); }
        }

        public string BcbsmiHomeVisitRequestedSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsmiHomeVisitRequestedSettingPath"); }
        }

        public string BcbsmiIncorrectPhoneNumberSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsmiIncorrectPhoneNumberSettingPath"); }
        }

        public string MonarchWellmedPdfPath
        {
            get { return ConfigurationManager.AppSettings.Get("MonarchWellmedPdfPath"); }
        }

        public string MonarchWelledPdfSfptPath
        {
            get { return ConfigurationManager.AppSettings.Get("MonarchWelledPdfSfptPath"); }
        }

        public string CustomerWithNoGmpiPath
        {
            get { return ConfigurationManager.AppSettings.Get("CustomerWithNoGmpiPath"); }
        }

        public bool SendPdfToWellmed
        {
            get
            {
                bool sendReporttoNtsp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendPdfToWellmed"), out sendReporttoNtsp);
                return sendReporttoNtsp;
            }
        }

        public long MartinsPointExclusiveAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("MartinsPointExclusiveAccountId"), out accountId);
                return accountId;
            }
        }

        public string WellCarePcpSummaryLogDownloadPath
        {
            get { throw new NotImplementedException(); }
        }

        public string WellCarePcpSummaryLogReportSettingPath
        {
            get { throw new NotImplementedException(); }
        }

        public DayOfWeek WellCarePcpSummaryLogReportDayOfWeek
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime WellCarePcpSummaryLogReportScheduleTime
        {
            get { throw new NotImplementedException(); }
        }

        public int WellCarePcpSummaryLogReportIntervalHours
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime WellCarePcpSummaryLogCutOfDate
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<long> WellCareEasyChoiceAccountIds
        {
            get { throw new NotImplementedException(); }
        }

        public int StartYear
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("StartYear")); }
        }


        public long ExcellusAccountId
        {
            get { return Convert.ToInt64(ConfigurationManager.AppSettings.Get("ExcellusAccountId")); }
        }

        public string[] ExcellusCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("ExcellusCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var excellusCustomTags = tags.Split(',');
                excellusCustomTags =
                    excellusCustomTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return excellusCustomTags;
            }
        }

        public string[] HealthNowCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("HealthNowCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var healthNowCustomTags = tags.Split(',');
                healthNowCustomTags =
                    healthNowCustomTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return healthNowCustomTags;
            }
        }

        public DayOfWeek ExcellusExportResultReportDayOfWeek
        {
            get
            {
                try
                {
                    var excellusExportResultReportDayOfWeek = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("ExcellusExportResultReportDayOfWeek"),
                        out excellusExportResultReportDayOfWeek);
                    if (excellusExportResultReportDayOfWeek >= 0 && excellusExportResultReportDayOfWeek <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("ExcellusExportResultReportDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public string[] AnthemCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("AnthemCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var bcbsMiRiskPatientTags = tags.Split(',');
                bcbsMiRiskPatientTags =
                    bcbsMiRiskPatientTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return bcbsMiRiskPatientTags;
            }
        }

        public string[] AnthemCustomTagStates
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("AnthemCustomTagStates");
                if (string.IsNullOrEmpty(tags)) return null;
                var bcbsMiRiskPatientTags = tags.Split(',');
                bcbsMiRiskPatientTags =
                    bcbsMiRiskPatientTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return bcbsMiRiskPatientTags;
            }
        }

        public string AnthemDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("AnthemDownloadPath"); }
        }

        public IEnumerable<long> GiftCertificateReportDownloadAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("GiftCertificateReportDownloadAccountIds");
                var gCAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return gCAccountIds;

                var gCAccountIdsArray =
                    configuValue.Split(',')
                        .Where(gCAccountIdstr => !string.IsNullOrEmpty(gCAccountIdstr))
                        .Select(x => x.Trim());

                foreach (var gCAccountIdstr in gCAccountIdsArray)
                {
                    long gCAccountId;
                    long.TryParse(gCAccountIdstr, out gCAccountId);
                    if (gCAccountId > 0)
                    {
                        gCAccountIds.Add(gCAccountId);
                    }
                }
                return gCAccountIds;
            }
        }

        public DateTime GiftCertificateReportCutOffDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GiftCertificateReportCutOffDate")); }
        }

        public IEnumerable<DayOfWeek> GiftCertificateReportDaysOfWeek
        {
            get
            {
                try
                {
                    var configuValue = ConfigurationManager.AppSettings.Get("GiftCertificateReportDaysOfWeek");
                    var gCReportDays = new List<DayOfWeek>();
                    if (string.IsNullOrEmpty(configuValue)) return gCReportDays;

                    var gCReportDaysArray =
                        configuValue.Split(',')
                            .Where(gCReportDayStr => !string.IsNullOrEmpty(gCReportDayStr))
                            .Select(x => x.Trim());

                    foreach (var gCReportDayStr in gCReportDaysArray)
                    {
                        int gCReportDay;
                        int.TryParse(gCReportDayStr, out gCReportDay);

                        if (gCReportDay >= 0 && gCReportDay <= 6)
                        {
                            gCReportDays.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), gCReportDayStr));
                        }
                    }

                    return gCReportDays;
                }
                catch (Exception)
                {

                }
                return new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday };
            }
        }

        public string GiftCertificateReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("GiftCertificateReportDownloadPath"); }
        }

        public DateTime GiftCertificateReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GiftCertificateReportScheduleTime"));
            }
        }


        public bool HideQuantaFloAbiSection
        {
            get
            {
                bool hideQuantaFloAbiSection;
                bool.TryParse(ConfigurationManager.AppSettings.Get("HideQuantaFloAbiSection"),
                    out hideQuantaFloAbiSection);
                return hideQuantaFloAbiSection;
            }
        }

        public string LoincLabDataPath
        {
            get { return ConfigurationManager.AppSettings.Get("LoincLabDataPath"); }
        }

        public string LoincCrosswalkPath
        {
            get { return ConfigurationManager.AppSettings.Get("LoincCrosswalkPath"); }
        }

        public DateTime LoincLabDataParseScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("LoincLabDataParseScheduleTime")); }
        }

        public DateTime LoincCrosswalkParseScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("LoincCrosswalkParseScheduleTime")); }
        }

        public string HourlyAppointmentBookedResoucePath
        {
            get { return ConfigurationManager.AppSettings.Get("HourlyAppointmentBookedResoucePath"); }
        }

        public string HourlyAppointmentBookedDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HourlyAppointmentBookedDownloadPath"); }
        }

        public DateTime HourlyAppointmentBookedScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HourlyAppointmentBookedScheduleTime"));
            }
        }

        public int HourlyAppointmentBookedIntervalHours
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HourlyAppointmentBookedIntervalHours"));
            }
        }

        public int HourlyAppointmentBookedStartTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HourlyAppointmentBookedStartTime")); }
        }

        public DayOfWeek FloridaBlueReportsDayOfWeek
        {
            get
            {
                try
                {
                    var floridaBlueReportsDayOfWeek = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("FloridaBlueReportsDayOfWeek"),
                        out floridaBlueReportsDayOfWeek);
                    if (floridaBlueReportsDayOfWeek >= 0 && floridaBlueReportsDayOfWeek <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("FloridaBlueReportsDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public string[] FloridaBlueMedicareCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("FloridaBlueMedicareCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var floridaBlueMedicareCustomTags = tags.Split(',');
                floridaBlueMedicareCustomTags =
                    floridaBlueMedicareCustomTags.Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x.Trim())
                        .ToArray();

                return floridaBlueMedicareCustomTags;
            }
        }

        public string[] FloridaBlueCommercialCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("FloridaBlueCommercialCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var floridaBlueCommercialCustomTags = tags.Split(',');
                floridaBlueCommercialCustomTags =
                    floridaBlueCommercialCustomTags.Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x.Trim())
                        .ToArray();

                return floridaBlueCommercialCustomTags;
            }
        }

        public long FloridaBlueCommercialId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("FloridaBlueCommercialId"), out accountId);
                return accountId;
            }
        }

        public string ResultPostedToPlanPath
        {
            get { return ConfigurationManager.AppSettings.Get("ResultPostedToPlanPath"); }
        }

        public string HourlyOutreachCallReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HourlyOutreachCallReportDownloadPath"); }
        }

        public DateTime HourlyOutreachCallReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HourlyOutreachCallReportScheduleTime"));
            }
        }

        public int HourlyOutreachCallReportIntervalHours
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HourlyOutreachCallReportIntervalHours"));
            }
        }

        public int HourlyOutreachCallReportStartTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HourlyOutreachCallReportStartTime")); }
        }

        public DateTime PatientKareoIntegrationSchedulingTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PatientKareoIntegrationSchedulingTime"));
            }
        }

        public string GiftCertificateSettingResourcePath
        {
            get { return ConfigurationManager.AppSettings.Get("GiftCertificateSettingResourcePath"); }
        }

        public DateTime FromDateForGapPatient
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("FromDateForGapPatient")); }
        }

        public int CustomerReturnInCallQueue
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CustomerReturnInCallQueue")); }
        }

        public string MonarchResultPdfArchive
        {
            get { return ConfigurationManager.AppSettings.Get("MonarchResultPdfArchive"); }
        }

        public int ZipRangeInMiles
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("ZipRangeInMiles")); }
        }

        public DateTime HealthPlanEventZipScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HealthPlanEventZipScheduleTime")); }
        }

        public int HealthPlanEventZipInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HealthPlanEventZipInterval")); }
        }

        public DateTime HealthPlanEventZipQueueNotGeneratedScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("HealthPlanEventZipQueueNotGeneratedScheduleTime"));
            }
        }

        public int HealthPlanEventZipQueueNotGeneratedInterval
        {
            get
            {
                return
                    Convert.ToInt32(ConfigurationManager.AppSettings.Get("HealthPlanEventZipQueueNotGeneratedInterval"));
            }
        }

        public DateTime HkynGenerationDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HkynGenerationDate")); }
        }

        public string HealthPlanDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanDownloadPath"); }
        }

        public long MedMutualAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("MedMutualAccountId"), out accountId);
                return accountId;
            }
        }

        public int MedMutualExportDay
        {
            get
            {
                int dayOfMonth = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("MedMutualExportDay"), out dayOfMonth);
                return dayOfMonth;
            }
        }

        public string ClinicalDoumentPath
        {
            get { return ConfigurationManager.AppSettings.Get("ClinicalDoumentPath"); }
        }

        public IEnumerable<long> ClinicalDoumentAccountIds
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("ClinicalDoumentAccountIds");
                var pcpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return pcpAccountIds;

                var partnerIdsArray =
                    configuValue.Split(',')
                        .Where(hospitalIdstr => !string.IsNullOrEmpty(hospitalIdstr))
                        .Select(x => x.Trim());

                foreach (var hospitalIdstr in partnerIdsArray)
                {
                    long pcpAccountId;
                    long.TryParse(hospitalIdstr, out pcpAccountId);
                    if (pcpAccountId > 0)
                    {
                        pcpAccountIds.Add(pcpAccountId);
                    }
                }

                return pcpAccountIds;
            }
        }

        public int FillEventRefusedCustomerDefault
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("FillEventRefusedCustomerDefault")); }
        }

        public string ClinicalDoumentSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("ClinicalDoumentSettingPath"); }
        }

        public int RefusedCustomerReturnInCallQueue
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("RefusedCustomerReturnInCallQueue")); }
        }

        public string HkynParsePdfPath
        {
            get { return ConfigurationManager.AppSettings.Get("HkynParsePdfPath"); }
        }

        public int HkynParsePdfIntervalInMinutes
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HkynParsePdfIntervalInMinutes")); }
        }

        public string EkgCardioCardParserFolderRepresentation
        {
            get { return ConfigurationManager.AppSettings.Get("EkgCardioCardParserFolderRepresentation"); }
        }

        public int MailRoundLeftVoiceMailDefault
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MailRoundLeftVoiceMailDefault")); }
        }

        public int MailRoundAllCallDefault
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MailRoundAllCallDefault")); }
        }

        public int FillEventAllCallDefault
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("FillEventAllCallDefault")); }
        }

        public int CallQueueMaxAttemptDefault
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CallQueueMaxAttemptDefault")); }
        }

        public DateTime MedicareEventTestScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareEventTestScheduleTime")); }
        }

        public int MedicareEventTestIntervalHour
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareEventTestIntervalHour")); }
        }

        public int MedicareEventTestIntervalMinute
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareEventTestIntervalMinute")); }
        }

        public DateTime MedicareCredentialScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareCredentialScheduleTime")); }
        }

        public int MedicareCredentialIntervalHour
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareCredentialIntervalHour")); }
        }

        public int MedicareCredentialIntervalMinute
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareCredentialIntervalMinute")); }
        }

        public string PdfLogFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("PdfLogFilePath"); }
        }

        public long AppleCareAccountId
        {
            get
            {
                int dayOfMonth = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("MedMutualExportDay"), out dayOfMonth);
                return dayOfMonth;
            }
        }

        public DayOfWeek AppleCareAppointmentBookedReportDayOfWeek
        {
            get
            {
                try
                {
                    var floridaBlueReportsDayOfWeek = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("AppleCareAppointmentBookedReportDayOfWeek"),
                        out floridaBlueReportsDayOfWeek);
                    if (floridaBlueReportsDayOfWeek >= 0 && floridaBlueReportsDayOfWeek <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("AppleCareAppointmentBookedReportDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public IEnumerable<long> AttestionFormParseAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("AttestionFormParseAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        accountIds.Add(hpAccountId);
                    }
                }

                return accountIds;
            }
        }

        public string AppleCareAttestationFormsPath
        {
            get { return ConfigurationManager.AppSettings.Get("AppleCareAttestationFormsPath"); }
        }

        public long ConnecticareAccountId
        {
            get
            {
                int accountId = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("ConnecticareAccountId"), out accountId);
                return accountId;
            }
        }

        public long BcbsAlAccountId
        {
            get
            {
                int accountId = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("BcbsAlAccountId"), out accountId);
                return accountId;
            }
        }

        public string BcbsAlSftpDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("BcbsAlSftpDownloadPath"); }
        }

        public long ConnecticareMaAccountId
        {
            get
            {
                int accountId = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("ConnecticareMaAccountId"), out accountId);
                return accountId;
            }
        }

        public string[] WellCareToWellMedCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("WellCareToWellMedCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var floridaBlueMedicareCustomTags = tags.Split(',');
                floridaBlueMedicareCustomTags =
                    floridaBlueMedicareCustomTags.Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x.Trim())
                        .ToArray();

                return floridaBlueMedicareCustomTags;
            }
        }

        public DateTime HealthPlanConfirmationCallQueueGenerationScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("HealthPlanConfirmationCallQueueGenerationScheduleTime"));
            }
        }

        public DateTime NewHkynEventDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("NewHkynEventDate")); }
        }

        public long OptumNvAccountId
        {
            get
            {
                int accountId = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("OptumNvAccountId"), out accountId);
                return accountId;
            }
        }

        public string TraleUrl
        {
            get { return ConfigurationManager.AppSettings.Get("TraleUrl"); }
        }

        public string TraleApiKey
        {
            get { return ConfigurationManager.AppSettings.Get("TraleApiKey"); }
        }

        public string ProfileId
        {
            get { return ConfigurationManager.AppSettings.Get("ProfileId"); }
        }

        public string TraleKey
        {
            get { return ConfigurationManager.AppSettings.Get("TraleKey"); }
        }

        public string TraleIv
        {
            get { return ConfigurationManager.AppSettings.Get("TraleIv"); }
        }

        public string BioCheckAssessmentFailedListPath
        {
            get { return ConfigurationManager.AppSettings.Get("BioCheckAssessmentFailedListPath"); }
        }


        public DateTime MedicareRapsSyncScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareRapsSyncScheduleTime")); }
        }

        public int MedicareRapsSyncIntervalHour
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareRapsSyncIntervalHour")); }
        }

        public int MedicareRapsSyncIntervalMinute
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareRapsSyncIntervalMinute")); }
        }

        public DateTime OptumNvResultPdfNamingChangeDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("OptumNvResultPdfNamingChangeDate")); }
        }

        public DateTime PhoneNumberUpdateScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PhoneNumberUpdateScheduleTime")); }
        }

        public int MergeCustomerInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MergeCustomerInterval")); }
        }

        public int PhoneNumberUpdateIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("PhoneNumberUpdateIntervalHours")); }
        }

        public string DailyVolumeReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("DailyVolumeReportPath"); }
        }

        public DateTime DailyVolumeReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("DailyVolumeReportScheduleTime")); }
        }

        public int DailyVolumeReportIntervalInHour
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("DailyVolumeReportIntervalInHour")); }
        }

        public string EventListGmsReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("EventListGmsReportPath"); }
        }

        public DateTime EventListGmsReportIntervalHour
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EventListGmsReportIntervalHour")); }
        }

        public bool StopTrailService
        {
            get
            {
                bool stopTrailService;
                bool.TryParse(ConfigurationManager.AppSettings.Get("StopTrailService"), out stopTrailService);
                return stopTrailService;
            }
        }

        public string CustomerWithNoMrnPath
        {
            get { return ConfigurationManager.AppSettings.Get("CustomerWithNoMrnPath"); }
        }

        public string GmsCustomerReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("GmsCustomerReportPath"); }
        }

        public IEnumerable<long> GmsAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("GmsAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        accountIds.Add(hpAccountId);
                    }
                }

                return accountIds;
            }
        }

        public DateTime GmsEventReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GmsEventReportScheduleTime")); }
        }

        public int GmsEventReportIntervalMinutes
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GmsEventReportIntervalMinutes")); }
        }

        public DateTime GmsCustomerReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GmsCustomerReportScheduleTime")); }
        }

        public int GmsCustomerReportIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GmsCustomerReportIntervalHours")); }
        }

        public int GmsMaxCustomerCount
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GmsMaxCustomerCount")); }
        }

        public string GmsSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("GmsSftpHost"); }
        }

        public string GmsSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("GmsSftpUserName"); }
        }

        public string GmsSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("GmsSftpPassword"); }
        }

        public bool SendReportToGmsSftp
        {
            get
            {
                bool sendReporttoWellcare;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToGmsSftp"), out sendReporttoWellcare);
                return sendReporttoWellcare;
            }
        }

        public string GmsSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("GmsSftpPath"); }
        }

        public int GmsEventStartTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GmsEventStartTime")); }
        }

        public int GmsEventEndTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GmsEventEndTime")); }
        }

        public string TwilioFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("TwilioFilePath"); }
        }

        public string GmsDialerFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("GmsDialerFilePath"); }
        }

        public DateTime GmsDialerFileParsingScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GmsDialerFileParsingScheduleTime")); }
        }

        public int GmsDialerFileParsingIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GmsDialerFileParsingIntervalHours")); }
        }

        public IEnumerable<long> EventScheduleAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("EventScheduleAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        accountIds.Add(hpAccountId);
                    }
                }

                return accountIds;
            }
        }

        public int EventScheduleAccountInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("EventScheduleAccountInterval")); }
        }

        public DateTime EventScheduleAccountScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EventScheduleAccountScheduleTime")); }
        }

        public string EventScheduleReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("EventScheduleReportPath"); }
        }

        public string MailRoundCustomersReportDestinantionPath
        {
            get { return ConfigurationManager.AppSettings.Get("MailRoundCustomersReportDestinantionPath"); }
        }

        public DateTime MailRoundCustomersReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MailRoundCustomersReportScheduleTime"));
            }
        }

        public int MailRoundCustomersReportIntervalHours
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MailRoundCustomersReportIntervalHours"));
            }
        }

        public string GmsUserName
        {
            get { return ConfigurationManager.AppSettings.Get("GmsUserName"); }
        }

        public string ResultNotPostedToPlanPath
        {
            get { return ConfigurationManager.AppSettings.Get("ResultNotPostedToPlanPath"); }
        }

        public string BiWeeklyMicroAlbuminFobtReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("BiWeeklyMicroAlbuminFobtReportPath"); }
        }

        public bool SendBiWeeklyMicroAlbuminFobtReportToSftp
        {
            get
            {
                bool sendReportToWellmed;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendBiWeeklyMicroAlbuminFobtReportToSftp"),
                    out sendReportToWellmed);
                return sendReportToWellmed;
            }
        }

        public DateTime BiWeeklyMicroAlbuminFobtCutoffDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BiWeeklyMicroAlbuminFobtCutoffDate"));
            }
        }

        public IEnumerable<long> BiWeeklyMicroAlbuminFobtReportRunDates
        {
            get
            {
                var configuValue = ConfigurationManager.AppSettings.Get("BiWeeklyMicroAlbuminFobtReportRunDates");
                var dates = new List<long>();
                if (string.IsNullOrEmpty(configuValue)) return dates;

                var datesArray =
                    configuValue.Split(',')
                        .Where(item => !string.IsNullOrEmpty(item))
                        .Select(x => x.Trim());

                foreach (var date in datesArray)
                {
                    long dateLong;
                    long.TryParse(date, out dateLong);
                    if (dateLong > 0)
                    {
                        dates.Add(dateLong);
                    }
                }
                return dates;
            }
        }

        public string BiWeeklyMicroAlbuminFobtSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("BiWeeklyMicroAlbuminFobtSftpPath"); }
        }

        public DateTime BiWeeklyMicroAlbuminFobtScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BiWeeklyMicroAlbuminFobtScheduleTime"));
            }
        }

        public int BiWeeklyMicroAlbuminFobtIntervalHours
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("BiWeeklyMicroAlbuminFobtIntervalHours"));
            }
        }

        public string EventScheduleReportSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("EventScheduleReportSftpPath"); }
        }

        public bool SendNonTargetableReportToSftp
        {
            get
            {
                bool sendReportToWellmed;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendNonTargetableReportToSftp"),
                    out sendReportToWellmed);
                return sendReportToWellmed;
            }
        }

        public string NonTargetableReportSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("NonTargetableReportSftpPath"); }
        }

        public string NonTargetableReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("NonTargetableReportPath"); }
        }

        public DateTime NonTargetableCutoffDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("NonTargetableCutoffDate")); }
        }

        public int NonTargetableReportRunDate
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NonTargetableReportRunDate")); }
        }

        public string AppointmentEncounterReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("AppointmentEncounterReportPath"); }
        }

        public DateTime AppointmentEncounterScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("AppointmentEncounterScheduleTime")); }
        }

        public int AppointmentEncounterIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("AppointmentEncounterIntervalHours")); }
        }

        public DateTime NonTargetableReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("NonTargetableReportScheduleTime")); }
        }

        public int NonTargetableReportIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NonTargetableReportIntervalHours")); }
        }

        public bool SendPcpChangeReportToSftp
        {
            get
            {
                bool sendReportToWellmed;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendPcpChangeReportToSftp"), out sendReportToWellmed);
                return sendReportToWellmed;
            }
        }

        public string PcpChangeReportSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("PcpChangeReportSftpPath"); }
        }

        public string PcpChangeReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("PcpChangeReportPath"); }
        }

        public DateTime PcpChangeReportCutoffDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PcpChangeReportCutoffDate")); }
        }

        public int PcpChangeReportRunDate
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("PcpChangeReportRunDate")); }
        }

        public DateTime PcpChangeReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PcpChangeReportScheduleTime")); }
        }

        public int PcpChangeReportIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("PcpChangeReportIntervalHours")); }
        }

        public string PcpChangeReportSettings
        {
            get { return ConfigurationManager.AppSettings.Get("PcpChangeReportSettings"); }
        }

        public string HousecallOutreachReportExportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HousecallOutreachReportExportDownloadPath"); }
        }

        public int HousecallOutreachReportExportScheduleInterval
        {
            get
            {
                var housecallOutreachReportExportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HousecallOutreachReportExportScheduleInterval"),
                    out housecallOutreachReportExportScheduleInterval);
                if (housecallOutreachReportExportScheduleInterval <= 1)
                    housecallOutreachReportExportScheduleInterval = 1;

                return housecallOutreachReportExportScheduleInterval;
            }
        }

        public DateTime HousecallOutreachReportExportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HousecallOutreachReportExportScheduleTime"));
            }
        }

        public DateTime HousecallOutreachReportCutOfDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HousecallOutreachReportCutOfDate")); }
        }

        public IEnumerable<long> HousecallPlanOutreachReportAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("HousecallPlanOutreachReportAccountIds");
                var hpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpAccountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        hpAccountIds.Add(hpAccountId);
                    }
                }

                return hpAccountIds;
            }

        }

        public string HousecallOutreachSettings
        {
            get { return ConfigurationManager.AppSettings.Get("HousecallOutreachSettings"); }
        }

        public string HousecallHafResultReportDownloadSettings
        {
            get { return ConfigurationManager.AppSettings.Get("HousecallHafResultReportDownloadSettings"); }
        }

        public string HousecallHafResultReportDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HousecallHafResultReportDownloadPath"); }
        }

        public DateTime HousecallHafResultReportDownloadTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HousecallHafResultReportDownloadTime"));
            }
        }

        public int HousecallHafResultReportDownloadInterval
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HousecallHafResultReportDownloadInterval"));
            }
        }

        public long WellmedWellCareAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("WellmedWellCareAccountId"), out accountId);
                return accountId;
            }
        }

        public int EventSuspentionCutoffDays
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("EventSuspentionCutoffDays")); }
        }

        public string WellmedMemberStatusReportPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedMemberStatusReportPath"); }
        }

        public DateTime WellmedMemberStatusReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("WellmedMemberStatusReportScheduleTime"));
            }
        }

        public int WellmedMemberStatusReportScheduleInterval
        {
            get
            {
                var wellmedMemberStatusReportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("HealthPlanMemberStatusReportScheduleInterval"),
                    out wellmedMemberStatusReportScheduleInterval);
                if (wellmedMemberStatusReportScheduleInterval <= 1)
                    wellmedMemberStatusReportScheduleInterval = 1;

                return wellmedMemberStatusReportScheduleInterval;
            }
        }

        public int WellmedMemberStatusReportDayOfMonth
        {
            get
            {
                var wellmedMemberStatusReportDayOfMonth = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("WellmedMemberStatusReportDayOfMonth"),
                    out wellmedMemberStatusReportDayOfMonth);
                if (wellmedMemberStatusReportDayOfMonth <= 1)
                    wellmedMemberStatusReportDayOfMonth = 1;

                return wellmedMemberStatusReportDayOfMonth;
            }
        }

        public string WellmedMemberStatusReportSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedMemberStatusReportSftpPath"); }
        }

        public bool WellmedMemberStatusReportSendToSftp
        {
            get
            {
                bool wellmedMemberStatusReportSendToSftp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("WellmedMemberStatusReportSendToSftp"),
                    out wellmedMemberStatusReportSendToSftp);
                return wellmedMemberStatusReportSendToSftp;
            }
        }

        public IEnumerable<long> WellCareToWellmedAccountId
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("WellCareToWellmedAccountId");
                var hpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpAccountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        hpAccountIds.Add(hpAccountId);
                    }
                }

                return hpAccountIds;
            }
        }

        public int EligibilityUploadIntervalMinutes
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("EligibilityUploadIntervalMinutes")); }
        }

        public IEnumerable<long> AnthemAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("AnthemAccountIds");
                var hpAccountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpAccountIds;

                var healthPlansArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in healthPlansArray)
                {
                    long hpAccountId;
                    long.TryParse(healthPlanId, out hpAccountId);
                    if (hpAccountId > 0)
                    {
                        hpAccountIds.Add(hpAccountId);
                    }
                }

                return hpAccountIds;
            }
        }

        public string CrosswalkFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("CrosswalkFilePath");
            }
        }

        public int CrosswalkFileYear
        {
            get
            {
                int crosswalkFileYear;
                int.TryParse(ConfigurationManager.AppSettings.Get("CrosswalkFileYear"), out crosswalkFileYear);
                return crosswalkFileYear;
            }
        }


        public int StaffEventScheduleParseIntervalMinutes
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("StaffEventScheduleParseIntervalMinutes"));
            }
        }

        public IEnumerable<long> GmsCampaignIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("GmsCampaignIds");
                var hpCampaignIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return hpCampaignIds;

                var campaignsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in campaignsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        hpCampaignIds.Add(hpCampaignId);
                    }
                }

                return hpCampaignIds;
            }
        }

        public int MedicareMedicationSyncIntervalMinute
        {
            get { throw new NotImplementedException(); }
        }

        public int MedicationFileParserIntervalMinute
        {
            get { throw new NotImplementedException(); }
        }

        public int CustomerForMedicationSyncCutoffDays
        {
            get { throw new NotImplementedException(); }
        }

        public string[] FloridaBlueMammoCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("FloridaBlueMammoCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var floridaBlueMammoCustomTags = tags.Split(',');
                floridaBlueMammoCustomTags =
                    floridaBlueMammoCustomTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return floridaBlueMammoCustomTags;
            }
        }

        public long FloridaBlueMammoId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("FloridaBlueMammoId"), out accountId);
                return accountId;
            }
        }

        public int NumberOfMaximumPrintInProgress
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("NumberOfMaximumPrintInProgress")); }
        }

        public string UniversalMemberFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("UniversalMemberFilePath"); }
        }

        public string ParsePatientDataSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("ParsePatientDataSftpPath"); }
        }

        public DateTime ParsePatientDataScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ParsePatientDataScheduleTime")); }
        }

        public int ParsePatientDataIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("ParsePatientDataIntervalHours")); }
        }

        public int UniversalMemberReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("UniversalMemberReportInterval")); }
        }

        public DateTime UniversalMemberReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("UniversalMemberReportScheduleTime"));
            }
        }

        public string UniversalProviderFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("UniversalProviderFilePath"); }
        }

        public int UniversalProviderReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("UniversalProviderReportInterval")); }
        }

        public DateTime UniversalProviderReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("UniversalProviderReportScheduleTime"));
            }
        }

        public DateTime EodGcCutoffDate
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EodGcCutoffDate"));
            }
        }

        public DateTime ChecklistChangeDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ChecklistChangeDate")); }
        }

        public string OptumUtCustomTagsForGms
        {
            get { return ConfigurationManager.AppSettings.Get("OptumUtCustomTagsForGms"); }
        }

        public long OptumUtAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("OptumUtAccountId"), out accountId);
                return accountId;
            }
        }

        public IEnumerable<long> OptumAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("OptumAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var accountIdsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in accountIdsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        accountIds.Add(hpCampaignId);
                    }
                }

                return accountIds;
            }
        }

        public string CustomerConsentDataFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("CustomerConsentDataFilePath"); }
        }

        public DateTime CustomerConsentDataReportScheduleTime
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("CustomerConsentDataReportScheduleTime"));
            }
        }

        public int CustomerConsentDataReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CustomerConsentDataReportInterval")); }
        }

        public string CustomerConsentDataReportSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("CustomerConsentDataReportSftpPath"); }
        }

        public bool CustomerConsentDataReportSendToSftp
        {
            get
            {
                bool customerConsentDataReportSendToSftp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("CustomerConsentDataReportSendToSftp"),
                    out customerConsentDataReportSendToSftp);
                return customerConsentDataReportSendToSftp;
            }
        }

        public string CustomerConsentDataReportSettingPath
        {
            get { return ConfigurationManager.AppSettings.Get("CustomerConsentDataReportSettingPath"); }
        }

        public string MatrixSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("MatrixSftpHost"); }
        }

        public string MatrixSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("MatrixSftpUserName"); }
        }

        public string MatrixSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("MatrixSftpPassword"); }
        }

        public string ConsentHeaderFormUrl
        {
            get { return ConfigurationManager.AppSettings.Get("ConsentHeaderFormUrl"); }
        }


        public DateTime GmsExcludeCustomerReportDownloadTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GmsExcludeCustomerReportDownloadTime"));
            }
        }

        public int GmsExcludeReportDownloadCustomerIntervalInHours
        {
            get
            {
                var wellmedMemberStatusReportScheduleInterval = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get("GmsExcludeReportDownloadCustomerIntervalInHours"),
                    out wellmedMemberStatusReportScheduleInterval);
                if (wellmedMemberStatusReportScheduleInterval <= 1)
                    wellmedMemberStatusReportScheduleInterval = 1;

                return wellmedMemberStatusReportScheduleInterval;
            }
        }

        public string GmsExcludeReportDownloadCustomerPath
        {
            get { return ConfigurationManager.AppSettings.Get("GmsExcludeReportDownloadCustomerPath"); }
        }

        public DateTime MedicareSuspectConditionSyncScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MedicareSuspectConditionSyncScheduleTime"));
            }
        }

        public int MedicareSuspectConditionSyncIntervalHour
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareSuspectConditionSyncIntervalHour"));
            }
        }

        public int MedicareSuspectConditionSyncIntervalMinute
        {
            get
            {
                return
                    Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicareSuspectConditionSyncIntervalMinute"));
            }
        }

        public IEnumerable<long> AppointmentEncounterReportAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("AppointmentEncounterReportAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var accountIdsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in accountIdsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        accountIds.Add(hpCampaignId);
                    }
                }

                return accountIds;
            }
        }

        public IEnumerable<long> GiftCerificateOptumAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("GiftCerificateOptumAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var accountIdsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in accountIdsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        accountIds.Add(hpCampaignId);
                    }
                }

                return accountIds;
            }
        }

        public DateTime GiftCerificateOptumScheduledTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("GiftCerificateOptumScheduledTime")); }
        }

        public int GiftCerificateOptumScheduledInterval
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("GiftCerificateOptumScheduledInterval"));
            }
        }

        public long GiftCerificateOptumDayServiceRun
        {
            get { return Convert.ToInt64(ConfigurationManager.AppSettings.Get("GiftCerificateOptumDayServiceRun")); }
        }

        public string GiftCerificateOptumDownloadPath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("GiftCerificateOptumDownloadPath")); }
        }

        public DateTime AccountZipSubstituteRegenerationScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(
                        ConfigurationManager.AppSettings.Get("AccountZipSubstituteRegenerationScheduleTime"));
            }
        }

        public int AccountZipSubstituteRegenerationInterval
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("AccountZipSubstituteRegenerationInterval"));
            }
        }

        public int AccountZipSubstituteStartTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("AccountZipSubstituteStartTime")); }
        }

        public int AccountZipSubstituteEndTime
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("AccountZipSubstituteEndTime")); }
        }

        public bool RegenerateAccountEventZip
        {
            get
            {
                bool regenerateAccountEventZip;
                bool.TryParse(ConfigurationManager.AppSettings.Get("RegenerateAccountEventZip"),
                    out regenerateAccountEventZip);
                return regenerateAccountEventZip;
            }
        }

        public string AccountZipRegenerationResourcePath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("AccountZipRegenerationResourcePath")); }
        }

        public int CustomerForSuspectSyncCutoffDays
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CustomerForSuspectSyncCutoffDays")); }
        }

        public long OptumNvMedicareAccountId
        {
            get
            {
                int accountId = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("OptumNvMedicareAccountId"), out accountId);
                return accountId;
            }
        }

        public IEnumerable<long> OptumNVSettingAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("OptumNVSettingAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var accountIdsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in accountIdsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        accountIds.Add(hpCampaignId);
                    }
                }

                return accountIds;
            }
        }

        public string[] FloridaBlueGapsCustomTags
        {
            get
            {
                var tags = ConfigurationManager.AppSettings.Get("FloridaBlueGapsCustomTags");
                if (string.IsNullOrEmpty(tags)) return null;
                var floridaBlueGapsCustomTags = tags.Split(',');
                floridaBlueGapsCustomTags =
                    floridaBlueGapsCustomTags.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                return floridaBlueGapsCustomTags;
            }
        }

        public long FloridaBlueGapsId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("FloridaBlueGapsId"), out accountId);
                return accountId;
            }
        }

        public string BcbsmiDateAddedIncorrectPhoneNumberSettingPath
        {
            get
            {
                return
                    Convert.ToString(
                        ConfigurationManager.AppSettings.Get("BcbsmiDateAddedIncorrectPhoneNumberSettingPath"));
            }
        }

        public string UniversalMemberFileSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("UniversalMemberFileSftpPath"); }
        }

        public string UniversalProviderFileSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("UniversalProviderFileSftpPath"); }
        }

        public string LabReportTestResultPath
        {
            get { return ConfigurationManager.AppSettings.Get("LabReportTestResultPath"); }
        }

        public string LabReportArchivedTestResultPath
        {
            get { return ConfigurationManager.AppSettings.Get("LabReportArchivedTestResultPath"); }
        }

        public int LabReportParserInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("LabReportParserInterval")); }
        }

        public string UniversalMemberArchivedFilePath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("UniversalMemberArchivedFilePath")); }
        }

        public string UniversalProviderArchivedFilePath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("UniversalProviderArchivedFilePath")); }
        }

        public string LabReportClientLogPath
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings.Get("LabReportClientLogPath")); }
        }

        public long BcbsScAssessmentAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("BcbsScAssessmentAccountId"), out accountId);
                return accountId;

            }
        }

        public IEnumerable<long> BcbsScResultPdfAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("BcbsScResultPdfAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var accountIdsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in accountIdsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        accountIds.Add(hpCampaignId);
                    }
                }

                return accountIds;
            }
        }
        public DateTime ResultFlowChangeDate
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("ResultFlowChangeDate")); }
        }

        public IEnumerable<long> HealthPlanMemberStatusReportAccountIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("HealthPlanMemberStatusReportAccountIds");
                var accountIds = new List<long>();
                if (string.IsNullOrEmpty(configValue)) return accountIds;

                var accountIdsArray =
                    configValue.Split(',')
                        .Where(healthPlanId => !string.IsNullOrEmpty(healthPlanId))
                        .Select(healthPlanId => healthPlanId.Trim());

                foreach (var healthPlanId in accountIdsArray)
                {
                    long hpCampaignId;
                    long.TryParse(healthPlanId, out hpCampaignId);
                    if (hpCampaignId > 0)
                    {
                        accountIds.Add(hpCampaignId);
                    }
                }

                return accountIds;
            }
        }

        public string HealthPlanExportRootPath
        {
            get { return ConfigurationManager.AppSettings.Get("HealthPlanExportRootPath"); }
        }

        public DayOfWeek ConnecticareEventScheduleExportDay
        {
            get
            {
                try
                {
                    var connecticareEventScheduleExportDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("ConnecticareEventScheduleExportDay"),
                        out connecticareEventScheduleExportDay);
                    if (connecticareEventScheduleExportDay >= 0 && connecticareEventScheduleExportDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("ConnecticareEventScheduleExportDay"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public string WellmedResultPdfCatalystDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedResultPdfCatalystDownloadPath"); }
        }

        public string WellmedSftpResultPdfCatalystDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedSftpResultPdfCatalystDownloadPath"); }
        }

        public string WellmedCustomerGroupName
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedCustomerGroupName"); }
        }

        public int IntervalForSendNotificationToNursePractitioner
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("IntervalForSendNotificationToNursePractitioner")); }
        }

        public string MedicareAppUrl
        {
            get { return ConfigurationManager.AppSettings.Get("MedicareAppUrl"); }
        }

        public int FillEventZipRadius
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("FillEventZipRadius")); }
        }

        public int SyncResultsReadyForCodingInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("SyncResultsReadyForCodingInterval")); }
        }

        public DayOfWeek BcbsMiGapResultExportIntervalDay
        {
            get
            {
                try
                {
                    var bcbsMiGapResultExportIntervalDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiGapResultExportIntervalDay"),
                        out bcbsMiGapResultExportIntervalDay);
                    if (bcbsMiGapResultExportIntervalDay >= 0 && bcbsMiGapResultExportIntervalDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiGapResultExportIntervalDay"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public DayOfWeek BcbsMiResultPdfDownloadIntervalDay
        {
            get
            {
                try
                {
                    var bcbsMiResultPdfDownloadIntervalDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("BcbsMiResultPdfDownloadIntervalDay"),
                        out bcbsMiResultPdfDownloadIntervalDay);
                    if (bcbsMiResultPdfDownloadIntervalDay >= 0 && bcbsMiResultPdfDownloadIntervalDay <= 6)
                    {
                        return
                            (DayOfWeek)
                                Enum.Parse(typeof(DayOfWeek),
                                    ConfigurationManager.AppSettings.Get("BcbsMiResultPdfDownloadIntervalDay"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public string SignatureForCoverLetterRelativePath
        {
            get { return AppUrl + "/Config/Content/ResultPacket/content/pcp_coverletter_signature.jpg"; }
        }

        public string FloridaBlueSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueSftpHost"); }
        }

        public string FloridaBlueSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueSftpUserName"); }
        }

        public string FloridaBlueSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueSftpPassword"); }
        }

        public bool SendReportToFloridaBlueSftp
        {
            get
            {
                bool sendReportToFloridaBlueSftp;
                bool.TryParse(ConfigurationManager.AppSettings.Get("SendReportToFloridaBlueSftp"), out sendReportToFloridaBlueSftp);
                return sendReportToFloridaBlueSftp;
            }
        }

        public string FloridaBlueSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("FloridaBlueSftpPath"); }
        }

        public long FloridaBlueFepAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("FloridaBlueFepAccountId"), out accountId);
                return accountId;
            }
        }

        public DayOfWeek FloridaBlueFepExportDayOfWeek
        {
            get
            {
                try
                {
                    var floridaBlueFepExportDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("FloridaBlueFepExportDayOfWeek"),
                        out floridaBlueFepExportDay);
                    if (floridaBlueFepExportDay >= 0 && floridaBlueFepExportDay <= 6)
                    {
                        return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), ConfigurationManager.AppSettings.Get("FloridaBlueFepExportDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public string IncrementalResultExportsPath
        {
            get { return ConfigurationManager.AppSettings.Get("IncrementalResultExportsPath"); }
        }

        public string CumulativeResultExportsPath
        {
            get { return ConfigurationManager.AppSettings.Get("CumulativeResultExportsPath"); }
        }

        public DateTime KareoIntegrationCutOffDate
        {
            get
            {
                DateTime kareoIntegrationCutOffDate;
                if (DateTime.TryParse(ConfigurationManager.AppSettings.Get("KareoIntegrationCutOffDate"),
                    out kareoIntegrationCutOffDate))
                    return kareoIntegrationCutOffDate;

                return DateTime.Today;
            }
        }

        public string KareoIntegrationSettingResourcePath
        {
            get { return ConfigurationManager.AppSettings.Get("KareoIntegrationSettingResourcePath"); }
        }

        public string AnthemAdditionalFieldValues
        {
            get { return ConfigurationManager.AppSettings.Get("AnthemAdditionalFieldValues"); }
        }

        public DayOfWeek AppleCareGiftCertificateDayOfWeek
        {
            get
            {
                try
                {
                    var floridaBlueFepExportDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("AppleCareGiftCertificateDayOfWeek"),
                        out floridaBlueFepExportDay);
                    if (floridaBlueFepExportDay >= 0 && floridaBlueFepExportDay <= 6)
                    {
                        return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), ConfigurationManager.AppSettings.Get("AppleCareGiftCertificateDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Sunday;
            }
        }

        public string[] AcesClientIds
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings.Get("AcesClientIds");
                string[] clientIds;
                if (string.IsNullOrEmpty(configValue)) return null;

                clientIds =
                    configValue.Split(',')
                        .Where(clientId => !string.IsNullOrEmpty(clientId)).Select(clientId => clientId).ToArray();

                return clientIds;
            }
        }

        public string HiptoAcesCrossWalkReportFilePath
        {
            get { return ConfigurationManager.AppSettings.Get("HiptoAcesCrossWalkReportFilePath"); }
        }

        public int HiptoAcesCrossWalkReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("HiptoAcesCrossWalkReportInterval")); }
        }
        public DateTime HiptoAcesCrossWalkReportScheduleTime
        {
            get
            {
                return
                    Convert.ToDateTime(ConfigurationManager.AppSettings.Get("HiptoAcesCrossWalkReportScheduleTime"));
            }
        }

        public string MemberUploadbyAcesSourceFolderPath
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings.Get("MemberUploadbyAcesSourceFolderPath"));
            }
        }

        public string MemberUploadbyAcesDestinationFolderPath
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings.Get("MemberUploadbyAcesDestinationFolderPath"));
            }
        }

        public string CustomerEligibilityUploadSftpPath
        {
            get { return ConfigurationManager.AppSettings.Get("CustomerEligibilityUploadSftpPath"); }
        }

        public DateTime CustomerEligibilityUploadScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("CustomerEligibilityUploadScheduleTime")); }
        }

        public int CustomerEligibilityUploadIntervalHours
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CustomerEligibilityUploadIntervalHours")); }
        }

        public DateTime MemberUploadbyAcesReportScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("MemberUploadbyAcesReportScheduleTime")); }
        }

        public int MemberUploadbyAcesReportInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MemberUploadbyAcesReportInterval")); }
        }

        public double MedicareSessionValidityDuration
        {
            get
            {
                var value = double.MinValue;
                double.TryParse(ConfigurationManager.AppSettings.Get("MedicareSessionValidityDuration"), out value);
                return value <= 0 ? 12 : value;
            }
        }

        public DateTime AnthemCutOfDateForSendingReport
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("AnthemCutOfDateForSendingReport"));
            }
        }

        public int BatchPageSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("BatchPageSize")); }
        }


        public string GiftCertificateReportInternalLocation
        {
            get { return ConfigurationManager.AppSettings.Get("GiftCertificateReportInternalLocation"); }
        }

        public string IpResultSftpFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("IpResultSftpFolderLocation"); }
        }

        public int IpResultPdfIntervalInMinutes
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("IpResultPdfIntervalInMinutes")); }
        }

        public long PPAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("PPAccountId"), out accountId);
                return accountId;
            }
        }

        public DateTime PPEventCutOfDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("PPEventCutOfDate"));
            }
        }

        public string ChatQuestionerAppUrl
        {
            get { return ConfigurationManager.AppSettings.Get("ChatQuestionerAppUrl"); }
        }

        public long NammAccountId
        {
            get
            {
                long accountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("NammAccountId"), out accountId);
                return accountId;
            }
        }

        public string NammAttestationFormsPath
        {
            get { return ConfigurationManager.AppSettings.Get("NammAttestationFormsPath"); }
        }

        public string NammSourceDirectory
        {
            get { return ConfigurationManager.AppSettings.Get("NammSourceDirectory"); }
        }
        public string NammSftpHost
        {
            get { return ConfigurationManager.AppSettings.Get("NammSftpHost"); }
        }
        public string NammSftpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("NammSftpUserName"); }
        }
        public string NammSftpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("NammSftpPassword"); }
        }
        public bool IsSftpEnableforNaamAccount
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsSftpEnableforNaamAccount")); }
        }

        public bool StopCustomerEligibilityUpload
        {
            get
            {
                bool stopCustomerEligibilityUpload;
                bool.TryParse(ConfigurationManager.AppSettings.Get("StopCustomerEligibilityUpload"),
                    out stopCustomerEligibilityUpload);
                return stopCustomerEligibilityUpload;
            }
        }

        public bool StopMemberUploadbyAces
        {
            get
            {
                bool stopMemberUploadbyAcesPollingAgent;
                bool.TryParse(ConfigurationManager.AppSettings.Get("StopMemberUploadbyAces"),
                    out stopMemberUploadbyAcesPollingAgent);
                return stopMemberUploadbyAcesPollingAgent;
            }
        }

        public DateTime? SyncStartDate
        {
            get
            {
                var dateString = ConfigurationManager.AppSettings.Get("SyncStartDate");
                if (string.IsNullOrWhiteSpace(dateString))
                    return null;

                return Convert.ToDateTime(dateString);
            }
        }

        public DateTime? SyncEndDate
        {
            get
            {
                var dateString = ConfigurationManager.AppSettings.Get("SyncEndDate");
                if (string.IsNullOrWhiteSpace(dateString))
                    return null;

                return Convert.ToDateTime(dateString);
            }
        }
        public string BloodResultFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("BloodResultFolderLocation"); }
        }

        public string BloodResultArchiveFolderLocation
        {
            get { return ConfigurationManager.AppSettings.Get("BloodResultArchiveFolderLocation"); }
        }

        public string ClientSftpPathForHipToAces
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ClientSftpPathForHipToAces");
            }
        }

        public DateTime StopSendingPdftoHealthPlanDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("StopSendingPdftoHealthPlanDate"));
            }
        }

        public string ResultPacketLocation
        {
            get
            {
                return SiteConfigurableContentPath + @"\ResultPacket\";
            }
        }

        public string SendTestMediaFilesClientLocation
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("SendTestMediaFilesClientLocation");
            }
        }

        public IEnumerable<long> AdditionalTestIdToSendMediaFiles
        {
            get
            {
                var configTestIds = ConfigurationManager.AppSettings.Get("AdditionalTestIdToSendMediaFiles");
                var testIds = new List<long>();
                if (string.IsNullOrEmpty(configTestIds)) return testIds;

                var testsArray = configTestIds.Split(',').Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Trim());

                foreach (var test in testsArray)
                {
                    long testId;
                    long.TryParse(test, out testId);
                    if (testId > 0)
                    {
                        testIds.Add(testId);
                    }
                }

                return testIds;
            }
        }

        public IEnumerable<long> IpSendMediaFilesForTestIds
        {
            get
            {
                var configTestIds = ConfigurationManager.AppSettings.Get("IpSendMediaFilesForTestIds");
                var testIds = new List<long>();
                if (string.IsNullOrEmpty(configTestIds)) return testIds;

                var testsArray = configTestIds.Split(',').Where(t => !string.IsNullOrEmpty(t)).Select(t => t.Trim());

                foreach (var test in testsArray)
                {
                    long testId;
                    long.TryParse(test, out testId);
                    if (testId > 0)
                    {
                        testIds.Add(testId);
                    }
                }

                return testIds;
            }
        }

        public bool StopHansonResultParse
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("StopHansonResultParse")); }
        }

        public string ChatAssessmentPdfUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ChatAssessmentPdfUrl");
            }
        }

        public string ChatAssessmentPdfUserName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ChatAssessmentPdfUserName");
            }
        }

        public string ChatAssessmentPdfPassword
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ChatAssessmentPdfPassword");
            }
        }

        public int CustomerActivityTypeUploadIntervalMinutes
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CustomerActivityTypeUploadIntervalMinutes"));
            }
        }

        public int MemberUploadParseIntervalMinutes
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("MemberUploadParseIntervalMinutes"));
            }
        }

        public string ChaperoneFormUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ChaperoneFormUrl");
            }
        }
        public string HighImageQuality { get { return "HighQuality_"; } }

        public DateTime StopSendingMediaFileDate
        {
            get
            {
                return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("StopSendingMediaFileDate"));
            }
        }
        public int PullBackPreAssessmentCallQueueCustomerInterval
        {
            get { throw new NotImplementedException(); }
        }

        public bool SyncWithHra
        {
            get
            {
                bool syncWithHra;
                Boolean.TryParse(ConfigurationManager.AppSettings.Get("SyncWithHra"), out syncWithHra);

                return syncWithHra;
            }
        }

        public string WellmedTxFocPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WellmedTxFocPath");
            }
        }

        public string WellmedFlFocPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WellmedFlFocPath");
            }
        }

        public long WellmedTxAccountId
        {
            get
            {
                long wellmedTxAccountId = 0;
                long.TryParse(ConfigurationManager.AppSettings.Get("WellmedTxAccountId"), out wellmedTxAccountId);
                return wellmedTxAccountId;
            }
        }
        public string WellmedTxLockCorporateEventFolderLocation
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WellmedTxLockCorporateEventFolderLocation");
            }
        }

        public string WellmedFlLockCorporateEventFolderLocation
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WellmedFlLockCorporateEventFolderLocation");
            }
        }

        public DateTime WellmedParseLockedEventScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("WellmedParseLockedEventScheduleTime")); }
        }

        public int WellmedParseLockedEventIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("WellmedParseLockedEventIntervalHours"), out hours);
                return (hours < 0 ? 12 : hours);
            }
        }

        public string WellmedTxCatalystGroupName
        {
            get { return ConfigurationManager.AppSettings.Get("WellmedTXCatalystGroupName"); }
        }

        public string WellmedFlGiftCertificateReportPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WellmedFlGiftCertificateReportPath");
            }
        }

        public string WellmedTxGiftCertificateReportPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WellmedTxGiftCertificateReportPath");
            }
        }

        public long WellmedGiftCertificateDayOfWeek
        {
            get { return Convert.ToInt64(ConfigurationManager.AppSettings.Get("WellmedGiftCertificateDayOfWeek")); }
        }

        public DateTime WellmedGiftCertificateScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("WellmedGiftCertificateScheduleTime")); }
        }

        public int WellmedGiftCertificateIntervalHours
        {
            get
            {
                int hours = 0;
                Int32.TryParse(ConfigurationManager.AppSettings.Get("WellmedGiftCertificateIntervalHours"), out hours);
                return (hours < 0 ? 12 : hours);
            }
        }

        public string HcpNvIncorrectPhoneNumberDownloadPath
        {
            get { return ConfigurationManager.AppSettings.Get("HcpNvIncorrectPhoneNumberDownloadPath"); }
        }

        public DayOfWeek WellmedIncorrectPhoneNumberDayOfWeek
        {
            get
            {
                try
                {
                    var floridaBlueFepExportDay = 0;
                    int.TryParse(ConfigurationManager.AppSettings.Get("WellmedIncorrectPhoneNumberDayOfWeek"),
                        out floridaBlueFepExportDay);

                    if (floridaBlueFepExportDay >= 0 && floridaBlueFepExportDay <= 6)
                    {
                        return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), ConfigurationManager.AppSettings.Get("WellmedIncorrectPhoneNumberDayOfWeek"));
                    }
                }
                catch (Exception)
                {

                }
                return DayOfWeek.Friday;
            }
        }
        public string OutTakeReportPath { get { return ConfigurationManager.AppSettings.Get("OutTakeReportPath"); } }
        public string WellmedTxFolder { get { return ConfigurationManager.AppSettings.Get("WellmedTxFolder"); } }
        public string WellmedFlFolder { get { return ConfigurationManager.AppSettings.Get("WellmedFlFolder"); } }

        public string BcbsScFolder { get { return ConfigurationManager.AppSettings.Get("BcbsFolder"); } }
        public string HcpNvFolder { get { return ConfigurationManager.AppSettings.Get("HcpNvFolder"); } }

        public string LockCorporateEventFolderLocation { get { return ConfigurationManager.AppSettings.Get("LockCorporateEventFolderLocation"); } }

        public DateTime EventZipProductTypePollingAgentRegenerationScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EventZipProductTypePollingAgentRegenerationScheduleTime")); }
        }

        public int EventZipProductTypePollingAgentRegenerationInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("EventZipProductTypePollingAgentRegenerationInterval")); }
        }

        public DateTime EventZipProductTypeSubstitutePollingAgentRegenerationScheduleTime
        {
            get { return Convert.ToDateTime(ConfigurationManager.AppSettings.Get("EventZipProductTypeSubstitutePollingAgentRegenerationScheduleTime")); }
        }

        public int EventZipProductTypeSubstitutePollingAgentRegenerationInterval
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings.Get("EventZipProductTypeSubstitutePollingAgentRegenerationInterval")); }
        }
        public long HcpNvIncorrectPhoneNumberDayOfWeek
        {
            get { return Convert.ToInt64(ConfigurationManager.AppSettings.Get("HcpNvIncorrectPhoneNumberDayOfWeek")); }
        }
    }

}


