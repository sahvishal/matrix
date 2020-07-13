using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;

namespace Jobs.FloridaBlueOutboundService
{
    partial class FloridaBlueOutboundService : ServiceBase
    {
        private readonly ILogger _logger;

        private readonly IntervalWorkThread _pollThreadChaseOutboundParse;
        private readonly Timer _timerChaseOutboundParse;

        private readonly IntervalWorkThread _pollThreadOutboundFileImport;
        private readonly Timer _timerOutboundFileImport;

        private readonly IntervalWorkThread _pollThreadCareCodingOutboundParse;
        private readonly Timer _timerCareCodingOutboundParse;

        private readonly IntervalWorkThread _pollThreadPatientDetailParse;
        private readonly Timer _timerPatientDetaildParse;

        private readonly IntervalWorkThread _pollThreadDiagnosisReportParse;
        private readonly Timer _timerDiagnosisReportParse;

        private readonly IntervalWorkThread _pollThreadLoincLabDataParse;
        private readonly Timer _timerLoincLabDataParse;

        private readonly IntervalWorkThread _pollThreadLoincCrosswalkParse;
        private readonly Timer _timerLoincCrosswalkParse;

        private readonly IntervalWorkThread _pollThreadPreApprovedTestUpdate;
        private readonly Timer _timerPreApprovedTestUpdate;

