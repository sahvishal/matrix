using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Lib;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class Async_CancelledCustomers : System.Web.UI.Page
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                long eventid = Convert.ToInt64(Request.QueryString["EventID"]);
                var masterDal = new MasterDAL();
                List<EEventCustomer> arrcustomer = masterDal.GetEventCustomerList(eventid.ToString(), 13, false);
                BindCustomerList(arrcustomer);

                HtmlForm newForm = this.form1;
                newForm.Controls.Clear();
                newForm.Controls.Add(div1);

                var sb = new System.Text.StringBuilder();
                var htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

                newForm.RenderControl(htWriter);

                string strRenderedHtml = sb.ToString();
                strRenderedHtml = strRenderedHtml.Substring(strRenderedHtml.IndexOf("<div id=\"div1\""), strRenderedHtml.LastIndexOf("</div") - strRenderedHtml.IndexOf("<div id=\"div1\"") + 6);
                Response.Write(strRenderedHtml);
            }
            Response.End();
        }

        public void BindCustomerList(List<EEventCustomer> arrcustomer)
        {

            // format phone no.
            var objCommonCode = new CommonCode();

            var dtcustomerlist = new DataTable();
            dtcustomerlist.Columns.Add("CustomerID");
            dtcustomerlist.Columns.Add("CustomerName");
            dtcustomerlist.Columns.Add("CheckInTime");
            dtcustomerlist.Columns.Add("CheckOutTime");
            dtcustomerlist.Columns.Add("AppointmentID");
            dtcustomerlist.Columns.Add("ScheduledByID");
            dtcustomerlist.Columns.Add("IsTimeSaved");
            dtcustomerlist.Columns.Add("PackageID");
            dtcustomerlist.Columns.Add("PackageName");
            dtcustomerlist.Columns.Add("PackageCost");
            dtcustomerlist.Columns.Add("CouponCode");
            dtcustomerlist.Columns.Add("CouponValue");
            dtcustomerlist.Columns.Add("NetPayment");
            dtcustomerlist.Columns.Add("IsPaid");
            dtcustomerlist.Columns.Add("AppointmentTime", typeof(DateTime));
            dtcustomerlist.Columns.Add("EventCustomerID");
            dtcustomerlist.Columns.Add("Email");
            dtcustomerlist.Columns.Add("Phone");
            dtcustomerlist.Columns.Add("NoShow", typeof(Boolean));

            dtcustomerlist.Columns.Add("Reason");
            dtcustomerlist.Columns.Add("Subject");
            dtcustomerlist.Columns.Add("IsTestConducted", typeof(Boolean));
            dtcustomerlist.Columns.Add("UserDateCreated");
            dtcustomerlist.Columns.Add("IsMedicalHistoryFilled");
            dtcustomerlist.Columns.Add("IsResultReady");
            dtcustomerlist.Columns.Add("CustomerEventTestID");
            dtcustomerlist.Columns.Add("TestStatus");

            dtcustomerlist.Columns.Add("UserCreationMode");
            dtcustomerlist.Columns.Add("EventCount");
            dtcustomerlist.Columns.Add("RegisteredBy");
            dtcustomerlist.Columns.Add("DateRegisteredOn");
            dtcustomerlist.Columns.Add("MedicalHistoryURLQuStr");
            dtcustomerlist.Columns.Add("IsAuthorized", typeof(bool));

            for (int icount = 0; icount < arrcustomer.Count; icount++)
            {
                ECustomers objcustomer = arrcustomer[icount].Customer;
                string packageTestnameString = string.Empty;


                string customername = objcustomer.User.FirstName;
                if (objcustomer.User.MiddleName.Length > 0)
                    customername += " " + objcustomer.User.MiddleName;

                customername += " " + objcustomer.User.LastName;

                DateTime appointmenttime = Convert.ToDateTime(arrcustomer[icount].EventAppointment.StartTime);
                string paymentstatus = "";
                if (arrcustomer[icount].Paid == true)
                    paymentstatus = "PAID";
                else
                    paymentstatus = "NOT PAID";

                string couponcode = "N/A";
                string couponvalue = "0.00";
                if (!arrcustomer[icount].Coupon.CouponCode.Equals("0"))
                {
                    couponcode = arrcustomer[icount].Coupon.CouponCode;
                }
                if (!arrcustomer[icount].Coupon.CouponAmount.ToString().Equals("0"))
                {
                    couponvalue = arrcustomer[icount].Coupon.CouponAmount.ToString();
                }

                string strmedicalhistoryqustr = "CustomerID=" + objcustomer.CustomerID + "&Package=" + arrcustomer[icount].EventPackage.Package.PackageName.Replace(" ", "@").Replace("+", "*");
                if (arrcustomer[icount].Customer.IsHistoryFilled)
                {
                    strmedicalhistoryqustr += "&Edit=true";
                }

                string usercreateddate = "";
                string phoneCell = objcustomer.User.PhoneCell;

                if (objCommonCode.FormatPhoneNumberGet(phoneCell).Length > 0)
                {
                    phoneCell = "PH:" + objCommonCode.FormatPhoneNumberGet(phoneCell);
                }
                if (arrcustomer[icount].Customer.User.DateApplied != null)
                    usercreateddate = arrcustomer[icount].Customer.User.DateApplied.ToString();



                Session["PackageName"] = arrcustomer[icount].EventPackage.Package.PackageName;



                if ((!string.IsNullOrEmpty(arrcustomer[icount].EventPackage.Package.PackageName)) && (!string.IsNullOrEmpty(arrcustomer[icount].AdditionalTest)))
                    packageTestnameString = arrcustomer[icount].EventPackage.Package.PackageName + ", " + arrcustomer[icount].AdditionalTest;
                else
                {
                    packageTestnameString = !string.IsNullOrEmpty(arrcustomer[icount].EventPackage.Package.PackageName) ? arrcustomer[icount].EventPackage.Package.PackageName : arrcustomer[icount].AdditionalTest;
                }


                if (arrcustomer[icount].EventAppointment.CheckInTime.Length < 1 || arrcustomer[icount].EventAppointment.CheckOutTime.Length < 1)
                    dtcustomerlist.Rows.Add(new object[] { objcustomer.CustomerID, customername,  
                                                            arrcustomer[icount].EventAppointment.CheckInTime, arrcustomer[icount].EventAppointment.CheckOutTime, 
                                                            arrcustomer[icount].EventAppointment.AppointmentID.ToString(), 
                                                            arrcustomer[icount].EventAppointment.ScheduleByID.ToString(), "NULL", 
                                                            arrcustomer[icount].EventPackage.Package.PackageID, packageTestnameString, 
                                                            "$" + arrcustomer[icount].EventPackage.PackagePrice, couponcode, couponvalue, 
                                                            "$" + arrcustomer[icount].PaymentDetail.Amount, paymentstatus, appointmenttime, 
                                                            arrcustomer[icount].CustomerEventTestID.ToString(), objcustomer.User.EMail1, 
                                                            phoneCell, arrcustomer[icount].NoShow,  
                                                            arrcustomer[icount].EventAppointment.Reason, arrcustomer[icount].EventAppointment.Subject, 
                                                            arrcustomer[icount].TestConducted, usercreateddate, 
                                                            arrcustomer[icount].Customer.IsHistoryFilled, arrcustomer[icount].Customer.IsResultsReady, 
                                                            arrcustomer[icount].EventCustomerID, arrcustomer[icount].CustomerTestStatus, 
                                                            arrcustomer[icount].Customer.UserCreationMode, arrcustomer[icount].Customer.EventCount > 0 ? arrcustomer[icount].Customer.EventCount - 1 : arrcustomer[icount].Customer.EventCount, 
                                                            arrcustomer[icount].RegisteredBy, arrcustomer[icount].DateCreated.ToString("MM/dd/yyyy"),strmedicalhistoryqustr, arrcustomer[icount].IsAuthorized });
                else
                    dtcustomerlist.Rows.Add(new object[] { objcustomer.CustomerID, customername, 
                                                            arrcustomer[icount].EventAppointment.CheckInTime, arrcustomer[icount].EventAppointment.CheckOutTime, 
                                                            arrcustomer[icount].EventAppointment.AppointmentID.ToString(), arrcustomer[icount].EventAppointment.ScheduleByID.ToString(), 
                                                            "DB", arrcustomer[icount].EventPackage.Package.PackageID, 
                                                            packageTestnameString, "$" + arrcustomer[icount].EventPackage.PackagePrice, 
                                                            couponcode, couponvalue, "$" + arrcustomer[icount].PaymentDetail.Amount, paymentstatus, 
                                                            appointmenttime, arrcustomer[icount].CustomerEventTestID.ToString(), 
                                                            objcustomer.User.EMail1, phoneCell, arrcustomer[icount].NoShow, 
                                                            arrcustomer[icount].EventAppointment.Reason, arrcustomer[icount].EventAppointment.Subject, 
                                                            arrcustomer[icount].TestConducted, usercreateddate, arrcustomer[icount].Customer.IsHistoryFilled, 
                                                            arrcustomer[icount].Customer.IsResultsReady, arrcustomer[icount].EventCustomerID, 
                                                            arrcustomer[icount].CustomerTestStatus, arrcustomer[icount].Customer.UserCreationMode, 
                                                            arrcustomer[icount].Customer.EventCount > 0 ? arrcustomer[icount].Customer.EventCount - 1 : arrcustomer[icount].Customer.EventCount, arrcustomer[icount].RegisteredBy, 
                                                            arrcustomer[icount].DateCreated.ToString("MM/dd/yyyy"),strmedicalhistoryqustr, arrcustomer[icount].IsAuthorized });
            }

            /*  added for sorting while keeping the filters applied */
            dtcustomerlist.DefaultView.RowFilter = "";

            /* **************************************************** */

            if (dtcustomerlist.DefaultView.Count < 1)
            {
                innerDivCancelledCustomers.Style[HtmlTextWriterStyle.Display] = "none";
                divNoRecordsFound.Style[HtmlTextWriterStyle.Display] = "block";
            }
            else
            {
                innerDivCancelledCustomers.Style[HtmlTextWriterStyle.Display] = "block";
                divNoRecordsFound.Style[HtmlTextWriterStyle.Display] = "none";
                grdeventCancelledcustomers.DataSource = dtcustomerlist.DefaultView;
                grdeventCancelledcustomers.DataBind();

                //string strformingpackagestring = "";

                //string defview = dtcustomerlist.DefaultView.RowFilter;
                //ArrayList arrpackagename = new ArrayList();
                //for (int vwcounter = 0; vwcounter < dtcustomerlist.DefaultView.Count; vwcounter++)
                //{
                //    string packagename = dtcustomerlist.DefaultView[vwcounter]["PackageName"].ToString();
                //    if (arrpackagename.Count > 0)
                //    {
                //        if (arrpackagename.Contains(packagename))
                //            continue;
                //    }

                //    arrpackagename.Add(packagename);

                //    dtcustomerlist.DefaultView.RowFilter = "PackageName = '" + packagename + "'";
                //    if (dtcustomerlist.DefaultView.Count > 0)
                //        strformingpackagestring += packagename + ": <b>" + dtcustomerlist.DefaultView.Count + " </b> &nbsp;|&nbsp;";
                //    dtcustomerlist.DefaultView.RowFilter = defview;
                //}
            }

        }

        protected void grdeventCancelledcustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                long eventId = Request.QueryString["EventID"] != null ? Convert.ToInt64(Request.QueryString["EventID"]) : 0;
                var viewOrderDetailsSpan = e.Row.FindControl("ViewOrderDetailsSpan") as HtmlContainerControl;
                var customerNameSpan = e.Row.FindControl("_customerName") as HtmlContainerControl;
                var customerIdSpan = e.Row.FindControl("_customerId") as HtmlContainerControl;
                long customerId = customerIdSpan != null ? Convert.ToInt64(customerIdSpan.InnerHtml.Trim()) : 0;
                string customerName = customerNameSpan != null ? customerNameSpan.InnerHtml.Trim() : "";

                var order = _orderRepository.GetOrder(customerId, eventId);

                if (viewOrderDetailsSpan != null && order != null)
                {
                    customerName = !string.IsNullOrEmpty(customerName) ? customerName.Replace("'", "\\'") : "";

                    viewOrderDetailsSpan.InnerHtml += "(<a id='" + customerId + "_Paid' href=\"javascript:ShowOrderDetailsDialog(" +
                                 order.Id + "," + order.DiscountedTotal.ToString("0.00") + "," + order.TotalAmountPaid.ToString("0.00") + "," +
                                 (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00") + ",'" + customerName + "'," +
                                 customerId + ");\">View Detail</a>)<br />";
                }
            }
        }
    }
}
