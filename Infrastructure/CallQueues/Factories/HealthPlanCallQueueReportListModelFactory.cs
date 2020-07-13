using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class HealthPlanCallQueueReportListModelFactory : IHealthPlanCallQueueReportListModelFactory
    {
        public CallQueueSchedulingReportListModel Create(IEnumerable<CallQueueCustomerCallDetails> callQueueCustomerCallDetailsView, List<Customer> customers,
            IEnumerable<Core.Sales.Domain.CorporateCustomerCustomTag> customerTags, IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair, IEnumerable<Event> events,
            IEnumerable<Organization> organizations, IEnumerable<CallQueue> callQueues)
        {
            var model = new CallQueueSchedulingReportListModel();
            var collection = new List<CallQueueSchedulingReportModel>();

            callQueueCustomerCallDetailsView.ToList().ForEach(c =>
            {

                var customer = (from cd in customers where cd.CustomerId == c.CalledCustomerId select cd).First();

                var eventDetail = events != null ? events.SingleOrDefault(x => x.Id == c.EventId) : null;

                var customerTag = "N/A";
                if (customerTags != null && customerTags.Any())
                {
                    var customTag = (from ct in customerTags where ct.CustomerId == c.CalledCustomerId select ct.Tag).ToArray();

                    if (customTag != null && customTag.Any())
                    {
                        customerTag = string.Join(", ", customTag);
                    }
                }

                var healthPlanName = "N/A";
                if (!organizations.IsNullOrEmpty())
                {
                    healthPlanName = organizations.Single(x => x.Id == c.HealthPlanId).Name;
                }

                var callqueueName = "N/A";

                if (!callQueues.IsNullOrEmpty())
                {
                    callqueueName = callQueues.Single(x => x.Id == c.CallQueueId).Name;
                }

                var agentName = "N/A";
                if (registeredbyAgentNameIdPair != null && registeredbyAgentNameIdPair.Any())
                {
                    agentName = registeredbyAgentNameIdPair.Single(ap => ap.FirstValue == c.CreatedByOrgRoleUserId).SecondValue;
                }

                var callOutreachTime = String.Format("{0:hh:mm tt}", c.CallDateTime);
                var outreachcallQueueModel = new CallQueueSchedulingReportModel
                {
                    CustomerId = c.CalledCustomerId,
                    Name = customer.Name,
                    MemberId = customer.InsuranceId,
                    DateOfBirth = customer.DateOfBirth,
                    CallDate = c.CallDateTime.Date,
                    CallTime = callOutreachTime,
                    EventDate = eventDetail != null ? eventDetail.EventDate : (DateTime?)null,
                    EventId = eventDetail != null ? eventDetail.Id.ToString() : "N/A",
                    Agent = agentName,
                    Tag = customer.Tag,
                    CustomTags = customerTag,
                    HealthPlan = healthPlanName,
                    CallQueue = callqueueName
                };

                collection.Add(outreachcallQueueModel);
            });

            model.Collection = collection;

            return model;
        }

    }
}