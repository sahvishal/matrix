using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

namespace Falcon.Jobs.CallQueueService
{
    partial class CallQueueService : ServiceBase
    {

        //private readonly IntervalWorkThread _pollThreadHealthPlanCallQueue;
        //private readonly Timer _timerHealthPlanCallQueue;

        //private readonly IntervalWorkThread _pollThreadHealthPlanCallRoundCallQueue;
        //private readonly Timer _timerHealthPlanCallRoundCallQueue;

        //private readonly IntervalWorkThread _pollThreadHealthPlanNoShowCallQueue;
        //private readonly Timer _timerHealthPlanNoShowCallQueue;

        ////private readonly IntervalWorkThread _pollThreadHealthPlanZipRadiusCallQueue;
        ////private readonly Timer _timerHealthPlanZipRadiusCallQueue;

        //private readonly IntervalWorkThread _pollThreadHealthPlanUncontactedCustomersQueue;
        //private readonly Timer _timerHealthPlanUncontactedCustomersQueue;

        //private readonly IntervalWorkThread _pollThreadUncontactedCustomersRegenerationQueue;
        //private readonly Timer _timerUncontactedCustomersRegenerationQueue;

        private readonly IntervalWorkThread _pollThreadHealthPlanFillEventCallQueue;
        private readonly Timer _timerHealthPlanFillEventCallQueue;

        private readonly IntervalWorkThread _pollThreadHealthPlanCallQueueForFillEvents;
        private readonly Timer _timerHealthPlanCallQueueForFillEventsCallQueue;

        private readonly IntervalWorkThread _pollThreadDeleteHealthPlanCriteria;
        private readonly Timer _timerDeleteHealthPlanCriteria;

        private readonly IntervalWorkThread _pollThreadHealthPlanCallQueueForMailRound;
        private readonly Timer _timerHealthPlanCallQueueForMailRound;


        private readonly IntervalWorkThread _pollThreadHealthPlanLanguageBarrierQueue;
        private readonly Timer _timerHealthPlanLanguageBarrierQueue;

        private readonly IntervalWorkThread _pollThreadLanguageBarrierRegenerationQueue;
        private readonly Timer _timerLanguageBarrierRegenerationQueue;

        private readonly IntervalWorkThread _pollThreadHealthPlanEventZip;
        private readonly Timer _timerHealthPlanEventZip;

        //private readonly IntervalWorkThread _pollThreadHealthPlanEventZipForQueueNotGenerated;
        //private readonly Timer _timerHealthPlanEventZipForQueueNotGenerated;

        private readonly IntervalWorkThread _pollThreadHealthPlanConfirmationQueue;
        private readonly Timer _timerHealthPlanConfirmationQueue;

        private readonly IntervalWorkThread _pollThreadHealthPlanConfirmationQueueRegeneration;
        private readonly Timer _timerHealthPlanConfirmationQueueRegeneration;

        private readonly IntervalWorkThread _pollThreadAccountEventZipSubstituteRegeneration;
        private readonly Timer _timerAccountEventZipSubstituteRegeneration;

        private readonly IntervalWorkThread _pollThreadEventZipProductTypePollingAgentRegeneration;
        private readonly Timer _timerEventZipProductTypePollingAgentRegeneration;

        private readonly IntervalWorkThread _pollThreadEventZipProductTypeSubstitutePollingAgentRegeneration;
        private readonly Timer _timerEventZipProductTypeSubstitutePollingAgentRegeneration;


