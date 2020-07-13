using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportDiabeticRetinopathyFactory
    {
        PcpResultExportModel SetDiabeticRetinopathyData(PcpResultExportModel model, DiabeticRetinopathyTestResult testResult, bool useBlankValue = false);
    }
}