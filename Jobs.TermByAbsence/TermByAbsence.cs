using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using System;
using System.ServiceProcess;
using System.Threading;

namespace Jobs.TermByAbsence
{

    public partial class TermByAbsence : ServiceBase
    {


        private readonly Thread _pollForMemberTermByAbsenceSuscribre;

        private readonly ILogger _logger;

        public TermByAbsence(ILogManager logManager, IMemberTermByAbsenceSubscriber memberTermByAbsenceSubscriber)
        {
            InitializeComponent();

            _logger = logManager.GetLogger("Jobs.TermByAbsence");
            _logger.Info("TermByAbsence Call.");

            _pollForMemberTermByAbsenceSuscribre = new Thread(memberTermByAbsenceSubscriber.PollForMemerTermByAbsenceSubscriber);

            _logger.Info("TermByAbsence Call Complete.");
        }

        public void Start(string[] args)
        {


            _logger.Info("Starting Member Term By Absence Subscriber Service....");
            _pollForMemberTermByAbsenceSuscribre.Start();



            Thread.Sleep(5000);

        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }
        protected override void OnStop()
        {
            _logger.Info("Stopping Term By Absence service ...");



        }

    }
}
