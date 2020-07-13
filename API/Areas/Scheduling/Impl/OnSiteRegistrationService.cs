using System.Linq;
using System.Transactions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Impl
{
    public class OnSiteRegistrationService : IOnSiteRegistrationService
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IEventCustomerReportingService _eventCustomerReportingService;

        public OnSiteRegistrationService(ICustomerRegistrationService customerRegistrationService, IEventCustomerReportingService eventCustomerReportingService)
        {
            _customerRegistrationService = customerRegistrationService;
            _eventCustomerReportingService = eventCustomerReportingService;
        }

        public Order RegisterCustomerOnSite(OnSiteRegistrationEditModel model)
        {
            using (var scope = new TransactionScope())
            {
                var order = _customerRegistrationService.RegisterOnsiteCustomer(model);
                scope.Complete();
                return order;
            }
        }

        public EventCustomerAppointmentViewModel FetchEventCustomerDetail(long eventId, long customerId)
        {

            var model = _eventCustomerReportingService.GetEventCustomerBriefList(eventId, new EventCustomerListModelFilter());

            if (model == null) return null;

            if (model.EventAppointmentSlotDistributions.IsNullOrEmpty()) return null;

            var eventAppointmentSlotDistribution = model.EventAppointmentSlotDistributions.FirstOrDefault(x => x.Customer.CustomerId == customerId);
            
            return eventAppointmentSlotDistribution;
        }
    }
}