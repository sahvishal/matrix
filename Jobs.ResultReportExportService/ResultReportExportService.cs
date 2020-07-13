using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;

namespace Falcon.Jobs.ResultReportExportService
{
    partial class ResultReportExportService : ServiceBase
    {

        private readonly ILogger _logger;

        private readonly IntervalWorkThread _pollThreadBcbsMiResultExportDownload;
        private readonly Timer _timerBcbsMiResultPollingAgent;

        private readonly IntervalWorkThread _pollThreadAnthemResultExportDownload;
        private readonly Timer _timerAnthemResultPollingAgent;

        public ResultReportExportService(ISettings settings, ILogManager logManager, IBcbsMiResultExportService bcbsMiResultExportService,IAnthemResultExportService anthemResultExportService)
        {
            InitializeComponent();
            _logger = logManager.GetLogger("ResultReportExportService");

            //Bcbs Mi Result Export  Report
            _pollThreadBcbsMiResultExportDownload = new IntervalWorkThread(bcbsMiResultExportService.ResultExport);
            _timerBcbsMiResultPollingAgent = new Timer(x => _pollThreadBcbsMiResultExportDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));
            
            //Anthem Result Export  Report
            _pollThreadAnthemResultExportDownload = new IntervalWorkThread(anthemResultExportService.ResultExport);
            _timerAnthemResultPollingAgent = new Timer(x => _pollThreadAnthemResultExportDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));

        }

        public void Start(string[] args)
        {
            _logger.Info("Bcbs Mi Result Export Service Started");
            _pollThreadBcbsMiResultExportDownload.Start();

            _logger.Info("Anthem Result Export Service Started");
            _pollThreadAnthemResultExportDownload.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Bcbs Mi Result Export Service Stopping..");
            _timerBcbsMiResultPollingAgent.Dispose();
            _pollThreadBcbsMiResultExportDownload.Stop();

            _logger.Info("Anthem Result Export Service Stopping..");
            _timerAnthemResultPollingAgent.Dispose();
            _pollThreadAnthemResultExportDownload.Stop();
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
