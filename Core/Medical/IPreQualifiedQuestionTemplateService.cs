using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IPreQualifiedQuestionTemplateService
    {
        PreQualifiedQuestionTemplateEditModel SaveTemplate(PreQualifiedQuestionTemplateEditModel model, long orgRoleUserId);
        PreQualifiedQuestionTemplateEditModel GetbyId(long id);
        PreQualifiedQuestionTemplateListModel GetPreQualifiedQuestionTemplateListModel(PreQualifiedQuestionTemplateModelFilter filter, int pageSize, out int totalRecords, int pageNumber = 1);
        IEnumerable<PreQualificationQuestionViewModel> GetPreQualificationQuestionsbyTemplateIds(IEnumerable<long> templateIds);
    }
}
