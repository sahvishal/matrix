using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Finance;

namespace Falcon.Jobs.PPExportService
{
    partial class ExportService : ServiceBase
    {
        private readonly ILogger _logger;

        //private readonly IntervalWorkThread _pollThreadPhysicianPartnersPdfDownload;
        //private readonly Timer _timerPhysicianPartnersCustomerPdfDownload;
        //

        //private readonly IntervalWorkThread _pollThreadPhysicianPartnersAppointmentBookedReport;
        //private readonly Timer _timerPhysicianPartnersCustomerAppointmentBookedReport;

        //private readonly IntervalWorkThread _pollThreadPhysicianPartnersResultExport;
        //private readonly Timer _timerPhysicianPartnersResultExport;

        private readonly IntervalWorkThread _pollThreadPcpResultPdfDownload;
        private readonly Timer _timerPcpResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadPcpAppointmentBookedReport;
        private readonly Timer _timerPcpCustomerAppointmentBookedReport;

        private readonly IntervalWorkThread _pollThreadPcpResultExport;
        private readonly Timer _timerPcpResultExport;

        private readonly IntervalWorkThread _pollThreadWellmedResultPdfDownload;
        private readonly Timer _timerWellmedResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadWellmedAppointmentBookedReport;
        private readonly Timer _timerWellmedCustomerAppointmentBookedReport;

        private readonly IntervalWorkThread _pollThreadWellmedResultExport;
        private readonly Timer _timerWellmedResultExport;

        private readonly IntervalWorkThread _pollThreadHcpCaliforniaResultPdfDownload;
        private readonly Timer _timerHcpCaliforniaResultPdfDownloadPollingAgent;

        //Molina
        private readonly IntervalWorkThread _pollThreadMolinaResultPdfDownload;
        private readonly Timer _timerMolinaResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadMolinaAppointmentBookedReport;
        private readonly Timer _timerMolinaCustomerAppointmentBookedReport;

        private readonly IntervalWorkThread _pollThreadMolinaResultExport;
        private readonly Timer _timerMolinaResultExport;

        private readonly IntervalWorkThread _pollThreadUnlockCorporateEvents;
        private readonly Timer _timerUnlockCorporateEvents;

        private readonly IntervalWorkThread _pollThreadParseLockedEventFilePollingAgent;
        private readonly Timer _timerParseLockedEventFile;

        private readonly IntervalWorkThread _pollThreadLockCorporateEventPollingAgent;
        private readonly Timer _timerLockCorporateEventPollingAgent;

        private readonly IntervalWorkThread _pollHealthPlanIncorrectPhoneCustomerPollingAgent;
        private readonly Timer _timerHealthPlanIncorrectPhoneCustomerPollingAgent;

        private readonly IntervalWorkThread _pollhomeVisitRequestedCustomerExportPollingAgent;
        private readonly Timer _timerhomeVisitRequestedCustomerExportPollingAgent;

        private readonly IntervalWorkThread _pollThreadWellmedWeeklyAppointmentBookedReport;
        private readonly Timer _timerWellmedWeeklyCustomerAppointmentBookedReport;

        private readonly IntervalWorkThread _pollThreadNtspResultPdfDownload;
        private readonly Timer _timerNtspResultPdfDownloadPollingAgent;

        //private readonly IntervalWorkThread _pollThreadTestNotPerformedReport;
        //private readonly Timer _timerThreadTestNotPerformedReport;

        private readonly IntervalWorkThread _pollThreadHealthPlanOutreachCallReport;
        private readonly Timer _timerThreadHealthPlanOutreachCallReport;

        private readonly IntervalWorkThread _pollThreadMartinPointDailyAppointmentBookedReport;
        private readonly Timer _timerThreadMartinPointDailyAppointmentBookedReport;

        private readonly IntervalWorkThread _pollThreadPatientInputFileReport;
        private readonly Timer _timerThreadPatientInputFileReport;

        private readonly IntervalWorkThread _pollThreadBcbsResultPdfDownload;
        private readonly Timer _timerBcbsResultPdfDownloadPollingAgent;

