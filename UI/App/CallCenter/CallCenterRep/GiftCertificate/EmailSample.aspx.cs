using System;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Deprecated.Repository;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.GiftCertificate
{
    public partial class EmailSample : System.Web.UI.Page
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

            GiftCertificatePreview.IsCallCenterPurchase = true;
            GiftCertificatePreview.IsOnlinePurchase = false;
            GiftCertificatePreview.CustomerId = CustomerId;
            if (CustomerId > 0)
            {
                HeadingText.InnerText = "4";
            }
        }

    }


}
