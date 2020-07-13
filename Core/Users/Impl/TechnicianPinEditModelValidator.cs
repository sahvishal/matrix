using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<TechnicianPinEditModel>))]
    public class TechnicianPinEditModelValidator : AbstractValidator<TechnicianPinEditModel>
    {
        public TechnicianPinEditModelValidator(){
        
            RuleFor(x => x.Pin)
                .NotEmpty()
                .WithMessage("required")
                .NotNull()
                .WithMessage("required")
                .Length(4)
                .WithMessage("length must be 4");
        }
    }
}
