using System.Configuration;

namespace Falcon.App.Core.Application.Enum
{
    public sealed class RequestSubcriberChannelNames
    {
        public RequestSubcriberChannelNames()
        { }

        static readonly string ChannelQueuePrefix = ConfigurationManager.AppSettings.Get("RedisChannelQueuePrefix");

        //User
        public static string GenerateCustomerEventCriticalDataChannel = ChannelQueuePrefix + "_" + "GenerateCustomerEventCriticalDataChannel";
        public static string GenerateCustomerEventCriticalDataQueue = ChannelQueuePrefix + "_" + "GenerateCustomerEventCriticalDataQueue";

        //Sales
        public static string GenerateHospitalPartnerCustomerReportChannel = ChannelQueuePrefix + "_" + "GenerateHospitalPartnerCustomerReportChannel";
        public static string GenerateHospitalPartnerCustomerReportQueue = ChannelQueuePrefix + "_" + "GenerateHospitalPartnerCustomerReportQueue";

        public static string GenerateHospitalPartnerEventReportChannel = ChannelQueuePrefix + "_" + "GenerateHospitalPartnerEventReportChannel";
        public static string GenerateHospitalPartnerEventReportQueue = ChannelQueuePrefix + "_" + "GenerateHospitalPartnerEventReportQueue";

        //Operation

        public static string CdImageStatusQueue = ChannelQueuePrefix + "_" + "CdImageStatusQueue";
        public static string CdImageStatusChannel = ChannelQueuePrefix + "_" + "CdImageStatusChannel";

        // Scheduling 

        public static string GenerateAppointmentBookedReportChannel = ChannelQueuePrefix + "_" + "GenerateAppointmentBookedReportChannel";
        public static string GenerateAppointmentBookedReportQueue = ChannelQueuePrefix + "_" + "GenerateAppointmentBookedReportQueue";

        public static string GenerateCancelledCustomerReportChannel = ChannelQueuePrefix + "_" + "GenerateCancelledCustomerReportChannel";
        public static string GenerateCancelledCustomerReportQueue = ChannelQueuePrefix + "_" + "GenerateCancelledCustomerReportQueue";

        public static string GeneratePublicEventVolumeReportChannel = ChannelQueuePrefix + "_" + "GeneratePublicEventVolumeReportChannel";
        public static string GeneratePublicEventVolumeReportQueue = ChannelQueuePrefix + "_" + "GeneratePublicEventVolumeReportQueue";

        public static string GenerateCorporateEventVolumeReportChannel = ChannelQueuePrefix + "_" + "GenerateCorporateEventVolumeReportChannel";
        public static string GenerateCorporateEventVolumeReportQueue = ChannelQueuePrefix + "_" + "GenerateCorporateEventVolumeReportQueue";

        public static string GenerateCustomerScheduleReportChannel = ChannelQueuePrefix + "_" + "GenerateCustomerScheduleReportChannel";
        public static string GenerateCustomerScheduleReportQueue = ChannelQueuePrefix + "_" + "GenerateCustomerScheduleReportQueue";

        public static string NoShowCustomerQueue = ChannelQueuePrefix + "_" + "NoShowCustomerQueue";
        public static string NoShowCustomerChannel = ChannelQueuePrefix + "_" + "NoShowCustomerChannel";

        public static string CustomerExportQueue = ChannelQueuePrefix + "_" + "CustomerExportQueue";
        public static string CustomerExportChannel = ChannelQueuePrefix + "_" + "CustomerExportChannel";

        public static string RescheduleAppointmentQueue = ChannelQueuePrefix + "_" + "RescheduleAppointmentQueue";
        public static string RescheduleAppointmentChannel = ChannelQueuePrefix + "_" + "RescheduleAppointmentChannel";

        public static string EventCancelationQueue = ChannelQueuePrefix + "_" + "EventCancelationQueue";
        public static string EventCancelationChannel = ChannelQueuePrefix + "_" + "EventCancelationChannel";

        public static string TestBookedQueue = ChannelQueuePrefix + "_" + "TestBookedQueue";
        public static string TestBookedChannel = ChannelQueuePrefix + "_" + "TestBookedChannel";

        public static string PcpAppointmentDispositionQueue = ChannelQueuePrefix + "_" + "PcpAppointmentDispositionQueue";
        public static string PcpAppointmentDispositionChannel = ChannelQueuePrefix + "_" + "PcpAppointmentDispositionChannel";

