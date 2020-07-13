using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvAaaFactory
    {
        PcpResultExportModel SetAwvAaaData(PcpResultExportModel model, AwvAaaTestResult testResult, bool useBlankValue = false);
    }
}
