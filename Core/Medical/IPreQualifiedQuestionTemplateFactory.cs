using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IPreQualifiedQuestionTemplateFactory
    {
        PreQualifiedQuestionTemplateEditModel CreateEditModel(PreQualificationTestTemplate preQualificationTestTemplate, IEnumerable<PreQualificationQuestion> questions, IEnumerable<long> selectedQuestionIds,
            IEnumerable<long> dependentTestIds);
        PreQualificationTestTemplate GetPreQualifiedQuestionTemplateDomain(PreQualifiedQuestionTemplateEditModel model);
        IEnumerable<PreQualificationQuestionViewModel> GetPreQualificationQuestionListModel(IEnumerable<PreQualificationTestTemplate> preQualificationTestTemplates, IEnumerable<Test> tests, IEnumerable<PreQualificationQuestion> questions, IEnumerable<OrderedPair<long, long>> templateIdQuestionIdPair, IEnumerable<PreQualificationQuestionRule> dependencyRule);
    }
}
