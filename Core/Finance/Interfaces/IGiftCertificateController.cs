using System.Collections.Generic;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IGiftCertificateController
    {
        List<GiftCertificateOfferingsViewData> GetCompleteGiftCertificateOfferingViewData();
        List<GiftCertificateOfferingsViewData> GetNewGiftCertificateOfferingViewData();
        object GetGiftCertificateByClaimCode(string claimCode);
        GiftCertificate GetGiftCertificate(long giftCertificateId);
        GiftCertificate GetGiftCertificateById(long giftCertificateId);
    }
}
