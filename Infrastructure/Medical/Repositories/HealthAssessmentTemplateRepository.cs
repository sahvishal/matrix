using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class HealthAssessmentTemplateRepository : PersistenceRepository, IHealthAssessmentTemplateRepository
    {
        public HealthAssessmentTemplate GetById(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(HafTemplateFields.HaftemplateId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<HealthAssessmentTemplate>(id);
            }
        }

        public IEnumerable<HealthAssessmentTemplate> GetByIds(IEnumerable<long> ids)
        {
            return Get(new RelationPredicateBucket(HafTemplateFields.HaftemplateId == ids.ToArray()));
        }

        private IEnumerable<HealthAssessmentTemplate> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var hafTemplateEntities = new EntityCollection<HafTemplateEntity>();

                var prefetchPath = new PrefetchPath2(EntityType.HafTemplateEntity) { HafTemplateEntity.PrefetchPathHafTemplateQuestion };

                adapter.FetchEntityCollection(hafTemplateEntities, expressionBucket, prefetchPath);

                var templates = Mapper.Map<IEnumerable<HafTemplateEntity>, IEnumerable<HealthAssessmentTemplate>>(hafTemplateEntities);

                return templates.OrderBy(t => t.Name).ToArray();
            }
        }

        public HealthAssessmentTemplate Save(HealthAssessmentTemplate healthAssessmentTemplate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    var entity = Mapper.Map<HealthAssessmentTemplate, HafTemplateEntity>(healthAssessmentTemplate);

                    if (healthAssessmentTemplate.IsDefault && healthAssessmentTemplate.IsPublished && healthAssessmentTemplate.Category == (long)HealthAssessmentTemplateCategory.HealthAssessmentTemplate)
                    {
                        UpdateDefaultStatus((HealthAssessmentTemplateType)healthAssessmentTemplate.TemplateType.Value);
                    }

                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }

                    DeleteHealthAssessmentTemplateQuestion(entity.HaftemplateId);
                    SaveHealthAssessmentTemplatequestion(entity.HaftemplateId, healthAssessmentTemplate.QuestionIds);
                    var template = GetById(entity.HaftemplateId);
                    scope.Complete();
                    return template;
                }
            }
        }

        private void DeleteHealthAssessmentTemplateQuestion(long healthAssessmentTemplateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HafTemplateQuestionFields.HaftemplateId == healthAssessmentTemplateId);
                adapter.DeleteEntitiesDirectly(typeof(HafTemplateQuestionEntity), relationPredicateBucket);
            }
        }

        private void SaveHealthAssessmentTemplatequestion(long healthAssessmentTemplateId, IEnumerable<long> questionIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HafTemplateQuestionEntity>();
                foreach (var questionId in questionIds)
                {
                    entities.Add(new HafTemplateQuestionEntity(healthAssessmentTemplateId, questionId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<HealthAssessmentTemplate> GetHealthAssessmentTemplate(HealthAssessmentTemplateListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    totalRecords = linqMetaData.HafTemplate.Count();
                    var entities = linqMetaData.HafTemplate.OrderByDescending(t => t.IsActive).OrderBy(t => t.Name).TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.Map<IEnumerable<HafTemplateEntity>, IEnumerable<HealthAssessmentTemplate>>(entities);
                }
                else
                {
                    var query = from t in linqMetaData.HafTemplate where t.Category == filter.Category && ((filter.Active ? t.IsActive : true) && (filter.Inactive ? !t.IsActive : true)) select t;

                    if (filter.TemplateType > 0)
                        query = from t in query where t.Type == filter.TemplateType select t;

                    if (!string.IsNullOrEmpty(filter.Name))
                        query = from t in query where t.Name.Contains(filter.Name) select t;

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.IsActive).OrderBy(p => p.Name).TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.Map<IEnumerable<HafTemplateEntity>, IEnumerable<HealthAssessmentTemplate>>(entities);
                }
            }
        }

        public HealthAssessmentTemplate GetByName(string name)
        {
            return Get(new RelationPredicateBucket(HafTemplateFields.Name == name)).SingleOrDefault();
        }

        public IEnumerable<HealthAssessmentTemplate> GetByType(HealthAssessmentTemplateType type)
        {
            var relationPredicateBucket = new RelationPredicateBucket(HafTemplateFields.Type == (long)type);
            relationPredicateBucket.PredicateExpression.Add(HafTemplateFields.IsPublished == true);
            relationPredicateBucket.PredicateExpression.Add(HafTemplateFields.IsActive == true);

            return Get(relationPredicateBucket);
        }

        public void UpdateDefaultStatus(HealthAssessmentTemplateType type)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new HafTemplateEntity() { IsDefault = false };
                var bucket = new RelationPredicateBucket(HafTemplateFields.Type == (long)type);
                try
                {
                    myAdapter.UpdateEntitiesDirectly(entity, bucket);
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public void PublishTemplate(long templateId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new HafTemplateEntity() { IsPublished = true };
                var bucket = new RelationPredicateBucket(HafTemplateFields.HaftemplateId == (long)templateId);
                try
                {
                    myAdapter.UpdateEntitiesDirectly(entity, bucket);
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public IEnumerable<HealthAssessmentTemplate> GetByCategory(HealthAssessmentTemplateCategory category)
        {
            var relationPredicateBucket = new RelationPredicateBucket(HafTemplateFields.Category == (long)category);
            relationPredicateBucket.PredicateExpression.Add(HafTemplateFields.IsPublished == true);
            relationPredicateBucket.PredicateExpression.Add(HafTemplateFields.IsActive == true);

            return Get(relationPredicateBucket);
        }
    }
}
