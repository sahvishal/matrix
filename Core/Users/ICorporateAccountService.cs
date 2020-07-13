using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICorporateAccountService
    {
        CorporateAccountBasicInfoEditModel GetBasicInfoEditModel(long id);
        CorporateAccountBasicInfoEditModel SaveAccountInfo(CorporateAccountBasicInfoEditModel model);
        RegistrationConfigEditModel GetRegistrationConfig(long id);
        void SaveAccountRegistrationInfo(RegistrationConfigEditModel model, long orgRoleId);
        ResultConfigEditModel GetResultConfigEditModel(long id);
        void SaveAccountResultConfig(ResultConfigEditModel model);
        bool CheckCanChangeClinicalTemplate(long accountId);
        void BindDefaultRegistrationData(RegistrationConfigEditModel model);
        TestCptSelectionViewModel GetCptTestMappingModel(long id);

        ListModelBase<CorporateAccountCustomerViewModel, CorporateAccountCustomerListModelFilter> GetMemberResultSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
