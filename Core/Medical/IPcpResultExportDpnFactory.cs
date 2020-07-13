using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportDpnFactory
    {
        PcpResultExportModel SetDpnData(PcpResultExportModel model, DpnTestResult testResult, bool useBlankValue = false);
    }
}