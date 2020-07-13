using System;
using System.Net;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.Jobs.ResultPdfService
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

                IoC.Resolve<ILogManager>().GetLogger("Jobs.ResultPdfService").Info("Starting jobs...");

                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                
                var serviceToRun = IoC.Resolve<ResultPdfService>();

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
                IoC.Resolve<ILogManager>().GetLogger("Jobs.ResultPdfService").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
