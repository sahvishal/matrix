using System;
using System.Web.UI;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.UI.App.BasePageClass;
using Falcon.Entity.CallCenter;

public partial class App_CallCenter_CallCenterRep_CallCenterRepCustomerList : BasePage
{
    protected long ExistingCallId
    {
        get
        {
            long callId = 0;
            if (Session["CallId"] != null) long.TryParse(Session["CallId"].ToString(), out callId);
            return callId;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Customer List";
        CallCenter_CallCenterMaster1 obj;
        obj = (CallCenter_CallCenterMaster1)this.Master;
        obj.SetTitle("Customer List");
        obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

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
                ECall objCall = repository.GetCallCenterEntity(ExistingCallId);
                hfCallStartTime.Value = objCall.TimeCreated;
            }

        }

    }


}
