using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.User;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Operations;
using CallType = Falcon.App.Core.CallCenter.Enum.CallType;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.Core.CallCenter;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using System.Text;
using Falcon.App.Core;

public partial class App_UCCommon_UCCustomerHistory : BaseUserControl
{

    private dynamic customerLogEditModel = new ExpandoObject();
    private List<EventsAttendedListModel> _eventsAttendedList = new List<EventsAttendedListModel>();
    private List<CommunicationListModel> _communicationList = new List<CommunicationListModel>();

    private string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? hfGuId.Value : Request.QueryString["guid"];
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
        set { Session[GuId] = value; }
    }

    public long UserId
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.UserId;
        }
    }

    public long RoleId
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;
        }
    }

    public long OrganizationId
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        }
    }

    protected long CustomerId
    {
        get
        {
            //return !string.IsNullOrEmpty(Request.QueryString["CustomerID"])
            //                 ? (long?)Convert.ToInt64(Request.QueryString["CustomerID"])
            //                 : null;

            long customerId = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["CustomerID"]))
            {
                long.TryParse(Request.QueryString["CustomerID"], out customerId);
            }
            return customerId;
        }
        set { RegistrationFlow.CustomerId = value; }
    }
    private OrganizationRoleUserModel CurrentOrgRole
    {
        get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole; }
    }
    public Roles CurrentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;

    protected long? CallId
    {
        get
        {
            if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                return RegistrationFlow.CallId;
            return null;
        }
        set { RegistrationFlow.CallId = value.HasValue ? value.Value : 0; }
    }

    private long? PackageId
    {
        get
        {
            if (RegistrationFlow != null && RegistrationFlow.PackageId > 0)
                return RegistrationFlow.PackageId;
            return null;
        }

    }

    protected long CallQueueCustomerId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CallQueueCustomerId : 0;
        }

    }

    protected string IsEligibleCustomer { get; set; }
    private Customer _customer = null;
    private Customer Customer
    {
        get
        {
            if (CustomerId <= 0)
                return null;

            if (_customer != null) return _customer;

            try
            {
                ICustomerRepository customerRepository = new CustomerRepository();

                if (CurrentRole == Roles.CallCenterRep)
                    _customer = customerRepository.GetRestrictedCustomer(CustomerId, CurrentOrgRole.OrganizationId);
                else
                    _customer = customerRepository.GetCustomer(CustomerId);
            }
            catch (ObjectNotFoundInPersistenceException<Customer>)
            {

            }
            return _customer;
        }
    }

    protected bool IsOfflineCustomerService
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Call"]) && Request.QueryString["Call"] == "No")
                return true;
            return false;
        }
    }

    private Order _order;
    private OrderDetail GetCurrentOrder(long customerId, long eventId)
    {
        IOrderRepository orderRepository = new OrderRepository();
        try
        {
            _order = orderRepository.GetOrder(customerId, eventId);
            IOrderController orderController = new OrderController();
            return orderController.GetActiveOrderDetail(_order);
        }
        catch
        {
            return null;
        }
    }

    protected string HraQuestionerAppUrl { get; set; }
    protected string OrganizationNameForHraQuestioner { get; set; }
    protected string HraToken { get; set; }
    protected string VersionNumber { get; set; }

    protected string ChatQuestionerAppUrl { get; set; }

    protected void Page_Load(object spreapprovedTestender, EventArgs e)
    {
        ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
        VersionNumber = systemInformationRepository.GetBuildNumber();

        if (!IsPostBack)
        {


            if (string.IsNullOrEmpty(Request.QueryString["guid"]))
            {
                hfGuId.Value = Guid.NewGuid().ToString();
                var registrationFlow = new RegistrationFlowModel
                                   {
                                       GuId = hfGuId.Value
                                   };
                RegistrationFlow = registrationFlow;
            }
            if (Request.QueryString["Action"] != null)
            {
                errordiv.Visible = true;
                switch (Request.QueryString["Action"])
                {
                    case "Edit":
                        errordiv.InnerText = "Customer details updated successfully.";
                        break;

                    case "Appointment":
                        errordiv.InnerText = "Appointment changed successfully.";
                        break;

                    case "Package":
                        errordiv.InnerText = "Order adjusted successfully.";
                        break;
                    case "Refund":
                        errordiv.InnerText = "Payment Refunded successfully.";
                        break;

                }
            }
            if (CustomerId > 0)
            {
                SetCustomerDetails(CustomerId);
                if (Customer != null)
                    LoadGrid(CustomerId);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Call"]) && Request.QueryString["Call"] == "No")
            {
                pCustomerLinks.Style.Add(HtmlTextWriterStyle.Display, "block");
                pCustomerLinks.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

                divPrevNext.Style.Add(HtmlTextWriterStyle.Display, "none");
                divPrevNext.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }

            if (Request["tab"] != null)
            {
                //imgCommunication.Src = @"/App/Images/communication-btn-on.gif";
                //imgAppointment.Src = @"/App/Images/appointments-btn-off.gif";
                this.Page.ClientScript.RegisterStartupScript(GetType(), "js_changetoCommunicationTab", "ChageTab('Communication');", true);
                tbpnlContainer.ActiveTabIndex = 1;
            }
            if (Request.UrlReferrer != null)
                ViewState["BackUrlRefferer"] = Request.UrlReferrer.PathAndQuery;

        }
        if (CustomerId > 0)
        {
            DisplayCummunication();
            var customerEligibility = IoC.Resolve<ICustomerEligibilityRepository>().GetByCustomerIdAndYear(CustomerId, DateTime.Today.Year);

            var customer = Customer;
            IsEligibleCustomer = string.Empty;
            if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
            {
                IsEligibleCustomer = customerEligibility.IsEligible.Value ? EligibleStatus.Yes.ToString() : EligibleStatus.No.ToString();
            }
            hideUserAccountRelatedLinks();
        }

        if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.Contains("EventCustomerList"))
        {
            tbpnlContainer.ActiveTabIndex = 1;
            this.Page.ClientScript.RegisterStartupScript(GetType(), "js_changetoCommunicationTab", "ChageTab('Communication');", true);
        }
        if (IsSystemGeneratedCallQueue())
        {
            imgBtnBack.Visible = false;
        }

        var sessionContext = IoC.Resolve<ISessionContext>();
        var settings = IoC.Resolve<ISettings>();
        HraQuestionerAppUrl = settings.HraQuestionerAppUrl;
        OrganizationNameForHraQuestioner = settings.OrganizationNameForHraQuestioner;
        HraToken = (Session.SessionID + "_" + sessionContext.UserSession.UserId + "_" +
                       sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                       sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();

        var model = new
        {
            CustomerId,
            customerLogEditModel,
            EventsAttendedList = _eventsAttendedList,
            CommunicationList = _communicationList
        };
        LogRelatedModel(ModelType.View, model, CustomerId);

    }

    protected void grdCustomerEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (CustomerId <= 0 && Customer == null)
                return;

            var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();
            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();

            var customer = Customer;


            string rowindex = (e.Row.DataItemIndex + 2) < 10 ? "ctl0" + Convert.ToString(e.Row.DataItemIndex + 2) : "ctl" + Convert.ToString(e.Row.DataItemIndex + 2);

            var divmain = (HtmlContainerControl)e.Row.FindControl("divmain");
            var divbottom = (HtmlContainerControl)e.Row.FindControl("divbottom");
            var dteventcustomer = (DataTable)ViewState["DSGRD"];
            var drvCurrent = dteventcustomer.DefaultView[e.Row.DataItemIndex]; // current row from datatable in view state, corresponding to the current grid row.

            var eventId = Convert.ToInt64(drvCurrent["EventID"]);
            var orderDetail = GetCurrentOrder(CustomerId, eventId);
            var eventCustomerDetails = eventCustomerRepository.Get(eventId, CustomerId);
            var eventRepository = IoC.Resolve<EventRepository>();
            var theEventData = eventRepository.GetById(eventId);

            var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
            var refundRequests = refundRequestRepository.GetbyOrderId(_order.Id);

            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = corporateAccountRepository.GetbyEventId(eventId);

            var eventHostpitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
            var eventHospitalPartner = eventHostpitalPartnerRepository.GetEventHospitalPartnersByEventId(eventId);



            var testResultService = IoC.Resolve<ITestResultService>();

            var bookAppointment = (account != null && account.BookPcpAppointment);
            bool isHealthPlanEvent = Convert.ToBoolean(drvCurrent["IsHealthPlanEvent"]);
           
            var hraQuestionnaireDiv = (HtmlContainerControl)e.Row.FindControl("divHraQuestionnaire");
            var isNoShow = Convert.ToBoolean(drvCurrent["IsNoShow"]);

            var chatQuestionnaireDiv = (HtmlContainerControl)e.Row.FindControl("divChatQuestionnaire");

            var isNewResultFlow = theEventData.EventDate >= IoC.Resolve<ISettings>().ResultFlowChangeDate;

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (account != null && account.IsHealthPlan)
            {
                var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEventData.EventDate);
            }

            if (isHealthPlanEvent && (questionnaireType == QuestionnaireType.HraQuestionnaire) && isNewResultFlow)
            {
                var isEawvPurchased = testResultService.IsTestPurchasedByCustomer(eventCustomerDetails.Id, (long)TestType.eAWV);
                var iseawvTestMarkedTestNotPerformed = false;

                if (isEawvPurchased)
                {
                    var testResultRepository = new EAwvTestRepository();
                    var eawvTestResult = testResultRepository.GetTestResult(eventCustomerDetails.CustomerId, eventCustomerDetails.EventId, (int)TestType.eAWV, isNewResultFlow);
                    if (eawvTestResult != null && eawvTestResult.TestNotPerformed != null && eawvTestResult.TestNotPerformed.TestNotPerformedReasonId > 0)
                    {
                        iseawvTestMarkedTestNotPerformed = true;
                    }
                }

                hraQuestionnaireDiv.Style.Add(HtmlTextWriterStyle.Display, (isEawvPurchased && !iseawvTestMarkedTestNotPerformed && !isNoShow) ? "block" : "none");
            }
            else if (account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.ChatQuestionnaire))
            {
                ChatQuestionerAppUrl = IoC.Resolve<ISettings>().ChatQuestionerAppUrl;
                chatQuestionnaireDiv.Style.Add(HtmlTextWriterStyle.Display, (questionnaireType == QuestionnaireType.ChatQuestionnaire) ? "block" : "none");
            }
            else
            {
                hraQuestionnaireDiv.Style.Add(HtmlTextWriterStyle.Display, (isHealthPlanEvent && (questionnaireType == QuestionnaireType.HraQuestionnaire) && !isNoShow) ? "block" : "none");
                chatQuestionnaireDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            DateTime? appointmentDateTime = null;
            var pcpAppointmentlinkContainer = (HtmlGenericControl)e.Row.FindControl("spPcpAppointment");
            if (bookAppointment)
            {
                var pcpAppointmentRepositoryRepository = IoC.Resolve<IPcpAppointmentRepository>();
                var pcpDispositionRepository = IoC.Resolve<IPcpDispositionRepository>();

                var pcpAppointment = pcpAppointmentRepositoryRepository.GetByCustomerIdEventId(CustomerId, eventId);

                var pcpDispositions = pcpDispositionRepository.GetByCustomerIdEventId(CustomerId, eventId);

                if (!pcpDispositions.IsNullOrEmpty() && pcpAppointment != null)
                {
                    var pcpDisposition = pcpDispositions.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).First();
                    var dateOfLatestDisposition = pcpDisposition.DataRecorderMetaData.DateCreated;

                    if (pcpAppointment.CreatedOn < dateOfLatestDisposition && (pcpAppointment.ModifiedOn == null || pcpAppointment.ModifiedOn.Value < dateOfLatestDisposition))
                    {
                        pcpAppointment = null;
                    }
                }

                if (pcpAppointment != null)
                {
                    appointmentDateTime = pcpAppointment.AppointmentOn;
                    //if (pcpAppointmentlinkContainer != null && CurrentRole == Roles.CallCenterRep)
                    //    pcpAppointmentlinkContainer.Visible = true;
                }

                if (pcpAppointmentlinkContainer != null && CurrentRole == Roles.CallCenterRep)
                    pcpAppointmentlinkContainer.Visible = true;
            }
            else
            {
                if (pcpAppointmentlinkContainer != null)
                    pcpAppointmentlinkContainer.Visible = false;
            }

            Page.ClientScript.RegisterStartupScript(typeof(string), "JsCode_CallCenterNotes" + drvCurrent["EventID"], "ShowCallCenterNotes('" + drvCurrent["EventID"] + "');", true);

            var spCost = (HtmlContainerControl)e.Row.FindControl("_spCost");
            spCost.InnerText = Convert.ToDecimal(drvCurrent["Cost"]).ToString("C2");

            var spPackage = (HtmlContainerControl)e.Row.FindControl("_spPackage");
            spPackage.InnerHtml = drvCurrent["Package"].ToString();
            var spSourceCode = (HtmlContainerControl)e.Row.FindControl("_spSourceCode");
            var sourceCodeDiscount = !String.IsNullOrEmpty(drvCurrent["Discount"].ToString())
                           ? Convert.ToDecimal(drvCurrent["Discount"]).ToString("C2")
                           : "";
            spSourceCode.InnerHtml = drvCurrent["Coupon"] + sourceCodeDiscount;

            if ((e.Row.RowIndex % 2) > 0)
            {
                divbottom.Attributes["class"] = "divorngboxbotbg_cd";
                divmain.Attributes["class"] = "divorngboxbodybg_cd";

            }
            else
            {
                divbottom.Attributes["class"] = "divbluboxbotbg_cd";
                divmain.Attributes["class"] = "divbluboxbodybg_cd";
            }
            var spLnkChangeAppt = (HtmlContainerControl)e.Row.FindControl("spLnkChangeAppt");
            if (Convert.ToString(drvCurrent["SignIN"]) != "-N/A-" && Convert.ToString(drvCurrent["SignOut"]) != "-N/A-")
            {
                spLnkChangeAppt.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                spLnkChangeAppt.Style.Add(HtmlTextWriterStyle.Display, "block");
            }

            if (CurrentRole == Roles.CallCenterRep && !theEventData.EnableForCallCenter)
            {
                spLnkChangeAppt.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            var cancelShippingLinkButton = e.Row.FindControl("CancelShippingLinkButton") as LinkButton;
            if (Convert.ToBoolean(drvCurrent["ShippingDetail"]) && cancelShippingLinkButton != null)
            {
                cancelShippingLinkButton.Enabled = true;
                cancelShippingLinkButton.CommandName = CurrentRole.ToString();
                cancelShippingLinkButton.CommandArgument = drvCurrent["OrderId"].ToString();
            }
            else if (cancelShippingLinkButton != null)
            {
                cancelShippingLinkButton.Enabled = false;
                cancelShippingLinkButton.OnClientClick = string.Empty;
            }


            var sendAppointmentConfirmationSpan = e.Row.FindControl("sendAppointmentConfirmationSpan") as HtmlGenericControl;


            if (sendAppointmentConfirmationSpan != null && CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) && ShowSmsConfirmationAndReminderLnk(account, eventCustomerDetails, theEventData, customer))
            {
                sendAppointmentConfirmationSpan.Visible = true;
            }
            else if (sendAppointmentConfirmationSpan != null)
            {
                sendAppointmentConfirmationSpan.Visible = false;
            }


            var sendAppointmentReminderSpan = e.Row.FindControl("sendAppointmentReminderSpan") as HtmlGenericControl;

            if (sendAppointmentReminderSpan != null && CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) && ShowSmsConfirmationAndReminderLnk(account, eventCustomerDetails, theEventData, customer))
            {
                sendAppointmentReminderSpan.Visible = true;
            }
            else if (sendAppointmentReminderSpan != null)
            {
                sendAppointmentReminderSpan.Visible = false;
            }

            var appointmentConfirmationSpan = e.Row.FindControl("spConfirmAppointment") as HtmlGenericControl;
            if (appointmentConfirmationSpan != null && CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) && ShowAppointmentConfirmationLink(eventCustomerDetails, theEventData))
            {
                appointmentConfirmationSpan.Visible = true;
            }
            else
            {
                appointmentConfirmationSpan.Visible = false;
            }

            var productRepository = IoC.Resolve<IElectronicProductRepository>();
            var products = productRepository.GetAllProductsForEvent(eventId);

            var spAddonProduct = e.Row.FindControl("spAddonProduct") as HtmlGenericControl;

            var removeProductContainer = (HtmlContainerControl)e.Row.FindControl("RemoveProductSpan");
            removeProductContainer.Visible = false;

            if (products != null && products.Count > 0)
            {
                if (spAddonProduct != null)
                    spAddonProduct.Style.Add(HtmlTextWriterStyle.Display, "block");

                var aAddonProduct = e.Row.FindControl("aAddonProduct") as HtmlAnchor;

                var hasPurchasedProduct = _order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.DetailType == OrderItemType.ProductItem).Count() > 0 ? true : false;
                var cdShippingDetails = shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);
                var hasUnShippedCd = false;
                if (!cdShippingDetails.IsNullOrEmpty())
                    hasUnShippedCd = cdShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).Any();

                if (aAddonProduct != null)
                {
                    if (!refundRequests.IsNullOrEmpty() && refundRequests.Where(rr => rr.RefundRequestType == RefundRequestType.CDRemoval && rr.RequestStatus == (long)RequestStatus.Pending).Any())
                    {
                        aAddonProduct.HRef = "javascript:void(0);";
                        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                        {
                            aAddonProduct.Attributes.Add("onclick", "ShowRefundRequestProductMessageForAdmin();");
                        }
                        else
                        {
                            aAddonProduct.Attributes.Add("onclick", "ShowRefundRequestProductMessage();");
                        }

                    }
                    else if ((hasPurchasedProduct && cdShippingDetails.IsNullOrEmpty()) || hasUnShippedCd)
                    {
                        aAddonProduct.HRef = "javascript:void(0);";
                        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                        {
                            aAddonProduct.Attributes.Add("onclick", "ShowAddOnProductMessageForAdmin();");
                        }
                        else
                        {
                            aAddonProduct.Attributes.Add("onclick", "ShowAddOnProductMessage();");
                        }

                        removeProductContainer.Visible = true;
                    }
                    else if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                        aAddonProduct.HRef = "/App/Franchisee/Technician/AdditionalProductRequest?id=" + CustomerId + "&EventId=" + eventId + "&guid=" + GuId;
                    else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
                        aAddonProduct.HRef = "/App/CallCenter/CallCenterRep/RequestReport/AdditionalProductRequest.aspx?CustomerId=" + CustomerId + (IsOfflineCustomerService ? "&Call=No" : "") + "&EventId=" + eventId + "&guid=" + GuId;
                }
            }
            else
            {
                if (spAddonProduct != null)
                    spAddonProduct.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            var TestPDF = (HtmlContainerControl)e.Row.FindControl("spTestPDF");


            if (CurrentRole == Roles.CallCenterRep || CurrentRole == Roles.CallCenterManager)
            {
                TestPDF.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            // *** Start AAATestResult ***
            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                // If the result are ready
                var spGeneratePDF = (HtmlContainerControl)e.Row.FindControl("spGeneratePDF");
                if (Convert.ToBoolean(drvCurrent["IsResultPDFGenerated"]) || Convert.ToBoolean(drvCurrent["IsClinicalFormGenerated"]))
                {
                    if (Convert.ToBoolean(drvCurrent["IsResultPDFGenerated"]))
                    {
                        TestPDF.Style.Add(HtmlTextWriterStyle.Display, "block");

                        var key = new DigitalDeliveryCryptographyService().GetKey(eventId, CustomerId, EPDFType.ResultPdf); ;
                        TestPDF.InnerHtml = "<a id='" + rowindex + "_ViewPDF' href=\"javascript:showClinicalForm('" + key + "')\" >View Results</a>";
                    }

                    spGeneratePDF.Style.Add(HtmlTextWriterStyle.Display, "block");
                }

                try
                {
                    if (Convert.ToInt32(drvCurrent["TestStatus"]) < 4 && Convert.ToInt32(drvCurrent["TestStatus"]) > 1)
                    {
                        var sperase = (HtmlContainerControl)e.Row.FindControl("spErase");
                        sperase.Visible = true;
                    }
                }
                catch { }
            }
            else
            {
                TestPDF.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            var eventcustomerid = Convert.ToInt32(((DataTable)ViewState["DSGRD"]).Rows[e.Row.DataItemIndex]["EventCustomerID"]);
            var packageid = Convert.ToInt32(((DataTable)ViewState["DSGRD"]).Rows[e.Row.DataItemIndex]["PackageID"]);


            //if (_order == null || _order.OrderDetails == null || _order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.DetailType == OrderItemType.ProductItem).Count() < 1)
            //{
            //    var removeProductContainer = (HtmlContainerControl)e.Row.FindControl("RemoveProductSpan");
            //    removeProductContainer.Visible = false;
            //}
            var manualRefund = (HtmlContainerControl)e.Row.FindControl("ManualRefund");
            if (manualRefund != null)
            {
                if (_order != null && _order.TotalAmountPaid > 0)
                    manualRefund.Visible = true;
                else
                    manualRefund.Visible = false;
            }

            var spAcceptPayment = (HtmlContainerControl)e.Row.FindControl("spAcceptPayment");

            if (Convert.ToBoolean(drvCurrent["Ispaid"]) == false)
            {
                var eventcustid = Convert.ToString(drvCurrent["EventCustomerID"]);

                var appointmentslot = Convert.ToString(drvCurrent["Appointment"]).Replace(" ", "@");
                var totalamount = Convert.ToString(drvCurrent["TotalAmount"]).Replace(" ", "@").Replace("$", "");

                spAcceptPayment.InnerHtml = "<a href='javascript:popupmenu2(\"/App/Franchisee/Technician/AcceptPayment.aspx?EventCustomerID=" + eventcustid + "&AppointmentSlot=" + appointmentslot + "&TotalAmount=" + totalamount + "&DateCreated=" + Convert.ToString(ViewState["DateCreated"]) + "&CustomerID=" + CustomerId + "&appointmentTime=" + drvCurrent["Appointment"].ToString() + "&EventID=" + Convert.ToString(drvCurrent["EventID"]) + "&PageCallBackFrom=CustomerDetail" + "\", 595, 680);' style=\"font-size:8pt;\"> Accept Payment </a>";

                SetPaymentAndShippingAnchors(e, CustomerId);
            }
            else
            {
                spAcceptPayment.Visible = false;
                SetPaymentAndShippingAnchors(e, CustomerId);
            }

            var lnktemp = (LinkButton)e.Row.FindControl("lnkRSMail");
            var spLnkRSMail = (HtmlContainerControl)e.Row.FindControl("spLnkRSMail");
            if (account == null || account.SendAppointmentMail)
            {
                lnktemp.Visible = true;
                if (customer.Email != null && !string.IsNullOrEmpty(customer.Email.ToString()) && (Convert.ToDateTime(((DataTable)ViewState["DSGRD"]).Rows[e.Row.DataItemIndex]["EventDate"]) >= DateTime.Now.Date))
                {
                    lnktemp.Enabled = true;
                    lnktemp.OnClientClick = "return confirm('Do you want to send a reminder mail to " + customer.Name.FullName.Replace("'", "\\'") + " ?');";
                }
                else
                {
                    lnktemp.Enabled = false;
                }
            }
            else
                spLnkRSMail.Visible = false;



            var lnkDelApp = (LinkButton)e.Row.FindControl("lnkDelApp");
            if (Convert.ToDateTime(((DataTable)ViewState["DSGRD"]).Rows[e.Row.DataItemIndex]["EventDate"]) >= Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")))
            {
                lnkDelApp.Enabled = true;

            }
            else
            {
                // Enable cancelappoint link in case of franchisor refer to story (#8539)
                if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    lnkDelApp.Enabled = true;
                }
                else
                {
                    lnkDelApp.Enabled = false;
                    lnkDelApp.OnClientClick = "return false";
                }
            }



            var lnkApplyCoupon = (HtmlContainerControl)e.Row.FindControl("spLnkApplyCoupon");
            //var spCustomerPayment = (HtmlContainerControl)e.Row.FindControl("spCustomerPayment");
            var cancelShippingSpan = e.Row.FindControl("CancelShippingSpan") as HtmlGenericControl;

            if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {

                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Display, "none");
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

                //spCustomerPayment.Style.Add(HtmlTextWriterStyle.Display, "none");
                //spCustomerPayment.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                if (cancelShippingSpan != null) cancelShippingSpan.Visible = true;
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Display, "none");
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                var lnkCoupon = (LinkButton)e.Row.FindControl("lnkApplyCoupon");
                lnkCoupon.OnClientClick = "return confirm('Are you sure want to apply the coupon?');";

                if (cancelShippingSpan != null) cancelShippingSpan.Visible = true;
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep))
            {
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                var lnkCoupon = (LinkButton)e.Row.FindControl("lnkApplyCoupon");
                lnkCoupon.OnClientClick = "return confirm('Are you sure want to apply the coupon?');";

                //if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                //{
                //    var AddNotes = (HtmlContainerControl)e.Row.FindControl("spAddNotes");
                //    AddNotes.Visible = true;
                //}
                if (cancelShippingSpan != null) cancelShippingSpan.Visible = true;


                //TODO:Temp patch, callcenter rep should have proper data.
                try
                {
                    if (!IoC.Resolve<ICallCenterRepRepository>().CanRefund(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId))
                    {
                        var callcenterDal = new CallCenterDAL();
                        int scriptTypeId = callcenterDal.GetScriptType("ForwardRefundCall", 2)[0].ScriptTypeID;
                        var scriptText = callcenterDal.GetScript(scriptTypeId.ToString(), 4)[0].ScriptText;
                        try
                        {
                            var ccRepList = IoC.Resolve<ICallCenterRepRepository>().GetCallCenterRepsAuthorizedToRefund();
                            scriptText = scriptText.Replace("<<Name>>", string.Join(",", ccRepList));
                            lnkDelApp.Attributes.Add("onclick", "alert('" + scriptText + "');");
                        }
                        catch
                        {
                            lnkDelApp.Attributes.Add("onclick", "return false;");
                        }

                    }
                }
                catch (ObjectNotFoundInPersistenceException<CallCenterRep>)
                {
                    lnkDelApp.Visible = true;
                }


            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
            {
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Display, "none");
                lnkApplyCoupon.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

                //spCustomerPayment.Style.Add(HtmlTextWriterStyle.Display, "none");
                //spCustomerPayment.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                if (cancelShippingSpan != null) cancelShippingSpan.Visible = true;
            }

            var lnkChangePackage = (LinkButton)e.Row.FindControl("lnkChangePackage");
            if (Convert.ToInt32(drvCurrent["TestStatus"].ToString()) < 4)
            {
                lnkChangePackage.Enabled = true;
                lnkChangePackage.OnClientClick = "return confirm('Are you sure you want to adjust order ?');";
            }
            else
            {
                lnkChangePackage.Enabled = false;
            }
            if (Convert.ToBoolean(drvCurrent["IsPaymentRefunded"]))
            {
                lnkChangePackage.Enabled = false;
                lnkChangePackage.OnClientClick = "return false;";
                lnkDelApp.Enabled = false;
                lnkDelApp.OnClientClick = "return false;";
            }

            var fullfillmentOptionAnchor = (HtmlAnchor)e.Row.FindControl("FullfillmentOptionAnchor");
            if (fullfillmentOptionAnchor != null)
            {
                var resultShippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                resultShippingDetails = resultShippingDetails.Where(sd => sd.ActualPrice > 0 && sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToArray();
                if (resultShippingDetails.Count() > 0)
                {
                    fullfillmentOptionAnchor.HRef = "Javascript:void(0);";
                    fullfillmentOptionAnchor.Attributes.Add("onclick", "ShowFullfillmentMessage();");
                }
                else if (!refundRequests.IsNullOrEmpty() && refundRequests.Where(rr => rr.RefundRequestType == RefundRequestType.CancelShipping && rr.RequestStatus == (long)RequestStatus.Pending).Any())
                {
                    fullfillmentOptionAnchor.HRef = "Javascript:void(0);";
                    fullfillmentOptionAnchor.Attributes.Add("onclick", "ShowRefundRequestShippingMessage();");
                }
                else
                {
                    fullfillmentOptionAnchor.HRef = "/App/CallCenter/CallCenterRep/RequestReport/SendReportStep2.aspx?CustomerId=" + CustomerId + (IsOfflineCustomerService ? "&Call=No" : "") + "&guid=" + GuId;
                }
            }

            /*****show jquery dialog box if Hospital partner has Restricted Evaluation********/


            var assignPhysicianToCustomer = (HtmlAnchor)e.Row.FindControl("AssignPhysicianToCustomer");
            if (assignPhysicianToCustomer != null)
            {
                if (eventHospitalPartner != null && eventHospitalPartner.RestrictEvaluation)
                {
                    assignPhysicianToCustomer.HRef = "Javascript:void(0);";
                    assignPhysicianToCustomer.Attributes.Add("onclick", "ShowPhysicianToCustomerRestricted();");
                }
                else
                {
                    assignPhysicianToCustomer.HRef = "javascript:window.open('/Operations/PhysicianAssignment/AssignPhysicianToCustomer?eventCustomerId=" + eventcustomerid + "','AssignPhysician_Customer','toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=550,height=450');void(0);";
                }
            }



            //var customerHealthInfo = IoC.Resolve<IHealthAssessmentRepository>().Get(CustomerId, eventId); 
            var healthAssessmentHelper = IoC.Resolve<IKynHealthAssessmentHelper>();
            var iskynPrefilled = healthAssessmentHelper.CheckHafPrefilled(eventId, CustomerId);
            var amedicalhistory = (HtmlAnchor)e.Row.FindControl("amedicalhistory");
            var spMedicalHistory = (HtmlContainerControl)e.Row.FindControl("spMedicalHistory");
            var medicalHistoryContainer = (HtmlContainerControl)e.Row.FindControl("medicalHistoryContainer");
            if (medicalHistoryContainer != null)
            {
                if (account == null || account.CaptureHaf)
                {
                    if (amedicalhistory != null && spMedicalHistory != null)
                    {
                        if (iskynPrefilled)
                        {
                            spMedicalHistory.InnerText = "Completed";
                            amedicalhistory.InnerText = "Update";
                            amedicalhistory.HRef = "/App/Franchisor/MedicalHistory.aspx?CustomerID=" + CustomerId + "&EventId=" + eventId + "&Edit=true";
                        }
                        else
                        {
                            spMedicalHistory.InnerText = "Not Filled";
                            amedicalhistory.InnerText = "Fill";
                            amedicalhistory.HRef = "/App/Franchisor/MedicalHistory.aspx?CustomerID=" + CustomerId + "&EventId=" + eventId;
                        }
                    }
                }
                else
                {
                    medicalHistoryContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }

            var mspHistoryForm = (HtmlAnchor)e.Row.FindControl("mspHistoryForm");
            var mspHistoryFormContainer = (HtmlGenericControl)e.Row.FindControl("mspformContainer");
            var mspHistorySpan = (HtmlGenericControl)e.Row.FindControl("mspHistory");
            if (mspHistoryFormContainer != null || mspHistoryForm != null && mspHistorySpan != null)
            {
                var customerMedicareQestionService = IoC.Resolve<ICustomerMedicareQuestionService>();
                var isPurchsed = customerMedicareQestionService.IsTestPurchased(eventId, CustomerId, new[] { (long)TestType.Medicare, (long)TestType.AwvSubsequent, (long)TestType.AWV });

                if (isPurchsed)
                {
                    var getCustomerAnswer = customerMedicareQestionService.GetAnswersByEventCustomerId(eventcustomerid);
                    var FilledStatus = getCustomerAnswer.IsNullOrEmpty() ? "Not Filled" : "Filled";

                    mspHistorySpan.InnerText = FilledStatus;
                    mspHistoryForm.InnerText = getCustomerAnswer.IsNullOrEmpty() ? "Fill" : "Update";
                    mspHistoryForm.HRef = "/medical/medicareQuestion/Update?eventcustomerid=" + eventcustomerid;
                }
                else
                {
                    mspHistoryFormContainer.Visible = false;
                    mspHistoryForm.Visible = false;
                }
            }

            var pcpAppointmentInfo = (HtmlGenericControl)e.Row.FindControl("pcpAppointmentInfo");
            var pcpAppointmentDate = (HtmlGenericControl)e.Row.FindControl("pcpAppointmentDate");


            if (pcpAppointmentInfo != null && pcpAppointmentDate != null)
            {
                if (bookAppointment)
                {
                    pcpAppointmentDate.InnerText = (appointmentDateTime.HasValue) ? appointmentDateTime.Value.Date.ToShortDateString() + " at " + appointmentDateTime.Value.ToString("hh:mm tt") : "N/A";
                }
                else
                {
                    pcpAppointmentInfo.Visible = false;
                }
            }

            if (eventCustomerDetails.LeftWithoutScreeningReasonId.HasValue)
            {
                var patientLeftWithoutScreening = (HtmlContainerControl)e.Row.FindControl("patientLeftWithoutScreening");
                var attendedSpan = (HtmlContainerControl)e.Row.FindControl("attendedSpan");
                var item = (LeftWithoutScreeningReason)eventCustomerDetails.LeftWithoutScreeningReasonId.Value;
                patientLeftWithoutScreening.InnerText = item.GetDescription();
                attendedSpan.InnerText = "No";
            }
            var divEnableTexting = (HtmlContainerControl)e.Row.FindControl("divEnableTexting");
            if (Convert.ToDateTime(((DataTable)ViewState["DSGRD"]).Rows[e.Row.DataItemIndex]["EventDate"]) >= DateTime.Now.Date)
            {
                var enableTextInfo = (HtmlContainerControl)e.Row.FindControl("EnableTextInfo");
                var enableTextingAnchor = (HtmlContainerControl)e.Row.FindControl("EnableTextingAnchor");

                divEnableTexting.Visible = true;
                var enableTextingFunction = "javascript:return loadEnableTexting(" + eventCustomerDetails.Id + ");";
                enableTextingAnchor.Attributes.Add("onClick", enableTextingFunction);
                if (eventCustomerDetails.EnableTexting)
                {
                    enableTextInfo.InnerText = "Yes";
                }
                else
                {
                    enableTextInfo.InnerText = "No";
                }
            }
            else
                divEnableTexting.Visible = false;



        }
    }

    private bool ShowSmsConfirmationAndReminderLnk(CorporateAccount account, EventCustomer eventCustomer, Event theEvent, Customer customer)
    {
        if (account != null && account.EnableSms && eventCustomer.EnableTexting && theEvent.EventDate >= DateTime.Today && theEvent.Status == EventStatus.Active)
        {
            if (customer.MobilePhoneNumber != null && !string.IsNullOrEmpty(customer.MobilePhoneNumber.Number) && customer.MobilePhoneNumber.ToString().Length > 0)
            {
                return true;
            }
        }

        return false;
    }

    protected void lnkRSMail_Click(object sender, EventArgs e)
    {
        if (!CheckCustomerId())
            return;
        var lnktemp = (LinkButton)sender;

        int eventId = Convert.ToInt32(lnktemp.CommandName);
        if (Customer == null) return;

        //var customer = Customer;

        var notifier = IoC.Resolve<INotifier>();
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var appointmentConfirmationViewModel = emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventId, CustomerId);

        var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
        var account = corporateAccountRepository.GetbyEventId(eventId);

        string emailTemplateAlias = EmailTemplateAlias.ScreeningReminderMail;
        if (account != null && account.AppointmentReminderMailTemplateId > 0)
        {
            var emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
            var emailTemplate = emailTemplateRepository.GetById(account.AppointmentReminderMailTemplateId);
            emailTemplateAlias = emailTemplate.Alias;
        }

        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ScreeningReminderMail, emailTemplateAlias, appointmentConfirmationViewModel, Customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath, useAlternateEmail: true);

        errordiv.Visible = true;
        errordiv.InnerText = "Reminder mail sent to customer successfully.";

        if (CurrentRole == Roles.CallCenterRep || CurrentRole == Roles.CallCenterManager)
        {
            if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No"))
            {
                if (CallId != null)
                {
                    var repository = new CallCenterCallRepository();
                    var call = repository.GetCallCenterEntity(CallId.Value);

                    call.CallStatus = CallType.Reminder_Mail.ToString().Replace("_", " ");
                    call.EventID = eventId;
                    EndCall(call);
                    StartCall(call.CalledCustomerID);
                }
            }
        }

        DisplayCummunication();
    }

    protected void lnkChangePackage_Click(object sender, EventArgs e)
    {
        if (!CheckCustomerId())
            return;

        var lnktemp = (LinkButton)sender;
        int eventcustomerid = Convert.ToInt32(lnktemp.CommandArgument);
        int eventid = Convert.ToInt32(lnktemp.CommandName);

        if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            Response.RedirectUser(ResolveUrl("~/App/Common/ChangePackage.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            Response.RedirectUser(ResolveUrl("~/App/Common/ChangePackage.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            Response.RedirectUser(ResolveUrl("~/App/Common/ChangePackage.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepChangePackage.aspx?Call=No&EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
            }
            else
            {
                if (CallId != null)
                {
                    var repository = new CallCenterCallRepository();
                    var call = repository.GetCallCenterEntity(CallId.Value);

                    call.CallStatus = CallType.Change_Package.ToString().Replace("_", " ");
                    call.CalledCustomerID = CustomerId;
                    call.EventID = eventid;

                    var dal = new CallCenterDAL();
                    dal.UpdateCall(call);
                }
                Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepChangePackage.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));

            }
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
        {
            Response.RedirectUser(ResolveUrl("~/App/Common/ChangePackage.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
        }


    }

    /// <summary>
    /// this method is called on click event on link button lnksendMail
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnksendMail_Click(object sender, EventArgs e)
    {
        var notifier = IoC.Resolve<INotifier>();
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        if (Customer == null) return;

        var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(Customer.UserLogin.UserName, Customer.Name.FullName, Customer.DateCreated);
        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, Customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

        if (Customer.UserLogin != null && !Customer.UserLogin.UserVerified)
        {
            var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
            customerRegistrationService.SendResetPasswordMail(Customer.Id, Customer.Name.FullName, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
        }
        errordiv.Visible = true;
        errordiv.InnerText = "Welcome mail sent to customer successfully.";
        DisplayCummunication();

    }

    /// <summary>
    /// this method is called on click event on link button lnkDisable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Command_Button_Click(Object sender, CommandEventArgs e)
    {
        var objUserDal = new UserDAL();
        var masterDal = new MasterDAL();

        if (Customer == null) return;

        switch (e.CommandName)
        {
            case "Disable":
                Int32 userId = Convert.ToInt32(Customer.Id);
                objUserDal.DisableUser(userId);
                break;

            case "Enable":
                userId = Convert.ToInt32(Customer.Id);
                objUserDal.EnableUser(userId);
                break;

            case "Erase":
                userId = Convert.ToInt32(Customer.Id);
                masterDal.RemoveCustomer(userId);
                break;
        }

        if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisee/FranchiseeCustomerList.aspx?Action=" + e.CommandName));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisee/SalesRep/SalesRepEventCustomerList.aspx?Action=" + e.CommandName));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisor/FranchisorCustomerList.aspx?Action=" + e.CommandName));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
        {
            Response.RedirectUser(this.ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerList.aspx?Action=" + e.CommandName));

        }
        else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerList.aspx?Action=" + e.CommandName));
        }

    }

    protected void lnkDelApp_Click(object sender, EventArgs e)
    {
        if (!CheckCustomerId())
            return;

        var lnktemp = (LinkButton)sender;
        int eventcustomerid = Convert.ToInt32(lnktemp.CommandArgument);
        int eventid = Convert.ToInt32(lnktemp.CommandName);

        if (eventcustomerid > 0)
        {
            if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisee/FranchiseeCancelAppointment.aspx?EventCustomerID=" + eventcustomerid));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisee/SalesRep/SalesRepCancelAppointment.aspx?EventCustomerID=" + eventcustomerid));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCancelAppointment.aspx?EventCustomerID=" + eventcustomerid));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCancelAppointment.aspx?Call=No&EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
                }
                else
                {
                    if (CallId != null)
                    {
                        var call = new CallCenterCallRepository().GetCallCenterEntity(CallId.Value);
                        call.CallStatus = CallType.Cancel_Appointment.ToString().Replace("_", " ");
                        call.CalledCustomerID = CustomerId;
                        call.EventID = eventid;

                        var dal = new CallCenterDAL();
                        dal.UpdateCall(call);
                    }
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCancelAppointment.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
                }
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianCancelAppointment.aspx?EventCustomerID=" + eventcustomerid));
            }
        }
    }

    protected void lnkErase_Click(object sender, EventArgs e)
    {
        LinkButton lnktemp = (LinkButton)sender;

        int eventid = Convert.ToInt32(lnktemp.CommandName);


    }

    /// <summary>
    /// for register new event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkRegisterForEvent_Click(object sender, EventArgs e)
    {
        if (CustomerId > 0)
        {
            CustomerId = CustomerId;

            if ((CurrentRole == Roles.CallCenterRep || CurrentRole == Roles.CallCenterManager) && Request.QueryString["Type"] == null)
            {
                // redirect to customer profile
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerID=" + CustomerId + "&CustomerType=Existing&Call=No" + "&Name=" + Server.UrlEncode(Customer.NameAsString) + "&guid=" + GuId));
                }
                else
                {
                    if (CallId != null)
                        new CallCenterCallRepository().UpdateCallCenterCallStatus(CallType.Existing_Customer.ToString().Replace("_", " "), CallId.Value);

                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerID=" + CustomerId + "&CustomerType=Existing&Name=" + Server.UrlEncode(Customer.NameAsString) + "&guid=" + GuId));
                }
            }
            else if (CurrentRole == Roles.Technician)
            {
                Response.RedirectUser(ResolveUrl("/App/Common/RegisterCustomer/RegisterCustomer.aspx?Customer=Existing&Action=Forward" + "&guid=" + GuId));
            }
            else if ((CurrentRole == Roles.CallCenterRep || CurrentRole == Roles.CallCenterManager) && Request.QueryString["Type"] != null && Request.QueryString["Type"] == "RegExistCustForSameEvent")
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    Response.RedirectUser(PackageId.HasValue
                                          ? ResolveUrl(
                                              "/App/CallCenter/CallCenterRep/ExistingCustomer/SelectPackage.aspx?Type=RegExistCustForSameEvent&Call=No" + "&guid=" + GuId)
                                          : ResolveUrl(
                                              "/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerID=" +
                                              CustomerId + "&Call=No" + "&guid=" + GuId));
                }
                else
                {
                    Response.RedirectUser(PackageId.HasValue
                                          ? ResolveUrl(
                                              "/App/CallCenter/CallCenterRep/ExistingCustomer/SelectPackage.aspx?Type=RegExistCustForSameEvent" + "&guid=" + GuId)
                                          : ResolveUrl(
                                              "/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerID=" + CustomerId + "&guid=" + GuId));
                }
            }
        }
    }

    protected void lnkApplyCoupon_Click(object sender, EventArgs e)
    {
        if (!CheckCustomerId())
            return;
        var lnktemp = (LinkButton)sender;
        int eventcustomerid = Convert.ToInt32(lnktemp.CommandArgument);
        int eventid = Convert.ToInt32(lnktemp.CommandName);

        if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepApplyCoupon.aspx?Call=No&EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
            }
            else
            {
                if (CallId != null)
                {
                    var repository = new CallCenterCallRepository();
                    var call = repository.GetCallCenterEntity(CallId.Value);

                    call.CallStatus = "Apply Coupon";
                    call.CalledCustomerID = CustomerId;
                    call.EventID = eventid;

                    var dal = new CallCenterDAL();
                    dal.UpdateCall(call);
                }
                Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepApplyCoupon.aspx?EventCustomerID=" + eventcustomerid + "&guid=" + GuId));
            }
        }

        if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            Response.RedirectUser("/App/Common/ApplyCoupon.aspx?EventCustomerID=" + eventcustomerid);

    }

    protected void lnkPrintReceipt_Click(object sender, EventArgs e)
    {
        if (!CheckCustomerId())
            return;
        var lnktemp = (LinkButton)sender;

        int eventid = Convert.ToInt32(lnktemp.CommandName);

        //if (CurrentRole == Roles.CallCenterRep || CurrentRole == Roles.CallCenterManager)
        //{
        if (CallId != null)
        {
            var repository = new CallCenterCallRepository();
            var call = repository.GetCallCenterEntity(CallId.Value);

            call.CallStatus = "Print Receipt";
            call.CalledCustomerID = CustomerId;
            call.EventID = eventid;

            var dal = new CallCenterDAL();
            dal.UpdateCall(call);
        }

        var receiptUrl = "/Config/Content/Controls/SmallPrintReciept.aspx?EventID=" + eventid + "&CustomerId=" + CustomerId;

        Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "popupmenu2('" + receiptUrl + "',282,535);", true);

        //}
    }

    protected void lnkBtnNext_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["NextCustID"].ToString()) > 0)
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser(Request.Url.AbsolutePath + "?CustomerID=" + ViewState["NextCustID"].ToString() + "&Call=No");
            }
            else
            {
                Response.RedirectUser(Request.Url.AbsolutePath + "?CustomerID=" + ViewState["NextCustID"].ToString());
            }
        }
    }

    protected void lnkBtnPrev_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["PrevCustID"].ToString()) > 0)
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser(Request.Url.AbsolutePath + "?CustomerID=" + ViewState["PrevCustID"].ToString() + "&Call=No");
            }
            else
            {
                Response.RedirectUser(Request.Url.AbsolutePath + "?CustomerID=" + ViewState["PrevCustID"].ToString());

            }
        }
    }

    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["BackUrlRefferer"] != null)
            Response.RedirectUser(ViewState["BackUrlRefferer"].ToString());
    }
    private bool IsSystemGeneratedCallQueue()
    {

        if (CallQueueCustomerId > 0)
        {
            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
            var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId);

            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);

            return (callQueue != null && !callQueue.IsManual && !callQueue.IsHealthPlan);


        }
        return false;
    }
    protected void CancelShippingLinkButton_Click(object sender, EventArgs e)
    {
        var cancelLink = sender as LinkButton;
        if (cancelLink != null)
        {
            var orderId = cancelLink.CommandArgument;

            if (CurrentOrgRole.CheckRole((long)Roles.OperationManager) || CurrentOrgRole.CheckRole((long)Roles.CallCenterRep))
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CancelShippingDetail.aspx") + "?Call=No&OrderId=" + orderId + "&guid=" + GuId);
                else
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CancelShippingDetail.aspx") + "?OrderId=" + orderId + "&guid=" + GuId);
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/CancelShippingDetail.aspx") + "?OrderId=" + orderId);
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisor/CancelShippingDetail.aspx") + "?OrderId=" + orderId);
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisee/CancelShippingDetail.aspx") + "?OrderId=" + orderId);
            }
        }
    }

    protected void lnkChangeApp_Click(object sender, EventArgs e)
    {
        var lnktemp = (LinkButton)sender;
        int eventcustomerid = Convert.ToInt32(lnktemp.CommandArgument);
        int eventid = Convert.ToInt32(lnktemp.CommandName);

        if (!CheckCustomerId())
            return;

        if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            Response.RedirectUser("~/App/Franchisee/FranchiseeRescheduleCustomerAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId);

        }
        else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepRescheduleCustomerAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId);

        }
        else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            Response.RedirectUser("~/App/Franchisor/FranchisorRescheduleCustomerAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId);

        }
        else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser("~/App/CallCenter/CallCenterRep/CallCenterRepRescheduleCustomerAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("~/App/CallCenter/CallCenterRep/CallCenterRepRescheduleCustomerAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId + "&guid=" + GuId);
            }
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
        {
            Response.RedirectUser("~/App/Franchisee/Technician/TechnicianRescheduleCustomerAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId);

        }
    }
    protected void grdCustomerEvents_PreRender(object sender, EventArgs e)
    {
        DateTime compareDateTime = DateTime.Now;
        GridViewRow firstRegistratinGridRow = null;
        foreach (GridViewRow gridRow in grdCustomerEvents.Rows)
        {
            var registerDateSpan = gridRow.FindControl("registerDateSpan") as HtmlGenericControl;

            if (registerDateSpan != null)
            {
                DateTime currentRowDate;
                if (DateTime.TryParse(registerDateSpan.InnerHtml, out currentRowDate))
                {
                    if (DateTime.Compare(currentRowDate, compareDateTime) < 0)
                    {
                        firstRegistratinGridRow = gridRow;
                        compareDateTime = currentRowDate;
                    }
                }
            }
        }
        if (firstRegistratinGridRow != null)
        {
            var marketingSource = firstRegistratinGridRow.FindControl("marketingSource") as HtmlGenericControl;

            if (marketingSource != null)
            {
                marketingSource.Attributes["class"] = "normaltextnowidth_default leadSourceSpan first-registration";
            }
        }
    }

    /// <summary>
    /// set the details of the customer for the given customer id
    /// </summary>
    private void SetCustomerDetails(long customerId)
    {
        // format phone no.
        var objCommonCode = new CommonCode();
        Customer customer = Customer;

        if (customer != null)
        {
            var customerEligibility = IoC.Resolve<ICustomerEligibilityRepository>().GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);

            customerLogEditModel.CustomerId = customerId;
            var corporateCustomTag = IoC.Resolve<ICorporateCustomerCustomTagRepository>();
            var customTags = corporateCustomTag.GetByCustomerId(customerId);
            requestedNewsletterSpan.InnerText = customer.RequestForNewsLetter ? "Yes" : "No";



            ViewState["PrevCustID"] = 0;//objCustomer[0].PrevCustomerID;
            ViewState["NextCustID"] = 0;//objCustomer[0].NextCustomerID;

            if (true)//objCustomer[0].PrevCustomerID == 0
            {
                imgDPrev.Visible = true;
                imgEPrev.Visible = false;
                lnkBtnPrev.Enabled = false;
            }
            if (true)//objCustomer[0].NextCustomerID == 0
            {
                imgDNext.Visible = true;
                imgENext.Visible = false;
                lnkBtnNext.Enabled = false;
            }

            if (customer.DoNotContactReasonNotesId.HasValue && customer.DoNotContactReasonNotesId > 0)
            {
                var notes = IoC.Resolve<INotesRepository>().Get(customer.DoNotContactReasonNotesId.Value);
                customerLogEditModel.DoNotContactReasonNotes = doNotContactReasonNotesSpan.InnerText = notes.Text;
            }

            if (customer.DoNotContactReasonId.HasValue && customer.DoNotContactReasonId > 0)
            {
                var item = (DoNotContactReason)customer.DoNotContactReasonId.Value;
                customerLogEditModel.DoNotContactReason = doNotContactReasonSpan.InnerText = item.GetDescription();
            }

            if (customer.DoNotContactTypeId.HasValue)
            {
                if ((customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotCall))
                {
                    doNotContactInfoImage.Visible = true;
                    doNotContact_phoneInfoImage.Visible = true;
                }

                if (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail)
                {
                    doNotMailInfoImage.Visible = true;
                    doNotMail_InfoImage.Visible = true;
                }
            }


            hfUserID.Value = customer.Id.ToString();

            spcutomerid.InnerHtml = customerId.ToString();

            CorporateTag.InnerText = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag;

            if (!customTags.IsNullOrEmpty())
            {
                var customerCustomTags = customTags.Select(x => x.Tag);
                CustomTag.InnerText = string.Join(",", customerCustomTags);

            }
            if (!string.IsNullOrEmpty(customer.Tag))
            {
                CorporateAccount corporateAccount = IoC.Resolve<ICorporateAccountRepository>().GetByTag(customer.Tag);
                if (corporateAccount != null)
                {
                    var accountAdditionalFields = IoC.Resolve<IAccountAdditionalFieldRepository>().GetByAccountId(corporateAccount.Id);
                    if (accountAdditionalFields != null && accountAdditionalFields.Any())
                    {

                        var additionalFields = accountAdditionalFields.Select(additionalField => new OrderedPair<string, string>(additionalField.DisplayName,
                                         GetCustomerAdditionalField(customer, additionalField.AdditionalFieldId)));
                        if (additionalFields != null && additionalFields.Any())
                        {
                            string additionalFieldHtml = string.Empty;
                            foreach (var item in additionalFields)
                            {
                                additionalFieldHtml += "<b>" + item.FirstValue + "</b>" + " : " + item.SecondValue + "<br/>";
                            }
                            ltrAdditionalField.Text = additionalFieldHtml;
                        }
                    }
                }
            }

            SetPreApprovedTest(customer.CustomerId);
            SetPreApprovedPackage(customer.CustomerId);
            //SetRequiredTest(customer.CustomerId);

            if (customer.DateOfBirth.HasValue)
                spdob.InnerHtml = customer.DateOfBirth.Value.ToString("MM/dd/yyyy");

            spCustomerName.InnerText = customer.Name.FullName;
            customerLogEditModel.UserName = spUserName.InnerText = customer.UserLogin.UserName;
            customerLogEditModel.Gender = spGender.InnerText = customer.Gender != Gender.Unspecified ? customer.Gender.ToString() : "-N/A-";
            customerLogEditModel.Email = spEmail.InnerText = customer.Email != null ? customer.Email.ToString() : "";
            if (customer.Email == null || string.IsNullOrEmpty(customer.Email.ToString()))
            {
                doNotContactInfoImage.Visible = false;
            }

            spAddress.InnerText = customerLogEditModel.Address = CommonCode.AddressSingleLine(customer.Address.StreetAddressLine1, customer.Address.StreetAddressLine2, customer.Address.City, customer.Address.State, customer.Address.ZipCode.ToString());
            if (((string)customerLogEditModel.Address).Length > 0)
            {
                customerLogEditModel.Address = ((string)customerLogEditModel.Address).Replace("&nbsp;", " ");
            }
            if (customer.HomePhoneNumber != null && !string.IsNullOrEmpty(customer.HomePhoneNumber.Number))
            {
                spPhoneNumber.InnerText = "Primary Contact Number:";
                customerLogEditModel.PrimaryContactNumber = spPhone.InnerText = customer.HomePhoneNumber.ToString().Length > 0 ? objCommonCode.FormatPhoneNumberGet(customer.HomePhoneNumber.ToString()) : "-N/A-";
            }
            else if (customer.MobilePhoneNumber != null && !string.IsNullOrEmpty(customer.MobilePhoneNumber.Number))
            {
                spPhoneNumber.InnerText = "Phone Number:";
                customerLogEditModel.PhoneNumber = spPhone.InnerText = customer.MobilePhoneNumber.ToString().Length > 0 ? objCommonCode.FormatPhoneNumberGet(customer.MobilePhoneNumber.ToString()) : "-N/A-";
            }
            else if (customer.OfficePhoneNumber != null && !string.IsNullOrEmpty(customer.OfficePhoneNumber.Number))
            {
                spPhoneNumber.InnerText = "Phone Number:";
                customerLogEditModel.PhoneNumber = spPhone.InnerText = customer.OfficePhoneNumber.ToString().Length > 0 ? objCommonCode.FormatPhoneNumberGet(customer.OfficePhoneNumber.ToString()) : "-N/A-";
            }

            customerLogEditModel.ConsentStatus = spConsentStatus.InnerText = (customer.PhoneCellConsentId == (long)PatientConsent.Unknown && customer.PhoneOfficeConsentId == (long)PatientConsent.Unknown && customer.PhoneHomeConsentId == (long)PatientConsent.Unknown) ? "No" : "Yes";

            customerLogEditModel.HomePhoneNumber = spHomePhoneNumber.InnerText = (customer.HomePhoneNumber != null && !string.IsNullOrEmpty(customer.HomePhoneNumber.Number)) ? objCommonCode.FormatPhoneNumberGet(customer.HomePhoneNumber.ToString()) : "-N/A-";
            customerLogEditModel.HomePhoneNumberConsent = spHomePhoneNumberConsent.InnerText = ((PatientConsent)customer.PhoneHomeConsentId).GetDescription();

            customerLogEditModel.OfficePhoneNumber = spOfficePhoneNumber.InnerText = (customer.OfficePhoneNumber != null && !string.IsNullOrEmpty(customer.OfficePhoneNumber.Number)) ? objCommonCode.FormatPhoneNumberGet(customer.OfficePhoneNumber.ToString()) : "-N/A-";
            customerLogEditModel.OfficePhoneNumberConsent = spOfficePhoneNumberConsent.InnerText = ((PatientConsent)customer.PhoneOfficeConsentId).GetDescription();

            customerLogEditModel.CellPhoneNumber = spCellPhoneNumber.InnerText = (customer.MobilePhoneNumber != null && !string.IsNullOrEmpty(customer.MobilePhoneNumber.Number)) ? objCommonCode.FormatPhoneNumberGet(customer.MobilePhoneNumber.ToString()) : "-N/A-";
            customerLogEditModel.CellPhoneNumberConsent = spCellPhoneNumberConsent.InnerText = ((PatientConsent)customer.PhoneCellConsentId).GetDescription();


            ViewState["DateCreated"] = customer.DateCreated;
            customerLogEditModel.SignUpDate = spSignUpDate.InnerHtml = customer.DateCreated.ToShortDateString();
            customerLogEditModel.TotalRevenue = "";

            var userLoginLog = IoC.Resolve<IUserLoginLogRepository>();

            var lastLoggedIn = userLoginLog.GetLastLoginTime(customer.UserLogin.Id);

            if (lastLoggedIn == null)
            {
                customerLogEditModel.LastLogin = spLastLogin.InnerText = "Never Logged In";
            }
            else
            {
                customerLogEditModel.LastLogin = spLastLogin.InnerText = lastLoggedIn.Value.ToShortDateString();
            }

            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
            var eventCustomers = eventCustomerRepository.GetbyCustomerId(customerId);
            string signupuser = "";

            if (eventCustomers != null && eventCustomers.Any())
            {
                var eventCustomer = eventCustomers.First();
                var registeredByOrgRoleUserId = eventCustomer.DataRecorderMetaData.DataRecorderCreator.Id;

                var orgUserRoleRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var orgRoleUser = orgUserRoleRepository.GetOrganizationRoleUser(registeredByOrgRoleUserId);

                var userRepository = IoC.Resolve<IUserRepository<User>>();
                var user = userRepository.GetUser(orgRoleUser.UserId);
                signupuser = user.Name.FullName;
            }


            string signup = "Internet";
            if (customer.AddedByRoleId.HasValue && (customer.AddedByRoleId == (long)Roles.CallCenterRep || GetParentRoleIdByRoleId(customer.AddedByRoleId.Value) == (long)Roles.CallCenterRep))
            {
                if (signupuser.Length > 0)
                {
                    signup = "Call Center Agent(" + signupuser + ")";
                }
                else
                {
                    signup = "Call Center Agent";
                }
            }
            else if (customer.AddedByRoleId.HasValue && (customer.AddedByRoleId == (long)Roles.Technician || GetParentRoleIdByRoleId(customer.AddedByRoleId.Value) == (long)Roles.Technician))
            {
                if (signupuser.Length > 0)
                {
                    signup = "Field Operation(" + signupuser + ")";
                }
                else
                {
                    signup = "Field Operation";
                }

            }
            else if (customer.AddedByRoleId.HasValue && (customer.AddedByRoleId == (long)Roles.FranchisorAdmin || GetParentRoleIdByRoleId(customer.AddedByRoleId.Value) == (long)Roles.FranchisorAdmin))
            {
                if (signupuser.Length > 0)
                {
                    signup = "Administrator(" + signupuser + ")";
                }
                else
                {
                    signup = "Administrator";
                }
            }
            else if (customer.AddedByRoleId.HasValue && (customer.AddedByRoleId == (long)Roles.SalesRep || GetParentRoleIdByRoleId(customer.AddedByRoleId.Value) == (long)Roles.SalesRep))
            {
                if (signupuser.Length > 0)
                {
                    signup = "Coordinator(" + signupuser + ")";
                }
                else
                {
                    signup = "Coordinator";
                }
            }
            customerLogEditModel.SignUp = spSignUp.InnerText = signup;
            customerLogEditModel.MarketingSource = marketingSourceSpan.InnerText = !string.IsNullOrEmpty(customer.MarketingSource)
                                                ? customer.MarketingSource
                                                : "N/A";
            customerLogEditModel.RequestedNewsletter = requestedNewsletterSpan.InnerText;
            if (!string.IsNullOrEmpty(customer.LastScreeningDate))
                customerLogEditModel.LastScreeningDate = LastScreeningDateSpan.InnerText = customer.LastScreeningDate;
            else
                LastScreeningDateContainerSpan.Style.Add(HtmlTextWriterStyle.Display, "none");

            var settings = IoC.Resolve<ISettings>();

            if (settings.CaptureEmployeeId || settings.CaptureInsuranceId)
            {
                if (settings.CaptureEmployeeId)
                    customerLogEditModel.EmployeeId = EmployeeIdSpan.InnerText = string.IsNullOrEmpty(customer.EmployeeId.Trim()) ? "Not Available" : customer.EmployeeId.Trim();
                else
                    EmployeeIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");

                if (settings.CaptureInsuranceId)
                    customerLogEditModel.InsuranceId = InsuranceIdSpan.InnerText = string.IsNullOrEmpty(customer.InsuranceId.Trim()) ? "Not Available" : customer.InsuranceId.Trim();
                else
                    InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
                EmployeeIdInsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");

            customerLogEditModel.EmployeeId = HICNNumber.InnerText = string.IsNullOrWhiteSpace(customer.Hicn) ? "N/A" : customer.Hicn.Trim();
            customerLogEditModel.MbiNumber = MBINumber.InnerText = string.IsNullOrWhiteSpace(customer.Mbi) ? "N/A" : customer.Mbi.Trim();

            //var toolTipRepository = IoC.Resolve<IToolTipRepository>();
            //var insuranceIdLabel = toolTipRepository.GetToolTipContentByTag(ToolTipType.InsuranceIdLabel);
            //insuranceIdLabel = string.IsNullOrEmpty(insuranceIdLabel) ? "Insurance Id:" : (insuranceIdLabel + ":");
            InsuranceIdLabel.InnerHtml = "Member Id:";//insuranceIdLabel;

            customerLogEditModel.IsEliglbe = IsEligibleSpan.InnerText = "N/A";
            IsEligibleCustomer = string.Empty;

            if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
            {
                customerLogEditModel.IsEliglbe = IsEligibleSpan.InnerText = customerEligibility.IsEligible.Value ? EligibleStatus.Yes.ToString() : EligibleStatus.No.ToString();
                IsEligibleCustomer = customerLogEditModel.IsEliglbe;
            }

            if (customer.ActivityId.HasValue)
            {
                var activityType = IoC.Resolve<IActivityTypeRepository>().GetById(customer.ActivityId.Value);
                activity.InnerText = activityType.Name;
            }
            else
                activity.InnerText = "N/A";

            GroupName.InnerText = string.IsNullOrEmpty(customer.GroupName) ? "N/A" : customer.GroupName;
            AcesId.InnerText = string.IsNullOrWhiteSpace(customer.AcesId) ? "N/A" : customer.AcesId;
            ProductType.InnerText = customer.ProductTypeId.HasValue && customer.ProductTypeId.Value > 0 ? ((ProductType)customer.ProductTypeId.Value).GetDescription() : "N/A";

            var primaryCarePhysicianRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();
            var pcp = primaryCarePhysicianRepository.Get(customerId);
            if (pcp != null)
            {
                customerLogEditModel.PcpName = PcpName.InnerText = pcp.Name.FullName;
                customerLogEditModel.PcpPhoneNumber =
                    PcpPhoneNumber.InnerText = pcp.Primary != null ? pcp.Primary.ToString() : "N/A";
                if (pcp.Address != null)
                {
                    customerLogEditModel.PcpAddress =
                        PcpAddress.InnerText =
                            CommonCode.AddressSingleLine(pcp.Address.StreetAddressLine1, pcp.Address.StreetAddressLine2,
                                pcp.Address.City, pcp.Address.State, pcp.Address.ZipCode.Zip);
                }
                else
                {
                    customerLogEditModel.PcpAddress = PcpAddress.InnerText = "N/A";
                }
            }

            var changePasswordUrl = "/App/Common/ChangePassword.aspx?UserID=" + customer.Id + "&UserEmail=" + customer.Email;
            achangepassword.HRef = "javascript:popupmenu('" + changePasswordUrl + "','392','200');";
            achangepassword.Attributes.Add("onclick", "return confirm('Are you sure want to reset password of this user?');");

            if (customer.Email == null || string.IsNullOrEmpty(customer.Email.ToString()))
                lnksendMail.Attributes.Add("onClick", "alert('Customer has not provided his Email ID while Registering.');return false;");
            else
                lnksendMail.OnClientClick = "return confirm('Do you want to send a welcome mail to " + customer.Name.FullName.Replace("'", "\\'") + " ?');";


            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                //splnkErase.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                //splnkErase.Style.Add(HtmlTextWriterStyle.Display, "block");
                //lnkErase.OnClientClick = "return confirm('Are you sure want to erase all the information of " + username.Replace("'", "\\'") + " ?');";
                //lnkErase.CommandName = "Erase";


                pAnswer.Style[HtmlTextWriterStyle.Display] = "block";
                pQuestion.Style[HtmlTextWriterStyle.Display] = "block";
                customerLogEditModel.Question = spQuestion.InnerText = customer.UserLogin.HintQuestion;
                spAnswer.InnerText = customer.UserLogin.HintAnswer;
            }
            else
            {
                splnkErase.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                splnkErase.Style.Add(HtmlTextWriterStyle.Display, "none");
            }



            if (customer.UserLogin.IsActive)//objCustomer[0].User.HomeAddress.Active)
            {
                lnkDisable.OnClientClick = "return confirm('Are you sure want to disable this user?');";
                lnkDisable.Text = "Disable";
                lnkDisable.CommandName = "Disable";
            }
            else
            {
                lnkDisable.OnClientClick = "return confirm('Are you sure want to enable this user?');";
                lnkDisable.Text = "Enable";
                lnkDisable.CommandName = "Enable";
            }

            ChangeUserNameAnchor.Attributes.Add("onclick", "OpenPopUpforChangeUserName('" + HttpUtility.HtmlEncode(customer.Id) + "');");

            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                aeditcustomer.HRef = "/App/Franchisor/FranchisorEditCustomer.aspx?UserID=" + customer.Id + "&CustomerID=" + CustomerId;
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Display, "none");
                spDisable.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                spDisable.Style.Add(HtmlTextWriterStyle.Display, "block");
                spResetPassword.Style.Add(HtmlTextWriterStyle.Visibility, "block");
                lnkForceChangePassword.Style.Add(HtmlTextWriterStyle.Display, "block");
                //lnkForceSecurityQuesChange.Style.Add(HtmlTextWriterStyle.Display, "block");
                lnkResetLoginCount.Style.Add(HtmlTextWriterStyle.Display, "block");

                if (!customTags.IsNullOrEmpty())
                {
                    lnkDeleteCustomTags.Style.Add(HtmlTextWriterStyle.Display, "block");
                }

            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                aeditcustomer.HRef = "/App/Franchisee/FranchiseeEditCustomer.aspx?UserID=" + customer.Id + "&CustomerID=" + CustomerId;
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Display, "none");
                spDisable.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                spDisable.Style.Add(HtmlTextWriterStyle.Display, "block");
                spResetPassword.Style.Add(HtmlTextWriterStyle.Visibility, "block");
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                aeditcustomer.HRef = "/App/Franchisee/SalesRep/SalesRepEditCustomer.aspx?UserID=" + customer.Id + "&CustomerID=" + CustomerId;
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Display, "none");
                spDisable.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                spDisable.Style.Add(HtmlTextWriterStyle.Display, "none");
                spResetPassword.Style.Add(HtmlTextWriterStyle.Visibility, "block");
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician))
            {
                aeditcustomer.HRef = "/App/Franchisee/Technician/TechnicianEditCustomer.aspx?UserID=" + customer.Id + "&CustomerID=" + CustomerId;
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Display, "block");
                spDisable.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                spDisable.Style.Add(HtmlTextWriterStyle.Display, "none");
                spResetPassword.Style.Add(HtmlTextWriterStyle.Visibility, "block");
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterManager) || CurrentOrgRole.CheckRole((long)Roles.CallCenterRep))
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Display, "none");

                    aeditcustomer.HRef = "/App/CallCenter/CallCenterRep/CallCenterRepEditCustomer.aspx?UserID=" + customer.Id + "&CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId;
                }
                else
                {
                    spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    spLnkRegBtn.Style.Add(HtmlTextWriterStyle.Display, "block");
                    aeditcustomer.HRef = "/App/CallCenter/CallCenterRep/CallCenterRepEditCustomer.aspx?UserID=" + customer.Id + "&CustomerID=" + CustomerId + "&guid=" + GuId;
                }

                spDisable.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                spDisable.Style.Add(HtmlTextWriterStyle.Display, "none");
                spResetPassword.Style.Add(HtmlTextWriterStyle.Display, "block");
                lnkResetLoginCount.Style.Add(HtmlTextWriterStyle.Display, "block");
            }


            dvNoRecordFound.Style["display"] = "none";
            dvCustomerDetails.Style["display"] = "block";
        }
        else
        {
            dvCustomerDetails.Style["display"] = "none";
            dvNoRecordFound.Style["display"] = "block";
        }
    }

    private long GetParentRoleIdByRoleId(long roleId)
    {
        var roleRepository = IoC.Resolve<IRoleRepository>();
        var role = roleRepository.GetByRoleId(roleId);

        if (role == null) return 0;

        return role.ParentId ?? 0;
    }

    public string GetImageUrlforEvaluationState(int evaluationStatus, bool isPartial, bool isPdfGenerated)
    {
        string imageUrl = "";

        switch (evaluationStatus)
        {
            case 2:
            case 3:
                if (isPartial)
                    imageUrl = "/App/Images/Customer/customerscreen-icon" + evaluationStatus + "p.gif";
                else
                    imageUrl = "/App/Images/Customer/customerscreen-icon" + evaluationStatus + ".gif";
                break;

            case 5:
                if (!isPartial)
                    imageUrl = "/App/Images/Customer/customerscreen-icon5.gif";
                else
                    imageUrl = "/App/Images/Customer/customerscreen-icon-red5.gif";
                break;

            case 6:
                if (isPdfGenerated)
                    imageUrl = "/App/Images/Customer/customerscreen-icon6.gif";
                else
                    imageUrl = "/App/Images/Customer/customerscreen-icon-red6.gif";
                break;

            default:
                imageUrl = "/App/Images/Customer/customerscreen-icon" + evaluationStatus + ".gif";
                break;
        }

        return imageUrl;
    }

    /// <summary>
    /// the customer history is filled with data from the database
    /// </summary>
    /// <param name="customerid"></param>
    private void LoadGrid(long customerid)
    {
        //ToDo: Refactoring is not done completly.
        // Load Role Info        
        var totalRevenue = 0m;

        var customerEventRegistrationViewDataRepository = new CustomerEventRegistrationViewDataRepository();
        var customerEventRegistrationSummary = customerEventRegistrationViewDataRepository.GetCustomerEventRegistrationViewData(customerid);

        var dteventcustomer = new DataTable();
        dteventcustomer.Columns.Add("EventName");
        dteventcustomer.Columns.Add("EventID");
        dteventcustomer.Columns.Add("HostName");
        dteventcustomer.Columns.Add("PodName");
        dteventcustomer.Columns.Add("Address");
        dteventcustomer.Columns.Add("Appointment");
        dteventcustomer.Columns.Add("SignIN");
        dteventcustomer.Columns.Add("SignOut");
        dteventcustomer.Columns.Add("RegisterDate");
        dteventcustomer.Columns.Add("ShowUp");
        dteventcustomer.Columns.Add("Package");
        dteventcustomer.Columns.Add("Cost");
        dteventcustomer.Columns.Add("Coupon");
        dteventcustomer.Columns.Add("Discount");
        dteventcustomer.Columns.Add("Payment");
        dteventcustomer.Columns.Add("SignUP");
        dteventcustomer.Columns.Add("Source");
        dteventcustomer.Columns.Add("Franchisee");
        dteventcustomer.Columns.Add("EventCustomerID");
        dteventcustomer.Columns.Add("EventDate");
        dteventcustomer.Columns.Add("UserAddress");
        dteventcustomer.Columns.Add("City");
        dteventcustomer.Columns.Add("PackageID");
        dteventcustomer.Columns.Add("State");
        dteventcustomer.Columns.Add("ZipCode");
        dteventcustomer.Columns.Add("AppointmentID");
        dteventcustomer.Columns.Add("IsPaid", typeof(bool));
        dteventcustomer.Columns.Add("TotalAmount");
        dteventcustomer.Columns.Add("CustomerEventTestID");
        dteventcustomer.Columns.Add("TestStatus");
        dteventcustomer.Columns.Add("IsPaymentRefunded", typeof(bool));
        dteventcustomer.Columns.Add("IsAuthorized", typeof(bool));
        dteventcustomer.Columns.Add("EventStatus");
        dteventcustomer.Columns.Add("IsResultPDFGenerated");
        dteventcustomer.Columns.Add("IsClinicalFormGenerated");
        dteventcustomer.Columns.Add("OrderId");
        dteventcustomer.Columns.Add("ShippingDetail");
        dteventcustomer.Columns.Add("TotalPayment");
        dteventcustomer.Columns.Add("TotalShippingAmount");
        dteventcustomer.Columns.Add("ActiveOrderDetailId");
        dteventcustomer.Columns.Add("AdditionalTest");
        dteventcustomer.Columns.Add("CorporateAccountTag");
        dteventcustomer.Columns.Add("IsHealthPlanEvent");
        dteventcustomer.Columns.Add("MedicareVisitId");
        dteventcustomer.Columns.Add("ShowHraQuestionnaire");
        dteventcustomer.Columns.Add("IsNoShow");

        var accountRepository = IoC.Resolve<ICorporateAccountRepository>();


        foreach (var customerEventRegistration in customerEventRegistrationSummary)
        {
            //  string role = "Internet";//for registration from public site
            //Todo: changed from old options "CallenterRep";, "Internet(Self Account)";,"Technician"; to WalkIn, Online , CCRep. switch case can be used to change.
            var role = customerEventRegistration.SignUpMode.GetDescription();

            string couponcode = "-N/A-";
            string couponamout = string.Empty;


            if (customerEventRegistration.SourceCodeId != 0)
            {
                couponcode = customerEventRegistration.SourceCode + "/";
                couponamout = customerEventRegistration.SourceCodeDiscount.ToString();

            }

            var podrepository = IoC.Resolve<IPodRepository>();
            var pods = podrepository.GetPodsForEvent(customerEventRegistration.EventId);

            string podNames = pods != null ? string.Join(", ", pods.Select(pod => pod.Name)) : "-N/A-";


            string checkin = "-N/A-";
            string checkout = "-N/A-";
            string showup = "No";

            if (!customerEventRegistration.NoShow && (!Convert.ToDateTime(customerEventRegistration.CheckInTime).ToShortTimeString().Equals("12:00 AM")) && (!Convert.ToDateTime(customerEventRegistration.CheckOutTime).ToShortTimeString().Equals("12:00 AM")))
            {
                showup = "Yes";
            }

            if (!Convert.ToDateTime(customerEventRegistration.CheckInTime).ToShortTimeString().Equals("12:00 AM"))
            {
                checkin = Convert.ToDateTime(customerEventRegistration.CheckInTime).ToShortTimeString();
            }
            if (!Convert.ToDateTime(customerEventRegistration.CheckOutTime).ToShortTimeString().Equals("12:00 AM"))
            {
                checkout = Convert.ToDateTime(customerEventRegistration.CheckOutTime).ToShortTimeString();
            }

            string payment = "Pending";

            //TODo: legacy of old order system. leave it as it is. didnt have any impact on links.
            bool IsPaymentRefunded = false;

            totalRevenue += customerEventRegistration.TotalPayment;

            string eventStatus = GetEventStatus((int)customerEventRegistration.EventStatus, customerEventRegistration.EventDate);

            var strAddress = customerEventRegistration.EventAddress.ToString();
            var account = accountRepository.GetbyEventId(customerEventRegistration.EventId);
            var corporateAccountTag = "";
            bool isHealthPlanEvent = false;
            bool showHraQuestionnaire = false;

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (account != null && customerEventRegistration != null)
            {
                var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, customerEventRegistration.EventDate);
            }

            if (account != null)
            {
                corporateAccountTag = account.Tag;
                isHealthPlanEvent = account.IsHealthPlan;
                showHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire ? true : false;
            }

            dteventcustomer.Rows.Add(new object[]
                                         {
                                             customerEventRegistration.EventName,
                                             customerEventRegistration.EventId,
                                             customerEventRegistration.HostOrganizationName, podNames,
                                             strAddress,
                                             Convert.ToDateTime(customerEventRegistration.AppointmentStartTime).
                                                 ToShortTimeString(),
                                             checkin,
                                             checkout,
                                             String.Format("{0:MM/dd/yyyy}", customerEventRegistration.EventSignupDate),
                                             showup,
                                             customerEventRegistration.PackageName,
                                             customerEventRegistration.PackagePrice,
                                             couponcode,
                                             couponamout,
                                             payment,
                                             role,
                                             !string.IsNullOrEmpty(customerEventRegistration.MarketingSource)?customerEventRegistration.MarketingSource:"N/A",
                                             customerEventRegistration.FranchiseeName,
                                             //Todo: need to check again. from dal it was replaced with EventCustomerId and here again changed. 1+1 mistake correct the logic
                                             customerEventRegistration.EventCustomerId,
                                             
                                             String.Format("{0:MM/dd/yyyy}", customerEventRegistration.EventDate),
                                             "objeventcustomer[icount].Customer.User.HomeAddress.Address1",
                                             "objeventcustomer[icount].Customer.User.HomeAddress.City",
                                             customerEventRegistration.PackageId,
                                             "objeventcustomer[icount].Customer.User.HomeAddress.State",
                                             "objeventcustomer[icount].Customer.User.HomeAddress.Zip",
                                             customerEventRegistration.AppointmentId,
                                             customerEventRegistration.IsPaid,
                                             customerEventRegistration.EffectiveOrderPrice,

                                             //Todo: need to check again. from dal it was replaced with EventCustomerId and here again changed. 1+1 mistake correct the logic
                                             customerEventRegistration.CustomerEventTestId,
                                             //todo: insteda of geting individual state of test get the status of customer
                                             (int) customerEventRegistration.ResultStatus,
                                             //todo: need to check it again
                                             IsPaymentRefunded,
                                             customerEventRegistration.IsAuthorized,
                                             eventStatus,
                                             
                                             customerEventRegistration.IsResultPdfgenerated,
                                             customerEventRegistration.IsClinicalFormPdfGenerated,
                                             customerEventRegistration.OrderId,
                                             //Todo:add shippingdetail flag in view and generate llblgen
                                             customerEventRegistration.IsShippingApplied,
                                             customerEventRegistration.TotalPayment,
                                             // ToDo:uncomment once llblgen is done
                                             customerEventRegistration.TotalShippingCost,
                                             customerEventRegistration.OrderDetailId,customerEventRegistration.AdditinalTest,
                                             corporateAccountTag,
                                             isHealthPlanEvent,
                                             customerEventRegistration.AwvVisitId,
                                             showHraQuestionnaire ,
                                             customerEventRegistration.NoShow
                                         });

            var eventAttended = new EventsAttendedListModel()
            {
                EventName = customerEventRegistration.EventName,
                EventID = customerEventRegistration.EventId,
                HostName = customerEventRegistration.HostOrganizationName,
                PodName = podNames,
                Address = strAddress,
                Appointment = Convert.ToDateTime(customerEventRegistration.AppointmentStartTime).ToShortTimeString(),
                SignIN = checkin,
                SignOut = checkout,
                RegisterDate = String.Format("{0:MM/dd/yyyy}", customerEventRegistration.EventSignupDate),
                ShowUp = showup,
                Package = customerEventRegistration.PackageName,
                Cost = customerEventRegistration.PackagePrice,
                Coupon = couponcode,
                Discount = couponamout,
                Payment = payment,
                SignUP = role,
                Source = !string.IsNullOrEmpty(customerEventRegistration.MarketingSource) ? customerEventRegistration.MarketingSource : "N/A",
                Franchisee = customerEventRegistration.FranchiseeName,
                EventCustomerID = customerEventRegistration.EventCustomerId,
                EventDate = String.Format("{0:MM/dd/yyyy}", customerEventRegistration.EventDate),
                UserAddress = "",
                City = "",
                PackageID = customerEventRegistration.PackageId,
                State = "",
                ZipCode = "",
                AppointmentID = customerEventRegistration.AppointmentId,
                IsPaid = customerEventRegistration.IsPaid,
                TotalAmount = customerEventRegistration.EffectiveOrderPrice,
                CustomerEventTestID = customerEventRegistration.CustomerEventTestId,
                TestStatus = customerEventRegistration.ResultStatus.ToString(),
                IsPaymentRefunded = IsPaymentRefunded,
                IsAuthorized = customerEventRegistration.IsAuthorized,
                EventStatus = eventStatus,
                IsResultPDFGenerated = customerEventRegistration.IsResultPdfgenerated,
                IsClinicalFormGenerated = customerEventRegistration.IsClinicalFormPdfGenerated,
                OrderId = customerEventRegistration.OrderId,
                ShippingDetail = customerEventRegistration.IsShippingApplied,
                TotalPayment = customerEventRegistration.TotalPayment,
                TotalShippingAmount = customerEventRegistration.TotalShippingCost,
                ActiveOrderDetailId = customerEventRegistration.OrderDetailId,
                AdditionalTest = customerEventRegistration.AdditinalTest,
            };

            _eventsAttendedList.Add(eventAttended);
        }

        //    }
        //}
        ViewState["DSGRD"] = dteventcustomer;
        if (dteventcustomer.Rows.Count > 0)
        {
            customerLogEditModel.TotalRevenue = spRevenue.InnerText = totalRevenue > 0 ? totalRevenue.ToString("C2") : "-N/A-";

            divEventsAttended.Visible = true;
        }
        else
        {
            divEventsAttended.Visible = false;
        }
        grdCustomerEvents.DataSource = dteventcustomer;
        grdCustomerEvents.DataBind();
    }

    private class EventsAttendedListModel
    {
        public string EventName { get; set; }
        public long EventID { get; set; }

        public string HostName { get; set; }
        public string PodName { get; set; }
        public string Address { get; set; }
        public string Appointment { get; set; }
        public string SignIN { get; set; }
        public string SignOut { get; set; }
        public string RegisterDate { get; set; }
        public string ShowUp { get; set; }
        public string Package { get; set; }
        public decimal Cost { get; set; }
        public string Coupon { get; set; }
        public string Discount { get; set; }
        public string Payment { get; set; }
        public string SignUP { get; set; }
        public string Source { get; set; }
        public string Franchisee { get; set; }
        public long EventCustomerID { get; set; }
        public string EventDate { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public long PackageID { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public long AppointmentID { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalAmount { get; set; }
        public long CustomerEventTestID { get; set; }
        public string TestStatus { get; set; }
        public bool IsPaymentRefunded { get; set; }
        public bool IsAuthorized { get; set; }
        public string EventStatus { get; set; }
        public bool IsResultPDFGenerated { get; set; }
        public bool IsClinicalFormGenerated { get; set; }
        public long OrderId { get; set; }
        public bool ShippingDetail { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalShippingAmount { get; set; }
        public long ActiveOrderDetailId { get; set; }
        public string AdditionalTest { get; set; }
    }

    private class CommunicationListModel
    {
        public long NotificationID { get; set; }
        public string Name { get; set; }
        public string NotificationTypeName { get; set; }
        public string NotificationMedium { get; set; }
        public string ServiceStatus { get; set; }
        public string ServicedBy { get; set; }
        public string ServicedDate { get; set; }
        public string CallNotes { get; set; }
        public string CCRep { get; set; }
        public string CallType { get; set; }
        public string CallDuration { get; set; }
        public string CallOutcome { get; set; }
        public string Disposition { get; set; }

        public string Reason { get; set; }
        public string DirectMailType { get; set; }
        public string IsCallQueueCall { get; set; }
    }
    private void SetPaymentAndShippingAnchors(GridViewRowEventArgs e, long customerId)
    {
        try
        {
            if (Customer == null) return;

            string rowindex = (e.Row.DataItemIndex + 2) < 10 ? "ctl0" + Convert.ToString(e.Row.DataItemIndex + 2) : "ctl" + Convert.ToString(e.Row.DataItemIndex + 2);

            var dteventcustomer = (DataTable)ViewState["DSGRD"];
            var drvCurrent = dteventcustomer.DefaultView[e.Row.DataItemIndex]; // current row from datatable in view state, corresponding to the current grid row.

            string customerName = Customer.Name.FullName.Replace("'", "\\'").Replace("@", "\\'").Replace("\"", "\\\"");

            var orderId = Convert.ToInt64(drvCurrent["OrderId"]);
            var activeOrderId = Convert.ToInt64(drvCurrent["ActiveOrderDetailId"]);

            var isShippingApplicable = Convert.ToBoolean(drvCurrent["ShippingDetail"]);
            var totalShipping = Convert.ToDecimal(drvCurrent["TotalShippingAmount"]);
            var eventDate = Convert.ToDateTime(drvCurrent["EventDate"]);
            var eventId = Convert.ToInt64(drvCurrent["EventID"]);

            if (orderId != 0)
            {
                var order = IoC.Resolve<IOrderRepository>().GetOrder(orderId);
                var totalAmount = order.DiscountedTotal.ToString("0.00");
                var amountPaid = order.TotalAmountPaid.ToString("0.00");
                var amountDue = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");

                var paymentLinkAnchor =
                    e.Row.FindControl("PaymentLinkAnchor") as HtmlAnchor;
                if (paymentLinkAnchor != null)
                {
                    var functionToCall = "javascript:return ShowOrderDetailPopUp(" +

                                         orderId + "," + totalAmount + "," + amountPaid + "," +
                                         amountDue + ",'" + customerName + "'," +
                                         customerId + ");";
                    paymentLinkAnchor.Attributes.Add("onClick", functionToCall);
                    paymentLinkAnchor.HRef = "javascript:void(0);";
                }

                var shippingDetailAnchor =
                    e.Row.FindControl("ShippingDetailAnchor") as HtmlAnchor;
                var shippingDetailSpan = e.Row.FindControl("ShippingDetailSpan") as HtmlGenericControl;


                if (shippingDetailAnchor != null && shippingDetailSpan != null && activeOrderId != 0 && isShippingApplicable)
                {
                    var shippingDetailTotalCost = totalShipping;

                    var functionToCall = "javascript:return ShowShippingDetailsDialog(" +
                                         activeOrderId + "," + shippingDetailTotalCost + ");";
                    shippingDetailAnchor.Attributes.Add("onClick", functionToCall);
                    shippingDetailAnchor.Visible = true;
                    shippingDetailAnchor.InnerHtml = "<strong>Shipping Details</strong>";
                    shippingDetailAnchor.Visible = true;
                }
                else if (shippingDetailAnchor != null)
                {
                    shippingDetailSpan.InnerText = "-N/A-";
                    shippingDetailAnchor.Visible = false;
                }

                var updateShippingStatusSpan = e.Row.FindControl("UpdateShippingStatusSpan") as HtmlGenericControl;
                if (updateShippingStatusSpan != null)
                {
                    if (isShippingApplicable)
                    {
                        updateShippingStatusSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                        var updateShippingStatusAnchor = e.Row.FindControl("UpdateShippingStatusAnchor") as HtmlAnchor;
                        if (updateShippingStatusAnchor != null)
                        {
                            if (eventDate > DateTime.Now)
                                updateShippingStatusAnchor.Attributes.Add("onclick", "ShowUpdateShippingMessageForFutureEvent();");
                            else
                                updateShippingStatusAnchor.Attributes.Add("onclick", "LoadShippingForUpdateStatus('" + eventId + "','" + customerId + "');");
                        }
                    }
                    else
                        updateShippingStatusSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
            }
        }
        catch { }
    }

    protected string Action(object status, object notificationid, object notificationmedium)
    {
        if (CurrentRole == Roles.Technician)
        {
            return "-N/A-";
        }
        if (notificationmedium.ToString() == "Phone")
        {
            return "-N/A-";
        }
        else if (status.ToString() != "-N/A-" && (long)notificationid > 0)
            return "<a href='/App/Franchisor/Admin/ViewNotification.aspx?mode=2&NotificationID=" + notificationid.ToString() + "' />View</a>";
        else
            return "-N/A-";
    }

    private void StartCall(long calledCustomerid)
    {
        // we are not setting time here as this is a new call only for system
        if (Customer == null) return;

        var newCall = new Call();
        var repository = new CallCenterCallRepository();

        if (CallId.HasValue)
        {
            var call = repository.GetById(CallId.Value);

            newCall.CalledInNumber = call.CalledInNumber;
            newCall.CallerNumber = call.CallerNumber;
            newCall.IsIncoming = call.IsIncoming;
        }

        newCall.CreatedByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        newCall.StartTime = DateTime.Now;
        newCall.CallDateTime = DateTime.Now;
        newCall.DateCreated = DateTime.Now;
        newCall.DateModified = DateTime.Now;
        newCall.CalledCustomerId = calledCustomerid;

        if (!string.IsNullOrEmpty(Customer.Tag))
        {
            var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = accountRepository.GetByTag(Customer.Tag);
            newCall.HealthPlanId = account.Id;
        }

        newCall = repository.Save(newCall);
        CallId = newCall.Id;
    }

    private void EndCall(ECall objCall)
    {
        objCall.TimeEnd = DateTime.Now.ToString();

        var callcenterDal = new CallCenterDAL();
        callcenterDal.UpdateCall(objCall);
    }

    private string GetEventStatus(int eventStatusNumber, DateTime strEventDate)
    {
        string strEventStatus = string.Empty;
        //if (!string.IsNullOrEmpty(strEventDate))
        //{
        // If Active then only [Scheduled/Conducted/Scheduled Today].
        if (Convert.ToString(Enum.Parse(typeof(EventStatus), eventStatusNumber.ToString())).Equals("Active"))
        {
            if ((strEventDate).ToString("MM/dd/yyyy").Equals(DateTime.Now.ToString("MM/dd/yyyy")))
            {
                strEventStatus = "Scheduled Today";
            }
            else if (strEventDate > DateTime.Now)
            {
                strEventStatus = "Scheduled";
            }
            else if (strEventDate < DateTime.Now)
                strEventStatus = "Conducted";
        }
        //Otherwise Suspended/Calcelled.
        else
        {
            strEventStatus = Convert.ToString(Enum.Parse(typeof(EventStatus), eventStatusNumber.ToString()));
        }
        //}
        return strEventStatus;
    }

    #region Communication Tab
    private void DisplayCummunication()
    {
        if (CustomerId > 0)
        {
            var objFranchisorDal = new FranchisorDAL();
            var listNotificationOther = objFranchisorDal.GetNotificationOtherCustomers(CustomerId);
            Falcon.Entity.Franchisor.ENotificationOther[] objENotificationOther = null;
            if (listNotificationOther != null)
                objENotificationOther = listNotificationOther.ToArray();
            var dtNotification = new DataTable();

            dtNotification.Columns.Add("NotificationID", typeof(Int64));
            dtNotification.Columns.Add("Name");
            dtNotification.Columns.Add("NotificationTypeName");
            dtNotification.Columns.Add("NotificationMedium");
            dtNotification.Columns.Add("ServiceStatus");
            dtNotification.Columns.Add("ServicedBy");
            dtNotification.Columns.Add("ServicedDate");
            dtNotification.Columns.Add("CallNotes");
            dtNotification.Columns.Add("CCRep");
            dtNotification.Columns.Add("CallType");
            dtNotification.Columns.Add("CallDuration");
            dtNotification.Columns.Add("CallOutcome");
            dtNotification.Columns.Add("Disposition");
            dtNotification.Columns.Add("Reason");
            dtNotification.Columns.Add("IsInvalidAddress");
            dtNotification.Columns.Add("IsCallQueueCall");


            if (objENotificationOther != null)
            {
                for (int icount = 0; icount < objENotificationOther.Length; icount++)
                {
                    string CallDuration = "";
                    if (!string.IsNullOrEmpty(objENotificationOther[icount].CallDuration))
                    {
                        int hr = Convert.ToDateTime(objENotificationOther[icount].CallDuration).Hour;
                        int min = Convert.ToDateTime(objENotificationOther[icount].CallDuration).Minute;
                        int sec = Convert.ToDateTime(objENotificationOther[icount].CallDuration).Second;
                        CallDuration = Convert.ToString((hr * 60) + min) + " min " + sec.ToString() + " sec ";
                    }
                    else
                    {
                        CallDuration = "-N/A-";
                    }
                    string NotificationDate = "";
                    if (objENotificationOther[icount].NotificationDate != "")
                    {
                        NotificationDate = Convert.ToDateTime(objENotificationOther[icount].NotificationDate).ToString("MMM dd yyyy") + "<br />" + Convert.ToDateTime(objENotificationOther[icount].NotificationDate).ToString("hh:mm tt");
                    }
                    else
                    {
                        NotificationDate = "-N/A-";
                    }
                    string CallType = "";
                    if (objENotificationOther[icount].CallType != "")
                    {
                        CallType = "<b>" + objENotificationOther[icount].CallType + "</b>";
                    }
                    else
                    {
                        CallType = "-N/A-";
                    }

                    var callStatus = "-N/A-";

                    if (objENotificationOther[icount].CallOutcome > 0)
                    {
                        CallStatus status;
                        Enum.TryParse(objENotificationOther[icount].CallOutcome.ToString(), out status);
                        if (Enum.IsDefined(typeof(CallStatus), status))
                        {
                            callStatus = status.GetDescription();
                        }
                    }
                    var disposition = "-N/A-";
                    var notInterestedReason = string.Empty;
                    if (!string.IsNullOrEmpty(objENotificationOther[icount].Disposition))
                    {
                        ProspectCustomerTag dispositionEnum;
                        Enum.TryParse(objENotificationOther[icount].Disposition, out dispositionEnum);
                        if (Enum.IsDefined(typeof(ProspectCustomerTag), dispositionEnum))
                        {
                            disposition = dispositionEnum.GetDescription();
                        }

                        if (dispositionEnum == ProspectCustomerTag.NotInterested)
                        {
                            notInterestedReason = "N/A";
                            if (objENotificationOther[icount].NotInterestedReasonId > 0)
                            {
                                notInterestedReason = ((NotInterestedReason)objENotificationOther[icount].NotInterestedReasonId).GetDescription();
                            }
                        }
                    }

                    string CallCenterNotes = string.Empty;
                    if (objENotificationOther[icount].CallId > 0)
                    {
                        ICallCenterNotesRepository _callCenterNotesRepository = new CallCenterNotesRepository();
                        var callCenterNotes = _callCenterNotesRepository.GetCallCenterNotesByCallId(objENotificationOther[icount].CallId);

                        if (callCenterNotes != null)
                        {
                            StringBuilder sbNotes = new StringBuilder();
                            foreach (var item in callCenterNotes)
                            {
                                sbNotes.AppendFormat("<div style='border-bottom: solid 1px; padding-bottom:2px;'> On [{0}]:</div>", item.DateCreated.ToShortDateString());
                                sbNotes.AppendFormat("<div>{0}</div> <br />", item.Notes);
                            }
                            CallCenterNotes = sbNotes.ToString();
                        }
                    }

                    var invalidAddressNotes = "-N/A-";

                    if (objENotificationOther[icount].IsInvalidAddress != null && objENotificationOther[icount].IsInvalidAddress.Value)
                    {
                        invalidAddressNotes = objENotificationOther[icount].Notes;

                    }

                    //Convert.ToDateTime(objENotificationOther[icount].NotificationDate).ToString("MM dd yyyy") + "<br />" + Convert.ToDateTime(objENotificationOther[icount].NotificationDate).ToString("hh:mm tt"),
                    dtNotification.Rows.Add(new object[] { objENotificationOther[icount].NotificationID, 
                                                            objENotificationOther[icount].CustomerName, 
                                                            objENotificationOther[icount].NotificationType, 
                                                            objENotificationOther[icount].NotificationMedium, 
                                                            objENotificationOther[icount].ServiceStatus, 
                                                            objENotificationOther[icount].ServicedBy, 
                                                            NotificationDate,                                                            
                                                            CallCenterNotes,
                                                            objENotificationOther[icount].CCRep,
                                                            CallType,
                                                            CallDuration,
                                                            callStatus,
                                                            disposition,
                                                            notInterestedReason,
                                                            invalidAddressNotes,
                                                            objENotificationOther[icount].IsCallQueueCall,
                                                            
                    });

                    _communicationList.Add(new CommunicationListModel()
                    {
                        NotificationID = objENotificationOther[icount].NotificationID,
                        Name = objENotificationOther[icount].CustomerName,
                        NotificationTypeName = objENotificationOther[icount].NotificationType,
                        NotificationMedium = objENotificationOther[icount].NotificationMedium,
                        ServiceStatus = objENotificationOther[icount].ServiceStatus,
                        ServicedBy = objENotificationOther[icount].ServicedBy,
                        ServicedDate = NotificationDate,
                        CallNotes = CallCenterNotes,
                        CCRep = objENotificationOther[icount].CCRep,
                        CallType = CallType,
                        CallDuration = CallDuration,
                        CallOutcome = callStatus,
                        Disposition = disposition,
                        Reason = notInterestedReason,
                        IsCallQueueCall = objENotificationOther[icount].IsCallQueueCall,
                    });
                }
            }

            //if (ViewState["SortDir"].ToString().Equals("asc"))
            //{
            //    dtNotification.DefaultView.Sort = " " + ViewState["SortExpression"].ToString() + " asc";

            //}
            //else
            //{
            //    dtNotification.DefaultView.Sort = " " + ViewState["SortExpression"].ToString() + " desc";
            //}

            if (objENotificationOther.Length > 0)
            {

                //dtNotification.DefaultView.Sort = " ServicedDate desc";
                grdCommunication.DataSource = dtNotification.DefaultView;
                grdCommunication.DataBind();
                dvNoItemFound.Style["display"] = "none";
            }
            else
            {
                //divMessage.Style.Add(HtmlTextWriterStyle.Display,"block");
                dvNoItemFound.Style["display"] = "block";
            }

        }
    }

    #region ImagePath
    protected string ImagePath(object Status)
    {
        string ImagePath = string.Empty;
        string strMedium = (string)Status;
        if (strMedium.Equals("Email"))
        {
            ImagePath = @"/App/Images/Email-icon.gif";
        }
        else if (strMedium.Equals("DirectMail"))
        {
            ImagePath = @"/App/Images/direct-mail.png";
        }
        else
        {
            ImagePath = @"/App/Images/Phone-icon.gif";
        }
        return ImagePath;
    }
    #endregion

    #region Grid PageIndexChanging
    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdCommunication_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Visible Communication Tab
        this.Page.ClientScript.RegisterStartupScript(GetType(), "js_changetoCommunicationTab", "ChageTab('Communication');", true);
        tbpnlContainer.ActiveTabIndex = 1;

        grdCommunication.PageIndex = e.NewPageIndex;
        DisplayCummunication();
    }
    #endregion

    #endregion

    private bool CheckCustomerId()
    {
        if (CustomerId <= 0)
        {
            errordiv.Visible = true;
            errordiv.InnerText = "Invalid customer id.";
            return false;
        }
        return true;
    }


    private void SetPreApprovedTest(long customerId)
    {
        var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
        var testRepository = IoC.Resolve<ITestRepository>();

        var preApprovedTestIds = preApprovedTestRepository.GetPreApprovedTests(customerId);

        var customerPreApprovedTest = "N/A";

        if (preApprovedTestIds != null)
        {
            var preApprovedTestNames = preApprovedTestIds != null ? preApprovedTestIds.Select(x => string.Format("\"{0}\"", x)).ToArray() : null;
            if (preApprovedTestNames != null)
            {
                customerPreApprovedTest = string.Join(", ", preApprovedTestNames);
            }
        }

        preapprovedTest.InnerText = customerPreApprovedTest;
    }

    private string GetCustomerAdditionalField(Customer customer, long additionalField)
    {
        switch ((AdditionalFieldsEnum)additionalField)
        {
            case AdditionalFieldsEnum.AdditionalField1:
                return string.IsNullOrEmpty(customer.AdditionalField1) ? "N/A" : customer.AdditionalField1;
            case AdditionalFieldsEnum.AdditionalField2:
                return string.IsNullOrEmpty(customer.AdditionalField2) ? "N/A" : customer.AdditionalField2;
            case AdditionalFieldsEnum.AdditionalField3:
                return string.IsNullOrEmpty(customer.AdditionalField3) ? "N/A" : customer.AdditionalField3;
            case AdditionalFieldsEnum.AdditionalField4:
                return string.IsNullOrEmpty(customer.AdditionalField4) ? "N/A" : customer.AdditionalField4;
        }

        return string.Empty;
    }

    private void SetPreApprovedPackage(long customerId)
    {
        var preApprovedPackageRepository = IoC.Resolve<IPreApprovedPackageRepository>();
        var packageRepository = IoC.Resolve<IPackageRepository>();

        var preApprovedPackages = preApprovedPackageRepository.GetByCustomerId(customerId);

        var preApprovedPackageIds = preApprovedPackages != null ? preApprovedPackages.Select(x => x.PackageId) : null;
        var customerPreApprovedPackage = "N/A";

        if (preApprovedPackageIds != null)
        {
            var packages = packageRepository.GetByIds(preApprovedPackageIds.ToList());

            var preApprovedPackageNames = packages != null ? packages.Select(x => string.Format("\"{0}\"", x.Name)).ToArray() : null;
            if (preApprovedPackageNames != null)
            {
                customerPreApprovedPackage = string.Join(", ", preApprovedPackageNames);
            }
        }

        preapprovedPackage.InnerText = customerPreApprovedPackage;
    }

    private bool ShowAppointmentConfirmationLink(EventCustomer eventCustomer, Event eventData)
    {
        return eventData.EventDate >= DateTime.Today && !eventCustomer.IsAppointmentConfirmed;
    }

    private void hideUserAccountRelatedLinks()
    {
        if (!CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) && _customer != null && !string.IsNullOrEmpty(_customer.Tag))
        {
            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = corporateAccountRepository.GetByTag(_customer.Tag);
            if (account != null && !account.AllowCustomerPortalLogin)
            {
                spResetPassword.Style.Add(HtmlTextWriterStyle.Display, "none");
                lnkForceChangePassword.Visible = false;
                lnkResetLoginCount.Visible = false;
                ChangeUserNameSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }
    }

    //private void SetRequiredTest(long customerId)
    //{
    //    var requiredTestRepository = IoC.Resolve<IRequiredTestRepository>();
    //    var testRepository = IoC.Resolve<ITestRepository>();

    //    var requiredTestIds = requiredTestRepository.GetRequiredTests(customerId);

    //    var customerRequiredTest = "N/A";

    //    if (requiredTestIds != null)
    //    {
    //        var requiredTestNames = requiredTestIds != null ? requiredTestIds.Select(x => string.Format("\"{0}\"", x)).ToArray() : null;
    //        if (requiredTestNames != null)
    //        {
    //            customerRequiredTest = string.Join(", ", requiredTestNames);
    //        }
    //    }
    //    requiredTest.InnerText = customerRequiredTest;
    //}
}
