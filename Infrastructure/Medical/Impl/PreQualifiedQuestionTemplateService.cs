using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PreQualifiedQuestionTemplateService : IPreQualifiedQuestionTemplateService
    {
        private readonly IPreQualificationTestTemplateRepository _preQualificationTestTemplateRepository;
        private readonly IPreQualificationQuestionRepository _preQualificationQuestionRepository;
        private readonly IPreQualifiedQuestionTemplateFactory _preQualifiedQuestionTemplateFactory;
        private readonly ITestRepository _testRepository;

        private readonly IPreQualificationTemplateDependentTestRepository _preQualificationTemplateDependentTestRepository;
        private readonly IPreQualificationQuestionRuleRepository _preQualificationQuestionRuleRepository;

        public PreQualifiedQuestionTemplateService(IPreQualificationTestTemplateRepository preQualificationTestTemplateRepository, IPreQualificationQuestionRepository preQualificationQuestionRepository,
            IPreQualifiedQuestionTemplateFactory preQualifiedQuestionTemplateFactory, ITestRepository testRepository,
            IPreQualificationTemplateDependentTestRepository preQualificationTemplateDependentTestRepository,
            IPreQualificationQuestionRuleRepository preQualificationQuestionRuleRepository)
        {
            _preQualificationTestTemplateRepository = preQualificationTestTemplateRepository;
            _preQualificationQuestionRepository = preQualificationQuestionRepository;
            _preQualifiedQuestionTemplateFactory = preQualifiedQuestionTemplateFactory;
            _testRepository = testRepository;

            _preQualificationTemplateDependentTestRepository = preQualificationTemplateDependentTestRepository;
            _preQualificationQuestionRuleRepository = preQualificationQuestionRuleRepository;
        }

        public PreQualifiedQuestionTemplateEditModel SaveTemplate(PreQualifiedQuestionTemplateEditModel model, long orgRoleUserId)
        {
            PreQualificationTestTemplate dbTemplate = null;

            var template = _preQualifiedQuestionTemplateFactory.GetPreQualifiedQuestionTemplateDomain(model);

            if (template.Id > 0)
            {
                dbTemplate = _preQualificationTestTemplateRepository.GetById(template.Id);
                template.CreatedBy = dbTemplate.CreatedBy;
                template.CreatedDate = dbTemplate.CreatedDate;
                template.UpdatedDate = DateTime.Now;
                template.UpdatedBy = orgRoleUserId;
            }
            else
            {
                template.CreatedBy = orgRoleUserId;
                template.CreatedDate = DateTime.Now;
            }

            template = _preQualificationTestTemplateRepository.Save(template, model.Questions.Where(x => x.IsSelected));
            model.Id = template.Id;

            if (!model.DependentTestIds.IsNullOrEmpty())
            {
                var dependentTests = model.DependentTestIds.Select(x => new PreQualificationTemplateDependentTest
                {
                    TemplateId = template.Id,
                    TestId = x,
                    IsActive = true
                });

                _preQualificationTemplateDependentTestRepository.SaveCollection(dependentTests);
            }

            return model;
        }

        public PreQualifiedQuestionTemplateEditModel GetbyId(long id)
        {
            var template = _preQualificationTestTemplateRepository.GetById(id);
            if (template == null) return new PreQualifiedQuestionTemplateEditModel { Questions = new PreQualifiedQuestionEditModel[] { } };

            var question = _preQualificationQuestionRepository.GetByTestId(template.TestId);
            var selectedQuestionIds = _preQualificationTestTemplateRepository.GetQuestionIdsByTemplateId(id);
            var dependentTestIds = _preQualificationTemplateDependentTestRepository.GetByTemplateId(id).Select(x => x.TestId);

            return _preQualifiedQuestionTemplateFactory.CreateEditModel(template, question, selectedQuestionIds, dependentTestIds);
        }

        public PreQualifiedQuestionTemplateListModel GetPreQualifiedQuestionTemplateListModel(PreQualifiedQuestionTemplateModelFilter filter, int pageSize, out int totalRecords, int pageNumber = 1)
        {
            var templates = _preQualificationTestTemplateRepository.GetByFilters(filter, pageNumber, pageSize, out  totalRecords);
            var dependentTests = _preQualificationTemplateDependentTestRepository.GetByTemplateIds(templates.Select(x => x.Id).ToArray());
            var testIds = templates.Select(x => x.TestId).Concat(dependentTests.Select(x => x.TestId));
            var tests = _testRepository.GetTestByIds(testIds);
            var list = new List<PreQualifiedQuestionTemplateViewModel>();

            foreach (var template in templates)
            {
                var testName = "N/A";
                var test = tests.FirstOrDefault(x => x.Id == template.TestId);
                if (test != null)
                    testName = test.Name;

                var templateDependentTestIds = dependentTests.Where(x => x.TemplateId == template.Id).Select(x => x.TestId);
                var templateDependentTests = tests.Where(x => templateDependentTestIds.Contains(x.Id)).Select(x => x.Name).ToArray();

                list.Add(new PreQualifiedQuestionTemplateViewModel
                {
                    Name = template.TemplateName,
                    TestName = testName,
                    Id = template.Id,
                    IsActive = template.IsActive,
                    IsPublished = template.IsPublished,
                    DependentTests = !templateDependentTests.IsNullOrEmpty() ? string.Join(", ", templateDependentTests) : string.Empty
                });
            }
            return new PreQualifiedQuestionTemplateListModel
            {
                Filter = filter,
                Templates = list
            };
        }

        public IEnumerable<PreQualificationQuestionViewModel> GetPreQualificationQuestionsbyTemplateIds(IEnumerable<long> templateIds)
        {
            if (!templateIds.Any())
                return new List<PreQualificationQuestionViewModel>();

            var preQualificationTestTemplates = _preQualificationTestTemplateRepository.GetByTemplateIds(templateIds);
            if (preQualificationTestTemplates.IsNullOrEmpty()) return null;

            var testIds = preQualificationTestTemplates.Select(x => x.TestId);
            var tests = _testRepository.GetTestByIds(testIds);

            var questions = _preQualificationQuestionRepository.GetQuestionsByTemplateIds(templateIds.ToArray());
            var questionIds = questions.IsNullOrEmpty() ? null : questions.Select(x => x.Id).ToArray();
            var dependencyRule = _preQualificationQuestionRuleRepository.Get().Where(x => questionIds.Contains(x.QuestionId));
            var templateIdQuestionIdPair = _preQualificationTestTemplateRepository.GetTemplateIdQuestionIdPairByTemplateIds(templateIds.ToArray());
            return _preQualifiedQuestionTemplateFactory.GetPreQualificationQuestionListModel(preQualificationTestTemplates,tests, questions, templateIdQuestionIdPair, dependencyRule);
        }




    }
}
