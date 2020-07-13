using System.Web.Services;
using Falcon.App.Core.Geo;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AddressController : WebService
    {
        private readonly IAddressRepository _addressRepository = new AddressRepository();

        [WebMethod (EnableSession = true)]
        public bool UpdateAddressLatitudeAndLongitude(long addressId, string latitude, string longitude, long verificationOrganizationRoleUserId, bool isManuallyVerified, bool useLatLogForMapping)
        {
            return _addressRepository.UpdateAddressLatitudeAndLongitude(addressId, latitude, longitude, verificationOrganizationRoleUserId, useLatLogForMapping);
        }
        [WebMethod (EnableSession = true)]
        public bool UpdateGoogleMapVerificatioStatus(long addressId, bool isManuallyVerified, long verificationOrganizationRoleUserId)
        {
            return _addressRepository.UpdateGoogleMapVerificatioStatus(addressId, isManuallyVerified, verificationOrganizationRoleUserId);
        }
    }
}
