using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IResultArchiveUploadRepository : IRepository<ResultArchive>
    {
        ResultArchive GetById(long id);
        IEnumerable<ResultArchive> GetByEventId(long eventId);
        IEnumerable<ResultArchive> Get(ResultArchiveUploadStatus status);
        IEnumerable<ResultArchive> GetByFilter(ResultArchiveUploadListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<long> GetEventIdsForStatus(IEnumerable<long> eventIds, ResultArchiveUploadStatus status);

        IEnumerable<ResultArchive> GetForEventArchiveStatsReport(EventArchiveStatsFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<ResultArchive> GetResultArchiveUploadingAfterHours(int markFailedAfterHours);
    }
}