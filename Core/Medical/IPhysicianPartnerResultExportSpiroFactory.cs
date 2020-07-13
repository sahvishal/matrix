using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianPartnerResultExportSpiroFactory
    {
        PhysicianPartnerResultExportModel SetSpiroData(PhysicianPartnerResultExportModel model, SpiroTestResult testResult);
    }
}
