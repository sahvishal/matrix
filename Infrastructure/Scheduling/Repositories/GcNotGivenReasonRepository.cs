using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class GcNotGivenReasonRepository : PersistenceRepository, IGcNotGivenReasonRepository
    {
        public IEnumerable<OrderedPair<long, string>> GetReasonForDropDown()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var data = (from gcngr in linqMetaData.GcNotGivenReason where gcngr.IsActive select new OrderedPair<long, string>(gcngr.Id, gcngr.Name)).ToArray();
                return data;
            }
        }
    }
}
