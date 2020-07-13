using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Core.Application
{
    public interface ILookupRepository
    {
        IEnumerable<Lookup> GetByLookupId(long lookupId);
    }
}
