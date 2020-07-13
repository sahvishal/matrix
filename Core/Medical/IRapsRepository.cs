using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IRapsRepository
    {
        Raps SaveRaps(Raps domainObject);
        IEnumerable<Raps> GetByCustomerId(long customerId);
        IEnumerable<Raps> GetRapsForSync(int skipCount);
    }
}
