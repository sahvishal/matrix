using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IFluConsentService
    {
        FluConsentTemplateListModel GetFluConsentTemplateList(FluConsentTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        FluConsentTemplateEditModel GetTemplateById(long templateId);

        void Save(FluConsentTemplateEditModel model, long orgRoleUserId);

        bool SaveAnswers(FluVaccineConsentModel model, long orgRoleUserId);
        FluVaccineConsentModel GetFluConsent(long eventCustomerId);
    }
}
