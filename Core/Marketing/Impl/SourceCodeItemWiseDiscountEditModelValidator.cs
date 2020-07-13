using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SourceCodeItemWiseDiscountEditModel>))]
    public  class SourceCodeItemWiseDiscountEditModelValidator : AbstractValidator<SourceCodeItemWiseDiscountEditModel>
    {
        public SourceCodeItemWiseDiscountEditModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Selection");
            RuleFor(x => x.DiscountAmount).NotNull().WithMessage("Discount Value should not be empty.").GreaterThanOrEqualTo(0).WithMessage("Discount Amount can not be less than 0");
            RuleFor(x => x.DiscountValueType).GreaterThan(0).WithMessage("Please specify, if value is Type Money or Percentage.");
        }
    }
}