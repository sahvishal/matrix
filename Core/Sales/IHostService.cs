using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface IHostService
    {
        long CreateHostFromAccount(CorporateAccountEditModel corporateAccount);
        long CreateHostFromBasicInfo(CorporateAccountBasicInfoEditModel corporateAccount);
        bool DeleteHost(long hostId);
    }
}
