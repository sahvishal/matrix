using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvCarotidFactory
    {
        PcpResultExportModel SetAwvCarotidData(PcpResultExportModel model, AwvCarotidTestResult testResult, bool useBlankValue = false);
    }
}
