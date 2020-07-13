using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;


namespace Falcon.Jobs.PPExportService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();
                var serviceToRun = IoC.Resolve<ExportService>();

                var logger = IoC.Resolve<ILogManager>().GetLogger("Jobs_PPExportService");

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
                    .GetLogger("Jobs.PPExportService")
                    .Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
