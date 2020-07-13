using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.Jobs.AppointmentBookExportService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();
                var serviceToRun = IoC.Resolve<AppointmentBookedService>();

                var logger = IoC.Resolve<ILogManager>().GetLogger("AppointmentBookedService");

                logger.Info("Starting Job");
                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

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
                IoC.Resolve<ILogManager>()
                    .GetLogger("Jobs.AppointmentBookedService")
                    .Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
