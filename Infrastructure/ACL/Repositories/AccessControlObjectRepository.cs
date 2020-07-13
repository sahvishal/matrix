using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.ACL;
using Falcon.App.Core.ACL.Domain;
using Falcon.App.Core.ACL.Enum;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.ACL.Repositories
{
    [DefaultImplementation]
    public class AccessControlObjectRepository : PersistenceRepository, IAccessControlObjectRepository
    {

        public IEnumerable<AccessControlObject> GetRootAccessControlObjects()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.AccessControlObject.Where(r => r.ParentId == 0 || r.ParentId == null).WithPath(path=>path.Prefetch(p=>p.AccessObjectScopeOption).Prefetch(p=>p.RoleAccessControlObject));

                var accessControlObjects = entities.Select(Mapper.Map<AccessControlObjectEntity, AccessControlObject>).ToList();

                return accessControlObjects.Select(GetChildAccessControlObjects).ToList();
            }
        }

        public AccessControlObject GetAccessControlObjectById(long accessControlObjectId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var accessControlObjectEntity = linqMetaData.AccessControlObject.WithPath(path=>path.Prefetch(p=>p.AccessObjectScopeOption)).FirstOrDefault(r => r.Id == accessControlObjectId);

                var accessControlObject = Mapper.Map<AccessControlObjectEntity, AccessControlObject>(accessControlObjectEntity);

                return GetChildAccessControlObjects(accessControlObject);
            }
        }

        public AccessControlObject GetChildAccessControlObjects(AccessControlObject accessControlObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var childrenCount = linqMetaData.AccessControlObject.Count(x => x.ParentId == accessControlObject.Id);

                if (childrenCount < 1) return accessControlObject;

                var childEntities = linqMetaData.AccessControlObject.Where(r => r.ParentId == accessControlObject.Id).WithPath(path => path.Prefetch(p => p.AccessObjectScopeOption));
                var childDomains = childEntities.Select(Mapper.Map<AccessControlObjectEntity, AccessControlObject>).ToList();

                foreach (var controlObject in childDomains)
                {
                    controlObject.Parent = accessControlObject;
                    accessControlObject.Children.Add(GetChildAccessControlObjects(controlObject));
                }

                return accessControlObject;
            }
        }

        public IEnumerable<AccessControlObject> GetAllowedAccessControlObjectsByRoleId(long roleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from raco in linqMetaData.RoleAccessControlObject
                                join aco in linqMetaData.AccessControlObject on raco.AccessControlObjectId equals aco.Id
                                where raco.RoleId == roleId && raco.PermissionTypeId == (long)PermissionType.Allow
                                select aco).WithPath(prefetch => prefetch.Prefetch(p => p.AccessControlObjectUrl).Prefetch(p => p.RoleAccessControlObject).Prefetch(p=>p.AccessObjectScopeOption));

                return Mapper.Map<IEnumerable<AccessControlObjectEntity>, IEnumerable<AccessControlObject>>(entities);
            }
        }

    }
}
