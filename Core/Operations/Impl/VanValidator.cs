using Falcon.App.Core.Operations.Domain;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class VanValidator : AbstractValidator<Van>
    {        
        public VanValidator()
        {
     
            RuleFor(x => x.Name).NotNull().WithMessage("required")
                .NotEmpty().Length(3, 20);            
        }

    }
}