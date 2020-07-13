using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PreQualifiedQuestionTemplateFactory : IPreQualifiedQuestionTemplateFactory
    {
        public PreQualifiedQuestionTemplateEditModel CreateEditModel(PreQualificationTestTemplate preQualificationTestTemplate, IEnumerable<PreQualificationQuestion> questions, IEnumerable<long> selectedQuestionIds,
            IEnumerable<long> dependentTestIds)
        {
            return new PreQualifiedQuestionTemplateEditModel()
            {
                Id = preQualificationTestTemplate.Id,
                IsActive = preQualificationTestTemplate.IsActive,
                IsPublished = preQualificationTestTemplate.IsPublished,
                Name = preQualificationTestTemplate.TemplateName,
                TestId = preQualificationTestTemplate.TestId,
                Questions = questions.Select(x => new PreQualifiedQuestionEditModel()
                {
                    Id = x.Id,
                    Question = x.Question,
                    IsSelected = !selectedQuestionIds.IsNullOrEmpty() && selectedQuestionIds.Contains(x.Id)
                }).ToArray(),
                DependentTestIds = dependentTestIds
            };
        }

        public PreQualificationTestTemplate GetPreQualifiedQuestionTemplateDomain(PreQualifiedQuestionTemplateEditModel model)
        {
            return new PreQualificationTestTemplate
            {
                Id = model.Id,
                TemplateName = model.Name,
                TestId = model.TestId,
                IsActive = true,
                IsPublished = model.IsPublished,
            };
        }

        public IEnumerable<PreQualificationQuestionViewModel> GetPreQualificationQuestionListModel(IEnumerable<PreQualificationTestTemplate> preQualificationTestTemplates,IEnumerable<Test> tests, IEnumerable<PreQualificationQuestion> questions, IEnumerable<OrderedPair<long, long>> templateIdQuestionIdPair, IEnumerable<PreQualificationQuestionRule> dependencyRule)
        {
            var listModel = new List<PreQualificationQuestionViewModel>();

            foreach (var testTemplate in preQualificationTestTemplates)
            {
                var templateQuestionIds = templateIdQuestionIdPair.Where(x => x.FirstValue == testTemplate.Id).Select(x => x.SecondValue);
                var templateQuestions = questions.Where(x => templateQuestionIds.Contains(x.Id));
                var test = tests.First(t => t.Id == testTemplate.TestId);

                var model = new PreQualificationQuestionViewModel
                {
                    TestId = test.Id,
                    TestName = test.Name,
                    TemplateId = testTemplate.Id,
                    QuestionRule = dependencyRule.ToList(),
                    Questions = templateQuestions.Select(x => new PreQualificationQuestion()
                    {
                        Id = x.Id,
                        Question = x.Question,
                        ControlValueDelimiter = x.ControlValueDelimiter,
                        ControlValues = x.ControlValues,
                        Index = x.Index,
                        ParentId = x.ParentId,
                        TypeId = x.TypeId,

                    }).ToList()
                };

                listModel.Add(model);
            }
            return listModel;
        }

    }
}
