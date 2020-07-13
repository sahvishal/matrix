using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Sales;

namespace Falcon.Jobs.ReportingService
{
    partial class ReportingService : ServiceBase
    {
        private readonly IntervalWorkThread _pollThreadTestPerformedReportPolling;
        private readonly Timer _timerTestPerformedReportPolling;

        private readonly IntervalWorkThread _pollThreaDailyPatientRecapReportPollingAgent;
        private readonly Timer _timerDailyPatientRecapReportPollingAgent;

        private readonly IntervalWorkThread _pollThreadBcbsMiServiceReportPollingAgent;
        private readonly Timer _timerBcbsMiServiceReportPollingAgent;

        private readonly IntervalWorkThread _pollThreadBcbsMiIncorrectPhoneExport;
        private readonly Timer _timerBcbsMiIncorrectPhoneExport;

        //private readonly IntervalWorkThread _pollThreadBcbsMiHomeVisitRequestExport;
        //private readonly Timer _timerBcbsMiHomeVisitRequestExport;

        private readonly IntervalWorkThread _pollThreadBcbsMiPcpResultMailedReportExport;
        private readonly Timer _timerBcbsMiBcbsMiPcpResultMailedReportExport;

        private readonly IntervalWorkThread _pollThreadBcbsMiMemberResultMailedReportExport;
        private readonly Timer _timerBcbsMiBcbsMiMemberResultMailedReportExport;

        private readonly IntervalWorkThread _pollThreadWellCarePcpSummaryLogReportExport;
        private readonly Timer _timerWellCarePcpSummaryLogReportExport;

        private readonly IntervalWorkThread _pollThreadWellCarePcpSummaryLogEasyChoiceReportExport;
        private readonly Timer _timerWellCarePcpSummaryLogEasyChoiceReportExport;

        private readonly IntervalWorkThread _pollThreadHealthPlanGiftCertificateReportExport;
        private readonly Timer _timerHealthPlanGiftCertificateReportExport;

        private readonly IntervalWorkThread _pollThreadAnthemHomeVisitReportExport;
        private readonly Timer _timerAnthemHomeVisitReportExport;

        private readonly IntervalWorkThread _pollThreadAnthemIncorrectPhoneNumberReportExport;
        private readonly Timer _timerAnthemIncorrectPhoneNumberReportExport;

        //private readonly IntervalWorkThread _pollThreadHourlyAppointmentBookedReportExport;
        //private readonly Timer _timerHourlyAppointmentBookedReportExport;

        //private readonly IntervalWorkThread _pollThreadHourlyOutreachCallReportExport;
        //private readonly Timer _timerHourlyOutreachCallReportExport;

        private readonly IntervalWorkThread _pollThreadDailyVolumeReportExport;
        private readonly Timer _timerDailyVolumeReportExport;

        //private readonly IntervalWorkThread _pollThreadGmsEventListExport;
        //private readonly Timer _timerGmsEventListExport;

        //private readonly IntervalWorkThread _pollThreadGmsCustomerListExport;
        //private readonly Timer _timerGmsCustomerListExport;

        private readonly IntervalWorkThread _pollThreadEventScheduleReportExport;
        private readonly Timer _timerEventScheduleReportExport;

        private readonly IntervalWorkThread _pollThreadMailRoundCustomersReport;
        private readonly Timer _timerMailRoundCustomersReport;

        //private readonly IntervalWorkThread _pollThreadGmsCallParsing;
        //private readonly Timer _timerGmsCallParsing;

        private readonly IntervalWorkThread _pollThreadBiWeeklyMicroAlbuminFobtReport;
        private readonly Timer _timerBiWeeklyMicroAlbuminFobt;

        private readonly IntervalWorkThread _pollThreadNonTargetableReport;
        private readonly Timer _timerNonTargetable;

        private readonly IntervalWorkThread _pollThreadPotentialPcpChangeReport;
        private readonly Timer _timerPotentialPcpChange;

        private readonly IntervalWorkThread _pollThreadHousecallOutreachReport;
        private readonly Timer _timerHousecallOutreachReport;

        private readonly IntervalWorkThread _pollThreadHouseCallHafResultExport;
        private readonly Timer _timerHouseCallHafResultExport;

