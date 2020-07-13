using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class CallCenterRepProfileRepository : PersistenceRepository, ICallCenterRepProfileRepository
    {
        public CallCenterRepProfile Get(long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ccrp in linqMetaData.CallCenterRepProfile
                              where ccrp.CallCenterRepId == orgRoleUserId
                              select ccrp).SingleOrDefault();

                return entity == null ? null : Mapper.Map<CallCenterRepProfileEntity, CallCenterRepProfile>(entity);
            }
        }

        public void Save(CallCenterRepProfile callCenterRepProfile)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallCenterRepProfile, CallCenterRepProfileEntity>(callCenterRepProfile);
                entity.IsNew = !adapter.FetchEntity(new CallCenterRepProfileEntity(callCenterRepProfile.CallCenterRepId));

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
        }
    }
}
