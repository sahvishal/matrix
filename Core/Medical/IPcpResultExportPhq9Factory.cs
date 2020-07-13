using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportPhq9Factory
    {
        PcpResultExportModel SetPhq9Data(PcpResultExportModel model, Phq9TestResult testResult, bool useBlankValue = false);
    }
}