using Falcon.App.Core.Geo.ViewModels;
using FluentValidation;
namespace Falcon.App.Core.Geo.Impl
{
    public class AddressEditModelValidator : AbstractValidator<AddressEditModel>
    {
        public AddressEditModelValidator()
        {
            RuleFor(x => x.StreetAddressLine1).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
            RuleFor(x => x.StateId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Please select state").OverridePropertyName("State");
            RuleFor(x => x.CountryId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required");
            RuleFor(x => x.City).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
            RuleFor(x => x.ZipCode).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
        }
    }
}