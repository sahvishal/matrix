using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.Jobs
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();
                var servicesToRun = new ConsoleServiceBase[]
                                        {
                                            IoC.Resolve<NotificationService>()
                                        };

                IoC.Resolve<ILogManager>().GetLogger("Jobs").Info("Starting jobs...");

                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                if (Environment.UserInteractive)
                {
                    foreach (var serviceBase in servicesToRun)
                    {
                        ConsoleServiceBase @base = serviceBase;
                        Task.Factory.StartNew(() => @base.Start(args));
                    }
                }
                else
                {
                    ServiceBase.Run(servicesToRun);
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger("Jobs").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
