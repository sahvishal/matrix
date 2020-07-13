using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.Entity.Franchisee;

namespace Falcon.Entity.Other
{
    public class EEvent
    {
        
        public int EventStatus { get; set; }

        
        public bool IsTeamConfiguredOnEventDay { get; set; }

        
        public Int64 EventActivityTemplateID { get; set; }

        
        public decimal PhonePayment { get; set; }

        
        public decimal InetPayment { get; set; }

        
        public decimal OnsitePayment { get; set; }

        
        public decimal UpgradePayment { get; set; }

        
        public decimal DowngradePayment { get; set; }

        
        public decimal GiftCertificatePayment { get; set; }

        //TODO: clean up this code when clean up all        
        public short GiftCertificatePaymentCount { get; set; }

        
        public short PhonePaymentCount { get; set; }

        
        public short InetPaymentCount { get; set; }
        
        
        public short OnsitePaymentCount { get; set; }

        
        public short UpgradePaymentCount { get; set; }

        
        public short DowngradePaymentCount { get; set; }

        
        public int EvalStatus_ONE { get; set; }

        
        public int EvalStatus_TWO { get; set; }

        
        public int EvalStatus_THREE { get; set; }

        
        public int EvalStatus_FOUR { get; set; }

        
        public int EvalStatus_FIVE { get; set; }

        
        public int EvalStatus_SIX { get; set; }

        
        public int EvalStatus_SEVEN { get; set; }

        
        public int ChequePaymentCount { get; set; }

        
        public int eCheckPaymentCount { get; set; }

        
        public int CardPaymentCount { get; set; }

        
        public int CashPaymentCount { get; set; }

        
        public double ChequePayment { get; set; }

        
        public double eCheckPayment { get; set; }

        
        public double CardPayment { get; set; }

        
        public double CashPayment { get; set; }

        
        public double TotalPayment { get; set; }

        /// <summary>
        /// EIP deposit, money paid by customers through card and cheques
        /// </summary>        
        public double EIPDeposit { get; set; }

        
        public int NoShowCustomer { get; set; }

        
        public string GoogleURI { get; set; }

        
        public string EventNotes { get; set; }

        
        public string ConfirmComments { get; set; }

        
        public bool ConfirmVisually { get; set; }

        
        public bool MinimumSiteRequirements { get; set; }

        
        public int ScheduleTemplateID { get; set; }

        
        public double Distance { get; set; }

        [IgnoreAudit]
        public EProspect Prospect { get; set; }

        
        public int EventID { get; set; }

        /// <summary>
        /// franchisee object for mapping event with franchisee
        /// </summary>    
        [IgnoreAudit]    
        public EFranchisee Franchisee { get; set; }

        [IgnoreAudit]
        public EFranchiseeFranchiseeUser FranchiseeFranchiseeUser { get; set; }

        
        public string Name { get; set; }

        
        public string EventDate { get; set; }

        
        public string EventStartTime { get; set; }

        
        public string EventEndTime { get; set; }

        
        public string TimeZone { get; set; }

        /// <summary>
        /// event type object for mapping event with event
        /// </summary>        
        [IgnoreAudit]
        public EEventType EventType { get; set; }

        /// <summary>
        /// eventschedulemethod object for mapping event with eventschedule method
        /// </summary>        
        [IgnoreAudit]
        public EEventScheduleMethod EventScheduleMethod { get; set; }

        /// <summary>
        /// event status
        /// </summary>        
        public bool Rescheduled { get; set; }

        /// <summary>
        /// event costtousehostsite 
        /// </summary>        
        public float CosttoUseHostSite { get; set; }

        /// <summary>
        /// complimentary screens used in event
        /// </summary>        
        public int ComplimentaryScreens { get; set; }

        /// <summary>
        /// fund raiser status of event
        /// </summary>        
        public bool FundRaiser { get; set; }

        /// <summary>
        /// event type
        /// </summary>        
        public string Type { get; set; }

        /// <summary>
        /// amount involved in  the event
        /// </summary>        
        public float Amount { get; set; }

        /// <summary>
        /// min patients expected to come
        /// </summary>        
        public int MinPatients { get; set; }

        /// <summary>
        /// max patients expected to come
        /// </summary>        
        public int MaxPatients { get; set; }

        /// <summary>
        /// status of communication with members
        /// </summary>        
        public bool CommunicateWithMembers { get; set; }

        /// <summary>
        /// communication mode object for mapping event with communication mode
        /// </summary>        
        
        public ECommunicationMode CommunicationMode { get; set; }

        /// <summary>
        /// seminar status of event
        /// </summary>        
        public bool DeliverSeminar { get; set; }
        
        public bool Active { get; set; }
        
        public int MarketingMaterialType { get; set; }

        [IgnoreAudit]
        public EHost Host { get; set; }

        [IgnoreAudit]
        public List<EEventCustomer> Customer { get; set; }

        
        public int CustomerCount { get; set; }

        
        public int PodTeamID { get; set; }

        [IgnoreAudit]
        public List<EEventPackage> EventPackage { get; set; }

        [IgnoreAudit]
        public List<EEventReferral> EventReferrral { get; set; }

        [IgnoreAudit]
        public List<EEventPod> EventPod { get; set; }

        
        public int SlotCount { get; set; }

        
        public int OccupiedSlotCount { get; set; }

        
        public int RegisteredCustomersCount { get; set; }

        
        public int AttendedCustomersCount { get; set; }

        
        public int OnSiteCustomersCount { get; set; }

        
        public int PaidCustomersCount { get; set; }

        
        public int UnpaidCustomersCount { get; set; }

        
        public int CancelCustomersCount { get; set; }

        
        public Int64 TotalRecord { get; set; }

        
        public Int32 IsActiveSlots { get; set; }

        
        public string PodName { get; set; }

        
        public bool IsSourceCodeApply { get; set; }

        
        public string InvitationCode { get; set; }

        public long HippaStatusYes { get; set; }
        public long HippaStatusNo { get; set; }
        public decimal AverageRevenuePerClient { get; set; }
        public int AverageRevenuePerClientCount { get; set; }
        public decimal UnPaidAmount { get; set; }
        public int AverageRevenueUnPaidCount { get; set; }

        public string DateCreated { get; set; }
        public string EventBookedBy { get; set; }

        // Events on Host - 1,
        // Events on Host Zip - 2
        // Event on Host Zip X miles - 3
        public int HostEventType { get; set; }
        public long? EventCancellationReasonId { get; set; }
    }
}

