using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICriteriaRepository
    {
        IEnumerable<Criteria> GetAll();
    }
}
