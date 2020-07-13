using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.RequestReport
{
    public partial class SendReportStep2 : Page
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
        }

        private long CustomerId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerID"]))
                {
                    long customerId = 0;
                    if (Int64.TryParse(Request.QueryString["CustomerID"], out customerId))
                    {
                        return customerId;
                    }
                }
                if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
                {
                    return RegistrationFlow.CustomerId;
                }
                return 0;
            }
        }

        private long EventId
        {
            set { RegistrationFlow.EventId = value; }
        }

        protected long? CallId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                    return RegistrationFlow.CallId;
                return null;
            }
            set
            {
                RegistrationFlow.CallId = value.HasValue ? value.Value : 0;
            }
        }

        private long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
            }
            set
            {
                RegistrationFlow.ShippingOptionId = value.HasValue ? value.Value : 0;
            }
        }

        private long? ShippingAddressId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingAddressId > 0)
                    return RegistrationFlow.ShippingAddressId;
                return null;
            }
            set
            {
                RegistrationFlow.ShippingAddressId = value.HasValue ? value.Value : 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Request Report";
            var obj = (CallCenter_CallCenterMaster1)Master;
            obj.SetTitle("Request Report");
            obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

            obj.hideucsearch();

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
            if (!IsPostBack)
            {
                if (CallId != null)
                    hfCallStartTime.Value = new CallCenterCallRepository().GetCallStarttime(CallId.Value);

                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var objCustomer = customerRepository.GetCustomer(CustomerId);
                spnCustomerName.InnerText = objCustomer.NameAsString;
                spnAddress.InnerText = objCustomer.Address.ToString();
                spnEmail.InnerText = objCustomer.Email != null ? objCustomer.Email.ToString() : string.Empty;

                ViewState["UrlReferer"] = "/App/CallCenter/CallCenterRep/CustomerOptions.aspx?CustomerID=" + objCustomer.CustomerId + "&Name=" + objCustomer.NameAsString + "&guid=" + GuId; //Request.UrlReferrer.PathAndQuery;

                var masterDal = new MasterDAL();
                List<EEvent> customerEvent = masterDal.GetCustomerEvent(CustomerId.ToString(), 1);

                var tbltemp = new DataTable();
                tbltemp.Columns.Add("Id");
                tbltemp.Columns.Add("Name");
                tbltemp.Columns.Add("Date");
                tbltemp.Columns.Add("City");
                tbltemp.Columns.Add("AppTime");
                tbltemp.Columns.Add("Package");
                tbltemp.Columns.Add("PaymentMethod");
                tbltemp.Columns.Add("Status");
                tbltemp.Columns.Add("EventCustomerID");
                tbltemp.Columns.Add("HostName");
                tbltemp.Columns.Add("HostAddress");
                tbltemp.Columns.Add("EventStatus");
                if (customerEvent != null)
                {
                    for (Int32 intCounter = 0; intCounter < customerEvent.Count; intCounter++)
                    {
                        string strEventDate = Convert.ToDateTime(customerEvent[intCounter].EventDate).ToString("MMM dd yyyy");

                        string strAppointmentStartTime = Convert.ToDateTime(customerEvent[intCounter].Customer[0].EventAppointment.StartTime).ToString("hh:mm tt");
                        string strAppointmentEndTime = Convert.ToDateTime(customerEvent[intCounter].Customer[0].EventAppointment.EndTime).ToString("hh:mm tt");
                        string strAppointmentTime = strAppointmentStartTime + " - " + strAppointmentEndTime;
                        string strPackage = customerEvent[intCounter].Customer[0].EventPackage.Package.PackageName;
                        string strReportStatus = customerEvent[intCounter].Customer[0].Interpreted.ToString();
                        string strPayMethod = customerEvent[intCounter].Customer[0].PaymentDetail.PaymentType.Name;
                        string strHostAddress = CommonCode.AddressMultiLine(customerEvent[intCounter].Host.Address.Address1, customerEvent[intCounter].Host.Address.Address2, customerEvent[intCounter].Host.Address.City, customerEvent[intCounter].Host.Address.State, customerEvent[intCounter].Host.Address.Zip);

                        tbltemp.Rows.Add(new object[]
                                             { customerEvent[intCounter].EventID,customerEvent[intCounter].Name,
                                               strEventDate ,customerEvent[intCounter].Host.Address.City ,
                                               strAppointmentTime,strPackage,strPayMethod,strReportStatus,
                                               customerEvent[intCounter].Customer[0].CustomerEventTestID ,
                                               customerEvent[intCounter].Host.Name,strHostAddress,
                                               Convert.ToString(Enum.Parse(typeof(EventStatus), customerEvent[intCounter].EventStatus.ToString()))
                                             });
                    }

                    dgeventhistory.DataSource = tbltemp;
                    ViewState["DSGRID"] = tbltemp;
                    dgeventhistory.DataBind();


                    dbsearch.Visible = true;
                    dbsearch.Style["display"] = "";
                    dvSearchResult.InnerText = "Select the appointment you want to buy the shipping option for:";
                    imgNext.Visible = true;
                }
                else
                {
                    dbsearch.Visible = false;
                    dbsearch.Style["display"] = "";

                    dgeventhistory.Visible = false;
                    dvSearchResult.InnerText = "No Result found";
                    imgNext.Visible = false;

                }

                rbtReportMailY.Checked = true;
                ShippingOtion.ShowOnlineOption = false;
            }
        }

        protected void dgeventhistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgeventhistory.PageIndex = e.NewPageIndex;
            dgeventhistory.DataSource = ViewState["DSGRID"];
            dgeventhistory.DataBind();
        }

        protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
        {

            var objCommoncode = new CommonCode();
            objCommoncode.EndCCRepCall(Page);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId);
            }
            else
                Response.RedirectUser(ViewState["UrlReferer"].ToString());
            //Response.RedirectUser(ViewState["UrlReferer"].ToString());
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            var eventId = Convert.ToInt64(hfEventID.Value);
            EventId = eventId;

            if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No"))
            {
                if (CallId != null)
                {
                    var repository = new CallCenterCallRepository();
                    repository.UpdateEventforaCall(eventId, CallId.Value);
                }
            }

            if (rbtReportMailY.Checked && Convert.ToInt64(hfResultOrderID.Value) > 0)
            {
                ShippingOptionId = Convert.ToInt64(hfResultOrderID.Value);
                var shippingAddress = ShippingOtion.SaveShippingAddress();
                if (shippingAddress != null)
                {
                    ShippingAddressId = shippingAddress.Id;
                }
                else
                    return;
            }
            else
            {
                RegistrationFlow.ShippingAddressId = 0;
                RegistrationFlow.ShippingOptionId = 0;
            }
            if (RegistrationFlow == null || RegistrationFlow.ShippingOptionId <= 0)
                Response.RedirectUser("/App/CallCenter/CallCenterRep/AddNotes.aspx?guid=" + GuId);

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                Response.RedirectUser("SendReportStep3.aspx?Call=No&CustomerID=" + CustomerId + "&guid=" + GuId);
            else
                Response.RedirectUser("SendReportStep3.aspx?guid=" + GuId);
            //Response.RedirectUser("SendReportStep3.aspx");
        }

        protected void dgeventhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var rbt = (RadioButton)e.Row.FindControl("rbtEventCustomerID");
                if (rbt != null)
                {
                    var eventCustomerId = Convert.ToInt64(((DataRowView)(e.Row.DataItem)).Row["EventCustomerID"]);
                    var orderRepository = IoC.Resolve<IOrderRepository>();
                    var order = orderRepository.GetOrderByEventCustomerId(eventCustomerId);
                    if (order != null && order.OrderDetails != null)
                    {
                        var orderDetail = order.OrderDetails.SingleOrDefault(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)
                                                    && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted);
                        var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();
                        if (orderDetail != null)
                        {
                            var shippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                            shippingDetails = shippingDetails.Where(sd => sd.ActualPrice > 0 && sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToArray();

                            var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
                            var refundRequests = refundRequestRepository.GetbyOrderId(order.Id);

                            if (!refundRequests.IsNullOrEmpty() && refundRequests.Where(rr => rr.RefundRequestType == RefundRequestType.CancelShipping && rr.RequestStatus == (long)RequestStatus.Pending).Any())
                            {
                                rbt.Attributes["onClick"] = "return ShowRefundRequestShippingMessage(" + rbt.ClientID + ")";
                            }
                            else if (shippingDetails.Count() > 0)
                            {
                                rbt.Attributes["onClick"] = "return SelectedEvent(" + rbt.ClientID + ")";
                            }
                            else
                            {
                                rbt.Attributes["onClick"] = "return SelectedEventDetail(" + rbt.ClientID + ")";

                                if (Request.QueryString["EventId"] != null && ((DataRowView)(e.Row.DataItem)).Row["Id"].ToString() == Request.QueryString["EventId"])
                                {
                                    if (ShippingOptionId.HasValue && ShippingOptionId.Value > 0)
                                        Page.ClientScript.RegisterClientScriptBlock(typeof(string), "JS_SelectFirstOption", "$(document).ready(function () { selectEventWithShipping('" + rbt.ClientID + "','" + ShippingOptionId.Value + "'); });", true);
                                    else
                                        Page.ClientScript.RegisterClientScriptBlock(typeof(string), "JS_SelectFirstOption", "$(document).ready(function () { selectEvent('" + rbt.ClientID + "'); });", true);
                                }
                            }
                        }
                    }
                }
            }
        }



    }
}
