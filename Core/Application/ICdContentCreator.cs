using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Application
{
    public interface ICdContentCreator
    {
        bool GenerateCdContent(long eventId, long customerId, CorporateAccount corporateAccount);
        bool ZipCdContentsPerEvent(long eventId);
        bool ZipCdContentsPerEventPerCustomer(long eventId, long customerId);
    }
}
