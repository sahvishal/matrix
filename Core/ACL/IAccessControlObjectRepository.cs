using System.Collections.Generic;
using Falcon.App.Core.ACL.Domain;

namespace Falcon.App.Core.ACL
{
    public interface IAccessControlObjectRepository
    {
        IEnumerable<AccessControlObject> GetRootAccessControlObjects();
        AccessControlObject GetAccessControlObjectById(long accessControlObjectId);
        IEnumerable<AccessControlObject> GetAllowedAccessControlObjectsByRoleId(long roleId);
        AccessControlObject GetChildAccessControlObjects(AccessControlObject accessControlObject);
    }
}
