using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IAppointmentBookedExportCsvHelper
    {
        void WriteCsv(IEnumerable<AppointmentsBookedModel> modelData, string fileName, ILogger logger);

        void WriteCsvforHourlyAppointmentBook(IEnumerable<HourlyAppointmentBookedModel> modelData, string fileName, ILogger logger);
    }
}
