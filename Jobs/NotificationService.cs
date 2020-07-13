using System;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;

namespace Falcon.Jobs
{
    public partial class NotificationService : ConsoleServiceBase
    {
        private readonly TimeSpan _interval = new TimeSpan(0, 0, 1, 0);
        private readonly IntervalWorkThread _pollThread;
        private readonly Timer _timer;
        private readonly ILogger _logger;


        //private readonly IntervalWorkThread _faxPollThread;
        //private readonly Timer _faxTimer;

        private readonly IntervalWorkThread _pollThreadForEvaluationReminderNotification;
        private readonly Timer _timerForEvaluationReminderNotification;

        private readonly IntervalWorkThread _pollThreadResultDeliveredNotification;
        private readonly Timer _timerResultDelieveredNotification;

        private readonly IntervalWorkThread _pollThreadScreeningReminderNotification;
        private readonly Timer _timerScreeningReminderNotification;

        private readonly IntervalWorkThread _pollThreadAnnualReminderNotification;
        private readonly Timer _timerAnnualReminderNotification;

        private readonly IntervalWorkThread _pollThreadSurveyEmailNotification;
        private readonly Timer _timerSurveyEmailNotification;

        private readonly IntervalWorkThread _pollThreadProspectCustomerEmailNotification;
        private readonly Timer _timerProspectCustomerEmailNotification;

        private readonly IntervalWorkThread _pollThreadTestUpsellEmailNotification;
        private readonly Timer _timerTestUpsellEmailNotification;

        private readonly IntervalWorkThread _pollThreadSecondResultReadyNotification;
        private readonly Timer _timerSecondResultReadyNotification;

        private readonly IntervalWorkThread _pollThreadEventResultReadyNotification;
        private readonly Timer _timerEventResultReadyNotification;

        private readonly IntervalWorkThread _pollThreadSecondScreeningReminderNotification;
        private readonly Timer _timerSecondScreeningReminderNotification;

        private readonly IntervalWorkThread _pollThreadKynFirstNotification;
        private readonly Timer _timerKynFirstNotification;

        private readonly IntervalWorkThread _pollThreadKynSecondNotification;
        private readonly Timer _timerKynSecondNotification;

        //private readonly IntervalWorkThread _pollThreadCallQueuePollingAgent;
        //private readonly Timer _timerCallQueuePollingAgent;

        private readonly IntervalWorkThread _pollThreadPullBackCallQueueCustomer;
        private readonly Timer _timerPullBackCallQueueCustomer;
     
        private readonly IntervalWorkThread _pollForAppointmentReminderViaSms;
        private readonly Timer _timerForAppointmentReminderViaSms;

        private readonly IntervalWorkThread _pollForFaxResultNotification;
        private readonly Timer _timerForFaxResultNotification;

        private readonly IntervalWorkThread _pollThreadPriorityInQueueNotification;
        private readonly Timer _timerPriorityInQueueNotification;

        //private readonly IntervalWorkThread _pollThreadSystemGeneratedCallQueue;
        //private readonly Timer _timerSystemGeneratedCallQueue;

        //private readonly IntervalWorkThread _pollThreadFillEventsCallQueue;
        //private readonly Timer _timerFillEventsCallQueue;

        //private readonly IntervalWorkThread _pollThreadUpsellCallQueue;
        //private readonly Timer _timerUpsellCallQueue;

        //private readonly IntervalWorkThread _pollThreadConfirmationCallQueue;
        //private readonly Timer _timerConfirmationCallQueue;

        private readonly IntervalWorkThread _pollThreadDeletePastEventSystemGeneratedCallQueue;
        private readonly Timer _timerDeletePastEventSystemGeneratedCallQueue;

        private readonly IntervalWorkThread _pollThreadNoshowEventCustomerNotification;
        private readonly Timer _timerNoshowEventCustomerNotification;

        private readonly IntervalWorkThread _pollThreadDirectMailActivityReminderNotification;
        private readonly Timer _timerDirectMailActivityReminderNotification;

        private readonly IntervalWorkThread _pollThreadCorporateEventResultReadyNotification;
        private readonly Timer _timerCorporateEventResultReadyNotification;

