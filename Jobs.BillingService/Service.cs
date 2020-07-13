using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;

namespace Falcon.Jobs.BillingService
{
    public partial class Service : ServiceBase
    {
        /*private readonly IntervalWorkThread _pollThreadInsuranceEncounter;
        private readonly Timer _timerInsuranceEncounter;

        private readonly IntervalWorkThread _pollThreadInsuranceClaim;
        private readonly Timer _timerInsuranceClaim;*/

        private readonly IntervalWorkThread _pollThreadPatientKareoIntegration;
        private readonly Timer _timerPatientKareoIntegration;

        private readonly ILogger _logger;

        public Service(IEncounterPollingAgent encounterPollingAgent, ILogManager logManager, ISettings settings, IClaimPollingAgent claimPollingAgent, IPatientKareoIntegrationPollingAgent patientKareoIntegrationPollingAgent)
        {
            InitializeComponent();

            /*_pollThreadInsuranceEncounter = new IntervalWorkThread(encounterPollingAgent.PollforInsuranceEncounter);
            _timerInsuranceEncounter = new Timer(x => _pollThreadInsuranceEncounter.Trigger(), new object(), GetDueTime(settings.InsuranceEncounterSchedulingTime), new TimeSpan(0, 24, 0, 0));//new TimeSpan(0)

            _pollThreadInsuranceClaim = new IntervalWorkThread(claimPollingAgent.PollForInsuranceClaim);
            _timerInsuranceClaim = new Timer(x => _pollThreadInsuranceClaim.Trigger(), new object(), GetDueTime(settings.InsuranceClaimSchedulingTime), new TimeSpan(0, 24, 0, 0));// new TimeSpan(0)*/

            _pollThreadPatientKareoIntegration = new IntervalWorkThread(patientKareoIntegrationPollingAgent.PollForIntegration);
            _timerPatientKareoIntegration = new Timer(x => _pollThreadPatientKareoIntegration.Trigger(), new object(), GetDueTime(settings.PatientKareoIntegrationSchedulingTime), new TimeSpan(0, 24, 0, 0));// new TimeSpan(0)

            _logger = logManager.GetLogger<Service>();
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
            _logger.Info("Starting billing service ...");

            /*_logger.Info("Starting Insurance Encounter service...");
            _pollThreadInsuranceEncounter.Start();

            _logger.Info("Starting Insurance Claim service...");
            _pollThreadInsuranceClaim.Start();*/

            _logger.Info("Starting Patient Kareo Integration service...");
            _pollThreadPatientKareoIntegration.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping billing service...");

            /*_logger.Info("Stopping Insurance Encounter service...");
            _timerInsuranceEncounter.Dispose();
            _pollThreadInsuranceEncounter.Stop();

            _logger.Info("Stopping Insurance Claim service...");
            _timerInsuranceClaim.Dispose();
            _pollThreadInsuranceClaim.Stop();*/

            _logger.Info("Stopping Patient Kareo Integration service...");
            _timerPatientKareoIntegration.Dispose();
            _pollThreadPatientKareoIntegration.Stop();
        }
    }
}
