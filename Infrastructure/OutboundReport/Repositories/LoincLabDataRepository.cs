using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class LoincLabDataRepository : PersistenceRepository, ILoincLabDataRepository
    {
        public void Save(LoincLabData domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = Mapper.Map<LoincLabData, LoincLabDataEntity>(domain);


                if (!adapter.SaveEntity(entity, false))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<LoincLabData> GetByMemberId(string memberid)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ln in linqMetaData.LoincLabData
                              where ln.MemberId.Trim().ToLower() == memberid.Trim().ToLower()
                              select ln);

                return Mapper.Map<IEnumerable<LoincLabDataEntity>, IEnumerable<LoincLabData>>(entity).ToArray();
            }
        }

        public IEnumerable<LoincLabData> GetByGmpi(string gmpi)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ln in linqMetaData.LoincLabData
                              where ln.Gmpi.Trim().ToLower() == gmpi.Trim().ToLower()
                              select ln);

                return Mapper.Map<IEnumerable<LoincLabDataEntity>, IEnumerable<LoincLabData>>(entity).ToArray();
            }
        }
    }
}