using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<GiftCertificate>))]
    public class GiftCertificateValidator : AbstractValidator<GiftCertificate>
    {
        public GiftCertificateValidator()
        {
            RuleFor(x => x.ClaimCode).NotNull().NotEmpty().WithMessage("Claim Code for applying a Gift Certificate is required.");
        }
    }
}