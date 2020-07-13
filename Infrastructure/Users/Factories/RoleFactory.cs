using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class RoleFactory : IRoleFactory
    {
        private readonly IRoleRepository _roleRepository;

        public RoleFactory(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEditModel CreateModel(Role domain)
        {
            return new RoleEditModel
            {
                Id = domain.Id,
                Name = domain.DisplayName,
                ShortName = domain.Alias,
                ParentId = domain.ParentId ?? 0,
                DateCreated = domain.DateCreated,
                DateModified = domain.DateModified,
                DefaultPage = domain.DefaultPage,
                Description = domain.Description,
                ShellType = domain.ShellType,
                OrganizationTypeId = domain.OrganizationTypeId,
                IsSystemRole = domain.IsSystemRole,
                IsTwoFactorAuthrequired = domain.IsTwoFactorAuthrequired,
                IsPinRequired = domain.IsPinRequired
            };
        }

        public Role CreateDomain(RoleEditModel model)
        {
            var domain = new Role
            {
                Id = model.Id,
                Alias = model.ShortName,
                ParentId = null,
                DisplayName = model.Name,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified,
                DefaultPage = model.DefaultPage,
                Description = model.Description,
                ShellType = model.ShellType,
                OrganizationTypeId = model.OrganizationTypeId,
                IsSystemRole = model.IsSystemRole,
                IsTwoFactorAuthrequired = model.IsTwoFactorAuthrequired,
                IsPinRequired = model.IsPinRequired
            };
            
            if (model.ParentId > 0)
            {
                domain.ParentId = model.ParentId;
            }

            if (model.Id < 1 && model.ParentId > 0)
            {
                var parentRole = _roleRepository.GetByRoleId(model.ParentId);

                domain.DateCreated = DateTime.Now;
                domain.DateModified = DateTime.Now;
                domain.OrganizationTypeId = parentRole.OrganizationTypeId;
                domain.ShellType = parentRole.ShellType;
                domain.DefaultPage = parentRole.DefaultPage;
                domain.Description = parentRole.Description;
                domain.Alias = parentRole.Alias;
            }

            return domain;
        }
    }
}
