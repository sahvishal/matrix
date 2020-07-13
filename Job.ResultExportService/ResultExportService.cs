using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;

namespace Falcon.Job.ResultExportService
{
    partial class ResultExportService : ServiceBase
    {
        private readonly ILogger _logger;

        private readonly IntervalWorkThread _pollThreadBcbsScResultPdfDownload;
        private readonly Timer _timerBcbsScResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadHealthNowResultPdfDownloadPollingAgent;
        private readonly Timer _timerHealthNowResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadWellCareResultPdfDownloadPollingAgent;
        private readonly Timer _timerWellCareResultPdfDownloadPollingAgent;

        //private readonly IntervalWorkThread _pollThreadAnthemCaResultPdfDownloadPollingAgent;
        //private readonly Timer _timerAnthemCaResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadBcbsMnPdfDownloadPollingAgent;
        private readonly Timer _timerBcbsMnResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadMonarchResultPdfDownloadPollingAgent;
        private readonly Timer _timerMonarchResultResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadBcbsmiResultPdfDownloadPollingAgent;
        private readonly Timer _timerBcbsmiResultResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadAnthemResultPdfDownloadPollingAgent;
        private readonly Timer _timerAnthemResultResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadWellCareToWellMedPdfPollingAgent;
        private readonly Timer _timerWellCareToWellMedPdfPollingAgent;

