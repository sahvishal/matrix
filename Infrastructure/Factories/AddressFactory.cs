using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.TypedViewClasses;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class AddressFactory : IAddressFactory
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper<ZipCode, ZipEntity> _mapper;

        public AddressFactory(ICountryRepository countryRepository, IZipCodeRepository zipCodeRepository, IMapper<ZipCode, ZipEntity> mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public AddressFactory()
            : this(new CountryRepository(), new ZipCodeRepository(), new ZipCodeMapper())
        { }


        public List<Address> CreateAddresses(AddressViewTypedView addressViewTypedView)
        {
            if (addressViewTypedView == null)
            {
                throw new ArgumentNullException("addressViewTypedView", "The collection of addresses is required.");
            }
            var addresses = new List<Address>();
            foreach (AddressViewRow addressViewRow in addressViewTypedView)
            {
                Address address = CreateAddress(addressViewRow);
                addresses.Add(address);
            }
            return addresses;
        }

        public Address CreateAddress(AddressViewRow addressViewRow)
        {
            if (addressViewRow == null)
            {
                throw new ArgumentNullException("addressViewRow");
            }

            return new Address(addressViewRow.AddressId)
                       {
                           StreetAddressLine1 = addressViewRow.Address1,
                           StreetAddressLine2 = addressViewRow.Address2,
                           City = addressViewRow.City,
                           CityId = addressViewRow.CityId,
                           Country = addressViewRow.Country,
                           CountryId = addressViewRow.CountryId,
                           State = addressViewRow.State,
                           StateCode = addressViewRow.StateCode,
                           StateId = addressViewRow.StateId,
                           ZipCode =
                               addressViewRow.ZipId != 0 && !string.IsNullOrEmpty(addressViewRow.ZipCode)
                                   ? new ZipCode(addressViewRow.ZipId)
                                   {
                                       Zip = addressViewRow.ZipCode,
                                       Latitude = !string.IsNullOrEmpty(addressViewRow.ZipLatitiude) ? Convert.ToSingle(addressViewRow.ZipLatitiude.Trim()) : 0,
                                       Longitude = !string.IsNullOrEmpty(addressViewRow.ZipLongitude) ? Convert.ToSingle(addressViewRow.ZipLongitude.Trim()) : 0
                                   } : null,
                           Latitude =
                               !string.IsNullOrEmpty(addressViewRow.Latitude) ? addressViewRow.Latitude : string.Empty,
                           Longitude =
                               !string.IsNullOrEmpty(addressViewRow.Longitude) ? addressViewRow.Longitude : string.Empty,
                           LatLogUseForAddressMaping = addressViewRow.UseLatLogForMapping,
                           VerificationOrgRoleUserId = addressViewRow.VerificationOrgRoleUserId < 1 ? null : (long?)addressViewRow.VerificationOrgRoleUserId
                           
                       };
        }

        public AddressEntity CreateAddressEntity(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }
            return new AddressEntity(address.Id)
                       {
                           Address1 = address.StreetAddressLine1,
                           Address2 = address.StreetAddressLine2,
                           CityId = address.CityId,
                           DateCreated = DateTime.Now,
                           DateModified = DateTime.Now,
                           IsActive = true,
                           StateId = address.StateId,
                           ZipId = address.ZipCode.Id,
                           CountryId = address.CountryId > 0 ? address.CountryId : _countryRepository.GetCountryId(address.Country),
                           IsNew = address.Id <= 0
                       };
        }


        public Address CreateAddressDomain(AddressEntity addressEntity)
        {
            if (addressEntity == null)
            {
                throw new ArgumentNullException("addressEntity");
            }

            return new Address(addressEntity.AddressId)
                       {
                           StreetAddressLine1 = addressEntity.Address1,
                           StreetAddressLine2 = addressEntity.Address2,
                           City = addressEntity.City != null ? addressEntity.City.Name : string.Empty,
                           CityId = addressEntity.CityId,
                           Country = addressEntity.Country != null ? addressEntity.Country.Name : string.Empty,
                           CountryId = addressEntity.CountryId,
                           State = addressEntity.State != null ? addressEntity.State.Name : string.Empty,
                           StateId = addressEntity.StateId,
                           ZipCode = addressEntity.Zip != null ? _mapper.Map(addressEntity.Zip) : null
                       };
        }

    }
}