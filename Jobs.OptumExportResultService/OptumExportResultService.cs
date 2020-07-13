using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Finance;

namespace Falcon.Jobs.OptumExportResultService
{
    partial class OptumExportResultService : ServiceBase
    {
        private readonly ILogger _logger;

        private readonly IntervalWorkThread _pollThreadOptumResultPdfDownload;
        private readonly Timer _timerOptumResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadOptumResultExportDownload;
        private readonly Timer _timerOptumResultExportDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadOptumAppointmentBookedDownload;
        private readonly Timer _timerOptumAppointmentBookedDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadOptumZipCreationPollingAgent;
        private readonly Timer _timerOptumZipCreationPollingAgent;

        private readonly IntervalWorkThread _pollThreadAppointmentEncounterPollingAgent;
        private readonly Timer _timerAppointmentEncounterPollingAgent;

        private readonly IntervalWorkThread _pollThreadGiftCertificateOptumPollingAgent;
        private readonly Timer _timerGiftCertificateOptumPollingAgent;


        public OptumExportResultService(ISettings settings, ILogManager logManager, IOptumResultPdfDownloadPollingAgent optumResultPdfDownloadPollingAgent, IOptumResultExportService optumResultExportService,
            IOptumAppointmentBookExportPollingAgent optumAppointmentBookExportPollingAgent, IOptumResultZipCreationPollingAgent optumResultZipCreationPollingAgent, IAppointmentEncounterPollingAgent appointmentEncounterPollingAgent,
            IGiftCertificateOptumPollingAgent giftCertificateOptumPollingAgent)
        {

            InitializeComponent();

            _logger = logManager.GetLogger<OptumExportResultService>();

            //Optum - result PDF export
            _pollThreadOptumResultPdfDownload = new IntervalWorkThread(optumResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerOptumResultPdfDownloadPollingAgent = new Timer(x => _pollThreadOptumResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //Optum  - result Export
            _pollThreadOptumResultExportDownload = new IntervalWorkThread(optumResultExportService.ResultExport);
            _timerOptumResultExportDownloadPollingAgent = new Timer(x => _pollThreadOptumResultExportDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));

            //Optum  - result Export
            _pollThreadOptumAppointmentBookedDownload = new IntervalWorkThread(optumAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerOptumAppointmentBookedDownloadPollingAgent = new Timer(x => _pollThreadOptumAppointmentBookedDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            //Optum  - Zip Creator Export
            _pollThreadOptumZipCreationPollingAgent = new IntervalWorkThread(optumResultZipCreationPollingAgent.CreateZipFile);
            _timerOptumZipCreationPollingAgent = new Timer(x => _pollThreadOptumZipCreationPollingAgent.Trigger(), new object(), GetDueTime(settings.OptumZipScheduledTime), new TimeSpan(0, settings.OptumZipScheduledInterval, 0, 0));

            //Optum  - NV Encounter Creator Export
            _pollThreadAppointmentEncounterPollingAgent = new IntervalWorkThread(appointmentEncounterPollingAgent.PollForAppointmentEncounterData);
            _timerAppointmentEncounterPollingAgent = new Timer(x => _pollThreadAppointmentEncounterPollingAgent.Trigger(), new object(), GetDueTime(settings.AppointmentEncounterScheduleTime), new TimeSpan(0, settings.AppointmentEncounterIntervalHours, 0, 0));

            //Optum  - Gift Certificate Optum 
            _pollThreadGiftCertificateOptumPollingAgent = new IntervalWorkThread(giftCertificateOptumPollingAgent.PollGiftCertificateOptumReport);
            _timerGiftCertificateOptumPollingAgent = new Timer(x => _pollThreadGiftCertificateOptumPollingAgent.Trigger(), new object(), GetDueTime(settings.GiftCerificateOptumScheduledTime), new TimeSpan(0, settings.GiftCerificateOptumScheduledInterval, 0, 0));
        }

        private static TimeSpan GetDueTime(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddDays(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;

            return dt - DateTime.Now;
        }

        public void Start(string[] args)
        {
            _logger.Info("Export Service Started");

            _logger.Info("Starting Optum Result Pdf Polling Agent");
            _pollThreadOptumResultPdfDownload.Start();

            _logger.Info("Starting Optum Result Export Polling Agent");
            _pollThreadOptumResultExportDownload.Start();

            _logger.Info("Starting Optum Appointment Booked Polling Agent");
            _pollThreadOptumAppointmentBookedDownload.Start();

            _logger.Info("Starting Optum Zip Creator Polling Agent");
            _pollThreadOptumZipCreationPollingAgent.Start();

            _logger.Info("Starting Appointment Encounter Polling Agent");
            _pollThreadAppointmentEncounterPollingAgent.Start();

            _logger.Info("Starting Gift Certificate Optum Polling Agent");
            _pollThreadGiftCertificateOptumPollingAgent.Start();
        }
        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Optum Result Pdf Polling Agent");
            _timerOptumResultPdfDownloadPollingAgent.Dispose();
            _pollThreadOptumResultPdfDownload.Stop();

            _logger.Info("Stopping Optum Result EXportPolling Agent");
            _timerOptumResultExportDownloadPollingAgent.Dispose();
            _pollThreadOptumResultExportDownload.Stop();

            _logger.Info("Stopping Optum Appointment Booked Polling Agent");
            _timerOptumAppointmentBookedDownloadPollingAgent.Dispose();
            _pollThreadOptumAppointmentBookedDownload.Stop();

            _logger.Info("Stopping Optum Zip Creator Polling Agent");
            _timerOptumZipCreationPollingAgent.Dispose();
            _pollThreadOptumZipCreationPollingAgent.Stop();

            _logger.Info("stopping Appointment Encounter Polling Agent");
            _timerAppointmentEncounterPollingAgent.Dispose();
            _pollThreadAppointmentEncounterPollingAgent.Stop();

            _logger.Info("stopping Gift Certificate Optum Polling Agent");
            _timerGiftCertificateOptumPollingAgent.Dispose();
            _pollThreadGiftCertificateOptumPollingAgent.Stop();
        }
    }
}
