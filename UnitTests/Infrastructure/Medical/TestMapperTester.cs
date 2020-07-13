using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Medical
{
    [TestFixture]
    public class TestMapperTester
    {
        private readonly IMapper<Test, TestEntity> _mapper = new TestMapper();

        [Test]
        public void CreateObjectFromEntityMapsEntityPropertiesToObjectProperties()
        {
            const long expectedId = 3;
            const string expectedName = "Name";
            const decimal expectedPrice = 3.14m;
            var entity = new TestEntity(expectedId) { Price = expectedPrice, Name = expectedName };
            
            Test test = _mapper.Map(entity);

            Assert.AreEqual(expectedId, test.Id);
            Assert.AreEqual(expectedName, test.Name);
        }
    }
}