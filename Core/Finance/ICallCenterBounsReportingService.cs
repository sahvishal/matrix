using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface ICallCenterBounsReportingService
    {
        CallCenterBonusListModel GetCallCenterBonus(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<PayPeriodBookedCustomerViewModel, PayPeriodBookedCustomerFilter> GetPayPeriodAppointmentBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        ListModelBase<AppointmentsShowedViewModel, CallCenterBonusFilter> GetAppointmentsShowed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<ActualCustomerShowedViewModel, PayPeriodBookedCustomerFilter> GetActualCustomerShowed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
