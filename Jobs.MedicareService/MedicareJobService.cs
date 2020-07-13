using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medicare;

namespace Falcon.Jobs.MedicareService
{
    public partial class MedicareJobService : ServiceBase
    {
        private readonly ISettings _settings;
        private readonly IntervalWorkThread _pollCustomerDemographicsSync;
        private readonly Timer _timerCustomerDemographicsSync;

        private readonly IntervalWorkThread _pollHealthPlanSync;
        private readonly Timer _timerHealthPlanSync;

        private readonly IntervalWorkThread _pollMedicareResultSync;
        private readonly Timer _timerMedicareResultSync;

        private readonly IntervalWorkThread _pollMedicareEventTestSync;
        private readonly Timer _timerMedicareEventTestSync;

        private readonly IntervalWorkThread _pollMedicareCredentialSync;
        private readonly Timer _timerMedicareCredentialSync;

        private readonly IntervalWorkThread _pollMedicareRapsSync;
        private readonly Timer _timerMedicareRapsSync;

        private readonly IntervalWorkThread _pollMedicareMedicationSync;
        private readonly Timer _timerMedicareMedicationSync;

        private readonly IntervalWorkThread _pollMedicareSuspectConditionSync;
        private readonly Timer _timerMedicareSuspectConditionSync;

        private readonly IntervalWorkThread _pollThreadSyncResultsReadyForCoding;
        private readonly Timer _timerSyncResultsReadyForCoding;

        private readonly ILogger _logger;

        public MedicareJobService(ILogManager logManager, ISyncCustomerPollingAgent syncCustomerPollingAgent, ISyncHealthPlanPollingAgent syncHealthPlanPollingAgent,
            ISettings settings, ISyncCustomerResultPollingAgent syncCustomerResultPollingAgent, ISyncEventTestPollingAgent syncEventTestPollingAgent,
            ISyncUserCredentialsPollingAgent syncUserCredentialsPollingAgent, ISyncRapsPollingAgent syncRapsPollingAgent, ISyncMedicationPollingAgent syncMedicationPollingAgent,
            ISyncSuspectConditionPollingAgent syncSuspectConditionPollingAgent, ISyncResultsReadyForCodingPollingAgent syncResultsReadyForCodingPollingAgent)
        {
            _settings = settings;
            InitializeComponent();
            _logger = logManager.GetLogger<MedicareJobService>();

            _pollCustomerDemographicsSync = new IntervalWorkThread(syncCustomerPollingAgent.Sync);
            _timerCustomerDemographicsSync = new Timer(x => _pollCustomerDemographicsSync.Trigger(), new object(), GetDueTime(_settings.MedicareCustomerScheduleTime), new TimeSpan(0, _settings.MedicareCustomerIntervalHour, _settings.MedicareCustomerIntervalMinute, 0));

            _pollHealthPlanSync = new IntervalWorkThread(syncHealthPlanPollingAgent.Sync);
            _timerHealthPlanSync = new Timer(x => _pollHealthPlanSync.Trigger(), new object(), GetDueTime(_settings.MedicareHealthPlanScheduleTime), new TimeSpan(0, _settings.MedicareCustomerIntervalHour, _settings.MedicareCustomerIntervalMinute, 0));

            _pollMedicareResultSync = new IntervalWorkThread(syncCustomerResultPollingAgent.Sync);
            _timerMedicareResultSync = new Timer(x => _pollMedicareResultSync.Trigger(), new object(), GetDueTime(_settings.MedicareResultScheduleTime), new TimeSpan(0, _settings.MedicareResultIntervalHour, _settings.MedicareResultIntervalMinute, 0));

            _pollMedicareEventTestSync = new IntervalWorkThread(syncEventTestPollingAgent.Sync);
            _timerMedicareEventTestSync = new Timer(x => _pollMedicareEventTestSync.Trigger(), new object(), GetDueTime(_settings.MedicareEventTestScheduleTime),
                new TimeSpan(0, _settings.MedicareEventTestIntervalHour, _settings.MedicareEventTestIntervalMinute, 0));

            _pollMedicareCredentialSync = new IntervalWorkThread(syncUserCredentialsPollingAgent.Sync);
            _timerMedicareCredentialSync = new Timer(x => _pollMedicareCredentialSync.Trigger(), new object(), GetDueTime(_settings.MedicareCredentialScheduleTime),
                new TimeSpan(0, _settings.MedicareCredentialIntervalHour, _settings.MedicareCredentialIntervalMinute, 0));

            _pollMedicareRapsSync = new IntervalWorkThread(syncRapsPollingAgent.Sync);
            _timerMedicareRapsSync = new Timer(x => _pollMedicareRapsSync.Trigger(), new object(), GetDueTime(_settings.MedicareRapsSyncScheduleTime),
                new TimeSpan(0, _settings.MedicareRapsSyncIntervalHour, _settings.MedicareRapsSyncIntervalMinute, 0));

            _pollMedicareMedicationSync = new IntervalWorkThread(syncMedicationPollingAgent.Sync);
            _timerMedicareMedicationSync = new Timer(x => _pollMedicareMedicationSync.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.MedicareMedicationSyncIntervalMinute, 0));

