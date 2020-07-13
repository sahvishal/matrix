using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportVisionFactory
    {
        PcpResultExportModel SetVisionData(PcpResultExportModel model, VisionTestResult testResult, bool useBlankValue = false);
    }
}