        public static string GenerateClientEventVolumeReportChannel = ChannelQueuePrefix + "_" + "GenerateClientEventVolumeReportChannel";
        public static string GenerateClientEventVolumeReportQueue = ChannelQueuePrefix + "_" + "GenerateClientEventVolumeReportQueue";

        public static string MemberStatusReportQueue = ChannelQueuePrefix + "_" + "MemberStatusReportQueue";
        public static string MemberStatusReportChannel = ChannelQueuePrefix + "_" + "MemberStatusReportChannel";

        public static string DailyVolumeReportQueue = ChannelQueuePrefix + "_" + "DailyVolumeReportQueue";
        public static string DailyVolumeReportChannel = ChannelQueuePrefix + "_" + "DailyVolumeReportChannel";

        public static string CustomerLeftWithoutScreeningQueue = ChannelQueuePrefix + "_" + "CustomerLeftWithoutScreeningQueue";
        public static string CustomerLeftWithoutScreeningChannel = ChannelQueuePrefix + "_" + "CustomerLeftWithoutScreeningChannel";

        public static string VoiceMailReminderQueue = ChannelQueuePrefix + "_" + "VoiceMailReminderQueue";
        public static string VoiceMailReminderChannel = ChannelQueuePrefix + "_" + "VoiceMailReminderChannel";

        public static string TextReminderQueue = ChannelQueuePrefix + "_" + "TextReminderQueue";
        public static string TextReminderChannel = ChannelQueuePrefix + "_" + "TextReminderChannel";

        public static string CorporateEventCustomersQueue = ChannelQueuePrefix + "_" + "CorporateEventCustomersQueue";
        public static string CorporateEventCustomersChannel = ChannelQueuePrefix + "_" + "CorporateEventCustomersChannel";

        public static string PcpTrackingReportQueue = ChannelQueuePrefix + "_" + "PcpTrackingReportQueue";
        public static string PcpTrackingReportChannel = ChannelQueuePrefix + "_" + "PcpTrackingReportChannel";

        //Marketing 
        public static string GenerateAbandonedProspectCustomerReportChannel = ChannelQueuePrefix + "_" + "GenerateAbandonedProspectCustomerReportChannel";
        public static string GenerateAbandonedProspectCustomerReportQueue = ChannelQueuePrefix + "_" + "GenerateAbandonedProspectCustomerReportQueue";

        //Call Center
        public static string CallQueueReportQueue = ChannelQueuePrefix + "_" + "CallQueueReportQueue";
        public static string CallQueueReportChannel = ChannelQueuePrefix + "_" + "CallQueueReportChannel";

        public static string OutreachCallReportChannel = ChannelQueuePrefix + "_" + "OutreachCallReportReportChannel";
        public static string OutreachCallReportQueue = ChannelQueuePrefix + "_" + "OutreachCallReportQueue";

        public static string UncontactedCustomersReportChannel = ChannelQueuePrefix + "_" + "UncontactedCustomersReportChannel";
        public static string UncontactedCustomersReportQueue = ChannelQueuePrefix + "_" + "UncontactedCustomersReportQueue";

        public static string CallQueueSchedulingReportQueue = ChannelQueuePrefix + "_" + "CallQueueSchedulingReportQueue";
        public static string CallQueueSchedulingReportChannel = ChannelQueuePrefix + "_" + "CallQueueSchedulingReportChannel";

        public static string CallQueueExcludedCustomerReportChannel = ChannelQueuePrefix + "_" + "CallQueueExcludedCustomerReportChannel";
        public static string CallQueueExcludedCustomerReportQueue = ChannelQueuePrefix + "_" + "CallQueueExcludedCustomerReportQueue";

        public static string AgentConversionReportChannel = ChannelQueuePrefix + "_" + "AgentConversionReportChannel";
        public static string AgentConversionReportQueue = ChannelQueuePrefix + "_" + "AgentConversionReportQueue";

        public static string CallQueueCustomersReportChannel = ChannelQueuePrefix + "_" + "CallQueueCustomersReportChannel";
        public static string CallQueueCustomersReportQueue = ChannelQueuePrefix + "_" + "CallQueueCustomersReportQueue";

