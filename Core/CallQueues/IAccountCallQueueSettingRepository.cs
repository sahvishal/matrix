using Falcon.App.Core.CallQueues.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface IAccountCallQueueSettingRepository
    {
        IEnumerable<AccountCallQueueSetting> GetByAccountId(long accountId);
        IEnumerable<AccountCallQueueSetting> GetByAccountIdAndCallQueueId(long accountId, long callQueueId);
        void Save(IEnumerable<AccountCallQueueSetting> accountCallQueueSettings, long accountId, bool isHealthPlan);
    }
}
