using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Application
{
    public interface IRepositoryStrategySetFactory<T>
    {
        RepositoryStrategySet<T> CreateRepositoryStrategySet();
    }
}