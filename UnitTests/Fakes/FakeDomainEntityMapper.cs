using Falcon.App.Infrastructure.Mappers;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeDomainEntityMapper : DomainEntityMapper<FakeDomainObject,FakeEntity>
    {
        protected override void MapDomainFields(FakeEntity entity, FakeDomainObject domainObjectToMapTo) { }
        protected override void MapEntityFields(FakeDomainObject domainObject, FakeEntity entityToMapTo) { }
    }
}