using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Controls;
using Falcon.App.Core.Extensions;
using System.Collections.Generic;
using System.Web.UI;

namespace Falcon.App.UI.App.Franchisee.SalesRep
{
    public partial class HSCReport : System.Web.UI.Page
    {
        private readonly IProspectCustomerRepository _prospectCustomer = new ProspectCustomerRepository();
        private const ProspectCustomerConversionStatus _prospectCustomerConverStatus = ProspectCustomerConversionStatus.NotConverted;

        protected long SalesRepId
        {
            get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId; }
         }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.settitle("SalesRep");
            obj.SetBreadCrumbRoot = "<a href=\"#\">Workshop Prospect Status Report</a>";
            obj.hideucsearch();
            if (!Page.IsPostBack)
            {
                BindDropDowns();
                BindDataForWithFiltes();
            }

        }

        protected void hscReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        var currentRow = e.Row.DataItem as ProspectCustomerViewData;
                        string callNotes = string.Empty;
                        if (currentRow != null)
                        {
                            var prospectStatus = e.Row.FindControl("_prospectStatus") as HtmlContainerControl;
                            var callDetails = e.Row.FindControl("_callDetails") as HtmlAnchor;
                            var callCount = e.Row.FindControl("_callCount") as HtmlContainerControl;

                            if (callCount != null)
                            {
                                if (currentRow.ProspectCallDetails.Count > 0)
                                    callCount.InnerText = currentRow.ProspectCallDetails.Count.ToString();
                                else callCount.Style.Add(HtmlTextWriterStyle.Display, "none");
                            }

                            // prospect Status
                            if (prospectStatus!=null)
                            {
                                if (currentRow.ProspectStatus == ProspectCustomerConversionStatus.NotConverted)
                                    prospectStatus.InnerText = "Not Converted";
                                else if (currentRow.ProspectStatus == ProspectCustomerConversionStatus.Converted || currentRow.ProspectStatus == ProspectCustomerConversionStatus.Declined)
                                {
                                    prospectStatus.InnerText = currentRow.ProspectStatus.ToString();
                                }
                                else prospectStatus.InnerText = "Not Converted";
                            }
                            // event details anchor
                            var eventDetailsAnchor = e.Row.FindControl("_eventDetailsAnchor") as HtmlAnchor;
                            if (eventDetailsAnchor != null && currentRow.EventId > 0)
                            {
                                eventDetailsAnchor.HRef = "/App/Common/EventDetails.aspx?EventID=" + currentRow.EventId;
                            }

                            // call log
                            if (callDetails != null)
                            {
                                if (currentRow.ProspectCallDetails != null && currentRow.ProspectCallDetails.Count() > 0)
                                {
                                    callNotes =
                                        "Call Details | <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"divgrid_cl\" style=\"width:280px\">";
                                    // Add heading row
                                    callNotes += "<tr class=\"row1\" style=\"font-size:11px\"><th>Date</th><th>Status</th><th>Notes</th></tr>";

                                    for (int i=0; i< currentRow.ProspectCallDetails.Count; i++)
                                    {
                                        callNotes = callNotes + "<tr class=\"smalltxt12\">";
                                        
                                        if (currentRow.ProspectCallDetails[i].CallDate.HasValue)
                                        callNotes = callNotes + "<td>" + currentRow.ProspectCallDetails[i].CallDate.Value.ToString("MM/dd/yyyy") + "<br />" + currentRow.ProspectCallDetails[i].CallDate.Value.ToString("hh:mm tt") + "</td>";
                                        else callNotes = callNotes + "<td></td>";

                                        if (currentRow.ProspectCallDetails[i].CallStatus.ToString() == "0")
                                        {
                                            callNotes = callNotes + "<td>" + CallStatus.Initiated.ToString() + "</td>";
                                        }
                                        else
                                        {
                                            if (currentRow.ProspectCallDetails[i].CallStatus == CallStatus.Attended)
                                                callNotes = callNotes + "<td>" + "Talked to Person" + "</td>";
                                            else if (currentRow.ProspectCallDetails[i].CallStatus == CallStatus.NoAnswer)
                                                callNotes = callNotes + "<td>" + "No Answer" + "</td>";
                                            else if (currentRow.ProspectCallDetails[i].CallStatus == CallStatus.VoiceMessage)
                                                callNotes = callNotes + "<td>" + "Voice Message" + "</td>";
                                            else
                                                callNotes = callNotes + "<td>" + currentRow.ProspectCallDetails[i].CallStatus.ToString() + "</td>";
                                        }

                                        if (!string.IsNullOrEmpty(currentRow.ProspectCallDetails[i].CallNotes))
                                        {
                                            callNotes = callNotes + "<td>" + currentRow.ProspectCallDetails[i].CallNotes + "</td>";
                                        }
                                        else
                                        {
                                            callNotes = callNotes + "<td>N/A</td>";
                                        }
                                        callNotes = callNotes + "</tr>";
                                    }
                                    // close table
                                    callNotes = callNotes + "</table>";
                                }
                                else
                                {
                                    callNotes = callNotes + "Call Details |<span class=\"redtxt_default\">Call Log : N/A</span>";
                                }
                                // create tooltip
                                callDetails.Title = callNotes;
                            }

                        }
                    }
                    break;
            }
        }

        private void BindDropDowns()
        {
            // Prospect Customer Conversion Status -> (Search Panel)
            _prospectStatus.Items.Clear();
            _prospectStatus.Items.Add(new ListItem("--All--", "0"));
            _prospectStatus.DataSource = _prospectCustomerConverStatus.GetNameValuePairs();
            _prospectStatus.DataTextField = "SecondValue";
            _prospectStatus.DataValueField = "FirstValue";
            _prospectStatus.DataBind();

            var listItem = _prospectStatus.Items.FindByText(ProspectCustomerConversionStatus.NotConverted.ToString());
            if (listItem != null)
                listItem.Text = "Not Converted";
        }

        protected void pagerTop_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            BindDataForWithFiltes();
        }

        private void BindDataForWithFiltes()
        {
            var pageIndex = _pagerTop.PageIndex;
            var pageSize = _pagerTop.PageSize;

            DateTime? fromDatePassed = null;
            DateTime? toDatePassed = null;

            ProspectCustomerConversionStatus ? prospectCustomerStatus = null;
            string prospectName = string.Empty;
            long eventId = 0;
            string wellnessSeminarName = string.Empty;
            string sourceCode = !string.IsNullOrEmpty(_sourceCodeText.Text) ? _sourceCodeText.Text.Trim() : string.Empty;

            // from due date
            if (!string.IsNullOrEmpty(_startDate.Text.Trim()))
            {
                DateTime prospectDateFrom;
                if (!DateTime.TryParse(_startDate.Text.Trim(), out prospectDateFrom))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid from date.");
                    return;
                }
                else fromDatePassed = prospectDateFrom;
            }
            // to due date
            if (!string.IsNullOrEmpty(_endDate.Text.Trim()))
            {
                DateTime dateTo;
                if (!DateTime.TryParse(_endDate.Text.Trim(), out dateTo))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid end due date.");
                    return;
                }
                toDatePassed = dateTo;
                if (toDatePassed != null) toDatePassed = toDatePassed.Value.AddDays(1);
            }

            // prospect status.
            if (!string.IsNullOrEmpty(_prospectStatus.SelectedValue))
            {
                if (Convert.ToString(_prospectStatus.SelectedValue) != "0")
                {
                    prospectCustomerStatus =
                        (ProspectCustomerConversionStatus)Enum.Parse(typeof(ProspectCustomerConversionStatus), _prospectStatus.SelectedValue);
                }
            }
            // Prospect Name
            prospectName = !string.IsNullOrEmpty(_prospectName.Text) ? _prospectName.Text.Trim() : string.Empty;
            // Event Name

            if(!string.IsNullOrEmpty(_eventIdText.Text))
            {
                if (!long.TryParse(_eventIdText.Text, out eventId))
                    eventId = 0;
            }

            // Welness Seminar Name
            wellnessSeminarName = !string.IsNullOrEmpty(_seminarNameText.Text) ? _seminarNameText.Text.Trim() : string.Empty;

            long totalRecord = 0;
            List<ProspectCustomerViewData> hscProspectCustomerViewData
                = _prospectCustomer.GetProspectCustomersForSalesRep(fromDatePassed, toDatePassed, prospectName, eventId, sourceCode, wellnessSeminarName, prospectCustomerStatus, SalesRepId, pageIndex,
                                                                    pageSize, out totalRecord);

            // Bind grids.
            if (!hscProspectCustomerViewData.IsNullOrEmpty())
            {
                _pagerTop.ItemCount = (int)totalRecord;
                _hscReport.DataSource = hscProspectCustomerViewData;
                _hscReport.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                _pagerTop.ItemCount = 0;
                _hscReport.DataSource = null;
                _hscReport.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "block");
            }

        }

        protected void searchRecord_Click(object sender, EventArgs e)
        {
            BindDataForWithFiltes();
        }

        protected void resetSearch_Click(object sender, EventArgs e)
        {
            _prospectName.Text = string.Empty;
            _startDate.Text = string.Empty;
            _endDate.Text = string.Empty;
            _prospectStatus.SelectedIndex = 0;
            _eventIdText.Text = string.Empty;
            _sourceCodeText.Text = string.Empty;
            _seminarNameText.Text = string.Empty;

            BindDataForWithFiltes();

        } 

    }

    
}
