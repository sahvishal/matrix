using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.DataAccess.Other;
using Falcon.Entity.CallCenter;
using Falcon.App.Lib;
using Falcon.App.Infrastructure.Deprecated.Repository;

public partial class App_CallCenter_CallCenterRepDashboard : Page
{
    public long ExisitingCallId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
        }
    }

    private string GuId { get; set; }

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

    protected bool StartCallAutomatically
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Call Center Rep Dashboard";
        var obj = (CallCenter_CallCenterMaster)this.Master;
        obj.settitle("Call Center Rep Dashboard");
        obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null && (Request.UrlReferrer.LocalPath != Request.Url.LocalPath))
            {
                if (RegistrationFlow != null)
                    RegistrationFlow.CallId = 0;
            }
        }

        if (!IsPostBack)
        {
            chkOutBoundCall.Attributes.Add("onClick", "return CheckOutBoundCall();");
            ibtnStartCall.Enabled = false;
            chkOutBoundCall.Enabled = false;

            if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
            {
                spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                divLastLogin.Visible = false;
            }

            txtIncomingPhLine.Focus();

            if (Request.QueryString["dn"] != null)
            {
                txtIncomingPhLine.Text = Request.QueryString["dn"];
            }

            if (Request.QueryString["cn"] != null)
            {
                txtCallersPhNumber.Text = Request.QueryString["cn"];
            }
            else if (Request.QueryString["amp;cn"] != null)
            {
                txtCallersPhNumber.Text = Request.QueryString["amp;cn"];
            }

            if (!string.IsNullOrWhiteSpace(txtCallersPhNumber.Text) && txtCallersPhNumber.Text.Length > 3 && txtCallersPhNumber.Text.IndexOf("000", 0, 3) >= 0)
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                var areaCode = Convert.ToString(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.AreaCode));
                if (!string.IsNullOrWhiteSpace(areaCode))
                    txtCallersPhNumber.Text = txtCallersPhNumber.Text.Replace(txtCallersPhNumber.Text, areaCode + txtCallersPhNumber.Text.Substring(3));
            }


            if (IoC.Resolve<ISettings>().EnableCallPop)
            {
                ibtnStartCall.Enabled = true;
                ClientScript.RegisterStartupScript(typeof(string), "jscode_checkStartCall", "CheckOutBoundCall();", true);
                chkOutBoundCall.Enabled = true;
            }
            else if (txtIncomingPhLine.Text != "" && txtCallersPhNumber.Text != "")
            {
                ibtnStartCall.Enabled = true;
                ibtnStartCall.ToolTip = "";
            }
            else
            {
                ibtnStartCall.Enabled = true;
                ClientScript.RegisterStartupScript(typeof(string), "jscode_checkStartCall", "CheckOutBoundCall();", true);
                chkOutBoundCall.Enabled = true;

                ibtnStartCall.ToolTip = "Please select Checkbox to start call.";
            }

            var callcenterDal = new CallCenterDAL();

            List<EScript> scripts = callcenterDal.GetScript(callcenterDal.GetScriptType("Welcome Script", 2)[0].ScriptTypeID.ToString(), 4);

            scripts[0].ScriptText = scripts[0].ScriptText.Replace("<<Your Name>>", IoC.Resolve<ISessionContext>().UserSession.FullName);
            //spWelcomeScript.InnerText = scripts[0].ScriptText;
            // to check if the existing call is in progress

            if (ExisitingCallId > 0)
            {
                hfCallStartTime.Value = new CallCenterCallRepository().GetCallStarttime(ExisitingCallId);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Int32), "JS",
                    "<script language='javascript'>var hfCallStartTime= document.getElementById('" +
                    hfCallStartTime.ClientID + "'); Call();  </script>", false);
            }
            else if (Request.QueryString["dn"] != null && (Request.QueryString["cn"] != null || Request.QueryString["amp;cn"] != null))
            {
                StartCallAutomatically = true;
            }

            // Get Dashboard Referesh Time From DB
            var otherDal = new OtherDAL();
            hidRefereshTime.Value = otherDal.GetConfigurationValue("CCRepDashBoardRefereshTime");
        }
        else
        {
            if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "setCallStartTime")
            {
                //Doing Nothing
            }
        }
        BindDropDownControls();
    }

    protected void ibtnStartCall_Click(object sender, ImageClickEventArgs e)
    {
        var objCcRepCall = new ECall();
        objCcRepCall.CallCenterCallCenterUserID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        objCcRepCall.TimeCreated = DateTime.Now.ToString();
        objCcRepCall.IncomingPhoneLine = txtIncomingPhLine.Text;
        objCcRepCall.CallersPhoneNumber = txtCallersPhNumber.Text;
        objCcRepCall.CallNotes = new List<ECallCenterNotes>();
        objCcRepCall.OutBound = chkOutBoundCall.Checked;

        var callcenterDal = new CallCenterDAL();

        var returnresult = callcenterDal.UpdateCall(objCcRepCall);

        GuId = Guid.NewGuid().ToString();
        var registrationFlow = new RegistrationFlowModel
                                   {
                                       GuId = GuId,
                                       CallId = returnresult,
                                       PreQualificationResultId = 0
                                   };
        RegistrationFlow = registrationFlow;

        Response.RedirectUser("BasicCallInfo.aspx?guid=" + GuId);
    }

    protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
    {
        var objCommoncode = new CommonCode();
        objCommoncode.EndCCRepCall(Page);

        var strJsCloseWindow = new System.Text.StringBuilder();
        strJsCloseWindow.Append(" <script language = 'Javascript'>CallEnd(); </script>");
        ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
    }

    private void BindDropDownControls()
    {
        var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
        var callQueues = callQueueRepository.GetByAssignedToOrgRoleUserId(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

        long callQueueId = 0;

        if (Request.QueryString["cq"] != null)
        {
            long.TryParse(Request.QueryString["cq"], out callQueueId);
        }
        if (callQueues != null && callQueues.Any())
        {
            CallQueues.DataSource = callQueues;
            CallQueues.DataTextField = "Name";
            CallQueues.DataValueField = "Id";
            CallQueues.DataBind();
            CallQueues.Items.Insert(0, (new ListItem("--Select--", "0")));

            CallQueues.SelectedValue = callQueueId.ToString();
        }
        else
        {
            CallQueues.Items.Insert(0, (new ListItem("--No Call Queue Assigned--", "0")));
        }
    }
}
