using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Marketing
{
    public interface ISourceCodeService
    {
        SourceCodeListModel Get(SourceCodeListModelFilter filter, int pageNumber, int pageSize, out long totalRecords);
        SourceCodeEditModel Get(long id = 0);
        SourceCodeEditModel Get(SourceCodeEditModel model);
    }
}