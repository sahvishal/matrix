using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.Job.CallUploadService
{
    partial class CallUploadService : ServiceBase
    {
        private readonly IntervalWorkThread _pollThreadCallUploadFileParser;
        private readonly Timer _timerCallUploadFileParser;

        private readonly IntervalWorkThread _pollThreadApplyRulesOnLockedCustomers;
        private readonly Timer _timerApplyRulesOnLockedCustomers;

        private readonly IntervalWorkThread _pollThreadExportableReports;
        private readonly Timer _timerExportableReports;

        private readonly IntervalWorkThread _pollThreaDeleteExportableReports;
        private readonly Timer _timerDeleteExportableReports;

        private readonly IntervalWorkThread _pollThreadRapsUploadFileParser;
        private readonly Timer _timerRapsUploadFileParser;

        private readonly IntervalWorkThread _pollThreadPhoneNumberUpdateUpload;
        private readonly Timer _timerPhoneNumberUpdateUpload;


        private readonly IntervalWorkThread _pollMergeCustomerUpload;
        private readonly Timer _timerMergeCustomerUpload;

        private readonly IntervalWorkThread _pollTwilioMessagePollingAgentThread;
        private readonly Timer _timerTwilioMessagePollingAgent;

        private readonly IntervalWorkThread _pollEligibilityUploadAgentThread;
        private readonly Timer _timerEligibilityUploadPollingAgent;

        private readonly IntervalWorkThread _pollParsingMedicationUpload;
        private readonly Timer _timerParsingMedicationUpload;

        private readonly IntervalWorkThread _pollCustomerActivityTypeUploadAgentThread;
        private readonly Timer _timerCustomerActivityTypeUploadPollingAgent;

        private readonly ILogger _logger;
        public CallUploadService(ILogManager logManager, ISettings settings, ICallUploadFileParserPollingAgent callUploadFileParserPollingAgent, IApplyRulesOnLockedCustomersPollingAgent applyRulesOnLockedCustomersPollingAgent
            , IExportableReportsPollingAgent exportableReportsPollingAgent, IDeleteExportableReportsPollingAgent deleteExportableReportsPollingAgent, IRapsUploadFileParserPollingAgent rapsUploadFileParserPollingAgent,
            IPhoneNumberUpdatePollingAgent phoneNumberUpdatePollingAgent, IMergeCustomerPollingAgent mergeCustomerPollingAgent, ITwilioMessagePollingAgent twilioMessagePollingAgent,
            IEligibilityUploadParsePollingAgent eligibilityUploadParsePollingAgent, IMedicationUploadFileParserPollingAgent medicationUploadFileParserPollingAgent,
            ICustomerActivityTypeUploadPollingAgent customerActivityTypeUploadPollingAgent)
        {
            InitializeComponent();

            _logger = logManager.GetLogger("Jobs.CallUploadService");

            _pollThreadCallUploadFileParser = new IntervalWorkThread(callUploadFileParserPollingAgent.PollForParsingCallUpload);
            _timerCallUploadFileParser = new Timer(x => _pollThreadCallUploadFileParser.Trigger(), new object(), new TimeSpan(0, 0, 2, 0), new TimeSpan(0, 0, settings.CallUploadParserInterval, 0));

            _pollThreadApplyRulesOnLockedCustomers = new IntervalWorkThread(applyRulesOnLockedCustomersPollingAgent.PollForApplyRule);
            _timerApplyRulesOnLockedCustomers = new Timer(x => _pollThreadApplyRulesOnLockedCustomers.Trigger(), new object(), new TimeSpan(0, 0, 2, 0), new TimeSpan(0, 12, settings.ApplyRulesOnLockedCustomersInterval, 0));

            _pollThreadExportableReports = new IntervalWorkThread(exportableReportsPollingAgent.PollForExportableRequest);
            _timerExportableReports = new Timer(x => _pollThreadExportableReports.Trigger(), new object(), new TimeSpan(0, 0, 0, 0), new TimeSpan(0, 0, 2, 0));

            _pollThreaDeleteExportableReports = new IntervalWorkThread(deleteExportableReportsPollingAgent.DeleteReports);
            _timerDeleteExportableReports = new Timer(x => _pollThreaDeleteExportableReports.Trigger(), new object(), new TimeSpan(0, 0, 0, 0), new TimeSpan(0, 6, 0, 0));

            _pollThreadRapsUploadFileParser = new IntervalWorkThread(rapsUploadFileParserPollingAgent.PollForParsingRapsUpload);
            _timerRapsUploadFileParser = new Timer(x => _pollThreadRapsUploadFileParser.Trigger(), new object(), new TimeSpan(0, 0, 0, 0), new TimeSpan(0, 4, settings.RapsUploadParserInterval, 0));

            _pollThreadPhoneNumberUpdateUpload = new IntervalWorkThread(phoneNumberUpdatePollingAgent.PollForPhoneNumberUpdate);
            _timerPhoneNumberUpdateUpload = new Timer(x => _pollThreadPhoneNumberUpdateUpload.Trigger(), new object(), GetDueTime(settings.PhoneNumberUpdateScheduleTime), new TimeSpan(0, settings.PhoneNumberUpdateIntervalHours, 0, 0));

            _pollMergeCustomerUpload = new IntervalWorkThread(mergeCustomerPollingAgent.PollForMergeCustomerUpload);
            _timerMergeCustomerUpload = new Timer(x => _pollMergeCustomerUpload.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.MergeCustomerInterval, 0));

            _pollTwilioMessagePollingAgentThread = new IntervalWorkThread(twilioMessagePollingAgent.PollForTwilioResponse);
            _timerTwilioMessagePollingAgent = new Timer(x => _pollTwilioMessagePollingAgentThread.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 0, 1));

            _pollEligibilityUploadAgentThread = new IntervalWorkThread(eligibilityUploadParsePollingAgent.PollForParsingEligibilityUpload);
            _timerEligibilityUploadPollingAgent = new Timer(x => _pollEligibilityUploadAgentThread.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.EligibilityUploadIntervalMinutes, 0));

            _pollParsingMedicationUpload = new IntervalWorkThread(medicationUploadFileParserPollingAgent.PollForParsingMedicationUpload);
            _timerParsingMedicationUpload = new Timer(x => _pollParsingMedicationUpload.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.MedicationFileParserIntervalMinute, 0));

            _pollCustomerActivityTypeUploadAgentThread = new IntervalWorkThread(customerActivityTypeUploadPollingAgent.PollForParsingCustomerActivityTypeUpload);
            _timerCustomerActivityTypeUploadPollingAgent = new Timer(x => _pollCustomerActivityTypeUploadAgentThread.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, settings.CustomerActivityTypeUploadIntervalMinutes, 0));
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
            _logger.Info("Starting Call Upload File Parser Polling");
            _pollThreadCallUploadFileParser.Start();

            _logger.Info("Starting Apply Rules On Locked Customers Polling");
            _pollThreadApplyRulesOnLockedCustomers.Start();

            _logger.Info("Starting Exportable Report  Polling");
            _pollThreadExportableReports.Start();

            _logger.Info("Starting Delete Exportable Report  Polling");
            _pollThreaDeleteExportableReports.Start();

            _logger.Info("Starting Raps Upload Parser Service");
            _pollThreadRapsUploadFileParser.Start();

            _logger.Info("Starting Phone Number Update Service");
            _pollThreadPhoneNumberUpdateUpload.Start();

            _logger.Info("Starting Merge customer Service");
            _pollMergeCustomerUpload.Start();

            _logger.Info("Starting Twilio Message Polling Agent");
            _pollTwilioMessagePollingAgentThread.Start();

            _logger.Info("Starting Eligibility Upload Parse Polling Agent");
            _pollEligibilityUploadAgentThread.Start();

            _logger.Info("Starting Medication Upload Parse Polling Agent");
            _pollParsingMedicationUpload.Start();

            _logger.Info("Starting Customer Activity Type Upload Parse Polling Agent");
            _pollCustomerActivityTypeUploadAgentThread.Start();
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("Starting Call Upload service ...");
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Call Upload File Parser Polling...");
            _timerCallUploadFileParser.Dispose();
            _pollThreadCallUploadFileParser.Stop();

            _logger.Info("Stopping Apply Rules On Locked Customers Polling...");
            _timerApplyRulesOnLockedCustomers.Dispose();
            _pollThreadApplyRulesOnLockedCustomers.Stop();

            _logger.Info("Stopping Exportable Report  Polling...");
            _timerExportableReports.Dispose();
            _pollThreadExportableReports.Stop();

            _logger.Info("Stopping Delete Exportable Report  Polling...");
            _timerDeleteExportableReports.Dispose();
            _pollThreaDeleteExportableReports.Stop();

            _logger.Info("Stopping Raps Upload Parser Service..");
            _timerRapsUploadFileParser.Dispose();
            _pollThreadRapsUploadFileParser.Stop();

            _logger.Info("Stopping Phone Number Update Service");
            _timerPhoneNumberUpdateUpload.Dispose();
            _pollThreadPhoneNumberUpdateUpload.Stop();

            _logger.Info("Stopping Merge Customer Service");
            _timerMergeCustomerUpload.Dispose();
            _pollMergeCustomerUpload.Stop();


            _logger.Info("Stopping Twilio Message Polling Agent");
            _timerTwilioMessagePollingAgent.Dispose();
            _pollTwilioMessagePollingAgentThread.Stop();

            _logger.Info("Stopping Eligibility Upload Parse Polling Agent");
            _timerEligibilityUploadPollingAgent.Dispose();
            _pollEligibilityUploadAgentThread.Stop();

            _logger.Info("Stopping Medication Upload Parse Polling Agent");
            _timerParsingMedicationUpload.Dispose();
            _pollParsingMedicationUpload.Stop();

            _logger.Info("Stopping Customer Activity Type Upload Parse Polling Agent");
            _timerCustomerActivityTypeUploadPollingAgent.Dispose();
            _pollCustomerActivityTypeUploadAgentThread.Stop();
        }
    }
}
