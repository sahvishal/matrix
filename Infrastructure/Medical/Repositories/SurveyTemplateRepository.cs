using AutoMapper;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class SurveyTemplateRepository : PersistenceRepository, ISurveyTemplateRepository
    {
        public SurveyTemplate GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                try
                {
                    var query = (from clt in linqMetaData.SurveyTemplate where clt.Id == id select clt).First();

                    return Mapper.Map<SurveyTemplateEntity, SurveyTemplate>(query);
                }
                catch (InvalidOperationException)
                {
                    throw new ObjectNotFoundInPersistenceException<SurveyTemplate>(id);
                }
            }
        }

        public IEnumerable<SurveyTemplate> GetAllTemplates()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.SurveyTemplate.Where(x => x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<SurveyTemplateEntity>, IEnumerable<SurveyTemplate>>(entities);
            }
        }

        public SurveyTemplate GetDefaultTemplate()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = linqMetaData.SurveyTemplate.Single(x => x.IsActive && x.IsPublished && x.IsDefault);

                return Mapper.Map<SurveyTemplateEntity, SurveyTemplate>(entity);
            }
        }

        public IEnumerable<SurveyTemplate> GetTemplatesByFilters(SurveyTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = linqMetaData.SurveyTemplate.Where(x => x.IsActive);

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = query.Where(x => x.Name.Contains(filter.Name));
                }

                totalRecords = query.Count();
                var entities = query.OrderByDescending(p => p.IsActive).OrderBy(p => p.Name).TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<SurveyTemplateEntity>, IEnumerable<SurveyTemplate>>(entities);
            }
        }

        public SurveyTemplate GetByName(string name)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from clt in linqMetaData.SurveyTemplate where clt.Name == name select clt).FirstOrDefault();

                return entity == null ? null : Mapper.Map<SurveyTemplateEntity, SurveyTemplate>(entity);
            }
        }

        public SurveyTemplate Save(SurveyTemplate SurveyTemplate, IEnumerable<SurveyQuestionEditModel> questions)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    var entity = Mapper.Map<SurveyTemplate, SurveyTemplateEntity>(SurveyTemplate);

                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }

                    DeleteSurveyTemplateQuestion(entity.Id);

                    SaveSurveyTemplateQuestion(entity.Id, questions);

                    var template = GetById(entity.Id);

                    scope.Complete();
                    return template;
                }
            }
        }

        private void DeleteSurveyTemplateQuestion(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(SurveyTemplateQuestionFields.TemplateId == templateId);
                adapter.DeleteEntitiesDirectly(typeof(SurveyTemplateQuestionEntity), relationPredicateBucket);
            }
        }

        private void SaveSurveyTemplateQuestion(long templateId, IEnumerable<SurveyQuestionEditModel> questions)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<SurveyTemplateQuestionEntity>();
                foreach (var question in questions)
                {
                    entities.Add(new SurveyTemplateQuestionEntity
                    {
                        TemplateId = templateId,
                        QuestionId = question.Id
                    });
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<long> GetQuestionIdsByTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return linqMetaData.SurveyTemplateQuestion.Where(x => x.TemplateId == templateId).Select(x => x.QuestionId).ToArray();
            }
        }

        public SurveyTemplate GetTemplateByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventSurveyTemplate = linqMetaData.EventSurveyTemplate.SingleOrDefault(x => x.EventId == eventId);

                var entity = eventSurveyTemplate != null ? linqMetaData.SurveyTemplate.SingleOrDefault(x => x.Id == eventSurveyTemplate.SurveyTemplateId) : null;

                return Mapper.Map<SurveyTemplateEntity, SurveyTemplate>(entity);
            }
        }
    }
}
