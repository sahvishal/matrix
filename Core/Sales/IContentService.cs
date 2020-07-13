using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface IContentService
    {
        ContentEditModel GetModel(long id);
        ContentEditModel SaveModel(ContentEditModel model, long orgRoleUserId);
        ContentListModel GetListModel(ContentListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}