        public static string CustomerWithNoEventsInAreaReportChannel = ChannelQueuePrefix + "_" + "CustomerWithNoEventsInAreaReportChannel";
        public static string CustomerWithNoEventsInAreaReportQueue = ChannelQueuePrefix + "_" + "CustomerWithNoEventsInAreaReportQueue";

        public static string CallCenterCallReportChannel = ChannelQueuePrefix + "_" + "CallCenterCallReportChannel";
        public static string CallCenterCallReportQueue = ChannelQueuePrefix + "_" + "CallCenterCallReportQueue";

        public static string ConfirmationReportChannel = ChannelQueuePrefix + "_" + "ConfirmationReportChannel";
        public static string ConfirmationReportQueue = ChannelQueuePrefix + "_" + "ConfirmationReportQueue";

        public static string CallSkippedReportChannel = ChannelQueuePrefix + "_" + "CallSkippedReportChannel";
        public static string CallSkippedReportQueue = ChannelQueuePrefix + "_" + "CallSkippedReportQueue";

        public static string ExcludedCustomerReportChannel = ChannelQueuePrefix + "_" + "ExcludedCustomerReportChannel";
        public static string ExcludedCustomerReportQueue = ChannelQueuePrefix + "_" + "ExcludedCustomerReportQueue";

        public static string PreAssessmentReportChannel = ChannelQueuePrefix + "_" + "PreAssessmentReportChannel";
        public static string PreAssessmentReportQueue = ChannelQueuePrefix + "_" + "PreAssessmentReportQueue";

        //Movie MAker

        public static string GenerateMpegRequestChannel = ChannelQueuePrefix + "_" + "GenerateMpegRequestChannel";
        public static string GenerateMpegRequestQueue = ChannelQueuePrefix + "_" + "GenerateMpegRequestQueue";

        public static string MoviefromAviRequestChannel = ChannelQueuePrefix + "_" + "MoviefromAviRequestChannel";
        public static string MoviefromAviRequestQueue = ChannelQueuePrefix + "_" + "MoviefromAviRequestQueue";
        //SVG 


        public static string ConvertSvgRequestChannel = ChannelQueuePrefix + "_" + "ConvertSvgRequestChannel";
        public static string ConvertSvgRequestQueue = ChannelQueuePrefix + "_" + "ConvertSvgRequestQueue";

        //Pdf Generator
        public static string GeneratePdfRequestChannel = ChannelQueuePrefix + "_" + "GeneratePdfRequestChannel";
        public static string GeneratePdfRequestQueue = ChannelQueuePrefix + "_" + "GeneratePdfRequestQueue";


        public static string HtmlStreamPdfRequestChannel = ChannelQueuePrefix + "_" + "HtmlStreamPdfRequestChannel";
        public static string HtmlStreamPdfRequestQueue = ChannelQueuePrefix + "_" + "HtmlStreamPdfRequestQueue";

        //Medical

        public static string GenerateTechnicalLimitedScreeningReportChannel = ChannelQueuePrefix + "_" + "GenerateTechnicalLimitedScreeningReportChannel";
        public static string GenerateTechnicalLimitedScreeningReportQueue = ChannelQueuePrefix + "_" + "GenerateTechnicalLimitedScreeningReportQueue";

        public static string GenerateCustomerEventCriticalDataReportChannel = ChannelQueuePrefix + "_" + "GenerateCustomerEventCriticalDataReportChannel";
        public static string GenerateCustomerEventCriticalDataReportQueue = ChannelQueuePrefix + "_" + "GenerateCustomerEventCriticalDataReportQueue";

        public static string GeneratePhysicianTestReviewReportChannel = ChannelQueuePrefix + "_" + "GeneratePhysicianTestReviewReportChannel";
        public static string GeneratePhysicianTestReviewReportQueue = ChannelQueuePrefix + "_" + "GeneratePhysicianTestReviewReportQueue";

        public static string PhysicianReviewSummaryQueue = ChannelQueuePrefix + "_" + "PhysicianReviewSummaryQueue";
        public static string PhysicianReviewSummaryChannel = ChannelQueuePrefix + "_" + "PhysicianReviewSummaryChannel";

        public static string PhysicianReviewQueue = ChannelQueuePrefix + "_" + "PhysicianReviewQueue";
        public static string PhysicianReviewChannel = ChannelQueuePrefix + "_" + "PhysicianReviewChannel";

