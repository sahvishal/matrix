using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using System.Collections.Generic;
using Falcon.App.UI.App.BasePageClass;

namespace Falcon.App.UI.Config.Content.Controls
{
    public partial class SmallPrintReciept : BasePage
    {
        private dynamic printReceiptModel = new ExpandoObject();

        private class OrderItemListModel
        {
            public string TestName { get; set; }
            public string DiagnosisCode { get; set; }
            public string CtpCode { get; set; }
            public string Price { get; set; }

        }
        private class PaymentDetailListModel
        {
            public string By { get; set; }
            public string On { get; set; }
            public string Details { get; set; }
            public string Amount { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PageCallBackFrom"] != null && Request.QueryString["PageCallBackFrom"] == "AcceptPayment")
            {
                hfPageCallBackFrom.Value = Request.QueryString["PageCallBackFrom"];
                pPrintBtn.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                pPrintBtn.Style.Add(HtmlTextWriterStyle.Display, "block");
                divAlignCenter.Style.Add(HtmlTextWriterStyle.PaddingLeft, "125px");

                var strJsCloseWindow = new StringBuilder();
                strJsCloseWindow.AppendLine("function ReloadParentPage(){");
                strJsCloseWindow.AppendLine("window.close();");
                strJsCloseWindow.AppendLine("window.parent.opener.checkClose();");
                strJsCloseWindow.AppendLine("window.opener.location.reload();}");
                ClientScript.RegisterClientScriptBlock(typeof(string), "JSCode_CloseWindow", strJsCloseWindow.ToString(), true);
            }
            else
            {
                var strJsCloseWindow = new StringBuilder();
                strJsCloseWindow.Append("function ReloadParentPage(){}");

                ClientScript.RegisterClientScriptBlock(typeof(string), "JSCode_CloseWindow", strJsCloseWindow.ToString(), true);
            }
            if (Request.QueryString["CustomerID"] != null && Request.QueryString["EventID"] != null)
            {
                var orderItemListModel = new List<OrderItemListModel>();
                var paymentList = new List<PaymentDetailListModel>();

                var eventId = Request.QueryString["EventID"] != null && !string.IsNullOrEmpty(Request.QueryString["EventID"])
                                  ? Convert.ToInt64(Request.QueryString["EventID"])
                                  : 0;
                var customerId = Request.QueryString["CustomerID"] != null && !string.IsNullOrEmpty(Request.QueryString["CustomerID"])
                                     ? Convert.ToInt64(Request.QueryString["CustomerID"])
                                     : 0;

                ICustomerRepository customerRepository = new CustomerRepository();
                var customer = customerRepository.GetCustomer(customerId);

                IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository =
                    new EventCustomerRegistrationViewDataRepository();


                //TODO: Remove all calls and get it in a single call as well refactoring code.
                Order order = null;
                OrderDetail orderDetail = null;
                IOrderRepository orderRepository = new OrderRepository();
                try
                {
                    order = orderRepository.GetOrder(customerId, eventId);
                    IOrderController orderController = new OrderController();
                    orderDetail = orderController.GetActiveOrderDetail(order);

                    if (order == null || orderDetail == null) return;
                    IOrderReceiptService orderReceiptService = new OrderReceiptService();
                    var testDetailViewData =
                        orderReceiptService.GetOrderTestViewData(eventId, customerId);

                    //Resolve it through Ioc
                    var orderService = IoC.Resolve<IOrderService>();
                    var paymentViewData = orderService.GetPaymentDetailViewData(order.Id);

                    var orderItemDetail = new StringBuilder();
                    var paymentDetail = new StringBuilder();


                    // TODO: This is done for private events in order to hide the price descrapancy.
                    if (order.UndiscountedTotal == 0)//eventData.RegistrationMode == RegistrationMode.Private
                    {
                        _tdPrice.Style["Display"] = "none";

                    }

                    bool isCptCode = true;
                    bool isDiagnosisCode = true;
                    //if (testDetailViewData.Where(t => !string.IsNullOrWhiteSpace(t.CptCode)).Count() > 0)
                    //    isCptCode = true;

                    //if (testDetailViewData.Where(t => !string.IsNullOrWhiteSpace(t.DiagnosisCode)).Count() > 0)
                    //    isDiagnosisCode = true;



                    if (!isCptCode) _tdCPT.Style["Display"] = "none";

                    if (!isDiagnosisCode) _tdDiagnosisCode.Style["Display"] = "none";

                    if (order.UndiscountedTotal != 0)
                    {
                        foreach (var test in testDetailViewData)
                        {
                            if (!isCptCode && !isDiagnosisCode)
                            {
                                orderItemDetail = orderItemDetail.Append("<tr><td>" + test.TestName + "</td>" +
                                                                            "<td align='right' style='display:none;'></td>" +
                                                                            "<td align='right' style='display:none;'></td>" +
                                                                            "<td align='right'>" +
                                                                            test.OfferPrice.ToString("C2") +
                                                                            "</td></tr>");
                            }
                            else
                            {
                                orderItemDetail =
                                    orderItemDetail.Append("<tr><td>" + test.TestName + "</td>" +
                                                           (!isDiagnosisCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>" + (string.IsNullOrWhiteSpace(test.DiagnosisCode) ? "NA" : test.DiagnosisCode) + "</td>") +
                                                           (!isCptCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>" + (string.IsNullOrWhiteSpace(test.CptCode) ? "NA" : test.CptCode) + "</td>") +
                                                           "<td align='right'>" + test.OfferPrice.ToString("C2") + "</td></tr>");

                            }
                            if (test.TestId == (long)TestType.MenBloodPanel || test.TestId == (long)TestType.WomenBloodPanel)
                            {
                                GetPanelTests(test, orderItemDetail, isDiagnosisCode, isCptCode, false);
                            }

                            orderItemListModel.Add(new OrderItemListModel()
                            {
                                TestName = test.TestName,
                                DiagnosisCode = !isDiagnosisCode ? "" : (string.IsNullOrWhiteSpace(test.DiagnosisCode) ? "NA" : test.DiagnosisCode),
                                CtpCode = !isCptCode ? "" : (string.IsNullOrWhiteSpace(test.CptCode) ? "NA" : test.CptCode),
                                Price = test.OfferPrice.ToString("C2")
                            });
                        }
                    }
                    else
                    {
                        foreach (var test in testDetailViewData)
                        {
                            if (!isCptCode && !isDiagnosisCode)
                            {
                                orderItemDetail =
                                    orderItemDetail.Append("<tr><td>" + test.TestName + "</td>" +
                                                           "<td align='right' style='display:none'></td>" +
                                                           "<td align='right' style='display:none;'></td>" +
                                                           "<td align='right' style='display:none'>" + "XXXX" + "</td></tr>");

                            }
                            else
                            {
                                orderItemDetail =
                                    orderItemDetail.Append("<tr><td>" + test.TestName + "</td>" +
                                                           (!isDiagnosisCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>" + (string.IsNullOrWhiteSpace(test.DiagnosisCode) ? "NA" : test.DiagnosisCode) + "</td>") +
                                                           (!isCptCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>" + (string.IsNullOrWhiteSpace(test.CptCode) ? "NA" : test.CptCode) + "</td>") +
                                                           "<td align='right' style='display:none'>" + "XXXX" + "</td></tr>");
                            }

                            if (test.TestId == (long)TestType.MenBloodPanel || test.TestId == (long)TestType.WomenBloodPanel)
                            {
                                GetPanelTests(test, orderItemDetail, isDiagnosisCode, isCptCode, true);
                            }

                            orderItemListModel.Add(new OrderItemListModel()
                            {
                                TestName = test.TestName,
                                DiagnosisCode = !isDiagnosisCode ? "" : (string.IsNullOrWhiteSpace(test.DiagnosisCode) ? "NA" : test.DiagnosisCode),
                                CtpCode = !isCptCode ? "" : (string.IsNullOrWhiteSpace(test.CptCode) ? "NA" : test.CptCode)
                            });
                        }
                    }


                    _orderDetail.InnerHtml = orderItemDetail.ToString();

                    //Payments
                    if (order.UndiscountedTotal != 0)
                    {
                        foreach (var payment in paymentViewData)
                        {
                            paymentDetail =
                                paymentDetail.Append("<tr><td>" + payment.PaymentInstrumentName + "</td><td align='left'>" +
                                                     payment.DateCreated + "</td></td><td align='left'>" +
                                                     payment.InstrumentNumber + "</td><td align='right'>" +
                                                     payment.Amount.ToString("C2") + "</td></tr>");
                            paymentList.Add(new PaymentDetailListModel()
                            {
                                By = payment.PaymentInstrumentName,
                                On = payment.DateCreated,
                                Details = payment.InstrumentNumber,
                                Amount = payment.Amount.ToString("C2")
                            });
                        }
                    }
                    else
                    {
                        paymentDetail =
                            paymentDetail.Append("<tr><td>" + "Corporate" +
                                                 "</td><td align='left'>" +
                                                 "-" + "</td><td align='left'>" +
                                                 "-" + "</td><td align='right'>" +
                                                 "-" + "</td></tr>");
                        paymentList.Add(new PaymentDetailListModel()
                        {
                            By = "Corporate"
                        });
                    }

                    if (order.OrderDiscount == order.UndiscountedTotal)
                    {
                        paymentDetail =
                            paymentDetail.Append("<tr><td>" + "100% coupon applied" +
                                                 "</td><td align='left'>" +
                                                 orderDetail.SourceCodeOrderDetail.DateCreated.ToShortDateString() + "</td><td align='left'>-</td><td align='right'>(" +
                                                 orderDetail.SourceCodeOrderDetail.Amount.ToString("C2") + ")</td></tr>");
                        paymentList.Add(new PaymentDetailListModel()
                        {
                            By = "100% coupon applied",
                            On = "",
                            Details = orderDetail.SourceCodeOrderDetail.DateCreated.ToShortDateString(),
                            Amount = orderDetail.SourceCodeOrderDetail.Amount.ToString("C2")
                        });
                    }

                    if (string.IsNullOrWhiteSpace(paymentDetail.ToString()))
                    {
                        paymentDetail =
                            paymentDetail.Append("<tr><td>" + "Unpaid" +
                                                 "</td><td align='left'>" +
                                                 "-" + "</td><td align='left'>" +
                                                 "-" + "</td><td align='right'>" +
                                                 "-" + "</td></tr>");
                        paymentList.Add(new PaymentDetailListModel()
                        {
                            By = "Unpaid"
                        });
                    }

                    _payments.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(paymentDetail.ToString(), true);//paymentDetail.ToString();

                }

                catch
                { }


                decimal amountPaid = order != null ? order.TotalAmountPaid : 0m;
                var shippingPrice = 0m;
                foreach (var shippingDetailOrderDetail in orderDetail.ShippingDetailOrderDetails)
                {
                    shippingPrice += shippingDetailOrderDetail.Amount;
                }

                _spnshipping.InnerText = (orderDetail.ShippingDetailOrderDetails.Count > 0) ? shippingPrice.ToString("C2") : "N/A";


                if (orderDetail.SourceCodeOrderDetail != null)
                {
                    _spnDiscount.InnerText = "(" + order.OrderDiscount.ToString("C2") + ")";
                }
                else
                {
                    _discountRow.Visible = false;
                }

                if (order != null)
                {
                    _productRow.Visible = order.ProductCost.HasValue;
                    _spnProduct.InnerText = order.ProductCost.HasValue ? order.ProductCost.Value.ToString("C2") : "";
                    var productRepository = IoC.Resolve<IElectronicProductRepository>();
                    var electronicProductDetails = productRepository.GetElectronicProductForOrder(order.Id);
                    if (electronicProductDetails != null && electronicProductDetails.Count() > 0)
                        ProductName.InnerHtml = "<strong>" + electronicProductDetails.First().Name + "</strong>";

                }



                _totalAmount.InnerText = order.DiscountedTotal.ToString("C2");
                var eventCustomerRegistrationViewData =
                    eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(customerId, eventId);

                if (eventCustomerRegistrationViewData != null && customer != null)
                {
                    lblCustomerName.Text = printReceiptModel.FullName = customer.Name.FullName;
                    lblCustomerID.Text = printReceiptModel.CustomerId = customer.CustomerId.ToString();
                    username.InnerText = printReceiptModel.UserName = customer.UserLogin.UserName;

                    Address.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(customer.Address.ToShortAddressString(), true);
                    printReceiptModel.Address = customer.Address.ToShortAddressString();

                    printReceiptModel.Shipping = _spnshipping.InnerHtml;
                    printReceiptModel.Discount = _spnDiscount.InnerHtml;

                    //lblPackageName.Text = eventCustomerRegistrationViewData.PackageName;
                    printReceiptModel.EventId = lblEventID.Text = eventCustomerRegistrationViewData.EventId.ToString();
                    printReceiptModel.EventName = lblVenue1.Text = eventCustomerRegistrationViewData.EventName;

                    lblVenue2.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(eventCustomerRegistrationViewData.EventAddress.StreetAddressLine1, true);
                    printReceiptModel.Street = eventCustomerRegistrationViewData.EventAddress.StreetAddressLine1;


                    printReceiptModel.Address = eventCustomerRegistrationViewData.EventAddress.City + ", " +
                                     eventCustomerRegistrationViewData.EventAddress.State + "&nbsp;&nbsp;" +
                                     eventCustomerRegistrationViewData.EventAddress.ZipCode.Zip;
                    lblVenue3.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(printReceiptModel.Address, true);

                    printReceiptModel.EventDate = lblDate.Text = eventCustomerRegistrationViewData.EventDate.ToLongDateString();
                    printReceiptModel.Appointment = lblTime.Text = eventCustomerRegistrationViewData.AppointmentStartTime.ToShortTimeString();

                    //GetCurrentOrder(Convert.ToInt64(Request.QueryString["CustomerID"]), Convert.ToInt64(Request.QueryString["EventID"]));

                    printReceiptModel.AmountPaid = lblAmountPaid.Text = amountPaid.ToString("C2");


                    var model = new
                    {
                        printReceiptModel,
                        OrderDetailList = orderItemListModel,
                        PaymentDetailsList = paymentList
                    };
                    LogRelatedModel(ModelType.View, model, customerId);
                    //var orderid = order != null ? order.Id.ToString() : string.Empty;
                    //string strBc = "C" + lblCustomerID.Text + "P" + orderid + "E" +
                    //               lblEventID.Text + "P" + DateTime.Today.ToString("yyyyMMdd");
                    //TODO: Host this service - Not able to find the source code.
                    //imgBarcode.Src = "http://services.healthyes.com/Barcode/BarCode.aspx?text=" + strBc;
                    //lblbc.Text = strBc;
                }
            }
        }

        private void GetPanelTests(TestViewData test, StringBuilder orderItemDetail, bool isDiagnosisCode, bool isCptCode, bool discounted)
        {
            var testRepository = IoC.Resolve<IUniqueItemRepository<Test>>();

            var testList = new List<Test>();
            if (test.TestId == (long)TestType.WomenBloodPanel)
            {
                testList = testRepository.GetByIds(TestGroup.WomenBloodPanelTestIds).ToList();
            }
            if (test.TestId == (long)TestType.MenBloodPanel)
            {
                testList = testRepository.GetByIds(TestGroup.MensBloodPanelTestIds).ToList();
            }

            foreach (var test1 in testList)
            {
                if (discounted)
                {
                    if (!isDiagnosisCode && !isCptCode)
                    {
                        orderItemDetail.Append("<tr><td><span style='padding-left:30px'>" + test1.Name + "</span></td>" + "<td align='right' style='display:none'></td>" + "<td align='right' style='display:none;'></td>" +
                                                               "<td align='right' style='display:none'>" + "XXXX" + "</td></tr>");
                    }
                    else
                    {
                        orderItemDetail =
                            orderItemDetail.Append("<tr><td><span style='padding-left:30px'>" + test1.Name + "</span></td>" +
                                                   (!isDiagnosisCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>" + (string.IsNullOrWhiteSpace(test1.DiagnosisCode) ? "NA" : test1.DiagnosisCode) + "</td>") +
                                                   (!isCptCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>" + (string.IsNullOrWhiteSpace(test1.CPTCode) ? "NA" : test.CptCode) + "</td>") +
                                                   "<td align='right' style='display:none'>" + "XXXX" + "</td></tr>");
                    }
                }
                else
                {
                    if (!isCptCode && !isDiagnosisCode)
                    {
                        orderItemDetail = orderItemDetail.Append("<tr><td><span style='padding-left:30px'>" + test1.Name + "</span></td>" + "<td align='right' style='display:none;'></td>" + "<td align='right' style='display:none;'></td>"
                                            + "<td align='right'>$0.00</td></tr>");
                    }
                    else
                    {
                        orderItemDetail = orderItemDetail.Append("<tr><td><span style='padding-left:30px'>" + test1.Name + "</span></td>" + (!isDiagnosisCode ? "<td align='right' style='display:none;'></td>" : "<td align='right'>"
                                            + (string.IsNullOrWhiteSpace(test1.DiagnosisCode) ? "NA" : test1.DiagnosisCode) + "</td>") + (!isCptCode ? "<td align='right' style='display:none;'></td>"
                                            : "<td align='right'>" + (string.IsNullOrWhiteSpace(test1.CPTCode) ? "NA" : test1.CPTCode) + "</td>") + "<td align='right'>$0.00</td></tr>");
                    }

                }


            }

        }

    }
}
