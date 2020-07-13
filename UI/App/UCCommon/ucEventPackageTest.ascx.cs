using System;
using System.Linq;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Finance.Impl;


namespace Falcon.App.UI.App.UCCommon
{
    public partial class ucEventPackageTest : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetOrderPackageTest(Core.Finance.Domain.Order order, EventCustomerPackageTestDetailViewData eventCustomerPackageTestDetailViewData)
        {
            IOrderController orderController = new OrderController();
            var orderDetail = orderController.GetActiveOrderDetail(order);
            var shippingPrice = Math.Round(orderDetail.ShippingDetailOrderDetails.Sum(sdod => sdod.Amount), 2);
            
            if (eventCustomerPackageTestDetailViewData.Package != null)
            {
                lblPackagename.Text = eventCustomerPackageTestDetailViewData.Package.Name;

                string packageTest = string.Empty;
                foreach (var test in eventCustomerPackageTestDetailViewData.Package.Tests)
                {
                    packageTest += "<li style=\"margin: 0px 10px; padding: 0px 0px; list-style: disc;\">" + test.Name + "</li>";
                }
                _lblTestNames.InnerHtml = packageTest;
            }
            else
            {

                _lblPackageRow.Visible = false;
                AdditionalTest.InnerHtml = "Test(s):";
            }
            var additionalTest = string.Empty;
            foreach (var test in eventCustomerPackageTestDetailViewData.Tests)
            {
                additionalTest += "<li style=\"margin: 0px 10px; padding: 0px 0px; list-style: disc;\">" + test.Name + "</li>";
            }

            _lblAdditionalTestNames.InnerHtml = additionalTest;
            if (eventCustomerPackageTestDetailViewData.Tests.Count<1) _lblAdditionalTestRow.Visible = false;

            if (eventCustomerPackageTestDetailViewData.ElectronicProduct != null)
            {
                //_lblProductNameRow.Visible = true;
                //lblProductName.Text = eventCustomerPackageTestDetailViewData.ElectronicProduct.Name;
                _lblProductPriceRow.Visible = true;
                lblProductPrice.Text = eventCustomerPackageTestDetailViewData.ElectronicProduct.Price.ToString("C2");
            }
            else
            {
                //_lblProductNameRow.Visible = false;
                _lblProductPriceRow.Visible = false;
            }
            string strPaymentStatus = "Not Paid";
            if (order.TotalAmountPaid > 0 && order.TotalAmountPaid < order.DiscountedTotal)
                strPaymentStatus = "Partially Paid";
            else if (order.TotalAmountPaid >= order.DiscountedTotal)
                strPaymentStatus = "Paid";

            //strPaymentStatus = (order.TotalAmountPaid - order.DiscountedTotal) >= 0 ? "Paid" : "Not Paid";
           
            lblPrice.Text = (order.OrderValue - order.OrderDiscount).ToString("C2");
            lblShippingPrice.Text =    orderDetail.ShippingDetailOrderDetails.Count > 0 ? shippingPrice.ToString("C2") : "N/A";
            lblTotalPrice.Text = order.DiscountedTotal.ToString("C2");
            lblPaymentStatus.Text = strPaymentStatus;


        }
    }
}