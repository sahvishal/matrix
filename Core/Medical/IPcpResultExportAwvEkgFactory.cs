using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvEkgFactory
    {
        PcpResultExportModel SetAwvEkgData(PcpResultExportModel model, AwvEkgTestResult testResult, bool useBlankValue = false);
    }
}
