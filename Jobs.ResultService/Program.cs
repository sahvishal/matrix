using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.Jobs.ResultService
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

                IoC.Resolve<ILogManager>().GetLogger("Jobs").Info("Starting jobs...");

                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                var serviceToRun = IoC.Resolve<Service>();

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
                IoC.Resolve<ILogManager>().GetLogger("Jobs.ResultService").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
