using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medicare;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.Jobs.MedicareService
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

                var serviceToRun = IoC.Resolve<MedicareJobService>();

                IoC.Resolve<ILogManager>().GetLogger("MedicareJobService").Info("Starting jobs...");

                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();


                if (Environment.UserInteractive)
                {
                    //IoC.Resolve<ISyncCustomerResultPollingAgent>().Sync();
                    //IoC.Resolve<ISyncCustomerPollingAgent>().Sync();
                    //IoC.Resolve<ISyncHealthPlanPollingAgent>().Sync();
                    //IoC.Resolve<ISyncCustomerResultPollingAgent>().Sync();
                    //IoC.Resolve<ISyncRapsPollingAgent>().Sync();
                    //IoC.Resolve<ISyncEventTestPollingAgent>().Sync();
                    //IoC.Resolve<ISyncResultsReadyForCodingPollingAgent>().PollForSync();
                    Task.Factory.StartNew(() => serviceToRun.Start(args));
                }
                else
                {
                    ServiceBase.Run(serviceToRun);
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger("MedicareJobService").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
