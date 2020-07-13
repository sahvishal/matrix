using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportMammographyFactory
    {
        PcpResultExportModel SetMammographyData(PcpResultExportModel model, MammogramTestResult testResult, bool useBlankValue = false);
    }
}