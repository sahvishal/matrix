using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Repositories.Host;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.UI.Controls;
using Falcon.App.Core.Extensions;
using System.Linq;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.UI.App.Franchisee.Reports
{
    public partial class TrackHostPaymentDetail : Page
    {
        private readonly IHostDepositService _hostDepositService = new HostDepositService();
        private const HostPaymentStatus PaymentStatus = HostPaymentStatus.Pending;
        private const HostPaymentType PaymentMode = HostPaymentType.Both;
        private readonly IHostPaymentRepository _hostPaymentRepository = new HostPaymentRepository();
        private readonly IHostDeositRepository _hostDeositRepository = new HostDepositRepository();
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository = new OrganizationRoleUserRepository();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var franchisorFranchisorMaster = Page.Master as Franchisor_FranchisorMaster;
            if (franchisorFranchisorMaster != null)
            {
                franchisorFranchisorMaster.HideLeftContainer = true;
                franchisorFranchisorMaster.hideucsearch();
                franchisorFranchisorMaster.settitle("Track Host Payments");
                franchisorFranchisorMaster.SetBreadCrumbRoot =
                    "<a href=\"/App/Franchisor/Dashboard.aspx\">Dashboard</a>";
            }
            if (!IsPostBack)
            {
                BindDropDowns();
                BindDataForFiltes();

                _organizationRoleUserId.Value = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId.ToString();
            }
            
        }
        
        protected void GetButton_Click(object sender, EventArgs e)
        {
            PaymentDetailPagerTop.PageIndex = 0;
        }
        private void BindPaymentStatus(string paymentStatus, ListControl hostPaymentStatusDropDown)
        {
            // Remove other status (that not required)
            var hostPaymentStatusFiltered = PaymentStatus.GetNameValuePairs();

            if (paymentStatus == HostPaymentStatus.Pending.ToString())
            {
                hostPaymentStatusFiltered = hostPaymentStatusFiltered.Where(hostPaymentStatus => hostPaymentStatus.FirstValue == (int)HostPaymentStatus.Paid).ToList();
            }
            else if (paymentStatus == HostPaymentStatus.Paid.ToString())
            {
                hostPaymentStatusFiltered = hostPaymentStatusFiltered.Where(hostPaymentStatus => hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Paid && hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Receivable).ToList();
            }
            else if (paymentStatus == HostPaymentStatus.Receivable.ToString())
            {
                hostPaymentStatusFiltered = hostPaymentStatusFiltered.Where(hostPaymentStatus => hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Receivable && hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Paid && hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Pending).ToList();
            }
            else if (paymentStatus == HostPaymentStatus.Refunded.ToString())
            {
                hostPaymentStatusFiltered = hostPaymentStatusFiltered.Where(hostPaymentStatus => hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Receivable && hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Refunded && hostPaymentStatus.FirstValue != (int)HostPaymentStatus.Pending).ToList();
            }
            hostPaymentStatusDropDown.Items.Clear();
            hostPaymentStatusDropDown.DataSource = hostPaymentStatusFiltered;
            hostPaymentStatusDropDown.DataTextField = "SecondValue";
            hostPaymentStatusDropDown.DataValueField = "FirstValue";
            hostPaymentStatusDropDown.DataBind();

            var listItem = hostPaymentStatusDropDown.Items.FindByText(paymentStatus);
            if (listItem != null)
                hostPaymentStatusDropDown.Items.Remove(listItem);//FindByText(paymentStatus).Selected = true);

        }

        private void BindDropDowns()
        {
            // Payment staus (Search)
            PaymentStatusSearch.Items.Clear();
            PaymentStatusSearch.Items.Add(new ListItem("--All--", "0"));
            PaymentStatusSearch.DataSource = PaymentStatus.GetNameValuePairs();
            PaymentStatusSearch.DataTextField = "SecondValue";
            PaymentStatusSearch.DataValueField = "FirstValue";
            PaymentStatusSearch.DataBind();

            var listItem = PaymentStatusSearch.Items.FindByText(HostPaymentStatus.Pending.ToString());
            if (listItem != null)
                PaymentStatusSearch.Items.FindByText(HostPaymentStatus.Pending.ToString()).Selected = true;

            // Payment Type
            PaymentTypeSearch.Items.Add(new ListItem("--All--", "0"));
            PaymentTypeSearch.Items.Add(new ListItem("Room Rent", "1"));
            PaymentTypeSearch.Items.Add(new ListItem("Deposit", "2"));

            


            // PaymentMode
            _paymentMode.Items.Clear();
            _paymentMode.Items.Add(new ListItem("Select Payment Mode", "0"));
            _paymentMode.Items.Add(new ListItem(HostPaymentType.Check.ToString(), HostPaymentType.Check.ToString()));
            _paymentMode.Items.Add(new ListItem(HostPaymentType.CreditCard.ToString(), HostPaymentType.CreditCard.ToString()));
            
        }

        protected void PaymentDetailsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        var data = e.Row.DataItem as EventHostDepositViewData;

                        if (data != null)
                        {
                            var eventAddress = e.Row.FindControl("eventAddress") as HtmlContainerControl;
                            var deliverToAddress = e.Row.FindControl("deliverToAddress") as HtmlContainerControl;
                            var paymentType = e.Row.FindControl("paymentType") as HtmlContainerControl;
                            var paymentMode = e.Row.FindControl("paymentMode") as HtmlContainerControl;
                            var paymentStatusDropDown = e.Row.FindControl("paymentStatusDropDown") as DropDownList;
                            var cancellationDate = e.Row.FindControl("cancellationDate") as Literal;
                            var dueDate = e.Row.FindControl("dueDate") as Literal;
                            var eventDateIcon = e.Row.FindControl("_eventDateIcon") as HtmlContainerControl;
                            var lastModifiedDate = e.Row.FindControl("_lastModifiedDate") as HtmlContainerControl;
                            var eventStatus = e.Row.FindControl("_eventStatus") as HtmlContainerControl;
                            var paymentStatus = e.Row.FindControl("_paymentStatus") as HtmlContainerControl;
                            long organizationRoleUserId=0;
                            DateTime? paymentRequested = null;

                            if (dueDate != null && data.DueDate.HasValue)
                            {
                                dueDate.Text = data.DueDate.Value.ToShortDateString();
                            }

                            if (cancellationDate != null && data.IsDeposit && data.DepositFullRefundDueDate !=null)
                            {
                                cancellationDate.Text = data.DepositFullRefundDueDate.Value.ToShortDateString();
                            }
                            if (eventAddress != null)
                            {
                                eventAddress.InnerHtml =
                                    CommonCode.AddressMultiLine(data.EventStreetAddressLine1,
                                                                data.EventStreetAddressLine2,
                                                                data.EventCity,
                                                                data.EventState,
                                                                data.EventZip);
                            }
                            if (deliverToAddress != null)
                            {
                                deliverToAddress.InnerHtml =
                                    CommonCode.AddressMultiLine(data.StreetAddressLine1,
                                                                data.StreetAddressLine2,
                                                                data.City,
                                                                data.State,
                                                                data.Zip);
                            }

                            if (paymentStatusDropDown != null)
                            {
                                var status = data.Status.ToString();
                                BindPaymentStatus(status, paymentStatusDropDown);
                            }
                            
                            var amountSpan = e.Row.FindControl("_amount") as HtmlContainerControl;

                            string paymentToolTip = string.Empty;
                            decimal amount = 0m;

                            if (eventStatus !=null && data.EventStatus != EventStatus.Active)
                            {
                                eventStatus.InnerHtml = "<strong>Event Status:</strong><br />" + data.EventStatus.ToString();
                            }
                            if (amountSpan != null)
                            {
                                if (!data.IsDeposit)
                                {
                                    bool isAppliedToCost = false;

                                    try
                                    {
                                        var hostDeposit = _hostDeositRepository.GetById(data.EventId);
                                        if (hostDeposit != null && hostDeposit.DepositApplicablityMode == DepositType.AppliedToCost)
                                        {
                                            isAppliedToCost = true;
                                            amount = hostDeposit.IsActive ? data.Amount - hostDeposit.Amount : data.Amount - 0;
                                            organizationRoleUserId = hostDeposit.PaymentRecordedBy != null
                                                                         ? hostDeposit.PaymentRecordedBy.Id
                                                                         : 0;
                                            paymentRequested = hostDeposit.CreatedDate;
                                        }
                                        else
                                            amount = data.Amount;

                                        if (isAppliedToCost)
                                        {
                                            paymentToolTip =
                                                "<a class=\"jtip\" href=\"#\" title=\"Details|Room Rent = $" +
                                                data.Amount.ToString("#.##");
                                            if (hostDeposit.IsActive) paymentToolTip += "<br /> Deposit = $" +
                                                                  hostDeposit.Amount.ToString("#.##");
                                            
                                            paymentToolTip += "<br /> Amount Payable = $" + amount.ToString("#.##") +
                                                "\">"+  amount.ToString("#.##") + "</a>";
                                            amountSpan.InnerHtml = paymentToolTip;
                                        }
                                        else
                                        {
                                            paymentToolTip =
                                                "<a class=\"jtip\" href=\"#\" title=\"Details|Room Rent = $" +
                                                data.Amount.ToString("#.##");
                                            if (hostDeposit.IsActive)
                                                paymentToolTip += "<br /> Deposit = Refundable";
                                            paymentToolTip += "<br />Amount Payable = $" + amount.ToString("#.##") + "\">" + amount.ToString("#.##") + "</a>";

                                            amountSpan.InnerHtml = paymentToolTip;
                                        }
                                    }
                                    catch
                                    {
                                        amount = data.Amount;
                                        paymentToolTip =
                                            "<a class=\"jtip\" href=\"#\" title=\"Details|Room Rent = $" +
                                            data.Amount.ToString("#.##") +
                                            "<br /> Deposit = Refundable <br /> Amount Payable = $" +
                                            amount.ToString("#.##") + "\">" + amount.ToString("#.##") + "</a>";
                                        amountSpan.InnerHtml = paymentToolTip;
                                    }
                                }
                                else
                                {
                                    paymentToolTip =
                                        "<a class=\"jtip\" href=\"#\" title=\"Details|This is deposit amount $" +
                                        data.Amount.ToString("#0.00") + "\">" + data.Amount.ToString("#0.00") + "</a>";
                                    amountSpan.InnerHtml = paymentToolTip;
                                    var hostPayment = _hostPaymentRepository.GetById(data.EventId);
                                    organizationRoleUserId = hostPayment.PaymentRecordedBy != null
                                                                         ? hostPayment.PaymentRecordedBy.Id
                                                                         : 0;
                                    paymentRequested = hostPayment.CreatedDate;
                                }
                            }
                            // Payment Recorded By
                            if (organizationRoleUserId > 0 && data.EventStatus != EventStatus.Active)
                            {
                                var organizationRoleUser =
                                _organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);
                                if (organizationRoleUser != null)
                                {
                                    ICustomerRepository customerRepository = new CustomerRepository();
                                    var userDetails = customerRepository.GetCustomerByUserId(organizationRoleUser.UserId);

                                    if (userDetails!=null && paymentStatus!=null)
                                    {
                                        paymentStatus.InnerHtml = "Payment Recorded By:" + userDetails.Name.FullName;
                                        if (paymentRequested != null)
                                            paymentStatus.InnerHtml = paymentStatus.InnerHtml + "<br />" + "Payment Date:" + paymentRequested.Value.ToShortDateString();
                                    }
                                }
                            }
                            

                            if (paymentType != null)
                            {
                                paymentType.InnerHtml = data.IsDeposit ? "Deposit" : "Room Rent";
                            }
                            if (paymentMode != null)
                            {
                                var payment = data.PaymentMode.ToString();
                                paymentMode.InnerHtml =
                                    Enum.Parse(typeof(HostPaymentType), payment).ToString();
                                if (paymentMode.InnerText == HostPaymentType.Both.ToString())
                                {
                                    paymentMode.InnerText = "Check/CC";
                                }
                            }

                            var eventWizardAnchor = e.Row.FindControl("EventWizardAnchor") as HtmlAnchor;
                            if (eventWizardAnchor != null)
                            {
                                eventWizardAnchor.HRef = "/App/Common/CreateEventWizard/Step1.aspx?EventID=" + data.EventId;
                            }

                            //var updateButton = e.Row.FindControl("UpdateButton") as Button;
                            //if (data.Status == HostPaymentStatus.Paid || data.Status == HostPaymentStatus.Refunded)
                            ////if (data.Status == HostPaymentStatus.Refunded)
                            ////{
                            ////    e.Row.Enabled = false;
                            ////    updateButton.Enabled = false;
                            ////}

                            // Past,Cussrent,Future event date icon
                            if (eventDateIcon != null)
                            {
                                if (data.EventDate.ToString("MM/dd/yyyy").Equals(DateTime.Now.ToString("MM/dd/yyyy")))
                                {
                                    eventDateIcon.InnerHtml =
                                        "<img src=\"/App/Images/icon-todays-event.gif\" title=\"Today Event\" alt=\"Today Event\"/>";

                                }
                                else if (data.EventDate > DateTime.Now)
                                {
                                    eventDateIcon.InnerHtml =
                                       "<img src=\"/App/Images/icon-future-event.gif\" title=\"Future Event\" alt=\"Future Event\"/>";
                                }
                                else if (data.EventDate < DateTime.Now)
                                {
                                    eventDateIcon.InnerHtml =
                                       "<img src=\"/App/Images/icon-past-event.gif\" title=\"Past Event\" alt=\"Past Event\"/>";
                                }
                            }
                            // Last Modified Date
                            if (data.HostPaymentTransactions != null && data.HostPaymentTransactions.Count > 0)
                            {
                                lastModifiedDate.InnerHtml =
                                    data.HostPaymentTransactions.LastOrDefault().TransactionDate.ToString("MM/dd/yyyy");
                            }
                            var _spanPrintButton=e.Row.FindControl("_spanPrintButton") as HtmlContainerControl;
                            if (data.Status == HostPaymentStatus.Pending)
                                _spanPrintButton.Style.Add(HtmlTextWriterStyle.Display, "none");
                            else
                                _spanPrintButton.Style.Add(HtmlTextWriterStyle.Display, "block");
                        }
                    }
                    break;
            }
        }

       private void BindDataForFiltes()
        {
            var pageIndex = PaymentDetailPagerTop.PageIndex;
            var pageSize = PaymentDetailPagerTop.PageSize;

            DateTime? paymentDueDateFromPassed = null;
            DateTime? paymentDueDateToPassed = null;

            long? eventIdPassed = null;
            HostPaymentStatus? hostPaymentStatus = null;
            bool? isDeposit = null;

            // from due date
            if (!string.IsNullOrEmpty(PaymentDueDateFrom.Text.Trim()))
            {
                DateTime paymentDueDateFrom;
                if (!DateTime.TryParse(PaymentDueDateFrom.Text.Trim(), out paymentDueDateFrom))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid start due date.");
                    return;
                }
                else paymentDueDateFromPassed = paymentDueDateFrom;
            }
            // to due date
            if (!string.IsNullOrEmpty(PaymentDueDateTo.Text.Trim()))
            {
                DateTime paymentDueDateTo;
                if (!DateTime.TryParse(PaymentDueDateTo.Text.Trim(), out paymentDueDateTo))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid end due date.");
                    return;
                }
                paymentDueDateToPassed = paymentDueDateTo;
            }
            // event id
            if (!string.IsNullOrEmpty(EventId.Text.Trim()))
            {
                long eventId;
                if (!long.TryParse(EventId.Text.Trim(), out eventId))
                {
                    MessageBox.ShowErrorMessage("Please enter a valid event id.");
                    return;
                }
                eventIdPassed = eventId;
            }
            // host payments.
            if (!string.IsNullOrEmpty(PaymentStatusSearch.SelectedValue))
            {
                if (Convert.ToString(PaymentStatusSearch.SelectedValue) != "0")
                {
                    hostPaymentStatus =
                        (HostPaymentStatus)Enum.Parse(typeof(HostPaymentStatus), PaymentStatusSearch.SelectedValue);
                }
            }
            // IsDeposit.
            if (!string.IsNullOrEmpty(PaymentTypeSearch.SelectedItem.Text))
            {
                if (Convert.ToString(PaymentTypeSearch.SelectedItem.Text) != "0")
                {
                    if (PaymentTypeSearch.SelectedItem.Text.Trim() == "Room Rent")
                    {
                        isDeposit = false;
                    }
                    if (PaymentTypeSearch.SelectedItem.Text.Trim() == "Deposit")
                    {
                        isDeposit = true;
                    }
                }
            }
            long totalRecord = 0;
            List<EventHostDepositViewData> eventHostDepositViewData
                = _hostDepositService.GetHostDepositsByFilters(
                    eventIdPassed, paymentDueDateFromPassed, paymentDueDateToPassed, hostPaymentStatus, isDeposit, pageIndex, pageSize, out totalRecord);

            // Bind grids.
            if (!eventHostDepositViewData.IsEmpty())
            {
                PaymentDetailPagerTop.ItemCount = (int)totalRecord;
                PaymentDetailsGrid.DataSource = eventHostDepositViewData;
                PaymentDetailsGrid.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                PaymentDetailPagerTop.ItemCount = 0;
                PaymentDetailsGrid.DataSource = null;
                PaymentDetailsGrid.DataBind();
                dvNoQueueItemFound.Style.Add(HtmlTextWriterStyle.Display, "block");
            }

        } 

        protected void resetSearch_Click(object sender, EventArgs e)
        {
            // clear all control
            EventId.Text = null;
            PaymentDueDateFrom.Text = null;
            PaymentDueDateTo.Text = null;
            PaymentStatusSearch.SelectedIndex = 0;
            PaymentTypeSearch.SelectedIndex = 0;
            PaymentDetailPagerTop.PageIndex = 0;
            BindDataForFiltes();
        }

        protected void searchRecord_Click(object sender, EventArgs e)
        {
            PaymentDetailPagerTop.PageIndex = 0;
            BindDataForFiltes();
        }

        protected void PaymentDetailPagerTop_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            BindDataForFiltes();
        }
    }
}