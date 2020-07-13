using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvHemoglobinFactory
    {
        PcpResultExportModel SetAwvHemoglobinData(PcpResultExportModel model, AwvHemaglobinTestResult testResult, bool useBlankValue = false);
    }
}