using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IResultArchiveUploadLogRepository : IRepository<ResultArchiveLog>
    {
        ResultArchiveLog Get(long id);
        IEnumerable<ResultArchiveLog> GetbyResultArchiveId(long resultArchiveId);
        IEnumerable<ResultArchiveLog> GetbyEventId(long eventId);
        IEnumerable<ResultArchiveLog> GetbyEventIdCustomerId(long eventId, long customerId);
    }
}