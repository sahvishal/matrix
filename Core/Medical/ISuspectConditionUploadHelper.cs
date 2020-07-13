using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.ValueTypes;
using System.Collections.Generic;
using System.Data;

namespace Falcon.App.Core.Medical
{
    public interface ISuspectConditionUploadHelper
    {
        string CheckForColumns(string[] columnList);
        SuspectConditionUploadLog GetUploadLog(DataRow row, long suspectConditionUploadId);
        void CreateHeaderFileRecord(string filePath, DataTable dataTable);
        void UpdateFailedRecords(string filePath, IEnumerable<SuspectConditionUploadLogViewModel> failedRecordsList);
        long FailedCustomerCount(string failedRecordsFilePath, MediaLocation mediaLocation);
        string CheckIsFileContainsRecord(MediaLocation mediaLocation, string filePath);
    }
}
