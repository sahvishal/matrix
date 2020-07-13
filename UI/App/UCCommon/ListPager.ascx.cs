using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Lib;

namespace Falcon.App.UI.Controls
{
    public delegate void PageIndexChangedEventHandler(object sender, PageIndexChangedEventArgs e);

    public partial class ListPager : System.Web.UI.UserControl
    {        

        private int CurrentPageSize
        {
            get
            {                
                if (ViewState["CurrentPageSize"] != null && !string.IsNullOrEmpty(ViewState["CurrentPageSize"].ToString()))
                {
                    return Convert.ToInt32(ViewState["CurrentPageSize"].ToString());
                }
                return -1;
            }
            set
            {
                ViewState["CurrentPageSize"] = value;
                ResultsPerPage.SelectedValue = value.ToString();
            }
        }

        private int CurrentPageIndex
        {
            get
            {
                if (ViewState["PageIndexControl"] != null && !string.IsNullOrEmpty(ViewState["PageIndexControl"].ToString()))
                {
                    return Convert.ToInt32(ViewState["PageIndexControl"].ToString());
                }
                return 0;
            }
            set
            {
                ViewState["PageIndexControl"] = value;
            }
        }

        private int VirtualItemCount
        {
            get
            {
                if (ViewState["VirtualItemCount"] != null && !string.IsNullOrEmpty(ViewState["VirtualItemCount"].ToString()))
                {
                    return Convert.ToInt32(ViewState["VirtualItemCount"].ToString());
                }
                return 0;
            }
            set
            {
                ViewState["VirtualItemCount"] = value;
            }
        }

        private int TotalPagesCount
        {
            get
            {
                if (ViewState["TotalPagesCount"] != null && !string.IsNullOrEmpty(ViewState["TotalPagesCount"].ToString()))
                {
                    return Convert.ToInt32(ViewState["TotalPagesCount"].ToString());
                }
                return 0;
            }
            set
            {
                ViewState["TotalPagesCount"] = value;
            }
        }

        private int JumpToPage
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentPage.Text))
                {
                    int pageNumber;
                    if (Int32.TryParse(CurrentPage.Text, out pageNumber))
                    {
                        return pageNumber;
                    }
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HelperFunctions.TieButton(CurrentPage, GoToPageButton);
            Visible = true;
            if (!IsPostBack)
            {
                CurrentPage.Text = (CurrentPageIndex + 1).ToString();
                CurrentPageSize = CurrentPageSize == -1 ? Convert.ToInt32(ResultsPerPage.SelectedValue) : CurrentPageSize;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SetPagingLinks();
            CheckMinimumVisibility();
            base.OnPreRender(e);
        }

        protected void GoToPageButton_Click(object sender, EventArgs e)
        {
            int newPageIndex = JumpToPage - 1;

            if (newPageIndex < 0 || newPageIndex > TotalPagesCount - 1)
            {
                newPageIndex = newPageIndex < 0 ? 0 : TotalPagesCount - 1;
            }

            SetPageIndex(newPageIndex);
            var indexChangedArgs = new PageIndexChangedEventArgs(newPageIndex, PageSize);
            this.OnPageIndexChanged(indexChangedArgs);
        }

        protected void NextPage_Click(object sender, EventArgs e)
        {
            int newPageIndex = CurrentPageIndex;
            newPageIndex++;

            SetPageIndex(newPageIndex);
            var indexChangedArgs = new PageIndexChangedEventArgs(newPageIndex, PageSize);
            this.OnPageIndexChanged(indexChangedArgs);
        }

        protected void PreviousPage_Click(object sender, EventArgs e)
        {
            int newPageIndex = CurrentPageIndex;
            newPageIndex--;

            SetPageIndex(newPageIndex);
            var indexChangedArgs = new PageIndexChangedEventArgs(newPageIndex, PageSize);
            this.OnPageIndexChanged(indexChangedArgs);
        }

        private PageIndexChangedEventHandler _onPageIndexChanged;
        public event PageIndexChangedEventHandler PageIndexChanged
        {
            add
            {
                _onPageIndexChanged += value;
            }
            remove
            {
                _onPageIndexChanged -= value;
            }
        }

        protected virtual void OnPageIndexChanged(PageIndexChangedEventArgs e)
        {
            if (_onPageIndexChanged != null)
            {
                _onPageIndexChanged(this, e);
            }
        }

        private void SetPageIndex(int pageIndex)
        {
            CurrentPageIndex = pageIndex;
            CurrentPage.Text = (CurrentPageIndex + 1).ToString();
        }

        private void SetPagingLinks()
        {
            if ((VirtualItemCount % CurrentPageSize) == 0)
                TotalPagesCount = (VirtualItemCount / CurrentPageSize);
            else
                TotalPagesCount = ((VirtualItemCount / CurrentPageSize) + 1);

            PreviousPage.Enabled = CurrentPageIndex == 0 ? false : true;
            NextPage.Enabled = CurrentPageIndex < TotalPagesCount - 1 ? true : false;

            TotalPages.Text = TotalPagesCount.ToString();
            CurrentPage.Text = (CurrentPageIndex + 1).ToString();
        }

        private void CheckMinimumVisibility()
        {
            List<ListItem> pageSizeListItems = ResultsPerPage.Items.Cast<ListItem>().ToList();
            List<int> pageSizeList = pageSizeListItems.ConvertAll<int>(listItem => Int32.Parse(listItem.Value));
            int minimumPageSize = pageSizeList.Min();

            Visible = VirtualItemCount > minimumPageSize;
        }


        protected void ResultsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int resultsPerPage = 1;
            if (ResultsPerPage.SelectedIndex > -1)
            {
                resultsPerPage = Convert.ToInt32(ResultsPerPage.SelectedValue);
                CurrentPageSize = resultsPerPage;
            }
            SetPageIndex(0);

            var indexChangedArgs = new PageIndexChangedEventArgs(CurrentPageIndex, resultsPerPage);
            this.OnPageIndexChanged(indexChangedArgs);
        }

        public int PageSize
        {
            get
            {
                return CurrentPageSize == -1 ? Convert.ToInt32(ResultsPerPage.SelectedValue) : CurrentPageSize;
            }
            set
            {
                CurrentPageSize = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return CurrentPageIndex;
            }
            set
            {
                CurrentPageIndex = value;
            }
        }

        public int ItemCount
        {
            get
            {
                return VirtualItemCount;
            }
            set
            {
                VirtualItemCount = value;
            }
        }

        public int MinPageSize
        {
            get
            {
                return Convert.ToInt32(ResultsPerPage.Items[0].Value);
            }
        }
    }

    public class PageIndexChangedEventArgs : EventArgs
    {

        public PageIndexChangedEventArgs(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            _pageSize = pageSize;

        }

        public int PageIndex { set; get; }

        public int PageSize
        {
            set
            {
                _pageSize = value;
            }
            get
            {
                return _pageSize;
            }
        }


        private int _pageSize = -1;
    }
}