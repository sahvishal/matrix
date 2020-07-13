using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IOnlineShippingService
    {
        OnlineProductShippingEditModel GetShippingOption(TempCart tempCart);
    }
}