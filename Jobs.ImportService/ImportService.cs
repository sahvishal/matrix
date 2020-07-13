using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;

namespace Falcon.Jobs.ImportService
{
    public partial class ImportService : ServiceBase
    {
        //private readonly IntervalWorkThread _pollThreadHafGenration;
        //private readonly Timer _timerHafGeneration;

        private readonly IntervalWorkThread _pollThreadAwvPcpImport;
        private readonly Timer _timerAwvPcpImport;

        private readonly IntervalWorkThread _pollThreadArchiveResultData;
        private readonly Timer _timerArchiveResultData;

        private readonly IntervalWorkThread _pollThreadCorporateTagData;
        private readonly Timer _timerCorporateTagData;

        private readonly IntervalWorkThread _pollThreadImportFilesForHafGeneration;
        private readonly Timer _timerImportFilesForHafGeneration;

        private readonly IntervalWorkThread _pollThreadDeactivateUsers;
        private readonly Timer _timerDeactivateUsers;

        private readonly IntervalWorkThread _pollThreadParseMonarchAttesationForm;
        private readonly Timer _timerParseMonarchAttesationForm;

        private readonly IntervalWorkThread _pollThreadImportEventFiles;
        private readonly Timer _timerImportEventFiles;

        private readonly IntervalWorkThread _pollForStaffEventScheduleParse;
        private readonly Timer _timerForStaffEventScheduleParse;

        private readonly IntervalWorkThread _pollForHafGenerationPublisher;
        private readonly Timer _timerForHafGenerationPublisher;

        private readonly Thread _pollForHafGenerationSubscriber;

        private readonly IntervalWorkThread _pollForParsePatientDataFromAces;
        private readonly Timer _timerForParsePatientDataFromAces;


        private readonly ILogger _logger;

        public ImportService(ILogManager logManager, ISettings settings, IAwvPrimaryCarePhysicianImportPollingAgent awvPrimaryCarePhysicianImportPollingAgent,
            IArchiveResultDataPollingAgent archiveResultDataPollingAgent, ICorporateTagPollingAgent corporateTagPollingAgent, IImportFilesForHafGenerationPollingAgent importFilesForHafGenerationPollingAgent,
            IUserDeactivationByLastLogInPollingAgent userDeactivationByLastLogInPollingAgent, IParseMonarchAttesationFormPollingAgent parseMonarchAttesationFormPolling, IImportEventFilesPollingAgent importEventFilesPollingAgent,
            IStaffEventScheduleParsePollingAgent staffEventScheduleParsePollingAgent, IHafGenerationPublisher hafGenerationPublisher, IHafGenerationSubscriber hafGenerationSubscriber,
            IParsePatientDataFromAcesPollingAgent parsePatientDataFromAcesPollingAgent) //IHafGenerationPollingAgent hafGenerationPollingAgent, 
        {
            InitializeComponent();

            //_pollThreadHafGenration = new IntervalWorkThread(hafGenerationPollingAgent.PollforHealthAssessmentFormGeneration);
            //_timerHafGeneration = new Timer(x => _pollThreadHafGenration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));

            _pollThreadAwvPcpImport = new IntervalWorkThread(awvPrimaryCarePhysicianImportPollingAgent.PollForPcpImport);
            _timerAwvPcpImport = new Timer(x => _pollThreadAwvPcpImport.Trigger(), new object(), GetDueTime(settings.AwvPcpImportScheduleTime), new TimeSpan(0, settings.AwvPcpImportInterval, 0, 0));//


            _pollThreadArchiveResultData = new IntervalWorkThread(archiveResultDataPollingAgent.PollToArchiveResultData);
            _timerArchiveResultData = new Timer(x => _pollThreadArchiveResultData.Trigger(), new object(), GetDueTime(settings.ArchiveResultDataScheduleTime), new TimeSpan(0, settings.ArchiveResultDataIntervalHrs, 0, 0));//

            _pollThreadCorporateTagData = new IntervalWorkThread(corporateTagPollingAgent.PollForExpiredCorporateTagData);
            _timerCorporateTagData = new Timer(x => _pollThreadCorporateTagData.Trigger(), new object(), GetDueTime(settings.CorporateTagSchedulingTime), new TimeSpan(0, settings.CorporateTagIntervalHrs, 0, 0));//

            _pollThreadImportFilesForHafGeneration = new IntervalWorkThread(importFilesForHafGenerationPollingAgent.PollForFileImport);
            _timerImportFilesForHafGeneration = new Timer(x => _pollThreadImportFilesForHafGeneration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 1, 0, 0));//

            _pollThreadDeactivateUsers = new IntervalWorkThread(userDeactivationByLastLogInPollingAgent.PollForDeactivation);
            _timerDeactivateUsers = new Timer(x => _pollThreadDeactivateUsers.Trigger(), new object(), GetDueTime(settings.UserDeactivationScheduleTime), new TimeSpan(1, 0, 0, 0));

