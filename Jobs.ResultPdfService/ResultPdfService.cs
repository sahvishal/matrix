using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;

namespace Falcon.Jobs.ResultPdfService
{
    partial class ResultPdfService : ServiceBase
    {
        private readonly IntervalWorkThread _pollThreadResultPacketGeneration;
        private readonly Timer _timerResultPacketGeneration;

        private readonly ILogger _logger;

        private readonly IntervalWorkThread _pollThreadGenerateKynXmlPolling;
        private readonly Timer _timerGenerateKynXmlPolling;

        private readonly IntervalWorkThread _pollThreadGenerateHkynXmlPolling;
        private readonly Timer _timerGenerateHkynXmlPolling;

        private readonly IntervalWorkThread _pollThreadKynXmlPolling;
        private readonly Timer _timerKynXml;

        private readonly IntervalWorkThread _pollThreadHkynXmlPolling;
        private readonly Timer _timerHkynXml;

        private readonly IntervalWorkThread _pollThreadHkynPdfParsePolling;
        private readonly Timer _timerHkynPdfParse;

        private readonly IntervalWorkThread _pollThreadMyBioCheckPolling;
        private readonly Timer _timerMyBioCheckJson;

        private readonly IntervalWorkThread _pollThreadGenerateBioCheckJsonPolling;
        private readonly Timer _timerGenerateBioCheckJsonJson;

        private readonly IntervalWorkThread _pollThreadBioCheckJsonForFailedPolling;
        private readonly Timer _timerGenerateBioCheckJsonForFailedCustomers;

        private readonly IntervalWorkThread _pollThreadResultPacketGeneratorAfterPhysicianEvaluation;
        private readonly Timer _timerResultPacketGeneratorAfterPhysicianEvaluation;

        private readonly Thread _pollForSendTestMediaFilesSubscriber;

        public ResultPdfService(IResultPacketGeneratorPollingAgent resultPacketGeneratorPollingAgent, IGenerateKynXmlPollingAgent generateKynXmlPollingAgent,
            ILogManager logManager, ISettings settings, IKynXmlPollingAgent kynXmlPollingAgent, IHkynXmlPollingAgent hkynXmlPollingAgent,
            IGenerateHkynXmlPollingAgent generateHkynXmlPollingAgent, IParseHkynPdfPollingAgent parseHkynPdfPollingAgent,
            IMyBioChekAssesmentPollingAgent myBioChekAssesmentPollingAgent, IBioCheckJsonGeneratorPollingAgent generateBioCheckJsonPollingAgent,
            IBioCheckJsonForFailedCustomersPollingAgent bioCheckJsonForFailedCustomersPollingAgent, IResultPacketGeneratorAfterPhysicianEvaluationPollingAgent resultPacketGeneratorAfterPhysicianEvaluationPollingAgent,
            ISendTestMediaFilesSubscriber sendTestMediaFilesSubscriber)
        {
            InitializeComponent();

            _logger = logManager.GetLogger("Jobs.ResultPdfService");

            _pollThreadResultPacketGeneration = new IntervalWorkThread(resultPacketGeneratorPollingAgent.PollForResultPacketGeneration);

            var intervalForPacketGeneration = ConfigurationManager.AppSettings["IntervalinMinutesforPdfGeneration"];
            Int32 s;

            if (!string.IsNullOrEmpty(intervalForPacketGeneration) && Int32.TryParse(intervalForPacketGeneration, out s))
            {
                _timerResultPacketGeneration = new Timer(x => _pollThreadResultPacketGeneration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, s, 0));
            }
            else
            {
                _timerResultPacketGeneration = new Timer(x => _pollThreadResultPacketGeneration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));
            }