        //private readonly IntervalWorkThread _pollThreadHealthPlanMemberStatusReportPollingAgent;
        //private readonly Timer _timerHealthPlanMemberStatusReportPollingAgent;

        //private readonly IntervalWorkThread _pollThreadFloridaBlueResultPdfDownload;
        //private readonly Timer _timerFloridaBlueResultPdfDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadDiabeticRetinopathyParserlogPollingAgent;
        private readonly Timer _timerDiabeticRetinopathyParserlogDownloadPollingAgent;

        private readonly IntervalWorkThread _pollThreadHcpCaAppointmentBookedPollingAgent;
        private readonly Timer _timerHcpCaAppointmentBookedPollingAgent;

        private readonly IntervalWorkThread _pollThreadParseWellmedLockedEventFilePollingAgent;
        private readonly Timer _timerParseWellmedLockedEventFile;

        private readonly IntervalWorkThread _pollThreadWellmedTxAppointmentBookedReport;
        private readonly Timer _timerWellmedTxCustomerAppointmentBookedReport;

        private readonly IntervalWorkThread _pollThreadGiftCertificateWellmedPollingAgent;
        private readonly Timer _timerGiftCertificateWellmedPollingAgent;

        //private readonly IntervalWorkThread _pollThreadHealthNowResultPdfDownloadPollingAgent;
        //private readonly Timer _timerHealthNowResultPdfDownloadPollingAgent;