            _pollMedicareSuspectConditionSync = new IntervalWorkThread(syncSuspectConditionPollingAgent.Sync);
            _timerMedicareSuspectConditionSync = new Timer(x => _pollMedicareSuspectConditionSync.Trigger(), new object(), GetDueTime(_settings.MedicareSuspectConditionSyncScheduleTime),
                new TimeSpan(0, _settings.MedicareSuspectConditionSyncIntervalHour, _settings.MedicareSuspectConditionSyncIntervalMinute, 0));

            _pollThreadSyncResultsReadyForCoding = new IntervalWorkThread(syncResultsReadyForCodingPollingAgent.PollForSync);
            _timerSyncResultsReadyForCoding = new Timer(x => _pollThreadSyncResultsReadyForCoding.Trigger(), new object(), new TimeSpan(0, 0, 2, 0), new TimeSpan(0, 0, _settings.SyncResultsReadyForCodingInterval, 0));
        }

        private static TimeSpan GetDueTime(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddDays(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;

            return dt - DateTime.Now;
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Medicare service ...");

            _logger.Info("Stopping sync Medicare Customer Polling Agent...");
            _timerCustomerDemographicsSync.Dispose();
            _pollCustomerDemographicsSync.Stop();

            _logger.Info("Stopping sync Health plan Polling Agent...");
            _timerHealthPlanSync.Dispose();
            _pollHealthPlanSync.Stop();

            _logger.Info("Stopping sync Health plan Result Polling Agent...");
            _timerMedicareResultSync.Dispose();
            _pollMedicareResultSync.Stop();

            _logger.Info("Stopping sync Event Test Polling Agent...");
            _timerMedicareEventTestSync.Dispose();
            _pollMedicareEventTestSync.Stop();

            _logger.Info("Stopping sync Medicare Credential Polling Agent...");
            _timerMedicareCredentialSync.Dispose();
            _pollMedicareCredentialSync.Stop();

            _logger.Info("Stopping sync raps Polling Agent...");
            _timerMedicareRapsSync.Dispose();
            _pollMedicareRapsSync.Stop();

            _logger.Info("Stopping sync medication Polling Agent...");
            _timerMedicareMedicationSync.Dispose();
            _pollMedicareMedicationSync.Stop();

            _logger.Info("Stopping sync suspect condition Polling Agent...");
            _timerMedicareSuspectConditionSync.Dispose();
            _pollMedicareSuspectConditionSync.Stop();

            _logger.Info("Stopping sync result ready for coding Polling Agent...");
            _timerSyncResultsReadyForCoding.Dispose();
            _pollThreadSyncResultsReadyForCoding.Stop();
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting Medicare service...");

            _logger.Info("Starting sync Customer Polling Agent ...");
            _pollCustomerDemographicsSync.Start();


            _logger.Info("Starting sync Health plan Polling Agent ...");
            _pollHealthPlanSync.Start();

            _logger.Info("Starting sync Health plan Polling Agent ...");
            _pollMedicareResultSync.Start();

            _logger.Info("Starting sync Event Test Polling Agent ...");
            _pollMedicareEventTestSync.Start();

            _logger.Info("Starting sync Medicare Credential Polling Agent ...");
            _pollMedicareCredentialSync.Start();

            _logger.Info("Starting sync raps   Polling Agent ...");
            _pollMedicareRapsSync.Start();

            _logger.Info("Starting sync medication Polling Agent ...");
            _pollMedicareMedicationSync.Start();

            _logger.Info("Starting sync suspect condition Polling Agent ...");
            _pollMedicareSuspectConditionSync.Start();

            _logger.Info("Starting sync result ready for coding Polling Agent...");
            _pollThreadSyncResultsReadyForCoding.Start();
        }
    }
}
