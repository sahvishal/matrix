using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Application.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    public class CustomerCriticalDataRepository : PersistenceRepository, IRepository<CustomerCriticalData>, ICustomerCriticalDataRepository
    {
        private readonly INotesRepository _notesRepository;

        public CustomerCriticalDataRepository()
            : this(new NotesRepository())
        { }

        public CustomerCriticalDataRepository(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        public CustomerCriticalData GetbyId(long id)
        {
            return Get(new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == id)).SingleOrDefault();
        }

        public IEnumerable<CustomerCriticalData> GetbyIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == ids.ToArray())).ToArray();
        }

        public IEnumerable<CustomerCriticalData> Get(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var ids = (from ecr in linqMetaData.EventCustomerResult
                           join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                           where ecr.EventId == eventId && ecr.CustomerId == customerId
                           select cest.CustomerEventScreeningTestId).ToArray();
                var expresion = new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == ids);
                expresion.PredicateExpression.AddWithAnd(CustomerEventCriticalTestDataFields.IsActive == true);

                return Get(expresion).ToArray();
            }
        }

        public CustomerCriticalData Get(long eventId, long customerId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var id = (from ecr in linqMetaData.EventCustomerResult
                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                          where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                          select cest.CustomerEventScreeningTestId).SingleOrDefault();
                var expresion = new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == id);
                expresion.PredicateExpression.AddWithAnd(CustomerEventCriticalTestDataFields.IsActive == true);

                return Get(expresion).SingleOrDefault();
            }
        }

        private IEnumerable<CustomerCriticalData> Get(IRelationPredicateBucket expression)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<CustomerEventCriticalTestDataEntity>();
                adapter.FetchEntityCollection(collection, expression);
                var criticalDataCollection = Mapper.Map<IEnumerable<CustomerEventCriticalTestDataEntity>, IEnumerable<CustomerCriticalData>>(collection.AsEnumerable());

                var ids = criticalDataCollection.Select(ccd => ccd.Id).ToArray();
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomers = (from ecr in linqMetaData.EventCustomerResult
                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                      where ids.Contains(cest.CustomerEventScreeningTestId)
                                      select new { ecr.EventId, ecr.CustomerId, cest.TestId, cest.CustomerEventScreeningTestId }).ToArray();

                foreach (var customerCriticalData in criticalDataCollection)
                {
                    var eventCustomer =
                        eventCustomers.Where(ec => ec.CustomerEventScreeningTestId == customerCriticalData.Id).Single();

                    customerCriticalData.EventId = eventCustomer.EventId;
                    customerCriticalData.CustomerId = eventCustomer.CustomerId;
                    customerCriticalData.TestId = eventCustomer.TestId;
                }

                return criticalDataCollection;
            }
        }

        public CustomerCriticalData Save(CustomerCriticalData domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerCriticalData, CustomerEventCriticalTestDataEntity>(domainObject);
                if (domainObject.Id < 1)
                {
                    var linqMetaData = new LinqMetaData(adapter);
                    var id = (from ecr in linqMetaData.EventCustomerResult
                              join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                              where ecr.EventId == domainObject.EventId && ecr.CustomerId == domainObject.CustomerId && cest.TestId == domainObject.TestId
                              select cest.CustomerEventScreeningTestId).SingleOrDefault();
                    var inDb = GetbyId(id);

                    if (inDb != null)
                        entity.IsNew = false;

                    entity.CustomerEventScreeningTestId = id;
                }

                adapter.SaveEntity(entity, true);
                return Mapper.Map<CustomerEventCriticalTestDataEntity, CustomerCriticalData>(entity);
            }
        }

        public void Delete(long customerId, long eventId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var id = (from ecr in linqMetaData.EventCustomerResult
                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                          where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                          select cest.CustomerEventScreeningTestId).SingleOrDefault();

                adapter.UpdateEntitiesDirectly(new CustomerEventCriticalTestDataEntity { IsActive = false }, new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == id));
            }
        }

        public void Delete(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var ids = (from ecr in linqMetaData.EventCustomerResult
                           join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                           where ecr.EventId == eventId && ecr.CustomerId == customerId
                           select cest.CustomerEventScreeningTestId).ToArray();

                adapter.UpdateEntitiesDirectly(new CustomerEventCriticalTestDataEntity { IsActive = false }, new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == ids));
            }
        }

        public void Delete(IEnumerable<CustomerCriticalData> domainObjects)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(CustomerCriticalData domainObject)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CustomerCriticalData> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var ids = (from ecr in linqMetaData.EventCustomerResult
                           join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                           where eventCustomerIds.Contains(ecr.EventCustomerResultId)
                           select cest.CustomerEventScreeningTestId).ToArray();
                var expresion = new RelationPredicateBucket(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId == ids);
                expresion.PredicateExpression.AddWithAnd(CustomerEventCriticalTestDataFields.IsActive == true);

                return Get(expresion).ToArray();
            }
        }

        public Notes SaveCriticalNotes(long eventCustomerResultId, Notes notes)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                notes = ((IRepository<Notes>)_notesRepository).Save(notes);

                if (notes.Id > 0)
                {
                    adapter.SaveEntity(new CriticalCustomerCommunicationRecordEntity { NoteId = notes.Id, EventCustomerResultId = eventCustomerResultId });
                }

                return notes;
            }
        }

        public IEnumerable<Notes> GetNotes(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var notesIds = (from cccr in linqMetaData.CriticalCustomerCommunicationRecord
                                where cccr.EventCustomerResultId == eventCustomerResultId
                                select cccr.NoteId).ToArray();
                return _notesRepository.Get(notesIds);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEventCustomerResultIdNotesIdPair(IEnumerable<long> eventCustomerResultIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from cccr in linqMetaData.CriticalCustomerCommunicationRecord
                        where eventCustomerResultIds.Contains(cccr.EventCustomerResultId)
                        select new OrderedPair<long, long>(cccr.EventCustomerResultId, cccr.NoteId)).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, bool>> GetCriticalTestIdDataAvaliablePair(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecr in linqMetaData.EventCustomerResult
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                        join cetp in linqMetaData.CustomerEventTestPhysicianEvaluation on cest.CustomerEventScreeningTestId equals cetp.CustomerEventScreeningTestId
                        into queryableEcr
                        from qe in queryableEcr.DefaultIfEmpty(new CustomerEventTestPhysicianEvaluationEntity { IsCritical = false })
                        join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                        into queryableCritical
                        from qc in queryableCritical.DefaultIfEmpty()
                        where ecr.EventId == eventId && ecr.CustomerId == customerId
                        && (qe.IsCritical || (qc.CustomerEventScreeningTestId > 0 && (qc.IsActive.HasValue ? qc.IsActive.Value : true)))
                        select new OrderedPair<long, bool>(cest.TestId, qc.CustomerEventScreeningTestId > 0)).ToArray();
            }
        }
    }
}