        private readonly ISettings _settings;
        private readonly ILogger _logger;
        public CallQueueService(ILogManager logManager, ISettings settings, IHealthPlanFillEventCallQueuePollingAgent healthPlanFillEventCallQueuePollingAgent,

            IHealthPlanCallQueueForFillEventsPollingAgent healthPlanCallQueueForFillEventsPollingAgent, IHealthPlanCriteriaForDeletionPollingAgent healthPlanCriteriaForDeletionPollingAgent,
            IHealthPlanMailRoundCallQueuePollingAgent healthPlanMailRoundCallQueuePollingAgent, IHealthPlanLanguageBarrierPollingAgent healthPlanLanguageBarrierPollingAgent,
            ILanguageBarrierRegeneratePollingAgent languageBarrierRegeneratePollingAgent, IHealthPlanEventZipPollingAgent healthPlanEventZipPollingAgent,
             IHealthPlanConfirmationQueuePollingAgent healthPlanConfirmationQueuePollingAgent,
            IHealthPlanConfirmationQueueNotGeneratedPollingAgent healthPlanConfirmationQueueNotGeneratedPollingAgent, IAccountEventZipSubstituteRegenerationPollingAgent accountEventZipSubstituteRegenerationPollingAgent,
            IEventZipProductTypePollingAgent eventZipProductTypePollingAgent, IEventZipProductTypeSubstitutePollingAgent eventZipProductTypeSubstitutePollingAgent)
        //IHealthPlanCallQueuePollingAgent healthPlanCallQueuePollingAgent,ICallRoundCallQueuePollingAgent callRoundCallQueuePollingAgent, INoShowCallQueuePollingAgent noShowCallQueuePollingAgent,  
        //IZipRadiusCallQueuePollingAgent zipRadiusCallQueuePollingAgent, IHealthPlanUncontactedCustomersPollingAgent healthPlanUncontactedCustomersPollingAgent,IUncontactedCustomersRegeneratePollingAgent uncontactedCustomersRegeneratePollingAgent,
        //IHealthPlanEventZipForQueueNotGeneratedPollingAgent healthPlanEventZipForQueueNotGeneratedPollingAgent,
        {
            InitializeComponent();
            _settings = settings;
            _logger = logManager.GetLogger("CallQueueService");

            //_pollThreadHealthPlanCallRoundCallQueue = new IntervalWorkThread(callRoundCallQueuePollingAgent.PollForCallQueue);
            //_timerHealthPlanCallRoundCallQueue = new Timer(x => _pollThreadHealthPlanCallRoundCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));

            //_pollThreadHealthPlanNoShowCallQueue = new IntervalWorkThread(noShowCallQueuePollingAgent.PollForCallQueue);
            //_timerHealthPlanNoShowCallQueue = new Timer(x => _pollThreadHealthPlanNoShowCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));

            //_pollThreadHealthPlanZipRadiusCallQueue = new IntervalWorkThread(zipRadiusCallQueuePollingAgent.PollForCallQueue);
            //_timerHealthPlanZipRadiusCallQueue = new Timer(x => _pollThreadHealthPlanZipRadiusCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));


            //_pollThreadHealthPlanCallQueue = new IntervalWorkThread(healthPlanCallQueuePollingAgent.PollForHealthPlanCallQueue);
            //_timerHealthPlanCallQueue = new Timer(x => _pollThreadHealthPlanCallQueue.Trigger(), new object(), GetDueTime(_settings.HealthPlanCallQueueGenerationScheduleTime), new TimeSpan(0, _settings.HealthPlanCallQueueGenerationInterval, 0, 0));

            //_pollThreadHealthPlanUncontactedCustomersQueue = new IntervalWorkThread(healthPlanUncontactedCustomersPollingAgent.PollForHealthPlanUncontactedCustomer);
            //_timerHealthPlanUncontactedCustomersQueue = new Timer(x => _pollThreadHealthPlanUncontactedCustomersQueue.Trigger(), new object(), GetDueTime(_settings.HealthPlanUncontactedCustomersGenerationScheduleTime), new TimeSpan(0, _settings.HealthPlanCallQueueGenerationInterval, 0, 0));

            //_pollThreadUncontactedCustomersRegenerationQueue = new IntervalWorkThread(uncontactedCustomersRegeneratePollingAgent.PollForRegenerateUncontactedCustomer);
            //_timerUncontactedCustomersRegenerationQueue = new Timer(x => _pollThreadUncontactedCustomersRegenerationQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));


            _pollThreadHealthPlanFillEventCallQueue = new IntervalWorkThread(healthPlanFillEventCallQueuePollingAgent.PollForCallQueue);
            _timerHealthPlanFillEventCallQueue = new Timer(x => _pollThreadHealthPlanFillEventCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));


            _pollThreadHealthPlanCallQueueForFillEvents = new IntervalWorkThread(healthPlanCallQueueForFillEventsPollingAgent.PollForHealthPlanCallQueue);
            _timerHealthPlanCallQueueForFillEventsCallQueue = new Timer(x => _pollThreadHealthPlanCallQueueForFillEvents.Trigger(), new object(), GetDueTime(_settings.HealthPlanFillEventCallQueueGenerationScheduleTime), new TimeSpan(0, _settings.HealthPlanCallQueueGenerationInterval, 0, 0));


