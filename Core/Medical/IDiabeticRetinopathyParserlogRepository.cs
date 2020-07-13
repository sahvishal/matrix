using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IDiabeticRetinopathyParserlogRepository
    {
        void Save(DiabeticRetinopathyParserlog domainObject);
        IEnumerable<DiabeticRetinopathyParserlog> GetDiabeticRetinopathyParserlogs(int pageNumber, int pageSize, DiabeticRetinopathyParserlogListModelFilter filter, out int totalRecords);
    }
}
