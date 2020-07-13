using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IRapsUploadLogRepository
    {
        RapsUploadLog GetById(long id);
        IEnumerable<RapsUploadLog> GetByRapsUploadId(long rapsUploadId);
        RapsUploadLog SaveRapsUploadLog(RapsUploadLog domainObject);
    }
}
