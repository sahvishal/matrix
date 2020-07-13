using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Customer
{
    public partial class CustomerAddOnProduct : Page
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

        private long? ProductId
        {
            set
            {
                RegistrationFlow.ProductId = value.HasValue ? value.Value : 0;
            }
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
            ShippingDetailControl.ShowOnlineOption = true;

            ProductOption.IsProductSelected = true;
            ProductOption.IsProductCheckboxEnabled = false;

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

        protected void BackButton_Click(object sender, EventArgs e)
        {
            RegistrationFlow = null;
            Response.RedirectUser("HomePage.aspx");
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            var orderRepository = IoC.Resolve<IOrderRepository>();
            var order = orderRepository.GetOrderByEventCustomerId(EventCustomerId.Value);
            var orderDetail = order.OrderDetails.SingleOrDefault(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)
                                                    && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted);

            var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();

            var resultShippingDetails = shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
            var cdShippingDetails = shippingDetailRepository.GetProductShippingDetailsForCancellation(orderDetail.Id);

            resultShippingDetails = resultShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToArray();

            if (Convert.ToInt64(ResultOrderId.Value) > 0 && resultShippingDetails.Count() > 0)
            {
                ErrorDiv.InnerText = "There is already an unprocessed shipping request in your order. Duplicate shipping cannot be added till this shipping request is processed. Proceed with the default selection to purchase images.";
                ErrorDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }
            if (Convert.ToInt64(ResultOrderId.Value) <= 0 && !cdShippingDetails.IsNullOrEmpty() && resultShippingDetails.Count() == 0)
            {
                ErrorDiv.InnerText = "To get an additional copy of Images, you need to select any one of the shipping options.";
                ErrorDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }

            if (ProductOption.IsProductSelected && ProductOption.ProductId > 0)
            {
                ProductId = ProductOption.ProductId;
                RedirectToPaymentPage();
            }
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
            {
                ShippingAddressId = 0;
                ShippingOptionId = 0;
            }
            
            Response.RedirectUser("Payment.aspx?CPI=true&CustomerID=" + CustomerId + "&EventCustomerId=" + EventCustomerId + "&EventId=" + EventId + "&guid=" + GuId);
        }
    }
}
