using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SurveyTemplateService : ISurveyTemplateService
    {
        private readonly ISurveyTemplateRepository _SurveyTemplateRepository;
        private readonly ISurveyQuestionRepository _SurveyQuestionRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISurveyQuestionAnswerEditModelFactory _SurveyQuestionAnswerEditModelFactory;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;

        public SurveyTemplateService(ISurveyTemplateRepository SurveyTemplateRepository, ISurveyQuestionRepository SurveyQuestionRepository,
            ICorporateAccountRepository corporateAccountRepository, ISurveyQuestionAnswerEditModelFactory SurveyQuestionAnswerEditModelFactory,
            ISurveyAnswerRepository surveyAnswerRepository)
        {
            _SurveyTemplateRepository = SurveyTemplateRepository;
            _SurveyQuestionRepository = SurveyQuestionRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _SurveyQuestionAnswerEditModelFactory = SurveyQuestionAnswerEditModelFactory;
            _surveyAnswerRepository = surveyAnswerRepository;
        }

        public SurveyTemplateEditModel SaveTemplate(SurveyTemplateEditModel model, long organizationRoleUserId)
        {
            SurveyTemplate templateInDb = null;

            var template = Mapper.Map<SurveyTemplateEditModel, SurveyTemplate>(model);

            if (template.Id > 0)
            {
                templateInDb = _SurveyTemplateRepository.GetById(template.Id);
                template.CreatedBy = templateInDb.CreatedBy;
                template.DateCreated = templateInDb.DateCreated;
                template.DateModified = DateTime.Now;
                template.ModifiedBy = organizationRoleUserId;
            }
            else
            {
                template.CreatedBy = organizationRoleUserId;
                template.DateCreated = DateTime.Now;
            }

            using (var scope = new TransactionScope())
            {
                template = _SurveyTemplateRepository.Save(template, model.Questions.Where(x => x.IsSelected));
                scope.Complete();
            }

            model.Id = template.Id;

            return model;
        }

        public SurveyTemplateEditModel GetbyId(long id)
        {
            var questions = _SurveyQuestionRepository.GetAllQuestions();

            if (id <= 0) return new SurveyTemplateEditModel() { Questions = CreateSurveyQuestionList(questions, null) };

            var template = _SurveyTemplateRepository.GetById(id);
            var selectedQuestionIds = _SurveyTemplateRepository.GetQuestionIdsByTemplateId(id);

            return new SurveyTemplateEditModel
            {
                Id = template.Id,
                IsActive = template.IsActive,
                IsPublished = template.IsPublished,
                Name = template.Name,
                Questions = CreateSurveyQuestionList(questions, selectedQuestionIds),
            };
        }

        private SurveyQuestionEditModel[] CreateSurveyQuestionList(IEnumerable<SurveyQuestion> questions, IEnumerable<long> selectedQuestionIds)
        {
            if (questions.IsNullOrEmpty()) return new List<SurveyQuestionEditModel>().ToArray();

            return questions.Select(x => new SurveyQuestionEditModel()
            {
                Id = x.Id,
                Index = x.Index,
                ParentId = x.ParentId.HasValue ? x.ParentId.Value : 0,
                Question = x.Question,
                IsSelected = !selectedQuestionIds.IsNullOrEmpty() && selectedQuestionIds.Contains(x.Id)

            }).ToArray();
        }

        public SurveyFormEditModel ViewTemplate(long templateId)
        {
            var template = _SurveyTemplateRepository.GetById(templateId);
            var surveyQuestion = _SurveyQuestionRepository.GetAllQuestionsForTemplateId(template.Id);

            var answerList = new List<SurveyAnswer>();

            return new SurveyFormEditModel
            {
                Name = new Name(""),
                SurveyQuestion = _SurveyQuestionAnswerEditModelFactory.SurveyQuestionAnswerEditModel(surveyQuestion, answerList),
                Gender = Gender.Unspecified,
            };
        }

        public List<SurveyTemplateViewModel> GetSurveyTemplateList(SurveyTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var list = new List<SurveyTemplateViewModel>();
            var templates = _SurveyTemplateRepository.GetTemplatesByFilters(filter, pageNumber, pageSize, out  totalRecords);
            if (templates.IsNullOrEmpty()) return list;

            var healthPlans = _corporateAccountRepository.GetBySurveyTemplateIds(templates.Select(x => x.Id));

            foreach (var SurveyTemplate in templates)
            {
                var healthPlanName = "N/A";
                var SurveyhealthPlans = healthPlans.Where(x => x.SurveyTemplateId == SurveyTemplate.Id);
                if (!SurveyhealthPlans.IsNullOrEmpty())
                    healthPlanName = string.Join(", ", SurveyhealthPlans.Select(x => x.Name));

                list.Add(new SurveyTemplateViewModel
                {
                    Name = SurveyTemplate.Name,
                    HealthPlan = healthPlanName,
                    Id = SurveyTemplate.Id,
                    IsActive = SurveyTemplate.IsActive,
                    IsPublished = SurveyTemplate.IsPublished,

                });
            }
            return list;
        }

        public SurveyFormEditModel GetCustomerSurveyFormEditModel(Customer customer, CorporateAccount account, EventCustomer eventCustomer)
        {
            var template = _SurveyTemplateRepository.GetTemplateByEventId(eventCustomer.EventId);
            if (template == null && account.SurveyTemplateId.HasValue)
                template = _SurveyTemplateRepository.GetById(account.SurveyTemplateId.Value);
            else if (template == null)
                template = _SurveyTemplateRepository.GetDefaultTemplate();

            if (template == null)
                return new SurveyFormEditModel { SurveyQuestion = new List<SurveyQuestionAnswerEditModel>() };

            var surveyQuestion = _SurveyQuestionRepository.GetAllQuestionsForTemplateId(template.Id);

            var answerList = _surveyAnswerRepository.GetSurveyAnswerByEventCustomerId(eventCustomer.Id).ToList();

            return new SurveyFormEditModel
            {
                CustomerId = customer.CustomerId,
                EventId = eventCustomer.EventId,
                Name = customer.Name,
                DoB = customer.DateOfBirth,
                EventCustomerId = eventCustomer.Id,
                SurveyQuestion = _SurveyQuestionAnswerEditModelFactory.SurveyQuestionAnswerEditModel(surveyQuestion, answerList),
                IsEditable = false,
                Gender = customer.Gender
            };
        }
    }
}
