using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using System;
using System.ServiceProcess;
using System.Threading;

namespace Jobs.HealthPlanReportsService
{

    public partial class HealthPlanReportsService : ServiceBase
    {
        private readonly IntervalWorkThread _pollThreadHiptoAcesCrossWalkPollingAgent;
        private readonly Timer _timerHiptoAcesCrossWalkPollingAgent;

        private readonly IntervalWorkThread _pollThreadCustomerEligibilityUploadPollingAgent;
        private readonly Timer _timerCustomerEligibilityUploadPollingAgent;

        private readonly IntervalWorkThread _pollThreadMemberUploadbyAcesPollingAgent;
        private readonly Timer _timerMemberUploadbyAcesPollingAgent;

        //private readonly Thread _pollForMemberTermByAbsenceSuscribre;

        private readonly IntervalWorkThread _pollThreadMemberUploadParsePollingAgent;
        private readonly Timer _timerMemberUploadParsePollingAgent;

     

        private readonly ILogger _logger;

        public HealthPlanReportsService(ILogManager logManager, ISettings settings, IHiptoAcesCrossWalkPollingAgent hiptoAcesCrossWalkPollingAgent,
            ICustomerEligibilityUploadPollingAgent customerEligibilityUploadPollingAgent, IMemberUploadbyAcesPollingAgent memberUploadbyAcesPollingAgent,
            //IMemberTermByAbsenceSubscriber memberTermByAbsenceSubscriber, 
            IMemberUploadParsePollingAgent memberUploadParsePollingAgent)
        {
            InitializeComponent();

            _logger = logManager.GetLogger("Jobs.HealthPlanReportsService");
            _logger.Info("Constructor Call.");

            _pollThreadHiptoAcesCrossWalkPollingAgent = new IntervalWorkThread(hiptoAcesCrossWalkPollingAgent.PollforHiptoAcesCrossWalk);
            _timerHiptoAcesCrossWalkPollingAgent = new Timer(x => _pollThreadHiptoAcesCrossWalkPollingAgent.Trigger(), new object(), GetDueTime(settings.HiptoAcesCrossWalkReportScheduleTime), new TimeSpan(0, settings.HiptoAcesCrossWalkReportInterval, 0, 0));

            _pollThreadCustomerEligibilityUploadPollingAgent = new IntervalWorkThread(customerEligibilityUploadPollingAgent.PollForCustomerEligibilityUpload);
            _timerCustomerEligibilityUploadPollingAgent = new Timer(x => _pollThreadCustomerEligibilityUploadPollingAgent.Trigger(), new object(), GetDueTime(settings.CustomerEligibilityUploadScheduleTime), new TimeSpan(0, settings.CustomerEligibilityUploadIntervalHours, 0, 0));

            _pollThreadMemberUploadbyAcesPollingAgent = new IntervalWorkThread(memberUploadbyAcesPollingAgent.PollForMemberUploadbyAces);
            _timerMemberUploadbyAcesPollingAgent = new Timer(x => _pollThreadMemberUploadbyAcesPollingAgent.Trigger(), new object(), GetDueTime(settings.MemberUploadbyAcesReportScheduleTime), new TimeSpan(0, settings.MemberUploadbyAcesReportInterval, 0, 0));

            //_pollForMemberTermByAbsenceSuscribre = new Thread(memberTermByAbsenceSubscriber.PollForMemerTermByAbsenceSubscriber);

            _pollThreadMemberUploadParsePollingAgent = new IntervalWorkThread(memberUploadParsePollingAgent.Parse);
            _timerMemberUploadParsePollingAgent = new Timer(x => _pollThreadMemberUploadParsePollingAgent.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.MemberUploadParseIntervalMinutes, 0));

            _logger.Info("Constructor Call Complete.");
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting Health Plan Reports service ...");

            _logger.Info("Starting Hip to Aces Crosswalk service ...");
            _pollThreadHiptoAcesCrossWalkPollingAgent.Start();

            _logger.Info("Starting Customer Eligibility Upload Service...");
            _pollThreadCustomerEligibilityUploadPollingAgent.Start();

            _logger.Info("Starting Member Upload by Aces service ...");
            _pollThreadMemberUploadbyAcesPollingAgent.Start();


            //_logger.Info("Starting Member Term By Absence Subscriber Service....");
            //_pollForMemberTermByAbsenceSuscribre.Start();

            _logger.Info("Starting Member Upload Parse Polling Agent ...");
            _pollThreadMemberUploadParsePollingAgent.Start();

            Thread.Sleep(5000);

        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }
        protected override void OnStop()
        {
            _logger.Info("Stopping Health Plan Reports service ...");

            _logger.Info("Stopping Hip to Aces Crosswalk service...");
            _timerHiptoAcesCrossWalkPollingAgent.Dispose();
            _pollThreadHiptoAcesCrossWalkPollingAgent.Stop();

            _logger.Info("Stopping Customer Eligibility Upload Service...");
            _timerCustomerEligibilityUploadPollingAgent.Dispose();
            _pollThreadCustomerEligibilityUploadPollingAgent.Stop();

            _logger.Info("Stopping Member Upload by Aces Service...");
            _timerMemberUploadbyAcesPollingAgent.Dispose();
            _pollThreadMemberUploadbyAcesPollingAgent.Stop();

            _logger.Info("Stopping Member Upload Parse Polling Agent ...");
            _timerMemberUploadParsePollingAgent.Dispose();
            _pollThreadMemberUploadParsePollingAgent.Stop();

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
