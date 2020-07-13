
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using System.Collections.Generic;
namespace Falcon.App.Core.Scheduling
{
    public interface IAppointmentBookedReportingService
    {
        IEnumerable<AppointmentBookedChartViewModel> GetAppointmentBookedChartForLastSevenDays(AppointmentBookedChartStatus appointmentBookedType);
    }
}
