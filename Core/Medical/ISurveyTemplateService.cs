using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISurveyTemplateService
    {
        SurveyTemplateEditModel SaveTemplate(SurveyTemplateEditModel model, long organizationRoleUserId);
        SurveyTemplateEditModel GetbyId(long id);
        SurveyFormEditModel ViewTemplate(long templateId);
        List<SurveyTemplateViewModel> GetSurveyTemplateList(SurveyTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        SurveyFormEditModel GetCustomerSurveyFormEditModel(Customer customer, CorporateAccount account, EventCustomer eventCustomer);
    }
}
