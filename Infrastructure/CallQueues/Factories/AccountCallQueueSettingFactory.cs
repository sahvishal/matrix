using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class AccountCallQueueSettingFactory : IAccountCallQueueSettingFactory
    {
        public IEnumerable<AccountCallQueueSettingEditModel> CreateModel(IEnumerable<AccountCallQueueSetting> accountCallQueueSettings, IEnumerable<CallQueue> callQueues)
        {
            if (accountCallQueueSettings.IsNullOrEmpty()) return null;

            var list = accountCallQueueSettings.Select(x => CreateModel(x, callQueues.FirstOrDefault(c => c.Id == x.CallQueueId))).ToList();
            return list;
        }

        private AccountCallQueueSettingEditModel CreateModel(AccountCallQueueSetting accountCallQueueSetting, CallQueue callQueue)
        {
            return new AccountCallQueueSettingEditModel
            {
                AccountId = accountCallQueueSetting.AccountId,
                DateCreated = accountCallQueueSetting.DateCreated,
                IsActive = accountCallQueueSetting.IsActive,
                NoOfDays = accountCallQueueSetting.NoOfDays > 0 ? accountCallQueueSetting.NoOfDays : (int?)null,
                SuppressionTypeId = accountCallQueueSetting.SuppressionTypeId,
                SuppressionDescription = ((CallQueueSuppressionType)accountCallQueueSetting.SuppressionTypeId).GetDescription(),
                CallQueueId = accountCallQueueSetting.CallQueueId,
                CallQueueName = callQueue.Name,
            };
        }

        public IEnumerable<AccountCallQueueSetting> CreateDomain(IEnumerable<AccountCallQueueSettingEditModel> modelList, long accountId)
        {
            if (modelList.IsNullOrEmpty()) return null;

            var list = modelList.Select(model => new AccountCallQueueSetting
            {
                AccountId = accountId,
                CallQueueId = model.CallQueueId,
                NoOfDays = model.NoOfDays.HasValue ? model.NoOfDays.Value : 0,
                SuppressionTypeId = model.SuppressionTypeId,
                DateCreated = DateTime.Now,
                IsActive = true
            }).ToList();

            return list;
        }
    }
}
