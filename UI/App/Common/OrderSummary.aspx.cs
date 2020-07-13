using System;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Common
{
    public partial class OrderSummary : System.Web.UI.Page
    {
        public string OrderId
        {
            get
            {
                if (Request.QueryString["OrderId"] != null)
                    return Request.QueryString["OrderId"].ToString();
                return string.Empty;
            }
        }

        public string AmountPaid
        {
            get
            {
                if (Request.QueryString["AmountPaid"] != null)
                    return Request.QueryString["AmountPaid"].ToString();
                return string.Empty;
            }
        }

        public string AmountDue
        {
            get
            {
                if (Request.QueryString["AmountDue"] != null)
                    return Request.QueryString["AmountDue"].ToString();
                return string.Empty;
            }
        }

        public string TotalAmount
        {
            get
            {
                if (Request.QueryString["TotalAmount"] != null)
                    return Request.QueryString["TotalAmount"].ToString();
                return string.Empty;
            }
        }

        public string CustomerId
        {
            get
            {
                if (Request.QueryString["CustomerId"] != null)
                    return Request.QueryString["CustomerId"].ToString();
                return string.Empty;
            }
        }

        public string CustomerName
        {
            get
            {
                if (Request.QueryString["CustomerName"] != null)
                    return Request.QueryString["CustomerName"].ToString();
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            long orderId = 0;
            string totalAmount = TotalAmount;
            string amountPaid = AmountPaid;
            string amountDue = AmountDue;

            if(string.IsNullOrEmpty(TotalAmount) && string.IsNullOrEmpty(AmountPaid) && string.IsNullOrEmpty(AmountDue) && long.TryParse(OrderId, out orderId))
            {
                var order = IoC.Resolve<IOrderRepository>().GetOrder(orderId);
                totalAmount = order.DiscountedTotal.ToString("0.00");
                amountPaid = order.TotalAmountPaid.ToString("0.00");
                amountDue = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");
            }

            ClientScript.RegisterStartupScript(Page.GetType(), "js_OpenOrderSummary", "ShowOrderDetailsDialog1('" + OrderId + "', '" + totalAmount + "', '" + amountPaid + "', '" + amountDue + "', '" + CustomerName.Replace("'", "\\\'") + "', '" + CustomerId + "');", true);
            ViewOrderDetail.ShowasJDialog = false;
            
        }

    }
}