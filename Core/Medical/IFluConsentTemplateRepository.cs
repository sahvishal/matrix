using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IFluConsentTemplateRepository
    {
        IEnumerable<FluConsentTemplate> GetTemplates(FluConsentTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        FluConsentTemplate GetById(long id);

        IEnumerable<FluConsentTemplate> GetByIds(long[] ids);

        FluConsentTemplate Save(FluConsentTemplate domain);
    }
}
