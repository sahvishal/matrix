using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class ActivityTypeRepository : PersistenceRepository, IActivityTypeRepository
    {
        public ActivityType Save(ActivityType domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ActivityType, ActivityTypeEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Activity Type");
                return Mapper.Map<ActivityTypeEntity, ActivityType>(entity);
            }
        }

        public ActivityType GetByAlias(string alias)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from q in linqMetaData.ActivityType
                              where q.Alias.ToLower() == alias.ToLower() && q.IsActive
                              select q).FirstOrDefault();

                if (entity == null) return null;

                return Mapper.Map<ActivityTypeEntity, ActivityType>(entity);
            }
        }

        public IEnumerable<ActivityType> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.ActivityType
                                where q.IsActive
                                orderby q.Name
                                select q).ToArray();

                return Mapper.Map<IEnumerable<ActivityTypeEntity>, IEnumerable<ActivityType>>(entities);
            }
        }

        public ActivityType GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from q in linqMetaData.ActivityType
                              where q.Id == id
                              select q).FirstOrDefault();

                if (entity == null) return null;

                return Mapper.Map<ActivityTypeEntity, ActivityType>(entity);
            }
        }

        public IEnumerable<ActivityType> GetByIds(long[] ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from q in linqMetaData.ActivityType
                                where ids.Contains(q.Id)
                                orderby q.Name
                                select q).ToArray();

                return Mapper.Map<IEnumerable<ActivityTypeEntity>, IEnumerable<ActivityType>>(entities);
            }
        }
    }
}
