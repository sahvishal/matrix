using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface IAddressRepository
    {
        Address GetAddress(long addressId);
        List<Address> GetAddresses(List<long> addressIds);
        Address Save(Address address);
        Address SaveTemporary(Address address);
        void UnDeleteAddress(long addressId);
        //bool ValidateAddress(string stateName, string cityName, string zipCode);
        bool ValidateAddress(Address addressToValidate);
        bool UpdateAddressLatitudeAndLongitude(long addressId, string latitude, string longitude, long verificationOrganizationRoleUserId, bool useLatLogForMapping);
        bool UpdateGoogleMapVerificatioStatus(long addressId, bool? isManuallyVerified, long verificationOrganizationRoleUserId);
        bool UpdateNeedVerfication(long addressId, bool needVerfication);

        bool UpdateNeedVerficationbyAddressIds(List<long> addressIds);

    }
}