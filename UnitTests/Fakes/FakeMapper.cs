using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Impl;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeMapper : Mapper<FakeDomainObject, FakeEntity>
    {
        public override FakeDomainObject Map(FakeEntity fakeEntity)
        {
            return new FakeDomainObject { Id = fakeEntity.Id };
        }

        public override FakeEntity Map(FakeDomainObject domainObject)
        {
            return new FakeEntity { Id = domainObject.Id };
        }
    }
}