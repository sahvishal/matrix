using System.Data;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IMergeCustomerUploadHelper
    {
        string CheckForColumns(DataRow row);
        MergeCustomerUploadLog GetUploadLog(DataRow row, long uploadId);
    }
}
