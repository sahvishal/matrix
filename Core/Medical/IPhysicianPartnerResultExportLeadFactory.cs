using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianPartnerResultExportLeadFactory
    {
        PhysicianPartnerResultExportModel SetLeadData(PhysicianPartnerResultExportModel model, LeadTestResult testResult);
    }
}
