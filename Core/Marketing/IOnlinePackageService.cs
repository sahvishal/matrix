using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Marketing
{
    public interface IOnlinePackageService
    {
        OrderPlaceEditModel GetEventPackageList(TempCart tempCart);
        OnlineProductShippingEditModel GetShippingOption(TempCart tempCart);
        IEnumerable<EventTestOrderItemViewModel> GetAdditionalTest(TempCart tempCart);
        void ReleaseSlotsOnScreeningtimeChanged(TempCart tempCart, long newEventPackageId, string newEventTestIds);
        IEnumerable<EventTestOrderItemViewModel> UpsaleTest(long eventId, long eventPackageId, Gender gender);
        bool SaveUpsellTestIds(UpsellTestEditModel model);
        bool SaveaAlacarteTestIds(TempCart tempCart, string selectedTestIds, bool saveBloodPanelTest);
        void UpdateTestPurchased(TempCart tempCart);
        bool IsUpsellTestAvailable(TempCart tempCart);

    }
}
