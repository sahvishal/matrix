using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SourceCodeEditModel>))]
    public class SourceCodeEditModelValidator : AbstractValidator<SourceCodeEditModel>
    {
        private ISourceCodeRepository _sourceCodeRepository;

        public SourceCodeEditModelValidator(ISourceCodeRepository sourceCodeRepository)
        {
            _sourceCodeRepository = sourceCodeRepository;

            RuleFor(x => x.CouponCode).NotNull().NotEmpty().WithMessage("required").Length(3, 50).WithMessage("3 - 50 chars").Must(ValidateforUniqueSourceCode).WithMessage("must be unique");
            RuleFor(x => x.SourceCodeTypeId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.CouponValue).NotNull().WithMessage("required").GreaterThanOrEqualTo(0).WithMessage("can not be less than 0").When(x => x.SourceCodeTypeId == (long)DiscountType.PerOrder);
            RuleFor(x => x.CouponValueType).GreaterThan(0).WithMessage("Please specify, if value is Type Money or Percentage.").When(x => x.SourceCodeTypeId == (long)DiscountType.PerOrder);
            RuleFor(x => x.ValidityStartDate).NotNull().NotEmpty().WithMessage("Can not be blank, when End Date is entered.").LessThan(x => x.ValidityEndDate.Value).WithMessage("Can not be greater than Validaity End Date.").When(x => x.ValidityEndDate.HasValue);
            RuleFor(x => x.PackageDiscounts).NotNull().NotEmpty().WithMessage("Please selecte a package or a test.").When(x => x.SourceCodeTypeId == (long)DiscountType.PerPackage && (x.TestDiscounts == null || x.TestDiscounts.Count() < 1));
            RuleFor(x => x.ShippingDiscounts).NotNull().NotEmpty().WithMessage("Please selecte a shipping option.").When(x => x.SourceCodeTypeId == (long)DiscountType.PerShipping);
            RuleFor(x => x.ProductDiscounts).NotNull().NotEmpty().WithMessage("Please selecte a product.").When(x => x.SourceCodeTypeId == (long)DiscountType.PerProduct);
        }

        private bool ValidateforUniqueSourceCode(SourceCodeEditModel model, string sourceCode)
        {
            return model.Id > 0 ? _sourceCodeRepository.ValidateSourceCode(model.CouponCode, model.Id) : _sourceCodeRepository.ValidateSourceCode(model.CouponCode);
        }
    }
}