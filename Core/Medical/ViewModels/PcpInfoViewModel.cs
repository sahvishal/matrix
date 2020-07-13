using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpInfoViewModel
    {
        public string Name { get; set; }

        public AddressViewModel Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }
    }
}