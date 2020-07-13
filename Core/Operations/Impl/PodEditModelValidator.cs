using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class PodEditModelValidator : AbstractValidator<PodEditModel>
    {
        public PodEditModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("(required)");
            RuleFor(x => x.Name).NotEmpty().WithMessage("(required)");
            RuleFor(x => x.Name).Length(3, 50).WithMessage("(2-50 chars)");
            RuleFor(x => x.Description).Length(0, 2000).When(x => !string.IsNullOrEmpty(x.Description)).WithMessage("(Max 2000 chars)");
            RuleFor(x => x.VanId).NotNull().NotEmpty().GreaterThan(0).WithMessage("required");
            RuleFor(x => x.AssignedToFranchiseeid).NotNull().NotEmpty().GreaterThan(0).WithMessage("required");
            RuleFor(x => x.DefaultStaffAssigned).NotNull().NotEmpty().WithMessage("required");
            RuleFor(x => x.Rooms).Must((x, rooms) => rooms.Count <= 3).WithMessage("can not add more than 3 rooms");
        }

    }
}