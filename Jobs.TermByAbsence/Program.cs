using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Jobs.TermByAbsence
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();
                IoC.Resolve<ILogManager>().GetLogger("Jobs.TermByAbsence").Info("Starting jobs...");

                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                var serviceToRun = IoC.Resolve<TermByAbsence>();

                if (Environment.UserInteractive)
                {
                   // IoC.Resolve<Falcon.App.Core.Medical.IMemberTermByAbsenceService>().SubscribeForEligibiltyUpdate(1201);
                   // IoC.Resolve<Falcon.App.Core.Medical.IMemberUploadbyAcesPollingAgent>().PollForMemberUploadbyAces();
                    //Task.Factory.StartNew(() => serviceToRun.Start(args));
                }
                else
                {
                    ServiceBase.Run(serviceToRun);
                }
            }

            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger("Jobs.TermByAbsence").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
