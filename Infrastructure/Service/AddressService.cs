using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Interfaces;
using Falcon.App.Infrastructure.Geo.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Service
{
    public class AddressService : IAddressService
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IZipCodeRepository _zipCodeRepository;

        public AddressService()
        {
            _stateRepository = new StateRepository();
            _cityRepository = new CityRepository();
            _zipCodeRepository = new ZipCodeRepository();
        }

        public State GetState(string stateName, string cityName, string zipCode)
        {
            try
            {
                var state = _stateRepository.GetState(stateName);
                if (state != null)
                {
                    // TODO: Ideally it should not be the case, there can be a single city with given name for a given state.
                    // But due to the data problem we are returning list of cities.
                    var cities = _cityRepository.GetCityForState(state.Id, cityName);
                    if (cities != null && !cities.IsEmpty())
                    {
                        var city =
                            cities.Where(
                                c =>
                                c.ZipCodes != null && !c.ZipCodes.IsEmpty() &&
                                c.ZipCodes.Select(zc => zc.Zip).Contains(zipCode)).FirstOrDefault();

                        if (city != null)
                        {
                            var zip =
                              _zipCodeRepository.GetZipCodeForCity(city.Id).Where(z => z.Zip == zipCode).SingleOrDefault();
                            if (zip != null)
                            {
                                city.ZipCodes = new List<ZipCode> { zip };
                                state.Cities = new List<City> { city };
                                return state;
                            }
                        }
                    }
                }
            }
            // TODO: This is done because there is problems with the data in the system,
            // We dont always get right data, so for now consuming it.
            // TODO: We really need to handle this state, city,zip combination uniquness more elegantly.
            catch { }
            return null;
        }

        public State GetStateByZipCode(string zipCode)
        {
            var zip = _zipCodeRepository.GetZipCode(zipCode);
            if (zip != null)
            {
                var city = _cityRepository.GetCityByZipCode(zipCode);
                if (city != null)
                {
                    city.ZipCodes = new List<ZipCode> { zip };

                    var state = _stateRepository.GetStateByCityId(city.Id);
                    if (state != null)
                    {
                        state.Cities = new List<City> { city };
                        return state;
                    }
                }
            }
            return null;
        }
    }
}
