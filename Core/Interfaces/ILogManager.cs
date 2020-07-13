namespace Falcon.App.Core.Interfaces
{
    public interface ILogManager
    {
        ILogger GetLogger<T>();
        ILogger GetLogger(string name);
    }
}