
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
namespace Falcon.App.Core.Scheduling
{
    public interface IMapEventListModelFactory
    {
        MapEventListModel Create(IEnumerable<Event> events, IEnumerable<EventBasicInfoViewModel> eventListInfo, IEnumerable<ZipCode> zipCodes, IEnumerable<CorporateAccount> corporateAccounts);
    }
}
