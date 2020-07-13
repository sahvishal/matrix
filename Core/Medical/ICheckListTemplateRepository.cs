using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICheckListTemplateRepository
    {
        CheckListTemplate GetById(long id);
        IEnumerable<CheckListTemplate> GetAllTemplates();
        CheckListTemplate GetDefaultTemplate();

        IEnumerable<CheckListTemplate> GetTemplatesByFilters(CheckListTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        CheckListTemplate GetByName(string name);
        CheckListTemplate Save(CheckListTemplate checkListTemplate, IEnumerable<CheckListGroupQuestionEditModel> questions);
        IEnumerable<long> GetQuestionIdsByTemplateId(long templateId);
        CheckListTemplate GetTemplateByHealthPlanId(long healthPlanId);
        IEnumerable<long> GetGroupQuestionIdsByTemplateId(long templateId);
        IEnumerable<ChecklistGroupQuestion> GetAllGroupQuestions();
        IEnumerable<ChecklistGroupQuestion> GetAllGroupQuestionsForTemplateId(long templateId);
        CheckListTemplate GetTemplateByEventId(long eventId);
    }
}