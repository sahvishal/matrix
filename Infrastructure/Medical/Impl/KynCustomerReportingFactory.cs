using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using System;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynCustomerReportingFactory : IKynCustomerReportingFactory
    {
        private readonly IKynHealthAssessmentHelper _healthAssessmentHelper;
        private readonly ISettings _settings;

        public KynCustomerReportingFactory(IKynHealthAssessmentHelper healthAssessmentHelper, ISettings settings)
        {
            _healthAssessmentHelper = healthAssessmentHelper;
            _settings = settings;
        }

        public KynCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Appointment> appointments, IEnumerable<Pod> pods, bool showKynOnly,
            IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, IEnumerable<CorporateCustomerCustomTag> customTags,
            IEnumerable<OrderedPair<long, string>> eventIdcorporateAccountNames, IEnumerable<OrderedPair<long, string>> eventIdhospitalPartnerNames, IEnumerable<HealthAssessmentAnswer> healthAssessments,
            IEnumerable<OrderedPair<long, string>> healthAssessmentsbyAgentNameIdPair, IEnumerable<OrganizationRoleUser> lastModifiedByAgents)
        {
            var model = new KynCustomerListModel();
            var kynCustomerslist = new List<KynCustomerModel>();
            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = events.FirstOrDefault(e => e.Id == ec.EventId);

                var customer = customers.FirstOrDefault(c => c.CustomerId == ec.CustomerId);
                var appointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointments.FirstOrDefault(a => a.Id == ec.AppointmentId.Value).StartTime : null;

                bool? iskynPrefilled = null;
                if (appointmentTime.HasValue)
                    iskynPrefilled = _healthAssessmentHelper.IsKynHafPrefilled(eventModel.Id, customer.CustomerId, appointmentTime.Value, showKynOnly);



                var eventPods = pods.Where(p => eventModel.PodIds.Contains(p.Id)).Select(x => x.Name);

                var registeredBy = (ec.DataRecorderMetaData == null || ec.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.FirstOrDefault(a => a.Id == ec.DataRecorderMetaData.DataRecorderCreator.Id));
                string agentName, agentRole;
                agentRole = agentName = string.Empty;

                if (registeredBy != null)
                {
                    if (registeredBy.RoleId == (long)Roles.Customer)
                    {
                        agentRole = "Internet";
                        agentName = "";
                    }
                    else
                    {
                        agentRole = roles.First(r => r.Id == registeredBy.RoleId).DisplayName;
                        agentName = agentIdNamePairs.First(ap => ap.FirstValue == registeredBy.Id).SecondValue;
                    }
                }
                var corporateCustomTags = "N/A";
                if (customTags != null && customTags.Any())
                {
                    var customerCustomTags = customTags.Where(ct => ct.CustomerId == customer.CustomerId).Select(ct => ct.Tag).ToArray();

                    if (customerCustomTags.Any())
                    {
                        corporateCustomTags = string.Join(",", customerCustomTags);
                    }
                }
               

                var kynCustomer = new KynCustomerModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name.FullName,
                    EventDate = eventModel.EventDate,
                    EventId = eventModel.Id,
                    Pod = eventPods != null && eventPods.Any() ? string.Join(", ", eventPods) : string.Empty,
                    KynStatus = iskynPrefilled.HasValue ? (iskynPrefilled.Value ? "Filled" : "Not Filled") : "N/A",
                    RegisterationByRole = agentRole,
                    RegisteredBy = agentName,
                    Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                    CustomTag = corporateCustomTags,
                };

                string sponseredBy = string.Empty;
                if (eventIdcorporateAccountNames.Any())
                {
                    var sponserName = eventIdcorporateAccountNames.FirstOrDefault(x => x.FirstValue == eventModel.Id);
                    if (sponserName != null)
                    {
                        sponseredBy = sponserName.SecondValue;
                    }
                    else
                    {
                        if (eventIdhospitalPartnerNames.Any())
                            sponserName = eventIdhospitalPartnerNames.FirstOrDefault(x => x.FirstValue == eventModel.Id);
                        sponseredBy = sponserName != null ? sponserName.SecondValue : _settings.CompanyName;
                    }
                }
                else
                {
                    if (eventIdhospitalPartnerNames.Any())
                    {
                        var sponserName = eventIdhospitalPartnerNames.FirstOrDefault(x => x.FirstValue == eventModel.Id);
                        if (sponserName != null)
                        {
                            sponseredBy = sponserName.SecondValue;
                        }
                    }
                    if (string.IsNullOrEmpty(sponseredBy))
                        sponseredBy = _settings.CompanyName;
                }
                kynCustomer.SponseredBy = sponseredBy;

                var modifiedByName = string.Empty;
                var healthAssessment = healthAssessments.Where(m => m.EventCustomerId == ec.Id).FirstOrDefault();
                if (healthAssessment != null)
                {
                    var lastModifiedAgent = (healthAssessment.DataRecorderMetaData == null || healthAssessment.DataRecorderMetaData.DataRecorderCreator == null ? null : lastModifiedByAgents.FirstOrDefault(a => a.Id == healthAssessment.DataRecorderMetaData.DataRecorderCreator.Id));
                    if (lastModifiedAgent != null)
                    {
                        if (lastModifiedAgent.RoleId == (long)Roles.Customer)
                        {
                            kynCustomer.ModifiedBy = "Internet";
                        }
                        else
                        {
                            kynCustomer.ModifiedBy = healthAssessmentsbyAgentNameIdPair.First(ap => ap.FirstValue == lastModifiedAgent.Id).SecondValue + " ("+ roles.First(r => r.Id == lastModifiedAgent.RoleId).DisplayName + ")";
                        }
                    }
                    kynCustomer.ModifiedOn = healthAssessment.DataRecorderMetaData.DateCreated;
                }
                kynCustomerslist.Add(kynCustomer);
            });
            model.Collection = kynCustomerslist;

            return model;
        }

    }
}
