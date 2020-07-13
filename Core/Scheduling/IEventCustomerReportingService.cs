using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerReportingService
    {
        ListModelBase<EventCustomerScheduleModel, CustomerScheduleModelFilter> GetCustomerScheduleModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<AppointmentsBookedModel, AppointmentsBookedListModelFilter> GetAppointmentsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<NoShowCustomerModel, NoShowCustomerModelFilter> GetNoShowCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        EventCustomerSummaryModel GetEventCustomerSummary(long eventId, long customerId);
        EventCustomerScheduleModel GetCustomerScheduleModel(long eventId);
        ListModelBase<CancelledCustomerModel, CancelledCustomerModelFilter> GetCancelledCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        EventCustomerListModel GetEventCustomerList(long eventId, EventCustomerListModelFilter filter);
        ListModelBase<CustomerExportModel, CustomerExportListModelFilter> GetCustomersForExport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<RescheduleApplointmentModel, RescheduleApplointmentListModelFilter> GetRescheduleAppointments(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        EventCustomerBrifListModel GetEventCustomerBriefList(long eventId, EventCustomerListModelFilter filter);
        bool IsCustomerScreeningTestResultExists(long eventCustomerResultId);
        ListModelBase<TestsBookedModel, TestsBookedListModelFilter> GetTestsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<PcpAppointmentViewModel, PcpAppointmentListModelFilter> GetPcpAppointment(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        IEnumerable<EventRescheduleAppointmentViewModel> GetRescheduleAppointmentsForEvent(long eventId);
        ListModelBase<MemberStatusModel, MemberStatusListModelFilter> GetMemberStatusReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<CustomerLeftWithoutScreeningModel, CustomerLeftWithoutScreeningModelFilter> GetCustomerLeftWithoutScreening(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<VoiceMailReminderModel, VoiceMailReminderModelFilter> GetVoiceMailReminderReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<TextReminderViewModel, TextReminderModelFilter> GetTextReminderReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<GapsClosureModel, GapsClosureModelFilter> GetGapsClosureReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        CorporateEventCustomerViewModel GetCorporateEventCustomerViewModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<CorporateEventCustomersModel, CorporateEventCustomerModelFilter> GetEventCustomerListModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        bool CanMarkedAsLeftWithoutScreening(long eventCustomerId);

        ListModelBase<HealthPlanGiftCertificateReportViewModel, HealthPlanGiftCertificateReportFilter> GetForHealthPlanGiftCertificateReport(int pageNumber, int pageSize, HealthPlanGiftCertificateReportFilter filter, out int totalRecords);

        IEnumerable<ShortPatientInfoViewModel> GetCustomerAppointmentList(long eventId, EventCustomerListModelFilter filter);
    }
}