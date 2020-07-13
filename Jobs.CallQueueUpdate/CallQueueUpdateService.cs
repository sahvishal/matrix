using System.ServiceProcess;
using System.Threading;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Interfaces;

namespace Falcon.Jobs.CallQueueUpdate
{
    partial class CallQueueUpdateService : ServiceBase
    {
        private readonly ILogger _logger;

        private readonly Thread _callQueueCustomerUpdateCustomerThread;
        private readonly Thread _callQueueCustomerUpdateAppointmentThread;
        private readonly Thread _callQueueCustomerUpdateCancellationThread;

        public CallQueueUpdateService(ILogManager logManager, ICallQueueCustomerPollingAgent callQueueCustomerPollingAgent)
        {
            _logger = logManager.GetLogger("CallQueueCustomerPollingAgent");
            InitializeComponent();
            _callQueueCustomerUpdateCustomerThread = new Thread(callQueueCustomerPollingAgent.PollForUpdateCustomerFlag);
            _callQueueCustomerUpdateAppointmentThread = new Thread(callQueueCustomerPollingAgent.PollForUpdateAppointmentFlag);
            _callQueueCustomerUpdateCancellationThread = new Thread(callQueueCustomerPollingAgent.PollForUpdateCancellationFlag);
        }

        public void Start(string[] args)
        {
            _logger.Info("Starting Call Queue Customer Update Customer Thread...");
            _callQueueCustomerUpdateCustomerThread.Start();

            Thread.Sleep(5000);
            _logger.Info("Starting Call Queue Customer Update Appointment Thread...");
            _callQueueCustomerUpdateAppointmentThread.Start();

            Thread.Sleep(5000);
            _logger.Info("Starting Call Queue Customer Update Cancellation Thread...");
            _callQueueCustomerUpdateCancellationThread.Start();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }


        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
