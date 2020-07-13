
namespace Falcon.App.Core.Medical
{
    public interface ISendTestMediaFilesService
    {
        void SubscriberForSendTestMediaFiles(long eventId, long customerId);
    }
}
