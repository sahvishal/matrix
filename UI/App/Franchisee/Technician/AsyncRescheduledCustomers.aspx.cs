using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Order;
using Gma.QrCodeNet.Encoding.DataEncodation;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class AsyncRescheduledCustomers : System.Web.UI.Page
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                long eventId = Convert.ToInt64(Request.QueryString["EventID"]);

                var eventCustomerReportingService = IoC.Resolve<IEventCustomerReportingService>();
                var rescheduledCustomers = eventCustomerReportingService.GetRescheduleAppointmentsForEvent(eventId);

                BindCustomerList(rescheduledCustomers);

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

        public void BindCustomerList(IEnumerable<EventRescheduleAppointmentViewModel> rescheduledCustomers)
        {

            var dtcustomerlist = new DataTable();
            dtcustomerlist.Columns.Add("CustomerID");
            dtcustomerlist.Columns.Add("CustomerName");
            dtcustomerlist.Columns.Add("EventId");
            dtcustomerlist.Columns.Add("EventCustomerID");
            dtcustomerlist.Columns.Add("Email");
            dtcustomerlist.Columns.Add("Phone");

            if (rescheduledCustomers != null && rescheduledCustomers.Any())
            {
                foreach (var model in rescheduledCustomers)
                {
                    dtcustomerlist.Rows.Add(new object[]
                    {
                        model.CustomerId,
                        model.CustomerName,
                        model.EventId,
                        model.EventCustomerId,
                        model.Email,
                        model.PhoneNumber
                    });
                }
            }
            

            /*  added for sorting while keeping the filters applied */
            dtcustomerlist.DefaultView.RowFilter = "";

            /* **************************************************** */

            if (dtcustomerlist.DefaultView.Count < 1)
            {
                innerDivRescheduledCustomers.Style[HtmlTextWriterStyle.Display] = "none";
                divNoRecordsFound.Style[HtmlTextWriterStyle.Display] = "block";
            }
            else
            {
                innerDivRescheduledCustomers.Style[HtmlTextWriterStyle.Display] = "block";
                divNoRecordsFound.Style[HtmlTextWriterStyle.Display] = "none";
                grdeventRescheduledCustomers.DataSource = dtcustomerlist.DefaultView;
                grdeventRescheduledCustomers.DataBind();

                
            }

        }

        protected void grdeventCancelledcustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var viewOrderDetailsSpan = e.Row.FindControl("ViewOrderDetailsSpan") as HtmlContainerControl;
                var customerNameSpan = e.Row.FindControl("_customerName") as HtmlContainerControl;
                var customerIdSpan = e.Row.FindControl("_customerId") as HtmlContainerControl;
                var eventIdIdSpan = e.Row.FindControl("_eventId") as HtmlContainerControl;
                long customerId = customerIdSpan != null ? Convert.ToInt64(customerIdSpan.InnerHtml.Trim()) : 0;
                long eventId = eventIdIdSpan != null ? Convert.ToInt64(eventIdIdSpan.InnerHtml.Trim()) : 0;

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