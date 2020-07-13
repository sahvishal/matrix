using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Impl;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Deprecated.Utility;
using EEventCustomer = Falcon.Entity.Other.EEventCustomer;
using Falcon.App.Lib;

public partial class App_Franchisee_Technician_PrintRoasterNew : System.Web.UI.Page
{
    private long EventId
    {
        get
        {
            long eventId = 0;
            if (long.TryParse(Request.QueryString["EventID"], out eventId))
                return eventId;
            return eventId;
        }
    }

    private long Recordcount { get; set; }

    private int Count { get; set; }

    //private bool _firstPage = true;
    //private const int RecordLimit = 20;

    protected bool EnableBarCode { get; set; }

    private DateTime EventDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
        EnableBarCode = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableBarCode));
        if (!IsPostBack)
        {
            if (Request.QueryString["EventID"] != null)
            {
                //long eventId = Convert.ToInt64(Request.QueryString["EventID"]);

                var eventRepository = IoC.Resolve<IEventRepository>();
                var hostRepository = IoC.Resolve<IHostRepository>();

                var eventDetail = eventRepository.GetById(EventId);
                var hostDetail = hostRepository.GetHostForEvent(EventId);


                speventid.InnerText = Request.QueryString["EventID"];
                speventname.InnerText = hostDetail.OrganizationName;
                speventloc.InnerText = hostDetail.Address.ToString();
                speventdate.InnerText = eventDetail.EventDate.ToString("MM/dd/yyyy");
                EventDate = eventDetail.EventDate;

                if (hostDetail.OfficePhoneNumber != null)
                    sphostdetail.InnerText = hostDetail.OfficePhoneNumber.ToString();
                else if (hostDetail.MobilePhoneNumber != null)
                    sphostdetail.InnerText = hostDetail.MobilePhoneNumber.ToString();
                else if (hostDetail.OtherPhoneNumber != null)
                    sphostdetail.InnerText = hostDetail.OtherPhoneNumber.ToString();


                CalCenternotes.InnerHtml = "<u>Event Notes</u> -" + eventDetail.TechnicianNotes;

                var hostFacilityRankingService = IoC.Resolve<IHostFacilityRankingService>();
                var hostFacilityRankingbyHsc = hostFacilityRankingService.GetHostFacilityRankingByHSC(hostDetail.Id);
                if (hostFacilityRankingbyHsc != null)
                {
                    tdPlugPoints.InnerText = hostFacilityRankingbyHsc.NumberOfPlugPoints != null ? hostFacilityRankingbyHsc.NumberOfPlugPoints.Value.ToString() : "";
                    tdRoomSize.InnerText = hostFacilityRankingbyHsc.RoomSize;
                    tdInternetAccess.InnerText = hostFacilityRankingbyHsc.InternetAccess != null ? hostFacilityRankingbyHsc.InternetAccess.Name : "";
                    tdHostRanking.InnerText = hostFacilityRankingbyHsc.Ranking != null ? hostFacilityRankingbyHsc.Ranking.Name : "";
                    tdRoomNeedCleared.InnerText = hostFacilityRankingbyHsc.RoomNeedsCleared != null ? (hostFacilityRankingbyHsc.RoomNeedsCleared.Value ? "Yes" : "No") : "";
                }

                var contactRepository = IoC.Resolve<IContactRepository>();
                var contact = contactRepository.GetContactForHost(hostDetail.Id);
                if (contact != null)
                {
                    tdContactName.InnerText = contact.Name.FullName;

                    if (contact.OfficePhoneNumber != null && !string.IsNullOrEmpty(contact.OfficePhoneNumber.Number))
                    {
                        if (string.IsNullOrEmpty(contact.OfficePhoneExtn))
                            tdContactPhone.InnerText = contact.OfficePhoneNumber.ToString();
                        else
                            tdContactPhone.InnerText = contact.OfficePhoneNumber + "-" + contact.OfficePhoneExtn;
                    }
                    else if (contact.MobilePhoneNumber != null && !string.IsNullOrEmpty(contact.MobilePhoneNumber.Number))
                        tdContactPhone.InnerText = contact.MobilePhoneNumber.ToString();
                    else if (contact.HomePhoneNumber != null && !string.IsNullOrEmpty(contact.HomePhoneNumber.Number))
                        tdContactPhone.InnerText = contact.HomePhoneNumber.ToString();

                    if (contact.Email != null)
                        tdContactEmail.InnerText = contact.Email.ToString();
                }

                var sponsor = string.Empty;
                var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
                var organizationRepository = IoC.Resolve<IOrganizationRepository>();
                var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(EventId);
                if (hospitalPartnerId > 0)
                {
                    sponsor = organizationRepository.GetOrganizationbyId(hospitalPartnerId).Name;
                }
                else if (eventDetail.AccountId.HasValue && eventDetail.AccountId.Value > 0)
                {
                    sponsor = organizationRepository.GetOrganizationbyId(eventDetail.AccountId.Value).Name;
                }

                tdSponsor.InnerText = sponsor;

                if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "Schedule")
                {
                    spGridHeader.InnerText = "Appointment Slots";
                    imgHeader.Src = "../../Images/header-Printroster1-new.gif";
                    LoadGrid(false);
                }
                else
                    LoadGrid(true);
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bolroster"></param>
    private void LoadGrid(bool bolroster)
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        var masterDal = new MasterDAL();
        List<Falcon.Entity.Other.EEventCustomer> eevent;

        if (bolroster)
            eevent = masterDal.GetCustomerListRoaster(speventid.InnerHtml, 0);
        else
            eevent = masterDal.GetCustomerListRoaster(speventid.InnerHtml, 1);

        DataTable tblEvent = new DataTable();

        tblEvent.Columns.Add("Serial");
        tblEvent.Columns.Add("AppointmentTime");
        tblEvent.Columns.Add("CustomerID");
        tblEvent.Columns.Add("CustomerName");
        tblEvent.Columns.Add("firstName");
        tblEvent.Columns.Add("lastName");
        tblEvent.Columns.Add("Package");
        tblEvent.Columns.Add("AdditionalTests");
        tblEvent.Columns.Add("Amount");
        tblEvent.Columns.Add("Discount");
        tblEvent.Columns.Add("PaymentStatus");
        tblEvent.Columns.Add("CheckInTime");
        tblEvent.Columns.Add("CheckOutTime");
        tblEvent.Columns.Add("CouponCode");
        tblEvent.Columns.Add("Email");
        tblEvent.Columns.Add("Phone");
        tblEvent.Columns.Add("IsShippingApplied");
        tblEvent.Columns.Add("Notes");
        tblEvent.Columns.Add("Signature");
        tblEvent.Columns.Add("AddOn");
        tblEvent.Columns.Add("KynStatus");
        tblEvent.Columns.Add("PCPInfo");
        tblEvent.Columns.Add("MSPInfo");

        int regcustomercount = 0;
        int i = 1;

        var customerCallNotesRepository = IoC.Resolve<ICustomerCallNotesRepository>();
        var productRepository = IoC.Resolve<IElectronicProductRepository>();
        var shippingDetailRepository = IoC.Resolve<IShippingDetailRepository>();
        var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();

        var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
        var eventPodRoomRepository = IoC.Resolve<IEventPodRoomRepository>();
        var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
        var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
        var customerMedicareService = IoC.Resolve<ICustomerMedicareQuestionService>();

        var slots = eventSchedulingSlotRepository.GetbyEventId(Convert.ToInt64(speventid.InnerHtml));
        var eventPodRooms = eventPodRoomRepository.GetByEventId(Convert.ToInt64(speventid.InnerHtml));

        var eventPodRepository = IoC.Resolve<IEventPodRepository>();
        var isKynIntegrationEnabled = eventPodRepository.IsKynIntegrationEnabled(EventId);
        var pcpRepository = IoC.Resolve<PrimaryCarePhysicianRepository>();

        var kynHealthAssessmentHelper = IoC.Resolve<IKynHealthAssessmentHelper>();
        var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
        var customerIds = eevent.Select(x => x.Customer.CustomerID);
        var pcpCustomerList = pcpRepository.GetByCustomerIds(customerIds);

        var eventCustomers = eventCustomerRepository.GetbyEventId(EventId);
        var orderMedicareSavedDate = customerMedicareService.GetEvenetCustomerMedicareSavedDatePair(EventId);

        if (eevent.Count > 0)
        {
            foreach (EEventCustomer objEvent in eevent)
            {
                string name = CommonClass.FormatName(objEvent.Customer.User.FirstName, "", objEvent.Customer.User.LastName);

                string firstName = objEvent.Customer.User.FirstName;
                string lastName = objEvent.Customer.User.LastName;

                DateTime appointment = Convert.ToDateTime(objEvent.EventAppointment.StartTime);

                var bookedAppointment = appointmentRepository.GetById(objEvent.EventAppointment.AppointmentID);
                var roomSlots = eventAppointmentService.GetRoomSlots(slots, bookedAppointment, eventPodRooms);

                var appointmentString = string.Format("{0:hh:mm tt}", appointment);
                if (roomSlots != null && roomSlots.Any())
                {
                    var roomSlotString = "<hr style='border:solid 1px #000000;' />";
                    foreach (var roomSlot in roomSlots)
                    {
                        roomSlotString += roomSlot.FirstValue + " - " + roomSlot.SecondValue.ToShortTimeString() + "<br />";
                    }

                    appointmentString += roomSlotString;
                }

                // string starttime = appointment.ToShortTimeString();
                string email = objEvent.Customer.User.EMail1;
                var user = objEvent.Customer.User;
                var validPhoneNumber = (!string.IsNullOrEmpty(user.PhoneHome)
                                            ? user.PhoneHome
                                            : (!string.IsNullOrEmpty(user.PhoneCell)
                                                   ? user.PhoneCell
                                                   : (!string.IsNullOrEmpty(user.PhoneOffice) ? user.PhoneOffice : "")));

                string phone = objCommonCode.FormatPhoneNumberGet(validPhoneNumber);
                if (objEvent.Customer.CustomerID > 0)
                    regcustomercount++;

                string shipping = objEvent.IsShippingApplied ? objEvent.Paid ? "Y" : "N" : "-";

                string paid = objEvent.Paid ? "Y/" + shipping : "N/" + shipping;
                string couponAmount = !string.IsNullOrEmpty(objEvent.Coupon.CouponCode)
                                          ? String.Format("{0:C2}", objEvent.Coupon.CouponValue)
                                          : "";
                var eventCallNotes = customerCallNotesRepository.GetEventCustomerAppointmentNotes(objEvent.Customer.CustomerID, EventId).ToList();
                eventCallNotes = eventCallNotes.Where(e => !string.IsNullOrEmpty(e.Notes)).Select(e => e).ToList();
                //var customerCallNotes =  customerCallNotesRepository.GetCustomerNotes(objEvent.Customer.CustomerID).ToList();
                //eventCallNotes.AddRange(customerCallNotes);
                string notes = string.Empty;
                if (eventCallNotes.Count > 0)
                    notes = string.Concat("<ul><li>", String.Join("</li><li>", eventCallNotes.Select(e => e.Notes)), " </li></ul>");

                var addOnProduct = productRepository.GetElectronicProductForOrder(EventId, objEvent.Customer.CustomerID);

                var additionalShipping = false;
                var cdShipping = false;
                var shippingDetails = shippingDetailRepository.GetShippingDetailsForEventCustomer(EventId, objEvent.Customer.CustomerID);
                var cdShippingOption = shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);
                if (shippingDetails != null && shippingDetails.Count() > 0)
                {
                    additionalShipping = shippingDetails.Where(sd => sd.ActualPrice > 0).Any();

                    if (cdShippingOption != null)
                        cdShipping = shippingDetails.Where(sd => sd.ShippingOption.Id == cdShippingOption.Id).Any();
                }

                var addOn = "No";
                if (addOnProduct != null && addOnProduct.Id == (long)Product.PremiumVersionPdf)
                    addOn = "Yes";
                else if (addOnProduct != null && addOnProduct.Id == (long)Product.UltraSoundImages && cdShipping)
                    addOn = "CD";
                else if (addOnProduct != null && addOnProduct.Id == (long)Product.UltraSoundImages && !cdShipping)
                    addOn = "Online";

                var kynStatus = "N/A";
                var isPCPInfoAvilable = "No";
                if (pcpCustomerList != null && pcpCustomerList.Any() && pcpCustomerList.Any(x => objEvent.Customer.CustomerID == x.CustomerId))
                    isPCPInfoAvilable = "Yes";


                if (isKynIntegrationEnabled)
                {
                    var isPreFilled = kynHealthAssessmentHelper.IsKynHafPrefilled(EventId, objEvent.Customer.CustomerID, Convert.ToDateTime(EventDate.ToShortDateString() + " " + appointment.ToShortTimeString()));
                    if (isPreFilled.HasValue)
                    {
                        kynStatus = isPreFilled.Value ? "Yes" : "No";
                    }
                }

                var mspFilled = "N/A";

                var isPurchased = customerMedicareService.IsTestPurchased(EventId, objEvent.Customer.CustomerID, new[] { (long)TestType.Medicare, (long)TestType.AWV, (long)TestType.AwvSubsequent });

                var eventcustomerID = eventCustomers.First(x => x.CustomerId == objEvent.Customer.CustomerID).Id;
                if (isPurchased)
                {
                    var isMedicareAnswers = orderMedicareSavedDate != null && orderMedicareSavedDate.Any(x => x.FirstValue == eventcustomerID && x.SecondValue.Date.AddDays(1) <= EventDate.Date);

                    mspFilled = isMedicareAnswers ? "Yes" : "No";
                }

                tblEvent.Rows.Add(i, appointmentString, objEvent.Customer.CustomerID, name, firstName, lastName, objEvent.EventPackage.Package.PackageName, objEvent.AdditionalTest, objEvent.PaymentDetail.Amount.ToString("C2"), couponAmount, paid,
                    objEvent.EventAppointment.CheckInTime, objEvent.EventAppointment.CheckOutTime, objEvent.Coupon.CouponCode, email, phone, objEvent.IsShippingApplied, notes, "___________", addOn, kynStatus, isPCPInfoAvilable, mspFilled);

                i++;
            }

        }
        Recordcount = tblEvent.Rows.Count;
        dgprintroster.DataSource = tblEvent;
        dgprintroster.DataBind();

        spcustomercount.InnerHtml = regcustomercount.ToString();
    }

    protected void dgprintroster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && dgprintroster.Rows.Count > 0)
        {
            //Count++;
            //if (Count == (_firstPage ? RecordLimit - 6 : RecordLimit) && e.Row.RowIndex + 1 != Recordcount)
            //{
            var rowInsert = new GridViewRow(e.Row.RowIndex + 1, e.Row.RowIndex + 1, DataControlRowType.DataRow, DataControlRowState.Insert);
            var cell = new TableCell();
            cell.ColumnSpan = 14;
            cell.Text = "<div style='clear:both!important'> <div style='page-break-before:auto;'></div></div>";
            cell.Style.Add(HtmlTextWriterStyle.Padding,"0px");
            cell.Style.Add(HtmlTextWriterStyle.Height, "0px");
            rowInsert.Cells.Add(cell);
            
            var table = (Table)dgprintroster.Rows[0].Parent;
            table.Rows.Add(rowInsert);

            //_firstPage = false;
            Count = 0;
            //}

        }

    }

}
