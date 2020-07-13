using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Lib;
using Falcon.App.UI.HtmlHelpers;
using Falcon.DataAccess.Master;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Other;

namespace Falcon.App.UI.App.Common
{
    public partial class EventDetails : System.Web.UI.Page
    {
        public long Eventid { set { eventid = value; } get { return eventid; } }
        long eventid = 0;
        public long UserID { set; get; }
        public long Shell { set; get; }
        public long Role { set; get; }
        public string CancellationReasonToolTipHeader { set; get; }
        private List<OrderedPair<long, string>> OrderItemTestNames { get; set; }
        public string TestFormationString { set { _testNameCountString.InnerHtml = value; } }

        # region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Event Details";
            CancellationReasonToolTipHeader = "Event Notes";
            var obj = (Franchisor_FranchisorMaster)Master;
            obj.setpoductitle("Event Details", "Event");
            obj.SetBreadCrumbRoot = "<a href='#'>Event</a>";
            obj.hideucsearch();

            var currentUserSession = IoC.Resolve<ISessionContext>().UserSession;

            if (!Page.IsPostBack)
            {
                ViewState["UrlRefferer"] = Request.UrlReferrer != null ? Request.UrlReferrer.PathAndQuery : string.Empty;

                if ((!string.IsNullOrEmpty(Request["EventID"])) && (long.TryParse(Request["EventID"], out eventid)))
                {
                    ////eventid = Convert.ToInt32(Request["EventID"]);
                    hidEventID.Value = eventid.ToString();
                    hidUserId.Value = currentUserSession.UserId.ToString();
                    hidRole.Value = currentUserSession.CurrentOrganizationRole.RoleAlias;
                }
                var masterDal = new MasterDAL();
                EEvent objevent = null;
                string strPackageDetails;
                objevent = masterDal.GetEventSummaryDetailsWithPackage(eventid, 1, out strPackageDetails);

                var eventMetricsService = IoC.Resolve<IEventMetricsService>();
                var eventMetricsViewData = eventMetricsService.GetEventMetricsViewData(eventid, currentUserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                if (objevent != null && eventMetricsViewData != null)
                {
                    LoadEventSummary(objevent, eventMetricsViewData);
                }
                else
                {
                    // wrong event id provided.
                    _divNoEventsFound.Style.Add(HtmlTextWriterStyle.Display, "block");
                    _divEventDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                    return;
                }
                // hide average revenue per client details in case of salesrep
                if (currentUserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                {
                    _spnAverage.Style.Add(HtmlTextWriterStyle.Display, "none");
                    _spnUnPaidExcludeNoShow.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                else
                {
                    _spnAverage.Style.Add(HtmlTextWriterStyle.Display, "block");
                    _spnUnPaidExcludeNoShow.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                //if (strPackageDetails.LastIndexOf("</b>") + 4 < strPackageDetails.Length)
                //{
                //    strPackageDetails = strPackageDetails.Substring(0, strPackageDetails.LastIndexOf("</b>") + 4);
                //}
                //sppackagecountstring.InnerHtml = strPackageDetails;
                // Set TestNames Counts
                GetEventTestDetails();

                if ((Request.QueryString["Tab"] != null) && (!string.IsNullOrEmpty(Request.QueryString["Tab"])))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscodegetactivertab", "SetImage('" + Request.QueryString["Tab"] + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscodegetactivertab", "SetImage('Customers');", true);
                }

                if (ViewState["UrlRefferer"] != null)
                {
                    if (ViewState["UrlRefferer"].ToString().IndexOf("CreateEventWizard") >= 0)
                    {
                        aBack.InnerText = "Manage Events";
                        if (currentUserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                            aBack.HRef = "/Scheduling/Event/Index?showUpcoming=true";
                        else if (currentUserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin))
                            aBack.HRef = "/Scheduling/Event/Index?showUpcoming=true";
                        else if (currentUserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin))
                            aBack.HRef = "/Scheduling/Event/Index?showUpcoming=true";
                    }
                    else
                    {
                        aBack.InnerText = "Back";
                        aBack.HRef = ViewState["UrlRefferer"].ToString();
                    }
                }
            }
            else
            {
                if (Request.Form["__EVENTTARGET"] != null)
                {
                    if (Request.Form["__EVENTTARGET"].Equals("DeleteAppointment"))
                        lnkDeleteSlot_Click(Convert.ToInt32(Request.Form["__EVENTARGUMENT"]));
                }
            }
        }

        private void lnkDeleteSlot_Click(int appointmentid)
        {

            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            var eventAppointment = new EEventAppointment
            {
                AppointmentID = appointmentid,
                EventID = Convert.ToInt32(hidEventID.Value),
                ScheduleByID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationRoleUserId)
            };



            var masterDal = new MasterDAL();

            long updateStatus = masterDal.UpdateAppointmentSlot(eventAppointment, Convert.ToInt16(EOperationMode.Delete));

            if (updateStatus == -1) return;
            Page.ClientScript.RegisterStartupScript(typeof(string), "js_setslotdropdown", "GetTable('Customers');", true);
        }

        private void GetEventTestDetails()
        {
            IOrderRepository orderRepository = new OrderRepository();

            var orders = orderRepository.GetAllOrdersForEvent(Eventid);
            var activeOrderDetails = orders.SelectMany(o => o.OrderDetails.Where(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)
                && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted));

            if (!activeOrderDetails.IsEmpty())
            {
                var orderIds = activeOrderDetails.Select(od => od.OrderId).ToList();

                if (!orderIds.IsEmpty())
                {
                    var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                    var orderIdeventPackageIdPairs = eventPackageRepository.GetEventPackageIdsForOrder(orderIds);
                    var eventPackages = eventPackageRepository.GetByIds(orderIdeventPackageIdPairs.Select(op => op.SecondValue).Distinct().ToArray());

                    var testRepository = IoC.Resolve<IEventTestRepository>();
                    var pairs = testRepository.GetEventTestIdForOrders(orderIds).ToArray();
                    var eventTests = testRepository.GetbyIds(pairs.Select(p => p.SecondValue).ToArray());

                    eventTests = (from p in pairs
                                 join et in eventTests on p.SecondValue equals et.Id
                                 select et).ToArray();

                    if (orderIdeventPackageIdPairs != null && orderIdeventPackageIdPairs.Any())
                    {
                        foreach (var pair in orderIdeventPackageIdPairs)
                        {
                            var eventPackage = eventPackages.SingleOrDefault(ep => ep.Id == pair.SecondValue);
                            if (eventPackage != null)
                                eventTests = eventTests.Concat(eventPackage.Tests);
                        }
                    }

                    OrderItemTestNames = (from et in eventTests select new OrderedPair<long, string>(et.TestId, et.Test.Name)).ToList();

                    var testItemGroup =
                        OrderItemTestNames.GroupBy(oitn => oitn.SecondValue).Select(
                            opgroup => new OrderedPair<string, int>(opgroup.Key, opgroup.Count()));

                    string testNameString = String.Join("&nbsp;|&nbsp;",
                                testItemGroup.Select(g => g.FirstValue + ": <b>(" + g.SecondValue + ")</b> ").ToArray());

                    TestFormationString = testNameString;
                }
            }
        }

