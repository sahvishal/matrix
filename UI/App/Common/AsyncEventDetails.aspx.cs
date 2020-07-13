using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Lib;
using Falcon.App.Core.Application;
using Falcon.App.UI;
using Falcon.App.UI.App.BasePageClass;

namespace HealthYes.Web.App.Common
{
    public partial class AsyncEventDetails : BasePage
    {

        public long EventId { set; get; }

        long ipagesize = 10;
        long ipageindex = 1;

        long total = 0;
        string strFilterString = string.Empty;
        string strType = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request["type"] != null && Request["type"] != "")
                {
                    strType = Request.QueryString["type"];
                    if (Request.QueryString["eventid"] != null)
                    {
                        EventId = Convert.ToInt64(Request.QueryString["eventid"]);
                    }
                    if (Request.QueryString["pagesize"] != null)
                    {
                        ipagesize = Convert.ToInt32(Request.QueryString["pagesize"]);
                    }
                    if (Request.QueryString["pageindex"] != null)
                    {
                        ipageindex = Convert.ToInt32(Request.QueryString["pageindex"]);
                    }
                    // customers
                    if (Request["type"].Equals("Customers"))
                    {
                        if (Request.QueryString["filterstring"] != null)
                        {
                            strFilterString = Convert.ToString(Request.QueryString["filterstring"]);
                        }
                        ViewState["Cancelled"] = strFilterString == "Cancelled" ? "True" : null;

                        var orderRepository = new OrderRepository();

                        var orders = orderRepository.GetAllOrdersForEvent(EventId);
                        var filteMode = (EventCustomerFilterMode)Enum.Parse(typeof(EventCustomerFilterMode), strFilterString);

                        var eventCustomerService = IoC.Resolve<IEventCustomerService>();
                        var eventCustomerOrderAggregates = eventCustomerService.GetEventCustomerRegistrationViewData(EventId, filteMode)
                                .OrderBy(ecoa => ecoa.AppointmentStartTime).ToList();
                        LogFilterListPairAudit(new { CustomerFilter = filteMode }, eventCustomerOrderAggregates);
                        if (eventCustomerOrderAggregates.Count > 0 && (filteMode != EventCustomerFilterMode.Filled || orders.Count() > 0))
                        {
                            _eventCustomerGrid.DataSource = eventCustomerOrderAggregates;
                            _eventCustomerGrid.DataBind();

                            if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                            {
                                _eventCustomerGrid.Columns[4].Visible = false;
                            }
                            WriteResponse(_eventCustomerGrid);
                        }
                        else
                        {

                            Response.Write("No Record Found");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                string errorMessage = "<div style='float:left; width:746px; border:solid 1px #E7F0F5; padding:10px 0px 10px 0px; display:block;' runat='server'>";
                errorMessage = errorMessage + "<p class='divnoitemtxt_custdbrd'>" + " <b> Some Error occured, data could not be loaded. </b>" + "</p>";
                //ErrorMessage = ErrorMessage + "<p class='divnoitemtxt_custdbrd'>" + ex.Message + "</p></div>";
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Message: " + ex.Message + "Stack Trace: \n" + ex.StackTrace);
                Response.Write(errorMessage);
            }
            finally
            {
                Response.End();
            }

        }

        private OrderDetail _orderDetail;

        private string GetCouponCode()
        {
            string couponCode = "N/A";
            if (_orderDetail != null && _orderDetail.SourceCodeOrderDetail != null)
            {
                ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                var sourceCode = sourceCodeRepository.GetSourceCodeById(_orderDetail.SourceCodeOrderDetail.SourceCodeId);
                if (sourceCode != null)
                {
                    couponCode = sourceCode.CouponCode;
                    string couponValue = "0.00";

                    if (_orderDetail.SourceCodeOrderDetail.Amount != 0m)
                    {
                        couponValue = _orderDetail.SourceCodeOrderDetail.Amount.ToString();
                    }
                    if (Convert.ToSingle(couponValue) < 0.00)
                    {
                        couponValue = string.Empty;
                    }
                    else couponValue = _orderDetail.SourceCodeOrderDetail.Amount.ToString("C2");

                    return couponCode + "(" + couponValue + ")";
                }
            }
            return couponCode;
        }

        private Order GetCurrentOrder(long customerId)
        {
            IOrderRepository orderRepository = new OrderRepository();
            try
            {
                var order = orderRepository.GetOrder(customerId, EventId);
                IOrderController orderController = new OrderController();
                _orderDetail = orderController.GetActiveOrderDetail(order);
                return order;
            }
            catch
            {
                return null;
            }
        }

        protected void _eventCustomerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var eventCustomer = e.Row.DataItem as EventCustomerRegistrationViewData;

                if (eventCustomer != null)
                {
                    // format phone no.
                    CommonCode objCommonCode = new CommonCode();
                    var phoneSpan = e.Row.FindControl("spPhone") as HtmlContainerControl;
                    if (objCommonCode.FormatPhoneNumberGet(eventCustomer.PhoneNumber).Length > 0)
                        phoneSpan.InnerText = "PH:" + objCommonCode.FormatPhoneNumberGet(eventCustomer.PhoneNumber);

                    string customerFullName = !string.IsNullOrEmpty(eventCustomer.MiddleName)
                                                  ? eventCustomer.FirstName + " " + eventCustomer.MiddleName + " " +
                                                    eventCustomer.LastName
                                                  : eventCustomer.FirstName + " " + eventCustomer.LastName;

                    string currentRowIndex = (e.Row.DataItemIndex + 2) < 10
                                                 ? "ctl0" + Convert.ToString(e.Row.DataItemIndex + 2)
                                                 : "ctl" + Convert.ToString(e.Row.DataItemIndex + 2);

                    var appointmentTime = e.Row.FindControl("_appointmentTimeLiteral") as Literal;
                    var statusSpan = e.Row.FindControl("spStatus") as HtmlContainerControl;
                    var checkInFilledSpan = e.Row.FindControl("spfiledcheckin") as HtmlContainerControl;
                    var actionSpan = e.Row.FindControl("spAction") as HtmlContainerControl;

                    if (appointmentTime != null)
                    {
                        var appointmentString = string.Format("{0:hh:mm tt}", eventCustomer.AppointmentStartTime);
                        if (eventCustomer.RoomSlots != null && eventCustomer.RoomSlots.Any())
                        {
                            var roomSlotString = "<hr />";
                            foreach (var roomSlot in eventCustomer.RoomSlots)
                            {
                                roomSlotString += roomSlot.FirstValue + " - " + roomSlot.SecondValue.ToShortTimeString() + "<br />";
                            }

                            appointmentString += roomSlotString;
                        }
                        appointmentTime.Text = appointmentString;
                    }
                    var customerId = eventCustomer.CustomerId;

                    var order = GetCurrentOrder(customerId);

                    var packageNameLiteral = e.Row.FindControl("PackageNameLiteral") as Literal;

                    if (packageNameLiteral != null)
                    {
                        if (!string.IsNullOrEmpty(eventCustomer.PackageName) && !string.IsNullOrEmpty(eventCustomer.AdditinalTest))
                            packageNameLiteral.Text = eventCustomer.PackageName + ", " + eventCustomer.AdditinalTest;
                        else
                        {
                            packageNameLiteral.Text = !string.IsNullOrEmpty(eventCustomer.PackageName) ? eventCustomer.PackageName : eventCustomer.AdditinalTest;
                        }
                    }

                    // TODO: Problem lies in DAL mapped to wrong field.
                    long eventCustomerId = eventCustomer.EventCustomerId;
                    long appiontmentId = eventCustomer.AppointmentId;

                    /* When appointmentslot is not allocated to a customer ********* */
                    if (eventCustomerId == 0)
                    {
                        var customerDetailSpan = e.Row.FindControl("spcustomerdetail") as HtmlContainerControl;
                        // Case added when a slot is blocked then link should be disable

                        string prepareAction = "<span style=\"width:110px; float:left;\">";

                        if (statusSpan != null && eventCustomer.AppointmentSlotStatus == AppointmentSlotStatus.Blocked)
                        {
                            statusSpan.InnerText = "Blocked";
                        }
                        else if (statusSpan != null)
                        {
                            statusSpan.InnerText = "Open";
                            prepareAction += " <a id='" + currentRowIndex +
                                             "_Block' href=\"javascript:OpenPopUp('/App/Common/BlockSlot.aspx?AppointmentID=" +
                                             appiontmentId + "&keepThis=true&TB_iframe=true&width=270&height=200&modal=true')\" class='thickbox'>Block</a> | ";
                        }
                        prepareAction += " <a id='" + currentRowIndex + "_Delete' href=\"javascript:DeleteAppointment('" +
                                         appiontmentId + "');\">Delete</a> ";

                        if (actionSpan != null)
                            actionSpan.InnerHtml = prepareAction;

                        if (customerDetailSpan != null)
                            customerDetailSpan.InnerHtml = eventCustomer.AppointmentBlockReason;

                        if (checkInFilledSpan != null)
                            checkInFilledSpan.InnerText = "N/A";

                        return;
                    }

                    var acceptanceDetailSpan = e.Row.FindControl("spAcctDetail") as HtmlContainerControl;
                    var appointmentDetailsSpan = e.Row.FindControl("spApptDetail") as HtmlContainerControl;

                    if (acceptanceDetailSpan != null)
                        acceptanceDetailSpan.Style[HtmlTextWriterStyle.Display] = "block";

                    if (appointmentDetailsSpan != null)
                        appointmentDetailsSpan.Style[HtmlTextWriterStyle.Display] = "block";


                    var customerDetailAnchor = e.Row.FindControl("aCustomerDetail") as HtmlAnchor;
                    var customerEditAnchor = e.Row.FindControl("CustomerEdit") as HtmlAnchor;

                    if (customerDetailAnchor != null && customerEditAnchor != null)
                    {
                        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                        if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                        {

                            customerEditAnchor.HRef = "~/App/Franchisor/FranchisorEditCustomer.aspx?CustomerID=" +
                                                      eventCustomer.CustomerId + "&Master=EventCustomerList";
                            customerDetailAnchor.HRef = "/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" +
                                                        eventCustomer.CustomerId;
                        }
                        else if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                        {
                            customerEditAnchor.HRef = "~/App/Franchisee/FranchiseeEditCustomer.aspx?CustomerID=" +
                                                      eventCustomer.CustomerId + "&Master=EventCustomerList";
                            customerDetailAnchor.HRef = "/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" +
                                                        eventCustomer.CustomerId;
                        }
                        else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
                        {
                            customerEditAnchor.HRef = "javascript:void(0);";
                            customerDetailAnchor.HRef = "javascript:void(0);";
                        }

                    }
                    var customerNameLiteral = e.Row.FindControl("_customerNameLiteral") as Literal;
                    if (customerNameLiteral != null)
                        customerNameLiteral.Text = customerFullName;

                    var customerIdLiteral = e.Row.FindControl("_customerIdLiteral") as Literal;
                    if (customerIdLiteral != null)
                        customerIdLiteral.Text = eventCustomer.CustomerId.ToString();

                    string userDateApplied = (eventCustomer.UserCreatedOn != default(DateTime))
                                                 ? eventCustomer.UserCreatedOn.ToString("MM/dd/yyyy")
                                                 : string.Empty;

                    var userCreatedDateLiteral = e.Row.FindControl("_userCreatedDateLiteral") as Literal;
                    if (userCreatedDateLiteral != null)
                        userCreatedDateLiteral.Text = userDateApplied;

                    var couponCodeLiteral = e.Row.FindControl("_couponCodeLiteral") as Literal;
                    var couponCode = GetCouponCode();
                    if (couponCodeLiteral != null)
                        couponCodeLiteral.Text = couponCode == "(0.00)" ? "-N/A-" : couponCode;

                    var paymentDetailLiteral = e.Row.FindControl("_paymentDetailLiteral") as Literal;
                    if (paymentDetailLiteral != null && order != null)
                    {
                        paymentDetailLiteral.Text = order.DiscountedTotal.ToString("C2");
                    }

                    /* When appointment slot is allocated to a customer ************ */

                    var checkInTempSpan = e.Row.FindControl("spCheckInInsert") as HtmlContainerControl;
                    var checkOutTempSpan = e.Row.FindControl("spCheckOutInsert") as HtmlContainerControl;

                    if (order != null && order.DiscountedTotal > order.TotalAmountPaid)
                    {
                        statusSpan.InnerText = "Not Paid";
                        
                    }
                    else
                    {

                        statusSpan.InnerText = "Paid";
                    }

                    bool isTimeSaved = eventCustomer.CheckInTime.HasValue && eventCustomer.CheckOutTime.HasValue;

                    if (isTimeSaved)
                    {

                        checkInTempSpan.InnerText = eventCustomer.CheckInTime.HasValue
                                                        ? eventCustomer.CheckInTime.Value.ToShortTimeString()
                                                        : "";
                        checkOutTempSpan.InnerText = eventCustomer.CheckOutTime.HasValue
                                                         ? eventCustomer.CheckOutTime.Value.ToShortTimeString() : "";
                        checkInFilledSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                    else
                        checkInFilledSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }
        }

        private void WriteResponse(GridView grdGrid)
        {
            // Render Html
            string pagingstring = ImplementPaging(ipageindex, ipagesize, total);
            HtmlForm Formnew = this.Page.Form;
            Formnew.Controls.Clear();
            Formnew.Controls.Add(grdGrid);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

            Formnew.RenderControl(htWriter);

            string strRenderedHTML = sb.ToString();
            string strTottalRecord = string.Empty;
            int startindex = strRenderedHTML.IndexOf("<table");
            int endindex = strRenderedHTML.LastIndexOf("</table>");
            int length = (endindex - startindex) + 8;
            strRenderedHTML = strRenderedHTML.Substring(startindex, length);
            strRenderedHTML = "<div style='float: left; width: 746px'>" + strRenderedHTML + "</div>";
            Response.Write(strRenderedHTML + pagingstring + "<p class=\"blueboxbotbg_cl\"><img src=\"/App/Images/specer.gif\" width=\"746\" height=\"5\" /></p>");
        }

        private string ImplementPaging(long pagenumber, long pagesize, long recordcount)
        {

            if (recordcount <= pagesize) return "";

            // Calculates Total number of pages possible
            long numberofpages = recordcount / pagesize;
            if ((pagesize * numberofpages) != recordcount) numberofpages++;

            long minpagenumtodisplay, maxpagenumtodisplay;

            //Calculates first and last page number to display in paging tab, so as to decide whole range
            minpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 1) : ((((pagenumber / 10) - 1) * 10) + 1);
            maxpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 10) : ((pagenumber / 10) * 10);

