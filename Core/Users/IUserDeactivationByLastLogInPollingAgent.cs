namespace Falcon.App.Core.Users
{
    public interface IUserDeactivationByLastLogInPollingAgent
    {
        void PollForDeactivation();
    }
}
