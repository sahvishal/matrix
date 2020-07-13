using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class EGlobalAttributes
    {
        private int m_iNumberOfPictures=0;
        private string m_strProspectKey1 = string.Empty;
        private string m_strProspectKey2 = string.Empty;
        private string m_strProspectKey3 = string.Empty;
        private int m_iDays = 0;
        private int m_iAppointments = 0;
        private int m_scheduletemplateid = 0;
        private string m_strMVAccessIPs = "";
        private string m_strGlobalCutOffDate = "";
        // Begin Added By Viranjay
        private string m_ShowOrderCatalog = string.Empty;
        private string m_MVPermittedKey = string.Empty;
        private string m_SystemVersion = string.Empty;
        private Int64 m_Eventdistance;
        private string m_FromEmailAddress = string.Empty;
        private string m_FromEmailName = string.Empty;
        private string m_AdministratorEmailAddress = string.Empty;
        private string m_HealthyesContactEmailAddress = string.Empty;
        private string m_GoogleCalendarUsername = string.Empty;
        private string m_GoogleCalendarPassword = string.Empty;
        private string m_CouponPrefix = string.Empty;
        private int m_CCRepDashBoardRefereshTime = 0;
        private string m_DisplayQABar= string.Empty;
        
        
        private decimal m_dblMaxDollarCommission = 0.00m;
        private decimal m_dblMaxPercentCommission = 0.00m;
        private decimal m_dblMaxDollarCommissionSalesRep = 0.00m;
        private decimal m_dblMaxPercentCommissionSalesRep = 0.00m;

        private string m_HealthYesCompetitor = string.Empty;
    
        // End Added By Viranjay
        /// <summary>
        /// 
        /// </summary>
        public string MVAccessIPs { get { return m_strMVAccessIPs; } set { m_strMVAccessIPs = value; } }

        /// <summary>
        /// 
        /// </summary>
        public string GlobalCutOffDate { get { return m_strGlobalCutOffDate; } set { m_strGlobalCutOffDate = value; } }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfPictures
        {
            get
            {
                return m_iNumberOfPictures;
            }
            set
            {
                m_iNumberOfPictures = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProspectKey1
        {
            get
            {
                return m_strProspectKey1;
            }
            set
            {
                m_strProspectKey1 = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProspectKey2
        {
            get
            {
                return m_strProspectKey2;
            }
            set
            {
                m_strProspectKey2 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProspectKey3
        {
            get
            {
                return m_strProspectKey3;
            }
            set
            {
                m_strProspectKey3 = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DaysToChangePassword
        {
            get
            {
                return m_iDays;
            }
            set
            { 
                m_iDays =value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int AppointmentSlot
        {
            get
            {
                return  m_iAppointments;
            }
            set
            {
                m_iAppointments = value;
            }

        }

        /// <summary>
        /// Event Schedule Template ID
        /// </summary>
        public int ScheduleTemplateID
        {
            get
            {
                return m_scheduletemplateid;
            }
            set
            {
                m_scheduletemplateid = value;
            }

        }
       

        /// <summary>
        /// Show Order Catalog
        /// </summary>
        public string ShowOrderCatalog
        {
            get
            {
                return m_ShowOrderCatalog;
            }
            set
            {
                m_ShowOrderCatalog = value;
            }
        }

        /// <summary>
        /// Medical Vendor Permitted Key
        /// </summary>   
        public string MVPermittedKey
        {
            get
            {
                return m_MVPermittedKey;
            }
            set
            {
                m_MVPermittedKey = value;
            }
        }

        /// <summary>
        /// System Version
        /// </summary>       
        public string SystemVersion
        {
            get
            {
                return m_SystemVersion;
            }
            set
            {
                m_SystemVersion = value;
            }
        }

        /// <summary>
        /// Event Distance
        /// </summary>        
        public Int64 Eventdistance
        {
            get
            {
                return m_Eventdistance;
            }
            set
            {
                m_Eventdistance = value;
            }
        }

        /// <summary>
        /// From Email Address
        /// </summary>        
        public string FromEmailAddress
        {
            get
            {
                return m_FromEmailAddress;
            }
            set
            {
                m_FromEmailAddress = value;               
            }
        }

        /// <summary>
        /// From Email Name
        /// </summary>  
        public string FromEmailName
        {
            get
            {
                return m_FromEmailName;
            }
            set
            {
                m_FromEmailName = value;
            }
        }

        /// <summary>
        /// Administrator Email Address
        /// </summary>   
        public string AdministratorEmailAddress
        {
            get
            {
                return m_AdministratorEmailAddress;
            }
            set
            {
                m_AdministratorEmailAddress = value;
            }
        }

        /// <summary>
        /// Healthyes Contact Email Address
        /// </summary>  
        public string HealthyesContactEmailAddress
        {
            get
            {
                return m_HealthyesContactEmailAddress;
            }
            set
            {
                m_HealthyesContactEmailAddress = value;
            }
        }

        /// <summary>
        /// Google Calendar Username
        /// </summary>  
        public string GoogleCalendarUsername
        {
            get
            {
                return m_GoogleCalendarUsername;
            }
            set
            {
                m_GoogleCalendarUsername = value;
            }
        }

        /// <summary>
        /// Google Calendar Password
        /// </summary>    
        public string GoogleCalendarPassword
        {
            get
            {
                return m_GoogleCalendarPassword;
            }
            set
            {
                m_GoogleCalendarPassword = value;
            }
        }

        /// <summary>
        /// Coupon Prefix
        /// </summary> 
        public string CouponPrefix
        {
            get
            {
                return m_CouponPrefix;
            }
            set
            {
                m_CouponPrefix = value;
            }
        }

        /// <summary>
        /// CC Rep Referesh Time
        /// </summary>    
        public int CCRepDashBoardRefereshTime
        {
            get
            {
                return m_CCRepDashBoardRefereshTime;
            }
            set
            {
                m_CCRepDashBoardRefereshTime = value;
            }
        }

        /// <summary>
        /// Display QA Bar
        /// </summary>  
        public string DisplayQABar
        {
            get
            {
                return m_DisplayQABar;
            }
            set
            {
                m_DisplayQABar = value;
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        public decimal MaxDollarCommission
        {
            get
            {
                return m_dblMaxDollarCommission;
            }
            set
            {
                m_dblMaxDollarCommission = value;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        public decimal MaxPercentCommission
        {
            get
            {
                return m_dblMaxPercentCommission;
            }
            set
            {
                m_dblMaxPercentCommission = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public decimal MaxDollarCommissionSalesRep
        {
            get
            {
                return m_dblMaxDollarCommissionSalesRep;
            }
            set
            {
                m_dblMaxDollarCommissionSalesRep = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public decimal MaxPercentCommissionSalesRep
        {
            get
            {
                return m_dblMaxPercentCommissionSalesRep;
            }
            set
            {
                m_dblMaxPercentCommissionSalesRep = value;
            }

        }

        public decimal CancellationFee { get; set; }

        /// <summary>
        /// HealthYesCompetitor
        /// </summary>
        public string HealthYesCompetitor
        {
            get
            {
                return m_HealthYesCompetitor;
            }
            set
            {
                m_HealthYesCompetitor = value;
            }
        }

        public string EventStartTime { get; set; }

        public string EventEndTime { get; set; }

        public decimal MinimumPurchaseAmount { get; set; }

        public string IncomingPhoneLineRequired { get; set; }

        public string EnableAlaCarte { get; set; }

        public string AreaCode { get; set; }

        public string EnableBarCode { get; set; }

        public string UpsellPackage { get; set; }

        public string UpsellCd { get; set; }

        public string UpsellAlaCarte { get; set; }

        public int MaxNoOfEventToShowOnline { get; set; }

        public int MaxNoOfAppointmentSlotsToShowOnline { get; set; }

        public int EventListPageSizeOnline { get; set; }

        public string PaperSize { get; set; }

        public string DisplayPremiumVersiononPortal { get; set; }

        public string EnableResultDeliveryNotification { get; set; }

        public string EnableNewsletterPrompt { get; set; }

        public string SourceCodeLabel { get; set; }

        public int CutOffHourNumberforOnlineEventSelection { get; set; }

        public string DisplayRescheduleAppointmentPortal { get; set; }

        public string ShowBasicBiometric { get; set; }

        public string EnableQuickOnsiteRegistration { get; set; }

        public string PayLaterOnlineRegistration { get; set; }

        public string RestrictAvailableTimeSlotForCorporate { get; set; }

        public string ScreeningReminderNotification { get; set; }

        public string IsHipaaEnabled { get; set; }
        public string EnableDynamicSlot { get; set; }

        public string LunchStartTime { get; set; }

        public string SendEmptyQueueEvaluationReminder { get; set; }

        public int EventBookingThreshold { get; set; }

        public string PackageSelectionInfo { get; set; }

        public string EnableSmsNotification { get; set; }

        public string EnablePhysicianPartnerCustomerResultFaxNotification { get; set; }

        public string EnableAWVCustomerResultFaxNotification { get; set; }

        public string AskPreQualificationQuestion { get; set; }
        public string PasswordExpirationDays { get; set; }
        public string PreviousPasswordNonRepetitionCount { get; set; }
        public string OtpNotificationMediumEmail { get; set; }
        public string OtpNotificationMediumSms { get; set; }
        public int OtpExpirationMinutes { get; set; }
        public int OtpMisMatchAttemptCount { get; set; }

        public string OtpByGoogleAuthenticator { get; set; }
        public string AllowSafeComputerRemember { get; set; }
        public int SafeDeviceExpiryDays { get; set; }
        public int AlertBeforePasswordExpirationInDays { get; set; }
        public string EnableVoiceMailNotification { get; set; }   
    }
}