        #endregion

        #region Methods
        public void LoadEventSummary(EEvent objevent, EventMetricsViewData eventMetricsViewData)
        {

            if (objevent == null)
                return;

            // format phone no.
            var objCommonCode = new CommonCode();

            hidEventName.Value = objevent.Name;
            hidEventDate.Value = objevent.EventDate;

            ViewState["EventDate"] = objevent.EventDate;
            ViewState["EventName"] = objevent.Name;

            speventdate.InnerText = Convert.ToDateTime(objevent.EventDate).ToShortDateString();
            speventloc.InnerText = CommonCode.AddressSingleLine(objevent.Host.Address.Address1, objevent.Host.Address.Address2, objevent.Host.Address.City, objevent.Host.Address.State, objevent.Host.Address.Zip);
            sphostphone.InnerText = objCommonCode.FormatPhoneNumberGet(objevent.Host.PhoneOffice);

            var eventStatus = (EventStatus)objevent.EventStatus;
            eventStatusSpan.InnerText = eventStatus.ToString();
            if (eventStatus != EventStatus.Active)
            {
                eventNotesSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                if (objevent.EventCancellationReasonId.HasValue)
                {
                    var reasons = DropDownHelper.GetLookupSelectListItems((long) EventCancellationReason.DateChange);
                    CancellationReasonToolTipHeader  = "Reason: " + HttpUtility.HtmlEncode(reasons.Single(x => x.Value == objevent.EventCancellationReasonId.ToString()).Text);
                    notesSpan.InnerText = "Notes: " + objevent.EventNotes;
                }
                else
                {
                    notesSpan.InnerText = objevent.EventNotes;
                }
            }
            else
                eventNotesSpan.Style.Add(HtmlTextWriterStyle.Display, "none");

            ViewState["HostName"] = objevent.Host.Name;
            ViewState["HostAddress"] = objevent.Host.Address.Address1;
            ViewState["HostCityStateZip"] = objevent.Host.Address.City + " " + objevent.Host.Address.State + " " + objevent.Host.Address.Zip;

            //spEIPdeposit.InnerHtml = decimal.Round(eventMetricsViewData.CashRevenue + eventMetricsViewData.CheckRevenue, 2).ToString();

            speventid.InnerText = objevent.EventID.ToString();

            spcashpayment.InnerText = decimal.Round(eventMetricsViewData.CashRevenue, 2).ToString();
            spcardpayment.InnerText = decimal.Round(eventMetricsViewData.ChargeCardRevenue, 2).ToString();
            spchequepayment.InnerText = decimal.Round(eventMetricsViewData.CheckRevenue, 2).ToString();
            spBPeCheckPayment.InnerText = decimal.Round(eventMetricsViewData.ECheckRevenue, 2).ToString();

            decimal totalRevenue = eventMetricsViewData.ChargeCardRevenue + eventMetricsViewData.CheckRevenue +
                           eventMetricsViewData.CashRevenue + eventMetricsViewData.ECheckRevenue +
                           eventMetricsViewData.GiftCertificateRevenue +
                           eventMetricsViewData.UnPaidExcluedeNoShowRevenue;
            //sptotalpayment.InnerHtml = decimal.Round(totalRevenue, 2).ToString();
            sptotalpayment.InnerText = decimal.Round(eventMetricsViewData.TotalRevenue, 2).ToString();

            ancregistered.Text = eventMetricsViewData.RegisteredCustomersCount.ToString();
            ancnoshow.Text = eventMetricsViewData.NoShowCustomersCount.ToString();
            ancpaid.Text = eventMetricsViewData.PaidCustomersCount.ToString();
            ancunpaid.Text = eventMetricsViewData.UnPaidCount.ToString();
            ancactual.Text = eventMetricsViewData.AttendedCustomersCount.ToString();
            ancuncancel.Text = eventMetricsViewData.CancelledCustomersCount.ToString();
            leftWithoutScreening.Text = eventMetricsViewData.LeftWithoutScreeningCustomersCount.ToString();

            var eventAppointmentChangeRepository = IoC.Resolve<IEventAppointmentChangeLogRepository>();
            var eventCustomerIds = eventAppointmentChangeRepository.GetEventCustomerIdByEventId(Eventid);
            ancrescheduled.Text = eventCustomerIds.Count().ToString();

            anccardpaymentcount.Text = eventMetricsViewData.ChargeCardCount.ToString();
            anccashpaymentcount.Text = eventMetricsViewData.CashCount.ToString();
            ancchequepaymentcount.Text = eventMetricsViewData.CheckCount.ToString();
            lnkBPeCheckPayment.Text = eventMetricsViewData.ECheckCount.ToString();

            // Metrics
            spPhoneTotalAmount.InnerText = eventMetricsViewData.PhonePayments.ToString("0.00");
            lnkPhoneTotal.Text = eventMetricsViewData.PhonePaymentCount.ToString();

            spnINetAmount.InnerText = eventMetricsViewData.InternetPayments.ToString("0.00");
            lnkINetTotal.Text = eventMetricsViewData.InternetPaymentCount.ToString();

            spnOnsiteAmount.InnerText = eventMetricsViewData.OnsitePayments.ToString("0.00");
            lnkOnSiteTotal.Text = eventMetricsViewData.OnsitePaymentCount.ToString();

            spnUpgradeAmount.InnerText = eventMetricsViewData.UpGradePayments.ToString("0.00");
            lnkUpgradeTotal.Text = eventMetricsViewData.UpGradePaymentCount.ToString();

            // BEGIN added upgrade/downgrade story(#7548)

            spnDowngradesAmount.InnerText = eventMetricsViewData.DownGradePayments < 0 ? (eventMetricsViewData.DownGradePayments * -1).ToString("0.00") : eventMetricsViewData.DownGradePayments.ToString("0.00");

            lnkDowngradeTotal.Text = eventMetricsViewData.DownGradePaymentCount.ToString();

            int totalCustomer = (eventMetricsViewData.PaidCustomersCount + eventMetricsViewData.UnPaidCount) - eventMetricsViewData.NoShowCustomersCount;


            _spnAverageRevenueCount.InnerText = totalCustomer > 0
                                        ? (totalRevenue / totalCustomer).ToString("0.00")
                                        : "0.00";
            _lnkAverageCustomers.Text = totalCustomer > 0 ? totalCustomer.ToString() : "0";

            _spnUnpaidTotal.InnerText = eventMetricsViewData.UnPaidExcluedeNoShowRevenue.ToString("0.00");
            _lnkUnpaidCount.Text = eventMetricsViewData.UnPaidExcluedeNoShowCount.ToString();
            // END added upgrade/downgrade story(#7548)

            //TODO: Need to filter customers paid by GC
            // added giftCertificate
            _spnGcPaymentTotal.InnerText = eventMetricsViewData.GiftCertificateRevenue.ToString("0.00");
            _lnkGcPaymentCount.Text = eventMetricsViewData.GiftCertificateCount.ToString();

            // show HSC name and event booked date.
            if (objevent.FranchiseeFranchiseeUser != null)
            {
                string salesRepDetails = string.Empty;
                //salesRepDetails = "<a herf=\"#\" class=\"jtip\" 
                salesRepDetails = "Event Booking Details|<b>Event Booked By: </b>";
                salesRepDetails = salesRepDetails + objevent.EventBookedBy;
                salesRepDetails = salesRepDetails + "<br><b>Event Booked On: </b>" + Convert.ToDateTime(objevent.DateCreated).ToString("MM/dd/yyyy");

                hrfBookingDetails.Title = salesRepDetails;
            }
            // Display Host Payment Details
            DispHostPaymentDetails(objevent.EventID);

            string dispeventnotes = "";
            if (objevent.EventNotes.Length < 90) dispeventnotes = objevent.EventNotes;
            else dispeventnotes = objevent.EventNotes.Substring(0, 90) + "...";

            sphostname.InnerText = objevent.Host.Name;

            if (!string.IsNullOrEmpty(objevent.Type) && objevent.Type != "0")
            {
                if (!string.IsNullOrEmpty(Enum.GetName(typeof(RegistrationMode), Convert.ToInt32(objevent.Type))))
                {
                    if (Enum.Parse(typeof(RegistrationMode), objevent.Type).ToString() == RegistrationMode.Public.ToString())
                    {
                        _eventType.InnerHtml = "<img src='/App/Images/public-icon.gif' title='Public Event' />";
                    }
                    else if (Enum.Parse(typeof(RegistrationMode), objevent.Type).ToString() == RegistrationMode.Private.ToString())
                    {
                        _eventType.InnerHtml = "<img src='/App/Images/private-icon.gif' title='Private Event' style='padding:0px 5px 0px 0px;' />";
                    }
                }
            }

            string googleMapLink = CommonCode.GetGoogleMapAddress(objevent.Host.Address.Address1, objevent.Host.Address.City, objevent.Host.Address.State, objevent.Host.Address.Zip, objevent.Host.Address.Latitude + "," + objevent.Host.Address.Longitude, objevent.Host.Address.UseLatLogForMapping);

            agmap.HRef = googleMapLink; //"http://maps.google.com/maps?f=q&hl=en&geocode=&q=" + objevent.Host.Address.Address1 + "," + objevent.Host.Address.City + "," + objevent.Host.Address.State + "," + objevent.Host.Address.Zip + "&ie=UTF8&z=16";

            // Set Google Address Verification Status
            if (!string.IsNullOrEmpty(objevent.Host.Address.GoogleAddressVerifiedBy))
            {
                _addressVerifiedStatus.InnerHtml = "<a href=\"#\" class=\"jtip\" title=" + "'Google Map Address Verification|Address Verified By " + HttpUtility.HtmlEncode(objevent.Host.Address.GoogleAddressVerifiedBy) + "'" + "><img src=\"/App/Images/info-icon.gif\" alt=\"Info\" title=\"Info\"/></a>";
            }
            else
            {
                _addressVerifiedStatus.InnerHtml = CommonCode.GetGoogleAddressNotVerifiedJtipHostDetails();
            }

            string poddetailstring = "N/A";

            foreach (EEventPod objeventpod in objevent.EventPod)
            {
                if (poddetailstring == "N/A")
                {
                    poddetailstring = "";
                }

                string strpodteam = "";
                string strpoddescription = "";
                string vandescription = "";

                strpoddescription = "<p class='prow'>Processing Capacity of " + HttpUtility.HtmlEncode(objeventpod.Pod.PodProcessingCapacity) + " </p>";
                vandescription = "<p class='prow'> Vehicle: " + HttpUtility.HtmlEncode(objeventpod.Pod.Van.Name) + "," + HttpUtility.HtmlEncode(objeventpod.Pod.Van.Make) + " (" + HttpUtility.HtmlEncode(objeventpod.Pod.Van.VIN) + ") </p>";

                foreach (EFranchiseeFranchiseeUser objfranchiseefruser in objeventpod.Pod.TeamIDList)
                {
                    strpodteam += "&bull; &nbsp;" + HttpUtility.HtmlEncode(objfranchiseefruser.FranchiseeUser.User.FirstName) + " " + HttpUtility.HtmlEncode(objfranchiseefruser.FranchiseeUser.User.MiddleName) + " " + HttpUtility.HtmlEncode(objfranchiseefruser.FranchiseeUser.User.LastName) + "(" + HttpUtility.HtmlEncode(objfranchiseefruser.RoleType) + ")(" + HttpUtility.HtmlEncode(objfranchiseefruser.FranchiseeFranchiseeUserID) + ")<br />";
                }

                //currentpod = "<div class='maindiv_roundmbox_ecl'><div class='innerdiv_roundmbox'><div class='lefttop_roundmbox'><img src='/App/Images/specer.gif' width='254' height='15' /></div><div class='midinner_roundmbox'>";
                string currentpod = "<div class='maindiv_roundmbox_ecl'>" + strpoddescription;
                currentpod += vandescription;
                currentpod += "<p class='prow'><u>Team Detail</u></p>";
                currentpod += "<p class='prow'>" + strpodteam + "</p></div>";

                poddetailstring = poddetailstring + HttpUtility.HtmlEncode(objeventpod.Pod.Name) + "<a href='javascript:void(0)' class='jtipLocal' title=\"Pod Details|" + currentpod + "\"> (More Info) </a>";
            }
            sppoddetail.InnerHtml = poddetailstring;

            ancopenpopupaddslot.HRef = "/App/Common/AddSlot.aspx?EventDate=" + objevent.EventDate + "&EventId=" + hidEventID.Value + "&keepThis=true&TB_iframe=true&width=295&height=140&modal=true";
        }
       
