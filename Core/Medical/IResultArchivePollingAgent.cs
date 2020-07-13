namespace Falcon.App.Core.Medical
{
    public interface IResultArchivePollingAgent
    {
        void PollforUploadCompleteResultArchives();
    }
}