using System;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class HealthAssessmentRepository : PersistenceRepository, IHealthAssessmentRepository
    {
        private readonly IHealthAssessmentFactory _healthAssessmentFactory;

        public HealthAssessmentRepository(IHealthAssessmentFactory healthAssessmentFactory)
        {
            _healthAssessmentFactory = healthAssessmentFactory;
        }

        public IEnumerable<HealthAssessmentQuestion> GetAllQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CustomerHealthQuestions.ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public IEnumerable<HealthAssessmentAnswer> Get(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from chi in linqMetaData.CustomerHealthInfo
                                join ec in linqMetaData.EventCustomers on chi.EventCustomerId equals ec.EventCustomerId
                                where ec.EventId == eventId && ec.CustomerId == customerId
                                select chi).ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public IEnumerable<HealthAssesmentArchiveAnswer> GetArchive(long customerId, long eventId, int versionNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from chia in linqMetaData.CustomerHealthInfoArchive
                                join ec in linqMetaData.EventCustomers on chia.EventCustomerId equals ec.EventCustomerId
                                where ec.EventId == eventId && ec.CustomerId == customerId
                                && chia.Version == versionNumber
                                select chia).ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public long GetLastVersionNumber(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from a in linqMetaData.CustomerHealthInfoArchive where a.EventCustomerId == eventCustomerId select a.Version).Max();
            }
        }

        public void Save(IEnumerable<HealthAssessmentAnswer> answer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = _healthAssessmentFactory.MapMultiple(answer);
                var collection = new EntityCollection<CustomerHealthInfoEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        public void Delete(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("CustomerHealthInfoEntity", new RelationPredicateBucket(CustomerHealthInfoFields.EventCustomerId == eventCustomerId));
            }
        }

        public void SaveArchive(IEnumerable<HealthAssessmentAnswer> domainCollection, long versionNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = _healthAssessmentFactory.MapMultiple(versionNumber, domainCollection);
                var collection = new EntityCollection<CustomerHealthInfoArchiveEntity>();
                collection.AddRange(entities);
                adapter.SaveEntityCollection(collection);
            }
        }

        public void Save(HealthAssessmentAnswer answer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _healthAssessmentFactory.Map(answer);
                entity.IsNew =
                    !adapter.FetchEntity(new CustomerHealthInfoEntity
                                            {
                                                CustomerId = answer.CustomerId,
                                                EventCustomerId = answer.EventCustomerId,
                                                CustomerHealthQuestionId = answer.QuestionId
                                            });
                adapter.SaveEntity(entity);
            }
        }

        public HealthAssessmentQuestion GetQuestionByLabel(string label)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from chq in linqMetaData.CustomerHealthQuestions
                              where chq.Label == label
                              select chq).SingleOrDefault();
                if (entity == null)
                    return null;
                return _healthAssessmentFactory.Map(entity);
            }
        }

        public IEnumerable<HealthAssessmentAnswer> GetByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CustomerHealthInfo.Where(i => customerIds.Contains(i.CustomerId)).ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetCustomerIdsforFilledHealthAssmtFormbyEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join haf in linqMetaData.CustomerHealthInfo on ec.EventCustomerId equals haf.EventCustomerId
                        where ec.EventId == eventId
                        select ec.CustomerId).Distinct().ToArray();

            }
        }

        public IEnumerable<HealthAssessmentQuestionGroup> GetAllQuestionGroupWithQuestion(bool showOnlyClinicalQuestion = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from q in linqMetaData.CustomerHealthQuestionGroup select q);

                if (showOnlyClinicalQuestion)
                    query = query.Where(q => q.IsClinicalQuestions);

                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(questionGroup => questionGroup.CustomerHealthQuestions))
                        .Where(questionGroup => questionGroup.IsActive);

                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public IEnumerable<HealthAssessmentQuestion> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from chq in linqMetaData.CustomerHealthQuestions
                                where ids.Contains(chq.CustomerHealthQuestionId)
                                select chq).ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public int GetLastVersionNumberUpdatedByCustomerOrOtherThanTechnician(long eventCustomerId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var technicianRoleId = (long)Roles.Technician;

                var technicianIds = (from oru in linqMetaData.OrganizationRoleUser
                                     join role in linqMetaData.Role on oru.RoleId equals role.RoleId
                                     where (role.RoleId == technicianRoleId || role.ParentId == technicianRoleId) && oru.IsActive
                                     select oru.OrganizationRoleUserId);

                var lastVersion = (from a in linqMetaData.CustomerHealthInfoArchive
                                   where a.EventCustomerId == eventCustomerId
                                   && (a.CreatedByOrgRoleUserId != null && (a.CreatedByOrgRoleUserId == customerId || !technicianIds.Contains(a.CreatedByOrgRoleUserId.Value)))
                                   select a.Version).Max();

                return (int)lastVersion;
            }

        }

        public IEnumerable<OrderedPair<long, DateTime>> GetHealthAssesmentSavedDatePair(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.CustomerHealthInfo.Where(ci => eventCustomerIds.Contains(ci.EventCustomerId)).GroupBy(ci => ci.EventCustomerId).
                        Select(grp_ci => new OrderedPair<long, DateTime>(grp_ci.Key, grp_ci.Max(ci => (ci.DateModified ?? ci.DateCreated) ?? DateTime.Now))).ToArray();

            }
        }

        public IEnumerable<HealthAssessmentQuestionGroup> GetQuestionWithGroupForTemplatId(long templatId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from hafTemlateQuestion in linqMetaData.HafTemplateQuestion
                             join chq in linqMetaData.CustomerHealthQuestions on hafTemlateQuestion.QuestionId equals chq.CustomerHealthQuestionId
                             join chqg in linqMetaData.CustomerHealthQuestionGroup on chq.CustomerHealthQuestionGroupId equals chqg.CustomerHealthQuestionGroupId
                             where hafTemlateQuestion.HaftemplateId == templatId
                             select chqg);
                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(questionGroup => questionGroup.CustomerHealthQuestions));

                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public IEnumerable<HealthAssessmentAnswer> GetAnswerByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CustomerHealthInfo.Where(i => i.EventCustomerId == eventCustomerId).ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }

        public IEnumerable<HealthAssessmentAnswer> GetCustomerHealthInfoByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from c in linqMetaData.CustomerHealthInfo
                                where eventCustomerIds.Contains(c.EventCustomerId)
                                select c).ToArray();
                return _healthAssessmentFactory.MapMultiple(entities);
            }
        }
    }
}