            _pollThreadGenerateKynXmlPolling = new IntervalWorkThread(generateKynXmlPollingAgent.Polling);
            _timerGenerateKynXmlPolling = new Timer(x => _pollThreadGenerateKynXmlPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.GenerateKynXmlInterval, 0));

            _pollThreadKynXmlPolling = new IntervalWorkThread(kynXmlPollingAgent.PollForEventsForKynXml);
            _timerKynXml = new Timer(x => _pollThreadKynXmlPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, settings.KynXmlIntervalInHours, settings.KynXmlIntervalInMinutes, 0));

            _pollThreadHkynXmlPolling = new IntervalWorkThread(hkynXmlPollingAgent.PollForEventsforHkynXml);
            _timerHkynXml = new Timer(x => _pollThreadHkynXmlPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, settings.KynXmlIntervalInHours, settings.KynXmlIntervalInMinutes, 0));

            _pollThreadGenerateHkynXmlPolling = new IntervalWorkThread(generateHkynXmlPollingAgent.Polling);
            _timerGenerateHkynXmlPolling = new Timer(x => _pollThreadGenerateHkynXmlPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.GenerateKynXmlInterval, 0));

            _pollThreadHkynPdfParsePolling = new IntervalWorkThread(parseHkynPdfPollingAgent.PollForParsing);
            _timerHkynPdfParse = new Timer(x => _pollThreadHkynPdfParsePolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.HkynParsePdfIntervalInMinutes, 0));

            _pollThreadMyBioCheckPolling = new IntervalWorkThread(myBioChekAssesmentPollingAgent.PollForEventsforMyBioChekAssesmentJson);
            _timerMyBioCheckJson = new Timer(x => _pollThreadMyBioCheckPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, settings.KynXmlIntervalInHours, settings.KynXmlIntervalInMinutes, 0));

            _pollThreadGenerateBioCheckJsonPolling = new IntervalWorkThread(generateBioCheckJsonPollingAgent.PollForBiomassEvents);
            _timerGenerateBioCheckJsonJson = new Timer(x => _pollThreadGenerateBioCheckJsonPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.GenerateKynXmlInterval, 0));


            _pollThreadBioCheckJsonForFailedPolling = new IntervalWorkThread(bioCheckJsonForFailedCustomersPollingAgent.PollForBiomassEvents);
            _timerGenerateBioCheckJsonForFailedCustomers = new Timer(x => _pollThreadBioCheckJsonForFailedPolling.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.HkynParsePdfIntervalInMinutes, 0));

            _pollThreadResultPacketGeneratorAfterPhysicianEvaluation = new IntervalWorkThread(resultPacketGeneratorAfterPhysicianEvaluationPollingAgent.PollForResultPacketGeneration);
            _timerResultPacketGeneratorAfterPhysicianEvaluation = new Timer(x => _pollThreadResultPacketGeneratorAfterPhysicianEvaluation.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.IpResultPdfIntervalInMinutes, 0));

            _pollForSendTestMediaFilesSubscriber = new Thread(sendTestMediaFilesSubscriber.PollForSendTestMediaFilesSubscriber);
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Result Packet Generation Polling...");
            _timerResultPacketGeneration.Dispose();
            _pollThreadResultPacketGeneration.Stop();

            _logger.Info("Stopping Generate Kyn Xml Polling...");
            _timerGenerateKynXmlPolling.Dispose();
            _pollThreadGenerateKynXmlPolling.Stop();

            _logger.Info("Stopping Kyn Xml Polling");
            _timerKynXml.Dispose();
            _pollThreadKynXmlPolling.Stop();

            _logger.Info("Stopping HKyn Xml Polling");
            _timerHkynXml.Dispose();
            _pollThreadHkynXmlPolling.Stop();

            _logger.Info("Stopping Generate HKyn Xml Polling...");
            _timerGenerateHkynXmlPolling.Dispose();
            _pollThreadGenerateHkynXmlPolling.Stop();

            _logger.Info("Stopping Hkyn Pdf Parser Polling...");
            _timerHkynPdfParse.Dispose();
            _pollThreadHkynPdfParsePolling.Stop();

            _logger.Info("Stopping My BioCheck Assessment Service...");
            _timerMyBioCheckJson.Dispose();
            _pollThreadMyBioCheckPolling.Stop();

            _logger.Info("Stopping Generate BioCheck JSON Service...");
            _timerGenerateBioCheckJsonJson.Dispose();
            _pollThreadGenerateBioCheckJsonPolling.Stop();

            _logger.Info("Stopping Generate BioCheck JSON  For Failed Customer Service...");
            _timerGenerateBioCheckJsonForFailedCustomers.Dispose();
            _pollThreadBioCheckJsonForFailedPolling.Stop();

            _logger.Info("Stopping Result Packet Generator After Physician Evaluation Polling...");
            _timerResultPacketGeneratorAfterPhysicianEvaluation.Dispose();
            _pollThreadResultPacketGeneratorAfterPhysicianEvaluation.Stop();
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting Result Packet Generation Polling...");
            _pollThreadResultPacketGeneration.Start();

            _logger.Info("Starting Generate Kyn Xml Polling ...");
            _pollThreadGenerateKynXmlPolling.Start();

            _logger.Info("Starting Kyn Xml Polling");
            _pollThreadHkynXmlPolling.Start();

            _logger.Info("Starting Generate Kyn Xml Polling ...");
            _pollThreadGenerateHkynXmlPolling.Start();

            _logger.Info("Starting Hkyn Pdf Parser Polling...");
            _pollThreadHkynPdfParsePolling.Start();

            _logger.Info("Starting My BioCheck Assessment Service...");
            _pollThreadMyBioCheckPolling.Start();

            _logger.Info("Starting Generate BioCheck JSON Service...");
            _pollThreadGenerateBioCheckJsonPolling.Start();

            _logger.Info("Starting Generate BioCheck JSON  For Failed Customer Service...");

            _pollThreadBioCheckJsonForFailedPolling.Start();

            _logger.Info("Starting Result Packet Generator After Physician Evaluation Polling...");
            _pollThreadResultPacketGeneratorAfterPhysicianEvaluation.Start();

            _logger.Info("Starting Send Test Media Files Subscriber Service....");
            _pollForSendTestMediaFilesSubscriber.Start();
            Thread.Sleep(5000);
        }
    }
}
