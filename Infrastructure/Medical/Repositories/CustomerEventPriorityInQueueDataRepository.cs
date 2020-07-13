using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CustomerEventPriorityInQueueDataRepository : PersistenceRepository, ICustomerEventPriorityInQueueDataRepository
    {
        private readonly IPriorityInQueueRepository _priorityInQueueRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly INotesRepository _notesRepository;
        private readonly ISettings _settings;

        public CustomerEventPriorityInQueueDataRepository(IPriorityInQueueRepository priorityInQueueRepository, IEventCustomerResultRepository eventCustomerResultRepository, INotesRepository notesRepository, ISettings settings)
        {
            _priorityInQueueRepository = priorityInQueueRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _notesRepository = notesRepository;
            _settings = settings;
        }

        public CustomerEventPriorityInQueueData GetByCustomerEventScreeningTestId(long customerEventScreeningTestId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.CustomerEventPriorityInQueueData.SingleOrDefault(cePiq => cePiq.CustomerEventScreeningTestId == customerEventScreeningTestId && cePiq.IsActive);
                if (entity == null)
                    return null;

                return Mapper.Map<CustomerEventPriorityInQueueDataEntity, CustomerEventPriorityInQueueData>(entity);

            }
        }

        public CustomerEventPriorityInQueueData GetByCustomerEventScreeningTestIdWithoutIsActive(long customerEventScreeningTestId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.CustomerEventPriorityInQueueData.SingleOrDefault(cePiq => cePiq.CustomerEventScreeningTestId == customerEventScreeningTestId);
                if (entity == null)
                    return null;

                return Mapper.Map<CustomerEventPriorityInQueueDataEntity, CustomerEventPriorityInQueueData>(entity);

            }
        }

        public CustomerEventPriorityInQueueData Save(CustomerEventPriorityInQueueData domainObject, long eventId, long customerId, long testId, long createdByOrgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var isSaved = false;
                var entity = Mapper.Map<CustomerEventPriorityInQueueData, CustomerEventPriorityInQueueDataEntity>(domainObject);

                if (domainObject.CustomerEventScreeningTestID < 1)
                {
                    var linqMetaData = new LinqMetaData(adapter);
                    var id = (from ecr in linqMetaData.EventCustomerResult
                              join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                              where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                              select cest.CustomerEventScreeningTestId).SingleOrDefault();
                    var inDb = GetByCustomerEventScreeningTestIdWithoutIsActive(id);

                    if (inDb != null)
                    {
                        entity.IsNew = false;
                        entity.IsActive = true;
                    }


                    entity.CustomerEventScreeningTestId = id;
                    isSaved = true;
                }

                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
                if (isSaved)
                {
                    var piq = _priorityInQueueRepository.GetByEventIdCustomerId(eventId, customerId);
                    if (piq == null)
                    {
                        var ecrID = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                        if (ecrID != null)
                        {
                            var metaData = new DataRecorderMetaData(createdByOrgRoleUserId, DateTime.Now, DateTime.Now);
                            var newNote = new Notes() { Text = "", DataRecorderMetaData = metaData };
                            newNote = _notesRepository.Save(newNote);

                            piq = new PriorityInQueue
                            {
                                EventCustomerResultId = ecrID.Id,
                                NoteId = newNote.Id,
                                CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                                ModifiedByOrgRoleUserId = createdByOrgRoleUserId,
                                InQueuePriority = _priorityInQueueRepository.GetMaxPriorityInQueue(),
                                IsActive = true
                            };

                            piq.DateCreated = piq.DateModified = DateTime.Now;
                            _priorityInQueueRepository.Save(piq);
                        }
                    }
                }

                return Mapper.Map<CustomerEventPriorityInQueueDataEntity, CustomerEventPriorityInQueueData>(entity);
            }
        }

        public CustomerEventPriorityInQueueData Get(long eventId, long customerId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var id = (from ecr in linqMetaData.EventCustomerResult
                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                          where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                          select cest.CustomerEventScreeningTestId).SingleOrDefault();
                var expresion = new RelationPredicateBucket(CustomerEventPriorityInQueueDataFields.CustomerEventScreeningTestId == id);
                expresion.PredicateExpression.AddWithAnd(CustomerEventPriorityInQueueDataFields.IsActive == true);

                return Get(expresion).SingleOrDefault();
            }
        }

        private IEnumerable<CustomerEventPriorityInQueueData> Get(IRelationPredicateBucket expression)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<CustomerEventPriorityInQueueDataEntity>();
                adapter.FetchEntityCollection(collection, expression);
                var priorityDataCollection = Mapper.Map<IEnumerable<CustomerEventPriorityInQueueDataEntity>, IEnumerable<CustomerEventPriorityInQueueData>>(collection.AsEnumerable());
                return priorityDataCollection;
            }
        }

        public void Delete(long customerId, long eventId, long testId, long createdByOrgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var id = (from ecr in linqMetaData.EventCustomerResult
                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                          where ecr.EventId == eventId && ecr.CustomerId == customerId && cest.TestId == testId
                          select cest.CustomerEventScreeningTestId).SingleOrDefault();

                adapter.UpdateEntitiesDirectly(new CustomerEventPriorityInQueueDataEntity { IsActive = false }, new RelationPredicateBucket(CustomerEventPriorityInQueueDataFields.CustomerEventScreeningTestId == id));
            }
        }


        public IEnumerable<CustomerEventPriorityInQueueData> GetByCustomerEventScreeningTestIds(List<long> customerEventScreeningTestIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.CustomerEventPriorityInQueueData.Where(cePiq => customerEventScreeningTestIds.Contains(cePiq.CustomerEventScreeningTestId) && cePiq.IsActive);


                return Mapper.Map<IEnumerable<CustomerEventPriorityInQueueDataEntity>, IEnumerable<CustomerEventPriorityInQueueData>>(entity);

            }
        }

        public IEnumerable<CustomerEventPriorityInQueueData> GetByEventCustomerResultId(long evencustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecr in linqMetaData.EventCustomerResult
                                join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                                join cepiq in linqMetaData.CustomerEventPriorityInQueueData on cest.CustomerEventScreeningTestId equals cepiq.CustomerEventScreeningTestId
                                where ecr.EventCustomerResultId == evencustomerResultId
                                && cepiq.IsActive && cets.IsPriorityInQueue
                                select cepiq).ToArray();

                return Mapper.Map<IEnumerable<CustomerEventPriorityInQueueDataEntity>, IEnumerable<CustomerEventPriorityInQueueData>>(entities);
            }
        }

        public IEnumerable<long> GetEventCustomerResultIdsForPriorityInQueueNotification(int daysToCheck)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var checkDate = DateTime.Now.Date.AddDays(-1 * daysToCheck);

                return (from ecr in linqMetaData.EventCustomerResult
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                        join cepiq in linqMetaData.CustomerEventPriorityInQueueData on cest.CustomerEventScreeningTestId equals cepiq.CustomerEventScreeningTestId
                        where cepiq.IsActive && cets.IsPriorityInQueue
                        &&
                           (
                                (
                                    (   cets.EvaluationState == (long)TestResultStateNumber.ResultsUploaded 
                                        || cets.EvaluationState == (long)TestResultStateNumber.ManualEntry
                                    ) 
                                    && cets.IsPartial == false 
                                    && e.EventDate < _settings.ResultFlowChangeDate
                                ) 
                                || 
                                (
                                    e.EventDate >= _settings.ResultFlowChangeDate 
                                    && (
                                            cets.EvaluationState == (long)NewTestResultStateNumber.ResultEntryPartial || 
                                            cets.EvaluationState == (long)NewTestResultStateNumber.ResultEntryCompleted
                                        )
                                )
                            )

                        && (cepiq.DateCreated >= checkDate || (cepiq.DateModified.HasValue ? cepiq.DateModified.Value >= checkDate : false))
                        select ecr.EventCustomerResultId).Distinct().ToArray();
            }
        }

        public IEnumerable<CustomerEventPriorityInQueueDataViewModel> GetPriorityInQueueViewDataByEventCustomerResultId(long evencustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ecr in linqMetaData.EventCustomerResult
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                        join cepiq in linqMetaData.CustomerEventPriorityInQueueData on cest.CustomerEventScreeningTestId equals cepiq.CustomerEventScreeningTestId
                        where ecr.EventCustomerResultId == evencustomerResultId
                        && cepiq.IsActive && cets.IsPriorityInQueue
                        select new CustomerEventPriorityInQueueDataViewModel
                        {
                            TestId = cest.TestId,
                            PriorityInQueueReason = cepiq.Note
                        }).ToArray();


            }
        }
    }
}
