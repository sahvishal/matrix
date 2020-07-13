using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo.Impl;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PaymentInstrumentEditModel>))]
    public class PaymentInstrumentEditModelValidator : AbstractValidator<PaymentInstrumentEditModel>
    {
        public PaymentInstrumentEditModelValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount can not be less than or equal to zero.");
            RuleFor(x => x.PaymentType).GreaterThan(0).WithMessage("Please select the payment mode.");
            RuleFor(d => d.ChargeCard).SetValidator(new ChargeCardPaymentEditModelValidator()).When(d => d.PaymentType == PaymentType.CreditCard.PersistenceLayerId || d.PaymentType == PaymentType.CreditCardOnFile_Value);
            RuleFor(d => d.Check).SetValidator(new CheckPaymentEditModelValidator()).When(d => d.PaymentType == PaymentType.Check.PersistenceLayerId);
            RuleFor(d => d.ECheck).SetValidator(new ECheckPaymentEditModelValidator()).When(d => d.PaymentType == PaymentType.ElectronicCheck.PersistenceLayerId);

            RuleFor(d => d.BillingAddress).SetValidator(new AddressEditModelValidator()).When(d => d.ChargeCard != null || d.ECheck != null);
        }
    }
}