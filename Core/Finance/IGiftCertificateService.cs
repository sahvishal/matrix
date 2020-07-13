using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IGiftCertificateService
    {
        GiftCertificate GetGiftCertificatebyClaimCode(string claimCode);
    }
}