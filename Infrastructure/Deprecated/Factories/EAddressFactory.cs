using Falcon.Entity.Other;

namespace Falcon.App.Infrastructure.Deprecated.Factories
{
    public class EAddressFactory
    {
        public EAddress CreateEAddress(string address1, string address2, int countryId, int stateId,
            int cityId, int zipId, string phoneNumber)
        {
            return CreateEAddress(address1, address2, countryId, stateId, cityId, zipId, phoneNumber, 0,
                string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public EAddress CreateEAddress(string address1, string address2, int countryId, int stateId, int cityId, int zipId, string phoneNumber,
            int addressId, string city, string state, string zipCode, string country)
        {
            return new EAddress
            {
                Address1 = address1,
                Address2 = address2,
                CountryID = countryId,
                StateID = stateId,
                CityID = cityId,
                ZipID = zipId,
                PhoneNumber = phoneNumber,
                AddressID = addressId,
                City = city,
                State = state,
                Zip = zipCode,
                Country = country
            };
        }
    }
}