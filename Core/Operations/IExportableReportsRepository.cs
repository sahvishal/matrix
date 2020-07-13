
using Falcon.App.Core.Operations.Domain;
namespace Falcon.App.Core.Operations
{
    public interface IExportableReportsRepository
    {
        ExportableReports GetById(long id);
    }
}
