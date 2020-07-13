using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IMemberUploadbyAcesFailedCustomerFactory
    {
        MemberUploadbyAcesFailedCustomerModel Create(CorporateCustomerEditModel model);
    }
}
