using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Geo
{
    public interface IAddressService
    {

        Address GetSanitizeAddress(Address addressToSanitize);
        Address GetSanitizeAddress(string zipCode);

        Address SaveAfterSanitizing(Address addressToSave, bool checkZipData = false);
        Address SaveTemporaryAfterSanitizing(Address temporaryAddress);

        AddressViewModel GetAddress(long addressId);
        AddressEditModel GetAddressEditModel(long addressId);

        Address GetAddressSanitizingInvalidZip(Address addressToSave, CorporateCustomerEditModel model, string addressTobe);
    }
}