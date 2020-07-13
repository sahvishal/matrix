using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;

namespace API.Areas.Users.Impl
{
    public class PatientAddressFactory : IPatientAddressFactory
    {
        private readonly IStateRepository _stateRepository;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public PatientAddressFactory(IStateRepository stateRepository, IZipCodeRepository zipCodeRepository, ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _stateRepository = stateRepository;
            _zipCodeRepository = zipCodeRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        private bool IsEmptyAddress(AddressViewModel address)
        {
            return string.IsNullOrEmpty(address.StreetAddressLine1) || string.IsNullOrEmpty(address.City) ||
                   string.IsNullOrEmpty(address.State) || string.IsNullOrEmpty(address.ZipCode) ||
                   string.IsNullOrEmpty(address.Country);
        }
        public Address GetAddress(AddressViewModel address, Address inpersistence)
        {
            if (inpersistence == null)
                inpersistence = new Address();

            if (IsEmptyAddress(address))
                throw new InvalidAddressException("Some mandatory field missing");

            var country = _countryRepository.GetCountryId(address.Country);


            var state = _stateRepository.GetState(address.State);
            if (state == null) throw new InvalidAddressException(string.Format("{0} not found", address.State));

            var city = _cityRepository.GetCityByStateAndName(state.Id, address.City);
            if (city == null) throw new InvalidAddressException(string.Format("{0} name does not exist in {1}", address.City, address.State));


            var zip = _zipCodeRepository.GetZipCode(address.ZipCode, city.Id);
            if (zip == null) throw new InvalidAddressException(string.Format("{0} name does not exist in {1}", address.ZipCode, address.City));

            inpersistence.StreetAddressLine1 = address.StreetAddressLine1;
            inpersistence.StreetAddressLine2 = address.StreetAddressLine2;
            inpersistence.CityId = city.Id;
            inpersistence.StateId = state.Id;
            inpersistence.ZipCode = zip;
            inpersistence.CountryId = country;

            return inpersistence;
        }
    }
}