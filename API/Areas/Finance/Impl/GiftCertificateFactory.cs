using API.Areas.Finance.Models;
using Falcon.App.Core.Finance.Domain;

namespace API.Areas.Finance.Impl
{
    public class GiftCertificateFactory : IGiftCertificateFactory
    {
        public GiftCertificateModel GetModel(GiftCertificate domain)
        {
            return new GiftCertificateModel
            {
                Amount = domain.Amount,
                ClaimCode = domain.ClaimCode,
                ExpirationDate = domain.ExpirationDate,
                Id = domain.Id,
                IsSuccess = true,
                StatusCode = 200,
                Message = domain.Description,
                Price = domain.Price
            };
        }
    }
}