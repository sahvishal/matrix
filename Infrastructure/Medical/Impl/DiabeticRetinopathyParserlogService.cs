using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using System;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class DiabeticRetinopathyParserlogService : IDiabeticRetinopathyParserlogService
    {
        private readonly IDiabeticRetinopathyParserlogFactory _diabeticRetinopathyParserlogFactory;
        private readonly IDiabeticRetinopathyParserlogRepository _diabeticRetinopathyParserlogRepository;
        public DiabeticRetinopathyParserlogService(IDiabeticRetinopathyParserlogFactory diabeticRetinopathyParserlogFactory, IDiabeticRetinopathyParserlogRepository diabeticRetinopathyParserlogRepository)
        {
            _diabeticRetinopathyParserlogFactory = diabeticRetinopathyParserlogFactory;
            _diabeticRetinopathyParserlogRepository = diabeticRetinopathyParserlogRepository;
        }

        public ListModelBase<DiabeticRetinopathyParserlogViewModel, DiabeticRetinopathyParserlogListModelFilter> GetDiabeticRetinopathyParserlog(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var diabeticRetinopathyParserFilter = filter as DiabeticRetinopathyParserlogListModelFilter;

            if (diabeticRetinopathyParserFilter == null)
            {
                diabeticRetinopathyParserFilter = new DiabeticRetinopathyParserlogListModelFilter
                {
                    DateFrom = DateTime.Today.AddDays(-7),
                    DateTo = DateTime.Today
                };
            }

            var diabeticRetinopathyParserlogList = _diabeticRetinopathyParserlogRepository.GetDiabeticRetinopathyParserlogs(pageNumber, pageSize, diabeticRetinopathyParserFilter, out totalRecords);
            return _diabeticRetinopathyParserlogFactory.GetDiabeticRetinopathyParserlog(diabeticRetinopathyParserlogList);
        }
    }
}
