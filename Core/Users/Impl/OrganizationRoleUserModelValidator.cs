using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class OrganizationRoleUserModelValidator : AbstractValidator<OrganizationRoleUserModel>
    {
        public OrganizationRoleUserModelValidator()
        {
            RuleFor(x => x.OrganizationId).GreaterThan(0);
            RuleFor(x => x.RoleId).GreaterThan(0);            
        }
    }
}