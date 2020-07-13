using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvSpiroFactory
    {
        PcpResultExportModel SetAwvSpiroData(PcpResultExportModel model, AwvSpiroTestResult testResult, bool useBlankValue = false);
    }
}
