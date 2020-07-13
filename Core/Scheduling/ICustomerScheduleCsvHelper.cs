using System.Collections.Generic;
using System.Text;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerScheduleCsvHelper
    {
        StringBuilder GetPatientScheduledReport(IEnumerable<EventCustomerScheduleModel> modelData, CSVExporter<CustomerScheduleModel> exporter);
    }
}