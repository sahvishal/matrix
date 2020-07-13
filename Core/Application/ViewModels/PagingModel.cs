using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Application.ViewModels
{
    public class PagingModel
    {
        public int PageSize { get; private set; }
        public int NumberOfItems { get; private set; }
        public Func<int, string> PageUrl { get; private set; }

        private int _currentPage;
        public int CurrentPage
        {
            get
            {
                return Math.Max(1, Math.Min(_currentPage, PageCount));
            }
            set { _currentPage = value; }
        }

        public int PageCount { get { return NumberOfItems / PageSize + (NumberOfItems % PageSize != 0 ? 1 : 0); } }

        public int PageSpan { get; private set; }

        public PagingModel(int currentPage, int pageSize, int numberOfItems, Func<int, string> pageUrl, int pageSpan = 3)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            NumberOfItems = numberOfItems;
            PageUrl = pageUrl;
            PageSpan = pageSpan;
        }

        public IEnumerable<int> GetPages()
        {
            return Enumerable.Range(1, PageCount).Where(IsPageIncluded);
        }

        public bool IsPageIncluded(int pageNumber)
        {
            return (pageNumber <= PageSpan)
                || (pageNumber > PageCount - PageSpan)
                || (Math.Abs(pageNumber - CurrentPage) < PageSpan);
        }

    }
}