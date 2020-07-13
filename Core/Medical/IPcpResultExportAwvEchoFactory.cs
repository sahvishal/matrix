using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvEchoFactory
    {
        PcpResultExportModel SetAwvEchoData(PcpResultExportModel model, AwvEchocardiogramTestResult testResult, bool useBlankValue = false);
    }
}
