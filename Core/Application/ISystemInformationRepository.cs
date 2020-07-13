namespace Falcon.App.Core.Application
{
    public interface ISystemInformationRepository
    {
        string GetSystemVersionNumber();

        string GetBuildNumber();
    }
}