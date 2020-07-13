using System.Collections.Generic;
using System.Data;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallUploadHelper
    {
        CallUploadLog GetUploadLog(DataRow row, long callUploadId);
        string CheckForColumns(DataRow row);

        long GetOrganizationRoleId(CallUploadLog callUploadLog,IEnumerable<OrderedPair<long, string>> organizationRoleUserEmail,IEnumerable<OrderedPair<long, string>> organizationRoleUserUserName);
    }
}