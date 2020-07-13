using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Jobs.FloridaBlueOutboundService
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();

                var logger = IoC.Resolve<ILogManager>().GetLogger("Jobs_FloridaBlueOutboundService");

                logger.Info("Starting Job");
                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                var serviceToRun = IoC.Resolve<FloridaBlueOutboundService>();

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
                IoC.Resolve<ILogManager>().GetLogger("Jobs_FloridaBlueOutboundService").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
