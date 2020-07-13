using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class MemberUploadLogRepository : PersistenceRepository, IMemberUploadLogRepository
    {
        public IEnumerable<MemberUploadLog> GetByCorporateUploadLogId(long corporateUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from mul in linqMetaData.MemberUploadLog
                    where mul.CorporateUploadId == corporateUploadId
                    select mul).ToArray();


                return Mapper.Map<IEnumerable<MemberUploadLogEntity>,IEnumerable<MemberUploadLog>>(entities);
            }
        }

        public void Save(MemberUploadLog domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<MemberUploadLog, MemberUploadLogEntity>(domain);

                adapter.SaveEntity(entity, false);
            }
        }
    }
}