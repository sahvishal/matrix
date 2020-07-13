
using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface ICorporateTagRepository
    {
        CorporateTag GetById(long id);
        CorporateTag Save(CorporateTag corporateTag);
        IEnumerable<CorporateTag> GetByCorporateId(long id, bool includeDisabled = true);
        IEnumerable<CorporateTag> GetAll();
        IEnumerable<CorporateTag> GetByCorporateAcccountIds(IEnumerable<long> corpoateAccountId);
        IEnumerable<CorporateTag> GetCorporateTagByFilter(CustomTagListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        bool DeleteCustomTags(string customTag, long orgId, bool isActive);
        bool DisableCustomTag(long corporateTagId, bool isdisabled, long orgId);
        IEnumerable<CorporateTag> GetAllForHealthPlans();
        bool Update(CorporateTag corporateTag);
        bool CustomTagIsUnique(string tagName);
        void DisableCustomTagAfterExpiryDate();
        CorporateTag GetByTag(string corporateTag);
        IEnumerable<CorporateTag> CorporateTagForHealthplanResticted(long agentOrganizationId);

        IEnumerable<CorporateTag> GetByCustomTags(IEnumerable<string> corporateTag);
    }
}
