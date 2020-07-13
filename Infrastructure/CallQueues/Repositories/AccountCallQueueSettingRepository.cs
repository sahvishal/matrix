using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class AccountCallQueueSettingRepository : PersistenceRepository, IAccountCallQueueSettingRepository
    {
        public IEnumerable<AccountCallQueueSetting> GetByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from acqs in linqMetaData.AccountCallQueueSetting
                                where acqs.AccountId == accountId
                                select acqs).ToArray();

                return Mapper.Map<IEnumerable<AccountCallQueueSettingEntity>, IEnumerable<AccountCallQueueSetting>>(entities);
            }
        }

        public IEnumerable<AccountCallQueueSetting> GetByAccountIdAndCallQueueId(long accountId, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from acqs in linqMetaData.AccountCallQueueSetting
                                where acqs.AccountId == accountId && acqs.CallQueueId == callQueueId
                                select acqs).ToArray();

                return Mapper.Map<IEnumerable<AccountCallQueueSettingEntity>, IEnumerable<AccountCallQueueSetting>>(entities);
            }
        }

        public void Save(IEnumerable<AccountCallQueueSetting> accountCallQueueSettings, long accountId, bool isHealthPlan)
        {
            DeleteByAccountId(accountId);
            if (isHealthPlan)
            {
                if (accountCallQueueSettings.IsNullOrEmpty()) return;

                foreach (var accountCallQueueSetting in accountCallQueueSettings)
                {
                    Save(accountCallQueueSetting);
                }
            }
        }

        private void DeleteByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(AccountCallQueueSettingEntity), new RelationPredicateBucket(AccountCallQueueSettingFields.AccountId == accountId));
            }
        }

        private void Save(AccountCallQueueSetting accountCallQueueSetting)
        {
            if (accountCallQueueSetting == null) return;

            var entity = Mapper.Map<AccountCallQueueSetting, AccountCallQueueSettingEntity>(accountCallQueueSetting);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
            }

        }
    }
}
