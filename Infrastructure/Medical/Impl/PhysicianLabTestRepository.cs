using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PhysicianLabTestRepository : PersistenceRepository, IPhysicianLabTestRepository
    {
        private readonly IMapper<PhysicianLabTest, PhysicianLabTestEntity> _licenseMapper;
        public PhysicianLabTestRepository(IMapper<PhysicianLabTest, PhysicianLabTestEntity> licenseMapper)
        {
            _licenseMapper = licenseMapper;
        }

        public IEnumerable<PhysicianLabTest> GetPhysicicanLabTestByStateId(long stateId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var entities = (from plt in linqMetaData.PhysicianLabTest where plt.StateId == stateId select plt).ToArray();

                return _licenseMapper.MapMultiple(entities);
            }
        }

        public IEnumerable<PhysicianLabTest> GetPhysicicanLabTestByStateIds(IEnumerable<long> stateIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var entities = (from plt in linqMetaData.PhysicianLabTest where stateIds.Contains(plt.StateId) select plt).ToArray();

                return _licenseMapper.MapMultiple(entities);
            }
        }
    }
}
