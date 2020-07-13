using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IOnlineEventListModelFactory
    {
        IEnumerable<OnlineEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, ZipCode filterZipCode,
            IEnumerable<EventSchedulingSlot> slots, long selectedEventId, int cutOffHourforMarkEventOnlineSelection, SortOrderBy sortOrderBy, SortOrderType sortOrderType, int maxNumberofRecordstoFetch, int pageNumber,
            int pageSize, out int totalRecords);

        IEnumerable<OnlineEventViewModel> ManageSponsoredByLogo(IEnumerable<OnlineEventViewModel> collection, IEnumerable<OrderedPair<long, long>> eventIdOrganizationIdpairs, IEnumerable<Organization> organizations, 
            IEnumerable<File> files);
    }
}