        private void DispHostPaymentDetails(long eventId)
        {
            string paymentDetails = "Payment Details|<div class=\"wrappd\">";
            IHostPaymentRepository hostPaymentRepository = new HostPaymentRepository();
            IHostDeositRepository hostDepositRepository = new HostDepositRepository();
            IHostRepository hostRepository = new HostRepository();
            // Room Rent
            try
            {
                var hostPaymentDetails = hostPaymentRepository.GetById(eventId);
                if (hostPaymentDetails != null && hostPaymentDetails.IsActive)
                {
                    if (hostPaymentDetails.HostPaymentTransactions != null && hostPaymentDetails.HostPaymentTransactions.Count > 0)
                    {
                        // Payment Heading 
                        paymentDetails = paymentDetails + "<div class=\"subhead\">Room Rent</div>";
                        // main sub Div
                        paymentDetails = paymentDetails + "<div class=\"inrcontnr\">";
                        string paymentPaid = string.Empty;
                        string paymentRefund = string.Empty;

                        foreach (var hostPaymentTransactions in hostPaymentDetails.HostPaymentTransactions)
                        {
                            if (hostPaymentTransactions.TransactionType == HostPaymentStatus.Paid)
                            {
                                // Payment Amount
                                paymentPaid = paymentPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Amount:</span>";
                                paymentPaid = paymentPaid + "<span class=\"titletextnowidth_default\">$" + hostPaymentTransactions.Amount.ToString("#.##") + "</span></div>";

                                // Payment Method
                                paymentPaid = paymentPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Method:</span>";
                                paymentPaid = paymentPaid + "<span class=\"titletextnowidth_default\">" + hostPaymentTransactions.TransactionMethod + "</span></div>";

                                // Payment Date
                                paymentPaid = paymentPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Date:</span>";
                                paymentPaid = paymentPaid + "<span class=\"titletextnowidth_default\">" + hostPaymentTransactions.TransactionDate.ToString("MM/dd/yyyy") + "</span></div>";

                                // TaxId Number
                                var taxIdNumber = hostRepository.GetTaxIdNumber(hostPaymentDetails.HostId);
                                paymentPaid = paymentPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">TaxId Number:</span>";
                                paymentPaid = paymentPaid + "<span class=\"titletextnowidth_default\">" + taxIdNumber + "</span></div>";

                                // Payment Date
                                paymentPaid = paymentPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Notes:</span>";
                                paymentPaid = paymentPaid + "<span class=\"titletextnowidth_default\">" + hostPaymentTransactions.Notes + "</span></div>";


                            }
                            else if (hostPaymentTransactions.TransactionType == HostPaymentStatus.Refunded)
                            {
                                // Refund Amount
                                paymentRefund = paymentRefund +
                                                 "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Refund Amount:</span>";
                                paymentRefund = paymentRefund + "<span class=\"titletextnowidth_default\">$" +
                                                 hostPaymentTransactions.Amount.ToString("#.##") + "</span></div>";
                                // Refund Method
                                paymentRefund = paymentRefund +
                                                 "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Refund Method:</span>";
                                paymentRefund = paymentRefund + "<span class=\"titletextnowidth_default\">" +
                                                 hostPaymentTransactions.TransactionMethod + "</span></div>";

                                // Refund Date
                                paymentRefund = paymentRefund +
                                                 "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Refund Date:</span>";
                                paymentRefund = paymentRefund + "<span class=\"titletextnowidth_default\">" +
                                                 hostPaymentTransactions.TransactionDate.ToString("MM/dd/yyyy") +
                                                 "</span></div>";

                                // Refund Notes
                                paymentRefund = paymentRefund +
                                                 "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Notes:</span>";
                                paymentRefund = paymentRefund + "<span class=\"titletextnowidth_default\">" +
                                                 hostPaymentTransactions.Notes + "</span></div>";

                            }
                        }
                        paymentDetails = paymentDetails + paymentPaid;
                        if (!string.IsNullOrEmpty(paymentRefund))
                            paymentDetails = paymentDetails + "<div class=\"left hr\"></div>";
                        paymentDetails = paymentDetails + paymentRefund;
                        paymentDetails = paymentDetails + "</div>";
                    }
                    else
                    {
                        // Payment Heading 
                        paymentDetails = paymentDetails + "<div class=\"subhead\">Room Rent</div>";
                        // main sub Div
                        paymentDetails = paymentDetails + "<div class=\"inrcontnr\">";
                        // Payment Amount
                        paymentDetails = paymentDetails + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Amount:</span>";
                        paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">$" + hostPaymentDetails.Amount.ToString("#.##") + "</span></div>";
                        // Payment Method
                        if (hostPaymentDetails.PaymentMode == HostPaymentType.Both)
                        {
                            paymentDetails = paymentDetails +
                                             "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Method:</span>";
                            paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">" +
                                             HostPaymentType.Check + "/" + HostPaymentType.CreditCard + "</span></div>";
                        }
                        else
                        {
                            paymentDetails = paymentDetails +
                                             "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Method:</span>";
                            paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">" +
                                             hostPaymentDetails.PaymentMode + "</span></div>";
                        }
                        // Payment Method
                        paymentDetails = paymentDetails + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Status:</span>";
                        paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">" + hostPaymentDetails.Status + "</span></div>";
                        paymentDetails = paymentDetails + "</div>";


                    }
                }
                else
                {
                    // Payment Heading 
                    paymentDetails = paymentDetails + "<div class=\"subhead\">No Room Rent Required.</div><div class=\"inrcontnr\">N/A</div>";
                }
            }
            catch (Exception)
            {
                paymentDetails = paymentDetails + "<div class=\"subhead\">No Room Rent Required.</div><div class=\"inrcontnr\">N/A</div>";
            }
            // Deposit Payment
            try
            {
                var hostDepositDetails = hostDepositRepository.GetById(eventId);
                if (hostDepositDetails != null && hostDepositDetails.IsActive)
                {
                    if (hostDepositDetails.HostPaymentTransactions != null && hostDepositDetails.HostPaymentTransactions.Count > 0)
                    {
                        // Payment Heading 
                        paymentDetails = paymentDetails + "<div class=\"subhead\">Deposit</div>";
                        // main sub Div
                        paymentDetails = paymentDetails + "<div class=\"inrcontnr\">";

                        string depositPaid = string.Empty;
                        string depositRefund = string.Empty;

                        foreach (var hostDepositTransactions in hostDepositDetails.HostPaymentTransactions)
                        {
                            if (hostDepositTransactions.TransactionType == HostPaymentStatus.Paid)
                            {
                                // Payment Amount
                                depositPaid = depositPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Amount:</span>";
                                depositPaid = depositPaid + "<span class=\"titletextnowidth_default\">$" + hostDepositTransactions.Amount.ToString("#.##") + "</span></div>";
                                // Payment Method
                                depositPaid = depositPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Method:</span>";
                                depositPaid = depositPaid + "<span class=\"titletextnowidth_default\">" + hostDepositTransactions.TransactionMethod + "</span></div>";

                                // Payment Date
                                depositPaid = depositPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Date:</span>";
                                depositPaid = depositPaid + "<span class=\"titletextnowidth_default\">" + hostDepositTransactions.TransactionDate.ToString("MM/dd/yyyy") + "</span></div>";

                                // TaxId Number
                                var taxIdNumber = hostRepository.GetTaxIdNumber(hostDepositDetails.HostId);
                                depositPaid = depositPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">TaxId Number:</span>";
                                depositPaid = depositPaid + "<span class=\"titletextnowidth_default\">" + taxIdNumber + "</span></div>";

                                // Payment Date
                                depositPaid = depositPaid + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Notes:</span>";
                                depositPaid = depositPaid + "<span class=\"titletextnowidth_default\">" + hostDepositTransactions.Notes + "</span></div>";

                            }
                            else if (hostDepositTransactions.TransactionType == HostPaymentStatus.Refunded)
                            {
                                // Refund Amount
                                depositRefund = depositRefund + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Refund Amount:</span>";
                                depositRefund = depositRefund + "<span class=\"titletextnowidth_default\">$" + hostDepositTransactions.Amount.ToString("#.##") + "</span></div>";
                                // Refund Method
                                depositRefund = depositRefund + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Refund Method:</span>";
                                depositRefund = depositRefund + "<span class=\"titletextnowidth_default\">" + hostDepositTransactions.TransactionMethod + "</span></div>";

                                // Refund Date
                                depositRefund = depositRefund + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Refund Date:</span>";
                                depositRefund = depositRefund + "<span class=\"titletextnowidth_default\">" + hostDepositTransactions.TransactionDate.ToString("MM/dd/yyyy") + "</span></div>";

                                // Refund Notes
                                depositRefund = depositRefund + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Notes:</span>";
                                depositRefund = depositRefund + "<span class=\"titletextnowidth_default\">" + hostDepositTransactions.Notes + "</span></div>";

                            }
                        }
                        paymentDetails = paymentDetails + depositPaid;
                        if (!string.IsNullOrEmpty(depositRefund))
                            paymentDetails = paymentDetails + "<div class=\"left hr\"></div>";
                        paymentDetails = paymentDetails + depositRefund;
                        paymentDetails = paymentDetails + "</div>";
                    }
                    else
                    {
                        // Payment Heading 
                        paymentDetails = paymentDetails + "<div class=\"subhead\">Deposit</div>";
                        // main sub Div
                        paymentDetails = paymentDetails + "<div class=\"inrcontnr\">";
                        // Payment Amount
                        paymentDetails = paymentDetails + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Amount:</span>";
                        paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">$" + hostDepositDetails.Amount.ToString("#.##") + "</span></div>";
                        // Payment Method
                        if (hostDepositDetails.PaymentMode == HostPaymentType.Both)
                        {
                            paymentDetails = paymentDetails +
                                             "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Method:</span>";
                            paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">" +
                                             HostPaymentType.Check + "/" + HostPaymentType.CreditCard + "</span></div>";
                        }
                        else
                        {
                            paymentDetails = paymentDetails +
                                             "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Method:</span>";
                            paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">" +
                                             hostDepositDetails.PaymentMode + "</span></div>";
                        }
                        // Payment Status
                        paymentDetails = paymentDetails + "<div class=\"inrrow\"><span class=\"titletextlarge_default\">Payment Status:</span>";
                        paymentDetails = paymentDetails + "<span class=\"titletextnowidth_default\">" + hostDepositDetails.Status + "</span></div>";
                        paymentDetails = paymentDetails + "</div>";
                    }
                }
                else
                    // Deposit Heading 
                    paymentDetails = paymentDetails + "<div class=\"subhead\">Deposit</div><div class=\"inrcontnr\">No Deposit Required.</div>";
            }
            catch (Exception)
            {
                // Payment Heading 
                paymentDetails = paymentDetails +
                                 "<div class=\"subhead\">Deposit</div><div class=\"inrcontnr\">No Deposit Required.</div>";
            }
            // close Main Div
            paymentDetails = paymentDetails + "</div>";
            paymentDetails = paymentDetails.Replace("'", "&#39");
            _hostPaymentDetails.Title = paymentDetails;
        }


        #endregion
    }
}
