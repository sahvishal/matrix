using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;

namespace Falcon.App.UI.App.Customer
{
    public partial class Payment : PackageRegistrationPaymentCharger
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

        # region "Overriden Properties"

        protected override long? CallId
        {
            get
            {
                return null;
            }
            set { }
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

        protected override long? CustomerId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
                    return RegistrationFlow.CustomerId;
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerId"]))
                {
                    long customerId;
                    if (Int64.TryParse(Request.QueryString["CustomerId"], out customerId))
                    {
                        return customerId;
                    }
                }
                return null;
            }
            set
            {
                RegistrationFlow.CustomerId = value.HasValue ? value.Value : 0;
            }
        }

        protected override long? EventId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                {
                    long eventId;
                    if (Int64.TryParse(Request.QueryString["EventId"], out eventId))
                    {
                        return eventId;
                    }
                }
                else if (RegistrationFlow != null && RegistrationFlow.EventId > 0)
                    return RegistrationFlow.EventId;
                return null;
            }
        }

        protected override ViewType CurrentViewType { get { return ViewType.CustomerPortal; } }

        public bool IsGiftCertificate
        {
            get
            {
                return "gc" == (Request.QueryString["gc"] ?? String.Empty);
            }
        }

        protected override long? PackageId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.PackageId > 0)
                    return RegistrationFlow.PackageId;
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
                if (RegistrationFlow != null && !RegistrationFlow.AppointmentSlotIds.IsNullOrEmpty())
                    return RegistrationFlow.AppointmentSlotIds;
                return null;
            }
        }

        protected override decimal? TotalAmount
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.TotalAmount > 0)
                    return RegistrationFlow.TotalAmount;
                return null;
            }
        }

        protected override string SourceCode
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCode : string.Empty;
            }
        }

        protected override long? SourceCodeId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.SourceCodeId > 0)
                    return RegistrationFlow.SourceCodeId;
                return null;
            }
        }

        protected override decimal SourceCodeAmount
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeAmount : 0;
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
                return RegistrationFlow != null ? RegistrationFlow.MarketingSource : string.Empty;
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

        protected override long? AwvVisitId
        {
            get { return RegistrationFlow.AwvVisitId; }
        }

        protected override decimal AmountTobePaid
        {
            get
            {
                if (IsNewFullfillmentOption || IsNewPurchaseImageOption)
                    return TotalAmount.Value;

                decimal totalAmount = 0;
                if (RegistrationFlow != null)
                {
                    if (AmountCoveredByInsurance > 0 && EligibilityId > 0)
                        totalAmount = RegistrationFlow.TotalAmount - AmountCoveredByInsurance + CoPayAmount;
                    else
                        totalAmount = RegistrationFlow.TotalAmount;
                }
                var paymentRestriction = IoC.Resolve<IPrePaymentRestriction>();
                return paymentRestriction.GetAllowedPrepaymentByChargeCard((ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue), totalAmount);

            }
        }

        protected override decimal AmountCoveredByInsurance
        {
            get
            {
                if (!string.IsNullOrEmpty(InsuranceAmountHiddenField.Value))
                {
                    decimal toBepaid = 0;
                    decimal.TryParse(InsuranceAmountHiddenField.Value, out toBepaid);
                    return toBepaid;
                }
                return 0;
            }
        }

        protected decimal CoPayAmount
        {
            get
            {
                if (!string.IsNullOrEmpty(CoPayAmountHiddenField.Value))
                {
                    decimal toBepaid = 0;
                    decimal.TryParse(CoPayAmountHiddenField.Value, out toBepaid);
                    return toBepaid;
                }
                return 0;
            }
        }

        protected override long EligibilityId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EligibilityId : 0;
            }
            set { RegistrationFlow.EligibilityId = value; }
        }

        protected bool IsTestCoveredByInsurance
        {
            get
            {
                return RegistrationFlow != null && RegistrationFlow.IsTestCoveredByInsurance;
            }
        }

        protected override long ChargeCardId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.ChargeCardId : 0;
            }
            set { RegistrationFlow.ChargeCardId = value; }
        }

        # endregion

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
        protected override DropDownList EChequeAccountTypeCombo { get { return ddlEAccountType; } }
        protected override DropDownList ChequeAccountTypeCombo { get { return null; } }

        protected override TextBox Address1TextBox { get { return txtAddress1; } }
        protected override TextBox Address2TextBox { get { return txtAddress1; } }
        protected override TextBox CityTextBox { get { return txtCity; } }
        protected override TextBox ZipTextBox { get { return txtZip; } }
        protected override TextBox PhoneTextBox { get { return txtHPhone; } }
        protected override TextBox CreditCardHolderNameTextBox { get { return txtCName; } }
        protected override TextBox CreditCardExpiryDateTextBox { get { return txtExpirationDate; } }
        protected override TextBox CreditCardNumberTextBox { get { return txtCCNo; } }
        protected override TextBox CreditCardSecurityNumberTextBox { get { return txtSequrityNo; } }
        protected override TextBox EChequeRoutingNumberTextBox { get { return txtERoutingNo; } }
        protected override TextBox EChequeAccountNumberTextBox { get { return txtEAccountNo; } }
        protected override TextBox EChequeBankNameTextBox { get { return txtEBankName; } }
        protected override TextBox EChequeAccountHolderNameTextBox { get { return txtEAccHolderName; } }
        protected override TextBox EChequeChequeNumberTextBox { get { return txtECheckNo; } }
        protected override TextBox ChequeRoutingNumberTextBox { get { throw new NotImplementedException(); } }

        protected override TextBox ChequeAccountNumberTextBox { get { return null; } }
        protected override TextBox ChequeBankNameTextBox { get { return null; } }
        protected override TextBox ChequeAccountHolderNameTextBox { get { return null; } }
        protected override TextBox ChequeChequeNumberTextBox { get { return null; } }

        protected override ListControl PaymentMode { get { return ddlPayMode; } }

        # endregion Page Controls Properties
        public bool IsNewFullfillmentOption
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CFO"]) && Request.QueryString["CFO"] == "true")
                {
                    bool isNewFullfillmentOption;
                    if (Boolean.TryParse(Request.QueryString["CFO"], out isNewFullfillmentOption))
                    {
                        return isNewFullfillmentOption;
                    }
                }
                return false;
            }
        }

        public bool IsNewPurchaseImageOption
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CPI"]) && Request.QueryString["CPI"] == "true")
                {
                    bool isNewPurchaseImageOption;
                    if (Boolean.TryParse(Request.QueryString["CPI"], out isNewPurchaseImageOption))
                    {
                        return isNewPurchaseImageOption;
                    }
                }
                return false;
            }
        }

        private long? EventCustomerId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EventCustomerId"]))
                {
                    long eventCustomerId;
                    if (Int64.TryParse(Request.QueryString["EventCustomerId"], out eventCustomerId))
                    {
                        return eventCustomerId;
                    }
                }
                return null;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (IsNewFullfillmentOption || IsNewPurchaseImageOption)
                EventCustomerControl.EventCustomerId = EventCustomerId;
            base.OnInit(e);
        }

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
                            organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsNewFullfillmentOption && !IsNewPurchaseImageOption && EventId.HasValue)
            {
                OrderSummaryControl.EventId = EventId.Value;
                OrderSummaryControl.RoleId = (long)Roles.Customer;
                OrderSummaryControl.PackageId = PackageId.HasValue ? PackageId.Value : 0;
                OrderSummaryControl.TestIds = TestIds;
                OrderSummaryControl.IsSourceCodeApplied = SourceCodeId > 0;
                OrderSummaryControl.SourceCodeAmount = SourceCodeAmount;
                if (!AppointmentSlotIds.IsNullOrEmpty())
                {
                    var slotService = IoC.Resolve<IEventSchedulingSlotService>();
                    var slot = slotService.GetHeadSlotintheChain(AppointmentSlotIds);
                    OrderSummaryControl.AppointmentTime = slot.StartTime.ToString("hh:mm tt");
                }
                if (ProductId.HasValue && ProductId.Value > 0)
                {
                    IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                    var product = itemRepository.GetById(ProductId.Value);
                    OrderSummaryControl.ProductName = product.Name;
                    OrderSummaryControl.ProductPrice = product.Price;
                }
                if (ShippingDetail != null && ShippingDetail.ShippingOption != null &&
                    ShippingDetail.ShippingOption.Id > 0)
                {
                    IUniqueItemRepository<ShippingOption> itemRepository = new ShippingOptionRepository();
                    var shippingOption = itemRepository.GetById(ShippingDetail.ShippingOption.Id);
                    OrderSummaryControl.ShippingOption = shippingOption.Name;
                    OrderSummaryControl.ShippingOptionPrice = ShippingDetail.ActualPrice;
                }

                OrderSummaryDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
                OrderSummaryDiv.Style.Add(HtmlTextWriterStyle.Display, "none");

            var customerMasterPage = (Customer_CustomerMaster)Master;
            customerMasterPage.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\">Home</a>";

            ddlState.Attributes["onChange"] = "$find('AutoCompleteExCCity').set_contextKey(this.options[this.selectedIndex].value);";
            ddlPayMode.Attributes.Add("onChange", "checkPaymentMode()");
            if (!IsPostBack)
            {
                decimal dcTotalAmount = 0;
                if (!IsNewFullfillmentOption && !IsNewPurchaseImageOption)
                {
                    customerMasterPage.SetPageView("EventRegistration");

                    if (EventId.HasValue)
                        hfEventID.Value = EventId.Value.ToString();

                    dcTotalAmount = TotalAmount.Value;
                    TotalAmountDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    FillHomeAddress();
                    EligibilityIdHiddenField.Value = EligibilityId.ToString();
                    ChargeCardIdHiddenField.Value = ChargeCardId.ToString();
                    if (ChargeCardId > 0)
                        GetCreditCardDataByChargeCardId(ChargeCardId);
                }
                else
                {
                    if (IsNewPurchaseImageOption && ProductId.HasValue)
                    {
                        var productRepository = IoC.Resolve<IElectronicProductRepository>();
                        var product = productRepository.GetById(ProductId.Value);
                        if (ShippingDetail != null)
                            dcTotalAmount = product.Price + ShippingDetail.ActualPrice;
                        else
                            dcTotalAmount = product.Price;
                    }
                    else if(IsNewFullfillmentOption)
                    {
                        if (ShippingDetail != null)
                            dcTotalAmount = ShippingDetail.ActualPrice;
                    }
                    customerMasterPage.SetPageView("DashBoard");
                    TotalAmountDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                    RegistrationFlow.TotalAmount = dcTotalAmount;
                    BindShippingAddress();
                }

                dvTotalAmount.InnerText = dcTotalAmount.ToString("0.00");

                rbtBillingAddressY.Attributes["onClick"] = "return CheckBillingAddress()";
                rbtBillingAddressN.Attributes["onClick"] = "return CheckBillingAddress()";
                chkOnsitePayment.Attributes["onClick"] = "return OnsitePayment()";
                txtCCNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
                txtSequrityNo.Attributes.Add("onKeyDown", "return CheckDecimal(event);");
            }
            else
            {
                if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "save")
                {
                    EligibilityId = Convert.ToInt64(EligibilityIdHiddenField.Value);
                    ChargeCardId = Convert.ToInt64(ChargeCardIdHiddenField.Value);
                    bool doEventRegistrationRedirect = false;
                    try
                    {
                        doEventRegistrationRedirect = SaveRegistrationPayment();
                    }
                    catch (Exception ex)
                    {
                        if (RegistrationFlow != null)
                            RegistrationFlow.ShippingDetailId = 0;
                        SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                        doEventRegistrationRedirect = false;
                    }
                    if (doEventRegistrationRedirect)
                    {
                        UpdateProspectCustomer(Customer.CustomerId);

                        RegistrationFlow.SourceCodeId = 0;
                        RegistrationFlow.SourceCode = string.Empty;
                        RegistrationFlow.SourceCodeAmount = 0;
                        RegistrationFlow.ProductId = 0;
                        RegistrationFlow.ShippingDetailId = 0;
                        RegistrationFlow.ShippingOptionId = 0;
                        RegistrationFlow.ShippingAddressId = 0;
                        RegistrationFlow.AppointmentSlotIds = null;
                        RegistrationFlow.PackageId = 0;
                        RegistrationFlow.TestIds = null;

                        var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                        callQueueCustomerRepository.UpdateOtherCustomerStatus(Customer.CustomerId, 0, CallQueueStatus.Completed, Customer.CustomerId);

                        Response.RedirectUser("ConfirmationReciept.aspx?guid=" + GuId);
                    }
                }
                if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "isNewFullfillmentOption")
                {
                    try
                    {
                        using (var transaction = new TransactionScope())
                        {
                            if (PlaceNewShippingOrder())
                            {
                                transaction.Complete();
                                ClientScript.RegisterStartupScript(typeof(string), "jscode6", "alert('Payment processed succesfully.'); ", true);
                                RegistrationFlow = null;
                                Response.RedirectUser("HomePage.aspx");
                            }
                            else
                                return;
                        }
                    }
                    catch (Exception ex)
                    {
                        SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                        return;
                    }
                }

                if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "isNewPurchaseImageOption")
                {
                    try
                    {
                        using (var transaction = new TransactionScope())
                        {
                            if (PlaceProductOrder())
                            {
                                transaction.Complete();
                                ClientScript.RegisterStartupScript(typeof(string), "jscode6", "alert('Payment processed succesfully.'); ", true);
                                RegistrationFlow = null;
                                Response.RedirectUser("HomePage.aspx");
                            }
                            else
                                return;
                        }
                    }
                    catch (Exception ex)
                    {
                        SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                        return;
                    }
                }
            }
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            if (IsNewFullfillmentOption)
            {
                Response.RedirectUser("CustomerFullfillmentOption.aspx?CustomerId=" + CustomerId + "&EventCustomerId=" + EventCustomerId + "&EventId=" + EventId + "&guid=" + GuId);
            }
            if (IsNewPurchaseImageOption)
            {
                Response.RedirectUser("/App/Customer/CustomerAddOnProduct.aspx?CustomerId=" + CustomerId + "&EventCustomerId=" + EventCustomerId + "&EventId=" + EventId + "&guid=" + GuId);
            }
            EligibilityId = Convert.ToInt64(EligibilityIdHiddenField.Value);
            ChargeCardId = Convert.ToInt64(ChargeCardIdHiddenField.Value);
            Response.RedirectUser("SelectAppointment.aspx?guid=" + GuId);
        }

        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        { }

        private void FillHomeAddress()
        {
            txtAddress1.Text = Customer.Address.StreetAddressLine1;
            txtAddress2.Text = Customer.Address.StreetAddressLine2;
            txtCity.Text = Customer.Address.City;
            var listItem = ddlState.Items.FindByText(Customer.Address.State);
            if (listItem != null)
                ddlState.SelectedValue = listItem.Value;
            txtZip.Text = Customer.Address.ZipCode.Zip;
        }

        private void BindShippingAddress()
        {
            txtAddress1.Text = Customer.Address.StreetAddressLine1;
            txtAddress2.Text = Customer.Address.StreetAddressLine2;
            txtCity.Text = Customer.Address.City;
            var listItem = ddlState.Items.FindByText(Customer.Address.State);
            if (listItem != null)
                ddlState.SelectedValue = listItem.Value;
            txtZip.Text = Customer.Address.ZipCode.Zip;

        }

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            errordiv.InnerHtml = errorMessage;
            errordiv.Visible = true;
            if (PaymentGatewayResponse != null)
            {
                if (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted)
                {
                    spnRequestID.InnerText = HttpUtility.HtmlEncode(PaymentGatewayResponse.TransactionCode);
                    pRequestID.Visible = true;
                    spnDecision.InnerText = HttpUtility.HtmlEncode(PaymentGatewayResponse.Message);
                    pDecision.Visible = true;
                    spnReasonCode.InnerText = HttpUtility.HtmlEncode(PaymentGatewayResponse.ResponseCode);
                    pReasonCode.Visible = true;
                }
            }
            ClientScript.RegisterStartupScript(typeof(string), "jscode_MaintainAfterFailedPostBack", "SetValuesafterFailedPostBack();", true);

        }

        protected override void SetDisplayControls()
        {

        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {
            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        private void UpdateProspectCustomer(long customerId)
        {
            var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
            var prospectCustomer = ((IProspectCustomerRepository)prospectCustomerRepository).GetProspectCustomerByCustomerId(customerId);
            if (prospectCustomer != null)
            {
                prospectCustomer.CustomerId = customerId;
                prospectCustomer.IsConverted = true;
                prospectCustomer.ConvertedOnDate = DateTime.Now;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                prospectCustomer.TagUpdateDate = DateTime.Now;

                prospectCustomerRepository.Save(prospectCustomer);
            }
        }

        private void GetCreditCardDataByChargeCardId(long chargeCardId)
        {
            var chargeCardRepository = IoC.Resolve<IChargeCardRepository>();
            var chargeCard = chargeCardRepository.GetById(chargeCardId);

            txtCName.Text = chargeCard.NameOnCard;
            txtCCNo.Text = chargeCard.Number;
            ddlCCType.SelectedValue = ((int)chargeCard.TypeId).ToString();
            txtExpirationDate.Text = chargeCard.ExpirationDate.ToString("MM/yyyy");
            txtSequrityNo.Text = chargeCard.CVV;
        }
    }
}