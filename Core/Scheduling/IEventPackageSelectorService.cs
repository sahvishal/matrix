using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventPackageSelectorService
    {
        IEnumerable<EventPackageEditModel> GetEventPackage(long accountId, long hospitalPartnerId, long territoryId, EventType eventType);
        OrderPlaceEditModel GetEventPackage(TempCart tempCart, long eventId, Roles role);
        OrderPlaceEditModel GetEventPackage(OrderPlaceEditModel model, long eventId, Roles role, long customerId, TempCart tempCart);
        OnSiteRegistrationEditModel SetEventAndPackageDetail(OnSiteRegistrationEditModel model, long eventId, Roles role);
        int GetScreeningTime(long eventId, long packageId, IEnumerable<long> testIds);
        int GetScreeningTime(Order order);
        int GetScreeningTime(long eventPackageId, IEnumerable<long> eventTestIds);
        void LoadPackageImagePath(IEnumerable<EventPackage> eventPackages, IEnumerable<EventPackageOrderItemViewModel> eventPackageModelCollection);
    }
}