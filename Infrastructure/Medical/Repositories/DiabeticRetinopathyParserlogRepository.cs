using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;


namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class DiabeticRetinopathyParserlogRepository : PersistenceRepository, IDiabeticRetinopathyParserlogRepository
    {
        public void Save(DiabeticRetinopathyParserlog domainObject)
        {
            var entity = Mapper.Map<DiabeticRetinopathyParserlog, DiabeticRetinopathyParserlogEntity>(domainObject);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<DiabeticRetinopathyParserlog> GetDiabeticRetinopathyParserlogs(int pageNumber, int pageSize, DiabeticRetinopathyParserlogListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var fromDate = filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : DateTime.Today.AddDays(-7);
                var todate = filter.DateTo.HasValue ? filter.DateTo.Value.AddDays(1).Date : DateTime.Today;
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from q in linqMetaData.DiabeticRetinopathyParserlog where q.DateCreated >= fromDate && q.DateCreated < todate select q);                
                
                query = (from q in query orderby q.DateCreated descending select q);

                totalRecords = query.Count();

                var entities = query.TakePage(pageNumber, pageSize).ToList();

                return Mapper.Map<IEnumerable<DiabeticRetinopathyParserlogEntity>, IEnumerable<DiabeticRetinopathyParserlog>>(entities);
            }
        }
    }
}
