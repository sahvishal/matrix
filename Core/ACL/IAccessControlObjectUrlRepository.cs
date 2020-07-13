using System.Collections.Generic;

namespace Falcon.App.Core.ACL
{
    public interface IAccessControlObjectUrlRepository
    {
        IEnumerable<string> GetAllUrl();
        long GetAllUrlCount();
    }
}