        //private readonly IntervalWorkThread _pollThreadWellCareResultPdfDownloadPollingAgent;
        //private readonly Timer _timerWellCareResultPdfDownloadPollingAgent;
        /* IPhysicianPartnerResultPdfDownloadPollingAgent ppResultPdfDownloadPollingAgent, ILogManager logManager,
            IPhysicianPartnerAppointmentBookExportPollingAgent ppAppointmentBookExportPollingAgent, IPhysicianPartnerResultExportPollingAgent resultExportPollingAgent, ITestNotPerformedReportPollingAgent testNotPerformedReportPollingAgent,*/
        public ExportService(ISettings settings, ILogManager logManager,
            IPcpResultPdfDownloadPollingAgent pcpResultPdfDownloadPollingAgent, IPcpAppointmentBookExportPollingAgent pcpAppointmentBookExportPollingAgent, IPcpResultExportPollingAgent pcpResultExportPollingAgent,
            IWellmedResultPdfDownloadPollingAgent wellmedResultPdfDownloadPollingAgent, IWellmedAppointmentBookExportPollingAgent wellmedAppointmentBookExportPollingAgent,
            IWellmedResultExportPollingAgent wellmedResultExportPollingAgent, IHcpCaliforniaResultPdfDownloadPollingAgent hcpCaliforniaResultPdfDownloadPollingAgent,
            IMolinaResultPdfDownloadPollingAgent molinaResultPdfDownloadPollingAgent, IMolinaAppointmentBookExportPollingAgent molinaAppointmentBookExportPollingAgent, IMolinaResultExportPollingAgent molinaResultExportPollingAgent,
            IUnlockCorporateEventsPollingAgent unlockCorporateEventsPollingAgent, IParseLockedEventFilePollingAgent parseLockedEventFilePollingAgent, ILockCorporateEventPollingAgent lockCorporateEventPollingAgent,
            IHealthPlanIncorrectPhoneExportPollingAgent healthPlanIncorrectPhoneCustomerPollingAgent, IHealthPlanHomeVisitRequestedCustomerExportPollingAgent homeVisitRequestedCustomerExportPollingAgent,
            IWellmedWeeklyAppointmentBookExportPollingAgent wellmedWeeklyAppointmentBook, INtspResultPdfDownloadPollingAgent ntspResultPdfDownloadPollingAgent,
            IHealthPlanOutreachCallReportPollingAgent healthPlanOutreachCallReportPollingAgent, IMartinPointDailyAppointmentBookExportPollingAgent martinPointDailyAppointmentBookExportPollingAgent, IPatientInputFilePollingAgent patientInputFilePollingAgent,
            IBcbsResultPdfDownloadPollingAgent bcbsResultPdfDownloadPollingAgent,  IFloridaBlueResultPdfDownloadPollingAgent floridaBlueResultPdfDownloadPollingAgent,
            IDiabeticRetinopathyParserlogPollingAgent diabeticRetinopathyParserlogPollingAgent, IHcpCaAppointmentBookExportPollingAgent hcpCaAppointmentBookExportPolling, IParseWellmedLockedEventFilePollingAgent parseWellmedLockedEventFilePollingAgent,
            IWellmedCatalystAppointmentsBookedExportPollingAgent wellmedTxAppointmentsBookedExportPollingAgent,
            IGiftCertificateWellmedPollingAgent giftCertificateWellmedPollingAgent
            )//, IHealthPlanMemberStatusReportPollingAgent healthPlanMemberStatusReportPollingAgent, IHealthNowResultPdfDownloadPollingAgent healthNowResultPdfDownloadPollingAgent, IWellCareResultPdfDownloadPollingAgent wellCareResultPdfDownloadPollingAgent
        {

            InitializeComponent();
            _logger = logManager.GetLogger<ExportService>();


            //_pollThreadPhysicianPartnersPdfDownload = new IntervalWorkThread(ppResultPdfDownloadPollingAgent.PollForPdfDownload);
            //_timerPhysicianPartnersCustomerPdfDownload = new Timer(x => _pollThreadPhysicianPartnersPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime),
            //    new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //_pollThreadPhysicianPartnersAppointmentBookedReport = new IntervalWorkThread(ppAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            //_timerPhysicianPartnersCustomerAppointmentBookedReport = new Timer(s => _pollThreadPhysicianPartnersAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime),
            //    new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            //_pollThreadPhysicianPartnersResultExport = new IntervalWorkThread(resultExportPollingAgent.PollForResultExport);
            //_timerPhysicianPartnersResultExport = new Timer(s => _pollThreadPhysicianPartnersResultExport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime),
            //    new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));

            _pollThreadPcpResultPdfDownload = new IntervalWorkThread(pcpResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerPcpResultPdfDownloadPollingAgent = new Timer(x => _pollThreadPcpResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            _pollThreadPcpAppointmentBookedReport = new IntervalWorkThread(pcpAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerPcpCustomerAppointmentBookedReport = new Timer(s => _pollThreadPcpAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            _pollThreadPcpResultExport = new IntervalWorkThread(pcpResultExportPollingAgent.PollForResultExport);
            _timerPcpResultExport = new Timer(s => _pollThreadPcpResultExport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));


            //wellmed - results export
            _pollThreadWellmedResultPdfDownload = new IntervalWorkThread(wellmedResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerWellmedResultPdfDownloadPollingAgent = new Timer(x => _pollThreadWellmedResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));


            _pollThreadWellmedAppointmentBookedReport = new IntervalWorkThread(wellmedAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerWellmedCustomerAppointmentBookedReport = new Timer(s => _pollThreadWellmedAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            _pollThreadWellmedResultExport = new IntervalWorkThread(wellmedResultExportPollingAgent.PollForResultExport);
            _timerWellmedResultExport = new Timer(s => _pollThreadWellmedResultExport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));


            //hcpCalifornia - results Pdf
            _pollThreadHcpCaliforniaResultPdfDownload = new IntervalWorkThread(hcpCaliforniaResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerHcpCaliforniaResultPdfDownloadPollingAgent = new Timer(x => _pollThreadHcpCaliforniaResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //molina sftp Service

            _pollThreadMolinaResultPdfDownload = new IntervalWorkThread(molinaResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerMolinaResultPdfDownloadPollingAgent = new Timer(x => _pollThreadMolinaResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            _pollThreadMolinaAppointmentBookedReport = new IntervalWorkThread(molinaAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerMolinaCustomerAppointmentBookedReport = new Timer(s => _pollThreadMolinaAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            _pollThreadMolinaResultExport = new IntervalWorkThread(molinaResultExportPollingAgent.PollForResultExport);
            _timerMolinaResultExport = new Timer(s => _pollThreadMolinaResultExport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerResultReportDownloadInterval, 0, 0));

            //lock-Unlock Corporate Events
            _pollThreadLockCorporateEventPollingAgent = new IntervalWorkThread(lockCorporateEventPollingAgent.PollForLockCorporateEvent);
            _timerLockCorporateEventPollingAgent = new Timer(x => _pollThreadLockCorporateEventPollingAgent.Trigger(), new object(), GetDueTime(settings.LockCorporateEventScheduleTime), new TimeSpan(0, settings.LockCorporateEventScheduleInterval, 0, 0));

            _pollThreadParseLockedEventFilePollingAgent = new IntervalWorkThread(parseLockedEventFilePollingAgent.PollForParseLockedEventFiles);
          
            _timerParseLockedEventFile = new Timer(x => _pollThreadParseLockedEventFilePollingAgent.Trigger(), new object(), GetDueTime(settings.WellmedParseLockedEventScheduleTime), new TimeSpan(0, settings.WellmedParseLockedEventIntervalHours, 0, 0));

            _pollThreadUnlockCorporateEvents = new IntervalWorkThread(unlockCorporateEventsPollingAgent.PollForUnlockCorporateEvents);
            _timerUnlockCorporateEvents = new Timer(x => _pollThreadUnlockCorporateEvents.Trigger(), new object(), GetDueTime(settings.UnlockCorporateEventsScheduleTime), new TimeSpan(0, settings.UnlockCorporateEventsScheduleInterval, 0, 0));

            _pollHealthPlanIncorrectPhoneCustomerPollingAgent = new IntervalWorkThread(healthPlanIncorrectPhoneCustomerPollingAgent.PollForCustomerExport);
            _timerHealthPlanIncorrectPhoneCustomerPollingAgent = new Timer(x => _pollHealthPlanIncorrectPhoneCustomerPollingAgent.Trigger(), new object(), GetDueTime(settings.HealthPlanIncorrectPhoneExportScheduleTime), new TimeSpan(0, settings.HealthPlanCustomerListExportScheduleInterval, 0, 0));

            _pollhomeVisitRequestedCustomerExportPollingAgent = new IntervalWorkThread(homeVisitRequestedCustomerExportPollingAgent.PollForCustomerExport);
            _timerhomeVisitRequestedCustomerExportPollingAgent = new Timer(x => _pollhomeVisitRequestedCustomerExportPollingAgent.Trigger(), new object(), GetDueTime(settings.HealthPlanHomeVisitRequestedExportScheduleTime), new TimeSpan(0, settings.HealthPlanCustomerListExportScheduleInterval, 0, 0));

            //wellmed weekly appointment report
            _pollThreadWellmedWeeklyAppointmentBookedReport = new IntervalWorkThread(wellmedWeeklyAppointmentBook.PollForAppointmentBookExport);
            _timerWellmedWeeklyCustomerAppointmentBookedReport = new Timer(s => _pollThreadWellmedWeeklyAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.WellmedWeeklyAppointmentBookedReportTime),
                new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            //Ntsp - result PDF export
            _pollThreadNtspResultPdfDownload = new IntervalWorkThread(ntspResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerNtspResultPdfDownloadPollingAgent = new Timer(x => _pollThreadNtspResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //As per mail by Marissa Jensen on Sep 14, 2016, No testperformed report would be sent to healthplan sftp.
            //_pollThreadTestNotPerformedReport = new IntervalWorkThread(testNotPerformedReportPollingAgent.PollForTestNotPerformed);
            //_timerThreadTestNotPerformedReport = new Timer(x => _pollThreadTestNotPerformedReport.Trigger(), new object(), GetDueTime(settings.HealthPlanTestNotPerformedExportScheduleTime), new TimeSpan(0, settings.HealthPlanTestNotPerformedExportScheduleInterval, 0, 0));

            //Outreach Report
            _pollThreadHealthPlanOutreachCallReport = new IntervalWorkThread(healthPlanOutreachCallReportPollingAgent.PollForOutreachReport);
            _timerThreadHealthPlanOutreachCallReport = new Timer(x => _pollThreadHealthPlanOutreachCallReport.Trigger(), new object(), GetDueTime(settings.HealthPlanOutreachReportExportScheduleTime), new TimeSpan(0, settings.HealthPlanOutreachReportExportScheduleInterval, 0, 0));

            //Martin Point Daily Appointment Report
            _pollThreadMartinPointDailyAppointmentBookedReport = new IntervalWorkThread(martinPointDailyAppointmentBookExportPollingAgent.PollForAppointmentBookExport);
            _timerThreadMartinPointDailyAppointmentBookedReport = new Timer(x => _pollThreadMartinPointDailyAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.MartinPointAppointmentBookedReportScheduleTime), new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            //Patient Input file Report
            _pollThreadPatientInputFileReport = new IntervalWorkThread(patientInputFilePollingAgent.PollForPatientInputFiles);
            _timerThreadPatientInputFileReport = new Timer(x => _pollThreadPatientInputFileReport.Trigger(), new object(), GetDueTime(settings.PatientInputFileScheduleTime), new TimeSpan(0, settings.PatientInputFileScheduleInterval, 0, 0));

            //BCBS - result PDF export
            _pollThreadBcbsResultPdfDownload = new IntervalWorkThread(bcbsResultPdfDownloadPollingAgent.PollForPdfDownload);
            _timerBcbsResultPdfDownloadPollingAgent = new Timer(x => _pollThreadBcbsResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));


            ////BCBS HealthPlan Member Status Report
            //_pollThreadHealthPlanMemberStatusReportPollingAgent = new IntervalWorkThread(healthPlanMemberStatusReportPollingAgent.PollForMemberStatusReport);
            //_timerHealthPlanMemberStatusReportPollingAgent = new Timer(x => _pollThreadHealthPlanMemberStatusReportPollingAgent.Trigger(), new object(), GetDueTime(settings.HealthPlanMemberStatusReportScheduleTime), new TimeSpan(0, settings.HealthPlanMemberStatusReportScheduleInterval, 0, 0));

            //Florida Blue - result PDF export
            //_pollThreadFloridaBlueResultPdfDownload = new IntervalWorkThread(floridaBlueResultPdfDownloadPollingAgent.PollForPdfDownload);
            //_timerFloridaBlueResultPdfDownloadPollingAgent = new Timer(x => _pollThreadFloridaBlueResultPdfDownload.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));

            //Diabetic RetinopathyParser log
            _pollThreadDiabeticRetinopathyParserlogPollingAgent = new IntervalWorkThread(diabeticRetinopathyParserlogPollingAgent.PollForDiabeticRetinopathyParserlog);
            _timerDiabeticRetinopathyParserlogDownloadPollingAgent = new Timer(x => _pollThreadDiabeticRetinopathyParserlogPollingAgent.Trigger(), new object(), GetDueTime(settings.DiabeticRetinopathylogSchedule), new TimeSpan(0, settings.DiabeticRetinopathylogInterval, 0, 0));


            ////HealthNow Result Pdf
            //_pollThreadHealthNowResultPdfDownloadPollingAgent = new IntervalWorkThread(healthNowResultPdfDownloadPollingAgent.PollForPdfDownload);
            //_timerHealthNowResultPdfDownloadPollingAgent = new Timer(x => _pollThreadHealthNowResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));


            ////HealthNow Result Pdf
            //_pollThreadWellCareResultPdfDownloadPollingAgent = new IntervalWorkThread(wellCareResultPdfDownloadPollingAgent.PollForPdfDownload);
            //_timerWellCareResultPdfDownloadPollingAgent = new Timer(x => _pollThreadWellCareResultPdfDownloadPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerResultPdfDownloadTime), new TimeSpan(0, settings.PhysicianPartnerResultPdfDownloadInterval, 0, 0));


            _pollThreadWellmedTxAppointmentBookedReport = new IntervalWorkThread(wellmedTxAppointmentsBookedExportPollingAgent.PollForAppointmentBookExport);
            _timerWellmedTxCustomerAppointmentBookedReport = new Timer(s => _pollThreadWellmedTxAppointmentBookedReport.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            
            //Hcp Ca Custom Appointment Booked Report
            _pollThreadHcpCaAppointmentBookedPollingAgent = new IntervalWorkThread(hcpCaAppointmentBookExportPolling.PollForAppointmentBookExport);
            _timerHcpCaAppointmentBookedPollingAgent = new Timer(s => _pollThreadHcpCaAppointmentBookedPollingAgent.Trigger(), new object(), GetDueTime(settings.PhysicianPartnerAppointmentBookedReportDownloadTime),
                new TimeSpan(0, settings.PhysicianPartnerAppointmentBookedReportDownloadInterval, 0, 0));

            _pollThreadParseWellmedLockedEventFilePollingAgent = new IntervalWorkThread(parseWellmedLockedEventFilePollingAgent.PollForParseLockedEventFiles);
            _timerParseWellmedLockedEventFile = new Timer(x => _pollThreadParseWellmedLockedEventFilePollingAgent.Trigger(), new object(), GetDueTime(settings.WellmedParseLockedEventScheduleTime), new TimeSpan(0, settings.WellmedParseLockedEventIntervalHours, 0, 0));
       
            //Wellmed  - Gift Certificate Wellmed 
            _pollThreadGiftCertificateWellmedPollingAgent = new IntervalWorkThread(giftCertificateWellmedPollingAgent.PollGiftCertificateWellmedReport);
            _timerGiftCertificateWellmedPollingAgent = new Timer(x => _pollThreadGiftCertificateWellmedPollingAgent.Trigger(), new object(), GetDueTime(settings.WellmedGiftCertificateScheduleTime), new TimeSpan(0, settings.WellmedGiftCertificateIntervalHours, 0, 0));
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
            _logger.Info("Export Service Started");
            //_pollThreadPhysicianPartnersPdfDownload.Start();
            //_pollThreadPhysicianPartnersAppointmentBookedReport.Start();
            //_pollThreadPhysicianPartnersResultExport.Start();
            _pollThreadPcpResultPdfDownload.Start();
            _pollThreadPcpAppointmentBookedReport.Start();
            _pollThreadPcpResultExport.Start();

            _pollThreadWellmedResultPdfDownload.Start();
            _pollThreadWellmedAppointmentBookedReport.Start();
            _pollThreadWellmedResultExport.Start();
            
            _pollThreadHcpCaliforniaResultPdfDownload.Start();

            //molina sftp Service
            _pollThreadMolinaResultPdfDownload.Start();
            _pollThreadMolinaAppointmentBookedReport.Start();
            _pollThreadMolinaResultExport.Start();

            //lock-Unlock Corporate Events
            _logger.Info("Starting Locked Corporate Event Service");
            _pollThreadLockCorporateEventPollingAgent.Start();

            _logger.Info("Starting parsing Locked Corporate Event Service");
            _pollThreadParseLockedEventFilePollingAgent.Start();

            _logger.Info("Starting Unlock Locked Corporate Event Service");
            _pollThreadUnlockCorporateEvents.Start();

            _logger.Info("Starting Health Plan Incorrect Phone Customer Export");
            _pollHealthPlanIncorrectPhoneCustomerPollingAgent.Start();

            _logger.Info("Starting Health Plan Home Visit Requested Customer Export");
            _pollhomeVisitRequestedCustomerExportPollingAgent.Start();

            _logger.Info("Starting Wellmed Weekly Appointment Report");
            _pollThreadWellmedWeeklyAppointmentBookedReport.Start();

            _logger.Info("Starting NTSP Result Pdf Polling Agent");
            _pollThreadNtspResultPdfDownload.Start();

            //As per mail by Marissa Jensen on Sep 14, 2016, No testperformed report would be sent to healthplan sftp.
            //_logger.Info("Starting Test Not Performed Polling Agent");
            //_pollThreadTestNotPerformedReport.Start();

            _logger.Info("Starting Outreach Report Polling Agent");
            _pollThreadHealthPlanOutreachCallReport.Start();

            _logger.Info("Starting Martin Point Customer Appointment Booked Polling Agent");
            _pollThreadMartinPointDailyAppointmentBookedReport.Start();

            _logger.Info("Starting Patient Input File Polling Agent");
            _pollThreadPatientInputFileReport.Start();

            _logger.Info("Starting BCBS Result Pdf Polling Agent");
            _pollThreadBcbsResultPdfDownload.Start();

            //_logger.Info("Starting Health Plan Member Status Report Polling Agent");
            //_pollThreadHealthPlanMemberStatusReportPollingAgent.Start();

            //_logger.Info("Starting Florida Blue Result Pdf Polling Agent");
            //_pollThreadFloridaBlueResultPdfDownload.Start();

            _logger.Info("Starting Diabetic Retinopathy Parser Log Polling Agent");
            _pollThreadDiabeticRetinopathyParserlogPollingAgent.Start();

            //_logger.Info("Starting HealthNow Result Pdf on sftp");
            //_pollThreadHealthNowResultPdfDownloadPollingAgent.Start();

            //_logger.Info("Starting WellCare Result Pdf on sftp");
            //_pollThreadWellCareResultPdfDownloadPollingAgent.Start();

            _logger.Info("Starting HCP CA Custom Appointment Booked Report Polling Agent");
            _pollThreadHcpCaAppointmentBookedPollingAgent.Start();

            _logger.Info("Starting Parse Wellmed Locked Event File Polling Agent");
            _pollThreadParseWellmedLockedEventFilePollingAgent.Start();

            _logger.Info("Starting  WellmedTX  Polling Agent");
            _pollThreadWellmedTxAppointmentBookedReport.Start();

            _logger.Info("Starting Wellmed Gift Certificate Polling Agent ...");
            _pollThreadGiftCertificateWellmedPollingAgent.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            //_timerPhysicianPartnersCustomerPdfDownload.Dispose();
            //_pollThreadPhysicianPartnersPdfDownload.Stop();


            //_timerPhysicianPartnersCustomerAppointmentBookedReport.Dispose();
            //_pollThreadPhysicianPartnersAppointmentBookedReport.Stop();

            //_timerPhysicianPartnersResultExport.Dispose();
            //_pollThreadPhysicianPartnersResultExport.Stop();

            _timerPcpResultPdfDownloadPollingAgent.Dispose();
            _pollThreadPcpResultPdfDownload.Stop();

            _timerPcpCustomerAppointmentBookedReport.Dispose();
            _pollThreadPcpAppointmentBookedReport.Stop();

            _timerPcpResultExport.Dispose();
            _pollThreadPcpResultExport.Stop();

            _timerWellmedResultPdfDownloadPollingAgent.Dispose();
            _pollThreadWellmedResultPdfDownload.Stop();

            _timerWellmedCustomerAppointmentBookedReport.Dispose();
            _pollThreadWellmedAppointmentBookedReport.Stop();

            _timerWellmedResultExport.Dispose();
            _pollThreadWellmedResultExport.Stop();

            _timerHcpCaliforniaResultPdfDownloadPollingAgent.Dispose();
            _pollThreadHcpCaliforniaResultPdfDownload.Stop();

            //Molina
            _timerMolinaResultPdfDownloadPollingAgent.Dispose();
            _pollThreadMolinaResultPdfDownload.Stop();

            _timerMolinaCustomerAppointmentBookedReport.Dispose();
            _pollThreadMolinaAppointmentBookedReport.Stop();

            _timerMolinaResultExport.Dispose();
            _pollThreadMolinaResultExport.Stop();

            //lock-Unlock Corporate Events
            _logger.Info("Stopping Locked Corporate Events");
            _timerLockCorporateEventPollingAgent.Dispose();
            _pollThreadLockCorporateEventPollingAgent.Stop();

            _logger.Info("Stopping Parsing Locked Corporate Events");
            _timerParseLockedEventFile.Dispose();
            _pollThreadParseLockedEventFilePollingAgent.Stop();

            _logger.Info("Stopping Unlock Locked Corporate Events");
            _timerUnlockCorporateEvents.Dispose();
            _pollThreadUnlockCorporateEvents.Stop();

            _logger.Info("Stopping Health Plan Customer List Export ");
            _timerHealthPlanIncorrectPhoneCustomerPollingAgent.Dispose();
            _pollHealthPlanIncorrectPhoneCustomerPollingAgent.Stop();

            _logger.Info("Stopping Health Plan Customer List Export ");
            _timerhomeVisitRequestedCustomerExportPollingAgent.Dispose();
            _pollhomeVisitRequestedCustomerExportPollingAgent.Stop();

            _logger.Info("Stopping Wellmed Weekly Appointment Export ");
            _timerWellmedWeeklyCustomerAppointmentBookedReport.Dispose();
            _pollThreadWellmedWeeklyAppointmentBookedReport.Stop();

            _logger.Info("Stopping NTSP Result Pdf Polling Agent ");
            _timerNtspResultPdfDownloadPollingAgent.Dispose();
            _pollThreadNtspResultPdfDownload.Stop();

            //As per mail by Marissa Jensen on Sep 14, 2016, No testperformed report would be sent to healthplan sftp.
            //_logger.Info("Stopping Test Not Performed Reports Polling Agent ");
            //_timerThreadTestNotPerformedReport.Dispose();
            //_pollThreadTestNotPerformedReport.Stop();

            _logger.Info("Stopping Outreach Report Export Polling Agent ");
            _timerThreadHealthPlanOutreachCallReport.Dispose();
            _pollThreadHealthPlanOutreachCallReport.Stop();

            _logger.Info("Stopping Martin Point Customer Appointment Booked Polling Agent ");
            _timerThreadMartinPointDailyAppointmentBookedReport.Dispose();
            _pollThreadMartinPointDailyAppointmentBookedReport.Stop();


            _logger.Info("Stopping Patient Input File Polling Agent");
            _timerThreadPatientInputFileReport.Dispose();
            _pollThreadPatientInputFileReport.Stop();

            _logger.Info("Stopping BCBS Result Pdf Polling Agent ");
            _timerBcbsResultPdfDownloadPollingAgent.Dispose();
            _pollThreadBcbsResultPdfDownload.Stop();

            //As per mail by Marissa Jensen on Oct 10 2017, Member Status Report should never been auto posted to Health Plan
            //_logger.Info("Stopping Health Plan Member Status Report Polling Agent");
            //_timerHealthPlanMemberStatusReportPollingAgent.Dispose();
            //_pollThreadHealthPlanMemberStatusReportPollingAgent.Stop();

            //_logger.Info("Stopping Florida Blue Result Pdf Polling Agent ");
            //_timerFloridaBlueResultPdfDownloadPollingAgent.Dispose();
            //_pollThreadFloridaBlueResultPdfDownload.Stop();

            _logger.Info("Stopping Diabetic Retinopathy Parser Log Polling Agent ");
            _timerDiabeticRetinopathyParserlogDownloadPollingAgent.Dispose();
            _pollThreadDiabeticRetinopathyParserlogPollingAgent.Stop();

            //_logger.Info("Stopping HealthNow Result Pdf Download Polling Agent ");
            //_timerHealthNowResultPdfDownloadPollingAgent.Dispose();
            //_pollThreadHealthNowResultPdfDownloadPollingAgent.Stop();

            //_logger.Info("Stopping WellCare Result Pdf Download Polling Agent ");
            //_timerWellCareResultPdfDownloadPollingAgent.Dispose();
            //_pollThreadWellCareResultPdfDownloadPollingAgent.Stop();

            _logger.Info("Stopping HCP CA Custom Appointment Booked Report Polling Agent");
            
            _timerHcpCaAppointmentBookedPollingAgent.Dispose();
            _pollThreadHcpCaAppointmentBookedPollingAgent.Stop();

            _logger.Info("Parse Wellmed Locked Event File Polling Agent");
            _timerParseWellmedLockedEventFile.Dispose();
            _pollThreadParseWellmedLockedEventFilePollingAgent.Stop();

            _logger.Info("Stopping WellmedTX  Polling Agent");
            _timerWellmedTxCustomerAppointmentBookedReport.Dispose();
            _pollThreadWellmedTxAppointmentBookedReport.Stop();
            _logger.Info("Stopping Export Service...");

            _logger.Info("Stopping Wellmed Gift Certificate Polling Agent ...");
            _timerGiftCertificateWellmedPollingAgent.Dispose();
            _pollThreadGiftCertificateWellmedPollingAgent.Stop();

        }
    }
}
