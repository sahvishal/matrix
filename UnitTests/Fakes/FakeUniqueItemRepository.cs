using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeUniqueItemRepository : UniqueItemRepository<FakeDomainObject,FakeEntity>
    {
        public FakeUniqueItemRepository(IPersistenceLayer persistenceLayer, 
            IMapper<FakeDomainObject, FakeEntity> itemFactory,
            RepositoryStrategySet<FakeDomainObject> repositoryStrategySet)
            : base(persistenceLayer, itemFactory, repositoryStrategySet)
        {}

        protected override EntityField2 EntityIdField
        {
            get { return FakeEntityFields.FakeField; }
        }
    }
}