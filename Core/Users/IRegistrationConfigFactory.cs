using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IRegistrationConfigFactory
    {
        RegistrationConfigEditModel CreateModel(CorporateAccount account);
        CorporateAccount CreateDomain(CorporateAccount inpersistence, RegistrationConfigEditModel model);
    }
}
