using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales
{
    public interface ICorporateUploadRepository
    {
        CorporateUpload GetById(long corporateUploadId);
        CorporateUpload Save(CorporateUpload domain);
        bool IsFileUpladedBetweenDateTime(DateTime startDateTime, DateTime endDateTime);
        IEnumerable<CorporateUpload> GetByFilter(int pageNumber, int pageSize, MemberUploadDetailsListModelFilter filter, out int totalRecords);
        IEnumerable<CorporateUpload> GetByParseStatus(int parseStatus);
    }
}