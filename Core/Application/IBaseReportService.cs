using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Application
{
    public interface IBaseReportService
    {
        string DownloadZipFile(MediaLocation mediaLocation, string csvfileName, long userId, ILogger logger);
        bool GetResponse(GenericReportRequest pub, bool append = false);
    }
}
