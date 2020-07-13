using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<RoleEditModel>))]
    public class RoleEditModelValidator : AbstractValidator<RoleEditModel>
    {
        public RoleEditModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name cannot be empty").NotEmpty().WithMessage("Name cannot be empty");
            //RuleFor(x => x.ShortName).NotNull().WithMessage("Alias cannot be empty").NotEmpty().WithMessage("Alias cannot be empty");
            RuleFor(x => x.ParentId).GreaterThan(0).WithMessage("Please select a Base role").When(x => !x.IsSystemRole && x.Id != (long)Core.Enum.Roles.Customer);

        }
    }


}