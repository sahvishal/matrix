namespace Falcon.App.Core.Application
{
    public interface IMovieMakerPollingAgent
    {
        void PollForMpegMaking();
        void PollForMoviefromAviMaking();
    }
}
