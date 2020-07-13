using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class PreQualificationTestTemplateRepository : PersistenceRepository, IPreQualificationTestTemplateRepository
    {
        public IEnumerable<PreQualificationTestTemplate> GetByTestId(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationTestTemplate
                                where q.TestId == testId && q.IsActive == true && q.IsPublished == true
                                select q).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationTestTemplateEntity>, IEnumerable<PreQualificationTestTemplate>>(entities);
            }
        }

        public PreQualificationTestTemplate GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from q in linqMetaData.PreQualificationTestTemplate
                              where q.Id == id && q.IsActive == true
                              select q).FirstOrDefault();

                if (entity == null) return null;

                return Mapper.Map<PreQualificationTestTemplateEntity, PreQualificationTestTemplate>(entity);
            }
        }

        public PreQualificationTestTemplate Save(PreQualificationTestTemplate domainObject, IEnumerable<PreQualifiedQuestionEditModel> questions)
        {
            if (domainObject == null) return null;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    var entity = Mapper.Map<PreQualificationTestTemplate, PreQualificationTestTemplateEntity>(domainObject);

                    if (!adapter.SaveEntity(entity))
                        throw new PersistenceFailureException();

                    DeletePreQualificationTemplateQuestion(entity.Id);
                    SavePreQualificationTemplateQuestion(entity.Id, questions);

                    var template = GetById(entity.Id);

                    scope.Complete();
                    return template;
                }
            }
        }

        public IEnumerable<long> GetQuestionIdsByTemplateId(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from q in linqMetaData.PreQualificationTemplateQuestion
                        where q.TemplateId == id
                        select q.QuestionId).ToArray();
            }
        }

        private void DeletePreQualificationTemplateQuestion(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(PreQualificationTemplateQuestionFields.TemplateId == templateId);
                adapter.DeleteEntitiesDirectly(typeof(PreQualificationTemplateQuestionEntity), relationPredicateBucket);
            }
        }

        private void SavePreQualificationTemplateQuestion(long templateId, IEnumerable<PreQualifiedQuestionEditModel> questions)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<PreQualificationTemplateQuestionEntity>();
                foreach (var question in questions)
                {
                    entities.Add(new PreQualificationTemplateQuestionEntity
                    {
                        TemplateId = templateId,
                        QuestionId = question.Id
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<PreQualificationTestTemplate> GetByFilters(PreQualifiedQuestionTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = linqMetaData.PreQualificationTestTemplate.Where(x => x.IsActive == true);

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = query.Where(x => x.TemplateName.Contains(filter.Name));
                }

                if (filter.TestId > 0)
                {
                    query = query.Where(x => x.TestId == filter.TestId);
                }

                totalRecords = query.Count();
                var entities = query.OrderByDescending(p => p.IsActive).OrderBy(p => p.TemplateName).TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationTestTemplateEntity>, IEnumerable<PreQualificationTestTemplate>>(entities);
            }
        }

        public PreQualificationTestTemplate GetByName(string templateName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from q in linqMetaData.PreQualificationTestTemplate where q.TemplateName.ToLower() == templateName select q).FirstOrDefault();
                if (entity == null) return null;
                return Mapper.Map<PreQualificationTestTemplateEntity, PreQualificationTestTemplate>(entity);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetTemplateIdQuestionIdPairByTemplateIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from q in linqMetaData.PreQualificationTemplateQuestion
                        where ids.Contains(q.TemplateId)
                        select new OrderedPair<long, long>(q.TemplateId, q.QuestionId)).ToArray();
            }
        }

        public IEnumerable<PreQualificationTestTemplate> GetByIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationTestTemplate
                                where ids.Contains(q.Id) && q.IsActive == true
                                select q);

                return Mapper.Map<IEnumerable<PreQualificationTestTemplateEntity>, IEnumerable<PreQualificationTestTemplate>>(entities);
            }
        }

        public IEnumerable<PreQualificationTestTemplate> GetByTemplateIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.PreQualificationTestTemplate
                                where ids.Contains(q.Id)
                                select q).ToArray();

                return Mapper.Map<IEnumerable<PreQualificationTestTemplateEntity>, IEnumerable<PreQualificationTestTemplate>>(entities);
            }
        }
    }
}
