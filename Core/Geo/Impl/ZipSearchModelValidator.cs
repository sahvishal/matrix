using Falcon.App.Core.Geo.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Geo.Impl
{
    public class ZipSearchModelValidator : AbstractValidator<ZipSearchModel>
    {
        public ZipSearchModelValidator()
        {
            RuleFor(x => x.ZipCode)
                .Length(5, 5).WithMessage("zip should be of 5 digits")
                .Matches("^[0-9]*$").WithMessage("numbers only");
        }


    }
}