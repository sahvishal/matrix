using Falcon.App.Core.Marketing.Domain;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    public class PackageValidator : AbstractValidator<Package>
    {
        //TODO put more rules
        public PackageValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("(required)");
            
        }

    }
}