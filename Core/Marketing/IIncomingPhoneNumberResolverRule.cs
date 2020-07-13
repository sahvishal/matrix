using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Marketing
{
    public interface IIncomingPhoneNumberResolverRule
    {
        string GetPhoneNumber(MarketingMaterialType printMaterial, AdvocateType advocateType);
    }
}