using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Product = Falcon.App.Core.Enum.Product;

public partial class App_Customer_NewCustomerDashboard : Page
{
    const Int32 IntPageSize = 100;

    private const string TipMessageForCrcReady = "Your Colorectal readings will be included in your results packet. You will be notified through email when your result packet gets ready.";

    protected bool DisplayPremiumVersion;
    protected bool DisplayRescheduleAppointment;

    public long CustomerId
    {
        get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId; }
    }



    public long UserId
    {
        get { return IoC.Resolve<ISessionContext>().UserSession.UserId; }
    }

    public string CustomerName
    {
        get { return IoC.Resolve<ISessionContext>().UserSession.FullName; }
    }

    /// <summary>
    /// Load the Page and initialize it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        var repo = IoC.Resolve<IConfigurationSettingRepository>();
        DisplayPremiumVersion = Convert.ToBoolean(repo.GetConfigurationValue(ConfigurationSettingName.DisplayPremiumVersiononPortal));

        DisplayRescheduleAppointment = Convert.ToBoolean(repo.GetConfigurationValue(ConfigurationSettingName.DisplayRescheduleAppointmentPortal));

        Title = "Home";
        var objMaster = (Customer_CustomerMaster)Master;
        objMaster.SetBreadcrumb = "Home";
        objMaster.SetPageView("DashBoard");
        if (!IsPostBack)
        {
            if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
            {
                spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                divLastLogin.Visible = false;
            }
            ucHPBanner.CustomerID = CustomerId;

            ICustomerRepository customerRepository = new CustomerRepository();
            var objCustomer = customerRepository.GetCustomer(CustomerId);

            if (objCustomer != null)
            {
                ViewState["DateCreated"] = objCustomer.DateCreated;
            }
            LoadGrid(CustomerId);
        }
    }

    /// <summary>
    /// Set the grid view row alternate color. and set the button for different options 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdCustomerEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var divmain = (HtmlContainerControl)e.Row.FindControl("divmain");
            var divbottom = (HtmlContainerControl)e.Row.FindControl("divbottom");
            var spEventName = (HtmlContainerControl)e.Row.FindControl("spEventName");
            var spDiscount = (HtmlContainerControl)e.Row.FindControl("spDiscount");

            var drvCurrent = e.Row.DataItem as DataRowView;

            var divHighRiskPanel = (Panel)e.Row.FindControl("divHighRiskPanel");

            if (drvCurrent != null)
            {
                var orderId = Convert.ToInt64(drvCurrent["OrderId"]);
                var eventId = Convert.ToInt64(drvCurrent["EventID"]);
                var orderRepository = IoC.Resolve<IOrderRepository>();
                var order = orderRepository.GetOrder(orderId);
                var orderDetail =
                    order.OrderDetails.SingleOrDefault(
                        od =>
                            (od.DetailType == OrderItemType.EventPackageItem ||
                             od.DetailType == OrderItemType.EventTestItem)
                            && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive &&
                            od.IsCompleted);

                var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
                var refundRequests = refundRequestRepository.GetbyOrderId(orderId);

                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(eventId);

                var isPaid = Convert.ToBoolean(((DataRowView)(e.Row.DataItem)).Row["IsPaid"]);
                divHighRiskPanel.Style.Add(HtmlTextWriterStyle.Display,
                    drvCurrent["AssociatedPhoneNumber"].ToString().Length < 1 ? "none" : "block");

                if ((e.Row.RowIndex % 2) > 0)
                {
                    divbottom.Attributes["class"] = "divorngboxbotbg_cd";
                    divmain.Attributes["class"] = "divorngboxbodybg_cd";
                    spEventName.Attributes["class"] = "orngtxt14ptbold_cd";

                }
                else
                {
                    divbottom.Attributes["class"] = "divbluboxbotbg_cd";
                    divmain.Attributes["class"] = "divbluboxbodybg_cd";
                    spEventName.Attributes["class"] = "blutxt14ptbold_cd";

                }
                var dtEventDate = Convert.ToDateTime(((DataRowView)(e.Row.DataItem)).Row["EventDate"]);
                var diffResult = dtEventDate - DateTime.Now.Date;

                var imgReschedule = (ImageButton)e.Row.FindControl("imgReschedule");
                var spimgReschedule = (HtmlContainerControl)e.Row.FindControl("spimgReschedule");
                if (!DisplayRescheduleAppointment || diffResult.Days <= 0)
                {
                    imgReschedule.Enabled = false;
                    spimgReschedule.Style[HtmlTextWriterStyle.Display] = "none";
                }
                else
                {
                    imgReschedule.Enabled = true;
                    spimgReschedule.Style[HtmlTextWriterStyle.Display] = "block";
                }

                var downlodAdobeReaderDiv = (HtmlContainerControl)e.Row.FindControl("DownlodAdobeReaderDiv");

                if (Convert.ToBoolean(drvCurrent["TestResultReady"]) && isPaid)
                {
                    downlodAdobeReaderDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                    
                    if (DisplayPremiumVersion)
                    {
                        var divGeneratePdf = (HtmlContainerControl)e.Row.FindControl("divGeneratePdf");
                        divGeneratePdf.Style.Add(HtmlTextWriterStyle.Display,
                            Convert.ToBoolean(drvCurrent["DisplayResultPDF"]) == false ? "none" : "block");
                    }

                    if (Convert.ToBoolean(drvCurrent["DisplayResultPDF"]) == false)
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "jscript_regenrating_message",
                            "alert('We are regenerating your result packet. This may take few minutes.');", true);
                    }

                    var aPdfReport = (HtmlAnchor)e.Row.FindControl("aPDFReport");
                    var key = new DigitalDeliveryCryptographyService().GetKey(eventId, CustomerId, EPDFType.ResultPdf);
                    aPdfReport.HRef = "javascript:showClinicalForm('" + key + "');";
                    
                    SetDownloadCdandResult(e, drvCurrent);
                }
                else
                {
                    downlodAdobeReaderDiv.Style.Add(HtmlTextWriterStyle.Display, "none");

                    var divGeneratePdf = (HtmlContainerControl)e.Row.FindControl("divGeneratePdf");
                    divGeneratePdf.Style.Add(HtmlTextWriterStyle.Display, "none");
                  
                }

                if (((DataRowView)(e.Row.DataItem)).Row["Discount"].ToString() == "")
                {

                    spDiscount.Style["display"] = "none";
                }

                ///// string eventDate = Convert.ToDateTime(drvCurrent["EventDate"]).ToString("dddd, MMMM dd, yyyy");

                var aReciept = (HtmlAnchor)e.Row.FindControl("aReciept");
                var aSmallReciept = (HtmlAnchor)e.Row.FindControl("aSmallReciept");
                aReciept.HRef = "javascript:popupmenu2('/Communication/AppointmentConfirmation?eventId=" +
                                Convert.ToString(drvCurrent["EventID"]) + "&customerId=" + CustomerId + "',925,925)";


                var shippingOptionAnchor = e.Row.FindControl("ShippingOptionAnchor") as HtmlAnchor;
                var shippingOptionDiv = e.Row.FindControl("ShippingOptionDiv") as HtmlContainerControl;
                var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();

                var shippingOption =
                    (shippingOptionRepository.GetAllShippingOptionsForBuyingProcess()
                        .Where(s => s.Price > 0)
                        .Select(s => s)
                        .Any());
                var hideResultPurchase = IoC.Resolve<ISettings>().HideResultPurchase;

                if (shippingOptionAnchor != null && shippingOptionDiv != null)
                {
                    if (hideResultPurchase || !shippingOption)
                    {
                        shippingOptionAnchor.Style.Add(HtmlTextWriterStyle.Display, "none");
                        shippingOptionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                    else
                    {
                        shippingOptionAnchor.Style.Add(HtmlTextWriterStyle.Display, "block");
                        shippingOptionDiv.Style.Add(HtmlTextWriterStyle.Display, "block");


                        var shippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                        shippingDetails =
                            shippingDetails.Where(sd => sd.ActualPrice > 0 && sd.Status == ShipmentStatus.Processing)
                                .Select(sd => sd)
                                .ToArray();
                        if (shippingDetails.Count() > 0)
                        {
                            shippingOptionAnchor.HRef = "javascript:void(0);";
                            shippingOptionAnchor.Attributes.Add("onclick", "ShowFullfillmentMessage();");
                        }
                        else if (!refundRequests.IsNullOrEmpty() &&
                                 refundRequests.Where(
                                     rr =>
                                         rr.RefundRequestType == RefundRequestType.CancelShipping &&
                                         rr.RequestStatus == (long)RequestStatus.Pending).Any())
                        {
                            shippingOptionAnchor.HRef = "Javascript:void(0);";
                            shippingOptionAnchor.Attributes.Add("onclick", "ShowRefundRequestShippingMessage();");
                        }
                        else
                        {
                            shippingOptionAnchor.HRef = "CustomerFullfillmentOption.aspx?CustomerId=" +
                                                        CustomerId + "&EventCustomerId=" +
                                                        drvCurrent["EventCustomerID"] +
                                                        "&EventId=" + drvCurrent["EventID"];
                        }

                    }
                }
                var hideProductPurchase = IoC.Resolve<ISettings>().HideProductPurchase;

                var productRepository = IoC.Resolve<IElectronicProductRepository>();
                var products = productRepository.GetAllProductsForEvent(eventId);
                var imagesOptionDiv = e.Row.FindControl("ImagesOptionDiv") as HtmlContainerControl;
                var imagesOptionAnchor = e.Row.FindControl("ImagesOptionAnchor") as HtmlAnchor;
                if (imagesOptionDiv != null && imagesOptionAnchor != null)
                {
                    if (!hideProductPurchase && products != null && products.Count > 0)
                    {
                        imagesOptionAnchor.Style.Add(HtmlTextWriterStyle.Display, "block");
                        imagesOptionDiv.Style.Add(HtmlTextWriterStyle.Display, "block");

                        var hasPurchasedProduct =
                            order.OrderDetails.Where(
                                od =>
                                    od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                                    od.DetailType == OrderItemType.ProductItem).Count() > 0
                                ? true
                                : false;
                        var cdShippingDetails =
                            shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);
                        var hasUnShippedCd = false;
                        if (!cdShippingDetails.IsNullOrEmpty())
                            hasUnShippedCd =
                                cdShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing)
                                    .Select(sd => sd)
                                    .Any();

                        if (!refundRequests.IsNullOrEmpty() &&
                            refundRequests.Where(
                                rr =>
                                    rr.RefundRequestType == RefundRequestType.CDRemoval &&
                                    rr.RequestStatus == (long)RequestStatus.Pending).Any())
                        {
                            imagesOptionAnchor.HRef = "javascript:void(0);";
                            imagesOptionAnchor.Attributes.Add("onclick", "ShowRefundRequestProductMessage();");
                        }
                        else if ((hasPurchasedProduct && cdShippingDetails.IsNullOrEmpty()) || hasUnShippedCd)
                        {
                            imagesOptionAnchor.HRef = "javascript:void(0);";
                            imagesOptionAnchor.Attributes.Add("onclick", "ShowAddOnProductMessage();");
                        }
                        else
                            imagesOptionAnchor.HRef = "/App/Customer/CustomerAddOnProduct.aspx?CustomerId=" + CustomerId +
                                                      "&EventCustomerId=" + drvCurrent["EventCustomerID"] + "&EventId=" +
                                                      drvCurrent["EventID"];
                    }
                    else
                    {
                        imagesOptionAnchor.Style.Add(HtmlTextWriterStyle.Display, "none");
                        imagesOptionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }
                if (isPaid)
                {
                    aSmallReciept.HRef =
                        "javascript:popupmenu2('/Config/Content/Controls/SmallPrintReciept.aspx?CustomerID=" +
                        Convert.ToString(CustomerId) + "&EventID=" +
                        Convert.ToString(drvCurrent["EventID"]) + "',320,535)";

                    SetPaymentAndShippingAnchors(e, drvCurrent, true, order);
                    var spnPaymentDetails =
                        (HtmlContainerControl)e.Row.FindControl("spAcceptPayment");
                    spnPaymentDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                    spnPaymentDetails.InnerText = "(Paid)";
                }
                else
                {
                    aSmallReciept.HRef = "javascript:alert('Not paid yet.');";
                    var spnPaymentDetails =
                        (HtmlContainerControl)e.Row.FindControl("spAcceptPayment");

                    spnPaymentDetails.InnerHtml =
                        "[ <a href='javascript:popupmenu3(\"/App/Franchisee/Technician/AcceptPayment.aspx?EventCustomerID=" +
                        Convert.ToString(drvCurrent["EventCustomerID"]) + "&CustomerID=" + Convert.ToString(CustomerId) +
                        "&EventID=" + Convert.ToString(drvCurrent["EventID"]) +
                        "&PageCallBackFrom=CustomerDashboard" +
                        "\", 695, 680);' style=\"font-size:8pt;\"> Make Payment </a> ]";

                    SetPaymentAndShippingAnchors(e, drvCurrent, false, order);

                }

                var customerHealthInfo = IoC.Resolve<IHealthAssessmentRepository>().Get(CustomerId, eventId);
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
                                spMedicalHistory.InnerHtml = "Filled";
                                //amedicalhistory.InnerHtml = "Update";
                                amedicalhistory.InnerHtml = "<input type='button' value='Update' class='anchor-button'/>";
                                amedicalhistory.HRef = "/App/Customer/NewMedicalHistory.aspx?CustomerID=" + CustomerId + "&EventId=" + eventId + "&Edit=true";

                                var answer = customerHealthInfo.First();
                                var eventRepository = IoC.Resolve<IEventRepository>();
                                var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();

                                var eventData = eventRepository.GetById(eventId);

                                if (answer.DataRecorderMetaData != null && answer.DataRecorderMetaData.DataRecorderCreator != null && answer.DataRecorderMetaData.DataRecorderCreator.Id > 0)
                                {
                                    var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(answer.DataRecorderMetaData.DataRecorderCreator.Id);
                                    if (answer.DataRecorderMetaData.DateCreated.Date >= eventData.EventDate.Date && orgRoleUser.RoleId != (long)Roles.Customer)
                                    {
                                        //amedicalhistory.InnerHtml = "View";
                                        amedicalhistory.InnerHtml = "<input type='button' value='View' class='anchor-button'/>";
                                    }

                                }
                            }
                            else
                            {
                                spMedicalHistory.InnerText = "Not Filled";
                                //amedicalhistory.InnerHtml = "Fill";
                                amedicalhistory.InnerHtml = "<input type='button' value='Fill Now' class='anchor-button'/>";
                                amedicalhistory.HRef = "/App/Customer/NewMedicalHistory.aspx?CustomerID=" + CustomerId + "&EventId=" + eventId + "&Edit=true";
                            }
                        }
                    }
                    else
                    {
                        medicalHistoryContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }

                long eventcustomerid = Convert.ToInt64(drvCurrent["EventCustomerID"]);


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
                        mspHistoryForm.HRef = "/medical/medicareQuestion/update?eventcustomerid=" + eventcustomerid;
                    }
                    else
                    {
                        mspHistoryFormContainer.Visible = false;
                        mspHistoryForm.Visible = false;
                    }
                }


            }
        }
    }

    private void SetPaymentAndShippingAnchors(GridViewRowEventArgs e, DataRowView drvCurrent, bool isPaid, Order order)
    {

        try
        {

            var orderId = order.Id;
            var activeOrderId = Convert.ToInt64(drvCurrent["ActiveOrderDetailId"]);
            var isShippingApplicable = Convert.ToBoolean(drvCurrent["ShippingDetail"]);
            var totalShipping = Convert.ToDecimal(drvCurrent["TotalShippingAmount"]);

            var totalAmount = order.DiscountedTotal.ToString("0.00");
            var amountPaid = order.TotalAmountPaid.ToString("0.00");
            var amountDue = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");

            var paymentLinkAnchor =
                e.Row.FindControl("PaymentLinkAnchor") as HtmlAnchor;
            if (paymentLinkAnchor != null)
            {
                var customerName = CustomerName;
                customerName = customerName.Replace("'", "\\'");
                customerName = customerName.Replace("\"", "\\\"");
                var functionToCall = "javascript:return ShowOrderDetailPopUp(" +
                                         orderId + "," + totalAmount + "," + amountPaid + "," +
                                         amountDue + ",'" + customerName + "'," +
                                         CustomerId + ");";
                paymentLinkAnchor.Attributes.Add("onClick", functionToCall);
            }

            if (!isPaid && paymentLinkAnchor != null)
                paymentLinkAnchor.InnerText = "(View Order)";

            var shippingDetailAnchor = (HtmlAnchor)e.Row.FindControl("ShippingDetailAnchor");
            var shippingDetailSpan = (HtmlGenericControl)e.Row.FindControl("ShippingDetailSpan");


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
        }
        catch { }
    }

    private void SetDownloadCdandResult(GridViewRowEventArgs e, DataRowView drvCurrent)
    {
        try
        {
            var orderId = Convert.ToInt64(drvCurrent["OrderId"]);
            var eventId = Convert.ToInt64(drvCurrent["EventID"]);
            var orderRepository = IoC.Resolve<IOrderRepository>();
            var orderController = IoC.Resolve<IOrderController>();
            var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();
            var cdTrackingRepository = IoC.Resolve<ICdContentGeneratorTrackingRepository>();

            var order = orderRepository.GetOrder(orderId);
            if (order != null)
            {
                //var productPurchased = order.OrderDetails.Where(od => od.DetailType == OrderItemType.ProductItem && od.IsCompleted).Any();
                var cdTracking = cdTrackingRepository.GetByEventIdAndCustomerId(eventId, CustomerId);

                var producRepository = IoC.Resolve<IElectronicProductRepository>();
                var product = producRepository.GetElectronicProductForOrder(eventId, CustomerId);
                var cdContainerDiv = (HtmlGenericControl)e.Row.FindControl("CdContainerDiv");

                if (cdContainerDiv != null)
                {
                    if (product != null && product.Id == (long)Product.UltraSoundImages && cdTracking != null && cdTracking.IsContentGenerated)
                    {
                        var imageDownloadInstructions = (HtmlContainerControl)e.Row.FindControl("ImageDownloadInstructions");

                        cdContainerDiv.Style.Add(HtmlTextWriterStyle.Display, "block");

                        imageDownloadInstructions.Style.Add(HtmlTextWriterStyle.Display, "block");

                        var cdDownloadAnchor = (HtmlAnchor)e.Row.FindControl("CdDownloadAnchor");

                        var downloadUrl = "/DigitalDelivery.aspx?key=" + new DigitalDeliveryCryptographyService().GetKey(eventId, CustomerId, EPDFType.CdContent);

                        cdDownloadAnchor.HRef = downloadUrl;
                        cdDownloadAnchor.Attributes.Add("onclick", "updateDownloadInfo(" + cdTracking.Id + ");");
                    }
                    else
                        cdContainerDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                }

                var premiumReportContainerDiv = (HtmlGenericControl)e.Row.FindControl("PremiumReportContainerDiv");
                if (premiumReportContainerDiv != null)
                {
                    if (product != null && product.Id == (long)Product.PremiumVersionPdf)
                    {
                        premiumReportContainerDiv.Style.Add(HtmlTextWriterStyle.Display, "block");

                        var aPdfReportWithImages = (HtmlAnchor)e.Row.FindControl("aPdfReportWithImages");
                        var key = EPDFType.ResultPdfWithImages + "~" + eventId + "~" + CustomerId + "~" + "SINGLE";
                        key = new DigitalDeliveryCryptographyService().Encrypt(key);
                        aPdfReportWithImages.HRef = "javascript:showClinicalForm('" + key + "');";
                    }
                    else
                        premiumReportContainerDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                }

                if (product != null && (product.Id == (long)Product.PremiumVersionPdf || product.Id == (long)Product.UltraSoundImages))
                {
                    var viewResultsContainer = (HtmlGenericControl)e.Row.FindControl("ViewResults");
                    if (viewResultsContainer != null)
                    {
                        //viewResultsContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
                        viewResultsContainer.Style.Add(HtmlTextWriterStyle.Display, Convert.ToBoolean(drvCurrent["DisplayResultPDF"]) == false ? "none" : "block");

                        var viewResultsLink = (HtmlAnchor)e.Row.FindControl("ViewResultsLink");
                        var key = EPDFType.ViewResult + "~" + eventId + "~" + CustomerId + "~" + "SINGLE";
                        key = new DigitalDeliveryCryptographyService().Encrypt(key);
                        viewResultsLink.HRef = "javascript:showClinicalForm('" + key + "');";
                    }
                }
                else
                {

                    var viewResultsContainer = (HtmlGenericControl)e.Row.FindControl("ViewResults");
                    if (viewResultsContainer != null)
                        viewResultsContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
                }

                //var activeOrderDetail = orderController.GetActiveOrderDetail(order);
                //var shippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(activeOrderDetail.Id);
                //var viewResultsContainer = (HtmlGenericControl)e.Row.FindControl("ViewResults");
                //if (viewResultsContainer != null)
                //{
                //    if (shippingDetails != null && shippingDetails.Count() > 0)
                //        viewResultsContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
                //    else
                //        viewResultsContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
                //}
            }

        }
        catch
        { }
    }

    /// <summary>
    /// Move forward and backward
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnknavigation_Click(object sender, EventArgs e)
    {
        if (!IsPostBack)
            return;
        var btntemp = (ImageButton)sender;
        var pdsEvent = new PagedDataSource { AllowPaging = true, PageSize = IntPageSize };
        var currentpage = Convert.ToInt32(ViewState["CurrentPageIndex"]);


        if (btntemp != null)
        {

            var tblEvent = (DataTable)ViewState["DSGRD"];
            var pagecount = Convert.ToInt32(Math.Ceiling((Double)tblEvent.Rows.Count / IntPageSize));

            if (btntemp.CommandName == "Navigation")
            {
                if (pagecount <= 1)
                {
                    ibtTopNext.Enabled = false;
                    ibtTopPrevious.Enabled = false;

                    ibtTopNext.ImageUrl = "~/App/Images/MV/rightarrow-btn-mvdbrd-d.gif";
                    ibtTopPrevious.ImageUrl = "~/App/Images/MV/leftarrow-btn-mvdbrd-d.gif";
                }
                else
                {
                    ibtTopNext.Enabled = true;
                    ibtTopPrevious.Enabled = true;
                    ibtTopNext.ImageUrl = "~/App/Images/MV/rightarrow-btn-mvdbrd.gif";
                    ibtTopPrevious.ImageUrl = "~/App/Images/MV/leftarrow-btn-mvdbrd.gif";
                }
            }

            if (btntemp.CommandArgument == "P")
            {
                if (currentpage == 0)
                {

                    return;
                }
                if (currentpage == 1)
                {

                    ibtTopPrevious.Enabled = false;

                    ibtTopPrevious.ImageUrl = "~/App/Images/MV/leftarrow-btn-mvdbrd-d.gif";
                }

                pdsEvent.CurrentPageIndex = currentpage - 1;
                ViewState["CurrentPageIndex"] = currentpage - 1;
            }
            else
            {
                if (currentpage == pagecount - 1)
                    return;
                if (currentpage == pagecount - 2)
                {
                    ibtTopNext.Enabled = false;

                    ibtTopNext.ImageUrl = "~/App/Images/MV/rightarrow-btn-mvdbrd-d.gif";

                }

                pdsEvent.CurrentPageIndex = currentpage + 1;
                ViewState["CurrentPageIndex"] = currentpage + 1;
            }
            pdsEvent.DataSource = tblEvent.DefaultView;

            grdCustomerEvents.DataSource = pdsEvent;
            grdCustomerEvents.DataBind();

        }
    }

    /// <summary>
    /// Reschedule the customer's appointment
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgReschedule_Click(object sender, ImageClickEventArgs e)
    {
        var imgReschedule = (ImageButton)sender;
        Int32 eventid = Convert.ToInt32(imgReschedule.CommandName);
        Int32 eventcustomerid = Convert.ToInt32(imgReschedule.CommandArgument);
        Response.RedirectUser("ChangeAppointment.aspx?EventID=" + eventid + "&EventCustomerID=" + eventcustomerid + "&CustomerID=" + CustomerId);

    }

    /// <summary>
    /// Prepare the data table and Load the grid 
    /// </summary>
    /// <param name="customerid"></param>
    private void LoadGrid(long customerid)
    {

        var customerEventRegistrationViewDataRepository = new CustomerEventRegistrationViewDataRepository();
        var customerEventRegistrationSummary = customerEventRegistrationViewDataRepository.GetCustomerEventRegistrationViewData(customerid);


        var dteventcustomer = new DataTable();
        dteventcustomer.Columns.Add("EventName");
        dteventcustomer.Columns.Add("EventID");
        dteventcustomer.Columns.Add("HostName");
        dteventcustomer.Columns.Add("Address");
        dteventcustomer.Columns.Add("Appointment");
        dteventcustomer.Columns.Add("RegisterDate");
        dteventcustomer.Columns.Add("ShowUp");
        dteventcustomer.Columns.Add("Package");
        dteventcustomer.Columns.Add("PackageTest");
        dteventcustomer.Columns.Add("TestResult");
        dteventcustomer.Columns.Add("Cost");
        dteventcustomer.Columns.Add("Coupon");
        dteventcustomer.Columns.Add("Discount");
        dteventcustomer.Columns.Add("Payment");
        dteventcustomer.Columns.Add("IsPaid");
        dteventcustomer.Columns.Add("EventCustomerID");
        dteventcustomer.Columns.Add("EventDate");
        dteventcustomer.Columns.Add("UserAddress");
        dteventcustomer.Columns.Add("City");
        dteventcustomer.Columns.Add("PackageID");
        dteventcustomer.Columns.Add("State");
        dteventcustomer.Columns.Add("ZipCode");
        dteventcustomer.Columns.Add("AppointmentID");
        dteventcustomer.Columns.Add("TestResultReady");
        dteventcustomer.Columns.Add("TempHostAddress");
        dteventcustomer.Columns.Add("TempHostCityStateZip");
        dteventcustomer.Columns.Add("NetPayment");
        dteventcustomer.Columns.Add("AssociatedPhoneNumber");
        dteventcustomer.Columns.Add("IsAuthorized");
        dteventcustomer.Columns.Add("DisplayResultPDF", typeof(bool));
        dteventcustomer.Columns.Add("EventStatus");
        dteventcustomer.Columns.Add("GoogleMap");
        dteventcustomer.Columns.Add("PackageContainsColorectal", typeof(bool));
        dteventcustomer.Columns.Add("ColoractelDisplayHTMLString");
        dteventcustomer.Columns.Add("TotalAmount");
        dteventcustomer.Columns.Add("OrderId");
        dteventcustomer.Columns.Add("ShippingDetail");
        dteventcustomer.Columns.Add("TotalPayment");
        dteventcustomer.Columns.Add("TotalShippingAmount");
        dteventcustomer.Columns.Add("ActiveOrderDetailId");
        string phonenumber = ucHPBanner.LoadBanner();

        foreach (var customerEventRegistration in customerEventRegistrationSummary)
        {
            string couponcode = "-N/A-";
            string couponamout = string.Empty;


            if (customerEventRegistration.SourceCodeId != 0)
            {
                couponcode = customerEventRegistration.SourceCode + "/";
                couponamout = customerEventRegistration.SourceCodeDiscount.ToString("C2");

            }

            string showup;

            var dtEventDate = customerEventRegistration.EventDate;

            var dt = new DateTime(dtEventDate.Year, dtEventDate.Month, dtEventDate.Day);
            var dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //System.TimeSpan diffResult = dtEventDate - DateTime.Now;
            TimeSpan diffResult = dt - dt2;

            if (diffResult.Days > 0)
            {
                showup = "Upcoming";
            }
            else if (diffResult.Days == 0)
            {
                showup = "InProgress";
            }
            else
            {
                showup = "Completed";
            }



            const string payment = "Pending";
            var bolIsPaid = customerEventRegistration.IsPaid;



            //// Fill the Tests details of package
            #region Package Test

            string strTests = "No information avaialable";

            Package packageDetail = null;
            if (customerEventRegistration.PackageId > 0)
                packageDetail = IoC.Resolve<IPackageRepository>().GetById(customerEventRegistration.PackageId);
            //toDO: this need get from view

            const string strTestheader = "<Table><tr><td style='color:#333'> Available Test</td></tr>";
            const string strTestFooter = "</table>";

            string strTestBody = "";

            if (packageDetail != null)
            {
                strTestBody = packageDetail.Tests.Aggregate(strTestBody, (current, test) => current + "<tr><td>&#8226; " + test.Name + "</td></tr>");
            }

            strTests = strTestheader + strTestBody + strTestFooter;


            #endregion

            #region  Test Result

            string strTestsResult;

            if (customerEventRegistration.IsResultReady)
            {
                //string key = EPDFType.Clinical_Form + "~" + Convert.ToString(customerEventRegistration.EventId) + "~" + CustomerId + "~" + "SINGLE";
                //key = new DigitalDeliveryCryptographyService().Encrypt(key);
                //strTestsResult = "<a href=\"javascript:showClinicalForm('" + key + "')\">Available Online</a>";

                strTestsResult = "<a href=\"/App/Common/Results.aspx?EventId=" + customerEventRegistration.EventId + "&CustomerId=" + CustomerId + "\" target=\"_blank\">Available Online</a>";

            }
            else
                strTestsResult = " <span style='font-weight:bold; color:#ff6600;'>Not Yet Available</span>";

            #endregion


            // get event status
            var eventStatusString = GetEventStatus((int)customerEventRegistration.EventStatus, customerEventRegistration.EventDate);



            var googleMapAddressAndLink =
                  CommonCode.GetGoogleMapAddress(customerEventRegistration.EventAddress.StreetAddressLine1,
                                                 customerEventRegistration.EventAddress.City,
                                                 customerEventRegistration.EventAddress.State,
                                                 customerEventRegistration.EventAddress.ZipCode.Zip,
                                                 customerEventRegistration.EventAddress.Latitude + "," +
                                                 customerEventRegistration.EventAddress.Longitude,
                                                 customerEventRegistration.EventAddress.LatLogUseForAddressMaping);

            bool isPackageWithColoractel = IsPackagewithColoractel(customerEventRegistration.PackageId);

            string htmlForColoractelDisplay;

            if (customerEventRegistration.IsColoractelResultReady)
                htmlForColoractelDisplay = "<span style='font-weight:bold; color:#ff6600;' title='Details |" + TipMessageForCrcReady + "' class='ready-crcstatus-tip'>Ready</span>";
            else
                htmlForColoractelDisplay = "<span style='font-weight:normal;'>Not Ready</span>";

            dteventcustomer.Rows.Add(new object[]
                                         {
                                             customerEventRegistration.EventName,
                                             customerEventRegistration.EventId,
                                             customerEventRegistration.HostOrganizationName,
                                             customerEventRegistration.EventAddress.ToString(),
                                             customerEventRegistration.AppointmentStartTime.ToShortTimeString(),
                                             String.Format("{0:MM/dd/yyyy}", customerEventRegistration.EventSignupDate),
                                             showup,
                                             customerEventRegistration.PackageName,
                                             strTests,
                                             strTestsResult,
                                             customerEventRegistration.PackagePrice.ToString("C2"),
                                             couponcode,
                                             couponamout,
                                             payment,
                                             bolIsPaid,
                                             customerEventRegistration.EventCustomerId,
                                             String.Format("{0:MM/dd/yyyy}", customerEventRegistration.EventDate),
                                             " objeventcustomer[icount].Customer.User.HomeAddress.Address1",
                                             " objeventcustomer[icount].Customer.User.HomeAddress.City",
                                             customerEventRegistration.PackageId,
                                             "objeventcustomer[icount].Customer.User.HomeAddress.State",
                                             "objeventcustomer[icount].Customer.User.HomeAddress.Zip",
                                             customerEventRegistration.AppointmentId,
                                             customerEventRegistration.IsResultReady,
                                             "objeventcustomer[icount].Customer.User.HomeAddress.Address1",
                                             "City,state,zip",
                                             ////"objeventcustomer[icount].Customer.User.HomeAddress.City +" "+objeventcustomer[icount].Customer.User.HomeAddress.State + " "+objeventcustomer[icount].Customer.User.HomeAddress.Zip",
                                             customerEventRegistration.TotalPayment,
                                             phonenumber,
                                             customerEventRegistration.IsAuthorized,
                                             customerEventRegistration.IsResultPdfgenerated,
                                             eventStatusString, googleMapAddressAndLink,
                                             isPackageWithColoractel,
                                             htmlForColoractelDisplay,
                                              customerEventRegistration.EffectiveOrderPrice,
                                             customerEventRegistration.OrderId,
                                             customerEventRegistration.IsShippingApplied,
                                             customerEventRegistration.TotalPayment,
                                             customerEventRegistration.TotalShippingCost,
                                              customerEventRegistration.OrderDetailId
                                         });



        }

        //}

        if (dteventcustomer.Rows.Count > 0)
        {
            ViewState["DSGRD"] = dteventcustomer;
            FillEvent(dteventcustomer);
            dvNoItemFound.Style["display"] = "none";
        }
        else
        {
            dvNoItemFound.Style["display"] = "block";
        }

    }

    private static bool IsPackagewithColoractel(long packageId)
    {
        if (packageId == (int)StrokeAndAneurysmPreventionPakAddOn.LiverAndColorectalScreening
            || packageId == (int)StrokeAndAneurysmPreventionPakAddOn.OsteoporosisAndColorectalScreening
            || packageId == (int)StrokeAndAneurysmPreventionPakAddOn.OsteoporosisAndLiverAndColorectalScreening
            || packageId == (int)StrokeAndAneurysmPreventionPakAddOn.ColorectalScreening
            || packageId == (int)SevenTestPreventionPak.LiverAndColorectalScreening
            || packageId == (int)SevenTestPreventionPak.OsteoporosisAndColorectalScreening
            || packageId == (int)SevenTestPreventionPak.OsteoporosisAndLiverAndColorectalScreening
            || packageId == (int)SevenTestPreventionPak.ColorectalScreening
            || packageId == (int)HeartAttackPreventionPak.LiverAndColorectalScreening
            || packageId == (int)HeartAttackPreventionPak.OsteoporosisAndColorectalScreening
            || packageId == (int)HeartAttackPreventionPak.OsteoporosisAndLiverAndColorectalScreening
            || packageId == (int)HeartAttackPreventionPak.ColorectalScreening)
            return true;

        return false;
    }

    /// <summary>
    /// Reset the Grid on the page index change
    /// </summary>
    /// <param name="dtEvent"></param>
    public void FillEvent(DataTable dtEvent)
    {
        var pdsEvent = new PagedDataSource
                                       {
                                           AllowPaging = true,
                                           PageSize = IntPageSize,
                                           CurrentPageIndex = 0,
                                           DataSource = dtEvent.DefaultView
                                       };
        ViewState["CurrentPageIndex"] = 0;

        if (pdsEvent.PageCount > 1)
        {
            ibtTopNext.Enabled = true;
            ibtTopNext.ImageUrl = "~/App/Images/MV/rightarrow-btn-mvdbrd.gif";

        }
        grdCustomerEvents.DataSource = pdsEvent;
        grdCustomerEvents.DataBind();


    }

    public void SetName(object sender, EventArgs e)
    {
        //spFullName.InnerHtml = uc1.CustName;

    }
    /// <summary>
    /// Event Status
    /// </summary>
    /// <param name="eventStatusNumber"></param>
    /// <param name="strEventDate"></param>
    /// <returns></returns>
    private static string GetEventStatus(int eventStatusNumber, DateTime strEventDate)
    {
        string strEventStatus = string.Empty;
        //if (strEventDate != null && strEventDate != "")
        //{
        //    // If Active then only [Scheduled/Conducted/Scheduled Today].
        if (Convert.ToString(Enum.Parse(typeof(EventStatus), eventStatusNumber.ToString())).Equals("Active"))
        {
            if (strEventDate.ToString("MM/dd/yyyy").Equals(DateTime.Now.ToString("MM/dd/yyyy")))
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

        return strEventStatus;


    }

}
