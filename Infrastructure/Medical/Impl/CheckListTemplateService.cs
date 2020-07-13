using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{

    [DefaultImplementation]
    public class CheckListTemplateService : ICheckListTemplateService
    {
        private readonly ICheckListTemplateRepository _checkListTemplateRepository;
        private readonly ICheckListGroupRepository _checkListGroupRepository;
        private readonly ICheckListQuestionRepository _checkListQuestionRepository;
        private readonly ICheckListQuestionAnswerEditModelFactory _checkListQuestionAnswerEditModelFactory;

        public CheckListTemplateService(ICheckListTemplateRepository checkListTemplateRepository, ICheckListGroupRepository checkListGroupRepository, ICheckListQuestionRepository checkListQuestionRepository,
            ICheckListQuestionAnswerEditModelFactory checkListQuestionAnswerEditModelFactory)
        {
            _checkListTemplateRepository = checkListTemplateRepository;
            _checkListGroupRepository = checkListGroupRepository;
            _checkListQuestionRepository = checkListQuestionRepository;
            _checkListQuestionAnswerEditModelFactory = checkListQuestionAnswerEditModelFactory;
        }

        public CheckListTemplateEditModel GetbyId(long id)
        {
            var groupQuestions = _checkListTemplateRepository.GetAllGroupQuestions();
            var questions = _checkListQuestionRepository.GetAllQuestions();

            if (id <= 0) return new CheckListTemplateEditModel() { Questions = CreateChecklistGroupQuestionList(groupQuestions, questions, null) };

            var template = _checkListTemplateRepository.GetById(id);
            var selectedGroupQuestionIds = _checkListTemplateRepository.GetGroupQuestionIdsByTemplateId(id);

            return new CheckListTemplateEditModel
            {
                //HealthPlanId = template.HealthPlanId.HasValue ? template.HealthPlanId.Value : 0,
                Id = template.Id,
                IsActive = template.IsActive,
                IsPublished = template.IsPublished,
                Name = template.Name,
                Questions = CreateChecklistGroupQuestionList(groupQuestions, questions, selectedGroupQuestionIds),
                Type = template.Type
            };
        }

        private CheckListGroupQuestionEditModel[] CreateChecklistGroupQuestionList(IEnumerable<ChecklistGroupQuestion> groupQuestions, IEnumerable<CheckListQuestion> questions, IEnumerable<long> selectedGroupQuestionIds)
        {
            var checklistGroupQuestionList = new List<CheckListGroupQuestionEditModel>();
            foreach (var checklistGroupQuestion in groupQuestions)
            {
                var question = questions.FirstOrDefault(x => x.Id == checklistGroupQuestion.QuestionId);
                if (question == null) continue;
                checklistGroupQuestionList.Add(new CheckListGroupQuestionEditModel
                {
                    Id = checklistGroupQuestion.Id,
                    GroupId = checklistGroupQuestion.GroupId,
                    QuestionId = checklistGroupQuestion.QuestionId,
                    Index = question.Index,
                    ParentId = checklistGroupQuestion.ParentId.HasValue ? checklistGroupQuestion.ParentId.Value : 0,
                    Question = question.Question,
                    IsSelected = !selectedGroupQuestionIds.IsNullOrEmpty() && selectedGroupQuestionIds.Contains(checklistGroupQuestion.Id)
                });
            }

            return checklistGroupQuestionList.ToArray();
        }

        public CheckListTemplateEditModel SaveTemplate(CheckListTemplateEditModel model, long organizationRoleUserId)
        {
            CheckListTemplate templateinDb = null;

            var template = Mapper.Map<CheckListTemplateEditModel, CheckListTemplate>(model);

            if (template.Id > 0)
            {
                templateinDb = _checkListTemplateRepository.GetById(template.Id);
                template.CreatedBy = templateinDb.CreatedBy;
                template.DateCreated = templateinDb.DateCreated;
                template.DateModified = DateTime.Now;
                template.ModifiedBy = organizationRoleUserId;
            }
            else
            {
                template.CreatedBy = organizationRoleUserId;
                template.DateCreated = DateTime.Now;
                template.Type = model.Type;
            }

            //var groupQuestions = _checkListTemplateRepository.GetAllGroupQuestions();
            //var gpIds = model.Questions.Select(x => x.Id).ToArray();
            //var checklistTemplateList = new List<CheckListGroupQuestionEditModel>();

            //foreach (var groupQuestionId in gpIds)
            //{
            //    var groupQuestion = groupQuestions.Single(x => x.Id == groupQuestionId);
            //    checklistTemplateList.Add(new CheckListGroupQuestionEditModel { IsSelected = true, Id = groupQuestion.Id,GroupId = groupQuestion.GroupId, QuestionId = groupQuestion.QuestionId });
            //}

            //model.Questions = checklistTemplateList.ToArray();
            using (var scope = new TransactionScope())
            {
                template = _checkListTemplateRepository.Save(template, model.Questions.Where(x => x.IsSelected));
                scope.Complete();
            }

            model.Id = template.Id;

            return model;
        }


        public CheckListFormEditModel ViewTemplate(long templateId)
        {
            var template = _checkListTemplateRepository.GetById(templateId);
            var templateGroup = _checkListGroupRepository.GetAllGroups();
            var checklistGroupQuestions = _checkListTemplateRepository.GetAllGroupQuestionsForTemplateId(templateId);
            var checkListQuestion = _checkListQuestionRepository.GetAllQuestionsForTemplateId(template.Id);

            var answerList = new List<CheckListAnswer>();

            return new CheckListFormEditModel
            {
                Name = new Name(""),
                CheckListQuestion = _checkListQuestionAnswerEditModelFactory.CheckListQuestionAnswerEditModel(checkListQuestion, answerList, templateGroup, checklistGroupQuestions),
                Gender = Gender.Unspecified,
            };
        }
    }
}