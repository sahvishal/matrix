using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.RequestReport
{
    public partial class AdditionalProductRequest : Page
    {
        private string GuId
        {
            get
            {
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    return string.IsNullOrEmpty(Request.QueryString["guid"]) ? hfGuId.Value : Request.QueryString["guid"];
                }
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private OrganizationRoleUserModel CurrentOrgRole
        {
            get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole; }
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
            set { Session[GuId] = value; }
        }

        private long CustomerId
        {
            get
            {

                long customerId = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerID"]))
                {
                    if (Int64.TryParse(Request.QueryString["CustomerID"], out customerId))
                    {
                        return customerId;
                    }
                }
                else if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
                {
                    return RegistrationFlow.CustomerId;
                }
                return customerId;
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

        private long? ProductId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                    return RegistrationFlow.ProductId;
                return null;
            }
            set
            {
                RegistrationFlow.ProductId = value.HasValue ? value.Value : 0;
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

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                MasterPageFile = "/App/Franchisee/Technician/TechnicianMaster.master";
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Request Report";

            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                var obj = (Franchisee_Technician_TechnicianMaster)Master;
                obj.settitle("Request Report");
                obj.SetBreadcrumb = "<a href=\"/Scheduling/Event/Index\">Dashboard</a>";
                this.Form.Action = Request.RawUrl;
            }
            else
            {
                var obj = (CallCenter_CallCenterMaster1)Master;
                obj.SetTitle("Request Report");
                obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

                obj.hideucsearch();
            }

            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                this.Form.Action = Request.RawUrl;
            }

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }

            if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                ResultOtion.EventId = Convert.ToInt64(Request.QueryString["EventId"]);

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["guid"]) && (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin)))
                {
                    hfGuId.Value = Guid.NewGuid().ToString();
                    var registrationFlow = new RegistrationFlowModel
                                               {
                                                   GuId = hfGuId.Value
                                               };
                    RegistrationFlow = registrationFlow;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                    hfEventID.Value = Request.QueryString["EventId"];
                RegistrationFlow.ShippingDetailId = 0;

                ProductOption.IsProductSelected = true;
                ProductOption.IsProductCheckboxEnabled = false;
                //if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                //    ProductOption.EventId = Convert.ToInt64(Request.QueryString["EventId"]);

                if (CallId != null)
                    hfCallStartTime.Value = new CallCenterCallRepository().GetCallStarttime(CallId.Value);


                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var objCustomer = customerRepository.GetCustomer(CustomerId);

                spnCustomerName.InnerText = objCustomer.NameAsString;
                spnAddress.InnerText = objCustomer.Address.ToString();
                spnEmail.InnerText = objCustomer.Email != null ? objCustomer.Email.ToString() : string.Empty;

                ViewState["UrlReferer"] = "/App/CallCenter/CallCenterRep/CustomerOptions.aspx?CustomerID=" + objCustomer.CustomerId + "&Name=" + objCustomer.NameAsString + "&guid=" + GuId;//Request.UrlReferrer.PathAndQuery;
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    if (!Request.UrlReferrer.PathAndQuery.ToLower().Contains(("/MakePaymentforAddonProduct").ToLower()))
                        ViewState["UrlReferer"] = Request.UrlReferrer.PathAndQuery;
                    else
                        ViewState["UrlReferer"] = Session["c_url"];
                }


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
                                               strAppointmentStartTime,strPackage,strPayMethod,strReportStatus,
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
                    dvSearchResult.InnerText = "Select the appointment you want to buy the add on product for:";
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
                ResultOtion.ShowOnlineOption = false;
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
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    Response.RedirectUser(ViewState["UrlReferer"].ToString());
                }

                Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId);
            }
            else
                Response.RedirectUser(ViewState["UrlReferer"].ToString());

        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            var orderRepository = IoC.Resolve<IOrderRepository>();
            var order = orderRepository.GetOrderByEventCustomerId(Convert.ToInt64(hfEventcustomerID.Value));
            var orderDetail = order.OrderDetails.SingleOrDefault(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)
                                                    && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted);

            var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();

            var resultShippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
            var cdShippingDetails = shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);

            resultShippingDetails = resultShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToArray();
            //cdShippingDetails = cdShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToArray();


            if (Convert.ToInt64(hfResultOrderID.Value) > 0 && resultShippingDetails.Count() > 0)//&& (cdShippingDetails == null || (cdShippingDetails.Count() < resultShippingDetails.Count()))
            {
                ErrorDiv.InnerText = "There is already an unprocessed shipping request in your order. Duplicate shipping cannot be added till this shipping request is processed. Proceed with the default selection to add a product or contact your admin.";
                ErrorDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }
            if (Convert.ToInt64(hfResultOrderID.Value) <= 0 && !cdShippingDetails.IsNullOrEmpty() && resultShippingDetails.Count() == 0)
            {
                ErrorDiv.InnerText = "To send an additional copy of Images to the customer, you need to select any one of the shipping options.";
                ErrorDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }

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

            if (ProductOption.IsProductSelected && ProductOption.ProductId > 0)
                ProductId = ProductOption.ProductId;
            else
                ProductId = null;

            if (Convert.ToInt64(hfResultOrderID.Value) > 0)
            {
                var address = ResultOtion.SaveShippingAddress();
                ShippingAddressId = address.Id;
                ShippingOptionId = Convert.ToInt64(hfResultOrderID.Value);
            }
            else
            {
                ShippingAddressId = null;
                ShippingOptionId = null;
            }

            if (ProductId == null)
            {
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    Response.RedirectUser(ViewState["UrlReferer"].ToString());
                }
                Response.RedirectUser("/App/CallCenter/CallCenterRep/AddNotes.aspx?guid=" + GuId);
            }
            else
            {
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    Session["c_url"] = ViewState["UrlReferer"].ToString();
                    Response.RedirectUser("/App/Franchisee/Technician/MakePaymentforAddonProduct?id=" + CustomerId + "&guid=" + GuId);
                }

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    Response.RedirectUser("SendReportStep3.aspx?Call=No&CustomerID=" + CustomerId + "&guid=" + GuId);
                else
                    Response.RedirectUser("SendReportStep3.aspx?guid=" + GuId);
            }

        }

        protected void dgeventhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var rbt = (RadioButton)e.Row.FindControl("rbtEventCustomerID");
                if (rbt != null)
                {
                    var productRepository = IoC.Resolve<IElectronicProductRepository>();
                    var products = productRepository.GetAllProductsForEvent(Convert.ToInt64(((DataRowView)(e.Row.DataItem)).Row["Id"]));

                    if (products != null && products.Count > 0)
                    {
                        var eventCustomerId = Convert.ToInt64(((DataRowView)(e.Row.DataItem)).Row["EventCustomerID"]);
                        var orderRepository = IoC.Resolve<IOrderRepository>();
                        var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
                        var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();

                        var order = orderRepository.GetOrderByEventCustomerId(eventCustomerId);
                        var refundRequests = refundRequestRepository.GetbyOrderId(order.Id);

                        var hasPurchasedProduct = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.DetailType == OrderItemType.ProductItem).Count() > 0 ? true : false;

                        var orderDetail = order.OrderDetails.SingleOrDefault(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)
                                                    && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted);

                        //var resultShippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                        var cdShippingDetails = shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);

                        var hasUnShippedCd = false;
                        if (!cdShippingDetails.IsNullOrEmpty())
                            hasUnShippedCd = cdShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).Any();

                        if (!refundRequests.IsNullOrEmpty() && refundRequests.Where(rr => rr.RefundRequestType == RefundRequestType.CDRemoval && rr.RequestStatus == (long)RequestStatus.Pending).Any())
                        {
                            rbt.Attributes["onClick"] = "return ShowRefundRequestProductMessage(" + rbt.ClientID + ")";
                        }
                        else if ((hasPurchasedProduct && cdShippingDetails.IsNullOrEmpty()) || hasUnShippedCd)
                            rbt.Attributes["onClick"] = "return ShowAddOnProductMessage(" + rbt.ClientID + ")";
                        else
                        {
                            rbt.Attributes["onClick"] = "return SelectedEventDetail(" + rbt.ClientID + ")";
                            if (Request.QueryString["EventId"] != null && ((DataRowView)(e.Row.DataItem)).Row["Id"].ToString() == Request.QueryString["EventId"])
                            {
                                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "JS_SelectFirstOption", "$(document).ready(function () { SelectedEventDetail(" + rbt.ClientID + "); });", true);
                            }
                        }
                    }
                    else
                        rbt.Attributes["onClick"] = "return SelectedEvent(" + rbt.ClientID + ")";
                }
            }
        }

        public string GetStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();
            return new JavaScriptSerializer().Serialize(states);
        }
    }
}