        public static string PhysicianQueueQueue = ChannelQueuePrefix + "_" + "PhysicianQueueQueue";
        public static string PhysicianQueueChannel = ChannelQueuePrefix + "_" + "PhysicianQueueChannel";

        public static string PhysicianEventQueueQueue = ChannelQueuePrefix + "_" + "PhysicianEventQueueQueue";
        public static string PhysicianEventQueueChannel = ChannelQueuePrefix + "_" + "PhysicianEventQueueChannel";

        public static string TestPerformedQueue = ChannelQueuePrefix + "_" + "TestPerformedQueue";
        public static string TestPerformedChannel = ChannelQueuePrefix + "_" + "TestPerformedChannel";

        public static string TestNotPerformedQueue = ChannelQueuePrefix + "_" + "TestNotPerformedQueue";
        public static string TestNotPerformedChannel = ChannelQueuePrefix + "_" + "TestNotPerformedChannel";

        public static string KynCustomersQueue = ChannelQueuePrefix + "_" + "KynCustomersQueue";
        public static string KynCustomersChannel = ChannelQueuePrefix + "_" + "KynCustomersChannel";

        public static string GapsClosureReportQueue = ChannelQueuePrefix + "_" + "GapsClosureReportQueue";
        public static string GapsClosureReportChannel = ChannelQueuePrefix + "_" + "GapsClosureReportChannel";

        //Finance

        public static string GenerateShippingRevenueDetailReportChannel = ChannelQueuePrefix + "_" + "GenerateShippingRevenueDetailReportChannel";
        public static string GenerateShippingRevenueDetailReportQueue = ChannelQueuePrefix + "_" + "GenerateShippingRevenueDetailReportQueue";

        public static string GenerateDeferredRevenueReportChannel = ChannelQueuePrefix + "_" + "GenerateDeferredRevenueReportChannel";
        public static string GenerateDeferredRevenueReportQueue = ChannelQueuePrefix + "_" + "GenerateDeferredRevenueReportQueue";

        public static string GenerateInsurancePaymentReportChannel = ChannelQueuePrefix + "_" + "GenerateInsurancePaymentReportChannel";
        public static string GenerateInsurancePaymentReportQueue = ChannelQueuePrefix + "_" + "GenerateInsurancePaymentReportQueue";

        public static string DetailOpenOrderQueue = ChannelQueuePrefix + "_" + "DetailOpenOrderQueue";
        public static string DetailOpenOrderChannel = ChannelQueuePrefix + "_" + "DetailOpenOrderChannel";

        public static string UpsellQueue = ChannelQueuePrefix + "_" + "UpsellQueue";
        public static string UpsellChannel = ChannelQueuePrefix + "_" + "UpsellChannel";

        public static string CreditCardReconsileQueue = ChannelQueuePrefix + "_" + "CreditCardReconsileQueue";
        public static string CreditCardReconsileChannel = ChannelQueuePrefix + "_" + "CreditCardReconsileChannel";

        public static string DailyRecapQueue = ChannelQueuePrefix + "_" + "DailyRecapQueue";
        public static string DailyRecapChannel = ChannelQueuePrefix + "_" + "DailyRecapChannel";

        public static string ShippingRevenueSummaryQueue = ChannelQueuePrefix + "_" + "ShippingRevenueSummaryQueue";
        public static string ShippingRevenueSummaryChannel = ChannelQueuePrefix + "_" + "ShippingRevenueSummaryChannel";

        public static string CustomerOpenOrderQueue = ChannelQueuePrefix + "_" + "CustomerOpenOrderQueue";
        public static string CustomerOpenOrderChannel = ChannelQueuePrefix + "_" + "CustomerOpenOrderChannel";

        public static string CorporateInvoiceQueue = ChannelQueuePrefix + "_" + "CorporateInvoiceQueue";
        public static string CorporateInvoiceChannel = ChannelQueuePrefix + "_" + "CorporateInvoiceChannel";

        public static string RefundRequestQueue = ChannelQueuePrefix + "_" + "RefundRequestQueue";
        public static string RefundRequestChannel = ChannelQueuePrefix + "_" + "RefundRequestChannel";

        public static string DailyRecapCustomerQueue = ChannelQueuePrefix + "_" + "DailyRecapCustomerQueue";
        public static string DailyRecapCustomerChannel = ChannelQueuePrefix + "_" + "DailyRecapCustomerChannel";

