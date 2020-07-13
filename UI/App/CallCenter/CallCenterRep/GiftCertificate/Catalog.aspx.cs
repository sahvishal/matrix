using System;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.GiftCertificate
{
    public partial class Catalog : System.Web.UI.Page
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

        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                CallPanel.Visible = false;
            }
            else
            {
                var callCenterCallRepo = new CallCenterCallRepository();
                hfCallStartTime.Value = callCenterCallRepo.GetCallStarttime(CallId);
            }

            var obj = (CallCenter_CallCenterMaster1)Master;
            if (obj != null)
                obj.HideBreadCrum();

            if (IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"] != null)
                {
                    string queryString = Request.Form["__EVENTARGUMENT"];
                    Response.RedirectUser("Details.aspx?Amount=" + queryString + "&guid=" + GuId);
                }
            }
        }
    }
}