            _pollThreadDeleteHealthPlanCriteria = new IntervalWorkThread(healthPlanCriteriaForDeletionPollingAgent.PollforCriteriaDeletion);
            _timerDeleteHealthPlanCriteria = new Timer(x => _pollThreadDeleteHealthPlanCriteria.Trigger(), new object(), GetDueTime(_settings.HealthPlanCriteriaForDeletionScheduleTime), new TimeSpan(0, _settings.HealthPlanCriteriaForDeletionInterval, 0, 0));

            _pollThreadHealthPlanCallQueueForMailRound = new IntervalWorkThread(healthPlanMailRoundCallQueuePollingAgent.PollForHealthPlanMailRoundCallQueue);
            _timerHealthPlanCallQueueForMailRound = new Timer(x => _pollThreadHealthPlanCallQueueForMailRound.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));

            //Language Barrier
            _pollThreadHealthPlanLanguageBarrierQueue = new IntervalWorkThread(healthPlanLanguageBarrierPollingAgent.PollForHealthPlanLanguageBarrierCustomer);
            _timerHealthPlanLanguageBarrierQueue = new Timer(x => _pollThreadHealthPlanLanguageBarrierQueue.Trigger(), new object(), GetDueTime(_settings.HealthPlanLanguageBarrierScheduleTime), new TimeSpan(0, _settings.HealthPlanCallQueueGenerationInterval, 0, 0));

