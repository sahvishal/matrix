using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.Interfaces;

namespace Falcon.Jobs.FloridaBlueService
{
    partial class FloridaBlueService : ServiceBase
    {
        private readonly ILogger _logger;

        private readonly IIntervalWorkThread _pollThreadResponseVendorReportPollingAgent;
        private readonly Timer _timerResponseVendorReportPollingAgent;

        private readonly IIntervalWorkThread _pollThreadConditionInboundReportPollingAgent;
        private readonly Timer _timerConditionInboundReportPollingAgent;

        private readonly IIntervalWorkThread _pollThreadBarrierInboundReportPollingAgent;
        private readonly Timer _timerBarrierInboundReportPollingAgent;

        private readonly IIntervalWorkThread _pollThreadLabsInboundReportPollingAgent;
        private readonly Timer _timerLabsInboundReportPollingAgent;

        private readonly IIntervalWorkThread _pollThreadInterviewInboundReportPollingAgent;
        private readonly Timer _timerInterviewInboundReportPollingAgent;

        private readonly IIntervalWorkThread _pollThreadCrosswalkInboundReportPollingAgent;
        private readonly Timer _timerCrosswalkInboundReportPollingAgent;

        private readonly IIntervalWorkThread _pollThreadCrosswalkLabInboundReportPollingAgent;
        private readonly Timer _timerCrosswalkLabInboundReportPollingAgent;

