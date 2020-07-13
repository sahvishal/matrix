using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportBoneMassFactory
    {
        PcpResultExportModel SetBoneMassData(PcpResultExportModel model, AwvBoneMassTestResult testResult, bool useBlankValue = false);
    }
}
