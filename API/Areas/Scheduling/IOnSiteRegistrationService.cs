using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling
{
    public interface IOnSiteRegistrationService
    {
        Order RegisterCustomerOnSite(OnSiteRegistrationEditModel model);
        EventCustomerAppointmentViewModel FetchEventCustomerDetail(long eventId, long customerId);
    }
}