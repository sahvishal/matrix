using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;

namespace API.Areas.Users
{
    public interface IPatientAddressFactory
    {
        Address GetAddress(AddressViewModel address, Address inpersistence);
    }
}
