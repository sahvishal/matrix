using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<GiftCertificatePayment>))]
    public class GiftCertificatePaymentValidator : AbstractValidator<GiftCertificatePayment>
    {
        public GiftCertificatePaymentValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("A Gift Certificate with value 0 is invalid!");
        }
    }
}