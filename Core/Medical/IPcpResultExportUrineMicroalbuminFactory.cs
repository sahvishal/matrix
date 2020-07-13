using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportUrineMicroalbuminFactory
    {
        PcpResultExportModel SetUrineMicroalbuminData(PcpResultExportModel model, UrineMicroalbuminTestResult testResult, bool useBlankValue = false);
    }
}