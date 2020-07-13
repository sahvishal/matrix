using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeRepository : Repository<FakeDomainObject, FakeEntity>
    {
        public FakeRepository(IPersistenceLayer persistenceLayer, 
            IMapper<FakeDomainObject, FakeEntity> mapper) 
            : base(persistenceLayer, mapper, new RepositoryStrategySet<FakeDomainObject>())
        {}
    }
}