        private readonly IntervalWorkThread _pollThreadWellmedMemberStatusReport;
        private readonly Timer _timerWellmedMemberStatusReport;

        private readonly IntervalWorkThread _pollThreadUniversalMemberReport;
        private readonly Timer _timerUniversalMemberReport;

        private readonly IntervalWorkThread _pollThreadUniversalProviderReport;
        private readonly Timer _timerUniversalProviderReport;

        private readonly IntervalWorkThread _pollThreadCustomerConsentDataReport;
        private readonly Timer _timerCustomerConsentDataReport;

        //private readonly IntervalWorkThread _pollThreadGmsExcludedCustomerReport;
        //private readonly Timer _timerGmsExcludedCustomeReport;

        private readonly ILogger _logger;


        public ReportingService(ILogManager logManager, ITestPerformedReportPollingAgent testPerformedReportPollingAgent, ISettings settings, IDailyPatientRecapReportPollingAgent dailyPatientRecapReportPollingAgent,
            IBcbsMiTestPerformedReportPollingAgent bcbsMiTestPerformedReportPolling, IBcbsMiIncorrectPhoneExportPollingAgent bcbsMiIncorrectPhoneExportPollingAgent,
            IBcbsMiPcpResultMailedReportPollingAgent bcbsMiPcpResultMailedReportPollingAgent,
            IBcbsMemberResultMailedReportPollingAgent bcbsMemberResultMailedReportPollingAgent, IWellCarePcpSummaryLogReportPollingAgent wellCarePcpSummaryLogReportPollingAgent,
            IWellCarePcpSummaryLogEasyChoiceReportPollingAgent wellCarePcpSummaryLogEasyChoiceReportPollingAgent, IAnthemHomeVisitRequestedCustomerExportPollingAgent anthemHomeVisitRequestedExport,
            IAnthemIncorrectPhoneNumberPollingAgent anthemIncorrectPhoneNumberExport, IHealthPlanGiftCertificateReportPollingAgent healthPlanGiftCertificateReportPollingAgent,
            //IHourlyAppointmentBookedReportPollingAgent hourlyAppointmentBookedReportPollingAgent,
            //IHourlyOutreachCallReportPollingAgent hourlyOutreachCallReportPollingAgent,
            IDailyVolumeReportPollingAgent dailyVolumeReportPollingAgent, 
            IEventScheduleReportPollingAgent eventScheduleReportPollingAgent, IMailRoundCustomersReportPollingAgent mailRoundCustomersReportPollingAgent,
            IBiWeeklyMicroAlbuminFobtPollingAgent biWeeklyMicroAlbuminFobtPollingAgent, INonTargetableReportPollingAgent nonTargetableReportPollingAgent, IPotentialPcpChangePollingAgent potentialPcpChangePollingAgent,
            IHousecallOutreachCallReportPollingAgent housecallOutreachCallReportPollingAgent, IHouseCallHafResultExportPollingAgent houseCallHafResultExportPollingAgent, IWellmedMemberStatusReportPollingAgent wellmedMemberStatusReportPollingAgent,
            IUniversalMemberPollingAgent universalMemberPollingAgent, IUniversalProviderPollingAgent universalProviderPollingAgent, ISendConsentDataPollingAgent sendConsentDataPollingAgent, IGmsExcludedCustomerPollingAgent gmsExcludedCustomerPollingAgent)
        {
            InitializeComponent();

            _pollThreadTestPerformedReportPolling = new IntervalWorkThread(testPerformedReportPollingAgent.PollForTestPerformedReports);
            _timerTestPerformedReportPolling = new Timer(x => _pollThreadTestPerformedReportPolling.Trigger(), new object(), GetDueTime(settings.TestPerformReportScheduleTime), new TimeSpan(0, settings.TestPerformReportInterval, 0, 0));

            _pollThreaDailyPatientRecapReportPollingAgent = new IntervalWorkThread(dailyPatientRecapReportPollingAgent.PollForDailyPatientRecapReport);
            _timerDailyPatientRecapReportPollingAgent = new Timer(x => _pollThreaDailyPatientRecapReportPollingAgent.Trigger(), new object(), GetDueTime(settings.DailyPatientRecapReportScheduleTime), new TimeSpan(0, settings.DailyPatientRecapReportInterval, 0, 0));


            _pollThreadBcbsMiServiceReportPollingAgent = new IntervalWorkThread(bcbsMiTestPerformedReportPolling.PollforCustomTestPerformedReport);
            _timerBcbsMiServiceReportPollingAgent = new Timer(x => _pollThreadBcbsMiServiceReportPollingAgent.Trigger(), new object(), GetDueTime(settings.BcbsMiServiceReportScheduleTime), new TimeSpan(0, settings.BcbsMiServiceReportIntervalHours, 0, 0));

            //Bcbs Mi Incorrect Phone Export
            _pollThreadBcbsMiIncorrectPhoneExport = new IntervalWorkThread(bcbsMiIncorrectPhoneExportPollingAgent.PollForExport);
            _timerBcbsMiIncorrectPhoneExport = new Timer(x => _pollThreadBcbsMiIncorrectPhoneExport.Trigger(), new object(), GetDueTime(settings.IncorrectPhoneExportDownloadTime), new TimeSpan(1, 0, 0, 0));

            //Bcbs Mi Home Visit Request Export
            //_pollThreadBcbsMiHomeVisitRequestExport = new IntervalWorkThread(bcbsMiHomeVisitRequestExportPollingAgent.PollForExport);
            //_timerBcbsMiHomeVisitRequestExport = new Timer(x => _pollThreadBcbsMiHomeVisitRequestExport.Trigger(), new object(), GetDueTime(settings.HomeVisitExportDownloadTime), new TimeSpan(1, 0, 0, 0));

            //Bcbs Mi Pcp Result Mailed Report Export
            _pollThreadBcbsMiPcpResultMailedReportExport = new IntervalWorkThread(bcbsMiPcpResultMailedReportPollingAgent.PollForPcpReultMailedReportExport);
            _timerBcbsMiBcbsMiPcpResultMailedReportExport = new Timer(x => _pollThreadBcbsMiPcpResultMailedReportExport.Trigger(), new object(), GetDueTime(settings.BcbsMiPcpResultMailedReportScheduleTime), new TimeSpan(0, settings.BcbsMiPcpResultMailedReportIntervalHours, 0, 0));


            //Bcbs Mi Member Result Mailed Report Export
            _pollThreadBcbsMiMemberResultMailedReportExport = new IntervalWorkThread(bcbsMemberResultMailedReportPollingAgent.PollforMemberResultMailedReport);
            _timerBcbsMiBcbsMiMemberResultMailedReportExport = new Timer(x => _pollThreadBcbsMiMemberResultMailedReportExport.Trigger(), new object(), GetDueTime(settings.BcbsMiMemberResultMailedReportScheduleTime), new TimeSpan(0, settings.BcbsMiMemberResultMailedReportIntervalHours, 0, 0));


            //WellCare Pcp Summary Log Report Export
            _pollThreadWellCarePcpSummaryLogReportExport = new IntervalWorkThread(wellCarePcpSummaryLogReportPollingAgent.PollForPcpLogSummaryReportExport);
            _timerWellCarePcpSummaryLogReportExport = new Timer(x => _pollThreadWellCarePcpSummaryLogReportExport.Trigger(), new object(), GetDueTime(settings.WellCarePcpSummaryLogReportScheduleTime), new TimeSpan(0, settings.WellCarePcpSummaryLogReportIntervalHours, 0, 0));

            //WellCare Pcp Summary Log Easy Choice Report Export
            _pollThreadWellCarePcpSummaryLogEasyChoiceReportExport = new IntervalWorkThread(wellCarePcpSummaryLogEasyChoiceReportPollingAgent.PollForPcpLogSummaryReportExport);
            _timerWellCarePcpSummaryLogEasyChoiceReportExport = new Timer(x => _pollThreadWellCarePcpSummaryLogEasyChoiceReportExport.Trigger(), new object(), GetDueTime(settings.WellCarePcpSummaryLogReportScheduleTime), new TimeSpan(0, settings.WellCarePcpSummaryLogReportIntervalHours, 0, 0));

            //WellCare Pcp Summary Log Easy Choice Report Export
            _pollThreadHealthPlanGiftCertificateReportExport = new IntervalWorkThread(healthPlanGiftCertificateReportPollingAgent.PollForReportGeneration);
            _timerHealthPlanGiftCertificateReportExport = new Timer(x => _pollThreadHealthPlanGiftCertificateReportExport.Trigger(), new object(), GetDueTime(settings.GiftCertificateReportScheduleTime), new TimeSpan(1, 0, 0, 0));

            //Anthem Home Visit Report Export
            _pollThreadAnthemHomeVisitReportExport = new IntervalWorkThread(anthemHomeVisitRequestedExport.PollForCustomerExport);
            _timerAnthemHomeVisitReportExport = new Timer(x => _pollThreadAnthemHomeVisitReportExport.Trigger(), new object(), GetDueTime(settings.HealthPlanHomeVisitRequestedExportScheduleTime), new TimeSpan(0, settings.HealthPlanCustomerListExportScheduleInterval, 0, 0));


            //Anthem Incorrect Phone Number Report Export
            _pollThreadAnthemIncorrectPhoneNumberReportExport = new IntervalWorkThread(anthemIncorrectPhoneNumberExport.PollForCustomerExport);
            _timerAnthemIncorrectPhoneNumberReportExport = new Timer(x => _pollThreadAnthemIncorrectPhoneNumberReportExport.Trigger(), new object(), GetDueTime(settings.HealthPlanIncorrectPhoneExportScheduleTime), new TimeSpan(0, settings.HealthPlanCustomerListExportScheduleInterval, 0, 0));

            //Hourly Appointment Booked Report Export
            //_pollThreadHourlyAppointmentBookedReportExport = new IntervalWorkThread(hourlyAppointmentBookedReportPollingAgent.PollForHourlyReport);
            //_timerHourlyAppointmentBookedReportExport = new Timer(x => _pollThreadHourlyAppointmentBookedReportExport.Trigger(), new object(), GetDueTimeMinute(settings.HourlyAppointmentBookedScheduleTime), new TimeSpan(0, 0, settings.HourlyAppointmentBookedIntervalHours, 0));

            //Hourly Outreach Call Report Export
            //_pollThreadHourlyOutreachCallReportExport = new IntervalWorkThread(hourlyOutreachCallReportPollingAgent.PollForHourlyOutreachCallReport);
            //_timerHourlyOutreachCallReportExport = new Timer(x => _pollThreadHourlyOutreachCallReportExport.Trigger(), new object(), GetDueTimeMinute(settings.HourlyOutreachCallReportScheduleTime), new TimeSpan(0, 0, settings.HourlyOutreachCallReportIntervalHours, 0));


            _pollThreadDailyVolumeReportExport = new IntervalWorkThread(dailyVolumeReportPollingAgent.PollForDailyVolumeReport);
            _timerDailyVolumeReportExport = new Timer(x => _pollThreadDailyVolumeReportExport.Trigger(), new object(), GetDueTimeMinute(settings.DailyVolumeReportScheduleTime), new TimeSpan(0, settings.DailyVolumeReportIntervalInHour, 0, 0));

            //GMS Event List Report Export
            //_pollThreadGmsEventListExport = new IntervalWorkThread(eventListGmsPollingAgent.PollForEventList);
            //_timerGmsEventListExport = new Timer(x => _pollThreadGmsEventListExport.Trigger(), new object(), GetDueTimeMinute(settings.GmsEventReportScheduleTime), new TimeSpan(0, 0, settings.GmsEventReportIntervalMinutes, 0));

            //GMS Customer List Report Export
            //_pollThreadGmsCustomerListExport = new IntervalWorkThread(gmsCallQueueCustomerReportPollingAgent.PollForReportGeneration);
            //_timerGmsCustomerListExport = new Timer(x => _pollThreadGmsCustomerListExport.Trigger(), new object(), GetDueTime(settings.GmsCustomerReportScheduleTime), new TimeSpan(0, settings.GmsCustomerReportIntervalHours, 0, 0));

            //Event Schedule Report Export
            _pollThreadEventScheduleReportExport = new IntervalWorkThread(eventScheduleReportPollingAgent.PollForEventScheduleReort);
            _timerEventScheduleReportExport = new Timer(x => _pollThreadEventScheduleReportExport.Trigger(), new object(), GetDueTime(settings.EventScheduleAccountScheduleTime), new TimeSpan(0, settings.EventScheduleAccountInterval, 0, 0));

            //Matrix Report Export
            _pollThreadMailRoundCustomersReport = new IntervalWorkThread(mailRoundCustomersReportPollingAgent.PollMailRoundCustomersReport);
            _timerMailRoundCustomersReport = new Timer(x => _pollThreadMailRoundCustomersReport.Trigger(), new object(), GetDueTime(settings.MailRoundCustomersReportScheduleTime), new TimeSpan(0, settings.MailRoundCustomersReportIntervalHours, 0, 0));

            //GMS Call Parsing
            //_pollThreadGmsCallParsing = new IntervalWorkThread(gmsCallParserPollingAgent.PollForCallParsing);
            //_timerGmsCallParsing = new Timer(x => _pollThreadGmsCallParsing.Trigger(), new object(), GetDueTime(settings.GmsDialerFileParsingScheduleTime), new TimeSpan(0, settings.GmsDialerFileParsingIntervalHours, 0, 0));

            //BiWeekly MicroAlbumin and Fobt Report WELLMED
            _pollThreadBiWeeklyMicroAlbuminFobtReport = new IntervalWorkThread(biWeeklyMicroAlbuminFobtPollingAgent.PollForBiWeeklyMicroAlbuminFobt);
            _timerBiWeeklyMicroAlbuminFobt = new Timer(x => _pollThreadBiWeeklyMicroAlbuminFobtReport.Trigger(), new object(), GetDueTime(settings.BiWeeklyMicroAlbuminFobtScheduleTime), new TimeSpan(0, settings.BiWeeklyMicroAlbuminFobtIntervalHours, 0, 0));

            //Non Targetable Report WELLMED
            _pollThreadNonTargetableReport = new IntervalWorkThread(nonTargetableReportPollingAgent.PollForNonTargetableCustomer);
            _timerNonTargetable = new Timer(x => _pollThreadNonTargetableReport.Trigger(), new object(), GetDueTime(settings.NonTargetableReportScheduleTime), new TimeSpan(0, settings.NonTargetableReportIntervalHours, 0, 0));

            //Potential Pcp Change Report WELLMED
            _pollThreadPotentialPcpChangeReport = new IntervalWorkThread(potentialPcpChangePollingAgent.PollForPotentialPcpChange);
            _timerPotentialPcpChange = new Timer(x => _pollThreadPotentialPcpChangeReport.Trigger(), new object(), GetDueTime(settings.PcpChangeReportScheduleTime), new TimeSpan(0, settings.PcpChangeReportIntervalHours, 0, 0));

            //Housecall outreach report
            _pollThreadHousecallOutreachReport = new IntervalWorkThread(housecallOutreachCallReportPollingAgent.PollForOutreachReport);
            _timerHousecallOutreachReport = new Timer(x => _pollThreadHousecallOutreachReport.Trigger(), new object(), GetDueTime(settings.HousecallOutreachReportExportScheduleTime), new TimeSpan(0, settings.HousecallOutreachReportExportScheduleInterval, 0, 0));

            //HouseCall HAF Result Export
            _pollThreadHouseCallHafResultExport = new IntervalWorkThread(houseCallHafResultExportPollingAgent.PollForResultExport);
            _timerHouseCallHafResultExport = new Timer(s => _pollThreadHouseCallHafResultExport.Trigger(), new object(), GetDueTime(settings.HousecallHafResultReportDownloadTime),
                new TimeSpan(0, settings.HousecallHafResultReportDownloadInterval, 0, 0));

            //Wellmed Member Status Report
            _pollThreadWellmedMemberStatusReport = new IntervalWorkThread(wellmedMemberStatusReportPollingAgent.PollForMemberStatusReport);
            _timerWellmedMemberStatusReport = new Timer(s => _pollThreadWellmedMemberStatusReport.Trigger(), new object(), GetDueTime(settings.WellmedMemberStatusReportScheduleTime),
                new TimeSpan(0, settings.WellmedMemberStatusReportScheduleInterval, 0, 0));

            //Universal Member Report
            _pollThreadUniversalMemberReport = new IntervalWorkThread(universalMemberPollingAgent.PollforUniversalMembers);
            _timerUniversalMemberReport = new Timer(x => _pollThreadUniversalMemberReport.Trigger(), new object(), GetDueTime(settings.UniversalMemberReportScheduleTime), new TimeSpan(0, settings.UniversalMemberReportInterval, 0, 0));

            //Universal Provider Report
            _pollThreadUniversalProviderReport = new IntervalWorkThread(universalProviderPollingAgent.PollforUniversalProviders);
            _timerUniversalProviderReport = new Timer(x => _pollThreadUniversalProviderReport.Trigger(), new object(), GetDueTime(settings.UniversalProviderReportScheduleTime), new TimeSpan(0, settings.UniversalProviderReportInterval, 0, 0));

            //Customer Consent Data Report
            _pollThreadCustomerConsentDataReport = new IntervalWorkThread(sendConsentDataPollingAgent.PollForSendConsentData);
            _timerCustomerConsentDataReport = new Timer(x => _pollThreadCustomerConsentDataReport.Trigger(), new object(), GetDueTime(settings.CustomerConsentDataReportScheduleTime), new TimeSpan(0, settings.CustomerConsentDataReportInterval, 0, 0));

            //_pollThreadGmsExcludedCustomerReport = new IntervalWorkThread(gmsExcludedCustomerPollingAgent.PollForReport);
            //_timerGmsExcludedCustomeReport = new Timer(s => _pollThreadGmsExcludedCustomerReport.Trigger(), new object(), GetDueTime(settings.GmsExcludeCustomerReportDownloadTime), new TimeSpan(0, settings.GmsExcludeReportDownloadCustomerIntervalInHours, 0, 0));

            _logger = logManager.GetLogger("Reporting Service");
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
            var log = IoC.Resolve<ILogManager>().GetLogger("Reporting Service");
            log.Info(string.Format("Next Time Service Run: " + dt));

            return dt - DateTime.Now;
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting Reporting service ...");

            _logger.Info("Starting Test Performed Reporting service ...");
            _pollThreadTestPerformedReportPolling.Start();

            _logger.Info("Starting Daily Patient Recap Reporting service ...");
            _pollThreaDailyPatientRecapReportPollingAgent.Start();

            _logger.Info("Starting BCBS MI service report service ...");
            _pollThreadBcbsMiServiceReportPollingAgent.Start();

            _logger.Info("Starting BCBS MI Incorrect Phone Export Service ...");
            _pollThreadBcbsMiIncorrectPhoneExport.Start();

            //_logger.Info("Starting BCBS MI Home Visit Request Export Service ...");
            //_pollThreadBcbsMiHomeVisitRequestExport.Start();

            _logger.Info("Starting Bcbs Mi Pcp Result Mailed Report Export ...");
            _pollThreadBcbsMiPcpResultMailedReportExport.Start();

            _logger.Info("Starting Bcbs Mi Members Result Mailed Report Export ...");
            _pollThreadBcbsMiMemberResultMailedReportExport.Start();

            _logger.Info("Starting WellCare PCP Summary Log Report Export ...");
            _pollThreadWellCarePcpSummaryLogReportExport.Start();

            _logger.Info("Starting WellCare PCP Summary Log Easy Choice Report Export ...");
            _pollThreadWellCarePcpSummaryLogEasyChoiceReportExport.Start();

            _logger.Info("Starting Health Plan Gift Certificate Report Export ...");
            _pollThreadHealthPlanGiftCertificateReportExport.Start();

            _logger.Info("Starting Anthem Home visit Report Export ...");
            _pollThreadAnthemHomeVisitReportExport.Start();

            _logger.Info("Starting Anthem Incorrect Phone Number Report Export ...");
            _pollThreadAnthemIncorrectPhoneNumberReportExport.Start();

            //_logger.Info("Starting Hourly Appointment Booked Report Export ...");
            //_pollThreadHourlyAppointmentBookedReportExport.Start();

            //_logger.Info("Starting Hourly Outreach Call Report Export ...");
            //_pollThreadHourlyOutreachCallReportExport.Start();

            _logger.Info("Starting Daily Volume Report Export ...");
            _pollThreadDailyVolumeReportExport.Start();

            //_logger.Info("Starting GMS Event Report Export ...");
            //_pollThreadGmsEventListExport.Start();

            //_logger.Info("Starting GMS Customer Report Export ...");
            //_pollThreadGmsCustomerListExport.Start();

            _logger.Info("Starting Event Schedule Report Export service ...");
            _pollThreadEventScheduleReportExport.Start();

            _logger.Info("Starting Matrix Report Export service ...");
            _pollThreadMailRoundCustomersReport.Start();

            //_logger.Info("Starting GMS Call Parsing service ...");
            //_pollThreadGmsCallParsing.Start();

            _logger.Info("Starting BiWeekly MicroAlbumin Fobt Report service ...");
            _pollThreadBiWeeklyMicroAlbuminFobtReport.Start();

            _logger.Info("Starting Non Targetable Report service ...");
            _pollThreadNonTargetableReport.Start();

            _logger.Info("Starting Potential PCP change Report service ...");
            _pollThreadPotentialPcpChangeReport.Start();

            _logger.Info("Starting Housecall Outreach Report service ...");
            _pollThreadHousecallOutreachReport.Start();

            _logger.Info("Starting HouseCall HAF Result Report Polling Agent");
            _pollThreadHouseCallHafResultExport.Start();

            _logger.Info("Starting Wellmed Member Status Report Polling Agent");
            _pollThreadWellmedMemberStatusReport.Start();

            _logger.Info("Starting Universal Member Report Polling Agent");
            _pollThreadUniversalMemberReport.Start();

            _logger.Info("Starting Universal Provider Report Polling Agent");
            _pollThreadUniversalProviderReport.Start();

            _logger.Info("Starting Customer Consent Data Report Polling Agent");
            _pollThreadCustomerConsentDataReport.Start();

            //_logger.Info("Starting GMS Exclude Customer Reporting service ...");
            //_pollThreadGmsExcludedCustomerReport.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping Reporting service ...");

            _logger.Info("Stopping Test Performed Reporting service ...");
            _timerTestPerformedReportPolling.Dispose();
            _pollThreadTestPerformedReportPolling.Stop();

            _logger.Info("Stopping Daily Patient Recap Reporting service ...");
            _timerDailyPatientRecapReportPollingAgent.Dispose();
            _pollThreaDailyPatientRecapReportPollingAgent.Stop();

            _logger.Info("Stopping BCBS MI service report service ...");
            _timerBcbsMiServiceReportPollingAgent.Dispose();
            _pollThreadBcbsMiServiceReportPollingAgent.Stop();

            _logger.Info("Stopping BCBS MI Incorrect Phone Export Service ...");
            _timerBcbsMiIncorrectPhoneExport.Dispose();
            _pollThreadBcbsMiIncorrectPhoneExport.Stop();

            //_logger.Info("Stopping BCBS MI Home Visit Request Export Service ...");
            //_timerBcbsMiHomeVisitRequestExport.Dispose();
            //_pollThreadBcbsMiHomeVisitRequestExport.Stop();

            _logger.Info("Stopping Bcbs Mi Pcp Result Mailed Report Export ...");
            _timerBcbsMiBcbsMiPcpResultMailedReportExport.Dispose();
            _pollThreadBcbsMiPcpResultMailedReportExport.Stop();

            _logger.Info("Stopping Bcbs Mi Members Result Mailed Report Export ...");
            _timerBcbsMiBcbsMiMemberResultMailedReportExport.Dispose();
            _pollThreadBcbsMiMemberResultMailedReportExport.Stop();

            _logger.Info("Stopping WellCare PCP Summary Log Report Export ...");
            _timerWellCarePcpSummaryLogReportExport.Dispose();
            _pollThreadWellCarePcpSummaryLogReportExport.Stop();

            _logger.Info("Stopping WellCare PCP Summary Log Easy Choice Report Export ...");
            _timerWellCarePcpSummaryLogEasyChoiceReportExport.Dispose();
            _pollThreadWellCarePcpSummaryLogEasyChoiceReportExport.Stop();

            _logger.Info("Stopping Health Plan Gift Certificate Report Export ...");
            _timerHealthPlanGiftCertificateReportExport.Dispose();
            _pollThreadHealthPlanGiftCertificateReportExport.Stop();

            _logger.Info("Stopping Anthem Home Visit Report Export ...");
            _timerAnthemHomeVisitReportExport.Dispose();
            _pollThreadAnthemHomeVisitReportExport.Stop();

            _logger.Info("Stopping Anthem Incorrect Phone Number Report Export ...");
            _timerAnthemIncorrectPhoneNumberReportExport.Dispose();
            _pollThreadAnthemIncorrectPhoneNumberReportExport.Stop();

            //_logger.Info("Stopping Hourly Appointment Booked Report Export ...");
            //_timerHourlyAppointmentBookedReportExport.Dispose();
            //_pollThreadHourlyAppointmentBookedReportExport.Stop();

            //_logger.Info("Stopping Hourly Outreach Call Report Export ...");
            //_timerHourlyOutreachCallReportExport.Dispose();
            //_pollThreadHourlyOutreachCallReportExport.Stop();

            _logger.Info("Stopping Daily Volume Report Export ...");
            _timerDailyVolumeReportExport.Dispose();
            _pollThreadDailyVolumeReportExport.Stop();

            //_logger.Info("Starting GMS Event Report Export ...");
            //_timerGmsEventListExport.Dispose();
            //_pollThreadGmsEventListExport.Stop();

            //_logger.Info("Starting GMS Customer Report Export ...");
            //_timerGmsCustomerListExport.Dispose();
            //_pollThreadGmsCustomerListExport.Stop();

            _logger.Info("stopping Event Schedule Report Export service ...");
            _timerEventScheduleReportExport.Dispose();
            _pollThreadEventScheduleReportExport.Stop();

            _logger.Info("stopping Matrix Report Export service ...");
            _timerMailRoundCustomersReport.Dispose();
            _pollThreadMailRoundCustomersReport.Stop();

            //_logger.Info("Stopping GMS Call Parsing service ...");
            //_timerGmsCallParsing.Dispose();
            //_pollThreadGmsCallParsing.Stop();

            _logger.Info("Stopping BiWeekly MicroAlbumin Fobt Report service ...");
            _timerBiWeeklyMicroAlbuminFobt.Dispose();
            _pollThreadBiWeeklyMicroAlbuminFobtReport.Stop();

            _logger.Info("Stopping Non Targetable Report service ...");
            _timerNonTargetable.Dispose();
            _pollThreadNonTargetableReport.Stop();

            _logger.Info("Stopping Potential PCP change Report service ...");
            _timerPotentialPcpChange.Dispose();
            _pollThreadPotentialPcpChangeReport.Stop();

            _logger.Info("Stopping Housecall Outreach Report service ...");
            _timerHousecallOutreachReport.Dispose();
            _pollThreadHousecallOutreachReport.Stop();

            _logger.Info("Stopping HouseCall HAF Result Report Polling Agent");
            _timerHouseCallHafResultExport.Dispose();
            _pollThreadHouseCallHafResultExport.Stop();

            _logger.Info("Stopping Wellmed Member Status Report Polling Agent");
            _timerWellmedMemberStatusReport.Dispose();
            _pollThreadWellmedMemberStatusReport.Stop();

            _logger.Info("Stopping Universal Member Report Polling Agent");
            _timerUniversalMemberReport.Dispose();
            _pollThreadUniversalMemberReport.Stop();

            _logger.Info("Stopping Universal Provider Report Polling Agent");
            _timerUniversalProviderReport.Dispose();
            _pollThreadUniversalProviderReport.Stop();

            _logger.Info("Stopping Customer Consent Data Report Polling Agent");
            _timerCustomerConsentDataReport.Dispose();
            _pollThreadCustomerConsentDataReport.Stop();

            //_logger.Info("Stopping GMS Exclude Customer Reporting service ...");
            //_timerGmsExcludedCustomeReport.Dispose();
            //_pollThreadGmsExcludedCustomerReport.Stop();
        }
    }
}

