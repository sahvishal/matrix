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
    public interface IOnlineSchedulingEventListModelFactory
    {
        OnlineSchedulingEventListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> totalSlotsOrderedPair, IEnumerable<OrderedPair<long, int>> availableSlotsOrderedPair, ZipCode filterZipCode,
            IEnumerable<EventSchedulingSlot> appointments, long selectedEventId, int cutOffHourforMarkEventOnlineSelection, SortOrderBy sortOrderBy, SortOrderType sortOrderType, int maxNumberofRecordstoFetch, int pageNumber, int pageSize, out int totalRecords);

        OnlineSchedulingEventListModel ManipulateSlotAvilabilityDisplay(OnlineSchedulingEventListModel model, IEnumerable<Appointment> slots);
        OnlineSchedulingEventListModel ManageSponsoredByLogo(OnlineSchedulingEventListModel model, IEnumerable<OrderedPair<long, long>> eventIdOrganizationIdpairs, IEnumerable<Organization> organizations, IEnumerable<File> files);

        OnlineSchedulingEventViewModel Create(Event theEvent, Host host, IEnumerable<Appointment> appointments, File file);
    }
}