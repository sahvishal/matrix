using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IGiftCertificateRepository : IUniqueItemRepository<GiftCertificate>
    {
        GiftCertificate GetByClaimCode(string claimCode);
        bool IsClaimCodeValidForCertificate(string claimCode, int giftCertificateId);
        void ActivateGiftCertificate(long id);
        decimal GetAmountUsedonGiftCertificate(long id);
    }
}