using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Deprecated.Repository;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UcChangePackage : PaymentInstrumentChargerControl
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

        protected decimal MinimumPurchaseAmount
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToDecimal(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.MinimumPurchaseAmount));
            }
        }

        protected override long? CallId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                    return RegistrationFlow.CallId;
                return null;
            }
            set { RegistrationFlow.CallId = value.HasValue ? value.Value : 0; }
        }
        protected long? CallQueueCustomerId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallQueueCustomerId > 0)
                    return RegistrationFlow.CallQueueCustomerId;
                return null;
            }
        }

        protected override ViewType CurrentViewType
        {
            get
            {
                return (ViewType)Enum.Parse(typeof(ViewType), IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias);
            }
        }

        protected override long? EventId
        {
            get
            {
                if (ViewState["EventId"] != null && !string.IsNullOrEmpty(ViewState["EventId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["EventId"]);
                }
                return null;
            }
            set
            {
                ViewState["EventId"] = value;
            }
        }

        protected override long? CustomerId
        {
            get
            {
                if (ViewState["CustomerId"] != null && !string.IsNullOrEmpty(ViewState["CustomerId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["CustomerId"]);
                }
                return null;
            }
            set
            {
                ViewState["CustomerId"] = value;
            }
        }

        protected override Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                return _customer;
            }
        }

        protected override decimal? TotalAmountPayable
        {
            get
            {
                if (ViewState["TotalAmountPayable"] != null && !string.IsNullOrEmpty(ViewState["TotalAmountPayable"].ToString()))
                {
                    return Convert.ToDecimal(ViewState["TotalAmountPayable"]);
                }
                return null;
            }
            set
            {
                ViewState["TotalAmountPayable"] = value;
            }
        }

        protected override decimal? AppliedGiftCertificateBalanceAmount
        {
            get
            {
                decimal giftCertificateAppliedAmount;
                if (decimal.TryParse(GCApply.GiftCertificateBalanceAmount, out giftCertificateAppliedAmount))
                    return giftCertificateAppliedAmount;
                return null;
            }
        }

        protected override long? AppliedGiftCertificateId
        {
            get
            {
                long giftCertificateId;
                if (long.TryParse(GCApply.GiftCertificateId, out giftCertificateId))
                    return giftCertificateId;
                return null;
            }
        }

        protected override DropDownList CountryCombo
        {
            get
            {
                return ddlcountry;
            }
        }

        protected override DropDownList ECountryCombo
        {
            get
            {
                return ddlEcountry;
            }
        }

        protected override HiddenField StateHiddenField
        {
            get
            {
                return hfstate;
            }
        }

        protected override HiddenField EStateHiddenField
        {
            get
            {
                return hfEstate;
            }
        }

        protected override DropDownList CreditCardTypeCombo
        {
            get { return ddlcardtype; }
        }

        protected override DropDownList EChequeAccountTypeCombo
        {
            get { return ddlEAccountType; }
        }

        protected override DropDownList ChequeAccountTypeCombo
        {
            get { return ddlaccounttype; }
        }

        protected override TextBox Address1TextBox
        {
            get
            {
                return txtAddress1;
            }
        }

        protected override TextBox Address2TextBox
        {
            get { return null; }
        }

        protected override TextBox CityTextBox
        {
            get
            {
                return txtCity;
            }
        }

        protected override TextBox ZipTextBox
        {
            get
            {
                return txtZip;
            }
        }

        protected override TextBox PhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox EAddress1TextBox
        {
            get
            {
                return txtEAddress1;
            }
        }

        protected override TextBox EAddress2TextBox
        {
            get { return null; }
        }

        protected override TextBox ECityTextBox
        {
            get
            {
                return txtECity;
            }
        }

        protected override TextBox EZipTextBox
        {
            get
            {
                return txtEZip;
            }
        }

        protected override TextBox EPhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox CreditCardHolderNameTextBox
        {
            get { return txtCardHolderName; }
        }

        protected override TextBox CreditCardExpiryDateTextBox
        {
            get { return txtExpirationDate; }
        }

        protected override TextBox CreditCardNumberTextBox
        {
            get { return txtCardNo; }
        }

        protected override TextBox CreditCardSecurityNumberTextBox
        {
            get { return txtSecurityNum; }
        }

        protected override TextBox EChequeRoutingNumberTextBox
        {
            get { return txtERoutingNo; }
        }

        protected override TextBox EChequeAccountNumberTextBox
        {
            get { return txtEAccountNo; }
        }

        protected override TextBox EChequeBankNameTextBox
        {
            get { return txtEBankName; }
        }

        protected override TextBox EChequeAccountHolderNameTextBox
        {
            get { return txtEAccHolderName; }
        }

        protected override TextBox EChequeChequeNumberTextBox
        {
            get { return txtECheckNo; }
        }

        protected override TextBox ChequeRoutingNumberTextBox
        {
            get { return txtRoutingNum; }
        }

        protected override TextBox ChequeAccountNumberTextBox
        {
            get { return txtAccountNum; }
        }

        protected override TextBox ChequeBankNameTextBox
        {
            get { return txtBankName; }
        }

        protected override TextBox ChequeAccountHolderNameTextBox
        {
            get { return txtAccHolderName; }
        }

        protected override TextBox ChequeChequeNumberTextBox
        {
            get { return txtChequeNum; }
        }

        protected override ListControl PaymentMode
        {
            get { return ddlpaymentmode; }
        }

        public bool IsFailedPostBack
        { get; set; }

        public bool IsProcessRequest
        {
            get
            {
                if (Request.QueryString[RefundRequest.ProcessRequest] != null)
                    return true;
                return false;
            }
        }

        //public string QuestionIdAnswerTestId
        //{
        //    get
        //    {
        //        return RegistrationFlow != null ? RegistrationFlow.QuestionIdAnswerTestId : string.Empty;
        //    }
        //    set
        //    {
        //        RegistrationFlow.QuestionIdAnswerTestId = value;
        //    }
        //}

        //public string DisqualifiedTest
        //{
        //    get
        //    {
        //        return RegistrationFlow != null ? RegistrationFlow.DisqualifiedTest : string.Empty;
        //    }
        //    set
        //    {
        //        RegistrationFlow.DisqualifiedTest = value;
        //    }
        //}

        protected const string IsValidCardHiddenFieldName = "IsCardValidForRefundHiddenField";

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            if (PaymentGatewayResponse != null)
            {
                if ((ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCard.PersistenceLayerId.ToString() || ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()) && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');", true);
                else if (ddlpaymentmode.SelectedItem.Value == PaymentType.ElectronicCheck.PersistenceLayerId.ToString() && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + errorMessage + "');", true);

            var testIds = new List<long>();
            TestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));
            ItemCartControl.TestIds = testIds;
            ItemCartControl.PackageId = PackageId;
            IsFailedPostBack = true;
            Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode_MaintainAfterFailedPostback", "SetValuesafterFailedPostBack(); ", true);
            divChangePackage.Style["Display"] = "block";
        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {

            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        protected Roles EventRegisteredBy
        {
            get
            {
                if (ViewState["EventRegisteredBy"] != null && !string.IsNullOrEmpty(ViewState["EventRegisteredBy"].ToString()))
                {
                    return (Roles)Enum.Parse(typeof(Roles), ViewState["EventRegisteredBy"].ToString());
                }
                return Roles.Customer;
            }
            set
            {
                ViewState["EventRegisteredBy"] = value;
            }
        }

        protected override string SourceCode { get; set; }

        protected override long SourceCodeId { get; set; }

        protected override decimal SourceCodeAmount { get; set; }

        protected OrganizationRoleUserModel CurrentOrgRole
        {
            get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole; }
        }

        private Roles _currentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;

        protected int ScreeningTime { get; set; }

        protected bool IsDynamicScheduling { get; set; }

        protected double SelectedSlotInterval { get; set; }

        protected string BookedSlotIds { get; set; }

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
                return Convert.ToInt64(EligibilityIdHiddenField.Value);
            }
            set { EligibilityIdHiddenField.Value = value.ToString(); }
        }

        protected bool IsTestCoveredByInsurance
        {
            get
            {
                return IsTestCoveredByInsuranceHiddenField.Value == Boolean.TrueString;
            }
        }

        protected override long ChargeCardId
        {
            get
            {
                return Convert.ToInt64(ChargeCardIdHiddenField.Value);
            }
            set { ChargeCardIdHiddenField.Value = value.ToString(); }
        }

        private string NewOrderString { get; set; }

        #region "Form Events"


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsFailedPostBack = false;
                ViewState["ReferredQuery"] = Request.UrlReferrer.PathAndQuery;

                if (Request.QueryString["EventCustomerID"] != null)
                    EventCustomerId = Convert.ToInt64(Request.QueryString["EventCustomerID"]);
                else if (Request.QueryString["EventId"] != null && Request.QueryString["CustomerId"] != null)
                {
                    EventId = Convert.ToInt64(Request.QueryString["EventId"]);
                    CustomerId = Convert.ToInt64(Request.QueryString["CustomerId"]);
                }

                SetCustomerDetail();

                BindAllDropDowns();
                RegisterJavaScriptEvents();

                //if (RegistrationFlow != null && !string.IsNullOrEmpty(RegistrationFlow.DisqualifiedTest))
                //{
                //    hfDisqualifedTest.Value = RegistrationFlow.DisqualifiedTest;
                //}

                //if (RegistrationFlow != null && !string.IsNullOrEmpty(RegistrationFlow.QuestionIdAnswerTestId))
                //{
                //    hfQuestionAnsTestId.Value = RegistrationFlow.QuestionIdAnswerTestId;
                //}

            }

            SetEventDetail(EventId.Value, CustomerId.Value);
            ItemCartControl.EventId = EventId.Value;
            ItemCartControl.RoleId = (long)_currentRole;

            //var eventTargetName = Request.Params.Get("__EVENTTARGET");
            //if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "AdjustOrder")
            //{
            //    AdjustOrder();
            //}

        }

        //protected void AdjustOrder()
        //{
        //    if (!string.IsNullOrEmpty(hfcouponid.Value) && Convert.ToInt32(hfcouponid.Value) > 0)
        //    {
        //        SourceCodeId = Convert.ToInt32(hfcouponid.Value);
        //        SourceCode = (!string.IsNullOrEmpty(hfAppliedCouponID.Value) && Convert.ToInt32(hfAppliedCouponID.Value) > 0) ? spcoupon.InnerHtml.Trim() : txtcoupon.Text;
        //        SourceCodeAmount = Convert.ToDecimal(hfcouponamount.Value) < 0 ? -1 * Convert.ToDecimal(hfcouponamount.Value) : Convert.ToDecimal(hfcouponamount.Value);
        //    }
        //    else
        //    {
        //        SourceCodeId = 0;
        //        SourceCode = string.Empty;
        //        SourceCodeAmount = 0;
        //    }
        //    TotalAmountPayable = Convert.ToDecimal(hfamountpayable.Value);
        //    if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin) || CurrentOrgRole.CheckRole((long)Roles.CallCenterRep))
        //    {
        //        if (TotalAmountPayable.Value > 0)
        //        {
        //            var paymentRestriction = IoC.Resolve<IPrePaymentRestriction>();
        //            if (Convert.ToDecimal(PaidAmountHiddenControl.Value) > 0)
        //            {
        //                var currentPackagePrice = Convert.ToDecimal(hfCurrentPackagePrice.Value);
        //                var newPackagePrice = Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value);

        //                TotalAmountPayable =
        //                    paymentRestriction.GetAllowedPrepaymentByChargeCard(
        //                        PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()
        //                            ? (ChargeCardType)Convert.ToInt32(hfCardTypeId.Value)
        //                            : (ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue),
        //                            TotalAmountPayable.Value);
        //                //newPackagePrice - currentPackagePrice - Convert.ToDecimal(hfcouponamount.Value));
        //            }
        //            else
        //            {
        //                TotalAmountPayable = paymentRestriction.GetAllowedPrepaymentByChargeCard(
        //                    PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()
        //                        ? (ChargeCardType)Convert.ToInt32(hfCardTypeId.Value)
        //                        : (ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue),
        //                    TotalAmountPayable.Value);
        //            }
        //        }
        //    }
        //    var testIds = new List<long>();
        //    TestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));
        //    TestIds = testIds;
        //    PackageId = Convert.ToInt64(PackageIdHiddenControl.Value);


        //    var addOnTestIds = new List<long>();
        //    IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => addOnTestIds.Add(Convert.ToInt64(t)));
        //    var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
        //    var screeningTime = eventPackageSelectorService.GetScreeningTime(EventId.Value, PackageId, addOnTestIds);

        //    var tempraryBookedSlotsIds = new List<long>();
        //    if (!string.IsNullOrEmpty(hfSlotIds.Value))
        //    {
        //        hfSlotIds.Value.Split(',').ToList().ForEach(t => tempraryBookedSlotsIds.Add(Convert.ToInt64(t)));
        //    }
        //    var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
        //    var healthAssessmentService = IoC.Resolve<IHealthAssessmentService>();
        //    var orgRoleId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        //    bool doEventRegistrationRedirect = false;
        //    try
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            string newOrderString;
        //            doEventRegistrationRedirect = ChangePackage(out newOrderString);
        //            if (doEventRegistrationRedirect)
        //            {
        //                if ((!CurrentOrgRole.CheckRole((long)Roles.Technician) && !CurrentOrgRole.CheckRole((long)Roles.NursePractitioner)) || Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value) < Convert.ToDecimal(hfCurrentPackagePrice.Value))
        //                    eventAppointmentService.AdjustAppointment(EventCustomerId, screeningTime, tempraryBookedSlotsIds, hfIsNewAppoitmentSelected.Value == Boolean.TrueString);
        //                var newPackagePrice = Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value);

        //                if (CallQueueCustomerId.HasValue)
        //                {
        //                    var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
        //                    var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId.Value);
        //                    var criteriaRepository = IoC.Resolve<ISystemGeneratedCallQueueCriteriaRepository>();
        //                    var criteria = criteriaRepository.GetQueueCriteria(callQueueCustomer.CallQueueId,
        //                        IoC.Resolve<ISessionContext>()
        //                            .UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        //                    if (newPackagePrice > criteria.Amount)
        //                    {
        //                        callQueueCustomerRepository.UpdateCallQueueCustomerStatusByCallQueueId(CallQueueCustomerId.Value, CallQueueStatus.Completed);
        //                        // incase upsale is done from Confirmation Queue update the upsellQueue

        //                        var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
        //                        var callQueue = callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Confirmation.ToString());
        //                        if (callQueueCustomer.CallQueueId == callQueue.Id)
        //                        {
        //                            callQueue = callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Upsell.ToString());
        //                            var upsellCallQueueCustomer = callQueueCustomerRepository.GetByCallQueueIdCustomerIdEventId(callQueue.Id, callQueueCustomer.ProspectCustomerId ?? 0, callQueueCustomer.CustomerId ?? 0, callQueueCustomer.EventId ?? 0);
        //                            callQueueCustomerRepository.UpdateCallQueueCustomerStatusByCallQueueId(upsellCallQueueCustomer.Id, CallQueueStatus.Completed);
        //                        }
        //                    }
        //                }
        //                if (!string.IsNullOrEmpty(GuId))
        //                {
        //                    healthAssessmentService.UpdateClinicalQuestions(GuId, EventId.Value, CustomerId.Value, orgRoleId);
        //                }

        //                scope.Complete();

        //                #region Audit

        //                //var auditLogModel = new 
        //                //{
        //                //    EventId, Host = sphostname.InnerHtml, AppointmentTime = spapptime.InnerHtml, OldOrder = sppackagename.InnerHtml, Cost = sppackagecost.InnerHtml
        //                //    ,SourceCode = spcoupon.InnerHtml,PaymentDetails = sppaymentdetails.InnerHtml, PackageId 
        //                //};
        //                dynamic auditLogModel = new ExpandoObject();

        //                auditLogModel.EventId = EventId;
        //                auditLogModel.Host = sphostname.InnerHtml;
        //                auditLogModel.AppointmentTime = spapptime.InnerHtml;
        //                auditLogModel.Cost = sppackagecost.InnerHtml;
        //                auditLogModel.SourceCode = spcoupon.InnerHtml;
        //                auditLogModel.PaymentDetails = sppaymentdetails.InnerHtml;
        //                auditLogModel.PackageId = PackageId;
        //                auditLogModel.OldOrder = sppackagename.InnerText;
        //                if (newOrderString == "")
        //                {
        //                    LogAudit(ModelType.View, auditLogModel, Customer.CustomerId);
        //                }
        //                else
        //                {
        //                    auditLogModel.NewOrder = newOrderString;
        //                    LogAudit(ModelType.Edit, auditLogModel, Customer.CustomerId);
        //                }

        //                //logList.Add(auditLogModel);
        //                //logList.Add(addOnTestIds);
        //                //LogAudit(ModelType.List, logList);
        //                #endregion
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
        //        doEventRegistrationRedirect = false;
        //    }

        //    if (doEventRegistrationRedirect)
        //        SetPageReDirection();
        //}

        protected void ibtnchangepackage_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(hfcouponid.Value) && Convert.ToInt32(hfcouponid.Value) > 0)
            {
                SourceCodeId = Convert.ToInt32(hfcouponid.Value);
                SourceCode = (!string.IsNullOrEmpty(hfAppliedCouponID.Value) && Convert.ToInt32(hfAppliedCouponID.Value) > 0) ? spcoupon.InnerHtml.Trim() : txtcoupon.Text;
                SourceCodeAmount = Convert.ToDecimal(hfcouponamount.Value) < 0 ? -1 * Convert.ToDecimal(hfcouponamount.Value) : Convert.ToDecimal(hfcouponamount.Value);
            }
            else
            {
                SourceCodeId = 0;
                SourceCode = string.Empty;
                SourceCodeAmount = 0;
            }
            TotalAmountPayable = Convert.ToDecimal(hfamountpayable.Value);
            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin) || CurrentOrgRole.CheckRole((long)Roles.CallCenterRep))
            {
                if (TotalAmountPayable.Value > 0)
                {
                    var paymentRestriction = IoC.Resolve<IPrePaymentRestriction>();
                    if (Convert.ToDecimal(PaidAmountHiddenControl.Value) > 0)
                    {
                        var currentPackagePrice = Convert.ToDecimal(hfCurrentPackagePrice.Value);
                        var newPackagePrice = Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value);

                        TotalAmountPayable =
                            paymentRestriction.GetAllowedPrepaymentByChargeCard(
                                PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()
                                    ? (ChargeCardType)Convert.ToInt32(hfCardTypeId.Value)
                                    : (ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue),
                                    TotalAmountPayable.Value);
                        //newPackagePrice - currentPackagePrice - Convert.ToDecimal(hfcouponamount.Value));
                    }
                    else
                    {
                        TotalAmountPayable = paymentRestriction.GetAllowedPrepaymentByChargeCard(
                            PaymentMode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()
                                ? (ChargeCardType)Convert.ToInt32(hfCardTypeId.Value)
                                : (ChargeCardType)Convert.ToInt32(CreditCardTypeCombo.SelectedValue),
                            TotalAmountPayable.Value);
                    }
                }
            }
            var testIds = new List<long>();
            TestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));
            TestIds = testIds;
            PackageId = Convert.ToInt64(PackageIdHiddenControl.Value);


            var addOnTestIds = new List<long>();
            IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => addOnTestIds.Add(Convert.ToInt64(t)));
            var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
            var screeningTime = eventPackageSelectorService.GetScreeningTime(EventId.Value, PackageId, addOnTestIds);

            var tempraryBookedSlotsIds = new List<long>();
            if (!string.IsNullOrEmpty(hfSlotIds.Value))
            {
                hfSlotIds.Value.Split(',').ToList().ForEach(t => tempraryBookedSlotsIds.Add(Convert.ToInt64(t)));
            }
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            var healthAssessmentService = IoC.Resolve<IHealthAssessmentService>();
            var orgRoleId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            SavePreQualificationQuestionAnswer(EventCustomerId, orgRoleId);

            bool doEventRegistrationRedirect = false;
            try
            {
                using (var scope = new TransactionScope())
                {
                    string newOrderString;
                    doEventRegistrationRedirect = ChangePackage(out newOrderString);
                    if (doEventRegistrationRedirect)
                    {
                        if ((!CurrentOrgRole.CheckRole((long)Roles.Technician) && !CurrentOrgRole.CheckRole((long)Roles.NursePractitioner)) || Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value) < Convert.ToDecimal(hfCurrentPackagePrice.Value))
                            eventAppointmentService.AdjustAppointment(EventCustomerId, screeningTime, tempraryBookedSlotsIds, hfIsNewAppoitmentSelected.Value == Boolean.TrueString);
                        var newPackagePrice = Convert.ToDecimal(CurrentOrderPriceHiddenControl.Value);

                        if (CallQueueCustomerId.HasValue)
                        {
                            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                            var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId.Value);
                            var criteriaRepository = IoC.Resolve<ISystemGeneratedCallQueueCriteriaRepository>();
                            var criteria = criteriaRepository.GetQueueCriteria(callQueueCustomer.CallQueueId,
                                IoC.Resolve<ISessionContext>()
                                    .UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                            if (newPackagePrice > criteria.Amount)
                            {
                                callQueueCustomerRepository.UpdateCallQueueCustomerStatusByCallQueueId(CallQueueCustomerId.Value, CallQueueStatus.Completed);
                                // incase upsale is done from Confirmation Queue update the upsellQueue

                                var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
                                var callQueue = callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Confirmation.ToString());
                                if (callQueueCustomer.CallQueueId == callQueue.Id)
                                {
                                    callQueue = callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Upsell.ToString());
                                    var upsellCallQueueCustomer = callQueueCustomerRepository.GetByCallQueueIdCustomerIdEventId(callQueue.Id, callQueueCustomer.ProspectCustomerId ?? 0, callQueueCustomer.CustomerId ?? 0, callQueueCustomer.EventId ?? 0);
                                    callQueueCustomerRepository.UpdateCallQueueCustomerStatusByCallQueueId(upsellCallQueueCustomer.Id, CallQueueStatus.Completed);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(GuId))
                        {
                            healthAssessmentService.UpdateClinicalQuestions(GuId, EventId.Value, CustomerId.Value, orgRoleId);
                        }

                        scope.Complete();

                        #region Audit

                        //var auditLogModel = new 
                        //{
                        //    EventId, Host = sphostname.InnerHtml, AppointmentTime = spapptime.InnerHtml, OldOrder = sppackagename.InnerHtml, Cost = sppackagecost.InnerHtml
                        //    ,SourceCode = spcoupon.InnerHtml,PaymentDetails = sppaymentdetails.InnerHtml, PackageId 
                        //};
                        dynamic auditLogModel = new ExpandoObject();

                        auditLogModel.EventId = EventId;
                        auditLogModel.Host = sphostname.InnerHtml;
                        auditLogModel.AppointmentTime = spapptime.InnerHtml;
                        auditLogModel.Cost = sppackagecost.InnerHtml;
                        auditLogModel.SourceCode = spcoupon.InnerHtml;
                        auditLogModel.PaymentDetails = sppaymentdetails.InnerHtml;
                        auditLogModel.PackageId = PackageId;
                        auditLogModel.OldOrder = sppackagename.InnerText;
                        if (newOrderString == "")
                        {
                            LogAudit(ModelType.View, auditLogModel, Customer.CustomerId);
                        }
                        else
                        {
                            auditLogModel.NewOrder = newOrderString;
                            LogAudit(ModelType.Edit, auditLogModel, Customer.CustomerId);
                        }

                        //logList.Add(auditLogModel);
                        //logList.Add(addOnTestIds);
                        //LogAudit(ModelType.List, logList);
                        #endregion
                    }
                }

                if (doEventRegistrationRedirect)
                {
                    var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                    IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
                    var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);

                    //If patient is marked NoShow, we will not update the Visit Status in HRA on adjust order.
                    var eventRepository = IoC.Resolve<IEventRepository>();
                    var eventData = eventRepository.GetById(eventCustomer.EventId);

                    var testResultService = IoC.Resolve<TestResultService>();
                    var isEawvPurchased = testResultService.IsTestPurchasedByCustomer(eventCustomer.EventId, eventCustomer.CustomerId, (long)TestType.eAWV);

                    var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(eventCustomer.EventId);
                    var settings = IoC.Resolve<ISettings>();

                    var medicare = IoC.Resolve<IMedicareApiService>();
                    var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                    var questionaireType = account == null ? QuestionnaireType.None : accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, eventData.EventDate);
                   
                    if (settings.SyncWithHra)
                    {
                        if (currentSession != null && questionaireType == QuestionnaireType.HraQuestionnaire)
                        {
                            var token = (Session.SessionID + "_" + currentSession.UserId + "_" + currentSession.CurrentOrganizationRole.RoleId + "_" + currentSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                            try
                            {
                                medicare.Connect(currentSession.UserLoginLogId);
                            }
                            catch (Exception)
                            {
                                var auth = new MedicareAuthenticationModel
                                {
                                    UserToken = token,
                                    CustomerId = 0,
                                    OrgName = settings.OrganizationNameForHraQuestioner,
                                    Tag = settings.OrganizationNameForHraQuestioner,
                                    IsForAdmin = true,
                                    RoleAlias = "CallCenterRep"
                                };
                                medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);
                                medicare.Connect(currentSession.UserLoginLogId);
                            }

                            if (isEawvPurchased)
                            {
                                if (!eventCustomer.AwvVisitId.HasValue || eventCustomer.AwvVisitId.Value <= 0 && !eventCustomer.NoShow)
                                {
                                    try
                                    {
                                        var medicareService = IoC.Resolve<IMedicareService>();
                                        var model = medicareService.GetCustomerDetails(eventCustomer.CustomerId);
                                        model.Tag = account.Tag;

                                        model.EventDetails = new MedicareEventEditModel { EventId = eventCustomer.EventId, VisitDate = eventData.EventDate };
                                        var result = medicare.PostAnonymous<MedicareCustomerSetupViewModel>(settings.MedicareApiUrl + MedicareApiUrl.CreateUpdateCustomer, model);
                                        if (result != null && result.PatientVisitId > 0)
                                        {
                                            RegistrationFlow.AwvVisitId = result.PatientVisitId;

                                            eventCustomer.AwvVisitId = result.PatientVisitId;
                                            eventCustomerRepository.Save(eventCustomer);

                                            medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + result.PatientVisitId + "&status=" + (int)MedicareVisitStatus.BookedForEvent + "&unlock=true");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while syncing event customer to Medicare. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        if (eventCustomer.NoShow)
                                        {
                                            var isSuccess = medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.NoShow + "&unlock=true");
                                        }
                                        else
                                        {
                                            var isSuccess = medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.BookedForEvent + "&unlock=true");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while updating visit status in Medicare. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                                    }
                                }
                            }
                            else if (eventCustomer.AwvVisitId.HasValue && eventCustomer.AwvVisitId.Value > 0)
                            {
                                try
                                {
                                    var isSuccess = medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.Initiated + "&unlock=true");
                                }
                                catch (Exception ex)
                                {
                                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while updating visit status in Medicare. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                doEventRegistrationRedirect = false;
            }

            if (doEventRegistrationRedirect)
                SetPageReDirection();
        }

        protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
        {
            string redirecturl = ViewState["ReferredQuery"].ToString();
            Response.RedirectUser(redirecturl);
        }

        protected void imgCancelBefore_Click(object sender, ImageClickEventArgs e)
        {
            string redirecturl = ViewState["ReferredQuery"].ToString();
            Response.RedirectUser(redirecturl);
        }

        #endregion

        private void RegisterJavaScriptEvents()
        {
            txtamount.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtChequeNum.Attributes.Add("onKeyDown", "return txtkeypress_NumericAlphanumeric(event);");

            ddlpaymentmode.Attributes.Add("onChange", "OpenCloseDiv('" + ddlpaymentmode.ClientID + "')");

            txtCardNo.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtSecurityNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
        }

        private void BindAllDropDowns()
        {
            BindCountryDropDown();
            BindPageDropDowns();
        }

        protected override void BindPaymentModeDropDown()
        {
            if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                DateTime eventDate = Convert.ToDateTime(ViewState["EventDate"].ToString());
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                if (eventDate > DateTime.Now)
                {
                    ddlpaymentmode.Items.Add(new ListItem(PaymentType.Onsite_Text, PaymentType.Onsite_Value.ToString()));
                }
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Customer))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                      PaymentType.Cash.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                      PaymentType.Check.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.PayLater_Text, PaymentType.Onsite_Value.ToString()));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
            {
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.ElectronicCheck.Name,
                                                      PaymentType.ElectronicCheck.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Add(new ListItem(PaymentType.Onsite_Text, PaymentType.Onsite_Value.ToString()));
            }

            var listItems = ddlpaymentmode.Items.Cast<ListItem>().ToList().OrderBy(li => li.Text).ToArray();
            ddlpaymentmode.Items.Clear();
            ddlpaymentmode.Items.AddRange(listItems);

            ddlpaymentmode.Items.Insert(0, new ListItem("Pay By:", "0"));
        }

        private void BindCountryDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            ddlcountry.DataSource = countries;
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataValueField = "Id";
            ddlcountry.DataBind();
            //ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
            ddlcountry.Items[0].Selected = true;

            ddlEcountry.DataSource = countries;
            ddlEcountry.DataTextField = "Name";
            ddlEcountry.DataValueField = "Id";
            ddlEcountry.DataBind();
            //ddlEcountry.Items.Insert(0, new ListItem("Select Country", "0"));
            ddlEcountry.Items[0].Selected = true;
        }

        private void SetCustomerDetail()
        {
            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
            EventCustomer eventCustomer;

            if (EventCustomerId < 1)
                eventCustomer = ((IEventCustomerRepository)eventCustomerRepository).Get(EventId.Value, CustomerId.Value);
            else
                eventCustomer = eventCustomerRepository.GetById(EventCustomerId);

            if (eventCustomer != null)
            {
                EventCustomerId = eventCustomer.Id;
                CustomerId = eventCustomer.CustomerId;
                EventId = eventCustomer.EventId;
                EventIdHiddenControl.Value = EventId.ToString();

                var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(eventCustomer.DataRecorderMetaData.DataRecorderCreator.Id);

                EventRegisteredBy = (Roles)Enum.Parse(typeof(Roles), orgRoleUser.RoleId.ToString());

                speventid.InnerHtml = EventId.ToString();

                if (Customer != null && Customer.Address != null)
                {
                    spcustomername.InnerHtml = " " + "-" + " " + Customer.Name;
                    spcustomerid.InnerHtml = "(ID:" + Customer.CustomerId + ")";
                }

                var eventService = IoC.Resolve<IEventService>();
                var eventBasicInfoViewModel = eventService.GetEventBasicInfoFor(eventCustomer.EventId);

                sphostname.InnerText = eventBasicInfoViewModel.HostName;
                spaddress.InnerText =
                    CommonCode.AddressSingleLine(eventBasicInfoViewModel.HostAddress.StreetAddressLine1,
                                                 eventBasicInfoViewModel.HostAddress.StreetAddressLine2,
                                                 eventBasicInfoViewModel.HostAddress.City,
                                                 eventBasicInfoViewModel.HostAddress.State,
                                                 eventBasicInfoViewModel.HostAddress.ZipCode);

                speventdate.InnerText = eventBasicInfoViewModel.EventDate.ToShortDateString();
                ViewState["EventDate"] = eventBasicInfoViewModel.EventDate.ToShortDateString();

                if (eventCustomer.AppointmentId.HasValue)
                {
                    var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                    var appointment = appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                    spapptime.InnerText = appointment.StartTime.ToShortTimeString();
                }

                IOrderRepository orderRepository = new OrderRepository();
                var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);
                if (order != null && !order.OrderDetails.IsEmpty())
                {
                    OrderId = order.Id;
                    SetOrderDetails(order);
                    SetRefundRequestAmount(OrderId);
                    SetPaymentDetails(order);

                    var testIds = new List<long>();
                    var additionalTestIds = new List<long>();
                    var testsName = string.Empty;
                    foreach (var orderDetail in order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess))
                    {
                        IOrderItemRepository orderItemRepository = new OrderItemRepository();
                        var orderItem = orderItemRepository.GetOrderItem(orderDetail.OrderItemId);

                        if (orderItem.OrderItemType == OrderItemType.EventPackageItem)
                        {
                            var eventPackageItem = orderItem as EventPackageItem;

                            var itemRepository = IoC.Resolve<IEventPackageRepository>();
                            var eventPackage = itemRepository.GetById(eventPackageItem.ItemId);
                            PackageId = eventPackage.PackageId;

                            var package = eventPackage.Package;
                            sppackagename.InnerText = package.Name;
                            testIds.AddRange(package.Tests.Select(t => t.Id));
                        }
                        else if (orderItem.OrderItemType == OrderItemType.EventTestItem)
                        {
                            var eventTestItem = orderItem as EventTestItem;

                            var itemRepository = IoC.Resolve<IEventTestRepository>();
                            var eventTest = itemRepository.GetbyId(eventTestItem.ItemId);
                            testIds.Add(eventTest.TestId);
                            additionalTestIds.Add(eventTest.TestId);

                            testsName += string.IsNullOrEmpty(testsName)
                                             ? eventTest.Test.Name
                                             : ", " + eventTest.Test.Name;
                        }
                    }

                    sppackagename.InnerText += string.IsNullOrEmpty(sppackagename.InnerHtml)
                                                   ? testsName
                                                   : ", " + testsName;

                    TestIds = testIds;
                    ItemCartControl.TestIds = testIds;
                    ItemCartControl.PackageId = PackageId;

                    var eligibilityService = IoC.Resolve<IEligibilityService>();
                    var isTestCoveredByInsurance = eligibilityService.CheckTestCoveredByinsurance(EventId.Value, PackageId, additionalTestIds);
                    IsTestCoveredByInsuranceHiddenField.Value = isTestCoveredByInsurance ? Boolean.TrueString : Boolean.FalseString;

                    var eligibilityRepository = IoC.Resolve<IEligibilityRepository>();
                    var eligibility = eligibilityRepository.GetEventCustomerEligibilityIdByEventCustomerId(eventCustomer.Id);
                    if (eligibility != null)
                    {
                        EligibilityId = eligibility.EligibilityId;
                        ChargeCardId = eligibility.ChargeCardId.HasValue && eligibility.ChargeCardId.Value > 0 ? eligibility.ChargeCardId.Value : 0;
                    }
                    else
                    {
                        EligibilityId = 0;
                        ChargeCardId = 0;
                    }
                    IOrderController orderController = new OrderController();
                    var activeOrderDetail = orderController.GetActiveOrderDetail(order);
                    if (activeOrderDetail.SourceCodeOrderDetail != null)
                    {
                        ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                        var sourceCode =
                            sourceCodeRepository.GetSourceCodeById(activeOrderDetail.SourceCodeOrderDetail.SourceCodeId);
                        spcoupon.InnerText = sourceCode.CouponCode;
                    }
                    else
                        spcoupon.InnerText = "N/A";
                    SetSourceCodeDetail(order);
                }
            }
        }

        private void SetRefundRequestAmount(long orderId)
        {
            var refundRequestRepository = IoC.Resolve<IRefundRequestRepository>();
            var refundRequests = refundRequestRepository.GetbyOrderId(orderId);
            if (refundRequests != null)
            {
                RefundRequestAmount.Value = refundRequests.Where(
                    rr => rr.RefundRequestType != RefundRequestType.ChangePackage).Sum(
                        rr => rr.RequestedRefundAmount).ToString("0.00");
            }
        }

        private void SetOrderDetails(Core.Finance.Domain.Order order)
        {
            var totalPrice = order.OrderValue;
            txtamount.Text = totalPrice.ToString("0.00");
            hfCurrentPackagePrice.Value = totalPrice.ToString("0.00");
            sppackagecost.InnerHtml = "$" + totalPrice.ToString("0.00");
            hfPackageCost.Value = totalPrice.ToString("0.00");
        }

        private void SetSourceCodeDetail(Core.Finance.Domain.Order order)
        {
            IOrderController orderController = new OrderController();
            var orderDetail = orderController.GetActiveOrderDetail(order);
            if (orderDetail != null && orderDetail.SourceCodeOrderDetail != null)
            {
                if (orderDetail.SourceCodeOrderDetail.SourceCodeId > 0)
                {
                    Page.ClientScript.RegisterHiddenField("ExistingCouponCodeInputHidden", spcoupon.InnerHtml.Trim());
                    hfcurrentcouponamount.Value = orderDetail.SourceCodeOrderDetail.Amount.ToString("0.00");
                    spApplySCodeTitle.InnerText = "Replace Existing Source Code";
                    hfIsAppliedCoupon.Value = Convert.ToString(true).ToLower();

                    var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();
                    var coupon = sourceCodeRepository.GetSourceCodeById(orderDetail.SourceCodeOrderDetail.SourceCodeId);
                    if (coupon != null)
                    {
                        hfAppliedCouponID.Value = coupon.Id.ToString();
                        hfAppliedMinPurchaseAmount.Value = coupon.MinimumPurchaseAmount.ToString();
                        ExistingCouponCodeHiddenControl.Value = coupon.CouponCode;
                        if (!(coupon.PackageDiscounts != null && coupon.PackageDiscounts.Count() > 0))
                        {
                            hfAppliedCouponPercentage.Value = coupon.DiscountValueType == DiscountValueType.Percent
                                                                  ? "true"
                                                                  : "false";
                            hfAppliedCouponValue.Value = coupon.CouponValue.ToString();
                        }
                        else
                        {
                            hfAppliedCouponDiscountTypePackageWise.Value = "true";
                            hfAppliedCouponPercentage.Value = false.ToString().ToLower();
                        }
                    }
                }
            }
        }

        private void SetPaymentDetails(Core.Finance.Domain.Order order)
        {
            TotalAmountPayable = order.DiscountedTotal - order.TotalAmountPaid;
            UnpaidAmountHiddenControl.Value = TotalAmountPayable.Value.ToString("0.00");
            PaidAmountHiddenControl.Value = order.TotalAmountPaid.ToString("0.00");
            hfamountpayable.Value = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");

            if (order.PaymentsApplied != null && !order.PaymentsApplied.IsEmpty())
            {
                SetCreditCardOnFileDetails(order);

                bool isUnpaid = true;
                string paidString = string.Empty;
                //decimal paidAmount = 0.00m;
                foreach (var paymentApplied in order.PaymentsApplied)
                {
                    if (string.IsNullOrEmpty(paidString))
                        paidString = "Paid Amount:";

                    if (paymentApplied.Amount > 0)
                    {
                        //paidAmount += paymentApplied.Amount;
                        paidString += " $" + paymentApplied.Amount.ToString("0.00") + " (" + paymentApplied.PaymentType + "),";
                        isUnpaid = false;
                    }
                    else if (paymentApplied.Amount < 0)
                    {
                        //paidAmount += paymentApplied.Amount;
                        paidString += " Refund Amount: $" + (-1 * paymentApplied.Amount).ToString("0.00") + " (" + paymentApplied.PaymentType + "),";
                        isUnpaid = false;
                    }
                }
                if (TotalAmountPayable < 0)
                    paidString += " | Unpaid Amount: $" + (TotalAmountPayable.Value * -1).ToString("0.00") + " <i>(To Refund) </i>";
                else
                    paidString += " | Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");

                if (paidString.Substring(paidString.Length - 1, 1) == ",")
                    paidString = paidString.Substring(0, paidString.Length - 1);
                //hfpaidamount.Value = paidAmount.ToString("N2");

                if (isUnpaid)
                    sppaymentdetails.InnerText = "Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");
                else
                    sppaymentdetails.InnerHtml = paidString;
            }
            else
                sppaymentdetails.InnerText = "Unpaid Amount: $" + TotalAmountPayable.Value.ToString("0.00");
        }

        private void SetCreditCardOnFileDetails(Core.Finance.Domain.Order order)
        {
            var creditCardPaymentInstrument =
                order.PaymentsApplied.OrderBy(pa => pa.DataRecorderMetaData.DateCreated).LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
                ChargeCardPayment;


            if (creditCardPaymentInstrument == null) return;

            string reasonForFailure = "";

            if (!IoC.Resolve<IChargeCardService>().IsCardValidforRefund(creditCardPaymentInstrument, 0, out reasonForFailure))
                Page.ClientScript.RegisterHiddenField(IsValidCardHiddenFieldName, Boolean.FalseString);
            else
                Page.ClientScript.RegisterHiddenField(IsValidCardHiddenFieldName, Boolean.TrueString);

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

                spexpdate.InnerHtml = existingChargeCard.ExpirationDate.ToString("MM/yyyy");
                hfCardTypeId.Value = ((int)existingChargeCard.TypeId).ToString();
                ddlpaymentmode.Items.Clear();
                ddlpaymentmode.Items.Insert(ddlpaymentmode.Items.Count, new ListItem(PaymentType.CreditCardOnFile_Text, PaymentType.CreditCardOnFile_Value.ToString()));
                ExistingChargeCardId.Value = existingChargeCard.Id.ToString();
            }
        }

        private void SetPageReDirection()
        {
            string redirecturl = ViewState["ReferredQuery"].ToString();

            if (IsProcessRequest)
                Response.RedirectUser("/Finance/RefundRequest");

            if (redirecturl.ToLower().IndexOf("action=appointment") >= 0)
                redirecturl = redirecturl.ToLower().Replace("action=appointment", "action=Package");
            else if (redirecturl.ToLower().IndexOf("action=edit") >= 0)
                redirecturl = redirecturl.ToLower().Replace("action=edit", "action=Package");
            else if (redirecturl.ToLower().IndexOf("action=package") < 0)
                redirecturl = redirecturl + "&action=Package";

            if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep) && CallId.HasValue)
            {
                var repository = new CallCenterCallRepository();
                var call = repository.GetCallCenterEntity(CallId.Value);

                if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"].ToLower() == "no"))
                {
                    if (call != null)
                    {
                        EndCall();
                        StartCall(call.CalledCustomerID);
                    }
                }
            }
            redirecturl = redirecturl.Replace("call=no", "Call=No");
            Response.RedirectUser(redirecturl);
        }

        private void StartCall(long calledCustomerid)
        {
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

        private void EndCall()
        {
            if (CallId == null) return;
            var repository = new CallCenterCallRepository();
            repository.UpdateCallEnd(DateTime.Now, CallId.Value);
        }

        private void SetEventDetail(long eventId, long customerId)
        {
            var eventRepository = IoC.Resolve<IEventRepository>();
            var theEvent = eventRepository.GetById(eventId);
            IsDynamicScheduling = theEvent.IsDynamicScheduling;

            ScreeningTime = GetScreeningTime(eventId, customerId);

            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);
            if (eventCustomer.AppointmentId.HasValue)
            {
                var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
                var appointment = appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

                var slots = eventSchedulingSlotRepository.GetbyIds(appointment.SlotIds);
                BookedSlotIds = string.Join(",", appointment.SlotIds);
                SelectedSlotInterval = (slots.Last().EndTime - slots.First().StartTime).TotalMinutes;
            }
        }

        private int GetScreeningTime(long eventId, long customerId)
        {
            var orderRepository = IoC.Resolve<IOrderRepository>();

            var order = EventCustomerId > 0
                            ? orderRepository.GetOrderByEventCustomerId(EventCustomerId)
                            : orderRepository.GetOrder(customerId, eventId);

            var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();

            return eventPackageSelectorService.GetScreeningTime(order);
        }
        private void SavePreQualificationQuestionAnswer(long eventCustomerId, long organizationRoleUserId)
        {
            if (eventCustomerId > 0 && !string.IsNullOrEmpty(hfQuestionAnsTestId.Value) && CustomerId.HasValue && CustomerId.Value > 0 && EventId.HasValue && EventId.Value > 0)
            {
                var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(hfQuestionAnsTestId.Value, hfDisqualifedTest.Value, eventCustomerId, CustomerId.Value, EventId.Value, organizationRoleUserId);
            }
        }
    }
}