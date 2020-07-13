using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class StateMapperTester
    {
        private readonly IMapper<State, StateEntity> _stateMapper = new StateMapper();

        [Test]
        public void MapSetsIdToStateEntityId()
        {
            const long expectedId = 24;
            var stateEntity = new StateEntity(expectedId);

            State state = _stateMapper.Map(stateEntity);

            Assert.AreEqual(expectedId, state.Id, "State ID was not mapped correctly.");
        }

        [Test]
        public void MapSetsNameToStateEntityName()
        {
            const string expectedName = "Iowa";
            var stateEntity = new StateEntity {Name = expectedName};

            State state = _stateMapper.Map(stateEntity);

            Assert.AreEqual(expectedName, state.Name, "State Name was not mapped correctly.");
        }
    }
}