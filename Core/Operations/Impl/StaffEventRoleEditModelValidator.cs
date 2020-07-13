using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
   public class StaffEventRoleEditModelValidator : AbstractValidator<StaffEventRoleEditModel>
    {
       public StaffEventRoleEditModelValidator()
       {
           RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("required").Length(4, 50).WithMessage("4-50 chars");
       }
    }
}
