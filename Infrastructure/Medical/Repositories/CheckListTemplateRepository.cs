using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CheckListTemplateRepository : PersistenceRepository, ICheckListTemplateRepository
    {

        public CheckListTemplate GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                try
                {
                    var query = (from clt in linqMetaData.CheckListTemplate where clt.Id == id select clt).First();

                    return Mapper.Map<CheckListTemplateEntity, CheckListTemplate>(query);
                }
                catch (InvalidOperationException)
                {
                    throw new ObjectNotFoundInPersistenceException<CheckListTemplate>(id);
                }
            }

        }

        public IEnumerable<CheckListTemplate> GetAllTemplates()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CheckListTemplate.Where(x => x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<CheckListTemplateEntity>, IEnumerable<CheckListTemplate>>(entities);
            }
        }

        public IEnumerable<CheckListTemplate> GetTemplatesByFilters(CheckListTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = linqMetaData.CheckListTemplate.Where(x => x.IsActive);

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    query = query.Where(x => x.Name.Contains(filter.Name));
                }

                if (filter.HealthPlanId > 0)
                {
                    query = query.Where(x => x.HealthPlanId.HasValue && x.HealthPlanId.Value == filter.HealthPlanId);
                }
                if (filter.CheckListTypeId > 0)
                {
                    query = query.Where(x => x.Type== filter.CheckListTypeId);
                }

                totalRecords = query.Count();
                var entities = query.OrderByDescending(p => p.IsActive).OrderBy(p => p.Name).TakePage(pageNumber, pageSize).ToArray();

                return Mapper.Map<IEnumerable<CheckListTemplateEntity>, IEnumerable<CheckListTemplate>>(entities);
            }
        }

        public CheckListTemplate GetDefaultTemplate()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = linqMetaData.CheckListTemplate.Single(x => x.IsActive && x.IsPublished && x.IsDefault);

                return Mapper.Map<CheckListTemplateEntity, CheckListTemplate>(entity);
            }
        }


        public CheckListTemplate GetTemplateByHealthPlanId(long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.CheckListTemplate.SingleOrDefault(x => x.IsActive && x.HealthPlanId.HasValue && x.HealthPlanId.Value == healthPlanId);

                return entity == null ? null : Mapper.Map<CheckListTemplateEntity, CheckListTemplate>(entity);
            }
        }

        public CheckListTemplate GetByName(string name)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from clt in linqMetaData.CheckListTemplate where clt.Name == name select clt).FirstOrDefault();

                return entity == null ? null : Mapper.Map<CheckListTemplateEntity, CheckListTemplate>(entity);
            }
        }

        public CheckListTemplate Save(CheckListTemplate checkListTemplate, IEnumerable<CheckListGroupQuestionEditModel> questions)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    var entity = Mapper.Map<CheckListTemplate, CheckListTemplateEntity>(checkListTemplate);

                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }

                    DeleteHealthAssessmentTemplateQuestion(entity.Id);

                    SaveHealthAssessmentTemplatequestion(entity.Id, questions);

                    var template = GetById(entity.Id);

                    scope.Complete();
                    return template;
                }
            }
        }

        private void DeleteHealthAssessmentTemplateQuestion(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(CheckListTemplateQuestionFields.TemplateId == templateId);
                adapter.DeleteEntitiesDirectly(typeof(CheckListTemplateQuestionEntity), relationPredicateBucket);
            }
        }

        private void SaveHealthAssessmentTemplatequestion(long templateId, IEnumerable<CheckListGroupQuestionEditModel> questions)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CheckListTemplateQuestionEntity>();
                foreach (var question in questions)
                {
                    entities.Add(new CheckListTemplateQuestionEntity
                    {
                        TemplateId = templateId,
                        GroupQuestionId = question.Id,
                        QuestionId = question.QuestionId
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

                return linqMetaData.CheckListTemplateQuestion.Where(x => x.TemplateId == templateId).Select(x => x.QuestionId).ToArray();
            }
        }

        public IEnumerable<ChecklistGroupQuestion> GetAllGroupQuestions()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.ChecklistGroupQuestion.Where(x => x.IsActive).ToArray();

                return Mapper.Map<IEnumerable<ChecklistGroupQuestionEntity>, IEnumerable<ChecklistGroupQuestion>>(entities);
            }
        }

        public IEnumerable<long> GetGroupQuestionIdsByTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return linqMetaData.CheckListTemplateQuestion.Where(x => x.TemplateId == templateId).Select(x => x.GroupQuestionId).ToArray();
            }
        }

        public IEnumerable<ChecklistGroupQuestion> GetAllGroupQuestionsForTemplateId(long templateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from clgq in linqMetaData.ChecklistGroupQuestion
                                join cltq in linqMetaData.CheckListTemplateQuestion on clgq.Id equals cltq.GroupQuestionId
                                where clgq.IsActive && cltq.TemplateId == templateId
                                select clgq).ToArray();

                return Mapper.Map<IEnumerable<ChecklistGroupQuestionEntity>, IEnumerable<ChecklistGroupQuestion>>(entities);
            }
        }

        public CheckListTemplate GetTemplateByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventChecklistTemplate = linqMetaData.EventChecklistTemplate.SingleOrDefault(x => x.EventId == eventId);

                var entity = eventChecklistTemplate != null ? linqMetaData.CheckListTemplate.SingleOrDefault(x => x.Id == eventChecklistTemplate.ChecklistTemplateId) : null;

                return Mapper.Map<CheckListTemplateEntity, CheckListTemplate>(entity);
            }
        }
    }
}