using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<RefundRequestResultEditModel>))]
    public class RefundRequestResultEditModelValidator : AbstractValidator<RefundRequestResultEditModel>
    {
        public RefundRequestResultEditModelValidator()
        {
            RuleFor(d => (int) d.RequestResultType).GreaterThan(0).WithMessage("Choose one option to proceed.");
            RuleFor(d => d.RequestResultType).Must(ValidateModelforOfferedDiscounts).WithMessage("Please specify which Free add on or Discount being offered.");
            RuleFor(d => d.Notes).NotNull().NotEmpty().WithMessage("required").Length(10, 2000).WithMessage(
                "(10-2000)chars");
            RuleFor(d => d.PaymentEditModel).SetValidator(new PaymentEditModelValidator());
            RuleFor(d => d.PaymentEditModel).Must(ValidateModelforPayments).When(d => d.PaymentEditModel != null).WithMessage("Please add payments to proceed.");
        }


        private static bool ValidateModelforPayments(RefundRequestResultEditModel model, PaymentEditModel childModel)
        {
            if(model.RequestResultType == RequestResultType.RescheduleAppointment || model.RequestResultType == RequestResultType.IssueGiftCertificate 
                || (model.RequestResultType == RequestResultType.OfferFreeAddonsAndDiscounts && model.PaymentEditModel.Amount == 0))
                return true;

            if (model.PaymentEditModel.Amount == 0 && model.PaymentEditModel.Payments == null && model.RefundAmount>0)
                return false;

            return true;
        }

        private static bool ValidateModelforOfferedDiscounts(RefundRequestResultEditModel model, RequestResultType a)
        {
            if (model.RequestResultType == RequestResultType.OfferFreeAddonsAndDiscounts && !model.OfferDiscount && (model.OfferFreeProduct != null && model.OfferFreeProduct.Where(p => p.ProductAvailed).Count() < 1))
                return false;

            return true;
        }
    }
}