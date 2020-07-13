using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianPartnerResultExportEchoFactory
    {
        PhysicianPartnerResultExportModel SetEchoData(PhysicianPartnerResultExportModel model, PpEchocardiogramTestResult testResult);
    }
}