        public ResultExportService(ISettings settings, ILogManager logManager, IBcbsScResultPdfDownloadPollingAgent bcbsScResultPdfDownloadPollingAgent,
            IHealthNowResultPdfDownloadPollingAgent healthNowResultPdfDownloadPollingAgent, IWellCareResultPdfDownloadPollingAgent wellCareResultPdfDownloadPollingAgent,
             IBcbsMnPdfDownloadPollingAgent bcbsMnPdfDownloadPollingAgent,
            IBcbsMiResultPdfDownloadPdfAgent bcbsMiResultPdfDownloadPdfAgent, IMonarchResultPdfToWellmedDownloadPollingAgent monarchResultPdfDownloadPollingAgent,
            IAnthemResultPdfDownloadPollingAgent anthemResultPdfDownloadPollingAgent,
            IWellCareToWellmedResultPdfDownloadPollingAgent wellCareToWellmedResultPdfDownloadPollingAgent) //IMonarchResultPdfDownloadPollingAgent monarchResultPdfDownloadPollingAgent,IAnthemCaResultPdfDownloadPollingAgent anthemCaResultPdfDownloadPollingAgent,
        {

            InitializeComponent();
            _logger = logManager.GetLogger<ResultExportService>();

            //BCBS - result PDF export
            _pollThreadBcbsScResultPdfDownload = new IntervalWorkThread(bcbsScResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerBcbsScResultPdfDownloadPollingAgent = new Timer(x => _pollThreadBcbsScResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //HealthNow Result Pdf
            _pollThreadHealthNowResultPdfDownloadPollingAgent = new IntervalWorkThread(healthNowResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerHealthNowResultPdfDownloadPollingAgent = new Timer(x => _pollThreadHealthNowResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));


            //HealthNow Result Pdf
            _pollThreadWellCareResultPdfDownloadPollingAgent = new IntervalWorkThread(wellCareResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerWellCareResultPdfDownloadPollingAgent = new Timer(x => _pollThreadWellCareResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            ////Anthem CA Result Pdf
            //_pollThreadAnthemCaResultPdfDownloadPollingAgent = new IntervalWorkThread(anthemCaResultPdfDownloadPollingAgent.PollForPdfDownload);
            //_timerAnthemCaResultPdfDownloadPollingAgent = new Timer(x => _pollThreadAnthemCaResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //Bcbs Mn Result Pdf
            _pollThreadBcbsMnPdfDownloadPollingAgent = new IntervalWorkThread(bcbsMnPdfDownloadPollingAgent.PollForPdfDownload);
            _timerBcbsMnResultPdfDownloadPollingAgent = new Timer(x => _pollThreadBcbsMnPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //Monarch Result Pdf -- Now Monarch All data will be zipped and will be sent to their sftp
            _pollThreadMonarchResultPdfDownloadPollingAgent = new IntervalWorkThread(monarchResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerMonarchResultResultPdfDownloadPollingAgent = new Timer(x => _pollThreadMonarchResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //bcbs mi Result Pdf
            _pollThreadBcbsmiResultPdfDownloadPollingAgent = new IntervalWorkThread(bcbsMiResultPdfDownloadPdfAgent.PollForPdfDownload);
            _timerBcbsmiResultResultPdfDownloadPollingAgent = new Timer(x => _pollThreadBcbsmiResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));


            //bcbs mi Result Pdf
            _pollThreadAnthemResultPdfDownloadPollingAgent = new IntervalWorkThread(anthemResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerAnthemResultResultPdfDownloadPollingAgent = new Timer(x => _pollThreadAnthemResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //Wellcare To Wellmed Result Pdf
            _pollThreadWellCareToWellMedPdfPollingAgent = new IntervalWorkThread(wellCareToWellmedResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerWellCareToWellMedPdfPollingAgent = new Timer(s => _pollThreadWellCareToWellMedPdfPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

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

            _logger.Info("Starting BcbsSc Result Pdf Polling Agent");
            _pollThreadBcbsScResultPdfDownload.Start();

            _logger.Info("Starting HealthNow Result Pdf on sftp");
            _pollThreadHealthNowResultPdfDownloadPollingAgent.Start();

            _logger.Info("Starting WellCare Result Pdf on sftp");
            _pollThreadWellCareResultPdfDownloadPollingAgent.Start();

            //_logger.Info("Starting Anthem CA Result Pdf on sftp");
            //_pollThreadAnthemCaResultPdfDownloadPollingAgent.Start();

            _logger.Info("Starting Bcbs Mn Result Pdf on sftp");
            _pollThreadBcbsMnPdfDownloadPollingAgent.Start();

            _logger.Info("Starting Monarch Result Pdf on sftp");
            _pollThreadMonarchResultPdfDownloadPollingAgent.Start();

            _logger.Info("Starting bcbs mi Result Pdf on sftp");
            _pollThreadBcbsmiResultPdfDownloadPollingAgent.Start();

            _logger.Info("Starting Anthem Result Pdf on sftp");
            _pollThreadAnthemResultPdfDownloadPollingAgent.Start();

            _logger.Info("Starting WellCareTowellmed");
            _pollThreadWellCareToWellMedPdfPollingAgent.Start();

        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Locked Corporate Events");
            _timerBcbsScResultPdfDownloadPollingAgent.Dispose();
            _pollThreadBcbsScResultPdfDownload.Stop();

            _logger.Info("Stopping HealthNow Result Pdf Download Polling Agent ");
            _timerHealthNowResultPdfDownloadPollingAgent.Dispose();
            _pollThreadHealthNowResultPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping WellCare Result Pdf Download Polling Agent ");
            _timerWellCareResultPdfDownloadPollingAgent.Dispose();
            _pollThreadWellCareResultPdfDownloadPollingAgent.Stop();

            //_logger.Info("Stopping Anthem CA Result Pdf Download Polling Agent ");
            //_timerAnthemCaResultPdfDownloadPollingAgent.Dispose();
            //_pollThreadAnthemCaResultPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping Bcbs Mn Result Pdf Download Polling Agent ");
            _timerBcbsMnResultPdfDownloadPollingAgent.Dispose();
            _pollThreadBcbsMnPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping Monarch Result Pdf Download Polling Agent ");
            _timerMonarchResultResultPdfDownloadPollingAgent.Dispose();
            _pollThreadMonarchResultPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping bcbs mi Result Pdf on sftp");
            _timerBcbsmiResultResultPdfDownloadPollingAgent.Dispose();
            _pollThreadBcbsmiResultPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping bcbs mi Result Pdf on sftp");
            _timerAnthemResultResultPdfDownloadPollingAgent.Dispose();
            _pollThreadAnthemResultPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping wellcare to Wellmed");
            _timerWellCareToWellMedPdfPollingAgent.Dispose();
            _pollThreadWellCareToWellMedPdfPollingAgent.Stop();
        }
    }
}
