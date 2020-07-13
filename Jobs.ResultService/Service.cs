using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;

namespace Falcon.Jobs.ResultService
{
    public partial class Service : ServiceBase
    {
        private readonly TimeSpan _interval = new TimeSpan(0, 0, 1, 0);
        private readonly IntervalWorkThread _pollThreadResultArchivePolling;
        private readonly Timer _timerResultArchivePolling;

        private readonly IntervalWorkThread _threadRoutineCleanUp;
        private readonly Timer _timerRoutineCleanUp;

        private readonly IMediaCleanUpPollingAgent _mediaCleanUpPollingAgent;
        private readonly Thread _threadStartUpExecution;

        private readonly IntervalWorkThread _pollThreadBloodTestResultPolling;
        private readonly Timer _timerBloodTestResult;

        private readonly IntervalWorkThread _pollThreadBloodLabResultPolling;
        private readonly Timer _timerBloodLabResult;

        private readonly IntervalWorkThread _pollThreadDiabeticRetinopathyParserPolling;
        private readonly Timer _timerDiabeticRetinopathyParser;

        private readonly IntervalWorkThread _pollThreadMarkFailedResultArchiveUploadPolling;
        private readonly Timer _timerMarkFailedResultArchiveUpload;

        private readonly IntervalWorkThread _pollThreadEawvHraParserPolling;
        private readonly Timer _timerEawvHraParser;

        private readonly IntervalWorkThread _pollThreadLabReportParserPolling;
        private readonly Timer _timerLabReportParser;

        private readonly IntervalWorkThread _pollThreadBloodResultParsing;
        private readonly Timer _timerBloodResultParsing;

        private readonly ISettings _settings;

        private ILogger _logger;


        public Service(IResultArchivePollingAgent resultArchivePollingAgent, ILogManager logManager, IMediaCleanUpPollingAgent mediaCleanUpPollingAgent,
                IBloodTestResultParserPollingAgent bloodTestResultParserPollingAgent, IBloodLabResultParserPollingAgent bloodLabResultParserPolling,
           ISettings settings, IDiabeticRetinopathyParserPollingAgent diabeticRetinopathyParserPollingAgent, IMarkFailedResultArchiveUploadPollingAgent markFailedResultArchiveUploadPollingAgent,
            IEawvHraParserPollingAgent eawvHraParserPollingAgent, ILabReportParserPollingAgent labReportParserPollingAgent, IBloodResultParsePollingAgent bloodResultParsePollingAgent)
        {
            InitializeComponent();
            _settings = settings;

            _pollThreadResultArchivePolling = new IntervalWorkThread(resultArchivePollingAgent.PollforUploadCompleteResultArchives);
            _timerResultArchivePolling = new Timer(x => _pollThreadResultArchivePolling.Trigger(), new object(), new TimeSpan(0), _interval);

            _mediaCleanUpPollingAgent = mediaCleanUpPollingAgent;
            _threadRoutineCleanUp = new IntervalWorkThread(mediaCleanUpPollingAgent.PollForCleanUp);
            _timerRoutineCleanUp = new Timer(x => _threadRoutineCleanUp.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 40, 0));

            //_pollThreadResultPacketGeneration = new IntervalWorkThread(resultPacketGeneratorPollingAgent.PollForResultPacketGeneration);


            _threadStartUpExecution = new Thread(ExecuteStartUp);
            //var intervalForPacketGeneration = ConfigurationManager.AppSettings["IntervalinMinutesforPdfGeneration"];
            //Int32 s;

            //if (!string.IsNullOrEmpty(intervalForPacketGeneration) && Int32.TryParse(intervalForPacketGeneration, out s))
            //{
            //    _timerResultPacketGeneration = new Timer(x => _pollThreadResultPacketGeneration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, s, 0));
            //}
            //else
            //{
            //    _timerResultPacketGeneration = new Timer(x => _pollThreadResultPacketGeneration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));
            //}

            //_pollThreadGenerateKynXmlPolling = new IntervalWorkThread(generateKynXmlPollingAgent.Polling);
            //_timerGenerateKynXmlPolling = new Timer(x => _pollThreadGenerateKynXmlPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.GenerateKynXmlInterval, 0));

            //_pollThreadKynXmlPolling = new IntervalWorkThread(kynXmlPollingAgent.PollForEventsForKynXml);
            //_timerKynXml = new Timer(x => _pollThreadKynXmlPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, _settings.KynXmlIntervalInHours, _settings.KynXmlIntervalInMinutes, 0));


            _pollThreadBloodTestResultPolling = new IntervalWorkThread(bloodTestResultParserPollingAgent.Parse);
            _timerBloodTestResult = new Timer(x => _pollThreadBloodTestResultPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.BloodTestResultParserInterval, 0));