            if (maxpagenumtodisplay > numberofpages)
            {
                if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
                maxpagenumtodisplay = numberofpages;
            }

            // Forms the paging tab string
            string pagingtableHTML = "<table  style=\"border:none; float:left; \"><tr> ";

            if (recordcount > 10 && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
            {
                pagingtableHTML += "<td><a href=\"javascript:GetTablePageChange('" + HttpUtility.HtmlEncode(strType) + "','" +HttpUtility.HtmlEncode( Convert.ToString(minpagenumtodisplay - 1)) + "')\">...</a></td>";
            }

            // Forms the Paging Number HTML .... for the range
            for (long icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
            {
                if (pagenumber == icount)
                    pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
                else
                    pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:GetTablePageChange('" + HttpUtility.HtmlEncode(strType) + "','" + HttpUtility.HtmlEncode(Convert.ToString(icount)) + "')\">" + HttpUtility.HtmlEncode(Convert.ToString(icount)) + "</a></td>";
            }

            if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
            {
                pagingtableHTML += "<td><a href=\"javascript:GetTablePageChange('" + "'" + HttpUtility.HtmlEncode(strType) + "','" + HttpUtility.HtmlEncode(Convert.ToString(maxpagenumtodisplay + 1)) + "')\">...</a></td>";
            }

            pagingtableHTML += " </tr></table>";
            return pagingtableHTML;
        }
        
    }
}
