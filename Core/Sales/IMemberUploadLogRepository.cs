using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface IMemberUploadLogRepository
    {
        IEnumerable<MemberUploadLog> GetByCorporateUploadLogId(long corporateUploadId);
        void Save(MemberUploadLog domain);
    }
}