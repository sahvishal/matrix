using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
  public  interface IKynCustomerReportingFactory
  {
      KynCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events,IEnumerable<Customer> customers,IEnumerable<Appointment> appointments,IEnumerable<Pod> pods,bool showKynOnly,
          IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, IEnumerable<CorporateCustomerCustomTag> customTags,
          IEnumerable<OrderedPair<long, string>> eventIdcorporateAccountNames, IEnumerable<OrderedPair<long, string>> eventIdhospitalPartnerNames, IEnumerable<HealthAssessmentAnswer> healthAssessments,
          IEnumerable<OrderedPair<long, string>> healthAssessmentsbyAgentNameIdPair, IEnumerable<OrganizationRoleUser> lastModifiedByAgents);
  }
}
