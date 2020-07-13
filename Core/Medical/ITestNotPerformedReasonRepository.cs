using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITestNotPerformedReasonRepository
    {
        IEnumerable<TestNotPerformedReason> GetAll();
    }
}
