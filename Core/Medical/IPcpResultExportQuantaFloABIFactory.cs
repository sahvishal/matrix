using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportQuantaFloABIFactory
    {
        PcpResultExportModel SetQuantaFloABIData(PcpResultExportModel model, QuantaFloABITestResult testResult, bool useBlankValue = false);
    }
}