using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface IContentRepository
    {
        Content Save(Content resultContent);
        Content Get(long id);
        void Activate(long id, long orgRoleUserId);
        void Deactivate(long id, long orgRoleUserId);
        IEnumerable<Content> Get(ContentListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}