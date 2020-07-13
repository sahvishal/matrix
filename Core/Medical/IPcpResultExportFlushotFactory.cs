using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportFlushotFactory
    {
        PcpResultExportModel SetAwvFluShotData(PcpResultExportModel model, AwvFluShotTestResult testResult, bool useBlankValue = false);
        PcpResultExportModel SetFluShotData(PcpResultExportModel model, FluShotTestResult testResult, bool useBlankValue = false);
    }
}