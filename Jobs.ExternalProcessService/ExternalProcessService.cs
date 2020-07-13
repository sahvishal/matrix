using System;
using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;

namespace Falcon.Jobs.ExternalProcessService
{
    public partial class ExternalProcessService : ServiceBase
    {
        private readonly ILogger _logger;

        private readonly Thread _movieMakerpollThread;

        private readonly Thread _pdfGenerationPolingAgent;

        private readonly Thread _htmlStreamPdfGenerationPolingAgent;

        private readonly Thread _convertSvgPolingAgent;

        private readonly Thread _movieFromAviPolingAgent;

        
        // Call Center
        private readonly Thread _callCenterCallQueueReportAgent;

        // Finance
        private readonly Thread _financeReportsAgent;

        // Scheduling 
        private readonly Thread _schedulingReportsAgent;

        //Medical
        private readonly Thread _medicalReportsAgent;

        //Operations
        private readonly Thread _operationCdImageStatusAgent;

        //Marketing
        private readonly Thread _marketingAbandonedProspectCustomerAgent;

        //Sales
        private readonly Thread _salesReportAgent;

        //User
        private readonly Thread _userCustomerEventCriticalAgent;

        public ExternalProcessService(IMovieMakerPollingAgent movieMakerPollingAgent, ILogManager logManager, IPdfGeneratorPollingAgent pdfGeneratorPollingAgent, IConvertSvgToImagePolingAgent convertSvgToImageAgent,
            ISchedulingReportsPollingAgent schedulingReportsPollingAgent, IFinanceReportsPollingAgent financeReportsPollingAgent, ICallCenterReportsPollingAgent callCenterReportsPollingAgent,
            IMarketingReportsPollingAgent marketingReportsPollingAgent, IMedicalReportsPollingAgent medicalReportsPollingAgent, ISalesReportsPollingAgent salesReportsPollingAgent,
            IUserReportsPollingAgent userReportsPollingAgent, IOperationReportsPollingAgent operationReportsPollingAgent

            )
        {
            InitializeComponent();
            _logger = logManager.GetLogger("External Process");

            _movieMakerpollThread = new Thread(movieMakerPollingAgent.PollForMpegMaking);
            
            _movieFromAviPolingAgent = new Thread(movieMakerPollingAgent.PollForMoviefromAviMaking);
            
            _pdfGenerationPolingAgent = new Thread(pdfGeneratorPollingAgent.PollForPdfGenerating);
            
            _htmlStreamPdfGenerationPolingAgent = new Thread(pdfGeneratorPollingAgent.PollForPdfFromHtmlStream);
            
            _convertSvgPolingAgent = new Thread(convertSvgToImageAgent.PollForConvertSvgToImage);
            


            //Call center
            _callCenterCallQueueReportAgent = new Thread(callCenterReportsPollingAgent.PollForCallQueueReportReports);
            
            //Finance
            _financeReportsAgent = new Thread(financeReportsPollingAgent.PollForFinanceReports);

            //Scheduling
            _schedulingReportsAgent = new Thread(schedulingReportsPollingAgent.PollForSchedulingReports);
            
            //Medical
            _medicalReportsAgent = new Thread(medicalReportsPollingAgent.PollForMedicalReports);

            // Operations
            _operationCdImageStatusAgent = new Thread(operationReportsPollingAgent.PollForCdImageStatusReports);
            
            //Marketing
            _marketingAbandonedProspectCustomerAgent = new Thread(marketingReportsPollingAgent.PollForAbandonedProspectCustomerReport);
            
            //Sales
            _salesReportAgent = new Thread(salesReportsPollingAgent.PollForSalesReport);
            

            //User
            _userCustomerEventCriticalAgent = new Thread(userReportsPollingAgent.PollForCustomerEventCriticalData);
            
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting Movie Making Polling thread...");
            _movieMakerpollThread.Start();

            Thread.Sleep(5000);
            _logger.Info("Starting Movie From Avi Polling thread...");
            _movieFromAviPolingAgent.Start();

            
            _logger.Info("Starting Pdf Generating Polling thread...");
            _pdfGenerationPolingAgent.Start();

            Thread.Sleep(5000);
            _logger.Info("Starting HTML Stream Pdf Generating Polling thread...");
            _htmlStreamPdfGenerationPolingAgent.Start();

            
            _logger.Info("Starting Convert SVG Polling thread...");
            _convertSvgPolingAgent.Start();

            
            _logger.Info("Starting Call Center Report ..");
            _callCenterCallQueueReportAgent.Start();

            _logger.Info("Starting Finance Report ..");
            _financeReportsAgent.Start();


            _logger.Info("Starting Scheduling Report ..");
            _schedulingReportsAgent.Start();

            _logger.Info("Starting Medical Report ..");
            _medicalReportsAgent.Start();

            _logger.Info("Starting Operation Report Polling thread...");
            _operationCdImageStatusAgent.Start();

            _logger.Info("Starting Marketing Report Polling thread...");
            _marketingAbandonedProspectCustomerAgent.Start();

            _logger.Info("Starting Sales Report Polling thread...");
            _salesReportAgent.Start();

            _logger.Info("Starting User Report Polling thread...");
            _userCustomerEventCriticalAgent.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            //_logger.Info("Stopping Movie Making Polling thread...");
            //_movieMakerpollThread.Abort();

            //_logger.Info("Stopping Pdf Generating Polling thread...");
            //_pdfGenerationPolingAgent.Stop();

            //_logger.Info("Stopping HTML Stream Pdf Generating Polling thread...");
            //_htmlStreamPdfGenerationPolingAgent.Stop();

            //_logger.Info("Stopping Convert SVG Polling thread...");
            //_convertSvgPolingAgent.Stop();

            //_logger.Info("Stopping Movie From AVI Polling thread...");
            //_movieFromAviPolingAgent.Stop();

            //_logger.Info("Stopping Call Center Report Polling thread...");
            //_callCenterCallQueueReportAgent.Stop();

            //_logger.Info("Stopping Finance Report Polling thread...");
            //_financeDetailOpenOrderAgent.Stop();

            //_financeUpsellAgent.Stop();

            //_financeCreditCardReconsileAgent.Stop();

            //_financeDailyRecapAgent.Stop();

            //_financeShippingRevenueSummaryAgent.Stop();

            //_financeCustomerOpenOrderAgent.Stop();

            //_financeCorporateInvoiceAgent.Stop();

            //_financeRefundRequestAgent.Stop();

            //_financeDailyRecapCustomerAgent.Stop();

            //_financeShippingRevenueDetailAgent.Stop();

            //_financeDeferredRevenueAgent.Stop();

            //_financeInsurancePaymentAgent.Stop();

            //_logger.Info("Stopping Scheduling Report Polling thread...");
            //_schedulingAppointmentBookedAgent.Stop();

            //_schedulingCancelledCustomerAgent.Stop();

            //_schedulingPublicEventVolumeAgent.Stop();

            //_schedulingCorporateEventVolumeAgent.Stop();

            //_schedulingCustomerScheduleAgent.Stop();

            //_schedulingNoShowCustomerAgent.Stop();

            //_schedulingCustomerExportAgent.Stop();

            //_schedulingRescheduleAppointmentAgent.Stop();

            //_schedulingEventCancelationAgent.Stop();

            //_schedulingTestBookedAgent.Stop();

            //_logger.Info("Stopping Medical  Report Polling thread...");
            //_medicalPhysicianReviewSummaryAgent.Stop();

            //_medicalPhysicianReviewAgent.Stop();

            //_medicalPhysicianQueueAgent.Stop();

            //_medicalPhysicianEventQueueAgent.Stop();

            //_medicalTestPerformedAgent.Stop();

            //_medicalKynCustomersAgent.Stop();

            //_medicalTechnicalLimitedScreeningAgent.Stop();

            //_medicalCustomerEventCriticalDataAgent.Stop();

            //_medicalPhysicianTestReviewAgent.Stop();

            //_logger.Info("Stopping Operation Reports thread...");
            //_operationCdImageStatusAgent.Stop();

            //_logger.Info("Stopping Marketing Report Polling thread...");
            //_marketingAbandonedProspectCustomerAgent.Stop();

            //_logger.Info("Stopping Sales Reports thread...");
            //_salesHospitalPartnerCustomerAgent.Stop();

            //_operationHospitalPartnerEventAgent.Stop();

            //_logger.Info("Stopping User Reports thread...");
            //_userCustomerEventCriticalAgent.Stop();
        }
    }
}