            _pollThreadLanguageBarrierRegenerationQueue = new IntervalWorkThread(languageBarrierRegeneratePollingAgent.PollforRegenerateLanguageBarrierCallQueue);
            _timerLanguageBarrierRegenerationQueue = new Timer(x => _pollThreadLanguageBarrierRegenerationQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));

            _pollThreadHealthPlanEventZip = new IntervalWorkThread(healthPlanEventZipPollingAgent.PollForHealthPlanEventZip);
            _timerHealthPlanEventZip = new Timer(x => _pollThreadHealthPlanEventZip.Trigger(), new object(), GetDueTime(_settings.HealthPlanEventZipScheduleTime), new TimeSpan(0, _settings.HealthPlanEventZipInterval, 0, 0));

            //_pollThreadHealthPlanEventZipForQueueNotGenerated = new IntervalWorkThread(healthPlanEventZipForQueueNotGeneratedPollingAgent.PollForHealthPlanEventZipQueueNotGenerated);
            //_timerHealthPlanEventZipForQueueNotGenerated = new Timer(x => _pollThreadHealthPlanEventZipForQueueNotGenerated.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.HealthPlanEventZipQueueNotGeneratedInterval, 0));

            _pollThreadHealthPlanConfirmationQueue = new IntervalWorkThread(healthPlanConfirmationQueuePollingAgent.PollForQueueGeneration);
            _timerHealthPlanConfirmationQueue = new Timer(x => _pollThreadHealthPlanConfirmationQueue.Trigger(), new object(), GetDueTime(_settings.HealthPlanConfirmationCallQueueGenerationScheduleTime), new TimeSpan(1, 0, 0, 0));

            _pollThreadHealthPlanConfirmationQueueRegeneration = new IntervalWorkThread(healthPlanConfirmationQueueNotGeneratedPollingAgent.PollForQueueReGeneration);
            _timerHealthPlanConfirmationQueueRegeneration = new Timer(x => _pollThreadHealthPlanConfirmationQueueRegeneration.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 5, 0));

            _pollThreadAccountEventZipSubstituteRegeneration = new IntervalWorkThread(accountEventZipSubstituteRegenerationPollingAgent.PollForRegeneration);
            _timerAccountEventZipSubstituteRegeneration = new Timer(x => _pollThreadAccountEventZipSubstituteRegeneration.Trigger(), new object(), GetDueTimeMinute(settings.AccountZipSubstituteRegenerationScheduleTime), new TimeSpan(0, 0, settings.AccountZipSubstituteRegenerationInterval, 0));

            //
            _pollThreadEventZipProductTypePollingAgentRegeneration = new IntervalWorkThread(eventZipProductTypePollingAgent.PollEventZipProductType);
            _timerEventZipProductTypePollingAgentRegeneration = new Timer(x => _pollThreadEventZipProductTypePollingAgentRegeneration.Trigger(), new object(), GetDueTimeMinute(settings.EventZipProductTypePollingAgentRegenerationScheduleTime), new TimeSpan(0, settings.EventZipProductTypePollingAgentRegenerationInterval, 0, 0));

            _pollThreadEventZipProductTypeSubstitutePollingAgentRegeneration = new IntervalWorkThread(eventZipProductTypeSubstitutePollingAgent.PollEventZipProductType);
            _timerEventZipProductTypeSubstitutePollingAgentRegeneration = new Timer(x => _pollThreadEventZipProductTypeSubstitutePollingAgentRegeneration.Trigger(), new object(), GetDueTimeMinute(settings.EventZipProductTypeSubstitutePollingAgentRegenerationScheduleTime), new TimeSpan(0, settings.EventZipProductTypeSubstitutePollingAgentRegenerationInterval, 0, 0));
        }

        private static TimeSpan GetDueTime(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddDays(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;

            return dt - DateTime.Now;
        }

        private static TimeSpan GetDueTimeMinute(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddHours(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;
            
            return dt - DateTime.Now;
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        public void Start(string[] args)
        {
            //_logger.Info("Starting Healthplan Call Queue Polling");
            //_pollThreadHealthPlanCallQueue.Start();

            //_logger.Info("Starting Healthplan Call Round Call Queue Polling");
            //_pollThreadHealthPlanCallRoundCallQueue.Start();

            //_logger.Info("Starting Healthplan No Show Customer Call Queue Polling");
            //_pollThreadHealthPlanNoShowCallQueue.Start();

            ////_logger.Info("Starting Healthplan Zip Radius Customer Call Queue Polling");
            ////_pollThreadHealthPlanZipRadiusCallQueue.Start();

            //_logger.Info("Starting Healthplan Uncontacted Customers Call Queue Polling");
            //_pollThreadHealthPlanUncontactedCustomersQueue.Start();

            //_logger.Info("Starting Uncontacted Customers Regeneration Call Queue Polling");
            //_pollThreadUncontactedCustomersRegenerationQueue.Start();


            _logger.Info("Starting Healthplan Fill Event Call Queue Polling");
            _pollThreadHealthPlanFillEventCallQueue.Start();
            _logger.Info("Starting Healthplan For Fill Events of Generated Queues Polling");
            _pollThreadHealthPlanCallQueueForFillEvents.Start();

            _logger.Info("Starting Health Plan Criteria For Deletion Polling Agent");
            _pollThreadDeleteHealthPlanCriteria.Start();

            _logger.Info("Starting Healthplan Mail round call queue");
            _pollThreadHealthPlanCallQueueForMailRound.Start();

            _logger.Info("Starting Healthplan Language Barrier Call queue");
            _pollThreadHealthPlanLanguageBarrierQueue.Start();

            _logger.Info("Starting Healthplan Language Barrier Regeneration Call queue");
            _pollThreadLanguageBarrierRegenerationQueue.Start();

            _logger.Info("Starting Health Plan Event Zip Polling Agent");
            _pollThreadHealthPlanEventZip.Start();

            /*_logger.Info("Starting Health Plan Event Zip For Queue Not Generated Polling Agent");
            _pollThreadHealthPlanEventZipForQueueNotGenerated.Start();*/

            _logger.Info("Starting Health Plan Confirmation Call Queue Generation Polling Agent");
            _pollThreadHealthPlanConfirmationQueue.Start();

            _logger.Info("Starting Health Plan Confirmation Call Queue Regeneration Polling Agent");
            _pollThreadHealthPlanConfirmationQueueRegeneration.Start();

            _logger.Info("Starting Account Event Zip Regeneration Polling Agent");
            _pollThreadAccountEventZipSubstituteRegeneration.Start();

            _logger.Info("Starting Event Zip Product Type Polling Agent Regeneration ");
            _pollThreadEventZipProductTypePollingAgentRegeneration.Start();

            _logger.Info("Starting Event Zip Product Type Substitute Polling Agent Regeneration ");
            _pollThreadEventZipProductTypeSubstitutePollingAgentRegeneration.Start();
        }

        protected override void OnStop()
        {
            //_logger.Info("Stopping Healthplan Call Queue Polling");
            //_timerHealthPlanCallQueue.Dispose();
            //_pollThreadHealthPlanCallQueue.Stop();


            //_logger.Info("Stopping Healthplan Call Round Call Queue Polling");
            //_timerHealthPlanCallRoundCallQueue.Dispose();
            //_pollThreadHealthPlanCallRoundCallQueue.Stop();

            //_logger.Info("Stopping Healthplan No Show Call Queue Polling");
            //_timerHealthPlanNoShowCallQueue.Dispose();
            //_pollThreadHealthPlanNoShowCallQueue.Stop();

            ////_logger.Info("Stopping Healthplan Zip Radius Call Queue Polling");
            ////_timerHealthPlanZipRadiusCallQueue.Dispose();
            ////_pollThreadHealthPlanZipRadiusCallQueue.Stop();

            //_logger.Info("Stopping Healthplan Uncontacted Customers Call Queue Polling");
            //_timerHealthPlanUncontactedCustomersQueue.Dispose();
            //_pollThreadHealthPlanUncontactedCustomersQueue.Stop();

            //_logger.Info("Stopping Healthplan Uncontacted Customers Regeneration Call Queue Polling");
            //_timerUncontactedCustomersRegenerationQueue.Dispose();
            //_pollThreadUncontactedCustomersRegenerationQueue.Stop();



            _logger.Info("Stopping Healthplan Fill Events For Generated Queues Polling");
            _timerHealthPlanCallQueueForFillEventsCallQueue.Dispose();
            _pollThreadHealthPlanCallQueueForFillEvents.Stop();

            _logger.Info("Stopping Healthplan Fill Event Call Queue Polling");
            _timerHealthPlanFillEventCallQueue.Dispose();
            _pollThreadHealthPlanFillEventCallQueue.Stop();

            _logger.Info("Stopping Health Plan Criteria For Deletion Polling Agent");
            _timerDeleteHealthPlanCriteria.Dispose();
            _pollThreadDeleteHealthPlanCriteria.Stop();

            _logger.Info("Stopping Healthplan Mail round call queue");
            _timerHealthPlanCallQueueForMailRound.Dispose();
            _pollThreadHealthPlanCallQueueForMailRound.Stop();

            _logger.Info("Stopping Healthplan Language Barrier Call Queue Polling");
            _timerHealthPlanLanguageBarrierQueue.Dispose();
            _pollThreadHealthPlanLanguageBarrierQueue.Stop();

            _logger.Info("Stopping Healthplan Language Barrier Regeneration Call Queue Polling");
            _timerLanguageBarrierRegenerationQueue.Dispose();
            _pollThreadLanguageBarrierRegenerationQueue.Stop();

            _logger.Info("Stopping Health Plan Event Zip Polling Agent");
            _timerHealthPlanEventZip.Dispose();
            _pollThreadHealthPlanEventZip.Stop();

            /*_logger.Info("Stopping Health Plan Event Zip For Queue Not Generated Polling Agent");
            _timerHealthPlanEventZipForQueueNotGenerated.Dispose();
            _pollThreadHealthPlanEventZipForQueueNotGenerated.Stop();*/

            _logger.Info("Stopping Health Plan Confirmation Call Queue Generation Polling Agent");
            _timerHealthPlanConfirmationQueue.Dispose();
            _pollThreadHealthPlanConfirmationQueue.Stop();

            _logger.Info("Stopping Health Plan Confirmation Call Queue Regeneration Polling Agent");
            _timerHealthPlanConfirmationQueueRegeneration.Dispose();
            _pollThreadHealthPlanConfirmationQueueRegeneration.Stop();

            _logger.Info("Stopping Account Event Zip Regeneration Polling Agent");
            _timerAccountEventZipSubstituteRegeneration.Dispose();
            _pollThreadAccountEventZipSubstituteRegeneration.Stop();

            _logger.Info("Stopping Event Zip Product Type Polling Agent Regeneration");
            _timerEventZipProductTypePollingAgentRegeneration.Dispose();
            _pollThreadEventZipProductTypePollingAgentRegeneration.Stop();

            _logger.Info("Stopping Event Zip Product Type Substitute Polling Agent Regeneration");
            _timerEventZipProductTypeSubstitutePollingAgentRegeneration.Dispose();
            _pollThreadEventZipProductTypeSubstitutePollingAgentRegeneration.Stop();
        }
    }
}
