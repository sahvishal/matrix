using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IHiptoAcesCrossWalkFactory
    {
        HiptoAcesCrossWalkViewModel Create(Customer customer, CorporateAccount corporateAccount);
    }
}
