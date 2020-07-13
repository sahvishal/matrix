using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.Jobs.FloridaBlueService
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();

                var logger = IoC.Resolve<ILogManager>().GetLogger("Jobs_FloridaBlueService");

                logger.Info("Starting Job");
                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                var serviceToRun = IoC.Resolve<FloridaBlueService>();

                if (Environment.UserInteractive)
                {
                    Task.Factory.StartNew(() => serviceToRun.Start(args));
                }
                else
                {
                    ServiceBase.Run(serviceToRun);
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger("Jobs.FloridaBlueService").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
