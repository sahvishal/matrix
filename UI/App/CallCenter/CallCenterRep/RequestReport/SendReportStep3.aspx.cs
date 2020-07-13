using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.RequestReport
{
    public partial class SendReportStep3 : PackageRegistrationPaymentCharger
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
            set { Session[GuId] = value; }
        }

        protected override long? CallId
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

        # region "Overriden Properties"
        protected override bool IsOnSitePayment { get { return (chkOnsitePayment.Checked || PaymentMode.SelectedItem.Value == PaymentType.Onsite_Value.ToString()); } }

        protected override long? CustomerId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerID"]))
                {
                    long customerId;
                    if (Int64.TryParse(Request.QueryString["CustomerID"], out customerId))
                    {
                        return customerId;
                    }
                }
                else if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
                {
                    return RegistrationFlow.CustomerId;
                }
                return null;
            }
            set
            {
                RegistrationFlow.CustomerId = value.HasValue ? value.Value : 0;
            }
        }

        protected override List<long> TestIds
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.TestIds != null)
                {
                    return RegistrationFlow.TestIds.ToList();
                }
                return null;
            }
        }

        protected override long? EventId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.EventId > 0)
                    return RegistrationFlow.EventId;
                return null;
            }
        }

        private OrganizationRoleUserModel CurrentOrgRole
        {
            get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole; }
        }

        protected override ViewType CurrentViewType
        {
            get
            {
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
                    return ViewType.Technician;

                return ViewType.CallCenterRep;
            }
        }

        public bool IsGiftCertificate
        {
            get
            {
                return false;
            }
        }

        protected override long? PackageId
        {
            get
            {
                return null;
            }
        }

        protected override long? ProductId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                    return RegistrationFlow.ProductId;
                return null;
            }
        }
        protected override IEnumerable<long> AppointmentSlotIds
        {
            get
            {
                return null;
            }
        }

        protected override decimal? TotalAmount
        {
            get
            {
                if (RegistrationFlow != null)
                    return RegistrationFlow.TotalAmount;
                return null;
            }
        }

        protected override string SourceCode
        {
            get
            {
                return string.Empty;
            }
        }

        protected override long? SourceCodeId
        {
            get
            {
                return null;
            }
        }

        protected override decimal SourceCodeAmount
        {
            get
            {
                return 0.0m;
            }
        }


        protected override Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null && CustomerId.HasValue)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                return _customer;
            }
        }

        protected override ShippingDetail ShippingDetail
        {

            get
            {
                if (ShippingOptionId.HasValue && ShippingAddressId.HasValue)
                {
                    var shippingDetail = GetShippingDetailData(ShippingOptionId.Value, ShippingAddressId.Value);
                    if (RegistrationFlow != null)
                        shippingDetail.Id = RegistrationFlow.ShippingDetailId;
                    return shippingDetail;
                }
                return null;
            }
            set
            {
                RegistrationFlow.ShippingDetailId = value.Id;
            }
        }


        protected override string MarketingSource
        {
            get
            {
                return string.Empty;
            }
        }

        protected override long? AppliedGiftCertificateId
        {
            get
            {
                return null;
            }
        }

        protected override decimal? AppliedGiftCertificateBalanceAmount
        {
            get
            {
                return null;
            }
        }

        protected override bool IsBillingAddressSameAsHomeAddress
        {
            get
            {
                return rbtBillingAddressY.Checked;
            }
            set
            {
                rbtBillingAddressY.Checked = value;
                rbtBillingAddressN.Checked = !value;
            }
        }
        # endregion

        private long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
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
        }

        protected override decimal AmountTobePaid
        {
            get
            {
                if (TotalAmount.HasValue)
                    return TotalAmount.Value;
                return 0;

                //var paymentRestriction = IoC.Resolve<IPrePaymentRestriction>();
                //return paymentRestriction.GetAllowedPrepaymentByChargeCard(
                //    (ChargeCardType)Convert.ToInt64(CreditCardTypeCombo.SelectedValue), TotalAmount.Value);
            }
        }

        protected override decimal AmountCoveredByInsurance
        {
            get
            {
                return 0.0m;
            }
        }

        protected override long EligibilityId
        {
            get
            {
                return 0;
            }

            set
            {
                RegistrationFlow.EligibilityId = value;
            }
        }

        protected override long ChargeCardId
        {
            get
            {
                return 0;
            }

            set
            {
                RegistrationFlow.ChargeCardId = value;
            }
        }

        # region Page Controls Properties

        protected override DropDownList CountryCombo
        {
            get { return ddlCountry; }
        }

        protected override HiddenField StateHiddenField
        {
            get { return hfstate; }
        }
        protected override DropDownList CreditCardTypeCombo { get { return ddlCCType; } }
        protected override DropDownList EChequeAccountTypeCombo { get { return null; } }

        protected override TextBox Address1TextBox { get { return txtAddress1; } }
        protected override TextBox Address2TextBox { get { return txtAddress2; } }
        protected override TextBox CityTextBox { get { return txtCity; } }
        protected override TextBox ZipTextBox { get { return txtZip; } }
        protected override TextBox PhoneTextBox { get { return txtHPhone; } }
        protected override TextBox CreditCardHolderNameTextBox { get { return txtCName; } }
        protected override TextBox CreditCardExpiryDateTextBox { get { return txtExpirationDate; } }
        protected override TextBox CreditCardNumberTextBox { get { return txtCCNo; } }
        protected override TextBox CreditCardSecurityNumberTextBox { get { return txtSequrityNo; } }
        protected override TextBox EChequeRoutingNumberTextBox { get { return null; } }
        protected override TextBox EChequeAccountNumberTextBox { get { return null; } }
        protected override TextBox EChequeBankNameTextBox { get { return null; } }
        protected override TextBox EChequeAccountHolderNameTextBox { get { return null; } }
        protected override TextBox EChequeChequeNumberTextBox { get { return null; } }

        protected override TextBox ChequeRoutingNumberTextBox { get { return txtRoutingNum; } }
        protected override TextBox ChequeAccountNumberTextBox { get { return txtAccountNum; } }
        protected override TextBox ChequeBankNameTextBox { get { return txtBankName; } }
        protected override TextBox ChequeAccountHolderNameTextBox { get { return txtAccHolderName; } }
        protected override TextBox ChequeChequeNumberTextBox { get { return txtChequeNum; } }
        protected override DropDownList ChequeAccountTypeCombo { get { return ddlaccounttype; } }

        protected override ListControl PaymentMode { get { return ddlPayMode; } }

        # endregion Page Controls Properties

        #region Event

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                this.MasterPageFile = "/App/Franchisee/Technician/TechnicianMaster.master";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                this.Form.Action = Request.RawUrl;
                OnSitePaymentSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
                PaymentModeSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                var item = ddlPayMode.Items.FindByText("Select Payment Mode");
                if (item != null)
                    ddlPayMode.Items.Remove(item);
                item = ddlPayMode.Items.FindByValue(PaymentType.ElectronicCheck.PersistenceLayerId.ToString());
                if (item != null)
                    ddlPayMode.Items.Remove(item);

            }
            else
            {
                OnSitePaymentSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                PaymentModeSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                var item = ddlPayMode.Items.FindByText("Select Payment Mode");
                if (item != null)
                    ddlPayMode.Items.Remove(item);
                item = ddlPayMode.Items.FindByValue(PaymentType.ElectronicCheck.PersistenceLayerId.ToString());
                if (item != null)
                    ddlPayMode.Items.Remove(item);
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

            if (!IsPostBack)
            {
                if (CustomerId.HasValue && EventId.HasValue)
                {
                    var orderRepository = IoC.Resolve<IOrderRepository>();
                    var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);
                    if (order != null && !order.OrderDetails.IsEmpty())
                        SetCreditCardOnFileDetails(order);
                }
                if ((ShippingDetail != null || ProductId.HasValue) && EventId.HasValue)
                {
                    ddlPayMode.Items.FindByValue(PaymentType.CreditCard.PersistenceLayerId.ToString()).Selected = true;
                    txtSequrityNo.Attributes.Add("onKeyDown", "return txtkeypress(event);");
                    decimal dcTotalAmount = 0.0m;
                    if (ProductId.HasValue)
                    {
                        var productRepository = IoC.Resolve<IElectronicProductRepository>();
                        var product = productRepository.GetById(ProductId.Value);

                        dvSelectedProduct.Style.Add(HtmlTextWriterStyle.Display, "block");
                        dvSelectedProductDesc.InnerText = product.Name;
                        dvSelectedProductAmt.InnerText = product.Price.ToString("0.00");

                        if (ShippingDetail != null)
                        {
                            var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                            var shippingOption = shippingOptionRepository.GetById(ShippingDetail.ShippingOption.Id);

                            dvReportEmail.Style.Add(HtmlTextWriterStyle.Display, "block");
                            dvReportEmailDesc.InnerText = shippingOption.Name;
                            dvReportEmailAmt.InnerText = ShippingDetail.ActualPrice.ToString();

                            spPrintedReportCost.InnerText = (product.Price + ShippingDetail.ActualPrice).ToString();
                            dcTotalAmount = product.Price + ShippingDetail.ActualPrice;
                            RegistrationFlow.TotalAmount = product.Price + ShippingDetail.ActualPrice;
                        }
                        else
                        {
                            spPrintedReportCost.InnerHtml = product.Price.ToString();
                            dcTotalAmount = product.Price;
                            RegistrationFlow.TotalAmount = product.Price;
                        }

                    }
                    else if (ShippingDetail != null)
                    {
                        var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                        var shippingOption = shippingOptionRepository.GetById(ShippingDetail.ShippingOption.Id);

                        dvReportEmail.Style.Add(HtmlTextWriterStyle.Display, "block");
                        dvReportEmailDesc.InnerText = shippingOption.Name;
                        dvReportEmailAmt.InnerText = ShippingDetail.ActualPrice.ToString();

                        spPrintedReportCost.InnerHtml = ShippingDetail.ActualPrice.ToString();
                        dcTotalAmount = ShippingDetail.ActualPrice;
                        RegistrationFlow.TotalAmount = ShippingDetail.ActualPrice;
                    }

                    if (dcTotalAmount > 0)
                        DivPaymentDetail.Style.Add(HtmlTextWriterStyle.Display, "block");
                    else
                        DivPaymentDetail.Style.Add(HtmlTextWriterStyle.Display, "none");
                    dvTotalAmount.InnerText = dcTotalAmount.ToString();
                    dvTotalBill.InnerText = dcTotalAmount.ToString();

                    var strJsCloseWindow = new System.Text.StringBuilder();
                    strJsCloseWindow.Append(" <script language = 'Javascript'>MailReport(); </script>");
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());

                    hfEventID.Value = EventId.Value.ToString();
                    rbtBillingAddressY.Attributes["onClick"] = "return CheckBillingAddress()";
                    rbtBillingAddressN.Attributes["onClick"] = "return CheckBillingAddress()";
                    chkOnsitePayment.Attributes["onClick"] = "return OnsitePayment()";
                    txtCCNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
                    txtSequrityNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");

                    if (CallId != null)
                        hfCallStartTime.Value = new CallCenterCallRepository().GetCallStarttime(CallId.Value);

                    GetAllPaymentType();
                }
            }
        }

        /// <summary>
        /// Move back to the Select Package page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No"))
            {
                if (CallId != null)
                {
                    var repository = new CallCenterCallRepository();
                    repository.UpdateEventforaCall(0, CallId.Value);
                }
            }

            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin)) // This will be the case of Add on Product through technician Only
            {
                Response.RedirectUser("/App/Franchisee/Technician/AdditionalProductRequest?id=" + CustomerId.Value + "&guid=" + GuId);
            }

            if (ProductId.HasValue)
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    if (EventId.HasValue && EventId.Value > 0)
                        Response.RedirectUser("AdditionalProductRequest.aspx?Call=No&CustomerId=" + CustomerId.Value + "&guid=" + GuId + "&EventId=" + EventId.Value);
                    else
                        Response.RedirectUser("AdditionalProductRequest.aspx?Call=No&CustomerId=" + CustomerId.Value + "&guid=" + GuId);
                }
                else if (EventId.HasValue && EventId.Value > 0)
                    Response.RedirectUser("AdditionalProductRequest.aspx?guid=" + GuId + "&EventId=" + EventId.Value);
                else
                    Response.RedirectUser("AdditionalProductRequest.aspx?guid=" + GuId);
            }
            else
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    if (EventId.HasValue && EventId.Value > 0)
                        Response.RedirectUser("SendReportStep2.aspx?Call=No&CustomerId=" + CustomerId.Value + "&guid=" + GuId + "&EventId=" + EventId.Value);
                    else
                        Response.RedirectUser("SendReportStep2.aspx?Call=No&CustomerId=" + CustomerId.Value + "&guid=" + GuId);
                }
                else if (EventId.HasValue && EventId.Value > 0)
                    Response.RedirectUser("SendReportStep2.aspx?guid=" + GuId + "&EventId=" + EventId.Value);
                else
                    Response.RedirectUser("SendReportStep2.aspx?guid=" + GuId);
                //Response.RedirectUser("SendReportStep2.aspx");
            }
        }

        /// <summary>
        /// Save the Billing info and move to the Primary care Physician page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {
            var doRedirect = false;

            try
            {
                using (var transaction = new TransactionScope())
                {
                    if (ProductId.HasValue ? PlaceProductOrder() : PlaceNewShippingOrder())
                    {
                        transaction.Complete();
                        doRedirect = true;
                    }
                    else
                    {
                        transaction.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + HttpUtility.HtmlEncode(ex.Message));
                return;
            }
            if (doRedirect)
            {
                if (RegistrationFlow != null)
                {
                    RegistrationFlow.ShippingDetailId = 0;
                    RegistrationFlow.ShippingOptionId = 0;
                    RegistrationFlow.ShippingAddressId = 0;
                    RegistrationFlow.ProductId = 0;
                }
                if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin)) // This will be the case of Add on Product through technician Only
                {
                    RegistrationFlow = null;
                    Response.RedirectUser(Session["c_url"].ToString());
                }
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId);
                else
                    Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&guid=" + GuId);
            }

        }

        /// <summary>
        /// End the call without saving the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
        {
            var commonCode = new CommonCode();
            commonCode.EndCCRepCall(Page);
        }

        protected void imgCancel_Click(object sender, ImageClickEventArgs e)
        {
            if (RegistrationFlow != null)
            {
                RegistrationFlow.ShippingDetailId = 0;
                RegistrationFlow.ShippingOptionId = 0;
                RegistrationFlow.ShippingAddressId = 0;
                RegistrationFlow.ProductId = 0;
            }
            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner) || CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin)) // This will be the case of Add on Product through technician Only
            {
                RegistrationFlow = null;
                Response.RedirectUser(Session["c_url"].ToString());
            }
            var strCustname = Customer.NameAsString;
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId.Value + "&Call=No" + "&guid=" + GuId);
            else
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CustomerOptions.aspx?CustomerID=" + CustomerId.Value +
                                  "&Name=" + strCustname + "&guid=" + GuId);
        }
        #endregion

        #region Methods

        private void GetAllPaymentType()
        {
            if (ShippingDetail != null && ShippingDetail.ActualPrice > 0)
                ddlPayMode.Items.FindByValue(PaymentType.CreditCard.PersistenceLayerId.ToString()).Selected = true;

            //ddlPayMode.Enabled = false;
        }

        protected override void SetDisplayControls()
        {
            Page.Title = "Payment Details ";
            if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                var obj = (Franchisee_Technician_TechnicianMaster)Master;
                obj.settitle("Paymnent");
                obj.SetBreadcrumb = "";
            }
            else
            {
                var obj = (CallCenter_CallCenterMaster1)Master;
                obj.SetTitle("Existing Customer");
                obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

                obj.hideucsearch();
            }
        }

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            divError.InnerHtml = string.IsNullOrEmpty(errorMessage) ? "Sorry, payment request from your credit card is rejected by our payment gateway. Please check given details." : errorMessage;
            divError.Visible = true;
            decimal dcTotalAmount = 0.0m;
            if (ProductId.HasValue)
            {
                var productRepository = IoC.Resolve<IElectronicProductRepository>();
                var product = productRepository.GetById(ProductId.Value);

                dvSelectedProduct.Style.Add(HtmlTextWriterStyle.Display, "block");
                dvSelectedProductDesc.InnerText = product.Name;
                dvSelectedProductAmt.InnerText = product.Price.ToString("0.00");

                if (ShippingDetail != null)
                {
                    var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                    var shippingOption = shippingOptionRepository.GetById(ShippingDetail.ShippingOption.Id);

                    dvReportEmail.Style.Add(HtmlTextWriterStyle.Display, "block");
                    dvReportEmailDesc.InnerText = shippingOption.Name;
                    dvReportEmailAmt.InnerText = ShippingDetail.ActualPrice.ToString();

                    spPrintedReportCost.InnerText = (product.Price + ShippingDetail.ActualPrice).ToString();
                    dcTotalAmount = product.Price + ShippingDetail.ActualPrice;
                    RegistrationFlow.TotalAmount = product.Price + ShippingDetail.ActualPrice;
                }
                else
                {
                    spPrintedReportCost.InnerText = product.Price.ToString();
                    dcTotalAmount = product.Price;
                    RegistrationFlow.TotalAmount = product.Price;
                }
            }
            else if (ShippingDetail != null)
            {
                var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                var shippingOption = shippingOptionRepository.GetById(ShippingDetail.ShippingOption.Id);

                dvReportEmail.Style.Add(HtmlTextWriterStyle.Display, "block");
                dvReportEmailDesc.InnerText = shippingOption.Name;
                dvReportEmailAmt.InnerText = ShippingDetail.ActualPrice.ToString();

                spPrintedReportCost.InnerText = ShippingDetail.ActualPrice.ToString();
                dcTotalAmount = ShippingDetail.ActualPrice;
                RegistrationFlow.TotalAmount = ShippingDetail.ActualPrice;
            }
            dvTotalAmount.InnerText = dcTotalAmount.ToString();
            dvTotalBill.InnerText = dcTotalAmount.ToString();

            var strJsCloseWindow = new System.Text.StringBuilder();
            strJsCloseWindow.Append(" <script language = 'Javascript'>MailReport(); </script>");
            ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());

        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            var sessionContext = IoC.Resolve<ISessionContext>();
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                       sessionContext.UserSession.CurrentOrganizationRole,
                        sessionContext.UserSession.UserId);
        }
        #endregion

        private ShippingDetail GetShippingDetailData(long shippingOptionId, long shippingAddressId)
        {
            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var addressRepository = IoC.Resolve<IAddressRepository>();

            var shippingDetail = new ShippingDetail
            {
                ShippingOption = new ShippingOption(),
                DataRecorderMetaData =
                    new DataRecorderMetaData
                    {
                        DataRecorderCreator =
                            organizationRoleUserRepository.GetOrganizationRoleUser(CurrentOrgRole.OrganizationRoleUserId)
                        ,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                Status = ShipmentStatus.Processing,
                ShippingAddress = addressRepository.GetAddress(shippingAddressId)
            };
            var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
            var shippingOption = shippingOptionRepository.GetById(shippingOptionId);
            shippingDetail.ShippingOption.Id = shippingOption.Id;
            shippingDetail.ActualPrice = shippingOption.Price;

            return shippingDetail;
        }

        private void SetCreditCardOnFileDetails(Core.Finance.Domain.Order order)
        {
            var creditCardPaymentInstrument =
                order.PaymentsApplied.OrderBy(pa => pa.DataRecorderMetaData.DateCreated).LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                ChargeCardPayment;

            if (creditCardPaymentInstrument == null) return;

            IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
            var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
            spcardholder.InnerText = existingChargeCard.NameOnCard;
            string cardnumber = existingChargeCard.Number;
            if (cardnumber.Length > 0)
            {
                string dispcardnumber = "";
                for (int jcount = 0; jcount < cardnumber.Length - 4; jcount++)
                {
                    dispcardnumber = dispcardnumber + "X";
                }

                dispcardnumber += cardnumber.Substring(cardnumber.Length - 4, 4);

                spccnumber.InnerText = dispcardnumber;
                spcctype.InnerText =
                    Enum.Parse(typeof(ChargeCardType), existingChargeCard.TypeId.ToString()).ToString();

                spexpdate.InnerText = existingChargeCard.ExpirationDate.ToString("MM/yyyy");


                ddlPayMode.Items.Insert(ddlPayMode.Items.Count, new ListItem(PaymentType.CreditCardOnFile_Text, PaymentType.CreditCardOnFile_Value.ToString()));

                var listItems = ddlPayMode.Items.Cast<ListItem>().ToList().OrderBy(li => li.Text).ToArray();
                ddlPayMode.Items.Clear();
                ddlPayMode.Items.AddRange(listItems);

                ddlPayMode.SelectedValue = PaymentType.CreditCard.PersistenceLayerId.ToString();
            }
        }
    }
}