using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface ICorporateTagService
    {
        CorporateTag Save(CorporateTag corporateTag);
        CorporateTagViewModel GetTagViewModel(long accountId);
        void Save(List<string> tags, long corporateId, long orgId);
        IEnumerable<string> DisabledTagsInUsed(IEnumerable<string> tags, long corporateId);
    }
}
