using Falcon.App.Core.Sales.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales
{
    public interface ICustomTagService
    {
        IEnumerable<CustomTagViewModel> GetCustomTagFilterList(CustomTagListModelFilter customeTagListModelFilter, int pageNumber, int pageSize, out int totalRecords);
        bool DeleteCorporateTag(long corporateTagId, long orgId);
        bool DisabledCorporateTag(long corporateTagId, bool disabled, long orgId);
        CustomTagEditViewModel GetCustomTag(long tagId);
        void SaveCustomeTag(CustomTagEditViewModel model, long orgId);
        void UpdateCustomeTag(CustomTagEditViewModel model);
    }
}
