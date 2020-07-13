using System.Collections.Generic;
using AutoMapper;
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
    public class UserNpiInfoRepository : PersistenceRepository, IUserNpiInfoRepository
    {
        public UserNpiInfo Get(long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from uni in linqMetaData.UserNpiInfo
                              where uni.UserId == userId
                              select uni).SingleOrDefault();

                return entity == null ? null : Mapper.Map<UserNpiInfoEntity, UserNpiInfo>(entity);
            }
        }

        /// <summary>
        /// Empty NPI Values are discarded from Save
        /// </summary>
        /// <param name="userNpiInfo"></param>
        public void Save(UserNpiInfo userNpiInfo)
        {
            Delete(userNpiInfo.UserId);
            if (!(string.IsNullOrEmpty(userNpiInfo.Credential) && string.IsNullOrEmpty(userNpiInfo.Npi)))
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    var entity = Mapper.Map<UserNpiInfo, UserNpiInfoEntity>(userNpiInfo);
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
                var relationPredicateBucket = new RelationPredicateBucket(UserNpiInfoFields.UserId == userId);
                adapter.DeleteEntitiesDirectly(typeof(UserNpiInfoEntity), relationPredicateBucket);
            }
        }

        public bool IsNpiExist(string npi, long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.UserNpiInfo.Any(x => x.Npi == npi && x.UserId != userId);
            }
        }

        public bool IsCredentialExist(string credential, long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.UserNpiInfo.Any(x => x.Credential == credential && x.UserId != userId);
            }
        }

        public IEnumerable<UserNpiInfo> GetByUserIds(IEnumerable<long> userIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from uni in linqMetaData.UserNpiInfo where userIds.Contains(uni.UserId) select uni).ToArray();
                return Mapper.Map<IEnumerable<UserNpiInfoEntity>, IEnumerable<UserNpiInfo>>(entities);
            }
        }
    }
}
