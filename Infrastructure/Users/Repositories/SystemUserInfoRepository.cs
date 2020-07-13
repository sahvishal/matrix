using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class SystemUserInfoRepository : PersistenceRepository, ISystemUserInfoRepository
    {
        public SystemUserInfo Get(long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from sui in linqMetaData.SystemUserInfo
                              where sui.UserId == userId
                              select sui).SingleOrDefault();

                return entity == null ? null : Mapper.Map<SystemUserInfoEntity, SystemUserInfo>(entity);
            }
        }

        public bool IsEmployeeExist(long userId, string employeeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.SystemUserInfo.Any(x => x.EmployeeId == employeeId && x.UserId != userId);
            }
        }

        public void Save(SystemUserInfo systemUserInfo)
        {
            Delete(systemUserInfo.UserId);
            if (!string.IsNullOrEmpty(systemUserInfo.EmployeeId))
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    var entity = Mapper.Map<SystemUserInfo, SystemUserInfoEntity>(systemUserInfo);
                    if (!adapter.SaveEntity(entity, false))
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }

        private void Delete(long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(SystemUserInfoFields.UserId == userId);
                adapter.DeleteEntitiesDirectly(typeof(SystemUserInfoEntity), relationPredicateBucket);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetIdEmployeeIdPairofUsers(long[] orgRoleUserIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from u in linqMetaData.SystemUserInfo
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                        select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.EmployeeId)).OrderBy(o => o.SecondValue).ToArray();
            }
        }
    }
}