            _pollThreadBloodLabResultPolling = new IntervalWorkThread(bloodLabResultParserPolling.Parse);
            _timerBloodLabResult = new Timer(x => _pollThreadBloodLabResultPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.BloodTestResultParserInterval, 0));

            _pollThreadDiabeticRetinopathyParserPolling = new IntervalWorkThread(diabeticRetinopathyParserPollingAgent.Parse);
            _timerDiabeticRetinopathyParser = new Timer(x => _pollThreadDiabeticRetinopathyParserPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.DiabeticRetinopathyResultParserInterval, 0));

            _pollThreadMarkFailedResultArchiveUploadPolling = new IntervalWorkThread(markFailedResultArchiveUploadPollingAgent.PollForFailedArchiveUpload);
            _timerMarkFailedResultArchiveUpload = new Timer(x => _pollThreadMarkFailedResultArchiveUploadPolling.Trigger(), new object(), GetDueTime(_settings.MarkResultArchiveFailedScheduledTime), new TimeSpan(0, _settings.MarkResultArchiveFailedInterval, 0, 0));

            _pollThreadEawvHraParserPolling = new IntervalWorkThread(eawvHraParserPollingAgent.PollforParsing);
            _timerEawvHraParser = new Timer(x => _pollThreadEawvHraParserPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 1, 0, 0));

            _pollThreadLabReportParserPolling = new IntervalWorkThread(labReportParserPollingAgent.Parse);
            _timerLabReportParser = new Timer(x => _pollThreadLabReportParserPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.LabReportParserInterval, 0));

            _pollThreadBloodResultParsing = new IntervalWorkThread(bloodResultParsePollingAgent.Parse);
            _timerBloodResultParsing = new Timer(x => _pollThreadBloodResultParsing.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.BloodTestResultParserInterval, 0));

            _logger = logManager.GetLogger<Service>();
        }

        private static TimeSpan GetDueTime(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddDays(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;

            return dt - DateTime.Now;
        }

        public void ExecuteStartUp()
        {
            _mediaCleanUpPollingAgent.ExecuteCleanUp(true);
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting result service ...");
            _threadStartUpExecution.Start();

            _pollThreadResultArchivePolling.Start();
            // _pollThreadResultPacketGeneration.Start();

            _threadRoutineCleanUp.Start();

            _logger.Info("Starting Generate Kyn Xml Polling ...");
            // _pollThreadGenerateKynXmlPolling.Start();

            _logger.Info("Starting Kyn Xml Polling");
            // _pollThreadKynXmlPolling.Start();

            _logger.Info("Starting Blood Test Result Polling");
            _pollThreadBloodTestResultPolling.Start();

            _logger.Info("Starting Blood Lab Result Polling");
            _pollThreadBloodLabResultPolling.Start();

            _logger.Info("Starting Diabetic Retinopathy Parser Polling");
            _pollThreadDiabeticRetinopathyParserPolling.Start();

            _logger.Info("Starting Mark Failed Result Archive Upload");
            _pollThreadMarkFailedResultArchiveUploadPolling.Start();

            _logger.Info("Starting Eawv Hra Polling Agent");
            _pollThreadEawvHraParserPolling.Start();

            _logger.Info("Starting Lab Report Polling Agent");
            _pollThreadLabReportParserPolling.Start();

            _logger.Info("Starting Blood Result Parse Polling Agent");
            _pollThreadBloodResultParsing.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping result service...");
            _timerResultArchivePolling.Dispose();
            _pollThreadResultArchivePolling.Stop();

            //_timerResultPacketGeneration.Dispose();
            //_pollThreadResultPacketGeneration.Stop();

            _timerRoutineCleanUp.Dispose();
            _threadRoutineCleanUp.Stop();

            //_logger.Info("Stopping Generate Kyn Xml Polling...");
            //_timerGenerateKynXmlPolling.Dispose();
            //_pollThreadGenerateKynXmlPolling.Stop();

            //_logger.Info("Stopping Kyn Xml Polling");
            //_timerKynXml.Dispose();
            //_pollThreadKynXmlPolling.Stop();

            _logger.Info("stopping Blood Test Result Polling..");
            _timerBloodTestResult.Dispose();
            _pollThreadBloodTestResultPolling.Stop();

            _logger.Info("stopping Blood Lab Result Polling..");
            _timerBloodLabResult.Dispose();
            _pollThreadBloodLabResultPolling.Stop();

            _logger.Info("Stopping Diabetic Retinopathy Parser Polling");
            _timerDiabeticRetinopathyParser.Dispose();
            _pollThreadDiabeticRetinopathyParserPolling.Stop();

            _logger.Info("Stopping Mark Failed Result Archive Upload");
            _timerMarkFailedResultArchiveUpload.Dispose();
            _pollThreadMarkFailedResultArchiveUploadPolling.Stop();

            _logger.Info("Stopping Eawv Hra Polling Agent");
            _timerEawvHraParser.Dispose();
            _pollThreadEawvHraParserPolling.Stop();

            _logger.Info("Stopping Lab Report Polling Agent");
            _timerLabReportParser.Dispose();
            _pollThreadLabReportParserPolling.Stop();

            _logger.Info("Stopping Blood Result Parse Polling Agent");
            _timerBloodResultParsing.Dispose();
            _pollThreadBloodResultParsing.Stop();
        }
    }
}
