using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Factories.Events;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    public class EventCustomerRegistrationViewDataRepository : PersistenceRepository, IEventCustomerRegistrationViewDataRepository
    {
        //ToDo: view is consuming to much time to load. 
        private const int CommandTimeOut = 60;
        private readonly IEventCustomerRegistrationViewDataFactory _factory;
        private readonly IPhysicianAssignmentService _physicianAssignmentService;
        private readonly IEventCustomerFilterPredicateFactory _eventCustomerFilterPredicateFactory;

        public EventCustomerRegistrationViewDataRepository()
        {
            _factory = new EventCustomerRegistrationViewDataFactory();
            _eventCustomerFilterPredicateFactory = new EventCustomerFilterPredicateFactory();
            _physicianAssignmentService = new PhysicianAssignmentService(new PhysicianEventAssignmentRepository(),
                new PhysicianCustomerAssignmentRepository(), new PhysicianRepository(), new EventCustomerRepository(),
                new EventPhysicianTestRepository(), new EventPhysicianTestFactory());
        }

        public EventCustomerRegistrationViewDataRepository(IPersistenceLayer persistenceLayer,
                                                           IEventCustomerRegistrationViewDataFactory factory, IEventCustomerFilterPredicateFactory eventCustomerFilterPredicateFactory, IPhysicianAssignmentService physicianAssignmentService)
            : base(persistenceLayer)
        {
            _eventCustomerFilterPredicateFactory = eventCustomerFilterPredicateFactory;
            _factory = factory;
            _physicianAssignmentService = physicianAssignmentService;
        }

        
        public List<EventCustomerRegistrationViewData> GetEventCustomerOrders(List<long> eventCustomerIds)
        {
            var customerOrderBasicInfoTypedView = new CustomerOrderBasicInfoTypedView();
            var fieldCompareRangePredicate =
                new FieldCompareRangePredicate(CustomerOrderBasicInfoFields.EventCustomerId, null, eventCustomerIds);
            var bucket = new RelationPredicateBucket(fieldCompareRangePredicate);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerOrderBasicInfoTypedView, bucket, false);
            }
            return _factory.Create(customerOrderBasicInfoTypedView, null);
        }

        public EventCustomerRegistrationViewData GetEventCustomerOrders(long customerId, long eventId)
        {
            var customerOrderBasicInfoTypedView = new CustomerOrderBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerOrderBasicInfoFields.EventId == eventId);
            bucket.PredicateExpression.AddWithAnd(CustomerOrderBasicInfoFields.CustomerId == customerId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(customerOrderBasicInfoTypedView, bucket, false);
            }
            return _factory.Create(customerOrderBasicInfoTypedView, null).FirstOrDefault();
        }

        public List<EventCustomerRegistrationViewData> GetEventCustomerOrdersForEvent(long eventId)
        {
            var customerOrderBasicInfoTypedView = new CustomerOrderBasicInfoTypedView();
            var bucket = new RelationPredicateBucket(CustomerOrderBasicInfoFields.EventId == eventId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.CommandTimeOut = CommandTimeOut;
                myAdapter.FetchTypedView(customerOrderBasicInfoTypedView, bucket, false);
            }
            var eventCustomerIds = customerOrderBasicInfoTypedView.Select(vw => vw.EventCustomerId).ToArray();
            return _factory.Create(customerOrderBasicInfoTypedView, _physicianAssignmentService.GetPhysicianAssignments(eventId, eventCustomerIds));
        }

        public List<EventCustomerRegistrationViewData> GetEventCustomerOrdersForEvent(EventCustomerFilterMode eventCustomerFilterMode, long eventId)
        {
            var customerOrderBasicInfoTypedView = new CustomerOrderBasicInfoTypedView();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerIds = linqMetaData.EventCustomers.Where(ec => ec.EventId == eventId).Select(ec => ec.EventCustomerId);
                // Hack: This is done to minimize the fetch time for the query.
                var fieldCompareRangePredicate = new FieldCompareRangePredicate(CustomerOrderBasicInfoFields.EventCustomerId, null, eventCustomerIds);

                var bucket = new RelationPredicateBucket(fieldCompareRangePredicate);

                //var bucket = new RelationPredicateBucket(CustomerOrderBasicInfoFields.EventId == eventId);

                //var predicates = _eventCustomerFilterPredicateFactory.CreatePredicate(eventCustomerFilterMode);
                //foreach (var predicate in predicates)
                //{
                //    bucket.PredicateExpression.AddWithAnd(predicate);
                //}
                
                myAdapter.FetchTypedView(customerOrderBasicInfoTypedView, bucket, false);

                IEnumerable<CustomerOrderBasicInfoRow> customerOrderBasicInfoRows = _eventCustomerFilterPredicateFactory.GetFilteredData(eventCustomerFilterMode,customerOrderBasicInfoTypedView);
                return _factory.Create(customerOrderBasicInfoRows, _physicianAssignmentService.GetPhysicianAssignments(eventId, eventCustomerIds));
            }
        }
    }
}