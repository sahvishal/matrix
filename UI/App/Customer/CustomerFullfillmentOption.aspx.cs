using System;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Customer
{
    public partial class CustomerFullfillmentOption : System.Web.UI.Page
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? hfGuId.Value : Request.QueryString["guid"];
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

        private long? CustomerId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerId"]))
                {
                    long customerId;
                    if (Int64.TryParse(Request.QueryString["CustomerId"], out customerId))
                    {
                        return customerId;
                    }
                }
                return null;
            }
        }

        private long? EventCustomerId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EventCustomerId"]))
                {
                    long eventCustomerId;
                    if (Int64.TryParse(Request.QueryString["EventCustomerId"], out eventCustomerId))
                    {
                        return eventCustomerId;
                    }
                }
                return null;
            }
        }

        private long? EventId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                {
                    long eventId;
                    if (Int64.TryParse(Request.QueryString["EventId"], out eventId))
                    {
                        return eventId;
                    }
                }
                return null;
            }
        }


        private long ShippingOptionId
        {
            set { RegistrationFlow.ShippingOptionId = value; }
        }

        private long ShippingAddressId
        {
            set { RegistrationFlow.ShippingAddressId = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            EventCustomerControl.EventCustomerId = EventCustomerId;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerMasterPage = (Customer_CustomerMaster)Master;
            customerMasterPage.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\">Home</a>";
            customerMasterPage.SetPageView("DashBoard");

            if (Session["LastLoginTime"] != null && !string.IsNullOrEmpty(Session["LastLoginTime"].ToString().Trim()))
            {
                spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                divLastLogin.Visible = false;
            }

            
            ShippingDetailControl.ShowFreeOption = false;
            ShippingDetailControl.ShowOnlineOption = false;
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["guid"]))
                {
                    hfGuId.Value = Guid.NewGuid().ToString();
                    var registrationFlow = new RegistrationFlowModel
                                               {
                                                   GuId = hfGuId.Value
                                               };
                    RegistrationFlow = registrationFlow;
                }
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            var shippingOptionId = Convert.ToInt64(ResultOrderId.Value);
            if (shippingOptionId > 0)
                RedirectToPaymentPage();
            else
            {
                RegistrationFlow = null;
                Response.RedirectUser("HomePage.aspx");
            }
        }

        private void RedirectToPaymentPage()
        {
            if (Convert.ToInt64(ResultOrderId.Value) > 0)
            {
                ShippingOptionId = Convert.ToInt64(ResultOrderId.Value);
                var shippingAddress = ShippingDetailControl.SaveShippingAddress();
                if (shippingAddress != null)
                    ShippingAddressId = shippingAddress.Id;
                else
                    return;
            }
            else
                return;
            
            Response.RedirectUser("Payment.aspx?CFO=true&CustomerID=" + CustomerId + "&EventCustomerId=" + EventCustomerId +
                              "&EventId=" + EventId + "&guid=" + GuId);
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            RegistrationFlow = null;
            Response.RedirectUser("HomePage.aspx");
        }
       
    }
}
