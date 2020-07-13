using System.Collections.Generic;
using Falcon.App.Core.ACL.Enum;

namespace Falcon.App.Core.ACL.ViewModel
{
    public class AccessControlObjectCacheItem
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        public IEnumerable<string> ResourceUrls { get; set; }

        public DataScope DataScope { get; set; }
    }


}