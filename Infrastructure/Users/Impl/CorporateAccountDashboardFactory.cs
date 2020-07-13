using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class CorporateAccountDashboardFactory : ICorporateAccountDashboardFactory
    {
        public CorporateAccountDashboardViewModel Create(IEnumerable<ClientEventVolumeModel> upcomingEvents, CorporateAccountMemberStatusViewModel memberStatus, IEnumerable<EventCustomerResult> recentCriticalCustomers,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels)
        {
            var model = new CorporateAccountDashboardViewModel
            {
                UpcomingEvents = upcomingEvents,
                MemberStatus = memberStatus
            };

            if (recentCriticalCustomers != null && recentCriticalCustomers.Any())
            {
                var customerModel = (from recentCriticalCustomer in recentCriticalCustomers
                                     let theEvent = events.Single(e => e.Id == recentCriticalCustomer.EventId)
                                     let customer = customers.Single(c => c.CustomerId == recentCriticalCustomer.CustomerId)
                                     let customerResultStatus = customerResultStatusViewModels.Single(crs => crs.EventCustomerId == recentCriticalCustomer.Id)
                                     select new CorporateAccountDashboardCriticalResults
                                     {
                                         CustomerId = customer.CustomerId,
                                         CustomerName = customer.Name,
                                         EventDate = theEvent.EventDate,
                                         EventId = theEvent.Id,
                                         CriticalMarkedByPhysician = customerResultStatus.TestResults.Any(tr => tr.CriticalMarkedByPhysician && !tr.IsCritical),
                                         ResultSummary = (recentCriticalCustomer.ResultSummary.HasValue ? (ResultInterpretation)recentCriticalCustomer.ResultSummary : ResultInterpretation.Critical).ToString()
                                     }).ToList();

                model.CriticalUrgentResult = customerModel;
            }

            return model;
        }
    }
}
