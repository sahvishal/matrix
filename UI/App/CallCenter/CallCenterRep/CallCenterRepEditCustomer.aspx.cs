using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.DataAccess.Other;

public partial class App_CallCenter_CallCenterRep_CallCenterRepEditCustomer : Page
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
    protected long ExistingCallId
    {
        get { return RegistrationFlow != null ? RegistrationFlow.CallId : 0; }
    }

    protected long SystemRoleId
    {
        get
        {
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            return currentOrgRole.GetSystemRoleId;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Edit Customer";
        var objMaster = (CallCenter_CallCenterMaster1)this.Master;
        if (SystemRoleId == (long)Roles.CallCenterRep)
        {
            objMaster.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">DashBoard</a>";
        }
        else if (SystemRoleId == (long)Roles.CallCenterManager)
        {
            objMaster.SetBreadCrumbRoot = "<a href=\"/App/CallCenter/CallCenterManagerDashBoard.aspx\">DashBoard</a>";
        }

        objMaster.SetTitle("Customer Profile");
        if (!IsPostBack)
        {

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
            else
            {
                var repository = new CallCenterCallRepository();
                var objCall = repository.GetCallCenterEntity(ExistingCallId);
                hfCallStartTime.Value = objCall.TimeCreated;
            }

            if (Request.QueryString["UserID"] != null)
            {
                UCEditCustomer1.UserID = Convert.ToInt32(Request.QueryString["UserID"]);
            }
            else if (Request.QueryString["CustomerID"] != null)
            {
                var otherDal = new OtherDAL();
                UCEditCustomer1.UserID = Convert.ToInt32(otherDal.GetUid(Convert.ToInt32(Request.QueryString["CustomerID"])));
            }

        }
    }
}
