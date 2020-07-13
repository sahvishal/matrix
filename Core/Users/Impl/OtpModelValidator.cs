using Falcon.App.Core.Application.Attributes; 
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<OtpModel>))]
    public class OtpModelValidator : AbstractValidator<OtpModel>
    {
        public OtpModelValidator()
        {
            RuleFor(x => x.Otp).NotEmpty().WithMessage("Please Enter OTP")
                .Must((x, otp) => !string.IsNullOrEmpty(x.Otp) && x.Otp.Length == 6).WithMessage("Otp Must Be 6 digit long");
        }
    }
}
