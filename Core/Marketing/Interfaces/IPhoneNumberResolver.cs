using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface IPhoneNumberResolver
    {
        PhoneNumber GetIncomingPhoneNumber();
        PhoneNumber GetIncomingPhoneNumber(MarketingMaterialType marketingMaterialType);

    }
}