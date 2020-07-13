using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportQualityMeasuresFactory
    {
        PcpResultExportModel SetQualityMeasuresData(PcpResultExportModel model, QualityMeasuresTestResult testResult, bool useBlankValue = false);
    }
}