        public FloridaBlueService(ILogManager logManager, ISettings settings, IResponseVendorReportPollingAgent responseVendorReportPollingAgent, IConditionInboundReportPollingAgent conditionInboundReportPollingAgent,
            IBarrierInboundReportPollingAgent barrierInboundReportPollingAgent, ILabsInboundReportPollingAgent labsInboundReportPollingAgent, IInterviewInboundReportPollingAgent interviewInboundReportPollingAgent,
            ICrosswalkInboundReportPollingAgent crosswalkInboundReportPollingAgent, ICrosswalkLabInboundReportPollingAgent crosswalkLabInboundReportPollingAgent)
        {
            InitializeComponent();
            _logger = logManager.GetLogger<FloridaBlueService>();

            //Response Vendor Inbound Report
            _pollThreadResponseVendorReportPollingAgent = new IntervalWorkThread(responseVendorReportPollingAgent.PollForResponseVendorReport);
            _timerResponseVendorReportPollingAgent = new Timer(x => _pollThreadResponseVendorReportPollingAgent.Trigger(), new object(), GetDueTime(settings.ResponseVendorReportScheduleTime), new TimeSpan(0, settings.ResponseVendorReportInterval, 0, 0));

            //Condition Inbound Report
            _pollThreadConditionInboundReportPollingAgent = new IntervalWorkThread(conditionInboundReportPollingAgent.PollForConditionInboundReport);
            _timerConditionInboundReportPollingAgent = new Timer(x => _pollThreadConditionInboundReportPollingAgent.Trigger(), new object(), GetDueTime(settings.ConditionInboundReportScheduleTime), new TimeSpan(0, settings.ConditionInboundReportInterval, 0, 0));

            //Barrier Inbound Report
            _pollThreadBarrierInboundReportPollingAgent = new IntervalWorkThread(barrierInboundReportPollingAgent.PollForBarrierInboundReport);
            _timerBarrierInboundReportPollingAgent = new Timer(x => _pollThreadBarrierInboundReportPollingAgent.Trigger(), new object(), GetDueTime(settings.BarrierInboundReportScheduleTime), new TimeSpan(0, settings.BarrierInboundReportInterval, 0, 0));

            //Labs Inbound Report
            _pollThreadLabsInboundReportPollingAgent = new IntervalWorkThread(labsInboundReportPollingAgent.PollForLabsInboundReport);
            _timerLabsInboundReportPollingAgent = new Timer(x => _pollThreadLabsInboundReportPollingAgent.Trigger(), new object(), GetDueTime(settings.LabsInboundReportScheduleTime), new TimeSpan(0, settings.LabsInboundReportInterval, 0, 0));

            //Interview Inbound Report
            _pollThreadInterviewInboundReportPollingAgent = new IntervalWorkThread(interviewInboundReportPollingAgent.PollForInterviewInboundReport);
            _timerInterviewInboundReportPollingAgent = new Timer(x => _pollThreadInterviewInboundReportPollingAgent.Trigger(), new object(), GetDueTime(settings.InterviewInboundReportScheduleTime), new TimeSpan(0, settings.InterviewInboundReportInterval, 0, 0));

            //Crosswalk Inbound Report
            _pollThreadCrosswalkInboundReportPollingAgent = new IntervalWorkThread(crosswalkInboundReportPollingAgent.PollForCrosswalkInboundReport);
            _timerCrosswalkInboundReportPollingAgent = new Timer(x => _pollThreadCrosswalkInboundReportPollingAgent.Trigger(), new object(), GetDueTime(settings.CrosswalkInboundReportScheduleTime), new TimeSpan(0, settings.CrosswalkInboundReportInterval, 0, 0));

            //Crosswalk Lab Inbound Report
            _pollThreadCrosswalkLabInboundReportPollingAgent = new IntervalWorkThread(crosswalkLabInboundReportPollingAgent.PollForCrosswalkLabInboundReport);
            _timerCrosswalkLabInboundReportPollingAgent = new Timer(x => _pollThreadCrosswalkLabInboundReportPollingAgent.Trigger(), new object(), GetDueTime(settings.CrosswalkLabInboundReportScheduleTime), new TimeSpan(0, settings.CrosswalkLabInboundReportInterval, 0, 0));
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
            _logger.Info("Florida Blue Service started.");

            _logger.Info("Starting Response Vendor Report generation.");
            _pollThreadResponseVendorReportPollingAgent.Start();

            _logger.Info("Starting Condition Inbound Report generation.");
            _pollThreadConditionInboundReportPollingAgent.Start();

            _logger.Info("Starting Barrier Inbound Report generation.");
            _pollThreadBarrierInboundReportPollingAgent.Start();

            _logger.Info("Starting Labs Inbound Report generation.");
            _pollThreadLabsInboundReportPollingAgent.Start();

            _logger.Info("Starting Interview Inbound Report generation.");
            _pollThreadInterviewInboundReportPollingAgent.Start();

            _logger.Info("Starting Crosswalk Inbound Report generation.");
            _pollThreadCrosswalkInboundReportPollingAgent.Start();

            _logger.Info("Starting Crosswalk Lab Inbound Report generation.");
            _pollThreadCrosswalkLabInboundReportPollingAgent.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Response Vendor Report generation.");
            _timerResponseVendorReportPollingAgent.Dispose();
            _pollThreadResponseVendorReportPollingAgent.Stop();

            _logger.Info("Stopping Condition Inbound Report generation.");
            _timerConditionInboundReportPollingAgent.Dispose();
            _pollThreadConditionInboundReportPollingAgent.Stop();

            _logger.Info("Stopping Barrier Inbound Report generation.");
            _timerBarrierInboundReportPollingAgent.Dispose();
            _pollThreadBarrierInboundReportPollingAgent.Stop();

            _logger.Info("Stopping Labs Inbound Report generation.");
            _timerLabsInboundReportPollingAgent.Dispose();
            _pollThreadLabsInboundReportPollingAgent.Stop();

            _logger.Info("Stopping Interview Inbound Report generation.");
            _timerInterviewInboundReportPollingAgent.Dispose();
            _pollThreadInterviewInboundReportPollingAgent.Stop();

            _logger.Info("Stopping Crosswalk Inbound Report generation.");
            _timerCrosswalkInboundReportPollingAgent.Dispose();
            _pollThreadCrosswalkInboundReportPollingAgent.Stop();

            _logger.Info("Stopping Crosswalk Lab Inbound Report generation.");
            _timerCrosswalkLabInboundReportPollingAgent.Dispose();
            _pollThreadCrosswalkLabInboundReportPollingAgent.Stop();

            _logger.Info("Stopping Florida Blue Service...");
        }
    }
}
