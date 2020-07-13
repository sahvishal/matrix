
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IExportableReportsQueueRepository
    {
        ExportableReportsQueue GetById(long id);
        ExportableReportsQueue Save(ExportableReportsQueue domainObject);

        ExportableReportsQueue GetExportableReportsQueueForService();
        IEnumerable<ExportableReportsQueue> GetExportableReportsQueuesForDelete(int noOfDays);
        void Delete(long id);
        IEnumerable<ExportableReportsQueue> GetExportableReportsQueue(int pageNumber, int pageSize, ExportableReportsQueueFilter filter, out int totalRecords);
    }
}
