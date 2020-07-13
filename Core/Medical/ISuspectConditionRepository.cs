using Falcon.App.Core.Medical.Domain;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISuspectConditionRepository
    {
        SuspectCondition SaveSuspectCondition(SuspectCondition domainObject);
        IEnumerable<SuspectCondition> GetByCustomerId(long customerId);
        IEnumerable<SuspectCondition> GetSuspectConditionForSync(int recordsToSkip);
        bool IsCustoemrExistForIcdCodeAndDate(IEnumerable<long> customerId, string icdCode, DateTime CaptureReferenceDate);
    }
}
