using Falcon.App.Core.Geo.Domain;
using FluentValidation;

namespace Falcon.App.Core.Geo.Impl
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.StreetAddressLine1).NotEmpty();
            RuleFor(x => x.State).NotEmpty().When(x => x.StateId < 1);
            RuleFor(x => x.StateId).GreaterThan(0).When(x => x.State == null);
            RuleFor(x => x.Country).NotEmpty().When(x => x.CountryId < 1);
            RuleFor(x => x.CountryId).GreaterThan(0).When(x => x.Country == null);
            RuleFor(x => x.City).NotEmpty().When(x => x.CityId < 1);
            RuleFor(x => x.CityId).GreaterThan(0).When(x => x.City == null);
            RuleFor(x => x.ZipCode).NotNull();

        }
        
    }
}