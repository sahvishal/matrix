using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportDiabeticNeuropathyFactory
    {
        PcpResultExportModel SetDiabeticNeuropathyData(PcpResultExportModel model, DiabeticNeuropathyTestResult testResult, bool useBlankValue = false);
    }
}