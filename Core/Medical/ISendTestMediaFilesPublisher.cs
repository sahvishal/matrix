
namespace Falcon.App.Core.Medical
{
    public interface ISendTestMediaFilesPublisher
    {
        void PublishSendTestMediaFiles(long eventId, long customerId);
    }
}
