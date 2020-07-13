using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomAppointmentBookedReportingService
    {
        ListModelBase<CustomAppointmentsBookedModel, CustomAppointmentsBookedListModelFilter> GetCustomAppointmentsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        IEnumerable<Address> SetCustomerSearchDetails(IEnumerable<long> billingAddressIds);
        IEnumerable<OffCallEventDetail> GetOffCallEventDetails(IEnumerable<long> customerIds);
    }
}