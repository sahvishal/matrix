using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class ExportableReportsQueueRepository : PersistenceRepository, IExportableReportsQueueRepository
    {
        public ExportableReportsQueue GetById(long exportableReportsQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from erq in linqMetaData.ExportableReportsQueue where erq.Id == exportableReportsQueueId select erq).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<ExportableReportsQueue>(exportableReportsQueueId);

                return AutoMapper.Mapper.Map<ExportableReportsQueueEntity, ExportableReportsQueue>(entity);
            }
        }

        public ExportableReportsQueue Save(ExportableReportsQueue domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<ExportableReportsQueue, ExportableReportsQueueEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Exportable Reports Queue");

                return AutoMapper.Mapper.Map<ExportableReportsQueueEntity, ExportableReportsQueue>(entity);
            }
        }

        public ExportableReportsQueue GetExportableReportsQueueForService()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from erq in linqMetaData.ExportableReportsQueue where erq.StatusId == (long)ExportableReportStatus.Pending select erq).OrderBy(erq => erq.RequestedOn).FirstOrDefault();

                if (entity == null)
                    return null;

                return AutoMapper.Mapper.Map<ExportableReportsQueueEntity, ExportableReportsQueue>(entity);
            }
        }

        public IEnumerable<ExportableReportsQueue> GetExportableReportsQueuesForDelete(int noOfDays)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var dateCheck = DateTime.Now.AddDays(-1 * noOfDays).Date;

                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from erq in linqMetaData.ExportableReportsQueue
                                where (erq.StatusId == (long)ExportableReportStatus.Completed || erq.StatusId == (long)ExportableReportStatus.Failed)
                              && erq.RequestedOn < dateCheck
                                orderby erq.RequestedOn
                                select erq).Take(100).ToArray();
                if (entities.Any())
                {
                    return AutoMapper.Mapper.Map<IEnumerable<ExportableReportsQueueEntity>, IEnumerable<ExportableReportsQueue>>(entities);
                }
                return null;
            }
        }

        public void Delete(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntity(new ExportableReportsQueueEntity(id));
            }
        }

        public IEnumerable<ExportableReportsQueue> GetExportableReportsQueue(int pageNumber, int pageSize, ExportableReportsQueueFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from erq in linqMetaData.ExportableReportsQueue
                             where erq.RequestedBy == filter.RequestedBy
                             select erq);

                if (filter.ReportId > 0)
                    query = query.Where(q => q.ReportId == filter.ReportId);

                if (filter.FromDate.HasValue)
                    query = query.Where(q => q.RequestedOn >= filter.FromDate.Value);

                if (filter.ToDate.HasValue)
                    query = query.Where(q => q.RequestedOn < filter.ToDate.Value.AddDays(1));

                query = (from q in query orderby q.RequestedOn descending select q);

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).ToArray();

                if (entities.Any())
                {
                    return AutoMapper.Mapper.Map<IEnumerable<ExportableReportsQueueEntity>, IEnumerable<ExportableReportsQueue>>(entities);
                }
                return null;
            }
        }
    }
}
