using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PhoneNumberResolutionRule : DomainObjectBase
    {
        public PhoneNumber IncomingPhoneNumber { get; set; }
    }
}