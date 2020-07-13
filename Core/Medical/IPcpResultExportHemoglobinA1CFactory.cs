using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportHemoglobinA1CFactory
    {
        PcpResultExportModel SetHemoglobinA1CData(PcpResultExportModel model, HemaglobinA1CTestResult testResult, bool useBlankValue = false);
    }
}