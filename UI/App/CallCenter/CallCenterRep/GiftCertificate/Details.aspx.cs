using System;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.GiftCertificate
{
    public partial class Details : System.Web.UI.Page
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

        private long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        protected bool NotInCall
        {
            get
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    return true;
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NotInCall)
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

        }

        protected void NavigateOnChangeAmountClick()
        {
            Response.RedirectUser("Catalog.aspx?guid=" + GuId, false);
        }

        protected void NavigateOnSubmitClick()
        {
            if (CustomerId > 0)
            {
                Response.RedirectUser(
                    "/App/CallCenter/CallCenterRep/ExistingCustomer/BillingInformationExisting.aspx?gc=gc" + "&guid=" + GuId);
            }

            Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?gc=gc" + "&guid=" + GuId);
        }
    }
}
