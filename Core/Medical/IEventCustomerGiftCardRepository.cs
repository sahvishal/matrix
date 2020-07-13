using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerGiftCardRepository
    {
        void Save(EventCustomerGiftCard domain);

        int GetLatestVersion(long eventCustomerId);

        EventCustomerGiftCard GetByEventCustomerId(long eventCustomerId);
        
        bool IsSaved(long eventCustomerId);
    }
}
