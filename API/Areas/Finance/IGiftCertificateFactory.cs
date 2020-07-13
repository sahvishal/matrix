using API.Areas.Finance.Models;
using Falcon.App.Core.Finance.Domain;

namespace API.Areas.Finance
{
    public interface IGiftCertificateFactory
    {
        GiftCertificateModel GetModel(GiftCertificate domain);
    }
}