        private readonly IntervalWorkThread _pollThreadCustomEventNotificationService;
        private readonly Timer _timerCustomEventNotificationService;

        private readonly IntervalWorkThread _pollThreadNotiificationToNursePractitioner;
        private readonly Timer _timerNotiificationToNursePractitioner;

        private readonly IntervalWorkThread _PollforPullBackPreAssessmentCallQueueCustomer;
        private readonly Timer _timerPollforPullBackPreAssessmentCallQueueCustomer;


        private readonly ISettings _settings;

        //public NotificationService(INotificationPollingAgent notificationPollingAgent, ILogManager logManager, IResultNotificationPollingAgent resultNotificationPollingAgent, ISurveyEmailPollingAgent surveyEmailPollingAgent,
        //    IEvaluationReminderNotificationPollingAgent evaluationReminderNotificationPollingAgent, IScreeningReminderPollingAgent screeningReminderPollingAgent, IAnnualReminderPollingAgent annualReminderPollingAgent,
        //    IProspectCustomerFollowupPollingAgent prospectCustomerFollowupPollingAgent, ISettings settings, ITestUpsellPollingAgent testUpsellPollingAgent, IResultReadyNotificationPollingAgent resultReadyNotificationPollingAgent,
        //    IEventResultReadyNotificationPollingAgent eventResultReadyNotificationPollingAgent, ISecondScreeningReminderPollingAgent secondScreeningReminderPollingAgent, IKynFirstNotificationPollingAgent kynFirstNotificationPollingAgent,
        //    IKynSecondNotificationPollingAgent kynSecondNotificationPollingAgent, ICallQueuePollingAgent callQueuePollingAgent, IPullBackCallQueueCustomerPollingAgent pullBackCallQueueCustomerPollingAgent, IPollForAppointmentReminderViaSms pollForAppointmentReminderViaSms,
        //    IPhysicianPartnerQueueFaxPollingAgent faxResultNotification, IPhysicianPartnerSendFaxPollingAgent faxNotificationPollingAgent, IPriorityInQueueNotificationPollingAgent pollForPriorityInQueue,
        //    ISystemGeneratedCallQueuePollingAgent systemGeneratedCallQueuePollingAgent, IFillEventsCallQueuePollingAgent fillEventsCallQueuePollingAgent, IDeletePastEventSystemGeneratedCallQueuePollingAgent deletePastEventSystemGeneratedCallQueue,
        //    IUpsellCallQueuePollingAgent upsellCallQueuePollingAgent, IConfirmationCallQueuePollingAgent confirmationCallQueuePollingAgent, INoShowCustomerPollingAgent noShowCustomerPollingAgent, IDirectMailActivityReminderPollingAgent directMailActivityReminderPollingAgent,
        //    ICorporateEventResultReadyNotificationPollingAgent corporateEventResultReadyNotificationPollingAgent)
        public NotificationService(INotificationPollingAgent notificationPollingAgent, ILogManager logManager, IResultNotificationPollingAgent resultNotificationPollingAgent, ISurveyEmailPollingAgent surveyEmailPollingAgent,
          IEvaluationReminderNotificationPollingAgent evaluationReminderNotificationPollingAgent, IScreeningReminderPollingAgent screeningReminderPollingAgent, IAnnualReminderPollingAgent annualReminderPollingAgent,
          IProspectCustomerFollowupPollingAgent prospectCustomerFollowupPollingAgent, ISettings settings, ITestUpsellPollingAgent testUpsellPollingAgent, IResultReadyNotificationPollingAgent resultReadyNotificationPollingAgent,
          IEventResultReadyNotificationPollingAgent eventResultReadyNotificationPollingAgent, ISecondScreeningReminderPollingAgent secondScreeningReminderPollingAgent, IKynFirstNotificationPollingAgent kynFirstNotificationPollingAgent,
          IKynSecondNotificationPollingAgent kynSecondNotificationPollingAgent, IPullBackCallQueueCustomerPollingAgent pullBackCallQueueCustomerPollingAgent, IPollForAppointmentReminderViaSms pollForAppointmentReminderViaSms,
          IPhysicianPartnerQueueFaxPollingAgent faxResultNotification, IPriorityInQueueNotificationPollingAgent pollForPriorityInQueue,
          IDeletePastEventSystemGeneratedCallQueuePollingAgent deletePastEventSystemGeneratedCallQueue, INoShowCustomerPollingAgent noShowCustomerPollingAgent, IDirectMailActivityReminderPollingAgent directMailActivityReminderPollingAgent,
          ICorporateEventResultReadyNotificationPollingAgent corporateEventResultReadyNotificationPollingAgent, IEventCustomNotificationPollingAgent eventCustomNotificationPolling,
            ISendNotiificationToNursePractitionerPollingAgent sendNotiificationToNursePractitionerPollingAgent,
            IPullBackPreAssessmentCallQueueCustomerPollingAgent pullBackPreAssessmentCallQueueCustomerPollingAgent) //IPhysicianPartnerSendFaxPollingAgent faxNotificationPollingAgent, 
        {
            InitializeComponent();
            _settings = settings;

            _pollThread = new IntervalWorkThread(notificationPollingAgent.PollForNotifications);
            _timer = new Timer(x => _pollThread.Trigger(), new object(), new TimeSpan(0), _interval);

            //_faxPollThread = new IntervalWorkThread(faxNotificationPollingAgent.PollForNotifications);
            //_faxTimer = new Timer(x => _faxPollThread.Trigger(), new object(), GetDueTime(_settings.FaxResultNotificationPushTime), new TimeSpan(0, _settings.FaxPushToApiServiceInterval, 0, 0));

            _pollThreadForEvaluationReminderNotification = new IntervalWorkThread(evaluationReminderNotificationPollingAgent.PollForEvaluationReminderNotification);
            _timerForEvaluationReminderNotification = new Timer(x => _pollThreadForEvaluationReminderNotification.Trigger(), new object(), GetDueTime(_settings.EvaluationReminderSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadScreeningReminderNotification = new IntervalWorkThread(screeningReminderPollingAgent.PollforSendingScreeningReminders);
            _timerScreeningReminderNotification = new Timer(x => _pollThreadScreeningReminderNotification.Trigger(), new object(), GetDueTime(_settings.ScreeningReminderSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadResultDeliveredNotification = new IntervalWorkThread(resultNotificationPollingAgent.PollforResultNotification);
            _timerResultDelieveredNotification = new Timer(x => _pollThreadResultDeliveredNotification.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, _settings.IntervalResultDelivery, 0, 0));

            _pollThreadAnnualReminderNotification = new IntervalWorkThread(annualReminderPollingAgent.PollforSendingAnnualReminders);
            _timerAnnualReminderNotification = new Timer(x => _pollThreadAnnualReminderNotification.Trigger(), new object(), GetDueTime(_settings.AnnualReminderSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadSurveyEmailNotification = new IntervalWorkThread(surveyEmailPollingAgent.PollforSurveyEmails);
            _timerSurveyEmailNotification = new Timer(x => _pollThreadSurveyEmailNotification.Trigger(), new object(), GetDueTime(_settings.SurveyEmailSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadProspectCustomerEmailNotification = new IntervalWorkThread(prospectCustomerFollowupPollingAgent.PollForSendingProspectCustomerReminders);
            _timerProspectCustomerEmailNotification = new Timer(x => _pollThreadProspectCustomerEmailNotification.Trigger(), new object(), GetDueTime(_settings.ProspectCustomerFollowUpSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadTestUpsellEmailNotification = new IntervalWorkThread(testUpsellPollingAgent.PollForTestUpsell);
            _timerTestUpsellEmailNotification = new Timer(x => _pollThreadTestUpsellEmailNotification.Trigger(), new object(), GetDueTime(_settings.TestUpsellSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadSecondResultReadyNotification = new IntervalWorkThread(resultReadyNotificationPollingAgent.PollforResultReadyNotification);
            _timerSecondResultReadyNotification = new Timer(x => _pollThreadSecondResultReadyNotification.Trigger(), new object(), GetDueTime(_settings.SecondResultReadyNotificationSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadEventResultReadyNotification = new IntervalWorkThread(eventResultReadyNotificationPollingAgent.PollforEventResultReadyNotification);
            _timerEventResultReadyNotification = new Timer(x => _pollThreadEventResultReadyNotification.Trigger(), new object(), GetDueTime(_settings.EventResultReadyNotificationSchedulingTime), new TimeSpan(0, _settings.IntervalEventResultReady, 0, 0));

            _pollThreadSecondScreeningReminderNotification = new IntervalWorkThread(secondScreeningReminderPollingAgent.PollforSendingScondScreeningReminders);
            _timerSecondScreeningReminderNotification = new Timer(x => _pollThreadSecondScreeningReminderNotification.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, _settings.IntervalSecondScreeningReminder, 0, 0));

            _pollThreadKynFirstNotification = new IntervalWorkThread(kynFirstNotificationPollingAgent.PollforKynNotification);
            _timerKynFirstNotification = new Timer(x => _pollThreadKynFirstNotification.Trigger(), new object(), GetDueTime(_settings.KynFirstNotificationSchedulingTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadKynSecondNotification = new IntervalWorkThread(kynSecondNotificationPollingAgent.PollforKynNotification);
            _timerKynSecondNotification = new Timer(x => _pollThreadKynSecondNotification.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, _settings.IntervalKynSecondNotification, 0, 0));

            //_pollThreadCallQueuePollingAgent = new IntervalWorkThread(callQueuePollingAgent.SendCustomersOnCallQueue);
            //_timerCallQueuePollingAgent = new Timer(x => _pollThreadCallQueuePollingAgent.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.CallQueueServiceInterval, 0));

            _pollThreadPullBackCallQueueCustomer = new IntervalWorkThread(pullBackCallQueueCustomerPollingAgent.PollforPullBackCallQueueCustomer);
            _timerPullBackCallQueueCustomer = new Timer(x => _pollThreadPullBackCallQueueCustomer.Trigger(), new object(), new TimeSpan(), new TimeSpan(0, 0, _settings.PullBackCallQueueCustomerServiceInterval, 0));

            _pollForAppointmentReminderViaSms = new IntervalWorkThread(pollForAppointmentReminderViaSms.PollforSendingAppointmentReminderViaSms);
            _timerForAppointmentReminderViaSms = new Timer(x => _pollForAppointmentReminderViaSms.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, _settings.SmsInterval, 0, 0));

            _pollForFaxResultNotification = new IntervalWorkThread(faxResultNotification.PollforFaxResultNotification);
            _timerForFaxResultNotification = new Timer(x => _pollForFaxResultNotification.Trigger(), new object(), GetDueTime(_settings.FaxResultNotificationQueueTime), new TimeSpan(0, 24, 0, 0));

            _pollThreadPriorityInQueueNotification = new IntervalWorkThread(pollForPriorityInQueue.PollForPriorityInQueueNotification);
            _timerPriorityInQueueNotification = new Timer(x => _pollThreadPriorityInQueueNotification.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.PriorityInQueueInterval, 0));

            //_pollThreadSystemGeneratedCallQueue = new IntervalWorkThread(systemGeneratedCallQueuePollingAgent.PollForCallQueue);
            //_timerSystemGeneratedCallQueue = new Timer(x => _pollThreadSystemGeneratedCallQueue.Trigger(), new object(), GetDueTime(_settings.SystemGeneratedCallQueueGenerationScheduleTime),
            //    new TimeSpan(0, _settings.SystemGeneratedCallQueueGenerationInterval, 0, 0));

            //_pollThreadFillEventsCallQueue = new IntervalWorkThread(fillEventsCallQueuePollingAgent.PollForCallQueue);
            //_timerFillEventsCallQueue = new Timer(x => _pollThreadFillEventsCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 10, 0));

            _pollThreadDeletePastEventSystemGeneratedCallQueue = new IntervalWorkThread(deletePastEventSystemGeneratedCallQueue.PollForCallQueueDeletion);
            _timerDeletePastEventSystemGeneratedCallQueue = new Timer(x => _pollThreadDeletePastEventSystemGeneratedCallQueue.Trigger(), new object(), GetDueTime(_settings.SystemGeneratedCallQueuePastEventDeleteScheduleTime),
                new TimeSpan(_settings.SystemGeneratedCallQueuePastEventDeleteInterval, 0, 0, 0));

            //_pollThreadUpsellCallQueue = new IntervalWorkThread(upsellCallQueuePollingAgent.PollForCallQueue);
            //_timerUpsellCallQueue = new Timer(x => _pollThreadUpsellCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 10, 0));

            //_pollThreadConfirmationCallQueue = new IntervalWorkThread(confirmationCallQueuePollingAgent.PollForCallQueue);
            //_timerConfirmationCallQueue = new Timer(x => _pollThreadConfirmationCallQueue.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, 10, 0));

            _pollThreadNoshowEventCustomerNotification = new IntervalWorkThread(noShowCustomerPollingAgent.PollForCustomerDoesNotAppearOnEvent);
            _timerNoshowEventCustomerNotification = new Timer(x => _pollThreadNoshowEventCustomerNotification.Trigger(), new object(), new TimeSpan(0), new TimeSpan(0, 0, _settings.NoShowCustomerScheduleInterval, 0));

            _pollThreadDirectMailActivityReminderNotification = new IntervalWorkThread(directMailActivityReminderPollingAgent.PollforDirectMailNotification);
            _timerDirectMailActivityReminderNotification = new Timer(x => _pollThreadDirectMailActivityReminderNotification.Trigger(), new object(), GetDueTime(_settings.DirectMailActivityReminderScheduleTime),
                    new TimeSpan(0, _settings.DirectMailActivityReminderInterval, 0, 0));

            _pollThreadCorporateEventResultReadyNotification = new IntervalWorkThread(corporateEventResultReadyNotificationPollingAgent.PollforEventResultReadyNotification);
            _timerCorporateEventResultReadyNotification = new Timer(x => _pollThreadCorporateEventResultReadyNotification.Trigger(), new object(), GetDueTime(_settings.CorporateEventResultReadyNotificationSchedulingTime), new TimeSpan(0, _settings.IntervalCorporateEventResultReady, 0, 0));
            
            _pollThreadCustomEventNotificationService = new IntervalWorkThread(eventCustomNotificationPolling.PollforCustomNotification);
            _timerCustomEventNotificationService = new Timer(x => _pollThreadCustomEventNotificationService.Trigger(), new object(), new TimeSpan(0), _interval);
            
            _pollThreadNotiificationToNursePractitioner = new IntervalWorkThread(sendNotiificationToNursePractitionerPollingAgent.PollForSendNotification);
            _timerNotiificationToNursePractitioner = new Timer(x => _pollThreadNotiificationToNursePractitioner.Trigger(), new object(), new TimeSpan(0, 0, 1, 0), new TimeSpan(0, 0, _settings.IntervalForSendNotificationToNursePractitioner, 0));

            _PollforPullBackPreAssessmentCallQueueCustomer = new IntervalWorkThread(pullBackPreAssessmentCallQueueCustomerPollingAgent.PollforPullBackPreAssessmentCallQueueCustomer);
            _timerPollforPullBackPreAssessmentCallQueueCustomer = new Timer(x => _pollThreadPullBackCallQueueCustomer.Trigger(), new object(), new TimeSpan(), new TimeSpan(0, 0, _settings.PullBackPreAssessmentCallQueueCustomerInterval, 0));

            _logger = logManager.GetLogger<NotificationService>();
        }

        private static TimeSpan GetDueTime(DateTime schedulingTime)
        {
            var firstNotificationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour, schedulingTime.Minute, schedulingTime.Second);
            var secondNotificationTime = firstNotificationTime.AddDays(1);
            var dt = DateTime.Now > firstNotificationTime ? secondNotificationTime : firstNotificationTime;

            return dt - DateTime.Now;
        }

        public override void Start(string[] args)
        {
            _logger.Info("Starting notification service...");
            _pollThread.Start();


            //_logger.Info("Starting fax notification service...");
            //_faxPollThread.Start();

            _logger.Info("Starting evalauation reminder notification service...");
            _pollThreadForEvaluationReminderNotification.Start();

            _logger.Info("Starting Result Delivery notification service...");
            _pollThreadResultDeliveredNotification.Start();

            _logger.Info("Starting Screening Reminder notification service...");
            _pollThreadScreeningReminderNotification.Start();

            _logger.Info("Starting Annual Reminder notification service...");
            _pollThreadAnnualReminderNotification.Start();

            _logger.Info("Starting Survey Email notification service...");
            _pollThreadSurveyEmailNotification.Start();

            _logger.Info("Starting Prospect Customer Follow up notification service...");
            _pollThreadProspectCustomerEmailNotification.Start();

            _logger.Info("Starting Test Upsell notification service...");
            _pollThreadTestUpsellEmailNotification.Start();

            _logger.Info("Starting Second Result Ready notification service...");
            _pollThreadSecondResultReadyNotification.Start();

            _logger.Info("Starting Event Result Ready notification service...");
            _pollThreadEventResultReadyNotification.Start();

            _logger.Info("Starting Second Screening Reminder notification service...");
            _pollThreadSecondScreeningReminderNotification.Start();

            _logger.Info("Starting Kyn First notification service...");
            _pollThreadKynFirstNotification.Start();

            _logger.Info("Starting Kyn Second notification service...");
            _pollThreadKynSecondNotification.Start();

            //_logger.Info("Starting Call Queue notification service...");
            //_pollThreadCallQueuePollingAgent.Start();

            _logger.Info("Starting Pull Back Call Queue Customer service...");
            _pollThreadPullBackCallQueueCustomer.Start();

            _logger.Info("Starting Appointment Reminder Via Sms service...");
            _pollForAppointmentReminderViaSms.Start();

            _logger.Info("Starting Fax Notification service...");
            _pollForFaxResultNotification.Start();

            _logger.Info("Starting Priority In Queue Notification service...");
            _pollThreadPriorityInQueueNotification.Start();

            //_logger.Info("Starting System Generated Call Queue Polling");
            //_pollThreadSystemGeneratedCallQueue.Start();

            //_logger.Info("Starting Fill Events Call Queue Polling");
            //_pollThreadFillEventsCallQueue.Start();

            //_logger.Info("Starting Upsell Call Queue Polling");
            //_pollThreadUpsellCallQueue.Start();

            //_logger.Info("Starting Confiramation Call Queue Polling");
            //_pollThreadConfirmationCallQueue.Start();

            _logger.Info("Starting Delete Past Event System Generated Call Queue Polling");
            _pollThreadDeletePastEventSystemGeneratedCallQueue.Start();

            _logger.Info("Starting No Show Customer Notification Polling");
            _pollThreadNoshowEventCustomerNotification.Start();

            _logger.Info("Starting Direct Mail Activity Reminder Polling");
            _pollThreadDirectMailActivityReminderNotification.Start();

            _logger.Info("Starting Corporate Event Result Ready notification service...");
            _pollThreadCorporateEventResultReadyNotification.Start();

            _logger.Info("Starting Custom Event Notification...");
            _pollThreadCustomEventNotificationService.Start();

            _logger.Info("Starting Send Notiification To Nurse Practitioner...");
            _pollThreadNotiificationToNursePractitioner.Start();

            _logger.Info("Starting Send Notiification To Pre-Assessment Call Queue...");
            _PollforPullBackPreAssessmentCallQueueCustomer.Start();

        }

        protected override void OnStop()
        {
            _logger.Info("Stopping notification service...");
            _pollThread.Stop();

            //_logger.Info("Stopping fax Notification service...");
            //_faxTimer.Dispose();
            //_faxPollThread.Stop();

            _logger.Info("Stopping evalauation reminder notification service...");
            _timerForEvaluationReminderNotification.Dispose();
            _pollThreadForEvaluationReminderNotification.Stop();


            _logger.Info("Stopping Result Delivery notification service...");
            _timerResultDelieveredNotification.Dispose();
            _pollThreadResultDeliveredNotification.Stop();


            _logger.Info("Stopping Screening Reminder service...");
            _timerScreeningReminderNotification.Dispose();
            _pollThreadScreeningReminderNotification.Stop();

            _logger.Info("Stopping Annual Reminder service...");
            _timerAnnualReminderNotification.Dispose();
            _pollThreadAnnualReminderNotification.Stop();


            _logger.Info("Stopping Survey Email notification service...");
            _timerSurveyEmailNotification.Dispose();
            _pollThreadSurveyEmailNotification.Stop();

            _logger.Info("Stopping Prospect Customer Follow up notification service...");
            _timerProspectCustomerEmailNotification.Dispose();
            _pollThreadProspectCustomerEmailNotification.Stop();

            _logger.Info("Stopping Test Upsell notification service...");
            _timerTestUpsellEmailNotification.Dispose();
            _pollThreadTestUpsellEmailNotification.Stop();

            _logger.Info("Stopping Second Result Ready notification service...");
            _timerSecondResultReadyNotification.Dispose();
            _pollThreadSecondResultReadyNotification.Stop();

            _logger.Info("Stopping Event Result Ready notification service...");
            _timerEventResultReadyNotification.Dispose();
            _pollThreadEventResultReadyNotification.Stop();

            _logger.Info("Stopping Second Screening Reminder service...");
            _timerSecondScreeningReminderNotification.Dispose();
            _pollThreadSecondScreeningReminderNotification.Stop();

            _logger.Info("Stopping Kyn First notification service...");
            _timerKynFirstNotification.Dispose();
            _pollThreadKynFirstNotification.Stop();

            _logger.Info("Stopping Kyn Second notification service...");
            _timerKynSecondNotification.Dispose();
            _pollThreadKynSecondNotification.Stop();

            //_logger.Info("Stopping Call Queue notification service...");
            //_timerCallQueuePollingAgent.Dispose();
            //_pollThreadCallQueuePollingAgent.Stop();

            _logger.Info("Stoping Pull Back Call Queue Customer service...");
            _timerPullBackCallQueueCustomer.Dispose();
            _pollThreadPullBackCallQueueCustomer.Stop();

            _logger.Info("Stoping Appointment Reminder Via Sms service...");
            _timerForAppointmentReminderViaSms.Dispose();
            _pollForAppointmentReminderViaSms.Stop();

            _logger.Info("Stoping Fax Notification polling service...");
            _timerForFaxResultNotification.Dispose();
            _pollForFaxResultNotification.Stop();

            _logger.Info("Stoping Priority In Queue Notification service...");
            _timerPriorityInQueueNotification.Dispose();
            _pollThreadPriorityInQueueNotification.Stop();

            //_logger.Info("stopping System Generated Call Queue Polling..");
            //_timerSystemGeneratedCallQueue.Dispose();
            //_pollThreadSystemGeneratedCallQueue.Stop();

            //_logger.Info("stopping Fill Events Call Queue Polling..");
            //_timerFillEventsCallQueue.Dispose();
            //_pollThreadFillEventsCallQueue.Stop();

            //_logger.Info("stopping Fill Events Call Queue Polling..");
            //_timerUpsellCallQueue.Dispose();
            //_pollThreadUpsellCallQueue.Stop();

            //_logger.Info("stopping Fill Events Call Queue Polling..");
            //_timerConfirmationCallQueue.Dispose();
            //_pollThreadConfirmationCallQueue.Stop();

            _logger.Info("stopping Delete Past Event System Generated Call Queue Polling..");
            _timerDeletePastEventSystemGeneratedCallQueue.Dispose();
            _pollThreadDeletePastEventSystemGeneratedCallQueue.Stop();

            _logger.Info("Stopping No Show Customer Polling ");
            _timerNoshowEventCustomerNotification.Dispose();
            _pollThreadNoshowEventCustomerNotification.Stop();

            _logger.Info("stopping Direct Mail Activity Reminder Polling");
            _timerDirectMailActivityReminderNotification.Dispose();
            _pollThreadDirectMailActivityReminderNotification.Stop();

            _logger.Info("Stopping Corporate Event Result Ready notification service...");
            _timerCorporateEventResultReadyNotification.Dispose();
            _pollThreadCorporateEventResultReadyNotification.Stop();

            _logger.Info("Stopping Custom Event Notification");
            _timerCustomEventNotificationService.Dispose();
            _pollThreadCustomEventNotificationService.Stop();

            _logger.Info("Stopping Send Notiification To Nurse Practitioner...");
            _timerNotiificationToNursePractitioner.Dispose();
            _pollThreadNotiificationToNursePractitioner.Stop();


            _logger.Info("Stoping Pull Back Pre- Assessment Call Queue Customer service...");
            _timerPollforPullBackPreAssessmentCallQueueCustomer.Dispose();
            _PollforPullBackPreAssessmentCallQueueCustomer.Stop();
        }
    }
}
