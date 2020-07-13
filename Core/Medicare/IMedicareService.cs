using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Medicare
{
    public interface IMedicareService
    {
        MedicareUserViewModel GetUser(long userId);
        MedicareCustomerViewModel GetCustomerDetails(long customerId);
        MedicareEventCustomerViewModel GetEventCustomerDetails(long customerId, long eventId);
        bool UpdateCustomerDetails(MedicareCustomerViewModel customerViewModel);
        IEnumerable<OrderedPair<long, string>> GetTestListByAliasList(IEnumerable<string> list);
        MedicareUserEditModel CreateUserEditModel(UserEditModel userEditModel, string defaultRoleAlias, IEnumerable<string> roles, IEnumerable<string> removedRoles);
        int GetResultState(long eventId, long customerId);
        IEnumerable<MedicareEventCustomerAcesViewModel> GetEventCustomerForAces();
        MedicareUserDeactivateModel DeactivateUserModel(long userId, bool isActive);
        void UpdateMedicareVisitStatus(long eventCustomerId, int visitStatus, string sessionId, ISessionContext sessionContext);
    }
}
