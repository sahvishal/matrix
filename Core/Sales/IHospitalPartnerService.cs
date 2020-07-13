using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface IHospitalPartnerService
    {
        ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>
            GetHospitalPartnerCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter> GetHospitalPartnerEventCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter> GetHospitalPartnerEvents(
            int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter>
            GetCustomerAggregateResultSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        IEnumerable<HospitalPartnerCustomerActivityViewModel> GetHospitalPartnerCustomerActivities(long eventId, long customerId);

        IEnumerable<NotesViewModel> GetEventNotes(long eventId);
        HospitalPartnerCallStatusViewModel GetHospitalPartnerCallStatus(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers);
        HospitalPartnerScheduledOutcomeViewModel GetHospitalPartnerScheduledOutcome(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers);
        HospitalPartnerNotScheduledOutcomeViewModel GetHospitalPartnerNotScheduledOutcome(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers);
        HospitalPartnerCallStatusViewModel GetHospitalFacilityCallStatus(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers);
        HospitalPartnerScheduledOutcomeViewModel GetHospitalFacilityScheduledOutcome(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers);
        HospitalPartnerNotScheduledOutcomeViewModel GetHospitalFacilityNotScheduledOutcome(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers);

        ListModelBase<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter> GetHospitalFacilityEvents(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
