using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class ExportableReportsRepository : PersistenceRepository, IExportableReportsRepository
    {
        public ExportableReports GetById(long exportableReportsId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from er in linqMetaData.ExportableReports where er.Id == exportableReportsId select er).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<ExportableReports>(exportableReportsId);

                return Mapper.Map<ExportableReportsEntity, ExportableReports>(entity);
            }
        }


    }
}
