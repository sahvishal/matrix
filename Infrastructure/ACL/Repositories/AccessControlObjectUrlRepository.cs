using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.ACL;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.ACL.Repositories
{
    [DefaultImplementation]
    public class AccessControlObjectUrlRepository : PersistenceRepository, IAccessControlObjectUrlRepository
    {
        public IEnumerable<string> GetAllUrl()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from u in linqMetaData.AccessControlObjectUrl 
                                select u.Url.ToLower());
                return  entities.ToList();
            }
        }

        public long GetAllUrlCount()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var count = (from u in linqMetaData.AccessControlObjectUrl
                                select u.Url).Count();
                return count;
            }
        } 
    }
}
