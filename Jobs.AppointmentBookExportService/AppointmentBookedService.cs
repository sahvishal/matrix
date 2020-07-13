using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;

namespace Falcon.Jobs.AppointmentBookExportService
{
    partial class AppointmentBookedService : ServiceBase
    {

        private readonly ILogger _logger;

        private readonly IntervalWorkThread _pollThreadBcbsMiAppointmentBookExportDownload;
        private readonly Timer _timerBcbsMiAppointmentBookExportPollingAgent;

        private readonly IntervalWorkThread _pollThreadAnthemAppointmentBookExportDownload;
        private readonly Timer _timerAnthemAppointmentBookExportPollingAgent;

        private readonly IntervalWorkThread _pollThreadWellCareToWellmedBookExportDownload;
        private readonly Timer _timerWellCareToWellmedBookExportPollingAgent;

        public AppointmentBookedService(ISettings settings, ILogManager logManager, IBcbsMiAppointmentBookExportPollingAgent bcbsMiAppointmentBookExportPollingAgent,
            IAnthemAppointmentBookedExportPollingAgent anthemAppointmentBookedExportPollingAgent,IWellCareToWellmedAppointmentBookExportPollingAgent wellCareToWellmedAppointmentBookExportPollingAgent)
        {
            InitializeComponent();

            _logger = logManager.GetLogger("AppointmentBookedService");

            //Bcbs Mi Appointment Booked Report
            _pollThreadBcbsMiAppointmentBookExportDownload = new IntervalWorkThread(bcbsMiAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerBcbsMiAppointmentBookExportPollingAgent = new Timer(x => _pollThreadBcbsMiAppointmentBookExportDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            //Bcbs Mi Appointment Booked Report
            _pollThreadAnthemAppointmentBookExportDownload = new IntervalWorkThread(anthemAppointmentBookedExportPollingAgent.PollForAppointmentBookedReport);
            _timerAnthemAppointmentBookExportPollingAgent = new Timer(x => _pollThreadAnthemAppointmentBookExportDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            //Wellcare to Wellmed Appointment Booked Report
            _pollThreadWellCareToWellmedBookExportDownload = new IntervalWorkThread(wellCareToWellmedAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerWellCareToWellmedBookExportPollingAgent = new Timer(x => _pollThreadWellCareToWellmedBookExportDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

        }


        public void Start(string[] args)
        {
            _logger.Info("Bcbs Mi Appointment Booked Service Started");
            _pollThreadBcbsMiAppointmentBookExportDownload.Start();

            _logger.Info("Anthem Appointment Booked Service Started");
            _pollThreadAnthemAppointmentBookExportDownload.Start();

            _logger.Info("Wellcare To Wellmed Booked Service Started");
            _pollThreadWellCareToWellmedBookExportDownload.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Bcbs Mi Appointment Booked Service Stopping..");
            _timerBcbsMiAppointmentBookExportPollingAgent.Dispose();
            _pollThreadBcbsMiAppointmentBookExportDownload.Stop();

            _logger.Info("Anthem Appointment Booked Service Stopping..");
            _timerAnthemAppointmentBookExportPollingAgent.Dispose();
            _pollThreadAnthemAppointmentBookExportDownload.Stop();

            _logger.Info("Wellcare To Wellmed Booked Service Stopping..");
            _timerWellCareToWellmedBookExportPollingAgent.Dispose();
            _pollThreadWellCareToWellmedBookExportDownload.Stop();
        }

        private static TimeSpan GetDueTime(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddDays(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;

            return dt - DateTime.Now;
        }
    }
}
