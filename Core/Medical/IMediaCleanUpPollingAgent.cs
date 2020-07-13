namespace Falcon.App.Core.Medical
{
    public interface IMediaCleanUpPollingAgent
    {
        void ArchivethePreviousFiles();
        void CleanUpCdContentFolder();
        void CleanUpPastCdContentFolder();
        void PollForCleanUp();
        void ExecuteCleanUp(bool executeFortnightCheck);
    }
}
