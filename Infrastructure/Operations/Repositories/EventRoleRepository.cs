using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class EventRoleRepository : UniqueItemRepository<StaffEventRole, StaffEventRoleEntity>, IEventRoleRepository
    {
        public EventRoleRepository(IMapper<StaffEventRole, StaffEventRoleEntity> mapper)
            : base(mapper)
        {
        }


        protected override EntityField2 EntityIdField
        {
            get { return StaffEventRoleFields.StaffEventRoleId; }
        }

        public new StaffEventRole Save(StaffEventRole staffEventRole)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket();
                bucket.PredicateExpression.Add(StaffEventRoleTestFields.StaffEventRoleId == staffEventRole.Id);

                if (staffEventRole.Id > 0)
                {
                    adapter.DeleteEntitiesDirectly(typeof(StaffEventRoleTestEntity), bucket);
                }
            }
            return base.Save(staffEventRole);
        }

        public new StaffEventRole GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity =
                    linqMetaData.StaffEventRole.WithPath(
                        prefetchPath => prefetchPath.Prefetch(ser => ser.StaffEventRoleTest)).Where(
                            ser => ser.StaffEventRoleId == id).SingleOrDefault();

                if (entity == null) throw new ObjectNotFoundInPersistenceException<StaffEventRole>(id);

                return Mapper.Map(entity);
            }
        }

        public new IEnumerable<StaffEventRole> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.StaffEventRole.WithPath(prefetchPath => prefetchPath.Prefetch(ser => ser.StaffEventRoleTest))
                                            .Where(ser => ids.Contains(ser.StaffEventRoleId)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }
        public IEnumerable<StaffEventRole> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<StaffEventRoleEntity>();
                var path = new PrefetchPath2(EntityType.StaffEventRoleEntity);
                path.Add(StaffEventRoleEntity.PrefetchPathStaffEventRoleTest);

                adapter.FetchEntityCollection(collection, null, path);
                return Mapper.MapMultiple(collection);
            }
        }

        public IEnumerable<StaffEventRole> GetByName(string roleName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    linqMetaData.StaffEventRole.WithPath(
                        prefetchPath => prefetchPath.Prefetch(ser => ser.StaffEventRoleTest))
                        .Where(ser => ser.Name == roleName).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<StaffEventRole> GetAllActiveRoles()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    linqMetaData.StaffEventRole.WithPath(
                        prefetchPath => prefetchPath.Prefetch(ser => ser.StaffEventRoleTest))
                        .Where(ser => ser.IsActive == true).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }


    }
}