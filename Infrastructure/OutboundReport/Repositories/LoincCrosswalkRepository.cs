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
    public class LoincCrosswalkRepository : PersistenceRepository, ILoincCrosswalkRepository
    {
        public void Save(LoincCrosswalk domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = Mapper.Map<LoincCrosswalk, LoincCrosswalkEntity>(domain);


                if (!adapter.SaveEntity(entity, false))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<LoincCrosswalk> GetByLoincNumber(string memberId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var loincNumbers = (from ln in linqMetaData.LoincLabData
                    where ln.MemberId.Trim().ToLower() == memberId.Trim().ToLower()
                    select ln.Loinc);

                var entity = (from ln in linqMetaData.LoincCrosswalk
                              where loincNumbers.Contains(ln.LoincNumber)
                              select ln);

                return Mapper.Map<IEnumerable<LoincCrosswalkEntity>, IEnumerable<LoincCrosswalk>>(entity).ToArray();
            }
        }
    }
}
