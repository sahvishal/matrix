using System.ComponentModel;
namespace Falcon.App.Core.Operations.Enum
{
    public enum ExportableReportType
    {
        [Description("Appointments Booked")]
        AppointmentsBooked = 1,

        [Description("Customer Schedule")]
        CustomerSchedule = 2,

        //[Description("Event Volume (Retail Events)")]
        //EventVolumeRetailEvents = 3,

        //[Description("Event Volume (Corporate Events)")]
        //EventVolumeCorporateEvents = 4,

        //[Description("Event Volume (Health Plan)")]
        //EventVolumeHealthPlan = 5,

        //[Description("No Show Customers")]
        //NoShowCustomers = 6,

        //[Description("Canceled Customer")]
        //CanceledCustomer = 7,

        [Description("Customer Export")]
        CustomerExport = 8,

        //[Description("Reschedule Appointment")]
        //RescheduleAppointment = 9,

        //[Description("Event Cancelation")]
        //EventCancelation = 10,

        [Description("Test Booked")]
        TestBooked = 11,

        //[Description("PCP Appointment Disposition")]
        //PcpAppointmentDisposition = 12,

        //[Description("Manage Customer Prospects")]
        //ManageCustomerProspects = 13,

        //[Description("Call Queue Report")]
        //CallQueueReport = 14,

        [Description("Outreach Call Report")]
        OutreachCallReport = 15,

        //[Description("Uncontacted Customers")]
        //UncontactedCustomers = 16,

        //[Description("Product Shipping Status")]
        //ProductShippingStatus = 17,

        //[Description("Critical/Urgent Management")]
        //CriticalUrgentManagement = 18,

        //[Description("Technical Limited Screening")]
        //TechnicalLimitedScreening = 19,

        [Description("Test Performed")]
        TestPerformed = 20,

        //[Description(@"Customer KYN\HAF Report")]
        //CustomerKynHafReport = 21,

        //[Description("Detail Open Order")]
        //DetailOpenOrder = 22,

        //[Description("Upgrade/Downgrade")]
        //UpgradeDowngrade = 23,

        //[Description("Daily Recap (Event)")]
        //DailyRecapEvent = 24,

        //[Description("Daily Recap (Customer)")]
        //DailyRecapCustomer = 25,

        //[Description("Credit Card Reconcilation")]
        //CreditCardReconcilation = 26,

        //[Description("Deferred Revenue")]
        //DeferredRevenue = 27,

        //[Description("Shipping Revenue Summary")]
        //ShippingRevenueSummary = 28,

        //[Description("Corporate Invoice")]
        //CorporateInvoice = 29,

        //[Description("Refund Requests")]
        //RefundRequests = 30,

        //[Description("Manage System Users")]
        //ManageSystemUsers = 31,

        [Description("Health Plan Member Status Report")]
        MemberStatusReport = 32,

        [Description("Test Not Performed")]
        TestNotPerformed = 33,

        [Description("Gaps Closure")]
        GapsClosure = 34,

        [Description("Event Report")]
        EventReport = 35,

        [Description("Gift Certificate")]
        GiftCertificate = 36,

        [Description("Event Archive Stats")]
        EventArchiveStats = 37,

        [Description("Call Queue Scheduling Report")]
        CallQueueSchedulingReport = 38,

        [Description("Call Queue Excluded Customer Report")]
        CallQueueExcludedCustomerReport = 39,

        [Description("Call Queue Customer Report")]
        CallQueueCustomerReport = 40,

        [Description("Customer With No Events In Area Report")]
        CustomerWithNoEventsInAreaReport = 41,

        [Description("Call Center Call Report")]
        CallCenterCallReport = 42,

        [Description("Confirmation Report")]
        ConfirmationReport = 43,

        [Description("Call Skipped Report")]
        CallSkippedReport = 44,

        [Description("PCP Tracking Report")]
        PcpTrackingReport = 45,

        [Description("Excluded Customer Report")]
        ExcludedCustomerReport = 46,

        [Description("Disqualified Test Report")]
        DisqualifiedTestReport = 47,
        
        [Description("PreAssessment Report")]
        PreAssessmentReport = 48,
    }
}
