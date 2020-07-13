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
    public class HcpcsCodeRepository : PersistenceRepository, IHcpcsCodeRepository
    {
        public List<HcpcsCode> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.HcpcsCode
                              where h.IsActive
                              select h).ToArray();


                return (List<HcpcsCode>)Mapper.Map<IEnumerable<HcpcsCodeEntity>, IEnumerable<HcpcsCode>>(entity);
            }
        }


        public HcpcsCode SaveHcpcsCode(HcpcsCode domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<HcpcsCode, HcpcsCodeEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save HcpcsCode");

                return AutoMapper.Mapper.Map<HcpcsCodeEntity, HcpcsCode>(entity);
            }
        }


    }
}
