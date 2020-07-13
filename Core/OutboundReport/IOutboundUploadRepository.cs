using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IOutboundUploadRepository
    {
        OutboundUpload GetById(long id);
        IEnumerable<OutboundUpload> GetAllUploadedFilesByType(long typeId);
        OutboundUpload Save(OutboundUpload domain);
    }
}
