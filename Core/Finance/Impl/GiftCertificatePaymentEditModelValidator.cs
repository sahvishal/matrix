using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<GiftCertificatePaymentEditModel>))]
    public class GiftCertificatePaymentEditModelValidator : AbstractValidator<GiftCertificatePaymentEditModel>
    {
        public GiftCertificatePaymentEditModelValidator()
        {
            RuleFor(x => x.GiftCertificate).NotNull().WithMessage("Gift certificate information is required.");
            RuleFor(x => x.GiftCertificatePayment).NotNull().WithMessage("Amount Information for applying Gift certificate is required.");
        }
    }
}