using System.Data;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IRapsUploadHelper
    {
        string CheckForColumns(DataRow row);
        RapsUploadLog GetUploadLog(DataRow row, long rapsUploadId);

    }
}
