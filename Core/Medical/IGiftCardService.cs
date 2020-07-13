using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IGiftCardService
    {
        bool Save(GiftCertificateSignatureModel model, long orgRoleUserId);

        GiftCertificateViewModel GetModel(long eventId, long customerId);
    }
}
