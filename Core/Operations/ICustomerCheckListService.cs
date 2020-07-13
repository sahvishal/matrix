using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface ICustomerCheckListService
    {
        CheckListFormEditModel GetCustomerCheckListEdtiModel(long customerId, long eventId);
        void SaveCheckListAnswer(CheckListAnswerEditModel model, long orgUserId, long userLoginLogId, string token);

        CheckListFormEditModel GetCustomerCheckListEdtiModel(Customer customer, CorporateAccount account, EventCustomer eventCustomer);
    }
}
