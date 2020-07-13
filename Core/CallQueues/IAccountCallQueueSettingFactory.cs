using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface IAccountCallQueueSettingFactory
    {
        IEnumerable<AccountCallQueueSettingEditModel> CreateModel(IEnumerable<AccountCallQueueSetting> accountCallQueueSettings, IEnumerable<CallQueue> callQueues);
        IEnumerable<AccountCallQueueSetting> CreateDomain(IEnumerable<AccountCallQueueSettingEditModel> modelList, long accountId);
    }
}
