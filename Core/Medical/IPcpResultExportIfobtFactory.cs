using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportIfobtFactory
    {
        PcpResultExportModel SetIfobtlobinData(PcpResultExportModel model, IFOBTTestResult testResult, bool useBlankValue = false);
    }
}