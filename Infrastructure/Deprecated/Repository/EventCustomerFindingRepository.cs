using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Infrastructure.Deprecated.Factories;
using Falcon.App.Core.Application.Attributes;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Deprecated.Repository
{
    public interface IEventCustomerFindingRepository
    {
        EventCustomersFindingEditModel GetforanEvent(long eventId);
        void Save(EventCustomersFindingEditModel model);
    }

    [DefaultImplementation]
    public class EventCustomerFindingRepository : PersistenceRepository, IEventCustomerFindingRepository
    {
        private ICustomerRepository _customerRepository;
        private IUniqueItemRepository<Event> _eventRepository;
        private IEventTestRepository _testRepository;
        private IEventCustomerRepository _eventCustomerRepository;
        private ICustomerReceiptModelService _service;
        private IEventCustomerFindingFactory _eventCustomerFindingFactory;
        private IPodRepository _podRepository;

        public EventCustomerFindingRepository(IUniqueItemRepository<Event> eventRepository, IEventTestRepository testRepository, IEventCustomerRepository eventCustomerRepository,
            ICustomerReceiptModelService service, IEventCustomerFindingFactory eventCustomerFindingFactory, ICustomerRepository customerRepository, IPodRepository podRepository)
        {
            _eventRepository = eventRepository;
            _testRepository = testRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _service = service;
            _eventCustomerFindingFactory = eventCustomerFindingFactory;
            _customerRepository = customerRepository;
            _podRepository = podRepository;
        }

        public EventCustomersFindingEditModel GetforanEvent(long eventId)
        {
            var selectedEvent = _eventRepository.GetById(eventId);
            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);
            var tests = _testRepository.GetTestsForEvent(eventId);

            var pod =_podRepository.GetPodsForEvent(selectedEvent.Id);

            var customerRecieptModels = new List<CustomerItemizedReceiptModel>();
            if (eventCustomers.IsNullOrEmpty()) return _eventCustomerFindingFactory.Create(selectedEvent, customerRecieptModels, tests, null, null, null,pod);

            eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow).ToArray();
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(crm => crm.CustomerId).ToArray());

            customerRecieptModels.AddRange(from eventCustomer in eventCustomers
                                           where eventCustomer.AppointmentId != null
                                           select _service.GetItemizedRecieptModel(eventCustomer.CustomerId, eventId));

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomerFindingEntities =
                    linqMetaData.CustomerEventTestFinding.Where(ce => ce.EventId == eventId).ToArray();

                var physicianNoteEntities = linqMetaData.CustomerEventTestPhysicianNote.Where(ce => ce.EventId == eventId).ToArray();

                return _eventCustomerFindingFactory.Create(selectedEvent, customerRecieptModels, tests,
                                                           eventCustomerFindingEntities, physicianNoteEntities, customers,pod);
            }

        }

        public void Save(EventCustomersFindingEditModel model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CustomerEventTestPhysicianNoteEntity),
                                               new RelationPredicateBucket(CustomerEventTestPhysicianNoteFields.EventId ==
                                                                           model.EventId));

                adapter.DeleteEntitiesDirectly(typeof(CustomerEventTestFindingEntity),
                                               new RelationPredicateBucket(CustomerEventTestFindingFields.EventId ==
                                                                           model.EventId));

                var entities = new EntityCollection<CustomerEventTestFindingEntity>();
                var physicianNotesEntities = new EntityCollection<CustomerEventTestPhysicianNoteEntity>();
                foreach (var customer in model.Customers)
                {
                    if (!string.IsNullOrEmpty(customer.Notes))
                    {
                        physicianNotesEntities.Add(new CustomerEventTestPhysicianNoteEntity(model.EventId,
                                                                                            customer.CustomerId) { PhysicianNotes = customer.Notes });
                    }

                    foreach (var test in customer.Tests)
                    {
                        entities.Add(new CustomerEventTestFindingEntity(model.EventId, customer.CustomerId,
                                                                        (long)test.TestType) { Finding = (int)test.Finding });
                    }
                }

                using (var scope = new TransactionScope())
                {
                    if (entities.Count > 0)
                        if (adapter.SaveEntityCollection(entities) == 0)
                            throw new PersistenceFailureException();

                    if (physicianNotesEntities.Count > 0)
                        if (adapter.SaveEntityCollection(physicianNotesEntities) == 0)
                            throw new PersistenceFailureException();

                    scope.Complete();
                }
            }
        }



    }
}