using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportOsteoporosisFactory
    {
        PcpResultExportModel SetOsteoporosisData(PcpResultExportModel model, OsteoporosisTestResult testResult, bool useBlankValue = false);
    }
}