using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvAbiFactory
    {
        PcpResultExportModel SetAwvAbiData(PcpResultExportModel model, AwvAbiTestResult testResult, bool useBlankValue = false);
    }
}