        public FloridaBlueOutboundService(ILogManager logManager, ISettings settings, IChaseOutboundParsePollingAgent chaseOutboundImportPollingAgent, IOutboundFileImportPollingAgent outboundFileImportPollingAgent,
            ICareCodingOutboundParsePollingAgent careCodingOutboundParsePollingAgent, IPatientDetailReportParsingPollingAgent patientDetailReportParsingPollingAgent, IDiagnosisReportParsingPollingAgent diagnosisReportParsingPollingAgent,
            ILoincLabDataPollingAgent loincLabDataPollingAgent, ILoincCrosswalkPollingAgent loincCrosswalkPollingAgent, IPreApprovedTestUpdatePollingAgent preApprovedTestUpdatePollingAgent)
        {
            InitializeComponent();
            _logger = logManager.GetLogger<FloridaBlueOutboundService>();

            _pollThreadOutboundFileImport = new IntervalWorkThread(outboundFileImportPollingAgent.PollForOutboundFileImport);
            _timerOutboundFileImport = new Timer(x => _pollThreadOutboundFileImport.Trigger(), new object(), GetDueTime(settings.OutboundFileImportScheduleTime), new TimeSpan(0, settings.OutboundFileImportIntervalHours, 0, 0));

            _pollThreadChaseOutboundParse = new IntervalWorkThread(chaseOutboundImportPollingAgent.PollForOutboundChase);
            _timerChaseOutboundParse = new Timer(x => _pollThreadChaseOutboundParse.Trigger(), new object(), GetDueTime(settings.OutboundChaseParseScheduleTime), new TimeSpan(0, settings.OutboundChaseParseIntervalHours, 0, 0));

            _pollThreadCareCodingOutboundParse = new IntervalWorkThread(careCodingOutboundParsePollingAgent.PollForOutboundCareCoding);
            _timerCareCodingOutboundParse = new Timer(x => _pollThreadCareCodingOutboundParse.Trigger(), new object(), GetDueTime(settings.OutboundCareCodingParseScheduleTime), new TimeSpan(0, settings.OutboundCareCodingParseIntervalHours, 0, 0));

            _pollThreadPatientDetailParse = new IntervalWorkThread(patientDetailReportParsingPollingAgent.PollForPatientDetailReportParsing);
            _timerPatientDetaildParse = new Timer(x => _pollThreadPatientDetailParse.Trigger(), new object(), GetDueTime(settings.PatientDetailParseScheduleTime), new TimeSpan(0, settings.PatientDetailParseIntervalHours, 0, 0));

            _pollThreadDiagnosisReportParse = new IntervalWorkThread(diagnosisReportParsingPollingAgent.PollForDiagnosisReportParsing);
            _timerDiagnosisReportParse = new Timer(x => _pollThreadDiagnosisReportParse.Trigger(), new object(), GetDueTime(settings.DiagnosisReportParseScheduleTime), new TimeSpan(0, settings.DiagnosisReportParseIntervalHours, 0, 0));

            _pollThreadLoincLabDataParse = new IntervalWorkThread(loincLabDataPollingAgent.Parse);
            _timerLoincLabDataParse = new Timer(x => _pollThreadLoincLabDataParse.Trigger(), new object(), GetDueTime(settings.LoincLabDataParseScheduleTime), new TimeSpan(1, 0, 0, 0));

            _pollThreadLoincCrosswalkParse = new IntervalWorkThread(loincCrosswalkPollingAgent.Parse);
            _timerLoincCrosswalkParse = new Timer(x => _pollThreadLoincCrosswalkParse.Trigger(), new object(), GetDueTime(settings.LoincCrosswalkParseScheduleTime), new TimeSpan(1, 0, 0, 0));

            _pollThreadPreApprovedTestUpdate = new IntervalWorkThread(preApprovedTestUpdatePollingAgent.PollForUpdate);
            _timerPreApprovedTestUpdate = new Timer(x => _pollThreadPreApprovedTestUpdate.Trigger(), new object(), GetDueTime(settings.LoincCrosswalkParseScheduleTime), new TimeSpan(30, 0, 0, 0));
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
            _logger.Info("Florida Blue Outbound Service started.");

            _logger.Info("Staring Chase Outbound Parse Service..");
            _pollThreadChaseOutboundParse.Start();

            _logger.Info("Staring Outbound File Import Service..");
            _pollThreadOutboundFileImport.Start();

            _logger.Info("Staring Care Coding Outbound Parse Service..");
            _pollThreadCareCodingOutboundParse.Start();

            _logger.Info("Staring Patient Detail Report Parse Service..");
            _pollThreadPatientDetailParse.Start();

            _logger.Info("Staring Diagnosis Report Parse Service..");
            _pollThreadDiagnosisReportParse.Start();

            _logger.Info("Staring Loinc Lab Data Parse Service..");
            _pollThreadLoincLabDataParse.Start();

            _logger.Info("Staring Loinc Crosswalk Parse Service..");
            _pollThreadLoincCrosswalkParse.Start();

            _logger.Info("Staring Pre-approved Test Update Service..");
            _pollThreadPreApprovedTestUpdate.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Chase Outbound Import Service.");
            _timerChaseOutboundParse.Dispose();
            _pollThreadChaseOutboundParse.Stop();

            _logger.Info("Stopping Outbound File Import Service.");
            _timerOutboundFileImport.Dispose();
            _pollThreadOutboundFileImport.Stop();

            _logger.Info("Stopping Care Coding Outbound Import Service.");
            _timerCareCodingOutboundParse.Dispose();
            _pollThreadCareCodingOutboundParse.Stop();

            _logger.Info("Stopping Patient Detail Report Parse Service..");
            _timerPatientDetaildParse.Dispose();
            _pollThreadPatientDetailParse.Stop();

            _logger.Info("Stopping Diagnosis Report Parse Service..");
            _timerDiagnosisReportParse.Dispose();
            _pollThreadDiagnosisReportParse.Stop();

            _logger.Info("Stopping Loinc Lab Data Parse Service..");
            _timerLoincLabDataParse.Dispose();
            _pollThreadLoincLabDataParse.Stop();

            _logger.Info("Stopping Loinc Crosswalk Parse Service..");
            _timerLoincCrosswalkParse.Dispose();
            _pollThreadLoincCrosswalkParse.Stop();

            _logger.Info("Stopping Pre-approved Test Update Service..");
            _timerPreApprovedTestUpdate.Dispose();
            _pollThreadPreApprovedTestUpdate.Stop();

            _logger.Info("Stopping Florida Blue Outbound Service...");
        }
    }
}
