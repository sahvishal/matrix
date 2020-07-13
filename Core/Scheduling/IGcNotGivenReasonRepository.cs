using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface IGcNotGivenReasonRepository
    {
        IEnumerable<OrderedPair<long, string>> GetReasonForDropDown();
    }
}
