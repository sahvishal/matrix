using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class OutboundUploadRepository : PersistenceRepository, IOutboundUploadRepository
    {
        public OutboundUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ou in linqMetaData.OutboundUpload where ou.Id == id select ou).SingleOrDefault();

                return entity == null ? null : Mapper.Map<OutboundUploadEntity, OutboundUpload>(entity);
            }
        }

        public IEnumerable<OutboundUpload> GetAllUploadedFilesByType(long typeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ou in linqMetaData.OutboundUpload where ou.StatusId == (long)OutboundUploadStatus.Pending && ou.TypeId == typeId select ou).ToArray();

                return Mapper.Map<IEnumerable<OutboundUploadEntity>, IEnumerable<OutboundUpload>>(entities);
            }
        }

        public OutboundUpload Save(OutboundUpload domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<OutboundUpload, OutboundUploadEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<OutboundUploadEntity, OutboundUpload>(entity);
            }
        }
    }
}
