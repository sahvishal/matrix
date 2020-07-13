namespace Falcon.App.Core.Application
{
    public interface IStrategy<T>
    {
        void ApplyStrategy(T domainObjectToCheck);
    }
}