using System;
using System.Collections.Generic;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{
    public class EEventWizard
    {
        private EHost m_objHost;
        private float m_fCosttoUseHostSite = 0;
        private int m_iPaymentTypeID = 0;
        private string m_strPaymentDueDate = string.Empty;
        private int m_iScheduleMethodID = 0;
        private int m_iCommunicationModeID = 0;
        private bool m_bolMinimumSiteRequirements = false;
        private bool m_bolConfirmVisually = false;
        private string m_strConfirmComments = string.Empty;
        private int m_iEventID = 0;
        private string m_strName = string.Empty;
        private string m_strEventDate = string.Empty;
        private string m_strEventStartTime = string.Empty;
        private string m_strEventEndTime = string.Empty;
        private string m_strTimeZone = string.Empty;
        private int m_iScheduleTemplateID = 0;
        private EEventType m_objEventType;
        private string m_strTeamArrivalTime = string.Empty;
        private string m_strTeamDepartureTime = string.Empty;
        private string m_strInvitationCode = string.Empty;
        private List<EEventPod> m_objEventPod = null;
        private bool m_bolRescheduled = false;
        private bool m_bolActive = true;
        private bool isEditEvent = false;
        private bool isLock = false;

        private EFranchisee m_objFranchisee;
        private EFranchiseeFranchiseeUser m_objFranchiseeFranchiseeUser;

        private List<EEventPackage> m_objEventPackage = null;

        private Int64 _hostPaymentId;
        private Int64 _hostDepositId;


        public long UpdatedByOrganizationRoleUser
        { get; set; }

        /// <summary>
        /// Event Notes
        /// </summary>

        public string Notes { get; set; }

        /// <summary>
        /// Event Status
        /// </summary>

        public int EventStatus { get; set; }

        public long? EventCancellationReason { get; set; }


        public float DepositAmount { get; set; }


        public bool PayByCheck { get; set; }


        public bool PayByCreditCard { get; set; }


        public string DepositDueDate { get; set; }


        public List<EEventPackage> EventPackage
        {
            get { return m_objEventPackage; }
            set { m_objEventPackage = value; }
        }

        /// <summary>
        /// 
        /// </summary>

        public Int64 EventActivityTemplateID { get; set; }

        /// <summary>
        /// Host Screening Coordinator SalesRep ID
        /// </summary>

        public Int64 HSCSalesRepID { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string TeamArrivalTime
        {
            get
            {
                return m_strTeamArrivalTime;
            }
            set
            {
                m_strTeamArrivalTime = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>

        public string TeamDepartureTime
        {
            get
            {
                return m_strTeamDepartureTime;
            }
            set
            {
                m_strTeamDepartureTime = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>

        public string InvitationCode
        {
            get
            {
                return m_strInvitationCode;
            }
            set
            {
                m_strInvitationCode = value;
            }
        }

        /// <summary>
        /// host object for mapping event with host.
        /// </summary>

        public EHost Host
        {
            get
            {
                return m_objHost;
            }
            set
            {
                m_objHost = value;
            }
        }

        /// <summary>
        /// event costtousehostsite 
        /// </summary>

        public float CosttoUseHostSite
        {
            get
            {
                return m_fCosttoUseHostSite;
            }
            set
            {
                m_fCosttoUseHostSite = value;
            }
        }

        /// <summary>
        /// event Payment Method ID
        /// </summary>

        public int PaymentTypeID
        {
            get
            {
                return m_iPaymentTypeID;
            }
            set
            {
                m_iPaymentTypeID = value;
            }
        }

        /// <summary>
        /// Payment Due Date
        /// </summary>

        public string PaymentDueDate
        {
            get
            {
                return m_strPaymentDueDate;
            }
            set
            {
                m_strPaymentDueDate = value;
            }
        }

        /// <summary>
        /// Schedule Method ID
        /// </summary>

        public int ScheduleMethodID
        {
            get
            {
                return m_iScheduleMethodID;
            }
            set
            {
                m_iScheduleMethodID = value;
            }
        }

        /// <summary>
        /// Communication Mode ID
        /// </summary>

        public int CommunicationModeID
        {
            get
            {
                return m_iCommunicationModeID;
            }
            set
            {
                m_iCommunicationModeID = value;
            }
        }

        /// <summary>
        /// Minimum Site Requirements
        /// </summary>

        public bool MinimumSiteRequirements
        {
            get { return m_bolMinimumSiteRequirements; }
            set { m_bolMinimumSiteRequirements = value; }
        }

        /// <summary>
        /// Confirm Visually or Confirm verbally
        /// </summary>

        public bool ConfirmVisually
        {
            get { return m_bolConfirmVisually; }
            set { m_bolConfirmVisually = value; }
        }

        /// <summary>
        /// ConfirmComments
        /// </summary>

        public string ConfirmComments
        {
            get { return m_strConfirmComments; }
            set { m_strConfirmComments = value; }
        }

        /// <summary>
        /// unique Event id
        /// </summary>

        public int EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }
        }


        /// <summary>
        ///Event name
        /// </summary>

        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        /// <summary>
        /// event date
        /// </summary>

        public string EventDate
        {
            get
            {
                return m_strEventDate;
            }
            set
            {
                m_strEventDate = value;
            }
        }

        /// <summary>
        /// start time of event
        /// </summary>

        public string EventStartTime
        {
            get
            {
                return m_strEventStartTime;
            }
            set
            {
                m_strEventStartTime = value;
            }
        }

        /// <summary>
        /// end time of event
        /// </summary>

        public string EventEndTime
        {
            get
            {
                return m_strEventEndTime;
            }
            set
            {
                m_strEventEndTime = value;
            }
        }

        /// <summary>
        /// time zone of the event 
        /// </summary>

        public string TimeZone
        {
            get
            {
                return m_strTimeZone;
            }
            set
            {
                m_strTimeZone = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>

        public int ScheduleTemplateID
        {
            get { return m_iScheduleTemplateID; }
            set { m_iScheduleTemplateID = value; }
        }

        /// <summary>
        /// event type object for mapping event with event
        /// </summary>

        public EEventType EventType
        {
            get
            {
                return m_objEventType;
            }
            set
            {
                m_objEventType = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>

        public List<EEventPod> EventPod
        {
            get { return m_objEventPod; }
            set { m_objEventPod = value; }
        }

        /// <summary>
        /// event status
        /// </summary>

        public bool Rescheduled
        {
            get
            {
                return m_bolRescheduled;
            }
            set
            {
                m_bolRescheduled = value;
            }
        }

        /// <summary>
        /// Event status
        /// </summary>

        public bool Active
        {
            get
            {
                return m_bolActive;
            }
            set
            {
                m_bolActive = value;
            }
        }

        /// <summary>
        /// franchisee object for mapping event with franchisee
        /// </summary>

        public EFranchisee Franchisee
        {
            get
            {
                return m_objFranchisee;
            }
            set
            {
                m_objFranchisee = value;
            }
        }

        /// <summary>
        /// franchiseefranchiseeuser object for mapping event with franchiseefranchiseeuser
        /// </summary>

        public EFranchiseeFranchiseeUser FranchiseeFranchiseeUser
        {
            get
            {
                return m_objFranchiseeFranchiseeUser;
            }
            set
            {
                m_objFranchiseeFranchiseeUser = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>


        public bool EditEvent
        {
            get { return isEditEvent; }
            set { isEditEvent = value; }
        }
        public bool IsLock
        {
            get { return isLock; }
            set { isLock = value; }
        }
        public string InstructionForCallCenter

        { get; set; }

        public Int64 HostPaymentId
        {
            get { return _hostPaymentId; }
            set { _hostPaymentId = value; }
        }
        public Int64 HostDepositId
        {
            get { return _hostDepositId; }
            set { _hostDepositId = value; }
        }

        public List<ETest> EventTest { get; set; }

        public long CooperateAccountId { get; set; }

        public long HospitalPartnerId { get; set; }

        public long TerritoryId { get; set; }

        public bool EnableAlaCarteOnline { get; set; }
        public bool EnableAlaCarteCallCenter { get; set; }
        public bool EnableAlaCarteTechnician { get; set; }

        public bool AttachHospitalMaterial { get; set; }
        public bool IsDynamicScheduling { get; set; }
        public int? SlotInterval { get; set; }
        public int? ServerRooms { get; set; }
        public DateTime? LunchStartTime { get; set; }
        public int? LunchDuration { get; set; }
        public long? HealthAssessmentTemplateId { get; set; }

        public bool CaptureInsuranceId { get; set; }
        public bool InsuranceIdRequired { get; set; }

        public bool EnableProduct { get; set; }

        public bool CaptureSsn { get; set; }

        public bool IsFemaleOnly { get; set; }

        public bool RecommendPackage { get; set; }

        public bool AskPreQualificationQuestion { get; set; }

        public int? FixedGroupScreeningTime { get; set; }

        public bool RestrictEvaluation { get; set; }

        public bool EnableForCallCenter { get; set; }

        public bool EnableForTechnician { get; set; }

        public bool IsPackageTimeOnly { get; set; }

        public bool IsManual { get; set; }

        public long? UpdatedByAdmin { get; set; }

        public bool AllowNonMammoPatients { get; set; }

        public string ProductType { get; set; }

    }
}
