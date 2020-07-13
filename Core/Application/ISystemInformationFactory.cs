namespace Falcon.App.Core.Application
{
    public interface ISystemInformationFactory
    {
        string GetFormattedVersionString(string rawVersionString);
    }
}