using System;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Enum;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Geo.ViewModels;
using FluentValidation;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Enum;


namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class AddressService : IAddressService
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IValidator<Address> _addressValidator;
        private readonly IZipDataRepository _zipDataRepository;

        public AddressService(IStateRepository stateRepository, ICityRepository cityRepository, IZipCodeRepository zipCodeRepository,
                            ICountryRepository countryRepository, IValidator<Address> addressValidator, IAddressRepository addressRepository, IZipDataRepository zipDataRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _zipCodeRepository = zipCodeRepository;
            _addressValidator = addressValidator;
            _addressRepository = addressRepository;
            _zipDataRepository = zipDataRepository;
        }

        public AddressService()
            : this(new StateRepository(), new CityRepository(), new ZipCodeRepository(), new CountryRepository(), new AddressValidator(), new AddressRepository(), new ZipDataRepository())
        { }


        public Address GetSanitizeAddress(Address addressToSanitize)
        {
            try
            {
                _addressValidator.ValidateAndThrow(addressToSanitize);
            }
            catch (ValidationException)
            {

                throw new InvalidAddressException("Address not valid.");
            }


            if (addressToSanitize.CountryId < 1)
            {
                addressToSanitize.CountryId = _countryRepository.GetCountryId(addressToSanitize.Country);
            }

            if (Enum.IsDefined(AddressValidatableCountries.USA.GetType(), (Int32)addressToSanitize.CountryId))
            {
                if (addressToSanitize.ZipCode.Zip.Length > 5)
                    addressToSanitize.ZipCode.Zip = addressToSanitize.ZipCode.Zip.Substring(0, 5);
                addressToSanitize = GetCompleteAddressforValidatable(addressToSanitize);
            }
            else
                addressToSanitize = GetCompleteAddressforUnValidatable(addressToSanitize);

            return addressToSanitize;
        }

        private Address GetCompleteAddressforValidatable(Address addressToSanitize)
        {
            State state;
            if (addressToSanitize.StateId < 1)
            {
                if (!string.IsNullOrEmpty(addressToSanitize.State))
                    state = _stateRepository.GetState(addressToSanitize.State);
                else
                    state = _stateRepository.GetStatebyCode(addressToSanitize.StateCode);

                addressToSanitize.StateId = state.Id;
            }
            else
                state = _stateRepository.GetState(addressToSanitize.StateId);

            if (addressToSanitize.CityId < 1)
            {
                var city = _cityRepository.GetCityByStateAndName(addressToSanitize.StateId, addressToSanitize.City);
                if (city == null) throw new InvalidAddressException(state.Name, addressToSanitize.City, addressToSanitize.ZipCode.Zip);

                addressToSanitize.CityId = city.Id;
            }

            if (addressToSanitize.ZipCode.Id < 1)
            {
                var zip = _zipCodeRepository.GetZipCodeForCity(addressToSanitize.CityId).Where(z => z.Zip == addressToSanitize.ZipCode.Zip).SingleOrDefault();
                if (zip != null)
                    addressToSanitize.ZipCode.Id = zip.Id;
                else
                {
                    throw new InvalidAddressException(state.Name, addressToSanitize.City, addressToSanitize.ZipCode.Zip);
                }
            }
            return addressToSanitize;
        }

        private Address GetCompleteAddressforUnValidatable(Address addressToSanitize)
        {
            State state;
            if (addressToSanitize.StateId < 1)
            {
                state = _stateRepository.GetState(addressToSanitize.State);
                addressToSanitize.StateId = state.Id;
            }
            else
                state = _stateRepository.GetState(addressToSanitize.StateId);

            if (addressToSanitize.CityId < 1)
            {
                var city = _cityRepository.GetCityByStateAndName(addressToSanitize.StateId, addressToSanitize.City.Trim());
                if (city == null)
                {
                    city = _cityRepository.Save(new City() { Name = addressToSanitize.City.Trim(), StateId = state.Id });
                }

                addressToSanitize.CityId = city.Id;
            }

            if (addressToSanitize.ZipCode.Id < 1)
            {
                var zips = _zipCodeRepository.GetZipCodeForCity(addressToSanitize.CityId);
                if (zips != null && zips.Count > 0)
                {
                    var zip = zips.Where(z => z.Zip == addressToSanitize.ZipCode.Zip).SingleOrDefault();
                    if (zip != null)
                        addressToSanitize.ZipCode.Id = zip.Id;
                    else
                    {
                        addressToSanitize.ZipCode = _zipCodeRepository.Save(new ZipCode() { CityId = addressToSanitize.CityId, Zip = addressToSanitize.ZipCode.Zip });
                    }
                }
                else
                {
                    addressToSanitize.ZipCode = _zipCodeRepository.Save(new ZipCode() { CityId = addressToSanitize.CityId, Zip = addressToSanitize.ZipCode.Zip });
                }
            }
            return addressToSanitize;
        }

        public Address GetSanitizeAddress(string zipCode)
        {
            var sanitizedAddress = new Address();

            //TODO:This can be reduced to one call from the db.
            try
            {
                var zip = _zipCodeRepository.GetZipCode(zipCode).FirstOrDefault();
                if (zip != null)
                {
                    sanitizedAddress.ZipCode = zip;
                    var city = _cityRepository.GetCityByZipCode(zipCode);
                    if (city != null)
                    {
                        sanitizedAddress.City = city.Name;
                        sanitizedAddress.CityId = city.Id;

                        var state = _stateRepository.GetStateByCityId(city.Id);
                        if (state != null)
                        {
                            sanitizedAddress.State = state.Name;
                            sanitizedAddress.StateId = state.Id;
                            sanitizedAddress.CountryId = _countryRepository.GetCountryByStateId(state.Id).Id;
                        }
                    }
                }
                else
                {
                    throw new InvalidAddressException("", "", zipCode);
                }
            }
            catch (InvalidAddressException)
            {
                throw new InvalidAddressException("", "", zipCode);
            }
            return sanitizedAddress;
        }

        public Address SaveAfterSanitizing(Address addressToSave, bool checkZipData = false)
        {
            bool needVerification = false;

            try
            {
                addressToSave = GetSanitizeAddress(addressToSave);
            }
            catch (InvalidAddressException)
            {
                if (checkZipData && addressToSave.ZipCode != null && !string.IsNullOrEmpty(addressToSave.ZipCode.Zip) && !string.IsNullOrEmpty(addressToSave.City) && addressToSave.StateId > 0)
                {
                    var state = _stateRepository.GetState(addressToSave.StateId);
                    var zipData = _zipDataRepository.GetZipData(addressToSave.ZipCode.Zip, addressToSave.City, state.Code);
                    if (zipData == null)
                    {
                        var avaailableCities = _zipDataRepository.GetZipData(addressToSave.ZipCode.Zip, state.Code);
                        if (avaailableCities == null)
                            throw;
                        throw new InvalidAddressException("Incorrect city entered. Available cities for " + addressToSave.ZipCode.Zip + " are : " + string.Join(", ", avaailableCities.Select(ac => ac.City).ToArray()));
                    }
                    addressToSave.CityId = 0;
                    addressToSave.City = zipData.City;
                    addressToSave.ZipCode.Zip = zipData.ZipCode;

                    ImportZipData(zipData);
                    addressToSave = GetSanitizeAddress(addressToSave);
                    needVerification = true;
                }
                else
                    throw;
            }
            var address = _addressRepository.Save(addressToSave);
            if (needVerification)
            {
                _addressRepository.UpdateNeedVerfication(address.Id, true);
            }
            return address;
        }

        public Address SaveTemporaryAfterSanitizing(Address temporaryAddress)
        {
            return _addressRepository.SaveTemporary(GetSanitizeAddress(temporaryAddress));
        }

        public AddressViewModel GetAddress(long addressId)
        {
            return Mapper.Map<Address, AddressViewModel>(_addressRepository.GetAddress(addressId));
        }


        public AddressEditModel GetAddressEditModel(long addressId)
        {
            return Mapper.Map<Address, AddressEditModel>(_addressRepository.GetAddress(addressId));
        }

        private void ImportZipData(ZipData data)
        {
            //foreach (var data in zipData)
            //{
            var state = string.IsNullOrEmpty(data.StateCode) ? null : _stateRepository.GetStatebyCode(data.StateCode);

            if (state != null)
            {
                var city = _cityRepository.GetCityByStateAndName(state.Id, data.City);

                if (city == null)
                {
                    city = new City()
                    {
                        Name = data.City,
                        CityCode = "",
                        Description = "Created while importing Zip from External Source.",
                        StateId = state.Id
                    };
                    city = _cityRepository.Save(city);
                }

                ZipCode zip = null;
                try
                {
                    zip = _zipCodeRepository.GetZipCode(data.ZipCode, city.Id);
                    if (zip == null)
                    {
                        zip = new ZipCode { CityId = city.Id, Zip = data.ZipCode };
                    }


                }
                catch (ObjectNotFoundInPersistenceException<ZipCode>)
                {
                    zip = new ZipCode { CityId = city.Id, Zip = data.ZipCode };
                }
                if (zip.Id <= 0)
                {
                    PrepareZipObject(data.Latitude, data.Longitude, data.TimeZone, data.DayLightSaving, zip);
                    _zipCodeRepository.Save(zip);
                }

            }
            //}
        }


        private long SaveNewZipCode(ZipData data, long cityId, string zipCode)
        {
            var retZip = new ZipCode();
            if (data != null)
            {
                ZipCode zip = new ZipCode { CityId = cityId, Zip = data.ZipCode };
                PrepareZipObject(data.Latitude, data.Longitude, data.TimeZone, data.DayLightSaving, zip);
                retZip = _zipCodeRepository.Save(zip);
            }
            else
            {
                ZipCode zip = new ZipCode { CityId = cityId, Zip = zipCode, Latitude = 0, Longitude = 0, TimeZone = 0, IsInDaylightSavingsTime = false };
                retZip = _zipCodeRepository.Save(zip);
            }
            return retZip != null ? retZip.Id : 0;
        }

        private void PrepareZipObject(string latitude, string longitude, string timeZone, string dayLightSaving, ZipCode zip)
        {

            float flLatitude;
            zip.Latitude = float.TryParse(latitude, out flLatitude) ? flLatitude : 0;

            float flLongitude;
            if (float.TryParse(longitude, out flLongitude))
                zip.Longitude = flLongitude;

            int timeZoneNumber = 0;
            if (int.TryParse(timeZone.Trim(), out timeZoneNumber))
            {
                timeZoneNumber = timeZoneNumber > 0 ? timeZoneNumber * -1 : timeZoneNumber;
                if (Enum.IsDefined(Core.Enum.TimeZone.Unknown.GetType(), timeZoneNumber))
                    zip.TimeZone = (Core.Enum.TimeZone)timeZoneNumber;
                else
                {
                    zip.TimeZone = Core.Enum.TimeZone.Unknown;
                }
            }
            else
                zip.TimeZone = Core.Enum.TimeZone.Unknown;

            zip.IsInDaylightSavingsTime = dayLightSaving.ToLower().Contains("y") ? true : false;
        }

        public Address GetAddressSanitizingInvalidZip(Address addressToSave, CorporateCustomerEditModel model, string addressTobe)
        {
            bool needVerification = false;
            long newZipId = 0;
            long newCityId = 0;
            try
            {

                addressToSave = GetSanitizeAddress(addressToSave);
            }
            catch (InvalidAddressException)
            {
                if (addressToSave.ZipCode != null && !string.IsNullOrEmpty(addressToSave.ZipCode.Zip) && !string.IsNullOrEmpty(addressToSave.City) && addressToSave.StateId > 0)
                {
                    State state;
                    if (addressToSave.StateId < 1)
                    {
                        if (!string.IsNullOrEmpty(addressToSave.State))
                            state = _stateRepository.GetState(addressToSave.State);
                        else
                            state = _stateRepository.GetStatebyCode(addressToSave.StateCode);

                        addressToSave.StateId = state.Id;
                    }
                    else
                        state = _stateRepository.GetState(addressToSave.StateId);

                    if (addressToSave.CityId < 1)
                    {
                        var city = _cityRepository.GetCityByStateAndName(addressToSave.StateId, addressToSave.City);
                        if (city == null)
                        {
                            city = _cityRepository.Save(new City() { Name = addressToSave.City.Trim(), StateId = state.Id });
                            newCityId = city != null ? city.Id : 0;
                        }

                        addressToSave.CityId = city.Id;

                    }

                    var zipData = _zipDataRepository.GetZipDataByZipCodeCity(addressToSave.ZipCode.Zip, addressToSave.City);
                    if (zipData != null)
                    {
                        addressToSave.CityId = addressToSave.CityId;
                        addressToSave.City = zipData.City;
                        addressToSave.ZipCode.Zip = zipData.ZipCode;
                    }

                    newZipId = SaveNewZipCode(zipData, addressToSave.CityId, addressToSave.ZipCode.Zip);

                    addressToSave = GetSanitizeAddress(addressToSave);
                    needVerification = true;
                }
                else
                    throw;
            }
            if (needVerification)
            {
                if (addressTobe.ToLower() == MemberUploadAddress.CustomerAddress.ToString().ToLower())
                {
                    model.IsCustomerZipInvalid = true;
                }
                else if (addressTobe.ToLower() == MemberUploadAddress.PcpAddress.ToString().ToLower())
                {
                    model.IsPCPZipInvalid = true;
                }
                else if (addressTobe.ToLower() == MemberUploadAddress.PcpMailingAddress.ToString().ToLower())
                {
                    model.IsPCPMailingZipInvalid = true;
                }
                if (newZipId > 0)
                {
                    if (model.NewInsertedZipIds.IsNullOrEmpty())
                        model.NewInsertedZipIds = newZipId.ToString();
                    else
                        model.NewInsertedZipIds += "," + newZipId.ToString();
                }
                if (newCityId > 0)
                {
                    if (model.NewInsertedCityIds.IsNullOrEmpty())
                        model.NewInsertedCityIds = newCityId.ToString();
                    else
                        model.NewInsertedCityIds += "," + newCityId.ToString();
                }

            }
            return addressToSave;
        }

    }
}
