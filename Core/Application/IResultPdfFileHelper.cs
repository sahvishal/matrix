using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Application
{
    public interface IResultPdfFileHelper
    {
        string GetFileName(List<CustomerInfo> resultPdfPostedCustomers, EventCustomerResult ecr, string fileName, long fileType, bool appendDateTime = true);

        CustomerInfo GetCustomerInfo(Event eventData, string fileName, long fileType, Customer customer, long eventCustomerId);

        void CreateCsvForFileShared(IEnumerable<CustomerInfo> customersInfo, string folderPath, string fileName);

        ResultPdfPostedXml CorrectMissingRecords(ResultPdfPostedXml resultPdfPostedXml);
    }
}
