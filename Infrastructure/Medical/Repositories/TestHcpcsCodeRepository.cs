using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class TestHcpcsCodeRepository : PersistenceRepository, ITestHcpcsCodeRepository
    {
        public List<TestHcpcsCode> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.TestHcpcsCode 
                              where h.IsActive
                              select h).ToArray();

                
                return (List<TestHcpcsCode>) Mapper.Map<IEnumerable<TestHcpcsCodeEntity>, IEnumerable<TestHcpcsCode>>(entity);
            }
        }
        
        public TestHcpcsCode SaveTestHcpcsCode(TestHcpcsCode domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<TestHcpcsCode, TestHcpcsCodeEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save TestHcpcsCode");

                return Mapper.Map<TestHcpcsCodeEntity, TestHcpcsCode>(entity);
            }
        }

         
    }
}
