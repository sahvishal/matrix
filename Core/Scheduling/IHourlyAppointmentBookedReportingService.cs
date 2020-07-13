using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IHourlyAppointmentBookedReportingService
    {
        ListModelBase<HourlyAppointmentBookedModel, HourlyAppointmentsBookedListModelFilter> GetHourlyAppointmentsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}