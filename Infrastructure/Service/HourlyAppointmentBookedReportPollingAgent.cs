using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class HourlyAppointmentBookedReportPollingAgent : IHourlyAppointmentBookedReportPollingAgent
    {
        private readonly ISettings _settings;
        private readonly IHourlyAppointmentBookedReportingService _hourlyAppointmentBookedReportingService;
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;
        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly ILogger _logger;

        public HourlyAppointmentBookedReportPollingAgent(ISettings settings, ILogManager logManager,
            IHourlyAppointmentBookedReportingService hourlyAppointmentBookedReportingService,
            IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory)
        {
            _settings = settings;
            _hourlyAppointmentBookedReportingService = hourlyAppointmentBookedReportingService;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;
            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _logger = logManager.GetLogger("HourlyAppointmentBookedReportPollingAgent");
        }

        public void PollForHourlyReport()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                _logger.Info(string.Format("Time of Date {0}", timeOfDay));

                if (timeOfDay.TimeOfDay > new TimeSpan(_settings.HourlyAppointmentBookedStartTime, 0, 0))
                {
                    timeOfDay = timeOfDay.AddMinutes(10);
                    var filter = new HourlyAppointmentsBookedListModelFilter
                    {
                        FromDate = timeOfDay.Date,
                        ToDate = DateTime.Now,
                        ShowCustomersWithAppointment = true
                    };
                    if (DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.HourlyAppointmentBookedDownloadPath))
                    {
                        try
                        {
                            var files = DirectoryOperationsHelper.GetFiles(_settings.HourlyAppointmentBookedDownloadPath, string.Format("HourlyAppointmentBookedReport_{0}*.csv", timeOfDay.ToString("yyyyMMdd")));
                            foreach (var file in files)
                            {
                                DirectoryOperationsHelper.DeleteFileIfExist(file);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("some error occurred while deleting Hourly Report");
                            _logger.Error(string.Format("Message: {0}", ex.Message));
                            _logger.Error(string.Format("Stack Trace: {0}", ex.StackTrace));
                        }


                        var hourlyReport = Path.Combine(_settings.HourlyAppointmentBookedDownloadPath, string.Format("HourlyAppointmentBookedReport_{0}.csv", timeOfDay.ToString("yyyyMMddHHmm")));
                        HourlyAppointmentsBooked(filter, hourlyReport);

                        var notificationModel = _emailNotificationModelsFactory.GetHourlyAppointmentBookedReportNotificationViewModel("AppointmentBookedReport", hourlyReport);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.HourlyNotificationAppointmentBookedReport, EmailTemplateAlias.HourlyNotificationAppointmentBookedReport, notificationModel, 0, 1, "Hourly Appointment Booked Report");
                    }
                }
                else
                {
                    _logger.Info(string.Format("Hourly AppointmentBooked Report Service can not be Run as it is restricted Time {0}", timeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("some error occurred while generating Hourly Report");
                _logger.Error(string.Format("Message: {0}", ex.Message));
                _logger.Error(string.Format("Stack Trace: {0}", ex.StackTrace));
            }
        }

        private void HourlyAppointmentsBooked(HourlyAppointmentsBookedListModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<HourlyAppointmentBookedModel>();

            while (true)
            {
                int totalRecords;
                var model = _hourlyAppointmentBookedReportingService.GetHourlyAppointmentsBooked(pageNumber, pageSize, filter, out totalRecords);

                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            //if (list.Any())
            _appointmentBookedExportCsvHelper.WriteCsvforHourlyAppointmentBook(list, destinationPath, _logger);
        }

    }
}