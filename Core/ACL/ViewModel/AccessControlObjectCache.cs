using System.Collections.Generic;

namespace Falcon.App.Core.ACL.ViewModel
{
    public class AccessControlObjectCache
    {
        public long RoleId { get; set; }

        public IEnumerable<AccessControlObjectCacheItem> AccessControlObjects { get; set; }
    }
}