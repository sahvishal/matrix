using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportHypertensionFactory : IPcpResultExportHypertensionFactory
    {
        public PcpResultExportModel SetHypertensionData(PcpResultExportModel model, HypertensionTestResult testResult)
        {
            throw new System.NotImplementedException();
        }
    }
}
