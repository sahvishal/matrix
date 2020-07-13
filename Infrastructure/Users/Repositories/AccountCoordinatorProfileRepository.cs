using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Factories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class AccountCoordinatorProfileRepository : PersistenceRepository, IRepository<AccountCoordinatorProfile>, IAccountCoordinatorProfileRepository
    {
        private readonly IAccountCoordinatorProfileFactory _accountCoordinatorProfileFactory;
        private readonly IUserRepository<AccountCoordinatorProfile> _userRepository;
        public AccountCoordinatorProfileRepository()
            : this(new SqlPersistenceLayer(), new AccountCoordinatorProfileFactory(), new UserRepository<AccountCoordinatorProfile>())
        {

        }
        public AccountCoordinatorProfileRepository(IPersistenceLayer persistenceLayer, IAccountCoordinatorProfileFactory accountCoordinatorProfileFactory, IUserRepository<AccountCoordinatorProfile> userRepository)
            : base(persistenceLayer)
        {
            _accountCoordinatorProfileFactory = accountCoordinatorProfileFactory;
            _userRepository = userRepository;
        }

        public AccountCoordinatorProfile Save(AccountCoordinatorProfile domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _accountCoordinatorProfileFactory.CreateAccountCoordinatorProfileEntity(domainObject);

                entity.IsNew = !adapter.FetchEntity(new AccountCoordinatorProfileEntity(domainObject.AccountCoordinatorId));

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return _accountCoordinatorProfileFactory.CreateAccountCoordinatorProfile(domainObject, entity);
            }
        }

        public void Delete(AccountCoordinatorProfile domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<AccountCoordinatorProfile> domainObjects)
        {
            throw new NotImplementedException();
        }

        public AccountCoordinatorProfile GetAccountCoordinatorProfile(long accountCoordinatorId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var accountCoordinatorProfileEntity =
                    linqMetaData.AccountCoordinatorProfile.WithPath(
                        prefetchPath =>
                        prefetchPath.Prefetch(tp => tp.OrganizationRoleUser)).
                        Where(tp => tp.OrganizationRoleUserId == accountCoordinatorId).FirstOrDefault();

                if (accountCoordinatorProfileEntity == null)
                    return null;

                AccountCoordinatorProfile user = _userRepository.GetUser(accountCoordinatorProfileEntity.OrganizationRoleUser.UserId);

                return _accountCoordinatorProfileFactory.CreateAccountCoordinatorProfile(user, accountCoordinatorProfileEntity);
            }
        }


        public IEnumerable<long> GetCriticalCoordinator(IEnumerable<long> organizationRoleUserIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organizationRoleUserId = (from acp in linqMetaData.AccountCoordinatorProfile
                                         where organizationRoleUserIds.Contains(acp.OrganizationRoleUserId) && acp.IsClinicalCoordinator
                                         select acp.OrganizationRoleUserId).ToArray();
                return organizationRoleUserId;
            }
        }
    }
}
