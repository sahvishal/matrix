using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.DataAccess.Deprecated;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.CallCenter.Interfaces;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep
{
    public partial class CustomerOptions : Page
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
                if (!String.IsNullOrWhiteSpace(Request.QueryString["CustomerId"]))
                {
                    long customerId;
                    if (Int64.TryParse(Request.QueryString["CustomerId"], out customerId))
                    {
                        RegistrationFlow.CustomerId = customerId;
                        return customerId;
                    }
                }
                return 0;
            }
        }

        public long ProspectCustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;
            }
        }

        protected long ExistingCallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        protected String FirstName
        {
            get { return Convert.ToString(Request.QueryString["FirstName"]); }
        }

        protected String LastName
        {
            get { return Convert.ToString(Request.QueryString["LastName"]); }
        }

        protected String CallBackNumber
        {
            get { return Convert.ToString(Request.QueryString["CallBackNo"]); }
        }

        protected String Zip
        {
            get { return Convert.ToString(Request.QueryString["Zip"]); }
        }

        protected string ScriptUrl
        {
            get { return RegistrationFlow != null ? RegistrationFlow.CallCenterScriptUrl : ""; }
        }

        protected bool IsInboundCall { get { return !IoC.Resolve<ICallCenterRepository>().IsCallTypeOutbound(ExistingCallId); } }


        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationFlow.CanSaveConsentInfo = true;
            var callCenterMasterPage = (CallCenter_CallCenterMaster1)Master;
            callCenterMasterPage.SetTitle("Customer Options");
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
            var repository = new CallCenterCallRepository();

            ViewScriptDiv.Visible = false;

            if (!IsPostBack)
            {
                hfCallStartTime.Value = repository.GetCallStarttime(ExistingCallId);

                if (CustomerId > 0)
                {
                    
                    imgSymbol.ImageUrl = "~/App/Images/CCRep/page3symbol.gif";
                    divOptions.Style.Add(HtmlTextWriterStyle.Display, "block");
                    spSearchType.InnerText = "Existing Customer Options";
                    divNewOptions.Style.Add(HtmlTextWriterStyle.Display, "none");

                    var customerRepository = IoC.Resolve<ICustomerRepository>();
                    var customer = customerRepository.GetCustomer(CustomerId);
                    
                    customername.InnerHtml = "<span style=\"color: #F37C00\">" + HttpUtility.HtmlEncode(customer.Name.FullName) +
                                             "</span>, how may i help you?";

                    long? healthPlanId = null;
                    if (!string.IsNullOrEmpty(customer.Tag))// && IsInboundCall
                    {
                        var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                        var corporateAccount = corporateAccountRepository.GetByTag(customer.Tag);

                        if (corporateAccount != null && corporateAccount.IsHealthPlan)
                            healthPlanId = corporateAccount.Id;

                        if (IsInboundCall)
                        {
                            if (corporateAccount != null && corporateAccount.ShowCallCenterScript && corporateAccount.CallCenterScriptFileId > 0)
                            {
                                ViewScriptDiv.Visible = true;

                                var fileRepository = IoC.Resolve<IUniqueItemRepository<File>>();
                                var mediaRepository = IoC.Resolve<IMediaRepository>();
                                var inboundCallScriptPdf = fileRepository.GetById(corporateAccount.CallCenterScriptFileId);
                                var mediaLocation = mediaRepository.GetCallCenterScriptPdfFolderLocation();
                                RegistrationFlow.CallCenterScriptUrl = mediaLocation.Url + inboundCallScriptPdf.Path;
                            }

                            if (corporateAccount != null && corporateAccount.WarmTransfer)
                            {
                                var customerWarmTransfer = IoC.Resolve<ICustomerWarmTransferRepository>().GetByCustomerIdAndYear(CustomerId, DateTime.Today.Year);
                                if (customerWarmTransfer != null && customerWarmTransfer.IsWarmTransfer.HasValue && customerWarmTransfer.IsWarmTransfer.Value)
                                    showWarmTransferMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
                            }
                        }
                    }

                    repository.UpdateCalledCustomerId(CustomerId, ExistingCallId, healthPlanId,customer.ProductTypeId);
                }
                else
                {
                    imgSymbol.ImageUrl = "~/App/Images/CCRep/page2symbol.gif";
                    divOptions.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divNewOptions.Style.Add(HtmlTextWriterStyle.Display, "block");
                    spSearchType.InnerText = "New Customer Options";
                    if (ProspectCustomerId > 0)
                    {
                        var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                        var prospectCustomer = prospectCustomerRepository.GetById(ProspectCustomerId);
                        customername.InnerHtml = "<span style=\"color: #F37C00\">" + HttpUtility.HtmlEncode(prospectCustomer.FirstName) +
                            " " + HttpUtility.HtmlEncode(prospectCustomer.LastName) + "</span>, how may i help you?";
                    }
                    else
                    {
                        customername.InnerHtml = "<span style=\"color: #F37C00\">" + HttpUtility.HtmlEncode(FirstName) +
                                " " + HttpUtility.HtmlEncode(LastName) + "</span>, how may i help you?";
                    }

                }
                // Coding if the call is for outbound 
                // Set the call as outbound
                if (Request.QueryString["CallType"] != null)
                {
                    if (Request.QueryString["CallType"].Equals("OutBound"))
                    {
                        spBtnSearchAgain.Style.Add(HtmlTextWriterStyle.Display, "none");
                        var callcenterDal = new CallCenterDAL();
                        List<EScript> outboundCallProspect;
                        if (Request.QueryString["Source"] != null && Request.QueryString["Source"].ToLower() == "online")
                        {
                            int scriptTypeId = callcenterDal.GetScriptType("OutboundOnlineProspect", 2)[0].ScriptTypeID;
                            outboundCallProspect = callcenterDal.GetScript(scriptTypeId.ToString(), 4);

                            string script = outboundCallProspect[0].ScriptText.Replace("<<prospect>>", Server.UrlDecode(Request.QueryString["Name"])).Replace("<<employee>>", HttpUtility.HtmlEncode(IoC.Resolve<ISessionContext>().UserSession.UserName));

                            customername.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(script, true);
                        }
                        else
                        {
                            int scriptTypeId = callcenterDal.GetScriptType("OutboundCallCenterProspect", 2)[0].ScriptTypeID;
                            outboundCallProspect = callcenterDal.GetScript(scriptTypeId.ToString(), 4);
                            string script = outboundCallProspect[0].ScriptText.Replace("<<prospect>>", Server.UrlDecode(Request.QueryString["Name"])).Replace("<<employee>>", HttpUtility.HtmlEncode(IoC.Resolve<ISessionContext>().UserSession.UserName));
                            customername.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(script, true);
                        }
                    }
                }
            }
        }

        protected void lnkCallType_Click(object sender, EventArgs e)
        {
            var lnkSender = (LinkButton)sender;
            var repository = new CallCenterCallRepository();

            switch (lnkSender.CommandName)
            {
                case "Issues":
                    repository.UpdateCallCenterCallStatus(CallType.Login_Issue.ToString().Replace("_", " "), ExistingCallId);
                    Response.RedirectUser("CallCenterRepLoginIssues.aspx?CustomerID=" + CustomerId + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                    break;

                case "RequestReport":
                    repository.UpdateCallCenterCallStatus(CallType.Request_Print_Version.ToString().Replace("_", " "), ExistingCallId);
                    Response.RedirectUser("RequestReport/SendReportStep2.aspx?guid=" + GuId);
                    break;

                case "ExistingCustomer":
                    repository.UpdateCallCenterCallStatus(CallType.Review_Customer.ToString().Replace("_", " "), ExistingCallId);
                    Session["ParameterString"] = null;
                    Response.RedirectUser("CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&guid=" + GuId);
                    break;

                case "RegisterCustomer":
                    repository.UpdateCallCenterCallStatus(CallType.Register_New_Customer.ToString().Replace("_", " "), ExistingCallId);

                    if (RegistrationFlow != null)
                    {
                        RegistrationFlow.SourceCodeId = 0;
                        RegistrationFlow.SourceCodeAmount = 0;
                        RegistrationFlow.SourceCode = string.Empty;
                        RegistrationFlow.TestIds = null;
                        RegistrationFlow.PackageId = 0;
                        RegistrationFlow.AppointmentSlotIds = null;
                        RegistrationFlow.ShippingDetailId = 0;
                    }

                    if (ProspectCustomerId > 0 && (RegistrationFlow == null || RegistrationFlow.CustomerId == 0))
                        BindCurrentCallToProspectCustomer();

                    Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerType=New&FirstName=" + FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&guid=" + GuId);

                    //Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=New&FirstName=" + FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip);
                    break;

                case "OtherIssues":
                    repository.UpdateCallCenterCallStatus(CallType.Other_Issues.ToString().Replace("_", " "), ExistingCallId);
                    Response.RedirectUser("AddNotes.aspx?guid=" + GuId);
                    break;

                case "ExistingCustomerRegister":
                    repository.UpdateCallCenterCallStatus(CallType.Existing_Customer.ToString().Replace("_", " "), ExistingCallId);
                    UpdateProspectCustomer();
                    BindCurrentCallToProspectCustomer();
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerType=Existing&CustomerID=" +
                       CustomerId + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));

                    //Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=Existing&CustomerID=" +
                    //    Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"]));
                    break;

                case "GiftCertificate":
                    repository.UpdateCallCenterCallStatus(CallType.Gift_Certificate.ToString().Replace("_", " "), ExistingCallId);

                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/GiftCertificate/Catalog.aspx?guid=" + GuId));
                    break;
                case "AddOnProduct":
                    Response.RedirectUser("RequestReport/AdditionalProductRequest.aspx?guid=" + GuId);
                    break;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "RegExistCustForSameEvent")
            {
                Response.RedirectUser("/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?Type=RegExistCustForSameEvent&guid=" + GuId);
            }
            else
            {
                if (RegistrationFlow != null)
                    RegistrationFlow.CustomerId = 0;
                Response.RedirectUser("/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?guid=" + GuId);
            }
        }

        private void BindCurrentCallToProspectCustomer()
        {
            if (ExistingCallId > 0 && ProspectCustomerId > 0)
            {
                var callWizardService = new CallCenterCallWizardService();
                callWizardService.BindCurrentCallToProspectCustomer(ExistingCallId, ProspectCustomerId, IoC.Resolve<ISessionContext>().UserSession.UserId);
            }
        }

        private void UpdateProspectCustomer()
        {
            var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
            var prospectCustomer = prospectCustomerRepository.GetProspectCustomerByCustomerId(CustomerId);
            if (prospectCustomer != null && RegistrationFlow != null)
            {
                RegistrationFlow.ProspectCustomerId = prospectCustomer.Id;
                return;
            }
            prospectCustomer = new ProspectCustomer();
            ICustomerRepository customerRepository = new CustomerRepository();
            var customer = customerRepository.GetCustomer(CustomerId);
            prospectCustomer.FirstName = customer.Name.FirstName;
            prospectCustomer.LastName = customer.Name.LastName;

            if (customer.HomePhoneNumber != null && !string.IsNullOrEmpty(customer.HomePhoneNumber.ToString()))
                prospectCustomer.CallBackPhoneNumber = customer.HomePhoneNumber;
            else if (customer.MobilePhoneNumber != null && !string.IsNullOrEmpty(customer.MobilePhoneNumber.ToString()))
                prospectCustomer.CallBackPhoneNumber = customer.MobilePhoneNumber;
            else if (customer.OfficePhoneNumber != null && !string.IsNullOrEmpty(customer.OfficePhoneNumber.ToString()))
                prospectCustomer.CallBackPhoneNumber = customer.OfficePhoneNumber;

            prospectCustomer.Address = new Address
            {
                City = customer.Address.City,
                Country = customer.Address.Country,
                State = customer.Address.State,
                StreetAddressLine1 = customer.Address.StreetAddressLine1,
                StreetAddressLine2 = customer.Address.StreetAddressLine2,
                ZipCode = new ZipCode { Zip = customer.Address.ZipCode.Zip }
            };
            if (customer.DateOfBirth.HasValue)
                prospectCustomer.BirthDate = customer.DateOfBirth.Value.Date;

            if (!string.IsNullOrEmpty(customer.Email.ToString()))
            {
                prospectCustomer.Email = customer.Email;
            }

            prospectCustomer.CustomerId = CustomerId;

            prospectCustomer.Source = ProspectCustomerSource.CallCenter;
            prospectCustomer.Tag = ProspectCustomerTag.CallCenterSignup;
            prospectCustomer.TagUpdateDate = DateTime.Now;

            var eventRepository = IoC.Resolve<IEventRepository>();
            prospectCustomer.IsConverted = eventRepository.CheckCustomerRegisteredForFutureEvent(CustomerId);

            if (!prospectCustomer.IsConverted.Value)
            {
                prospectCustomer.ConvertedOnDate = null;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                prospectCustomer.CreatedOn = DateTime.Now;
            }


            IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();

            prospectCustomer = uniqueItemRepository.Save(prospectCustomer);
            if (RegistrationFlow != null)
                RegistrationFlow.ProspectCustomerId = prospectCustomer.Id;

        }

    }
}