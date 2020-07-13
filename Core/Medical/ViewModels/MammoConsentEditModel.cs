using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MammoConsentEditModel : ViewModelBase
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }

        public Name FullName { get; set; }
        public AddressViewModel Address { get; set; }
        public PhoneNumber HomeNumber { get; set; }

        public PrimaryCarePhysician Pcp { get; set; }

        public string RefrrerUrl { get; set; }

        public string PrintUrl { get; set; }

        public bool Print { get; set; }

        public MammoConsentEditModel()
        {
            Pcp = new PrimaryCarePhysician();
        }
    }
}
