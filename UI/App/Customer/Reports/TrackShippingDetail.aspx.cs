using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Lib;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Controls;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.UI.UtilityReports
{
    public partial class TrackShippingDetail : BasePage
    {
        private const ShipmentStatus STATUS = ShipmentStatus.Processing;
        private readonly IPodRepository _podRepository = new PodRepository();
        private readonly IShippingDetailRepository _shippingDetailRepository = new ShippingDetailRepository();
        private readonly IShippingOptionRepository _shippingOptionRepository = new ShippingOptionRepository();

        public OrganizationRoleUserModel CurrentOrgRole
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (!IsPostBack)
            {
                BindDropdowns();
                BindDataForFilters();
            }
            var franchisorFranchisorMaster = Page.Master as Franchisor_FranchisorMaster;
            if (franchisorFranchisorMaster != null)
            {
                franchisorFranchisorMaster.HideLeftContainer = true;
                franchisorFranchisorMaster.hideucsearch();
                franchisorFranchisorMaster.settitle("Track Shipping Detail");
                franchisorFranchisorMaster.SetBreadCrumbRoot =
                    "<a href=\"/App/Franchisor/Dashboard.aspx\">Dashboard</a>";
            }
        }

        protected void ShippingDetailsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        var eventCustomerShippingDetailViewData = e.Row.DataItem as EventCustomerShippingDetailViewData;
                        if (eventCustomerShippingDetailViewData != null)
                        {
                            var anchorResultPdf = e.Row.FindControl("ResultPdfAnchor") as HtmlAnchor;

                            if (anchorResultPdf != null)
                            {
                                if (eventCustomerShippingDetailViewData.IsResultPdfGenerated)
                                {
                                    var mediaRepository = IoC.Resolve<IMediaRepository>();
                                    var productRepository = IoC.Resolve<IElectronicProductRepository>();
                                    var isPremiumVersionPurchased = productRepository.IsProductPurchased(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, Product.PremiumVersionPdf);


                                    var key = new DigitalDeliveryCryptographyService().GetKey(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, EPDFType.ResultPdf);
                                    if (isPremiumVersionPurchased)
                                    {
                                        key = new DigitalDeliveryCryptographyService().GetKey(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, EPDFType.ResultPdfWithImages);
                                    }
                                    else
                                    {
                                        var resultPdfLocation = mediaRepository.GetPremiumVersionResultPdfLocation(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, false).PhysicalPath;
                                        if (eventCustomerShippingDetailViewData.ShippingOptionName.ToLower().Contains("pcp"))
                                        {
                                            var pcpResultPdfPath = resultPdfLocation + mediaRepository.GetPdfFileNameForPcpResultReport();
                                            if (File.Exists(pcpResultPdfPath))
                                            {
                                                key = new DigitalDeliveryCryptographyService().GetKey(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, EPDFType.PcpResultReport);
                                            }
                                        }
                                        else
                                        {
                                            var customerResultPdfPath = resultPdfLocation + mediaRepository.GetPdfFileNameForResultReport();
                                            if (File.Exists(customerResultPdfPath))
                                            {
                                                key = new DigitalDeliveryCryptographyService().GetKey(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, EPDFType.ResultPdf);
                                            }
                                            else
                                            {
                                                var pcpResultPdfPath = resultPdfLocation + mediaRepository.GetPdfFileNameForPcpResultReport();
                                                if (File.Exists(pcpResultPdfPath))
                                                {
                                                    key = new DigitalDeliveryCryptographyService().GetKey(eventCustomerShippingDetailViewData.EventId, eventCustomerShippingDetailViewData.CustomerId, EPDFType.PcpResultReport);
                                                }
                                            }
                                        }
                                    }

                                    anchorResultPdf.HRef = " javascript:ShowPdf('/DigitalDelivery.aspx?key=" + key + "');";
                                }
                                else
                                {
                                    anchorResultPdf.HRef = "javascript:alert('Not generated yet.');";
                                }
                            }

                            var statusItemLiteral = e.Row.FindControl("StatusItemLiteral") as Literal;
                            if (statusItemLiteral != null)
                            {
                                statusItemLiteral.Text = eventCustomerShippingDetailViewData.Status.ToString();
                            }
                            var shippingStatus =
                                e.Row.FindControl("ShipmentStatusDropDown") as DropDownList;
                            if (shippingStatus != null)
                            {
                                BindStatusDropDown(((int)eventCustomerShippingDetailViewData.Status).ToString(), shippingStatus);
                            }
                            var nameLiteral = e.Row.FindControl("NameItemLiteral") as Literal;
                            if (nameLiteral != null)
                            {
                                var customerDetail = "<a href='/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + eventCustomerShippingDetailViewData.CustomerId + "'>" + eventCustomerShippingDetailViewData.CustomerId + "</a>";
                                if (CurrentOrgRole.CheckRole((long) Roles.OperationManager))
                                {
                                    customerDetail = eventCustomerShippingDetailViewData.CustomerId.ToString();
                                }
                                
                                nameLiteral.Text = eventCustomerShippingDetailViewData.CustomerName + " [" +
                                                   customerDetail + "]" + "<br />" +
                                                   CommonCode.AddressMultiLine(
                                                       eventCustomerShippingDetailViewData.CustomerStreetAddressLine1,
                                                       eventCustomerShippingDetailViewData.CustomerStreetAddressLine2,
                                                       eventCustomerShippingDetailViewData.CustomerCity,
                                                       eventCustomerShippingDetailViewData.CustomerState,
                                                       eventCustomerShippingDetailViewData.CustomerZip)
                                                       + "<br />" + eventCustomerShippingDetailViewData.CustomerEmail;
                            }
                            var packageNameItemLiteral = e.Row.FindControl("PackageNameItemLiteral") as Literal;

                            if (packageNameItemLiteral != null)
                            {
                                packageNameItemLiteral.Text = eventCustomerShippingDetailViewData.PackageName;
                                packageNameItemLiteral.Text = string.IsNullOrEmpty(packageNameItemLiteral.Text)
                                                                  ? eventCustomerShippingDetailViewData.AdditionalTest
                                                                  : packageNameItemLiteral.Text +
                                                                    (string.IsNullOrEmpty(eventCustomerShippingDetailViewData.AdditionalTest)
                                                                         ? string.Empty
                                                                         : ", " +
                                                                           eventCustomerShippingDetailViewData.
                                                                               AdditionalTest);
                                if (!string.IsNullOrEmpty(eventCustomerShippingDetailViewData.ProductName))
                                    packageNameItemLiteral.Text = packageNameItemLiteral.Text + "<br /> + " + eventCustomerShippingDetailViewData.ProductName;
                            }

                            var unpiadDiv = e.Row.FindControl("UnpiadDiv") as HtmlGenericControl;
                            if (unpiadDiv != null)
                            {
                                unpiadDiv.Style.Add(HtmlTextWriterStyle.Display, eventCustomerShippingDetailViewData.IsPaid ? "none" : "block");
                            }
                        }
                    }
                    break;
            }
        }

        protected void ShippingDetailsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var updateButton = (e.CommandSource as Button);
            if (updateButton != null)
            {
                var currentGridRow = (updateButton.NamingContainer as GridViewRow);
                if (currentGridRow != null)
                {
                    switch (e.CommandName)
                    {
                        case "UpdateShippingStatus":
                            long shippingDetailId;
                            if (e.CommandArgument != null && !string.IsNullOrEmpty(e.CommandArgument.ToString()) &&
                                Int64.TryParse(e.CommandArgument.ToString(), out shippingDetailId))
                            {
                                ShippingDetail shippingDetail = UpdateShippingDetail(currentGridRow, shippingDetailId,
                                                                                     false);
                                if (shippingDetail != null)
                                {
                                    shippingDetail = _shippingDetailRepository.Save(shippingDetail);
                                    if (shippingDetail.Id > 0)
                                    {
                                        MessageBox.ShowSuccessMessage("Shipping Detail updated successfully.");
                                        BindDataForFilters();
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }

        protected void GetButton_Click(object sender, EventArgs e)
        {
            ShippingDetailPagerTop.PageIndex = 0;
            BindDataForFilters();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            bool allDataSaved = true;
            var selectedRows = GetSelectedRows();
            foreach (var row in selectedRows)
            {
                if (row != null)
                {
                    var shippingDetailIdLiteral = row.FindControl("ShippingDetailIdLiteral") as Literal;
                    if (shippingDetailIdLiteral != null && !string.IsNullOrEmpty(shippingDetailIdLiteral.Text))
                    {
                        long shippingDetailId;
                        if (Int64.TryParse(shippingDetailIdLiteral.Text, out shippingDetailId))
                        {
                            ShippingDetail shippingDetail = UpdateShippingDetail(row, shippingDetailId, true);
                            if (shippingDetail != null)
                            {
                                _shippingDetailRepository.Save(shippingDetail);
                            }
                            else
                            {
                                allDataSaved = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (allDataSaved)
            {
                MessageBox.ShowSuccessMessage("Shipping Detail(s) updated successfully.");
                BindDataForFilters();
            }
        }

        protected void ShippingDetailPager_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            BindDataForFilters();
        }

        private void BindDataForFilters()
        {
            var pageIndex = ShippingDetailPagerTop.PageIndex;
            var pageSize = ShippingDetailPagerTop.PageSize;

            DateTime? eventStartDate = null;
            DateTime? eventEndDate = null;
            if (!string.IsNullOrEmpty(EventDateFrom.Text.Trim()))
            {
                DateTime date;
                if (!DateTime.TryParse(EventDateFrom.Text.Trim(), out date))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid event start date.");
                    return;
                }
                eventStartDate = date.GetStartOfDay();
            }
            if (!string.IsNullOrEmpty(EventDateTo.Text.Trim()))
            {
                DateTime date;
                if (!DateTime.TryParse(EventDateTo.Text.Trim(), out date))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid event end date.");
                    return;
                }
                eventEndDate = date.GetStartOfDay();
            }

            long eventId = 0;
            if (!string.IsNullOrEmpty(EventId.Text.Trim()))
            {
                long id = 0;
                if (!long.TryParse(EventId.Text.Trim(), out id))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid event id.");
                    return;
                }
                eventId = id;
            }

            var filter = new EventCustomerShippingDetailViewDataFilter
                             {
                                 ShippmentStatus =
                                     Convert.ToInt64(
                                         ShipmentStatusDropDown.SelectedValue),
                                 ShippingOptions = ShippingOptionCheckboxList.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => Convert.ToInt64(i.Value)),
                                 DateFrom = eventStartDate,
                                 DateTo = eventEndDate,
                                 EventId = eventId,
                                 IsExclusivelyRequested = !RequestedAllInputRadio.Checked ? (bool?)(RequestedExclInputRadio.Checked || !RequestedNotExclInputRadio.Checked) : null,
                                 PodId = Convert.ToInt64(PodsDropDown.SelectedValue),
                                 IsResultReady = ResultsReadyCheckBox.Checked,
                                 HasEmail = Convert.ToInt32(HasEmailDropDown.SelectedValue)
                             };

            GetFilteredData(pageIndex + 1, pageSize, filter);
        }

        private void GetFilteredData(int pageIndex, int pageSize, EventCustomerShippingDetailViewDataFilter filter)
        {
            try
            {
                var shippingDetailService = IoC.Resolve<IShippingDetailService>();
                var eventCustomerShippingDetailViewData = shippingDetailService.GetEventCustomerShippingDetailViewData(pageIndex, pageSize, filter);
                BindGridView(eventCustomerShippingDetailViewData);
                LogFilterListPairAudit(filter, eventCustomerShippingDetailViewData);
            }
            catch (Exception ex)
            {
                MessageBox.ShowErrorMessage(ex.Message);
                MessageBox.ShowErrorMessage(
                    "Oops some error occured while processing, please try again after some time.");
                ShippingDetailsGrid.DataSource = null;
                ShippingDetailsGrid.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }

        private void BindGridView(IEnumerable<EventCustomerShippingDetailViewData> eventCustomerShippingDetailViewDatas)
        {
            if (eventCustomerShippingDetailViewDatas != null && eventCustomerShippingDetailViewDatas.Count() > 0)
            {
                var totalCount = eventCustomerShippingDetailViewDatas.First().TotalCount;
                ShippingDetailPagerTop.ItemCount = totalCount;
                ShippingDetailsGrid.DataSource = totalCount > 0 ? eventCustomerShippingDetailViewDatas : null;
                ShippingDetailsGrid.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, totalCount > 0 ? "none" : "block");
            }
            else
            {
                ShippingDetailPagerTop.ItemCount = 0;
                ShippingDetailsGrid.DataSource = null;
                ShippingDetailsGrid.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }

        private void BindDropdowns()
        {
            BindStatusDropDown("0", ShipmentStatusDropDown);
            ShipmentStatusDropDown.Items.Insert(0, new ListItem("--All--", "0"));

            BindStatusDropDown("1", ShipmentStatusUpdateDropDown);

            var shippingOptions = _shippingOptionRepository.GetAllShippingOptionsForTracking();
            ShippingOptionCheckboxList.DataSource = shippingOptions;
            ShippingOptionCheckboxList.DataTextField = "Name";
            ShippingOptionCheckboxList.DataValueField = "Id";
            ShippingOptionCheckboxList.DataBind();
            //ShippingOptionsDropDown.Items.Insert(0, new ListItem("--All--", "0"));

            var pods = _podRepository.GetAllPods();
            PodsDropDown.DataSource = pods;
            PodsDropDown.DataTextField = "Name";
            PodsDropDown.DataValueField = "Id";
            PodsDropDown.DataBind();
            PodsDropDown.Items.Insert(0, new ListItem("--All--", "0"));
        }

        private void BindStatusDropDown(string status, ListControl shippingStatus)
        {
            var statusPairs = STATUS.GetNameValuePairs();
            statusPairs.RemoveAll(sp => sp.FirstValue == (int)ShipmentStatus.Cancelled);
            shippingStatus.DataSource = statusPairs;
            shippingStatus.DataTextField = "SecondValue";
            shippingStatus.DataValueField = "FirstValue";
            shippingStatus.DataBind();
            if (shippingStatus.Items.FindByValue(status) != null)
                shippingStatus.Items.FindByValue(status).Selected = true;
        }

        private IEnumerable<GridViewRow> GetSelectedRows()
        {
            return ShippingDetailsGrid.Rows.Cast<GridViewRow>().Where(IsCheckBoxSelected);
        }

        private bool IsCheckBoxSelected(Control row)
        {
            var chekBoxSelect = row.FindControl("chkSelect") as CheckBox;
            return (chekBoxSelect != null && chekBoxSelect.Checked);
        }

        private ShippingDetail UpdateShippingDetail(Control currentGridRow, long shippingDetailId, bool isBulkUpdate)
        {
            NullArgumentChecker.CheckIfNull(currentGridRow, "currentGridRow");

            if (shippingDetailId > 0 && currentGridRow is GridViewRow)
            {
                currentGridRow = currentGridRow as GridViewRow;

                var eventDate = currentGridRow.FindControl("EventDateItemLiteral") as Literal;

                if (eventDate != null)
                {
                    if (Convert.ToDateTime(eventDate.Text) > DateTime.Now)
                    {
                        MessageBox.ShowErrorMessage("You can not update shipping status of future event.");
                        return null;
                    }
                }

                var shippingDetail = _shippingDetailRepository.GetById(shippingDetailId);

                var shippingStatus =
                    currentGridRow.FindControl("ShipmentStatusDropDown") as DropDownList;

                if (shippingStatus != null)
                {
                    shippingDetail.Status = (ShipmentStatus)Enum.Parse(typeof(ShipmentStatus), (isBulkUpdate ? ShipmentStatusUpdateDropDown.SelectedValue : shippingStatus.SelectedValue));
                }

                if (shippingDetail.Status == ShipmentStatus.Shipped)
                {
                    shippingDetail.ShippedByOrgRoleUserId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                }
                

                shippingDetail.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                shippingDetail.DataRecorderMetaData.DateModified = DateTime.Now;
                return shippingDetail;
            }
            return null;
        }
    }
}
