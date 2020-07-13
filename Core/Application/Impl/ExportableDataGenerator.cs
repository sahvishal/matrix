using System.Linq;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Application.Impl
{
    public delegate ListModelBase<T, N> ViewModelData<T, N>(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        where T : ViewModelBase
        where N : ModelFilterBase;

    public class ExportableDataGenerator<T, N>
        where T : ViewModelBase
        where N : ModelFilterBase
    {
        public ViewModelData<T, N> Method { get; set; }
        public double Status { get; set; }

        private const int PageSize = 100;
        private int _totalRecords;
        private int _pageNumber;
        private ListModelBase<T, N> _model;
        private readonly ILogger _logger;
        public ExportableDataGenerator(ViewModelData<T, N> method, ILogger logger = null)
        {
            _totalRecords = 0;
            _pageNumber = 1;
            Method = method;
            _logger = logger;
        }

        public ListModelBase<T, N> GetData(N filter)
        {
            var model = Method(_pageNumber, PageSize, filter, out _totalRecords);

            if (_totalRecords < 1) return model;

            Status = (_pageNumber * PageSize) / _totalRecords;

            if (_logger != null)
            {
                _logger.Info("Total Number of Records: " + _totalRecords + " Current Page:  " + _pageNumber);
            }

            if (Status > 100) Status = 100;

            if (_model == null)
            {
                _model = model;
            }
            else
            {
                var collection = _model.Collection.ToList();
                collection.AddRange(model.Collection);
                _model.Collection = collection;
            }

            if ((_pageNumber * PageSize) < _totalRecords)
            {
                _pageNumber++;
                GetData(filter);
            }
            _model.Filter = filter;
            return _model;
        }
    }
}