        public static string EventReportQueue = ChannelQueuePrefix + "_" + "EventReportQueue";
        public static string EventReportChannel = ChannelQueuePrefix + "_" + "EventReportChannel";

        public static string GiftCertificateQueue = ChannelQueuePrefix + "_" + "GiftCertificateQueue";
        public static string GiftCertificateChannel = ChannelQueuePrefix + "_" + "GiftCertificateChannel";

        public static string EventArchiveStatsQueue = ChannelQueuePrefix + "_" + "EventArchiveStatsQueue";
        public static string EventArchiveStatsChannel = ChannelQueuePrefix + "_" + "EventArchiveStatsChannel";

        public static string PayPeriodAppointmentBookedQueue = ChannelQueuePrefix + "_" + "PayPeriodAppointmentBookedQueue";
        public static string PayPeriodAppointmentBookedChannel = ChannelQueuePrefix + "_" + "PayPeriodAppointmentBookedChannel";

        public static string CallCenterBonusQueue = ChannelQueuePrefix + "_" + "CallCenterBonusQueue";
        public static string CallCenterBonusChannel = ChannelQueuePrefix + "_" + "CallCenterBonusChannel";

        public static string AppointmentsShowedQueue = ChannelQueuePrefix + "_" + "AppointmentsShowedQueue";
        public static string AppointmentsShowedChannel = ChannelQueuePrefix + "_" + "AppointmentsShowedChannel";


        public static string ActualCustomerShowedQueue = ChannelQueuePrefix + "_" + "ActualCustomerShowedQueue";
        public static string ActualCustomerShowedChannel = ChannelQueuePrefix + "_" + "ActualCustomerShowedChannel";

        public static string CallQueueCustomerUpdateCustomerFlagQueue = ChannelQueuePrefix + "_" + "CallQueueCustomerUpdateCustomerFlagQueue";
        public static string CallQueueCustomerUpdateCustomerFlagChannel = ChannelQueuePrefix + "_" + "CallQueueCustomerUpdateCustomerFlagChannel";

        public static string CallQueueCustomerUpdateAppointmentFlagQueue = ChannelQueuePrefix + "_" + "CallQueueCustomerUpdateAppointmentFlagQueue";
        public static string CallQueueCustomerUpdateAppointmentFlagChannel = ChannelQueuePrefix + "_" + "CallQueueCustomerUpdateAppointmentFlagChannel";

        public static string CallQueueCustomerUpdateCancellationFlagQueue = ChannelQueuePrefix + "_" + "CallQueueCustomerUpdateCancellationFlagQueue";
        public static string CallQueueCustomerUpdateCancellationFlagChannel = ChannelQueuePrefix + "_" + "CallQueueCustomerUpdateCancellationFlagChannel";

        public static string StaffEventAssignmentExportQueue = ChannelQueuePrefix + "_" + "StaffEventAssignmentExportQueue";
        public static string StaffEventAssignmentExportChannel = ChannelQueuePrefix + "_" + "StaffEventAssignmentExportChannel";

        public static string GenerateBulkHafQueue = ChannelQueuePrefix + "_" + "GenerateBulkHafQueue";
        public static string GenerateBulkHafChannel = ChannelQueuePrefix + "_" + "GenerateBulkHafChannel";

        public static string DisqualifiedTestReportQueue = ChannelQueuePrefix + "_" + "DisqualifiedTestReportQueue";
        public static string DisqualifiedTestReportChannel = ChannelQueuePrefix + "_" + "DisqualifiedTestReportChannel";

        public static string MemberTermByAbsenceQueue = ChannelQueuePrefix + "_" + "MemberTermByAbsenceQueue";
        public static string MemberTermByAbsenceChannel = ChannelQueuePrefix + "_" + "MemberTermByAbsenceChannel";

        public static string IpCopyMediaFilesQueue = ChannelQueuePrefix + "_" + "IpCopyMediaFilesQueue";
        public static string IpCopyMediaFilesChannel = ChannelQueuePrefix + "_" + "IpCopyMediaFilesChannel";

        //public static string FOCAttestationScanDocumentMediaFileQueue = ChannelQueuePrefix + "_" + "FOCAttestationScanDocumentMediaFileQueue";
        //public static string FOCAttestationScanDocumentMediaFileChannel = ChannelQueuePrefix + "_" + "FOCAttestationScanDocumentMediaFileChannel";
    }
}
