using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories.Events;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation(Interface = typeof(IEventCustomerAggregateRepository))]
    public class EventCustomerAggregateRepository : PersistenceRepository, IEventCustomerAggregateRepository
    {
        private readonly IEventCustomerAggregateFactory _factory;

        public EventCustomerAggregateRepository()
        {
            _factory = new EventCustomerAggregateFactory();
        }

        public EventCustomerAggregateRepository(IEventCustomerAggregateFactory factory)
        {
            _factory = factory;
        }

        public EventCustomerAggregate GetRegisteredEvent(long customerId, long eventId)
        {
            var customerEventBasicInfoTypedView = new CustomerEventBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerEventBasicInfoFields.EventId == eventId);
            bucket.PredicateExpression.AddWithAnd(CustomerEventBasicInfoFields.CustomerId == customerId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerEventBasicInfoTypedView, bucket, false);
            }
            return _factory.CreateAggregatesFromTypedViewCollection(customerEventBasicInfoTypedView).FirstOrDefault();
        }

        public EventCustomerAggregate GetEventCustomerById(long eventCustomerId)
        {
            var customerEventBasicInfoTypedView = new CustomerEventBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerEventBasicInfoFields.EventCustomerId == eventCustomerId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerEventBasicInfoTypedView, bucket, false);
            }
            return _factory.CreateAggregatesFromTypedViewCollection(customerEventBasicInfoTypedView).FirstOrDefault();
        }

        public List<EventCustomerAggregate> GetEventCustomersByIds(long[] eventCustomerIds)
        {
            var customerEventBasicInfoTypedView = new CustomerEventBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerEventBasicInfoFields.EventCustomerId == eventCustomerIds);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerEventBasicInfoTypedView, bucket, false);
            }
            return _factory.CreateAggregatesFromTypedViewCollection(customerEventBasicInfoTypedView);
        }

        private List<EventCustomerAggregate> FetchEventCustomerInformation(long salesRepId, DateRange eventDateRange)
        {
            var customerEventBasicInfoTypedView = new CustomerEventBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerEventBasicInfoFields.AssignedToOrgRoleUserId == salesRepId);

            if (eventDateRange != null)
            {
                if (eventDateRange.StartDate.HasValue)
                {
                    bucket.PredicateExpression.Add(CustomerEventBasicInfoFields.EventDate >=
                                                   eventDateRange.StartDate.Value);
                }
                if (eventDateRange.EndDate.HasValue)
                {
                    bucket.PredicateExpression.Add(CustomerEventBasicInfoFields.EventDate <=
                                                   eventDateRange.EndDate.Value.GetEndOfDay());
                }
            }
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerEventBasicInfoTypedView, bucket, false);
            }
            return _factory.CreateAggregatesFromTypedViewCollection(customerEventBasicInfoTypedView);
        }

        public List<EventCustomerAggregate> GetAllEventCustomerInfoBySalesRep(int salesRepId)
        {
            return FetchEventCustomerInformation(salesRepId, null);
        }

        /// <summary>
        /// Returns event customer information for a given sales rep, discluding events before the given date.
        /// </summary>
        /// <param name="salesRepId">The id of the sales rep to get the information for.</param>
        /// <param name="eventStartDate">Only events starting on or after this date will be returned.</param>
        /// <returns>A list of event customer information.</returns>
        public List<EventCustomerAggregate> GetEventCustomerInfoBySalesRep(long salesRepId, DateTime eventStartDate)
        {
            return GetEventCustomerInfoBySalesRep(salesRepId, new DateRange { StartDate = eventStartDate });
        }

        public List<EventCustomerAggregate> GetEventCustomerInfoBySalesRep(long salesRepId, DateRange eventDateRange)
        {
            return FetchEventCustomerInformation(salesRepId, eventDateRange);
        }
    }
}