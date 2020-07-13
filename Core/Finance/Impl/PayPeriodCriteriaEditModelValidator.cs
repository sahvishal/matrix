using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PayPeriodCriteriaEditModel>))]
    public class PayPeriodCriteriaEditModelValidator : AbstractValidator<PayPeriodCriteriaEditModel>
    {
        public PayPeriodCriteriaEditModelValidator()
        {
            RuleFor(x => x.MinCustomer).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Greater than 0").When(x => (x.TypeId == (long)PayPeriodCriteriaType.GreaterThanEqualTo) || (x.TypeId == (long)PayPeriodCriteriaType.Between));
            RuleFor(x => x.MaxCustomer).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Greater than 0").When(x => (x.TypeId == (long)PayPeriodCriteriaType.LessThanEqualTo) || (x.TypeId == (long)PayPeriodCriteriaType.Between));
            RuleFor(x => x.TypeId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required");
            RuleFor(x => x.Amount).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Greater than 0");
        }
    }
}