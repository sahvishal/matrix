using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.ACL;
using Falcon.App.Core.ACL.Domain;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.ACL.Repositories
{
    [DefaultImplementation]
    public class RoleAccessControlObjectRepository : PersistenceRepository, IRoleAccessControlObjectRepository
    {
        public IEnumerable<RoleAccessControlObject> GetRoleAccessControlObjectByRoleId(long roleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.RoleAccessControlObject.Where(r => r.RoleId == roleId).WithPath(path => path.Prefetch(p => p.AccessControlObject).Prefetch(p=>p.Role));

                return roleEntities.Select(Mapper.Map<RoleAccessControlObjectEntity, RoleAccessControlObject>).ToList();

            }
        }

        public bool IsExisting(RoleAccessControlObject roleAccessControlObject)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.RoleAccessControlObject.Any(r => r.RoleId == roleAccessControlObject.Role.Id 
                    && r.AccessControlObjectId == roleAccessControlObject.AccessControlObject.Id);
            }
        }

        public IEnumerable<RoleAccessControlObject> GetRoleAccessControlObjectByParentRoleId(long parentRoleId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var roleEntities = linqMetaData.RoleAccessControlObject.Where(r => r.Role.ParentId == parentRoleId).WithPath(path => path.Prefetch(p => p.AccessControlObject).Prefetch(p => p.Role));

                return roleEntities.Select(Mapper.Map<RoleAccessControlObjectEntity, RoleAccessControlObject>).ToList();

            }
        }

        public void DeleteRoleAccessControlObject(RoleAccessControlObject roleAccessControlObject)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(RoleAccessControlObjectFields.AccessControlObjectId == roleAccessControlObject.AccessControlObject.Id);
                relationPredicateBucket.PredicateExpression.AddWithAnd(RoleAccessControlObjectFields.RoleId == roleAccessControlObject.Role.Id);
                relationPredicateBucket.PredicateExpression.AddWithAnd(RoleAccessControlObjectFields.ScopeId == (long)roleAccessControlObject.DataScope);
                relationPredicateBucket.PredicateExpression.AddWithAnd(RoleAccessControlObjectFields.PermissionTypeId == (long)roleAccessControlObject.PermissionType);

                myAdapter.DeleteEntitiesDirectly(typeof (RoleAccessControlObjectEntity), relationPredicateBucket);
            }
        }

        public RoleAccessControlObject SaveRoleAccessControlObject(RoleAccessControlObject roleAccessControlObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<RoleAccessControlObject, RoleAccessControlObjectEntity>(roleAccessControlObject);

                entity.IsNew = !IsExisting(roleAccessControlObject);

                if (!adapter.SaveEntity(entity, true, true))
                {
                    throw new PersistenceFailureException();
                }
                return roleAccessControlObject;
            }
        }
    }
}
