using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public abstract class BaseReportPollingAgent
    {

        protected readonly string Host = "";
        protected readonly int RedisDatabaseKey;

        protected BaseReportPollingAgent(ISettings settings)
        {
            Host = settings.RedisServerHost;
            RedisDatabaseKey = settings.RedisDatabaseKey;
        }

        protected void ProcessReports(GenericReportRequest request)
        {
            using (var streamWriter = new StreamWriter(request.CsvFilePath, false))
            {
                streamWriter.Write(request.Model);
                streamWriter.Close();
            }
        }

    }
}
