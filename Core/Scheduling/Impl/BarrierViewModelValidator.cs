using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;


namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<BarrierEditModel>))]
    public class BarrierViewModelValidator : AbstractValidator<BarrierEditModel>
    {
        public BarrierViewModelValidator()
        {
            RuleFor(m => m.BarrierId).GreaterThan(0).WithMessage("required.");
            RuleFor(m => m.Reason).NotEmpty().NotNull().WithMessage("required.");
        }
    }
}
