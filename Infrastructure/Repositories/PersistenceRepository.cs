using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;

namespace Falcon.App.Infrastructure.Repositories
{
    public class PersistenceRepository
    {
        private readonly IPersistenceLayer _persistenceLayer;
        protected IPersistenceLayer PersistenceLayer
        {
            get { return _persistenceLayer; }
        }

        protected PersistenceRepository(IPersistenceLayer persistenceLayer)
        {
            _persistenceLayer = persistenceLayer;
        }

        protected PersistenceRepository()
            : this(new SqlPersistenceLayer())
        {
        }
    }
}