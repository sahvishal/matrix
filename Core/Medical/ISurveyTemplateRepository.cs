using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISurveyTemplateRepository
    {
        SurveyTemplate GetById(long id);
        IEnumerable<SurveyTemplate> GetAllTemplates();
        SurveyTemplate GetDefaultTemplate();
        IEnumerable<SurveyTemplate> GetTemplatesByFilters(SurveyTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        SurveyTemplate GetByName(string name);
        SurveyTemplate Save(SurveyTemplate SurveyTemplate, IEnumerable<SurveyQuestionEditModel> questions);
        IEnumerable<long> GetQuestionIdsByTemplateId(long templateId);
        SurveyTemplate GetTemplateByEventId(long eventId);
    }
}