using System;
using System.Collections.Generic;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.DataAccess.Deprecated;
using Falcon.DataAccess.Master;
using Falcon.Entity.CallCenter;
using Falcon.Entity.Other;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.CallCenter.Interfaces;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep
{
    public partial class BasicCallInfo : Page
    {

        private long CurrentProspectCustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;
            }
            set
            {
                RegistrationFlow.ProspectCustomerId = value;
            }

        }

        protected long ExistingCallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        public OrganizationRoleUserModel CurrentOrganizationRole
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
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

        protected bool IsInboundCall { get { return !IoC.Resolve<ICallCenterRepository>().IsCallTypeOutbound(ExistingCallId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationFlow.CanSaveConsentInfo = false;
            if (Request.QueryString["guid"] == null || Request.QueryString["guid"] == string.Empty)
                Response.RedirectUser("/CallCenter/CallCenterRepDashboard/Index");

            SetDisplayControls();
            SetJavaScriptEvents();
            if (!IsPostBack)
            {
                var repository = new CallCenterCallRepository();
                ECall objCall = repository.GetCallCenterEntity(ExistingCallId);
                if (objCall != null && (!string.IsNullOrWhiteSpace(objCall.CallersPhoneNumber) || !string.IsNullOrWhiteSpace(objCall.CallBackNumber)))
                {
                    var commonCode = new CommonCode();
                    txtCallBackNo.Text = commonCode.FormatPhoneNumber(string.IsNullOrWhiteSpace(objCall.CallersPhoneNumber) ? objCall.CallBackNumber : objCall.CallersPhoneNumber);
                }

                hfCallStartTime.Value = objCall.TimeCreated;
                if ((Request.UrlReferrer != null) && Request.UrlReferrer.LocalPath == "/App/CallCenter/CallCenterRep/CustomerVerification.aspx")
                {
                    if (CurrentProspectCustomerId > 0)
                        SetProspectCustomerDataToControls();
                    if (RegistrationFlow != null)
                        txtSourceCode.Text = RegistrationFlow.CallSourceCode;
                    if (Request.QueryString["CustomerId"] != null)
                        txtCustomerID.Text = Request.QueryString["CustomerId"];
                }
                else if (Request.UrlReferrer != null && Request.UrlReferrer.LocalPath == "/App/CallCenter/CallCenterRep/AddNotes.aspx")
                {
                    if (CurrentProspectCustomerId > 0)
                    {
                        SetProspectCustomerDataToControls();
                        CurrentProspectCustomerId = 0;
                        txtFirstName.Text = "";
                    }
                }
                else if (CurrentProspectCustomerId > 0)
                {
                    SetProspectCustomerDataToControls();
                }

                if (RegistrationFlow != null)
                {
                    RegistrationFlow.CallSourceCode = string.Empty;
                    RegistrationFlow.SourceCode = string.Empty;
                    RegistrationFlow.SourceCodeId = 0;
                    RegistrationFlow.SourceCodeAmount = 0;
                    RegistrationFlow.TestIds = null;
                    RegistrationFlow.PackageId = 0;
                    RegistrationFlow.AppointmentSlotIds = null;
                    RegistrationFlow.ShippingDetailId = 0;
                    RegistrationFlow.ShippingOptionId = 0;
                    RegistrationFlow.ShippingAddressId = 0;
                    RegistrationFlow.ProductId = 0;
                    RegistrationFlow.PackageCost = 0;
                    RegistrationFlow.TotalAmount = 0;
                }
            }

            if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "Search")
                SearchCustomer();
        }

        protected void ibtnNext_Click(object sender, ImageClickEventArgs e)
        { }

        private void SetJavaScriptEvents()
        {
            txtFirstName.Attributes.Add("onKeyDown", "return txtkeypress_AlphanumericOnly(event);");
            txtLastName.Attributes.Add("onKeyDown", "return txtkeypress_AlphanumericOnly(event);");
            txtCustomerID.Attributes.Add("onKeyDown", "return txtkeypress(event);");
        }

        private void SetDisplayControls()
        {
            var callCenterMasterPage = (CallCenter_CallCenterMaster1)Master;
            callCenterMasterPage.SetTitle("Basic Call Information");
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
            callCenterMasterPage.hideucsearch();
        }

        private void SetProspectCustomerDataToControls()
        {
            var commonCode = new CommonCode();
            ProspectCustomer currentProspectCustomer = null;
            if (CurrentProspectCustomerId > 0)
            {
                var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                currentProspectCustomer = prospectCustomerRepository.GetById(CurrentProspectCustomerId);
                CurrentProspectCustomerId = currentProspectCustomer.Id;
            }
            if (currentProspectCustomer == null) return;

            txtFirstName.Text = currentProspectCustomer.FirstName;
            txtLastName.Text = currentProspectCustomer.LastName;
            txtZipCode.Text = currentProspectCustomer.Address.ZipCode.Zip;
            txtCallBackNo.Text = currentProspectCustomer.CallBackPhoneNumber != null
                                     ? commonCode.FormatPhoneNumber(
                                         currentProspectCustomer.CallBackPhoneNumber.ToString())
                                     : string.Empty;
        }

        private bool GetCustomerList()
        {
            bool callResult = false;
            bool zipResult = false;

            var organizationId = CurrentOrganizationRole.OrganizationId;

            var masterDal = new MasterDAL();
            List<ECustomers> customersOnCall = masterDal.SearchCustomersOnCall(txtFirstName.Text.Replace("'", "''"),
                txtLastName.Text.Replace("'", "''"), txtZipCode.Text, 0, txtCallBackNo.Text, txtCustomerID.Text, txtMemberId.Text, txtHicn.Text, txtPhoneNumber.Text, txtEmail.Text, organizationId, txtMbiNumber.Text);

            if (customersOnCall != null && customersOnCall.Count > 0)
                callResult = true;

            if (callResult == false && (txtZipCode.Text.Length > 0 || (txtCallBackNo.Text.Length > 0 && txtCallBackNo.Text != "(___)-___-____")))
            {
                customersOnCall = masterDal.SearchCustomersOnCall(txtFirstName.Text.Replace("'", "''"),
                    txtLastName.Text.Replace("'", "''"), txtZipCode.Text, 1, txtCallBackNo.Text, txtCustomerID.Text, txtMemberId.Text, txtHicn.Text, txtPhoneNumber.Text, txtEmail.Text, organizationId, txtMbiNumber.Text);
                if (customersOnCall != null && customersOnCall.Count > 0)
                    zipResult = true;
            }

            return callResult || zipResult;
        }

        private bool GetProspectCustomerList()
        {
            if (ExistingCallId > 0 && !string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text) && !string.IsNullOrWhiteSpace(txtCallBackNo.Text.Replace("(", "").Replace(")", "").Replace("-", "")))
            {
                IProspectCustomerRepository prospectCustomerRepository = new ProspectCustomerRepository();
                var listProspectCustomerViewData = prospectCustomerRepository.GetProspectCustomersWithFiltersforCallCenterRep(txtFirstName.Text, txtLastName.Text, txtCallBackNo.Text.Replace("(", "").Replace(")", "").Replace("-", ""));
                if (listProspectCustomerViewData != null && listProspectCustomerViewData.Count > 0)
                    return true;
            }
            return false;
        }

        private void SetProspectCustomer()
        {

            long? sourceCodeId = null;
            if (!string.IsNullOrEmpty(txtSourceCode.Text))
            {
                ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                try
                {
                    var sourceCode = sourceCodeRepository.GetSourceCodeByCode(txtSourceCode.Text);
                    if (sourceCode != null)
                        sourceCodeId = sourceCode.Id;
                }
                catch
                {
                    sourceCodeId = null;
                }
            }

            var commonCode = new CommonCode();
            var phoneNumber = commonCode.FormatPhoneNumber(txtCallBackNo.Text);
            ProspectCustomer prospectCustomer = null;
            if (CurrentProspectCustomerId > 0)
            {
                var proecpectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
                prospectCustomer = proecpectCustomerRepository.GetProspectCustomer(CurrentProspectCustomerId);
            }
            else
            {


                prospectCustomer = new ProspectCustomer
                                       {
                                           FirstName = txtFirstName.Text,
                                           LastName = txtLastName.Text,
                                           Address = new Address { ZipCode = new ZipCode { Zip = txtZipCode.Text } },
                                           Source = ProspectCustomerSource.CallCenter,
                                           Tag = ProspectCustomerTag.CallCenterSignup,
                                           TagUpdateDate = DateTime.Now
                                           //SourceCodeId = sourceCodeId
                                       };
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                prospectCustomer.CallBackPhoneNumber = new PhoneNumber
                                                                  {
                                                                      PhoneNumberType = PhoneNumberType.Unknown,
                                                                      Number =
                                                                          phoneNumber.Substring(3,
                                                                                                phoneNumber.Length - 3),
                                                                      AreaCode = phoneNumber.Substring(0, 3)
                                                                  };
            }
            if (ViewState["IncomingPhoneLine"] != null && !string.IsNullOrEmpty(ViewState["IncomingPhoneLine"].ToString()))
            {
                var incomingPhoneNumber = ViewState["IncomingPhoneLine"].ToString();
                prospectCustomer.PhoneNumber = new PhoneNumber
                                                                  {
                                                                      PhoneNumberType = PhoneNumberType.Unknown,
                                                                      Number =
                                                                          incomingPhoneNumber.Substring(3,
                                                                                                        incomingPhoneNumber
                                                                                                            .Length - 3),
                                                                      AreaCode = incomingPhoneNumber.Substring(0, 3)
                                                                  };
            }

            SaveProspectCustomerNew(prospectCustomer);
        }

        private void SaveProspectCustomerNew(ProspectCustomer prospectCustomer)
        {
            if (prospectCustomer != null && !string.IsNullOrEmpty(prospectCustomer.FirstName) && !string.IsNullOrEmpty(prospectCustomer.LastName) && prospectCustomer.CallBackPhoneNumber != null && !string.IsNullOrWhiteSpace(prospectCustomer.CallBackPhoneNumber.ToString()) && prospectCustomer.CallBackPhoneNumber.ToString() != "(___)-___-____")
            {
                var isNewProspectCustomer = prospectCustomer.Id <= 0;
                IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();
                prospectCustomer = uniqueItemRepository.Save(prospectCustomer);
                CurrentProspectCustomerId = prospectCustomer.Id;

                if (isNewProspectCustomer && ExistingCallId > 0 && CurrentProspectCustomerId > 0)
                {
                    var callWizardService = new CallCenterCallWizardService();
                    callWizardService.BindCurrentCallToProspectCustomer(ExistingCallId, CurrentProspectCustomerId, IoC.Resolve<ISessionContext>().UserSession.UserId);
                }
            }
        }

        private void SearchCustomer()
        {
            var repository = new CallCenterCallRepository();
            var objCall = repository.GetCallCenterEntity(ExistingCallId);

            ViewState["IncomingPhoneLine"] = objCall.IncomingPhoneLine;
            RegistrationFlow.CallSourceCode = txtSourceCode.Text;

            if (!string.IsNullOrEmpty(txtSourceCode.Text) || !string.IsNullOrEmpty(txtCallBackNo.Text))
            {
                objCall.SourceCode = txtSourceCode.Text;
                objCall.CallBackNumber = PhoneNumber.ToNumber(txtCallBackNo.Text);

                var callcenterDal = new CallCenterDAL();
                callcenterDal.UpdateCall(objCall);
            }

            if (GetCustomerList() == false && (txtCustomerID.Text.Trim().Length > 0 || GetProspectCustomerList() == false))
            {
                if (txtCustomerID.Text.Trim().Length > 0)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_NoRecordsFound",
                                                       "alert('Customer with ID " + txtCustomerID.Text.Trim() + " not found. Please try again.');", true);
                    return;
                }
                if (txtCustomerID.Text.Trim().Length == 0)
                {
                    CurrentProspectCustomerId = 0;
                    SetProspectCustomer();

                    Response.RedirectUser("CustomerOptions.aspx?FirstName=" + txtFirstName.Text + "&LastName=" + txtLastName.Text +
                                      "&CallBackNo=" + txtCallBackNo.Text + "&Zip=" + txtZipCode.Text + "&guid=" + GuId);
                }
            }
            else
            {
                if (txtCustomerID.Text.Trim().Length > 0)
                {
                    Response.RedirectUser("/App/CallCenter/CallCenterRep/CustomerOptions.aspx?CustomerID=" + txtCustomerID.Text.Trim() + "&guid=" + GuId);
                    //Response.RedirectUser("CustomerVerification.aspx?FirstName=" + txtFirstName.Text + "&LastName=" + txtLastName.Text +
                    //                  (!string.IsNullOrEmpty(txtCallBackNo.Text) ? "&CallBackNo=" + txtCallBackNo.Text : "") +
                    //                  (!string.IsNullOrEmpty(txtZipCode.Text) ? "&Zip=" + txtZipCode.Text : "") +
                    //                  (!string.IsNullOrEmpty(txtCustomerID.Text) ? "&CustomerId=" + txtCustomerID.Text.Trim() : "")
                    //                  + (!string.IsNullOrEmpty(txtMemberId.Text) ? "&MemberId=" + txtMemberId.Text : "")
                    //                  + (!string.IsNullOrEmpty(txtHicn.Text) ? "&Hicn=" + txtHicn.Text : "")
                    //                  + (!string.IsNullOrEmpty(txtPhoneNumber.Text) ? "&PhoneNumber=" + txtPhoneNumber.Text : "")
                    //                  + (!string.IsNullOrEmpty(txtEmail.Text) ? "&EmailId=" + txtEmail.Text : "")
                    //                  + (!string.IsNullOrEmpty(txtMbiNumber.Text) ? "&MbiNumber=" + txtMbiNumber.Text : "")
                    //                  + "&guid=" + GuId);
                }
                else
                {
                    if (CurrentProspectCustomerId > 0)
                        SetProspectCustomer();
                    Response.RedirectUser("CustomerVerification.aspx?FirstName=" + txtFirstName.Text + "&LastName=" + txtLastName.Text +
                                      (!string.IsNullOrEmpty(txtCallBackNo.Text) ? "&CallBackNo=" + txtCallBackNo.Text : "") +
                                      (!string.IsNullOrEmpty(txtZipCode.Text) ? "&Zip=" + txtZipCode.Text : "")
                                      + (!string.IsNullOrEmpty(txtMemberId.Text) ? "&MemberId=" + txtMemberId.Text : "")
                                      + (!string.IsNullOrEmpty(txtHicn.Text) ? "&Hicn=" + txtHicn.Text : "")
                                      + (!string.IsNullOrEmpty(txtPhoneNumber.Text) ? "&PhoneNumber=" + txtPhoneNumber.Text : "")
                                      + (!string.IsNullOrEmpty(txtEmail.Text) ? "&EmailId=" + txtEmail.Text : "")
                                      + (!string.IsNullOrEmpty(txtMbiNumber.Text) ? "&MbiNumber=" + txtMbiNumber.Text : "")
                                      + "&guid=" + GuId);
                }
            }
        }
    }
}