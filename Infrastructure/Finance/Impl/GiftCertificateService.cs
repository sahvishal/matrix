using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class GiftCertificateService : IGiftCertificateService
    {
        private readonly IGiftCertificateRepository _giftCertificateRepository;
        public GiftCertificateService(IGiftCertificateRepository giftCertificateRepository)
        {
            _giftCertificateRepository = giftCertificateRepository;
        }

        public GiftCertificate GetGiftCertificatebyClaimCode(string claimCode)
        {
            var giftCertificate = _giftCertificateRepository.GetByClaimCode(claimCode);
            if (giftCertificate != null)
            {
                giftCertificate.Amount = _giftCertificateRepository.GetAmountUsedonGiftCertificate(giftCertificate.Id);

                if (giftCertificate.BalanceAmount > 0 && ((giftCertificate.ExpirationDate.HasValue && giftCertificate.ExpirationDate >= DateTime.Today) || !giftCertificate.ExpirationDate.HasValue))
                    return giftCertificate;

                if (giftCertificate.ExpirationDate.HasValue && giftCertificate.ExpirationDate < DateTime.Today)
                    throw new ObjectDeactivatedException<GiftCertificate>();

                throw new InvalidOperationException("There is no amount left in the given gift certificate, please use another mode to pay.");
            }
            throw new InvalidOperationException("The given claim code is not valid.");
        }

    }
}