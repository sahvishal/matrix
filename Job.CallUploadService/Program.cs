using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Medical.Impl;

namespace Falcon.Job.CallUploadService
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DependencyRegistrar.RegisterDependencies();
                var serviceToRun = IoC.Resolve<CallUploadService>();

                IoC.Resolve<ILogManager>().GetLogger("Jobs.CallUploadService").Info("Starting jobs...");

                var autoMapperBootstrapper = new AutoMapperBootstrapper();
                autoMapperBootstrapper.Bootstrap();

                if (Environment.UserInteractive)
                {
                    IoC.Resolve<MedicationUploadFileParserPollingAgent>().PollForParsingMedicationUpload();
                    //Task.Factory.StartNew(() => serviceToRun.Start(args));
                }
                else
                {
                    ServiceBase.Run(serviceToRun);
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger("Jobs.CallUploadService").Info("\n\nSystem Failure! Message: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
            }
        }
    }
}