            _pollThreadParseMonarchAttesationForm = new IntervalWorkThread(parseMonarchAttesationFormPolling.PollforAttestationForm);
            _timerParseMonarchAttesationForm = new Timer(x => _pollThreadParseMonarchAttesationForm.Trigger(), new object(), GetDueTime(settings.MonarchAttestationScheduleTime), new TimeSpan(0, settings.MonarchAttestationIntervalHours, 0, 0));

            _pollThreadImportEventFiles = new IntervalWorkThread(importEventFilesPollingAgent.PollForEventFilesImport);
            _timerImportEventFiles = new Timer(x => _pollThreadImportEventFiles.Trigger(), new object(), GetDueTime(settings.EventFileImportScheduleTime), new TimeSpan(0, settings.EventFileImportIntervalHours, 0, 0));

            _pollForStaffEventScheduleParse = new IntervalWorkThread(staffEventScheduleParsePollingAgent.PollForStaffEventScheduleParse);
            _timerForStaffEventScheduleParse = new Timer(x => _pollForStaffEventScheduleParse.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.StaffEventScheduleParseIntervalMinutes, 0));

            _pollForHafGenerationPublisher = new IntervalWorkThread(hafGenerationPublisher.PollHafForPublish);
            _timerForHafGenerationPublisher = new Timer(x => _pollForHafGenerationPublisher.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 3, 0));

            _pollForHafGenerationSubscriber = new Thread(hafGenerationSubscriber.PollForHafGenerationSubscriber);

            _pollForParsePatientDataFromAces = new IntervalWorkThread(parsePatientDataFromAcesPollingAgent.PollForParsePatientDataFromAces);
            _timerForParsePatientDataFromAces = new Timer(x => _pollForParsePatientDataFromAces.Trigger(), new object(), GetDueTime(settings.ParsePatientDataScheduleTime), new TimeSpan(0, settings.ParsePatientDataIntervalHours, 0, 0));

            _logger = logManager.GetLogger("Jobs.ImportService");
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
            //_logger.Info("Starting HAF Generation ...");
            //_pollThreadHafGenration.Start();

            _logger.Info("Starting Awv Pcp Import...");
            _pollThreadAwvPcpImport.Start();

            _logger.Info("Staring Result Data Archive Service..");
            _pollThreadArchiveResultData.Start();

            _logger.Info("Starting CorporateTag Service..");
            _pollThreadCorporateTagData.Start();

            _logger.Info("Starting File Import for Haf Generation Service..");
            _pollThreadImportFilesForHafGeneration.Start();

            _logger.Info("Starting User Deactivation Service..");
            _pollThreadDeactivateUsers.Start();

            _logger.Info("Starting Monarch Attestation Polling Agent..");
            _pollThreadParseMonarchAttesationForm.Start();

            _logger.Info("Starting Event Files Import Service...");
            _pollThreadImportEventFiles.Start();

            _logger.Info("Starting Staff Event Scheduling parse Service...");
            _pollForStaffEventScheduleParse.Start();

            _logger.Info("Starting Haf Publisher Service....");
            _pollForHafGenerationPublisher.Start();

            _logger.Info("Starting Haf Subscriber Service....");
            _pollForHafGenerationSubscriber.Start();
            Thread.Sleep(5000);

            _logger.Info("Starting Parse Patient Data From Aces Service...");
            _pollForParsePatientDataFromAces.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            //_logger.Info("Stopping HAF Generation ...");
            //_timerHafGeneration.Dispose();
            //_pollThreadHafGenration.Stop();

            _logger.Info("Stopping Awv Pcp Import");
            _timerAwvPcpImport.Dispose();
            _pollThreadAwvPcpImport.Stop();

            _logger.Info("Stopping Result Data Archive Service.");
            _timerArchiveResultData.Dispose();
            _pollThreadArchiveResultData.Stop();

            _logger.Info("Stopping CorporateTag Service.");
            _timerCorporateTagData.Dispose();
            _pollThreadImportFilesForHafGeneration.Stop();

            _logger.Info("Stopping File Import for Haf Generation Service.");
            _timerImportFilesForHafGeneration.Dispose();
            _pollThreadCorporateTagData.Stop();

            _logger.Info("Stopping User Deactivation Service..");
            _timerDeactivateUsers.Dispose();
            _pollThreadDeactivateUsers.Stop();

            _logger.Info("Stopping Monarch Attestation Polling Agent..");
            _timerParseMonarchAttesationForm.Dispose();
            _pollThreadParseMonarchAttesationForm.Stop();

            _logger.Info("Stopping Event Files Import Service...");
            _timerImportEventFiles.Dispose();
            _pollThreadImportEventFiles.Stop();

            _logger.Info("Stopping Staff Event Scheduling parse Service...");
            _timerForStaffEventScheduleParse.Dispose();
            _pollForStaffEventScheduleParse.Stop();

            _logger.Info("Stopping Haf Publisher Service....");
            _timerForHafGenerationPublisher.Dispose();
            _pollForHafGenerationPublisher.Stop();

            _logger.Info("Stopping Parse Patient Data From Aces Service...");
            _timerForParsePatientDataFromAces.Dispose();
            _pollForParsePatientDataFromAces.Stop();

        }
    }
}
