using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.ACL;
using Falcon.App.Core.ACL.Domain;
using Falcon.App.Core.ACL.Enum;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.ACL.Impl
{
    [DefaultImplementation]
    public class RoleAccessControlListService : IRoleAccessControlListService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAccessControlObjectRepository _accessControlObjectRepository;
        private readonly IRoleAccessControlObjectRepository _roleAccessControlObjectRepository;

        public RoleAccessControlListService(IRoleRepository roleRepository, IAccessControlObjectRepository accessControlObjectRepository, IRoleAccessControlObjectRepository roleAccessControlObjectRepository)
        {
            _roleRepository = roleRepository;
            _accessControlObjectRepository = accessControlObjectRepository;
            _roleAccessControlObjectRepository = roleAccessControlObjectRepository;
        }

        public RoleAccessControlObjectEditModel Get(long roleId)
        {
            if (roleId < 1) throw new InvalidOperationException();

            var role = _roleRepository.GetByRoleId(roleId);
            var accessControlObjects = GetListofAccessControlObject(role, _accessControlObjectRepository.GetRootAccessControlObjects().ToArray());
            var roleAccessControlObjects = _roleAccessControlObjectRepository.GetRoleAccessControlObjectByRoleId(roleId).ToArray();

            var model = new RoleAccessControlObjectEditModel
                {
                    RoleId = role.Id,
                    RoleName = role.DisplayName,
                    AccessControlObjects = CreateViewModel(accessControlObjects, roleAccessControlObjects).OrderBy(x => x.DisplayOrder).ToArray()
                };

            //if (role.ParentId != null && role.ParentId > 0)
            //{
                //var parentRole = _roleRepository.GetByRoleId(role.ParentId.Value);
                //var parentRoleAccessControlObjects = _roleAccessControlObjectRepository.GetRoleAccessControlObjectByRoleId(parentRole.Id).ToArray();
                //DisableAccessControlNotInBaseRole(model.AccessControlObjects, parentRoleAccessControlObjects);
            //}

            return model;
        }

        //private void DisableAccessControlNotInBaseRole(IList<AccessControlObjectViewModel> model, IEnumerable<RoleAccessControlObject> parentRoleAccessControlObject)
        //{
        //    foreach (var accessControl in model)
        //    {
        //        int count = parentRoleAccessControlObject.Count(x => x.AccessControlObject.Id == accessControl.Id);
        //        accessControl.IsAvailableInParent = count > 0;
        //        if (accessControl.Children.Any())
        //        {
        //            DisableAccessControlNotInBaseRole(accessControl.Children, parentRoleAccessControlObject);
        //        }
        //    }
        //}

        //private void UpdateChildAccessControlObjects(long parentRoleId)
        //{
        //    var parentRoleAccessControlObjects = _roleAccessControlObjectRepository.GetRoleAccessControlObjectByRoleId(parentRoleId);

        //    var childRoles = _roleRepository.GetRolesByParentId(parentRoleId);
        //    foreach (var role in childRoles)
        //    {
        //        var roleAccessControlObjects = _roleAccessControlObjectRepository.GetRoleAccessControlObjectByRoleId(role.Id);
        //        foreach (var rac in roleAccessControlObjects.Where(y => !(parentRoleAccessControlObjects.Select(x => x.AccessControlObject.Id)).Contains(y.AccessControlObject.Id)))
        //        {
        //            rac.PermissionType = PermissionType.Deny;
        //            _roleAccessControlObjectRepository.SaveRoleAccessControlObject(rac);
        //            //_roleAccessControlObjectRepository.DeleteRoleAccessControlObject(rac);
        //        }
        //    }
        //}

        public void Save(RoleAccessControlObjectEditModel model)
        {
            if (model.RoleId < 1) throw new InvalidOperationException();

            SaveWithoutUpdatingChildRole(model);
            //UpdateChildAccessControlObjects(model.RoleId);
        }

        public void CreateAccessPermissionsBasedonParentRole(long parentRoleId, long roleId)
        {
            var parentRoleAccessControl = Get(parentRoleId);
            parentRoleAccessControl.RoleId = roleId;
            SaveWithoutUpdatingChildRole(parentRoleAccessControl);
        }

        private void SaveWithoutUpdatingChildRole(RoleAccessControlObjectEditModel model)
        {
            var roleAccessControlObjects = _roleAccessControlObjectRepository.GetRoleAccessControlObjectByRoleId(model.RoleId).ToArray();

            var objsToSave = GetSelectedObjects(model.AccessControlObjects);
            var objAccessIds = objsToSave.Select(x => x.FirstValue).ToArray();
            var objsToDelete = roleAccessControlObjects.Where(x => !objAccessIds.Contains(x.AccessControlObject.Id)).ToArray();


            foreach (RoleAccessControlObject roleAccessControlObject in objsToDelete)
            {
                roleAccessControlObject.PermissionType = PermissionType.Deny;
                _roleAccessControlObjectRepository.SaveRoleAccessControlObject(roleAccessControlObject);
                //_roleAccessControlObjectRepository.DeleteRoleAccessControlObject(roleAccessControlObject);
            }

            foreach (var item in objsToSave)
            {
                var obj = roleAccessControlObjects.SingleOrDefault(x => x.AccessControlObject.Id == item.FirstValue);

                if (obj != null)
                {
                    obj.DataScope = (DataScope)item.SecondValue;
                    obj.PermissionType = PermissionType.Allow;

                    _roleAccessControlObjectRepository.SaveRoleAccessControlObject(obj);
                }
                else
                {
                    obj = new RoleAccessControlObject
                    {
                        AccessControlObject = _accessControlObjectRepository.GetAccessControlObjectById(item.FirstValue),
                        DataScope = (DataScope)item.SecondValue,
                        Role = new Role(model.RoleId),
                        PermissionType = PermissionType.Allow
                    };

                    _roleAccessControlObjectRepository.SaveRoleAccessControlObject(obj);
                }

            }
        }

        private IList<OrderedPair<long, long>> GetSelectedObjects(IEnumerable<AccessControlObjectViewModel> collectionModel)
        {
            var collection = new List<OrderedPair<long, long>>();

            foreach (AccessControlObjectViewModel model in collectionModel)
            {
                if (!model.IsSelected && !model.IsRequired) continue;
                collection.Add(new OrderedPair<long, long>(model.Id, model.DataScopeId));

                if (model.Children.Any())
                {
                    var result = GetSelectedObjects(model.Children.ToList());
                    if (result.Any())
                        collection.AddRange(result);
                }
            }

            return collection;
        }

        private IEnumerable<AccessControlObject> GetListofAccessControlObject(Role role, IEnumerable<AccessControlObject> accessControlObjects)
        {
            var roleScopeOptions = role.GetRoleScopeOptions().ToArray();

            if (!roleScopeOptions.Any()) return accessControlObjects;

            var scopeOptions = roleScopeOptions.Select(x => (long)x.Scope).ToArray();

            var collection = new List<AccessControlObject>();

            foreach (var accessObject in accessControlObjects)
            {
                var scopeOptionsforCurrentObject = accessObject.AccessObjectScopeOptions.Where(x => scopeOptions.Contains((long)x.Scope)).ToArray();

                if (!scopeOptionsforCurrentObject.Any()) continue;

                accessObject.AccessObjectScopeOptions = scopeOptionsforCurrentObject;

                if (accessObject.Children != null)
                {
                    accessObject.Children = GetListofAccessControlObject(role, accessObject.Children).ToList();
                }

                collection.Add(accessObject);
            }

            return collection;
        }

        private IList<AccessControlObjectViewModel> CreateViewModel(IEnumerable<AccessControlObject> collectionObject, IList<RoleAccessControlObject> roleAccessControlObjects)
        {
            var collection = new List<AccessControlObjectViewModel>();

            foreach (var aclObj in collectionObject)
            {
                var roleAccessObject = roleAccessControlObjects.SingleOrDefault(x => x.AccessControlObject.Id == aclObj.Id);

                if (roleAccessObject == null) continue;

                var obj = new AccessControlObjectViewModel
                    {
                        Id = aclObj.Id,
                        Title = aclObj.Title,
                        Alias = aclObj.Alias,
                        DisplayOrder = aclObj.DisplayOrder,
                        IsRootParent = aclObj.Parent == null || aclObj.Parent.Id < 1,
                        IsRequired = aclObj.IsRequired
                    };

                if (aclObj.Children.Any())
                {
                    obj.Children = CreateViewModel(aclObj.Children, roleAccessControlObjects);
                }


                obj.IsSelected = roleAccessObject.PermissionType == PermissionType.Allow;
                obj.DataScopeId = (long)roleAccessObject.DataScope;
                
                var scopeOptions = aclObj.AccessObjectScopeOptions.ToArray();

                obj.DataScopeOptions = scopeOptions.Any() ? scopeOptions.Select(m => (long)m.Scope).ToList() : new List<long> { (long)DataScope.Global };
                //obj.DataScopeOptions = aclObj.AccessObjectScopeOptions.Select(m => (long)m.Scope).ToArray();
                //obj.DataScopeOptions = new List<long> {(long)DataScope.Global};
                collection.Add(obj);
            }

            return collection;
        }
    }
}