using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface INdcRepository
    {
        IEnumerable<Ndc> GetByName(IEnumerable<string> names);
        IEnumerable<Ndc> GetByIds(IEnumerable<long> ids);
        IEnumerable<Ndc> GetByNdcCode(IEnumerable<string> names);
        IEnumerable<OrderedPair<long, string>> GetBySearchText(string serachText);
    }
}
