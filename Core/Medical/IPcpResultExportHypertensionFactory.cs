using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportHypertensionFactory
    {
        PcpResultExportModel SetHypertensionData(PcpResultExportModel model, HypertensionTestResult testResult);
    }
}
