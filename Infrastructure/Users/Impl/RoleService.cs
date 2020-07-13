using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.ACL;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using SD.LLBLGen.Pro.LinqSupportClasses.ExpressionClasses;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleAccessControlListService _roleAccessControlListService;
        private readonly IRoleFactory _roleFactory;

        public RoleService(IRoleRepository roleRepository, IRoleAccessControlListService roleAccessControlListService, IRoleFactory roleFactory)
        {
            _roleRepository = roleRepository;
            _roleAccessControlListService = roleAccessControlListService;
            _roleFactory = roleFactory;
        }

        public RoleEditModel Get(long roleId)
        {
            var domain = _roleRepository.GetByRoleId(roleId);

            if (domain == null) return new RoleEditModel(){IsTwoFactorAuthrequired = true};

            return _roleFactory.CreateModel(domain);
        }

        public RoleEditModel Save(RoleEditModel model)
        {
            var domain = _roleFactory.CreateDomain(model);
            domain.IsActive = true;
            var isNew = domain.Id < 1;

            if (model.ResetAllOverrides)
            {
                _roleRepository.OverRideIsTwoFactorAuthRequired(model.Id);
            }
            if (model.Id > 0 || !_roleRepository.GetRolesByExactName(model.Name).Any())
            {
                _roleRepository.Save(domain);
            }
            else
            {
                throw new Exception("Duplicate Name");
            }

            if (isNew && domain.ParentId != null && domain.ParentId.Value > 0)
            {
                _roleAccessControlListService.CreateAccessPermissionsBasedonParentRole(domain.ParentId.Value, domain.Id);
            }
            
            model.Id = domain.Id;

            return model;
        }

        public RoleListModel Get(RoleListModelFilter filter)
        {
            var collection = _roleRepository.GetRolesByName(filter.Name);
            
            var viewModels = collection.Select(r=>
                                    new RoleViewModel
                                  {
                                      Id = r.Id,
                                      Name = r.DisplayName,
                                      ParentId = r.ParentId ?? 0,
                                      ParentRole = r.ParentId != null && r.ParentId.Value > 0 ? collection.FirstOrDefault(x=>x.Id == r.ParentId.Value).DisplayName : string.Empty,
                                      ShortName = r.Alias,
                                      UserCount = _roleRepository.GetRoleCount(r.Id)
                                  }).ToArray();

            return new RoleListModel
                {
                    Filter = filter,
                    Collection = viewModels
                };

        }

        public IEnumerable<RoleSelectItemModel> GetRoles(Roles parentRole)
        {
            var parentRoleId = (long)parentRole;

            var roles = _roleRepository.GetRolesByParentId(parentRoleId);

            return roles.Select(x => new RoleSelectItemModel { RoleName = x.DisplayName, RoleId = x.Id, ParentRole = parentRole }).ToArray();
        }
    }
}