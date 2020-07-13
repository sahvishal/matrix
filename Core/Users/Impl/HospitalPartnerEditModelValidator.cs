using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HospitalPartnerEditModel>))]
    public class HospitalPartnerEditModelValidator : AbstractValidator<HospitalPartnerEditModel>
    {
        public HospitalPartnerEditModelValidator()
        {
            RuleFor(x => x.MailTransitDays).NotNull().WithMessage("required");
        }
    }
}