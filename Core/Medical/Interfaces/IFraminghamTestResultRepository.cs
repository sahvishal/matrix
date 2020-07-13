using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IFraminghamTestResultRepository
    {
        List<FraminghamRiskTestResult> GetTestResults(long customerId);
        bool UpdateFraminghamValue(long customerEventScreeningTestId, decimal framinghamValue);
    }
}
