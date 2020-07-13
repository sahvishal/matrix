using System.Web.UI;
using System;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Deprecated.Repository;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep
{
    public partial class CancelShippingDetail : Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
            
            CallCenter_CallCenterMaster1 obj;
            obj = (CallCenter_CallCenterMaster1)this.Master;
            obj.SetTitle("");
        }
    }
}