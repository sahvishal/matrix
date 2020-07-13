using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using Falcon.App.Infrastructure.CallQueues.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Lib;
using Falcon.App.UI.HtmlHelpers;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Application.Domain;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep
{
    public partial class AddNotes : Page
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

        private long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }

        }

        private Core.Users.Domain.Customer _customer;

        private Core.Users.Domain.Customer CurrentCustomer
        {
            get
            {
                if (_customer == null && CustomerId > 0)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId);
                }
                return _customer;
            }
            set { _customer = value; }
        }

        protected long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }

        protected long ExistingCallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
            set
            {
                RegistrationFlow.CallId = value;
            }
        }

        protected bool IsCallForProspectCustomerSignUpConversion
        {
            get
            {
                if (ViewState["CallForProspectCustomerSignUpConversion"] == null) ViewState["CallForProspectCustomerSignUpConversion"] = false;
                return Convert.ToBoolean(ViewState["CallForProspectCustomerSignUpConversion"]);
            }
            set { ViewState["CallForProspectCustomerSignUpConversion"] = value; }
        }

        protected bool IsProspectCustomerConverted
        {
            get
            {
                if (ViewState["IsProspectCustomerConverted"] == null) ViewState["IsProspectCustomerConverted"] = false;
                return Convert.ToBoolean(ViewState["IsProspectCustomerConverted"]);
            }
            set { ViewState["IsProspectCustomerConverted"] = value; }
        }

        protected Int64 ProspectCustomerIdforLeadConversion
        {
            get
            {
                if (ViewState["ProspectCustomerIdforLeadConversion"] == null) ViewState["ProspectCustomerIdforLeadConversion"] = 0;
                return Convert.ToInt64(ViewState["ProspectCustomerIdforLeadConversion"]);
            }
            set { ViewState["ProspectCustomerIdforLeadConversion"] = value; }
        }

        protected bool IsCallTypeOutbound
        {
            get
            {
                if (ViewState["CallType"] == null) ViewState["CallType"] = true;
                return Convert.ToBoolean(ViewState["CallType"]);
            }
            set { ViewState["CallType"] = value; }
        }

        protected bool IsHealthPlanCallQueue { get; set; }

        private long OrganizationRoleUserId
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            }
        }
        protected enum RequeueOption
        {
            Automatic = 1,
            Specific = 2
        }

        protected long CallQueueCustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallQueueCustomerId : 0;
            }
        }

        protected bool IsRescheduled
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["IsRescheduled"])) return false;
                return Convert.ToBoolean(Request.QueryString["IsRescheduled"]);
            }
        }

        protected bool IsInboundCall { get { return !IoC.Resolve<ICallCenterRepository>().IsCallTypeOutbound(ExistingCallId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            var callCenterMasterPage = (CallCenter_CallCenterMaster)Master;
            callCenterMasterPage.settitle(Page.Title);
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
            spSearchType.InnerText = Page.Title;
            IsHealthPlanCallQueue = (CallQueueCustomerId > 0) && CheckIsHealthPlanCallQueue();

            spnRestrictedNotes.Style.Add(HtmlTextWriterStyle.Display, "none");
            spnRestrictedNotes.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            CorporateAccount account = null;

            if (CustomerId > 0)
            {

                if (CurrentCustomer != null && !string.IsNullOrEmpty(CurrentCustomer.Tag))
                {
                    account = IoC.Resolve<ICorporateAccountRepository>().GetByTag(CurrentCustomer.Tag);
                    if (account != null && account.RestrictHealthPlanData)
                    {
                        spnRestrictedNotes.Style.Add(HtmlTextWriterStyle.Display, "block");
                        spnRestrictedNotes.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    }
                }
            }

            if (!IsPostBack)
            {
                if (CurrentCustomer != null)
                {
                    BindConsentDropDownControls();
                    BindCustomerDataForConsent(CurrentCustomer);
                }

                var isWarmTransfer = false;
                if (IsInboundCall && CurrentCustomer != null && account != null && account.WarmTransfer)
                {
                    var customerWarmTransfer = IoC.Resolve<ICustomerWarmTransferRepository>().GetByCustomerIdAndYear(CurrentCustomer.CustomerId, DateTime.Today.Year);
                    isWarmTransfer = customerWarmTransfer != null && customerWarmTransfer.IsWarmTransfer.HasValue && customerWarmTransfer.IsWarmTransfer.Value;
                }

                BindCallStatusOptions(isWarmTransfer);

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    spContinueCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    spContinueCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    CallStatusRadioList.Visible = false;
                    if (Request.QueryString["EventRegistered"] != null && Request.QueryString["EventRegistered"] == "Yes")
                    {
                        GetScript();
                    }
                }
                else
                {
                    var repository = new CallCenterCallRepository();
                    ECall objCall = repository.GetCallCenterEntity(ExistingCallId);

                    if (objCall != null)
                        SetupCallStatusFlow();

                    if (objCall != null)
                    {
                        if (objCall.CallNotes != null && objCall.CallNotes.Count > 0 && objCall.CallNotes[0] != null)
                        {
                            txtNotes.Text = objCall.CallNotes[0].Notes;
                        }
                        if ((objCall.CallStatus == CallType.Existing_Customer.ToString().Replace("_", " ")) ||
                            ((objCall.CallStatus == CallType.Register_New_Customer.ToString().Replace("_", " "))))
                        {
                            // Fill the Registration information
                            GetScript();
                        }
                    }

                    if (Request.QueryString["LbuttonVisible"] != null && Request.QueryString["LbuttonVisible"].ToLower().Trim() == "yes")
                    {
                        pNewCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                        pNewCust.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    }
                    else
                    {
                        if (objCall != null && objCall.OutBound)
                        {
                            spContinueCall.Style.Add(HtmlTextWriterStyle.Display, "block");
                        }
                        pNewCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }
            }
        }

        private void BindConsentDropDownControls()
        {
            ddlPatientConsentPrimary.Items.Clear();
            var consentDropDown = DropDownHelper.GetPatientPhoneConsent();
            ddlPatientConsentPrimary.DataSource = consentDropDown;
            ddlPatientConsentPrimary.DataTextField = "Text";
            ddlPatientConsentPrimary.DataValueField = "Value";
            ddlPatientConsentPrimary.DataBind();

            ddlPatientConsentOffice.Items.Clear();
            ddlPatientConsentOffice.DataSource = consentDropDown;
            ddlPatientConsentOffice.DataTextField = "Text";
            ddlPatientConsentOffice.DataValueField = "Value";
            ddlPatientConsentOffice.DataBind();

            ddlPatientConsentCell.Items.Clear();
            ddlPatientConsentCell.DataSource = consentDropDown;
            ddlPatientConsentCell.DataTextField = "Text";
            ddlPatientConsentCell.DataValueField = "Value";
            ddlPatientConsentCell.DataBind();
        }

        private void BindCustomerDataForConsent(Falcon.App.Core.Users.Domain.Customer customer)          //Also Sets visibility of Consent DIV
        {
            txtphonehome.Text = customer.HomePhoneNumber.ToString();
            txtphoneoffice.Text = customer.OfficePhoneNumber.ToString();
            PhoneOfficeExtension.Text = customer.PhoneOfficeExtension;
            txtphonecell.Text = customer.MobilePhoneNumber.ToString();
            if (customer.PhoneHomeConsentId > 0)
            {
                ddlPatientConsentPrimary.SelectedValue = customer.PhoneHomeConsentId.ToString();
            }
            if (customer.PhoneCellConsentId > 0)
            {
                ddlPatientConsentCell.SelectedValue = customer.PhoneCellConsentId.ToString();
            }
            if (customer.PhoneOfficeConsentId > 0)
            {
                ddlPatientConsentOffice.SelectedValue = customer.PhoneOfficeConsentId.ToString();
            }

            if (CustomerId > 0 && RegistrationFlow.CanSaveConsentInfo)
            {
                PhoneConsent.Style.Add(HtmlTextWriterStyle.Display, "block");
                PhoneConsent.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            }
            else
            {
                PhoneConsent.Style.Add(HtmlTextWriterStyle.Display, "none");
                PhoneConsent.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
        }

        private void BindCallStatusOptions(bool isWarmTransfer)
        {
            CallStatusRadioList.Items.Clear();
            CallStatusRadioList.Items.Add(new ListItem("No Answer", Convert.ToString((long)CallStatus.NoAnswer)));
            CallStatusRadioList.Items.Add(new ListItem("Left Voice Message", Convert.ToString((long)CallStatus.VoiceMessage)));
            CallStatusRadioList.Items.Add(new ListItem("Talked To Patient", Convert.ToString((long)CallStatus.Attended)));

            CallStatusRadioList.Items.FindByValue(Convert.ToString((long)CallStatus.Attended)).Selected = true;

            CallBackOptionsRadioList.Items.Clear();

            CallBackOptionsRadioList.Items.Add(new ListItem(RequeueOption.Automatic.ToString(), Convert.ToString((long)RequeueOption.Automatic)));
            CallBackOptionsRadioList.Items.Add(new ListItem(RequeueOption.Specific.ToString(), Convert.ToString((long)RequeueOption.Specific)));


            if (!IsHealthPlanCallQueue)
            {
                CallBackOptionsRadioList.Items.FindByValue(Convert.ToString((long)RequeueOption.Automatic)).Selected = true;
                requeueLabel.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                if (!IsProspectCustomerConverted)
                {
                    CallStatusRadioList.Items.Add(new ListItem("Left Message With Other", Convert.ToString((long)CallStatus.LeftMessageWithOther)));
                    CallStatusRadioList.Items.Add(new ListItem("Talked to Other Person", Convert.ToString((long)CallStatus.TalkedtoOtherPerson)));
                    CallStatusRadioList.Items.Add(new ListItem("No Events In Area", Convert.ToString((long)CallStatus.NoEventsInArea)));
                }
                CallBackOptionsRadioList.Items.FindByValue(Convert.ToString((long)RequeueOption.Specific)).Selected = true;
                requeueLabel.Style.Add(HtmlTextWriterStyle.Display, "none");
                CallBackOptionsRadioList.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            var tagRepository = IoC.Resolve<ITagRepository>();
            var tags = tagRepository.GetTags(ProspectCustomerSource.CallCenter, IsHealthPlanCallQueue, isWarmTransfer).OrderBy(x => x.Name).ToArray();

            if (tags != null && tags.Any())
            {
                var isMammoPatient = IoC.Resolve<IPreApprovedTestRepository>().CheckPreApprovedTestForCustomer(CustomerId, new long[] { (long)TestType.Mammogram });

                if (!isMammoPatient)
                {
                    string[] removeMammoDispositions = {ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString(), 
                        ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString(),
                        ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString()};

                    tags = tags.Where(x => !removeMammoDispositions.Contains(x.Alias)).ToArray();
                }

                if (isWarmTransfer)
                {
                    CallDispositionDropdown.DataSource = tags.Where(x => x.CallStatus != (long)CallStatus.LeftMessageWithOther && x.CallStatus != (long)CallStatus.TalkedtoOtherPerson && x.CallStatus != (long)CallStatus.NoEventsInArea
                                               && (!x.ForAppointmentConfirmation || x.Alias == ProspectCustomerTag.CallBackLater.ToString()));
                }
                else
                {
                    CallDispositionDropdown.DataSource = tags.Where(x => x.CallStatus != (long)CallStatus.LeftMessageWithOther && x.CallStatus != (long)CallStatus.TalkedtoOtherPerson && x.CallStatus != (long)CallStatus.NoEventsInArea
                                               && (!x.ForAppointmentConfirmation || x.Alias == ProspectCustomerTag.CallBackLater.ToString()) && !x.ForWarmTransfer);
                }

                CallDispositionDropdown.DataTextField = "Name";
                CallDispositionDropdown.DataValueField = "Alias";
                CallDispositionDropdown.DataBind();

                CallDispositionDropdown.Items.Insert(0, new ListItem("--Select--", "-1"));
            }

            var reasonPair = (NotInterestedReason.CustomerRefused).GetNameValuePairs();

            NotIntrestedDropDownList.DataSource = reasonPair;
            NotIntrestedDropDownList.DataTextField = "SecondValue";
            NotIntrestedDropDownList.DataValueField = "FirstValue";
            NotIntrestedDropDownList.DataBind();
            NotIntrestedDropDownList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        private void SetupCallStatusFlow()
        {
            ICallCenterRepository callCenterRepository = new CallCenterRepository();
            IsCallTypeOutbound = callCenterRepository.IsCallTypeOutbound(ExistingCallId);

            ProspectCustomerIdforLeadConversion = callCenterRepository.GetProspectCustomerIdifCallforLeadConversion(ExistingCallId);

            if (ProspectCustomerIdforLeadConversion > 0)
            {
                IsCallForProspectCustomerSignUpConversion = true;
                IProspectCustomerRepository prospectCustomerRepository = new ProspectCustomerRepository();
                IsProspectCustomerConverted = prospectCustomerRepository.IsConvertedandRegistered(ProspectCustomerIdforLeadConversion, EventId);
            }
            if (CustomerId > 0 && EventId > 0)
            {
                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var eventCustomer = eventCustomerRepository.Get(EventId, CustomerId);
                if (eventCustomer != null)
                {
                    if (eventCustomer.AppointmentId.HasValue && eventCustomer.AppointmentId > 0)
                    {
                        CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                    else
                    {
                        CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }

                }
                else
                {
                    CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                }


            }
            else
            {
                CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            //if (IsCallForProspectCustomerSignUpConversion && IsProspectCustomerConverted == false)
            //{
            //    CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            //}
            //else
            //    CallDispositionDiv.Style.Add(HtmlTextWriterStyle.Display, "none");

            if (!IsCallTypeOutbound || (IsCallForProspectCustomerSignUpConversion && IsProspectCustomerConverted) || IsHealthPlanCallQueue)
            {
                var listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.NoAnswer));
                if (listItem != null)
                    listItem.Enabled = false;

                listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.VoiceMessage));
                if (listItem != null)
                    listItem.Enabled = false;

                listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.TalkedtoOtherPerson));
                if (listItem != null)
                    listItem.Enabled = false;

                listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.LeftMessageWithOther));
                if (listItem != null)
                    listItem.Enabled = false;

                //listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.IncorrectPhoneNumber));
                //if (listItem != null)
                //    listItem.Enabled = false;

                //listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.LeftMessageWithOther));
                //if (listItem != null)
                //    listItem.Enabled = false;

                listItem = CallStatusRadioList.Items.FindByValue(Convert.ToString((short)CallStatus.NoEventsInArea));
                if (listItem != null)
                    listItem.Enabled = false;
            }

            if (CallQueueCustomerId > 0 && !IsHealthPlanCallQueue && (!IsCallForProspectCustomerSignUpConversion || (IsCallForProspectCustomerSignUpConversion && IsProspectCustomerConverted == false)))
            {
                CallBackOptionsContainerDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                RemoveFromQueueDiv.Style.Add(HtmlTextWriterStyle.Display, "inline-block");

                var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId);
                var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
                var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);

                AllAttemptsExhaustedDiv.Style.Add(HtmlTextWriterStyle.Display, (callQueueCustomer.Attempts + 1 >= callQueue.Attempts) ? "block" : "none");
            }
            else
            {
                CallBackOptionsContainerDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                RemoveFromQueueDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

        }

        private void UnlockCallQuequeCustomer()
        {
            var customerLock = IoC.Resolve<ICallQueueCustomerLockRepository>();
            customerLock.RelaseCallQueueCustomerLock(CallQueueCustomerId);
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
        private bool CheckIsHealthPlanCallQueue()
        {
            if (CallQueueCustomerId <= 0) return false;
            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
            var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId);

            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);

            return (callQueue != null && !callQueue.IsManual && callQueue.IsHealthPlan);
        }

        protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ExistingCallId > 0)
                {
                    SaveNotes();
                    EndCall();
                }
                else
                {
                    SaveRegistrationNotes();
                }
                var url = "/CallCenter/CallCenterRepDashboard/Index";

                var currentUser = IoC.Resolve<ISessionContext>().UserSession;
                if (currentUser.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterManager))
                {
                    url = "/App/CallCenter/CallCenterManagerDashBoard.aspx";
                }
                //if (IsSystemGeneratedCallQueue())
                //{
                //    UnlockCallQuequeCustomer();
                //    var setting = IoC.Resolve<ISettings>();
                //    url = setting.AppUrl + "/CallCenter/CallQueue/Call#/callqueuecustomers";
                //}
                //else 

                var assignmentChanged = false;
                if (IsHealthPlanCallQueue)
                {
                    if (RegistrationFlow.IsGmsCall || RegistrationFlow.IsViciCall)
                    {
                        url = "/CallCenter/CallCenterRepDashboard/Index";
                        Response.RedirectUser(url);
                        return;
                    }

                    var filter = new Core.CallQueues.ViewModels.OutboundCallQueueFilter();
                    filter.PageNumber = 1;
                    filter.UseCustomTagExclusively = false;
                    filter.HealthPlanId = hfHpHealthPlanId.Value != "" ? Convert.ToInt64(hfHpHealthPlanId.Value) : 0;
                    filter.CallQueueId = hfHpCallQueueId.Value != "" ? Convert.ToInt64(hfHpCallQueueId.Value) : 0;
                    filter.EventId = hfEventId.Value != "" ? Convert.ToInt64(hfEventId.Value) : 0;
                    filter.CriteriaId = hfHpCriteriaId.Value != "" ? Convert.ToInt64(hfHpCriteriaId.Value) : 0;
                    filter.CampaignId = hfHpCampaignId.Value != "" ? Convert.ToInt64(hfHpCampaignId.Value) : 0;
                    filter.ZipCode = hfHpFillEventZipCode.Value;
                    filter.Radius = hfHpRadius.Value != "" ? Convert.ToInt32(hfHpRadius.Value) : 0;

                    var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                    logger.Info(string.Format("HealthPlanId : {0}, CallQueueId : {1}, filter.EventId : {2}, CriteriaId : {3}, CampaignId : {4}, ZipCode : {5}, Radius : {6}", filter.HealthPlanId, filter.CallQueueId, filter.EventId, filter.CriteriaId,
                        filter.CampaignId, filter.ZipCode, filter.Radius));

                    var agentOrgRoleUserId = currentUser.CurrentOrganizationRole.OrganizationRoleUserId;
                    var agentOrganizationId = currentUser.CurrentOrganizationRole.OrganizationId;

                    filter.AgentOrganizationRoleUserId = agentOrgRoleUserId;
                    filter.AgentOrganizationId = agentOrganizationId;

                    var startOutboundCall = IoC.Resolve<ICallQueueCustomerDetailService>().GetCustomerContactViewModel(filter);

                    UnlockCallQuequeCustomer();
                    var setting = IoC.Resolve<ISettings>();
                    //url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + RegistrationFlow.CallQueueCustomerId + "/" + RegistrationFlow.AttempId;

                    if (startOutboundCall.AssignmentChanged)
                    {
                        assignmentChanged = true;
                        ClientScript.RegisterStartupScript(typeof(string), "js_setAssignmentChangedStatus", "setAssignmentChangedStatus();", true);
                        //url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard/Index#/dashboard";
                    }
                    else
                        url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + startOutboundCall.CallQueueCustomerId + "/" + startOutboundCall.AttemptId;
                }
                else
                {
                    var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                    if (RegistrationFlow != null && CallQueueCustomerId > 0)
                    {
                        var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId);
                        url = url + "?cq=" + callQueueCustomer.CallQueueId;
                    }
                }

                RegistrationFlow = null;
                if (!assignmentChanged)
                    Response.RedirectUser(url);
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("Some exception has occur.  Message " + ex.Message + "  Stack Trace: " + ex.StackTrace);
            }
        }

        private void GetScript()
        {
            if (EventId > 0 && CustomerId > 0)
            {
                try
                {
                    var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                    eventCustomerRepository.GetRegisteredEventForUser(CustomerId, EventId);

                    var customerRepository = IoC.Resolve<ICustomerRepository>();
                    var customer = customerRepository.GetCustomer(CustomerId);

                    if (customer != null)
                    {
                        string strCustomerName = customer.NameAsString;

                        var callCenterDAL = new CallCenterDAL();
                        int scriptTypeId = callCenterDAL.GetScriptType("Final Thank you", 2)[0].ScriptTypeID;

                        List<EScript> scripts = callCenterDAL.GetScript(scriptTypeId.ToString(), 4);
                        scripts[0].ScriptText = scripts[0].ScriptText.Replace("<<Your Name>>", HttpUtility.HtmlEncode(strCustomerName));
                        scripts[0].ScriptText = scripts[0].ScriptText.Replace("<<CallCenterTollFreeNumber>>", HttpUtility.HtmlEncode(IoC.Resolve<ISettings>().PhoneTollFree));
                        hfThankYou.Value = scripts[0].ScriptText;

                        scriptTypeId = callCenterDAL.GetScriptType("Conclusion Script", 2)[0].ScriptTypeID;
                        scripts = callCenterDAL.GetScript(scriptTypeId.ToString(), 4);
                        scripts[0].ScriptText = scripts[0].ScriptText.Replace("<<Your Name>>", HttpUtility.HtmlEncode(strCustomerName));
                        hfConclusion.Value = scripts[0].ScriptText;

                        // Fill the payment Summry
                        dvEventsummary.Style.Add(HtmlTextWriterStyle.Display, "block");
                        dvEventsummary.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                        /////
                    }
                }
                catch (ObjectNotFoundInPersistenceException<EventCustomer>)
                {
                    dvEventsummary.Style.Add(HtmlTextWriterStyle.Display, "none");
                    dvEventsummary.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
            }
        }

        private void StartCall(string status)
        {
            // we are not setting time here as this is a new call only for system
            hfCallStartTime.Value = DateTime.Now.ToString();

            var callCenterRepCall = new ECall();

            if (ExistingCallId > 0)
            {
                var repository = new CallCenterCallRepository();
                var call = repository.GetCallCenterEntity(ExistingCallId);

                callCenterRepCall.IncomingPhoneLine = call.IncomingPhoneLine;
                callCenterRepCall.CallersPhoneNumber = call.CallersPhoneNumber;
                callCenterRepCall.CallBackNumber = call.CallBackNumber;
            }

            if (!string.IsNullOrEmpty(status)) callCenterRepCall.CallStatus = status;

            callCenterRepCall.CallCenterCallCenterUserID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            callCenterRepCall.TimeCreated = hfCallStartTime.Value;

            callCenterRepCall.CallNotes = new List<ECallCenterNotes>();
            var callcenterDal = new CallCenterDAL();
            long returnresult = callcenterDal.UpdateCall(callCenterRepCall);

            ExistingCallId = returnresult;
        }

        private void EndCall()
        {
            var callQueueEditModel = new CallQueueCustomerCallDetailsEditModel
            {
                ModifiedByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
            };

            var repository = new CallCenterCallRepository();
            var objCall = repository.GetById(ExistingCallId);

            objCall.EndTime = DateTime.Now;

            if (CallStatusRadioList.SelectedItem.Value == Convert.ToString((short)CallStatus.NoAnswer))
                objCall.Status = (long)CallStatus.NoAnswer;
            else if (CallStatusRadioList.SelectedItem.Value == Convert.ToString((short)CallStatus.VoiceMessage))
            {
                objCall.Status = (long)CallStatus.VoiceMessage;
                if (objCall.CallQueueId.HasValue)
                    objCall.IsContacted = true;
            }
            else if (CallStatusRadioList.SelectedItem.Value == Convert.ToString((short)CallStatus.Attended))
            {
                var customerService = IoC.Resolve<ICustomerService>();

                if (objCall.CallQueueId.HasValue)
                {
                    objCall.IsContacted = true;
                    if (CurrentCustomer != null && CurrentCustomer.IsIncorrectPhoneNumber)
                    {
                        objCall.InvalidNumberCount = 0;
                        customerService.UpdateIsIncorrectPhoneNumber(CurrentCustomer, false);
                    }
                }
                if (CurrentCustomer != null)
                {
                    if (CallDispositionDropdown.SelectedValue == ProspectCustomerTag.DeclinedMobileAndTransferredToHome.ToString())
                    {
                        CurrentCustomer.ActivityId = null;
                    }

                    if (CallDispositionDropdown.SelectedValue == ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString())
                    {
                        CurrentCustomer = customerService.UpdateDoNotCallStatuswithReason(CurrentCustomer, false, ProspectCustomerTag.MemberStatesIneligibleMastectomy);
                        var noteId = SaveDNCNotes(ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription(), callQueueEditModel.ModifiedByOrgRoleUserId);
                        CurrentCustomer.DoNotContactReasonNotesId = noteId;
                    }

                    customerService.SaveCustomerOnly(CurrentCustomer, callQueueEditModel.ModifiedByOrgRoleUserId);
                }

                objCall.Status = (long)CallStatus.Attended;
            }
            else if (CallStatusRadioList.SelectedItem.Value == Convert.ToString((short)CallStatus.LeftMessageWithOther))
            {
                objCall.Status = (long)CallStatus.LeftMessageWithOther;
                if (objCall.CallQueueId.HasValue)
                    objCall.IsContacted = true;
            }
            else if (CallStatusRadioList.SelectedItem.Value == Convert.ToString((short)CallStatus.TalkedtoOtherPerson))
                objCall.Status = (long)CallStatus.TalkedtoOtherPerson;

            ProspectCustomerTag pct;
            if (Enum.TryParse(objCall.Disposition, out pct))
            {
                if (Enum.IsDefined(typeof(ProspectCustomerTag), pct))
                {
                    objCall.Disposition = pct.ToString();
                }
            }

            if (IsCallForProspectCustomerSignUpConversion && objCall.Status == (long)CallStatus.Attended && CallDispositionDropdown.SelectedItem != null)
            {
                if (!IsProspectCustomerConverted)
                {
                    objCall.Disposition = Enum.Parse(typeof(ProspectCustomerTag), CallDispositionDropdown.SelectedItem.Value).ToString();
                    callQueueEditModel.Disposition = objCall.Disposition;
                }
                else if (IsProspectCustomerConverted)
                {
                    objCall.Disposition = IsRescheduled ? ProspectCustomerTag.RescheduleAppointment.ToString() : ProspectCustomerTag.BookedAppointment.ToString();
                    callQueueEditModel.Disposition = objCall.Disposition;
                }
            }

            //repository.Save(objCall);

            var callQueueStatus = CallQueueStatus.Initial;
            if (RemoveFromQueueChkBx.Checked)
                callQueueStatus = CallQueueStatus.Removed;

            var tag = ProspectCustomerTag.Unspecified;

            if (CallDispositionDropdown.SelectedItem != null && CallDispositionDropdown.SelectedItem.Value != "-1")
            {
                ProspectCustomerTag ptag;

                objCall.Disposition = CallDispositionDropdown.SelectedValue.ToString();

                tag = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), CallDispositionDropdown.SelectedItem.Value);
                Enum.TryParse(CallDispositionDropdown.SelectedItem.Value, true, out ptag);
                if (Enum.IsDefined(typeof(ProspectCustomerTag), ptag))
                {
                    if (tag == ProspectCustomerTag.BookedAppointment || tag == ProspectCustomerTag.HomeVisitRequested || tag == ProspectCustomerTag.MobilityIssue
                    || tag == ProspectCustomerTag.TransportationIssue || tag == ProspectCustomerTag.DoNotCall || tag == ProspectCustomerTag.Deceased
                    || tag == ProspectCustomerTag.NoLongeronInsurancePlan || tag == ProspectCustomerTag.IncorrectPhoneNumber || tag == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther ||

                    tag == ProspectCustomerTag.DebilitatingDisease)
                    {
                        callQueueStatus = CallQueueStatus.Removed;

                    }

                    callQueueEditModel.Disposition = ptag != ProspectCustomerTag.Unspecified ? ptag.ToString() : callQueueEditModel.Disposition;

                    if (tag == ProspectCustomerTag.DoNotCall)
                    {
                        UpdateDoNotCallStatus(true);
                    }

                    if (tag == ProspectCustomerTag.LanguageBarrier)
                    {
                        MarkCustomerAsLanguageBarrier();
                    }
                }

            }
            else if (objCall.Status == (long)CallStatus.TalkedtoOtherPerson && !string.IsNullOrEmpty(ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers.ToString()))
            {
                callQueueStatus = CallQueueStatus.Removed;
                callQueueEditModel.Disposition = ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers.ToString();
            }

            objCall.NotInterestedReasonId = null;

            if (objCall.Status == (long)CallStatus.Attended && tag == ProspectCustomerTag.NotInterested && NotIntrestedDropDownList.SelectedItem != null)
            {
                NotInterestedReason reason;
                Enum.TryParse(NotIntrestedDropDownList.SelectedItem.Value, out reason);

                if (Enum.IsDefined(typeof(NotInterestedReason), reason))
                {
                    objCall.NotInterestedReasonId = (long?)reason;
                }
            }

            repository.Save(objCall);

            var increaseCallCount = objCall.IsContacted.HasValue && objCall.IsContacted.Value;

            if (IsCallForProspectCustomerSignUpConversion)
            {
                var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                if (objCall.Status == (long)CallStatus.Attended && IsProspectCustomerConverted == false)
                {
                    var prospectCustomer = prospectCustomerRepository.GetById(ProspectCustomerIdforLeadConversion);
                    prospectCustomer.IsConverted = false;
                    prospectCustomer.Tag = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), CallDispositionDropdown.SelectedItem.Value);
                    prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                    prospectCustomer.TagUpdateDate = DateTime.Now;
                    prospectCustomerRepository.Save(prospectCustomer);
                    callQueueEditModel.Disposition = prospectCustomer.Tag.ToString();
                    callQueueEditModel.CallStatusId = (long)CallStatus.Attended;

                    UpdateOutboundCallStatus(callQueueStatus, increaseCallCount, false, callQueueEditModel);
                }
                else if (objCall.Status == (long)CallStatus.Attended && IsProspectCustomerConverted)
                {
                    var prospectCustomer = prospectCustomerRepository.GetById(ProspectCustomerIdforLeadConversion);
                    prospectCustomer.IsConverted = true;
                    prospectCustomer.ConvertedOnDate = DateTime.Now;
                    prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                    prospectCustomer.Tag = ProspectCustomerTag.BookedAppointment;
                    callQueueEditModel.Disposition = IsRescheduled ? ProspectCustomerTag.RescheduleAppointment.ToString() : ProspectCustomerTag.BookedAppointment.ToString();
                    callQueueEditModel.CallStatusId = (long)CallStatus.Attended;
                    prospectCustomer.TagUpdateDate = DateTime.Now;

                    prospectCustomerRepository.Save(prospectCustomer);

                    UpdateOutboundCallStatus(CallQueueStatus.Completed, increaseCallCount, true, callQueueEditModel);
                }
                else
                {
                    UpdateOutboundCallStatus(callQueueStatus, increaseCallCount, false, callQueueEditModel);
                }
            }
            else
            {
                UpdateOutboundCallStatus(callQueueStatus, increaseCallCount, false, callQueueEditModel);
            }
            if (DoNotCallChkBx.Checked)
            {

                UpdateDoNotCallStatus(true);
            }

            if (CustomerId > 0 && (objCall.Status == (long)CallStatus.TalkedtoOtherPerson && tag == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers))
            {
                var customerService = IoC.Resolve<ICustomerService>();
                customerService.UpdateIsIncorrectPhoneNumber(CustomerId, true, OrganizationRoleUserId);
            }

            if (objCall.CallQueueId > 0)
            {
                callQueueEditModel.CallStatusId = objCall.Status;
                callQueueEditModel.Disposition = objCall.Disposition;
            }

            UpdateCallQueueCustomer(callQueueEditModel, CustomerId);
        }

        private void MarkCustomerAsLanguageBarrier()
        {
            if (CustomerId > 0)
            {
                var customerService = IoC.Resolve<ICustomerService>();

                customerService.UpdateIsLanguageBarrier(CustomerId, true, OrganizationRoleUserId);
            }
        }

        private void UpdateDoNotCallStatus(bool markDoNotCall)
        {
            if (ProspectCustomerIdforLeadConversion > 0)
            {
                var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                ((IProspectCustomerRepository)prospectCustomerRepository).UpdateDoNotCallStatus(ProspectCustomerIdforLeadConversion, ProspectCustomerConversionStatus.Declined);
            }
            if (CustomerId > 0)
            {
                var customerService = IoC.Resolve<ICustomerService>();
                customerService.UpdateDoNotCallStatus(CustomerId, !markDoNotCall, OrganizationRoleUserId, (long)DoNotContactSource.Manual);
            }
        }
        private void SaveNotes()
        {
            var notes = txtNotes.Text;
            if (CallDispositionDropdown.SelectedValue == ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString())
            {
                notes = notes.Replace(ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription() + " : ", "");
                notes = !string.IsNullOrWhiteSpace(notes) ? ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription() + " : " + notes : ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription();
            }

            if (string.IsNullOrWhiteSpace(notes)) return;

            var callCenterRepository = IoC.Resolve<ICallCenterNotesRepository>();

            var callCenterNotes = new CallCenterNotes
            {
                CallId = ExistingCallId,
                Notes = notes,
                IsActive = true,
                NotesSequence = 1
            };

            callCenterRepository.Save(callCenterNotes);

            SaveRegistrationNotes();
        }

        private void SaveRegistrationNotes()
        {
            if (CustomerId > 0)
            {
                var notes = txtNotes.Text;
                if (CallDispositionDropdown.SelectedValue == ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString())
                {
                    notes = notes.Replace(ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription() + " : ", "");
                    notes = !string.IsNullOrWhiteSpace(notes) ? ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription() + " : " + notes : ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription();
                }

                var currentUser = IoC.Resolve<ISessionContext>().UserSession;
                var customerRegistrationNotes = new CustomerCallNotes
                                                    {
                                                        CustomerId = CustomerId,
                                                        EventId =
                                                            EventId > 0 ? (long?)EventId : null,
                                                        Notes = notes,
                                                        NotesType = CustomerRegistrationNotesType.AppointmentNote,
                                                        DataRecorderMetaData = new DataRecorderMetaData
                                                                                   {
                                                                                       DateCreated = DateTime.Now,
                                                                                       DataRecorderCreator = new OrganizationRoleUser(currentUser.CurrentOrganizationRole.OrganizationRoleUserId)
                                                                                   }
                                                    };

                var customerRegistrationNotesRepository = IoC.Resolve<IUniqueItemRepository<CustomerCallNotes>>();
                customerRegistrationNotesRepository.Save(customerRegistrationNotes);
            }
        }

        protected void lnkRegNewCust_Click(object sender, EventArgs e)
        {
            ContinueCallbycreatinganewInstance(CallType.Register_New_Customer.ToString().Replace("_", " "));

            if (RegistrationFlow != null)
            {
                RegistrationFlow.TestIds = null;
                RegistrationFlow.PackageId = 0;
                RegistrationFlow.AppointmentSlotIds = null;
                RegistrationFlow.ShippingDetailId = 0;
                RegistrationFlow.ShippingAddressId = 0;
                RegistrationFlow.CallQueueCustomerId = 0;
                RegistrationFlow.PreQualificationResultId = 0;
                RegistrationFlow.AwvVisitId = null;
            }
            if (IsSystemGeneratedCallQueue())
            {
                UnlockCallQuequeCustomer();
            }
            Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=New&Action=RegNewCustForSameEvent" + "&guid=" + GuId);
        }

        protected void lnkRegExistCust_Click(object sender, EventArgs e)
        {
            ContinueCallbycreatinganewInstance(CallType.Existing_Customer.ToString().Replace("_", " "));

            if (RegistrationFlow != null)
            {
                RegistrationFlow.CustomerId = 0;
                RegistrationFlow.EventId = 0;
                RegistrationFlow.PreQualificationResultId = 0;
                RegistrationFlow.CallQueueCustomerId = 0;
                RegistrationFlow.CampaignId = 0;
                RegistrationFlow.AwvVisitId = null;
            }
            if (IsSystemGeneratedCallQueue())
            {
                UnlockCallQuequeCustomer();
            }
            Response.RedirectUser("BasicCallInfo.aspx?guid=" + GuId);
        }

        protected void imgContinueCall_Click(object sender, ImageClickEventArgs e)
        {
            if (IsSystemGeneratedCallQueue())
            {
                UnlockCallQuequeCustomer();
            }

            if (RegistrationFlow != null)
            {
                RegistrationFlow.ProspectCustomerId = 0;
                RegistrationFlow.PreQualificationResultId = 0;
                RegistrationFlow.AwvVisitId = null;
            }
            ContinueCallbycreatinganewInstance(string.Empty);
            if (Request.QueryString["CustomerID"] != null)
            {
                if (RegistrationFlow != null)
                    RegistrationFlow.CallQueueCustomerId = 0;
                Response.RedirectUser("CustomerOptions.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
            }
            else
            {
                if (RegistrationFlow != null)
                {
                    RegistrationFlow.CustomerId = 0;
                    RegistrationFlow.EventId = 0;
                    RegistrationFlow.ProspectCustomerId = 0;
                    RegistrationFlow.CallQueueCustomerId = 0;
                    RegistrationFlow.CampaignId = 0;
                }
                Response.RedirectUser("BasicCallInfo.aspx?guid=" + GuId);
            }
        }

        protected void imgSaveConsent_Click(object sender, ImageClickEventArgs e)
        {
            if (CustomerId > 0)
            {
                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var customerService = IoC.Resolve<ICustomerService>();

                var customer = customerRepository.GetCustomer(CustomerId);

                customer.PhoneHomeConsentId = long.Parse(ddlPatientConsentPrimary.SelectedValue);
                customer.PhoneCellConsentId = long.Parse(ddlPatientConsentCell.SelectedValue);
                customer.PhoneOfficeConsentId = long.Parse(ddlPatientConsentOffice.SelectedValue);

                var commonCode = new CommonCode();
                customer.HomePhoneNumber = new PhoneNumber
                {
                    PhoneNumberType = PhoneNumberType.Home,
                    Number = commonCode.FormatPhoneNumber(txtphonehome.Text)
                };

                customer.OfficePhoneNumber = new PhoneNumber
                {
                    PhoneNumberType = PhoneNumberType.Office,
                    Number = commonCode.FormatPhoneNumber(txtphoneoffice.Text)
                };
                customer.PhoneOfficeExtension = PhoneOfficeExtension.Text;
                customer.MobilePhoneNumber = new PhoneNumber
                {
                    PhoneNumberType = PhoneNumberType.Mobile,
                    Number = commonCode.FormatPhoneNumber(txtphonecell.Text)
                };

                var isSaveSuccess = customerService.SaveCustomer(customer, OrganizationRoleUserId);
                if (isSaveSuccess)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "js_showConsentSaveSuccessAlert", "ShowConsentSaveSuccessAlert();", true);
                }
            }
        }

        private void ContinueCallbycreatinganewInstance(string status)
        {
            if (ExistingCallId > 0)
            {
                SaveNotes();
                EndCall();
            }
            StartCall(status);
        }

        private void UpdateOutboundCallStatus(CallQueueStatus status, bool increaseAttemptCount, bool isCustomerConverted, CallQueueCustomerCallDetailsEditModel editModel)
        {
            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
            var orgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            if (CallQueueCustomerId > 0)
            {
                var callQueueCustomer = callQueueCustomerRepository.GetById(CallQueueCustomerId);

                editModel.CallQueueCustomerId = CallQueueCustomerId;

                var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
                var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);

                //if (!(callQueue.Category == CallQueueCategory.Upsell && callQueueCustomer.Status == CallQueueStatus.Completed))
                //{
                //    callQueueCustomer.Status = status;
                //}
                editModel.CallQueueStatus = (long)status;

                //callQueueCustomer.DateModified = DateTime.Now;
                //callQueueCustomer.ModifiedByOrgRoleUserId = orgRoleUserId;

                DateTime callDate;
                int attemptCount;

                if (CallBackOptionsRadioList.SelectedItem.Value == Convert.ToString((long)RequeueOption.Automatic))
                {
                    //callDate = DateTime.Now.AddDays(30);
                    //attemptCount = callQueueCustomer.Attempts + 1;
                    editModel.CallDate = DateTime.Now.AddDays(30);
                    editModel.Attempt = increaseAttemptCount ? callQueueCustomer.Attempts + 1 : 0;
                }
                else
                {
                    if ((ScheduledDateText.Text + " " + ScheduledTimeText.Text).Trim() == "")
                    {
                        // callDate = DateTime.Now.AddDays(30);
                        // attemptCount = callQueueCustomer.Attempts + 1;
                        editModel.CallDate = DateTime.Now.AddDays(30);
                        editModel.Attempt = increaseAttemptCount ? callQueueCustomer.Attempts + 1 : 0;
                    }
                    else
                    {
                        callDate = Convert.ToDateTime(ScheduledDateText.Text + " " + ScheduledTimeText.Text);

                        attemptCount = increaseAttemptCount ? callQueueCustomer.Attempts + 1 >= callQueue.Attempts ? callQueue.Attempts - 1 : callQueueCustomer.Attempts + 1 : 0;
                        editModel.CallDate = callDate;
                        editModel.CallbackDate = callDate;
                        editModel.Attempt = attemptCount;
                    }
                }

                //if (increaseAttemptCount)
                //{
                //    callQueueCustomer.Attempts = attemptCount;
                //    callQueueCustomer.CallDate = callDate;
                //}

                // callQueueCustomerRepository.Save(callQueueCustomer);

                var customerId = callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0;
                var prospectCustomerId = callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0;

                if (increaseAttemptCount)
                    callQueueCustomerRepository.UpdateOtherCustomerAttempt(CallQueueCustomerId, customerId, prospectCustomerId, orgRoleUserId, editModel.CallDate.Value, status == CallQueueStatus.Removed, callQueueCustomer.CallQueueId,
                        editModel.CallStatusId);

                if (status == CallQueueStatus.Completed)
                {
                    callQueueCustomerRepository.UpdateOtherCustomerStatus(customerId, prospectCustomerId, status, orgRoleUserId);
                }
                else if (ProspectCustomerIdforLeadConversion > 0 && CallStatusRadioList.SelectedItem.Value == Convert.ToString((short)CallStatus.Attended))
                {
                    var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                    var prospectCustomer = prospectCustomerRepository.GetById(ProspectCustomerIdforLeadConversion);
                    prospectCustomer.IsQueuedForCallBack = true;
                    prospectCustomer.CallBackRequestedDate = editModel.CallDate;
                    prospectCustomer.CallBackRequestedOn = DateTime.Now;
                    prospectCustomerRepository.Save(prospectCustomer);
                }
            }
            else if (isCustomerConverted)
            {
                callQueueCustomerRepository.UpdateOtherCustomerStatus(CustomerId, RegistrationFlow.ProspectCustomerId, status, orgRoleUserId);
            }
            else if (increaseAttemptCount)
            {
                callQueueCustomerRepository.UpdateOtherCustomerAttempt(CallQueueCustomerId, CustomerId, RegistrationFlow.ProspectCustomerId, orgRoleUserId, DateTime.Now.AddDays(30), false, 0);
            }
        }

        private void UpdateCallQueueCustomer(CallQueueCustomerCallDetailsEditModel editmodel, long customerId)
        {
            var callQueueCustomerRepository = IoC.Resolve<CallQueueCustomerRepository>();
            callQueueCustomerRepository.UpdateCallqueueCustomerByCustomerId(editmodel, customerId);
        }

        private long SaveDNCNotes(string prospectCustomerTag, long organizationRoleUserId)
        {
            var notesRepository = IoC.Resolve<INotesRepository>();
            Notes notes;
            notes = new Notes
            {
                Text = prospectCustomerTag,
                DataRecorderMetaData = new DataRecorderMetaData(organizationRoleUserId, DateTime.Now, null)
            };
            notes = ((IRepository<Notes>)notesRepository).Save(notes);
            return notes.Id;
        }
    }
}
