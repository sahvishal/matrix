using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Exceptions;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class MedicareQuestionRepository : PersistenceRepository, IMedicareQuestionRepository
    {
        public IEnumerable<MedicareQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    linqMetaData.MedicareQuestion.Where(x=>x.IsActive).WithPath(prefetchPath =>
                                                        prefetchPath.Prefetch(p => p.MedicareGroupDependencyRule)
                                                            .Prefetch(p => p.MedicareQuestionDependencyRule)
                                                            .Prefetch(p => p.MedicareQuestionsRemarks)
                                                            ).ToArray();

                var questions = Mapper.Map<IEnumerable<MedicareQuestionEntity>, IEnumerable<MedicareQuestion>>(entities);
                return questions;
            }
        }

        public IEnumerable<MedicareQuestionGroup> GetAllGroups()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.MedicareQuestionGroup.ToArray();
                var questions = Mapper.Map<IEnumerable<MedicareQuestionGroupEntity>, IEnumerable<MedicareQuestionGroup>>(entities);

                return questions;
            }
        }

        public IEnumerable<MedicareQuestionAnswer> GetAnswersByEventCustomerId(long eventcustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    linqMetaData.CustomerMedicareQuestionAnswer.Where(x => x.EventCustomerId == eventcustomerId).ToArray();

                var answers = Mapper.Map<IEnumerable<CustomerMedicareQuestionAnswerEntity>, IEnumerable<MedicareQuestionAnswer>>(entities);

                return answers;
            }
        }

        public void SaveCustomerAnswer(IEnumerable<MedicareQuestionAnswer> customerAnswers, long customerEventId, long createdBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CustomerMedicareQuestionAnswerEntity), new RelationPredicateBucket(CustomerMedicareQuestionAnswerFields.EventCustomerId == customerEventId));

                var collection = new EntityCollection<CustomerMedicareQuestionAnswerEntity>();

                var entities = MapMultiple(customerAnswers, createdBy);

                collection.AddRange(entities);

                if (adapter.SaveEntityCollection(collection) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<MedicareQuestionsRemark> GetQuestionRemarks()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    linqMetaData.MedicareQuestionsRemarks.ToArray();

                var dependencyRule = Mapper.Map<IEnumerable<MedicareQuestionsRemarksEntity>, IEnumerable<MedicareQuestionsRemark>>(entities);

                return dependencyRule;
            }
        }

        private IEnumerable<CustomerMedicareQuestionAnswerEntity> MapMultiple(IEnumerable<MedicareQuestionAnswer> healthAssessmentAnswers, long createdBy)
        {
            return healthAssessmentAnswers.Select(x => Map(x, createdBy)).ToArray();
        }

        private CustomerMedicareQuestionAnswerEntity Map(MedicareQuestionAnswer domain, long createdBy)
        {
            var entity = new CustomerMedicareQuestionAnswerEntity
            {
                Answer = domain.Answer,
                EventCustomerId = domain.EventCustomerId,
                QuestionId = domain.QuestionId,
                CreateOn = DateTime.Now,
                CreateBy = createdBy
            };

            return entity;
        }


        public IEnumerable<OrderedPair<long, DateTime>> GetEvenetCustomerMedicareSavedDatePair(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cmqa in linqMetaData.CustomerMedicareQuestionAnswer
                                join ec in linqMetaData.EventCustomers on cmqa.EventCustomerId equals ec.EventCustomerId
                                where ec.EventId == eventId
                                select cmqa).GroupBy(cm => cm.EventCustomerId).Select(grp_ci => new OrderedPair<long, DateTime>(grp_ci.Key, grp_ci.Max(ci => (ci.CreateOn)))).ToArray();


                return entities;

            }

        }
    }
}