using System;
using System.Linq;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Infrastructure.CallCenter.Repositories; 
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Controls;
using System.Collections.Generic;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UcCallCenterMetricsDetail : BaseUserControl
    {
        protected enum DisplayType
        {
            Booking,
            //SpouseBooking,
            Closing,
            Asr
        }

        protected DisplayType CurrentDisplayType
        {
            get
            {
                if (ViewState["CurrentDisplayType"] != null)
                    return (DisplayType)ViewState["CurrentDisplayType"];
                return (DisplayType)Enum.Parse(typeof(DisplayType), DisplayTypeList.SelectedItem.Value);
            }
            set { ViewState["CurrentDisplayType"] = value; }
        }

        protected String PageHeader
        {
            get
            {
                return string.Format("{0} For {1}",
                                     CurrentDisplayType == DisplayType.Booking
                                         ? "Booking Details"
                                         : CurrentDisplayType == DisplayType.Closing
                                               ? "Closing Detail"
                                               : "Average Sales", CallCenterRepDropDown.SelectedItem.Text);
            }
            set { ViewState["CurrentDisplayType"] = value; }
        }

        protected long CallCenterRepId
        {
            get { return Convert.ToInt32(CallCenterRepDropDown.SelectedItem.Value); }
        }

        protected DateTime StartDate
        {
            get
            {
                return !string.IsNullOrWhiteSpace(DateFromTextBox.Text) ? Convert.ToDateTime(DateFromTextBox.Text) : DateTime.Now;
            }
        }

        protected DateTime EndDate
        {
            get
            {
                return !string.IsNullOrWhiteSpace(DateToTextBox.Text) ? Convert.ToDateTime(DateToTextBox.Text).AddDays(1) : DateTime.Now.AddDays(1);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].ToLower() == DisplayType.Booking.ToString().ToLower())
                        CurrentDisplayType = DisplayType.Booking;
                    //else if (Request.QueryString["Type"].ToLower() == DisplayType.SpouseBooking.ToString().ToLower())
                    //    CurrentDisplayType = DisplayType.SpouseBooking;
                    else if (Request.QueryString["Type"].ToLower() == DisplayType.Closing.ToString().ToLower())
                    {
                        CurrentDisplayType = DisplayType.Closing;
                        SalesLabel.InnerText = "Total Closing Sales:";
                        AverageSalesLabel.InnerText = "Average Closing Sales:";
                    }
                    else if (Request.QueryString["Type"].ToLower() == DisplayType.Asr.ToString().ToLower())
                        CurrentDisplayType = DisplayType.Asr;

                    LoadCallCenterRepDropDown();
                    LoadDisplayType();
                    
                    DisplayTypeList.Items.FindByText(CurrentDisplayType.ToString()).Selected=true;
                    CallCenterRepDropDown.Items.FindByValue(Request.QueryString["Rep"]).Selected = true;
                    DateFromTextBox.Text = Convert.ToDateTime(Request.QueryString["From"]).ToString("MM/dd/yyyy");
                    DateToTextBox.Text = Convert.ToDateTime(Request.QueryString["To"]).ToString("MM/dd/yyyy");
                }
                else
                {
                    LoadCallCenterRepDropDown();
                    LoadDisplayType();
                    
                }

                GetCallCenterRepMetricDetails();
                GetCallCenterRepMetricSummary();    
            }
        }

        private void LoadCallCenterRepDropDown()
        {
            var listIdNamePair = new CallCenterRepRepository().GetCallCenterRepIdNamePair();
            CallCenterRepDropDown.DataSource = listIdNamePair.OrderBy(nm => nm.SecondValue);
            CallCenterRepDropDown.DataTextField = "SecondValue";
            CallCenterRepDropDown.DataValueField = "FirstValue";
            CallCenterRepDropDown.DataBind();
        }

        private void LoadDisplayType()
        {
            DisplayTypeList.Items.AddRange((from DisplayType displayType in Enum.GetValues(typeof(DisplayType))
                                      select new ListItem(displayType.ToString(), ((int)displayType).ToString())).ToArray());

            //foreach (ListItem item in from DisplayType displayType in Enum.GetValues(typeof (DisplayType))
            //                          select new ListItem(displayType.ToString(), ((int)displayType).ToString()))
            //{
            //    DisplayTypeList.Items.Add(item);
            //}
        }

        private void GetCallCenterRepMetricDetails()
        {
            int pageIndex = MetricsDetailPagerTop.PageIndex;
            int pageSize = MetricsDetailPagerTop.PageSize;
            int totalCount = 0;

            ICallCenterRepMetricService callCenterRepMetricService = new CallCenterRepMetricService(CallCenterRepId,
                                                                                                    StartDate, EndDate);
            List<CallCenterRepMetricDetailViewData> repMetricDetailsViewData = null;

            switch (CurrentDisplayType)
            {
                case DisplayType.Booking:
                    repMetricDetailsViewData = callCenterRepMetricService.GetBookingCallCenterRepMetricDetailsViewData(CallCenterRepId, StartDate, EndDate,
                                                                                    pageIndex, pageSize, out totalCount);
                    break;
                //case DisplayType.SpouseBooking:
                //    {
                //        var repSpouseMetricDetailsViewData =
                //            callCenterRepMetricService.GetSpouseBookingCallCenterRepMetricDetailsViewData(
                //                CallCenterRepId, StartDate, EndDate);
                //        repMetricDetailsViewData = new List<CallCenterRepMetricDetailViewData>();
                //        foreach (var spouseMetricDetailsViewData in repSpouseMetricDetailsViewData)
                //        {

                //            repMetricDetailsViewData.Add(spouseMetricDetailsViewData.OwnerDetail);
                //            repMetricDetailsViewData.AddRange(spouseMetricDetailsViewData.SpouseDetails);
                //        }
                //        MetricsDetailsGridView.RowDataBound += MetricsDetailsGridView_RowDataBound;
                //    }
                //    break;
                case DisplayType.Closing:
                    repMetricDetailsViewData = callCenterRepMetricService.GetClosingCallCenterRepMetricDetailsViewData(CallCenterRepId, StartDate, EndDate,
                                                                                    pageIndex, pageSize, out totalCount);
                    break;
                case DisplayType.Asr:
                    repMetricDetailsViewData = callCenterRepMetricService.GetAsrCallCenterRepMetricDetailsViewData(CallCenterRepId, StartDate, EndDate,
                                                                                pageIndex, pageSize, out totalCount);
                    break;
            }
            var filter = new {DisplayType = CurrentDisplayType.GetDescription(),  CallCenterRepId, StartDate, EndDate };
            LogFilterListPairAudit(filter, repMetricDetailsViewData);
            MetricsDetailPagerTop.ItemCount = totalCount;
            MetricsDetailsGridView.DataSource = repMetricDetailsViewData;
            MetricsDetailsGridView.DataBind();
        }

        protected void MetricsDetailsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        var callCenterRepMetricDetailViewData = e.Row.DataItem as CallCenterRepMetricDetailViewData;
                        var addressLiteral = e.Row.FindControl("AddressLiteral") as Literal;
                        if (callCenterRepMetricDetailViewData != null && addressLiteral != null)
                        {
                            addressLiteral.Visible = true;
                            if (callCenterRepMetricDetailViewData.CustomerAddress != null)
                                addressLiteral.Text +=
                                    CommonCode.AddressMultiLine(
                                        callCenterRepMetricDetailViewData.CustomerAddress.StreetAddressLine1,
                                        callCenterRepMetricDetailViewData.CustomerAddress.StreetAddressLine2,
                                        callCenterRepMetricDetailViewData.CustomerAddress.City,
                                        callCenterRepMetricDetailViewData.CustomerAddress.State,
                                        callCenterRepMetricDetailViewData.CustomerAddress.ZipCode.Zip);
                        }
                    }
                    break;
            }
        }

        private void GetCallCenterRepMetricSummary()
        {
            ICallCenterRepMetricDetailRepository callCenterRepMetricDetailRepository =
                new CallCenterRepMetricDetailRepository(CallCenterRepId, StartDate, EndDate);

            CallCenterRepStatisticsViewData callCenterRepStatisticsViewData = null;

            switch (CurrentDisplayType)
            {
                case DisplayType.Booking:
                    callCenterRepStatisticsViewData = callCenterRepMetricDetailRepository.GetBookedEventCustomerStatisticsForCallCenterRep(
                        CallCenterRepId, StartDate, EndDate);
                    break;
                //case DisplayType.SpouseBooking:
                //    {
                //        ICallCenterRepMetricService callCenterRepMetricService = new CallCenterRepMetricService(CallCenterRepId,
                //                                                                                    StartDate, EndDate);
                //        callCenterRepStatisticsViewData = callCenterRepMetricService.GetSpouseBookingStatistics
                //            (
                //            CallCenterRepId, StartDate, EndDate);
                //    }

                //    break;
                case DisplayType.Closing:
                    callCenterRepStatisticsViewData = callCenterRepMetricDetailRepository.GetClosedEventCustomerStatisticsForCallCenterRep(
                         CallCenterRepId, StartDate, EndDate);
                    break;
                case DisplayType.Asr:
                    callCenterRepStatisticsViewData = callCenterRepMetricDetailRepository.GetBookedEventCustomerStatisticsForCallCenterRep(
                        CallCenterRepId, StartDate, EndDate);
                    break;
            }

            if (callCenterRepStatisticsViewData == null) return;

            TotalAmountSpan.InnerText = callCenterRepStatisticsViewData.TotalAmount.ToString("C");
            TotalAttendedSpan.InnerText = callCenterRepStatisticsViewData.TotalAttendedCustomers.ToString();
            TotalCancelledSpan.InnerText = callCenterRepStatisticsViewData.TotalCancelledCustomers.ToString();
            TotalCustomerSpan.InnerText = callCenterRepStatisticsViewData.TotalCustomers.ToString();
            TotalNoShowSpan.InnerText = callCenterRepStatisticsViewData.TotalNoShowCustomers.ToString();
            AverageAmountSpan.InnerText = callCenterRepStatisticsViewData.AverageAmount.ToString("C");

            //if (CurrentDisplayType == DisplayType.SpouseBooking && callCenterRepStatisticsViewData is CallCenterRepSpouseStatisticsViewData)
            //{
            //    var callCenterRepSpouseStatisticsViewData =
            //        callCenterRepStatisticsViewData as CallCenterRepSpouseStatisticsViewData;
            //    TotalAttendedSpan.InnerHtml += "/(" + callCenterRepSpouseStatisticsViewData.TotalAttendedCustomerPairs +
            //                                   ")";
            //    TotalCancelledSpan.InnerHtml += "/(" + callCenterRepSpouseStatisticsViewData.TotalCancelledCustomerPairs +
            //                                    ")";
            //    TotalCustomerSpan.InnerHtml += "/(" + callCenterRepSpouseStatisticsViewData.TotalCustomerPairs +
            //                                   ")";
            //    TotalNoShowSpan.InnerHtml += "/(" + callCenterRepSpouseStatisticsViewData.TotalNoShowCustomerPairs +
            //                                 ")";
            //    AverageAmountSpan.InnerHtml = callCenterRepSpouseStatisticsViewData.AverageAmount.ToString("C");
            //}
        }

        protected void SearchRecordButton_Click(object sender, EventArgs e)
        {
            MetricsDetailPagerTop.PageIndex = 0;
            GetCallCenterRepMetricDetails();
            GetCallCenterRepMetricSummary();
        }

        protected void MetricsDetailPagerTop_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            GetCallCenterRepMetricDetails();
        }

    }
}