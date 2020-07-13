using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class AccountAdditionalFieldRepository : PersistenceRepository, IAccountAdditionalFieldRepository
    {
        public IEnumerable<AccountAdditionalFields> GetByAccountId(long accountId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from aaf in linqMetaData.AccountAdditionalFields
                                where aaf.AccountId == accountId
                                select aaf).ToArray();

                return Mapper.Map<IEnumerable<AccountAdditionalFieldsEntity>, IEnumerable<AccountAdditionalFields>>(entities);
            }
        }

        public IEnumerable<AccountAdditionalFieldsEditModel> GetAccountAdditionalFieldsEditModelByAccountId(long accountId)
        {
            var domain = GetByAccountId(accountId);
            return Mapper.Map<IEnumerable<AccountAdditionalFields>, IEnumerable<AccountAdditionalFieldsEditModel>>(domain);
        }

        public IEnumerable<AccountAdditionalFields> GetAccountAdditionalFieldsByAccountIds(IEnumerable<long> accountIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from aaf in linqMetaData.AccountAdditionalFields
                                where accountIds.Contains(aaf.AccountId)
                                select aaf).ToArray();

                return Mapper.Map<IEnumerable<AccountAdditionalFieldsEntity>, IEnumerable<AccountAdditionalFields>>(entities);
            }
        }
    }
}
