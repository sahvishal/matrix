using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Impl;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Service;
using Falcon.App.UI;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Lib;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.UI.Lib;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Enum;
using CallType = Falcon.App.Core.CallCenter.Enum.CallType;
using ViewType = Falcon.App.Core.Enum.ViewType;
using Falcon.App.Core.Deprecated;

public partial class App_UCCommon_UCChangeAppointment : BaseUserControl
{
    private string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
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
    }

    public bool IsCustomer { get; set; }

    protected long? CallId
    {
        get
        {
            if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                return RegistrationFlow.CallId;
            return null;
        }
        set { RegistrationFlow.CallId = value.HasValue ? value.Value : 0; }
    }

    public Roles CurrentRole
    {
        get
        {
            return (Roles)CurrentOrgRole.GetSystemRoleId;
        }
    }

    public OrganizationRoleUserModel CurrentOrgRole
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        }
    }

    public long EventCustomerId
    {
        get
        {
            if (ViewState["EventCustomerId"] != null)
            {
                return Convert.ToInt64(ViewState["EventCustomerId"]);
            }
            if (Request.QueryString["EventCustomerID"] != null)
            {
                var eventCustomerId = Convert.ToInt64(Request.QueryString["EventCustomerID"]);
                ViewState["EventCustomerId"] = eventCustomerId;
                return eventCustomerId;
            }
            return 0;
        }
        set
        {
            ViewState["EventCustomerId"] = value;
        }
    }

    public long EventId
    {
        get
        {
            if (ViewState["EventId"] != null)
            {
                return Convert.ToInt64(ViewState["EventId"]);
            }
            if (Request.QueryString["EventID"] != null)
            {
                long eventId = Convert.ToInt64(Request.QueryString["EventID"]);
                ViewState["EventId"] = eventId;
                return eventId;
            }
            return 0;
        }
        set
        {
            ViewState["EventId"] = value;
        }
    }

    public long CustomerId
    {
        get
        {
            if (Request.QueryString["CustomerID"] != null)
            {
                return Convert.ToInt64(Request.QueryString["CustomerID"]);
            }
            return 0;
        }
    }

    private Customer _customer;

    private Customer Customer
    {
        get
        {
            if (_customer == null)
            {
                ICustomerRepository customerRepository = new CustomerRepository();
                _customer = customerRepository.GetCustomer(CustomerId);
            }
            return _customer;
        }
    }

    public bool IsProcessRequest
    {
        get
        {
            if (Request.QueryString[RefundRequest.ProcessRequest] != null)
                return true;
            return false;
        }
    }

    public long RefundRequestId
    {
        get
        {
            long requestId = 0;
            if (Request.QueryString[RefundRequest.ProcessRequestId] != null)
            {
                long.TryParse(Request.QueryString[RefundRequest.ProcessRequestId], out requestId);
            }
            return requestId;
        }
    }

    public bool EnableAlaCarte { get; set; }
    public bool ShowPackagePopup { get; set; }
    public bool ChangePackage
    {
        get
        {
            if (ViewState["ChangePackage"] != null)
            {
                return Convert.ToBoolean(ViewState["ChangePackage"]);
            }

            return false;
        }
        set
        {
            ViewState["ChangePackage"] = value;
        }
    }


    private void SetChangePackageValues()
    {
        EnableAlaCarte = false;
        ShowPackagePopup = false;
        ItemCartControl.Visible = false;
        ChangePackage = false;
        orderpaneldiv.Visible = false;
    }

    public bool CustomerHasMammoTest { get; set; }
    public bool IsRedirectNonMammoEvent { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerHasMammoTest = CheckPreApprovedTest(TestGroup.BreastCancer);
        if (!IsPostBack)
        {
            SetChangePackageValues();
         
            ViewState["ReferredQuery"] = Request.UrlReferrer.PathAndQuery;

            if (Request.QueryString["CustomerList"] != null)
                ViewState["CustomerList"] = true;

            hfEventID.Value = EventId.ToString();
            if (IsProcessRequest)
                SetSummaryPanel();
            else
                SetCustomerDetail();

            GetSlots(EventId.ToString());

            imgAppointment.Src = "/App/Images/page3symbolsmall.gif";
            spHeading.InnerText = "Select new time for the appointment";

            ViewState["SortExp"] = "EventDateSort";
            ViewState["SortDir"] = SortDirection.Ascending;
            rdbYes.Checked = true;
            BindReasonDropdown();

            BindEventSearchDropdown(Customer);
        }
        else
        {
            IsRedirectNonMammoEvent = false;
            var eventTargetName = Request.Params.Get("__EVENTTARGET");
            if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "continueWithWarning")
            {
                var orgUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                var previousEventId = Convert.ToInt64(hfPreviousEventId.Value);
                if (previousEventId > 0)
                    IoC.Resolve<Falcon.App.Core.Medical.IEventCustomerQuestionAnswerService>().UpdatePreQualifiedTestAnswers(CustomerId, EventId, previousEventId, orgUserId);
                ShowAppointmentPannel();
            }

            if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "ChangePackage_Click")
                ChangePackage_Click();

            if (ChangePackage)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_showHideProcessPaymentbtn", "showHideProcessPaymentbtn(true);", true);
            }

            if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "redirectNonMammoEvent")
            {
                IsRedirectNonMammoEvent = true;
                BindEventGrid();
            }
        }

    }

    private void GetSlots(string eventid)
    {
        // fill slots
        if (!string.IsNullOrEmpty(eventid))
        {
            hfNewEventID.Text = eventid;
            long id;
            Int64.TryParse(hfNewEventID.Text, out id);

            if (ChangePackage)
            {
                _ucEventAppointment1.EventId = null;
                _ucEventAppointment1.ScreeningTime = GetScreeningTimeForNewPackageTests(id);
                _ucEventAppointment1.SetAppointmentIds(null);
            }
            else
            {
                _ucEventAppointment1.EventId = null;
                _ucEventAppointment1.ScreeningTime = GetScreeningTime();
                _ucEventAppointment1.SetAppointmentIds(null);
            }

            if (id > 0)
            {
                _ucEventAppointment1.EventId = id;
            }


            if (CurrentRole == Roles.CallCenterRep)
            {
                _ucEventAppointment1.CurrentViewType = ViewType.CallCenterRep;
            }
            else if (CurrentRole == Roles.Technician || CurrentRole == Roles.NursePractitioner)
            {
                _ucEventAppointment1.CurrentViewType = ViewType.Technician;
            }
            else if (CurrentRole == Roles.FranchisorAdmin)
            {
                _ucEventAppointment1.CurrentViewType = ViewType.FranchisorAdmin;
            }
            else if (CurrentRole == Roles.FranchiseeAdmin)
            {
                _ucEventAppointment1.CurrentViewType = ViewType.FranchiseeAdmin;
            }
        }
    }

    private int GetScreeningTimeForNewPackageTests(long id)
    {
        long packageId;
        var testids = new List<long>();

        Int64.TryParse(PackageIdHiddenControl.Text, out packageId);
        if (!string.IsNullOrEmpty(IndependentTestIdsHiddenControl.Text))
        {
            testids = IndependentTestIdsHiddenControl.Text.Trim().Split(new[] { ',' }).Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
        }

        var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
        _ucEventAppointment1.PackageId = packageId;
        _ucEventAppointment1.TestIds = IndependentTestIdsHiddenControl.Text;

        return eventPackageSelectorService.GetScreeningTime(id, packageId, testids);
    }

    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        if (IsProcessRequest)
        {
            if (RefundRequestId > 0)
                Response.RedirectUser("/Finance/RefundRequest/Edit?id=" + RefundRequestId);
            else
            {
                Response.RedirectUser("/Finance/RefundRequest/Index");
            }
        }

        if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {//CustomerID
            Response.RedirectUser(ResolveUrl("/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + CustomerId));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            Response.RedirectUser(ResolveUrl("/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + CustomerId));
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            if (ViewState["CustomerList"] == null)
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + CustomerId));
            }
            else
            {
                Response.RedirectUser(ViewState["ReferredQuery"].ToString());
            }
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
        {
            if (Request.QueryString["dialerType"] != null &&
                    (Request.QueryString["dialerType"] == ((long)DialerType.Gms).ToString() || Request.QueryString["dialerType"] == ((long)DialerType.Vici).ToString()))
            {
                var url = "";
                var setting = IoC.Resolve<ISettings>();
              
                if (Request.QueryString["CallQueueId"]=="154")
                {
                    url = setting.AppUrl + "/CallCenter/PreAssessmentCallQueue/PreAssessmentCall?customerId=" + Request.QueryString["CustomerID"] +
                                           "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                }
                else
                {
                    url = setting.AppUrl + "/CallCenter/ContactCustomer/AppointmentConfirmation?customerId=" + Request.QueryString["CustomerID"] +
                       "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                }
                Response.Redirect(url);
            }

            else if (Request.QueryString["callQueueCustomerId"] != null && Request.QueryString["attemptId"] != null)
            {
                var setting = IoC.Resolve<ISettings>();
                var url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + Request.QueryString["callQueueCustomerId"] + "/" + Request.QueryString["attemptId"];

                Response.Redirect(url);
            }

            else if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId));
            }
            else
            {
                Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&guid=" + GuId));

            }
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
        {
            if (ViewState["CustomerList"] == null)
                Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment"));
            else
                Response.RedirectUser(ViewState["ReferredQuery"].ToString());
        }
        else if (CurrentOrgRole.CheckRole((long)Roles.Customer))
        {
            Response.RedirectUser(ResolveUrl("/App/Customer/HomePage.aspx"));
        }

    }

    private DateTime? AppointDateTime { get; set; }

    private bool ChangeAppointment(long eventId, IEnumerable<long> slotIds, out long? awvVisitId)
    {
        awvVisitId = null;
        var slotService = IoC.Resolve<IEventSchedulingSlotService>();
        if (slotService.IsSlotBooked(slotIds))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_AppointmentAlreadyBooked", " alert('This appointment slot has already been booked. Please choose another appointment slot.');", true);
            return false;
        }

        var eventCustomerId = EventCustomerId;

        var itemRepository = IoC.Resolve<IUniqueItemRepository<EventCustomer>>();
        var eventCustomerRepository = (IEventCustomerRepository)itemRepository;

        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();

        var eventCustomer = itemRepository.GetById(eventCustomerId);
        long appointmentIdOld = eventCustomer.AppointmentId.HasValue ? eventCustomer.AppointmentId.Value : 0;
        var currentEventId = eventCustomer.EventId;
        awvVisitId = eventCustomer.AwvVisitId;
        EventCustomerResult eventCustomerResult = null;
        try
        {
            eventCustomerResult = eventCustomerResultRepository.GetById(eventCustomerId);

            if (eventCustomerResult != null && (eventCustomerResult.ResultState > (int)TestResultStateNumber.ManualEntry || eventCustomerResult.ResultState > (int)NewTestResultStateNumber.ResultEntryCompleted) && eventId != currentEventId)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_RecordPastPreAudit", " alert('Can not reschedule appointment. Record/Result has moved past Pre Audit.');", true);
                return false;
            }
        }
        catch (ObjectNotFoundInPersistenceException<EventCustomerResult>) { }

        EventCustomer cancelledEventCustomer = null;
        try
        {
            cancelledEventCustomer = eventCustomerRepository.GetCancelledEventForUser(eventCustomer.CustomerId, eventId);
        }
        catch (ObjectNotFoundInPersistenceException<EventCustomer>)
        { }

        var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        var appointment = eventAppointmentService.CreateAppointment(slotIds, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);

        AppointDateTime = appointment.StartTime;
        //if (eventCustomer.NoShow)
        //{
        //    eventCustomer.DataRecorderMetaData.DateCreated = DateTime.Now;
        //    eventCustomer.DataRecorderMetaData.DataRecorderCreator = new OrganizationRoleUser(currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
        //}

        eventCustomer.EventId = eventId;
        eventCustomer.AppointmentId = appointment.Id;
        eventCustomer.NoShow = false;
        eventCustomer.LeftWithoutScreeningReasonId = null;
        eventCustomer.LeftWithoutScreeningNotesId = null;
        eventCustomer.IsAppointmentConfirmed = false;
        eventCustomer.ConfirmedBy = null;
        itemRepository.Save(eventCustomer);
        var reasonId = Convert.ToInt64(RescheduleReasonDropdownList.SelectedValue);
        var subReasonId = Convert.ToInt64(Request.Form[RescheduleSubReasonDropdownList.UniqueID]);

        eventAppointmentService.SaveChangeAppointmentLog(eventCustomerId, currentEventId, appointmentIdOld, eventId, appointment.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, reasonId, ReasonNotesTextbox.Text, subReasonId > 0 ? subReasonId : (long?)null);

        #region Audit

        var auditlogModel = new { CustomerID = eventCustomer.CustomerId, CurrentEventId = currentEventId, NewEventId = eventId, NewAppointmentTime = appointment.StartTime, Reason = ReasonNotesTextbox.Text };
        LogAudit(ModelType.Edit, auditlogModel, CustomerId);
        #endregion


        if (appointmentIdOld > 0)
        {
            eventAppointmentService.DeleteAppointment(appointmentIdOld);
        }


        MarkProspectCustomerConverted(eventCustomerId, eventCustomer.CustomerId);

        if (currentEventId == eventId)
        {
            SendMail(eventCustomer.CustomerId, eventId, currentSession);
            return true;
        }


        var customerNotesRepository = IoC.Resolve<ICustomerCallNotesRepository>();
        var eventNotes = customerNotesRepository.GetEventCustomerAppointmentNotes(eventCustomer.CustomerId, currentEventId);
        if (eventNotes != null && eventNotes.Count() > 0)
        {
            foreach (var customerCallNotese in eventNotes)
            {
                customerCallNotese.EventId = eventId;
            }

            customerNotesRepository.Update(eventNotes);
        }

        if (eventCustomerResult != null)
        {
            eventCustomerResult.EventId = eventId;
            eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;
            eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
            eventCustomerResultRepository.Save(eventCustomerResult);
        }

        IOrderRepository orderRepository = new OrderRepository();
        var eventTestRepository = IoC.Resolve<IEventTestRepository>();
        IOrderItemRepository orderItemRepository = new OrderItemRepository();
        var eventPackageRepository = IoC.Resolve<EventPackageRepository>();

        var currentOrder = orderRepository.GetOrderByEventCustomerId(eventCustomerId);

        foreach (var activeOrderDetail in currentOrder.OrderDetails.Where(od => od.IsCompleted && (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)))
        {

            if (activeOrderDetail.DetailType == OrderItemType.EventPackageItem)
            {
                var eventPackageInDb = eventPackageRepository.GetById(activeOrderDetail.OrderItem.ItemId);
                var eventPackage = eventPackageRepository.GetByEventAndPackageIds(eventId, eventPackageInDb.PackageId);

                OrderItem orderItem = orderItemRepository.SaveOrderItem(eventPackage.Id, OrderItemType.EventPackageItem);
                activeOrderDetail.OrderItemId = orderItem.Id;
            }
            if (activeOrderDetail.DetailType == OrderItemType.EventTestItem)
            {
                var eventTestInDb = eventTestRepository.GetbyId(activeOrderDetail.OrderItem.ItemId);
                var eventTest = eventTestRepository.GetByEventAndTestId(eventId, eventTestInDb.TestId);

                OrderItem orderItem = orderItemRepository.SaveOrderItem(eventTest.Id, OrderItemType.EventTestItem);
                activeOrderDetail.OrderItemId = orderItem.Id;
            }
        }

        var orderDetailWithSourceCode = currentOrder.OrderDetails.SingleOrDefault(od => od.SourceCodeOrderDetail != null);
        if (orderDetailWithSourceCode != null)
        {
            var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();
            var sourceCode = sourceCodeRepository.GetSourceCodeById(orderDetailWithSourceCode.SourceCodeOrderDetail.SourceCodeId);
            if (sourceCode.EventIds != null && sourceCode.EventIds.Count() > 0)
            {
                if (!sourceCode.EventIds.Contains(eventId))
                {
                    currentOrder.OrderDetails.SingleOrDefault(od => od.SourceCodeOrderDetail != null).SourceCodeOrderDetail = null;
                }
            }
        }

        orderRepository.SaveOrder(currentOrder);

        if (cancelledEventCustomer != null)
        {
            var cancelledOrder = orderRepository.GetInactiveOrder(cancelledEventCustomer.CustomerId, cancelledEventCustomer.EventId);
            IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
            orderDetailRepository.UpdateOrderDetail(cancelledOrder.Id, currentOrder.Id);
            eventCustomerRepository.DeleteEventCustomer(cancelledEventCustomer.Id);

            var paymentRepository = IoC.Resolve<IPaymentRepository>();
            var payments = paymentRepository.GetByOrderId(cancelledOrder.Id);
            if (payments != null && payments.Count > 0)
            {
                paymentRepository.UpdatePayment(payments, currentOrder.Id);
            }
        }

        SendMail(eventCustomer.CustomerId, eventId, currentSession);


        return true;
    }

    private void SendMail(long customerId, long eventId, UserSessionModel currentSession)
    {
        var eventRepository = IoC.Resolve<IEventRepository>();
        var theEvent = eventRepository.GetById(eventId);
        var settings = IoC.Resolve<ISettings>();
        var daysIntervalBeforeEvent = settings.DaysBeforeScreeningReminder;

        if (DateTime.Now.AddDays(daysIntervalBeforeEvent).Date >= theEvent.EventDate.Date)
        {
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var notifier = IoC.Resolve<INotifier>();
            var customer = customerRepository.GetCustomer(customerId);
            var appointmentConfirmationViewModel = emailNotificationModelsFactory.GetAppointmentConfirmationModel(theEvent.Id, customerId);

            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = corporateAccountRepository.GetbyEventId(eventId);

            string emailTemplateAlias = EmailTemplateAlias.ScreeningReminderMail;
            if (account != null && account.AppointmentReminderMailTemplateId > 0)
            {
                var emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
                var emailTemplate = emailTemplateRepository.GetById(account.AppointmentReminderMailTemplateId);
                emailTemplateAlias = emailTemplate.Alias;
            }

            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ScreeningReminderMail, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "Change Appointment", useAlternateEmail: true);
        }
    }

    private void MarkProspectCustomerConverted(long eventCustomerId, long customerId)
    {
        var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
        var prospectCustomer = prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
        if (prospectCustomer != null)
        {
            var customerService = IoC.Resolve<ICustomerService>();
            customerService.MarkProspectCustomerConverted(eventCustomerId);
        }
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {

        IEnumerable<long> slotIds = _ucEventAppointment1.GetAppointmentIds();//Convert.ToInt64(hfAppointmentID.Value);
        var eventId = Convert.ToInt64(hfNewEventID.Text);
        var oldeventId = Convert.ToInt64(hfEventID.Value);
        //var customerService = IoC.Resolve<ICustomerService>();

        bool result;
        string previousTag = string.Empty;
        bool isAppointmentChanged = true;
        long? awvVisitId = null;
        using (var scope = new TransactionScope())
        {
            try
            {
                result = ChangeAppointment(eventId, slotIds, out awvVisitId);
                if (result)
                {
                    //previousTag = customerService.SetCustomerTag(CustomerId, eventId);
                    //previousTag = Customer.Tag;
                    scope.Complete();

                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while Changing appointment without payment. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);

                _ucEventAppointment1.SetAppointmentIds(null);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_AppointmentAlreadyBooked", " alert('The slot selected is no longer temporarily booked for you. Please choose the slot again.');", true);
                result = false;
                isAppointmentChanged = false;
            }
        }

        if (isAppointmentChanged)
        {
            var eventRepository = IoC.Resolve<IEventRepository>();
            var eventData = eventRepository.GetById(eventId);

            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            var customerService = IoC.Resolve<ICustomerService>();
            var orgRoleUserId = currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
            previousTag = customerService.SetCustomerTag(Customer, eventId, orgRoleUserId, eventData.EventDate);
            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);

            if (awvVisitId.HasValue && awvVisitId.Value > 0)
            {
                try
                {
                    var testResultService = IoC.Resolve<TestResultService>();
                    var isEawvPurchased = testResultService.IsTestPurchasedByCustomer(eventId, CustomerId, (long)TestType.eAWV);

                    var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(eventId);

                    var medicare = IoC.Resolve<IMedicareApiService>();
                    if (currentSession != null)
                    {
                        var token = (Session.SessionID + "_" + currentSession.UserId + "_" + currentSession.CurrentOrganizationRole.RoleId + "_" + currentSession.CurrentOrganizationRole.OrganizationId).Encrypt();
                        var settings = IoC.Resolve<ISettings>();
                        
                        if (settings.SyncWithHra)
                        {
                            try
                            {
                                medicare.Connect(currentSession.UserLoginLogId);
                            }
                            catch (Exception)
                            {
                                var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                                medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                medicare.Connect(currentSession.UserLoginLogId);
                            }

                            if (isEawvPurchased)
                            {
                                var visitId = medicare.Post<long>(MedicareApiUrl.EventInfoUpdateUrl,
                                new MedicareEventEditModel
                                {
                                    EventId = eventId,
                                    Tag = account != null ? account.Tag : null,
                                    VisitId = awvVisitId.Value,
                                    VisitDate = eventData.EventDate,
                                    IsFromReschedule = true
                                });
                                if (visitId != awvVisitId.Value && EventCustomerId > 0)
                                {

                                    eventCustomer.AwvVisitId = visitId;
                                    eventCustomerRepository.Save(eventCustomer);
                                }
                            }
                            else
                            {
                                var isSuccess = medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + awvVisitId.Value + "&status=" + (int)MedicareVisitStatus.Initiated + "&unlock=true");
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Error Occured while Updating Event to Medicare. EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                }
            }

            if (oldeventId != eventId)
            {
                try
                {
                    var eventSchedulingSlotService = IoC.Resolve<IEventSchedulingSlotService>();
                    eventSchedulingSlotService.SendEventFillingNotification(eventId, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION Event Filling Notification Message:" + ex.Message + " Stack Trace - " + ex.StackTrace);
                }

                if (!IsProcessRequest && currentSession != null)
                {
                    try
                    {
                        var reasonId = Convert.ToInt64(RescheduleReasonDropdownList.SelectedValue);
                        var selectedSubReasonId = long.Parse(Request.Form[RescheduleSubReasonDropdownList.UniqueID]);

                        var cancelAppointmentNotificationServcie = IoC.Resolve<ICancellationRescheduleAppointmentNotificationService>();
                        var rescheduleReason = ((RescheduleAppointmentReason)reasonId).GetDescription();
                        var rescheduleSubReason = selectedSubReasonId > 0 ? ((RescheduleAppointmentSubReason)selectedSubReasonId).GetDescription() : "N/A";

                        var orgRoleId = currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
                        cancelAppointmentNotificationServcie.SendCancellationRescheduleAppointmentMail(false, CustomerId, oldeventId, eventId, rescheduleReason, orgRoleId, "System: Change Appointment", rescheduleSubReason);
                    }
                    catch (Exception ex)
                    {
                        IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION Process Refund Request Message:" + ex.Message + " Stack Trace - " + ex.StackTrace);
                    }
                }

                try
                {
                    if (!string.IsNullOrEmpty(previousTag.Trim()) && currentSession != null)
                    {
                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                        var emailNotification = emailNotificationModelsFactory.GetCustomerTagChangeNotificationViewModel(oldeventId, eventId, CustomerId, previousTag);
                        var notifier = IoC.Resolve<INotifier>();

                        if (emailNotification.PreviousTag != emailNotification.NewTag)
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerTagUpdated, EmailTemplateAlias.CustomerTagUpdated, emailNotification, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "Change Appointment");
                    }

                    if (oldeventId != eventId)
                    {
                        UpdateEventCustomerPreApprovedTest(eventId, CustomerId);
                        DeleteEventCustomerCheckListAnswers(eventId, CustomerId);
                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("EXCEPTION " + ex.Message + " Stack Trace - " + ex.StackTrace);
                }

                try
                {
                    var futureAppointment = new FutureAppointmentFlagViewModel
                    {
                        CustomerId = CustomerId,
                        HasFutureAppointment = true,
                        FutureAppointmentDate = eventData.EventDate
                    };

                    IoC.Resolve<ICallQueueCustomerPublisher>().UpdateFutreAppointmentFlag(futureAppointment);

                    if (oldeventId != eventId && AppointDateTime.HasValue)
                    {
                        //eventData.TimeZone

                        var smsHelper = IoC.Resolve<ISmsHelper>();
                        var hostRepository = IoC.Resolve<HostRepository>();
                        var host = hostRepository.GetHostForEvent(eventId);
                        var appointmentWithTimeZone = smsHelper.ConvertToServerTime(AppointDateTime.Value, eventData.TimeZone, !SmsHelper.DaylightSavingNotApplicableStates.Contains(host.Address.StateCode));

                        IoC.Resolve<ICallQueueCustomerRepository>().UpdateConfirmationQueueCustomersOnReschedule(eventCustomer, AppointDateTime.Value, appointmentWithTimeZone);
                    }

                }
                catch (Exception ex)
                {

                    var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                    logger.Error("some Error Occurred While Updating future Customers");
                    logger.Error("Message: " + ex.Message);
                    logger.Error("Stack Trace: " + ex.StackTrace);
                }

                SendMailOnRegistrationOfMammoPatientOnNonMammoEvent(eventData, currentSession);
            }

        }

        if (result)
        {
            if (IsProcessRequest)
                SaveRequest();

            Page.ClientScript.RegisterStartupScript(typeof(string), "JSCODE", "alert('Appointment change successfully.');", true);

            if (CurrentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                Response.RedirectUser(
                    ResolveUrl("/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" +
                                    CustomerId + "&Action=Appointment"));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                Response.RedirectUser(
                    ResolveUrl("/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" +
                                    CustomerId + "&Action=Appointment"));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                Response.RedirectUser(
                    ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" +
                                    CustomerId + "&Action=Appointment"));
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.CallCenterRep) || CurrentOrgRole.CheckRole((long)Roles.CallCenterManager))
            {
                //Keep this before redirect for CCRep normal flow
                if (Request.QueryString["dialerType"] != null &&
                    (Request.QueryString["dialerType"] == ((long)DialerType.Gms).ToString() || Request.QueryString["dialerType"] == ((long)DialerType.Vici).ToString()))
                {
                    var url = "";
                    var setting = IoC.Resolve<ISettings>();
                    if (Request.QueryString["CallQueueId"] == "154")
                    {
                        var callCenterCall = IoC.Resolve<ICallCenterCallRepository>();
                        if (Request.QueryString["CallID"] != "")
                        {
                            long callId = Convert.ToInt64(Request.QueryString["CallID"]);
                            callCenterCall.UpdateCallCenterCallEvent(eventId, callId);
                        }
                        url = setting.AppUrl + "/CallCenter/PreAssessmentCallQueue/PreAssessmentCall?customerId=" + Request.QueryString["CustomerID"] +
                                               "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                    }
                    else
                    {
                     url = setting.AppUrl + "/CallCenter/ContactCustomer/AppointmentConfirmation?customerId=" + Request.QueryString["CustomerID"] +
                             "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                    }

                    Response.Redirect(url);
                }

                else if (Request.QueryString["callQueueCustomerId"] != null && Request.QueryString["attemptId"] != null)
                {
                    var setting = IoC.Resolve<ISettings>();
                    var url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + Request.QueryString["callQueueCustomerId"] + "/" + Request.QueryString["attemptId"];

                    Response.Redirect(url);

                    /*Response.RedirectUser("../AddNotes.aspx?LbuttonVisible=yes&IsRescheduled=true&guid=" + GuId);*/
                }

                else if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    Response.RedirectUser(
                        ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment&Call=No" + "&guid=" + GuId));
                }
                else
                {
                    if (CallId.HasValue)
                    {
                        var repository = new CallCenterCallRepository();
                        var call = repository.GetCallCenterEntity(CallId.Value);

                        call.CallStatus = CallType.Reschedule.ToString();
                        call.EventID = eventId;

                        EndCall(call);
                        StartCall(call.CalledCustomerID);
                    }

                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + CustomerId + "&Action=Appointment" + "&guid=" + GuId));

                }
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Technician) || CurrentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                if (ViewState["CustomerList"] == null)
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" +
                                        CustomerId + "&Action=Appointment"));
                else
                    Response.RedirectUser(ViewState["ReferredQuery"].ToString());
            }
            else if (CurrentOrgRole.CheckRole((long)Roles.Customer))
            {
                Response.RedirectUser(ResolveUrl("/App/Customer/HomePage.aspx?Action=Appointment"));
            }
        }

    }

    private bool CheckPreApprovedTest()
    {
        var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
        return preApprovedTestRepository.CheckPreApprovedTestForCustomer(CustomerId, TestGroup.BreastCancer);
    }

    private void SendMailOnRegistrationOfMammoPatientOnNonMammoEvent(Event eventData, UserSessionModel currentSession)
    {
        try
        {
            if (Customer != null && eventData != null)
            {
                var customerHasMammo = CheckPreApprovedTest();
                if (customerHasMammo)
                {
                    var eventhasMammoTest = IoC.Resolve<IEventTestRepository>().EventHasMammoTests(eventData.Id);

                    if (!eventhasMammoTest)
                    {
                        var notifier = IoC.Resolve<INotifier>();
                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                        var mammoNotificationModel = emailNotificationModelsFactory.GetMammoPatientRegestrationOnNonMammoEventViewModel(Customer, eventData);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.MammoPatientRegistrationOnNonMammoEventNotification, EmailTemplateAlias.MammoPatientRegistrationOnNonMammoEvent, mammoNotificationModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            logger.Error("Message" + ex.Message + " \n Stack Trace: " + ex.StackTrace);
        }
    }

    protected void rdbNo_CheckedChanged(object sender, EventArgs e)
    {
        divEventName.Style.Add(HtmlTextWriterStyle.Display, "none");
        divEventHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
        divEventID.Style.Add(HtmlTextWriterStyle.Display, "none");
        RescheduleAppointment();
    }

    private void RescheduleAppointment()
    {
        if (rdbYes.Checked)
        {
            DVEvent.Style.Add(HtmlTextWriterStyle.Display, "none");
            DVEvent.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            imgAppointment.Src = "/App/Images/page3symbolsmall.gif";
            spHeading.InnerText = "Select new time for the appointment";
            GetSlots(EventId.ToString());
            spAppointment.Style.Add(HtmlTextWriterStyle.Display, "block");
            spAppointment.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            ibtnSave.Style.Add(HtmlTextWriterStyle.Display, "block");
            ibtnSave.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            appointmentPaymentControl.Visible = false;
            orderpaneldiv.Visible = false;
            ChangePackage = false;
            Div3.Style.Add(HtmlTextWriterStyle.Display, "none");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_showHideProcessPaymentbtn", "showHideProcessPaymentbtn(false);", true);
        }
        else
        {
            txtCity.Text = "";
            txtTo.Text = "";
            txtFrom.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            DVEvent.Style.Add(HtmlTextWriterStyle.Display, "block");
            DVEvent.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            dvgrid.Style.Add(HtmlTextWriterStyle.Display, "none");
            dvgrid.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            dgEvent.Visible = false;
            Div3.Style.Add(HtmlTextWriterStyle.Display, "none");
            imgAppointment.Src = "/App/Images/page4symbolsmall.gif";
            spHeading.InnerText = "Select the available slot for the selected event ";
            spAppointment.Style.Add(HtmlTextWriterStyle.Display, "none");
            spAppointment.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            ibtnSave.Style.Add(HtmlTextWriterStyle.Display, "none");
            ibtnSave.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_showHideProcessPaymentbtn", "showHideProcessPaymentbtn(false);", true);
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        hfPreviousEventId.Value = "0";
        BindEventGrid();
        ChangePackage = false;
        orderpaneldiv.Visible = false;
        appointmentPaymentControl.Visible = false;
    }

    private void SetSummaryPanel()
    {
        var service = IoC.Resolve<IEventCustomerReportingService>();
        var model = service.GetEventCustomerSummary(EventId, CustomerId);

        spCustomerName.InnerText = model.CustomerName;
        hfEventCustomerID.Value = model.EventCustomerId.ToString();
        EventCustomerId = model.EventCustomerId;
        spCustomerID.InnerText = model.CustomerId.ToString();
        spEventID.InnerText = model.EventId.ToString();
        spHost.InnerText = model.Host;

        hidNewEvent.Text = model.Host;
        spAddress.InnerText = model.Address.ToString();

        ViewState["OrderId"] = model.OrderId;

        spCoupon.InnerText = !string.IsNullOrEmpty(model.SourceCode) ? model.SourceCode : "-N/A-";
        spCost.InnerText = model.Cost.ToString("0.00");


        spPackage.InnerText = model.Package;

        if (model.AppointmentTime.HasValue)
        {
            spAppointmentTime.InnerText = model.AppointmentTime.Value.ToShortTimeString();
        }

        // display event status
        _spnEventStatus.InnerText = model.EventStatus.ToString();

        // disable change appointment in case the event is cancel or suspended
        if (model.EventStatus != EventStatus.Active)
        {
            rdbYes.Enabled = false;
            rdbNo.Checked = true;
            RescheduleAppointment();
        }

    }

    private void SetCustomerDetail()
    {
        var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
        var eventCustomer = EventCustomerId > 0 ? eventCustomerRepository.GetById(EventCustomerId) : eventCustomerRepository.GetRegisteredEventForUser(CustomerId, EventId);

        if (eventCustomer != null)
        {
            var service = IoC.Resolve<IEventCustomerReportingService>();
            var model = service.GetEventCustomerSummary(eventCustomer.EventId, eventCustomer.CustomerId);

            spCustomerName.InnerText = model.CustomerName;
            hfEventCustomerID.Value = model.EventCustomerId.ToString();
            EventCustomerId = model.EventCustomerId;
            spCustomerID.InnerText = model.CustomerId.ToString();
            spEventID.InnerText = model.EventId.ToString();

            spHost.InnerText = model.Host;
            // TODO: It has to be verified.
            hidNewEvent.Text = model.Host;
            spAddress.InnerText = model.Address.ToString();

            ViewState["OrderId"] = model.OrderId;
            spCoupon.InnerText = !string.IsNullOrEmpty(model.SourceCode) ? model.SourceCode : "-N/A-";
            spCost.InnerText = model.Cost.ToString("0.00");

            spPackage.InnerText = model.Package;

            if (model.AppointmentTime.HasValue)
            {
                spAppointmentTime.InnerText = model.AppointmentTime.Value.ToShortTimeString();
            }


            // display event status
            _spnEventStatus.InnerHtml = model.EventStatus.ToString();

            // disable change appointment in case the event is cancel or suspended
            if (model.EventStatus != EventStatus.Active)
            {
                //
                rdbYes.Enabled = false;
                rdbNo.Checked = true;
                RescheduleAppointment();
            }
        }
    }

    private int GetScreeningTime()
    {
        var orderRepository = IoC.Resolve<IOrderRepository>();

        var order = EventCustomerId > 0
                        ? orderRepository.GetOrderByEventCustomerId(EventCustomerId)
                        : orderRepository.GetOrder(CustomerId, EventId);

        var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();

        SetPackageIdAndTestIds(order);

        return eventPackageSelectorService.GetScreeningTime(order);
    }

    private void SetPackageIdAndTestIds(Order order)
    {
        var eventTestRepository = IoC.Resolve<IEventTestRepository>();
        var eventPackageRepository = IoC.Resolve<EventPackageRepository>();

        var testIds = new List<long>();

        foreach (var activeOrderDetail in order.OrderDetails.Where(od => od.IsCompleted && (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)))
        {

            if (activeOrderDetail.DetailType == OrderItemType.EventPackageItem)
            {
                var eventPackageInDb = eventPackageRepository.GetById(activeOrderDetail.OrderItem.ItemId);
                _ucEventAppointment1.PackageId = eventPackageInDb.PackageId;
            }
            if (activeOrderDetail.DetailType == OrderItemType.EventTestItem)
            {
                var eventTestInDb = eventTestRepository.GetbyId(activeOrderDetail.OrderItem.ItemId);
                testIds.Add(eventTestInDb.TestId);
            }
        }

        if (!testIds.IsNullOrEmpty())
            _ucEventAppointment1.TestIds = string.Join(",", testIds);
    }

    protected void lnkSelectEvent_Click(object sender, EventArgs e)
    {
        var lnktemp = (LinkButton)sender;
        int eventid = Convert.ToInt32(lnktemp.CommandArgument);
        ChangePackage = false;
        orderpaneldiv.Visible = false;
        appointmentPaymentControl.Visible = false;
        ItemCartControl.Visible = false;

        spAppointment.Style.Add(HtmlTextWriterStyle.Display, "none");
        spAppointment.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

        if (!EventValidation(eventid)) return;

        hfNewEventID.Text = eventid.ToString();

        var eventTestRepository = IoC.Resolve<IEventTestRepository>();
        var eventTests = eventTestRepository.GetEventTestsByEventIds(new[] { Convert.ToInt64(eventid) });
        var preQualificationTemplateIds = eventTests.Where(x => x.PreQualificationQuestionTemplateId.HasValue).Select(x => x.PreQualificationQuestionTemplateId.Value).ToArray();

        var preQualificationTestTemplateRepository = IoC.Resolve<IPreQualificationTestTemplateRepository>();
        var preQualificationTestTemplates = preQualificationTestTemplateRepository.GetByIds(preQualificationTemplateIds);

        var selectedTemplateIds = new List<long>(); //preQualificationTestTemplates.Select(x => x.TestId).ToArray();
        foreach (var preQualificationTestTemplate in preQualificationTestTemplates)
        {
            if (CheckPreApprovedTest(new[] { preQualificationTestTemplate.TestId }))
            {
                selectedTemplateIds.Add(preQualificationTestTemplate.Id);
            }
        }

        hfTemplateIds.Value = string.Join(",", selectedTemplateIds);

        var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
        hfQuestionIdAnswerTestId.Value = eventCustomerQuestionAnswerService.GetQuestionAnswerTestIdString(CustomerId, Convert.ToInt64(eventid));

        if (IsCustomerTagSame(eventid)) return;

        hfHostName.Value = lnktemp.CommandName;
        hfAppointmentID.Value = "";
        hfAppointmentTime.Value = "";

        if (selectedTemplateIds.Any())
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "js_GetPreQualificationQuestion",
                "GetPreQualificationQuestion('" + string.Join(",", selectedTemplateIds) + "');", true);
        }
        else
        {
            ShowAppointmentPannel();
        }
    }


    private void ShowAppointmentPannel()
    {
        if (ChangePackage == false && !OrderValidation(ParseIntoInt(hfNewEventID.Text))) return;

        GetSlots(hfNewEventID.Text);
        var dt = (DataTable)ViewState["Event"];
        var dr = dt.Select("Id=" + hfNewEventID.Text.Trim());
        divEventName.InnerHtml = dr[0]["Name"] + ", " + dr[0]["Address"];
        divEventID.InnerHtml = "Event (ID:" + dr[0]["Id"] + "):" + " ";
        divEventName.Style.Add(HtmlTextWriterStyle.Display, "block");
        divEventName.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        divEventHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
        divEventHeading.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        divEventID.Style.Add(HtmlTextWriterStyle.Display, "block");
        divEventID.Style.Add(HtmlTextWriterStyle.Visibility, "visible");


        spAppointment.Style.Add(HtmlTextWriterStyle.Display, "block");
        spAppointment.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

        if (ChangePackage)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_showHideProcessPaymentbtn", "showHideProcessPaymentbtn(true);", true);
        }
        else
        {
            ibtnSave.Style.Add(HtmlTextWriterStyle.Display, "block");
            ibtnSave.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }

        Page.ClientScript.RegisterStartupScript(typeof(string), "js_setFocus", "setFocustoApptblock();", true);
    }
    protected void dgEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgEvent.PageIndex = e.NewPageIndex;
        dgEvent.DataSource = (DataTable)ViewState["Event"];
        dgEvent.DataBind();
    }


    private void BindEventGrid()
    {
        IConfigurationSettingRepository configurationSettingRepository = new ConfigurationSettingRepository();
        string distanceFromZip = configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.Eventdistance);

        if (Convert.ToInt32(ZipRadius.SelectedValue) > 0)
            distanceFromZip = ZipRadius.SelectedValue;

        ViewState["SortExp"] = string.IsNullOrEmpty(txtZip.Text) ? "Name" : "Distance";
        var tag = string.Empty;
        var hasMammo = false;

        if (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.HealthPlan.ToString() || EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Corporate.ToString() || EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Mammo.ToString())
        {
            tag = Customer.Tag;

            if (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Mammo.ToString())
            {
                hasMammo = true;
            }
        }

        if (CustomerHasMammoTest && !IsRedirectNonMammoEvent)
        {
            hasMammo = true;
        }

        long? ProductTypeId = null;
        if (Customer != null && CustomerId > 0)
        {
            ProductTypeId = Customer.ProductTypeId;
        }         
        var eventService = IoC.Resolve<IEventService>();
        var events = eventService.GetEventHostViewData(ViewType.CallCenterRep, txtState.Text, txtCity.Text, "", txtZip.Text, Convert.ToInt32(distanceFromZip), txtFrom.Text.Length > 0 ? (DateTime?)Convert.ToDateTime(txtFrom.Text) : null,
            txtTo.Text.Length > 0 ? (DateTime?)Convert.ToDateTime(txtTo.Text) : null, 0, CurrentRole == Roles.CallCenterRep, EventId, tag, hasMammo, ProductType: ProductTypeId);

        DataTable eventTable = GetEventTableColumns();

        if (events != null && !events.IsEmpty())
        {
            string googleAddressVerified = string.Empty;
            foreach (var eventHostViewData in events)
            {
                string addressMultiLine = CommonCode.AddressMultiLine(eventHostViewData.StreetAddressLine1, eventHostViewData.StreetAddressLine2, eventHostViewData.City, eventHostViewData.State, eventHostViewData.Zip);

                string eventType = string.Empty;

                if (!string.IsNullOrEmpty(eventHostViewData.EventType))
                {
                    eventType = eventHostViewData.EventType.Trim().Equals("Public") ? "<img src='/App/Images/public-icon.gif' title='Public Event' />" : "<img src='/App/Images/private-icon.gif' title='Private Event' style='padding:0px 5px 0px 0px;' />";
                }

                bool slotsAvailable = true;
                bool noSlotsAvailable = true;
                bool suspended = true;
                bool cancelled = true;

                switch (eventHostViewData.EventStatus)
                {
                    case "Suspended":
                        slotsAvailable = false;
                        noSlotsAvailable = false;
                        cancelled = false;
                        break;
                    case "Canceled":
                        slotsAvailable = false;
                        noSlotsAvailable = false;
                        suspended = false;
                        break;
                    default:
                        suspended = false;
                        cancelled = false;
                        if (eventHostViewData.AvailableAppointmentSlots.HasValue && eventHostViewData.AvailableAppointmentSlots.Value > 0)
                            noSlotsAvailable = false;
                        else
                            slotsAvailable = false;
                        break;
                }

                eventTable.Rows.Add
                    (
                        new object[]
                                {
                                    eventHostViewData.EventId, eventHostViewData.Name,
                                    eventHostViewData.EventDate, eventHostViewData.PodNames(), eventHostViewData.OrganizationName, addressMultiLine,
                                    eventHostViewData.DistanceFromZip,
                                    eventHostViewData.IsDynamicScheduling.HasValue && eventHostViewData.IsDynamicScheduling.Value? "Dynamic Scheduling": eventHostViewData.AvailableAppointmentSlots + "/" + eventHostViewData.TotalAppointmentSlots,
                                    "", slotsAvailable, noSlotsAvailable, eventHostViewData.EventType, eventType,
                                    suspended, cancelled, eventHostViewData.EventNotes,
                                    eventHostViewData.EventStatus, googleAddressVerified,
                                    eventHostViewData.HasBreastCancerTest.HasValue && eventHostViewData.HasBreastCancerTest.Value,eventHostViewData.IsFemaleOnly,eventHostViewData.SponseredBy,eventHostViewData.InvitationCode
                                     ,eventHostViewData.AllowNonMammoPatients
                                });
            }
        }

        if (eventTable.Rows.Count > 0)
        {
            ViewState["Event"] = eventTable;
            dgEvent.DataSource = eventTable;

            dgEvent.Visible = true;
            dgEvent.DataBind();


            Div3.Style.Add(HtmlTextWriterStyle.Display, "block");


            //dvSearchResult1.InnerText = "Total: ";
            //dvSearchResult.InnerText = eventTable.Rows.Count + " Result found";

            //dbsearch.Visible = true;
            //dbsearch.Style["display"] = string.Empty;

        }
        else
        {
            //dbsearch.Visible = false;
            //dbsearch.Style["display"] = string.Empty;
            dgEvent.Visible = false;
            //dvSearchResult.InnerText = "No Result found";
        }
    }

    private static DataTable GetEventTableColumns()
    {
        var eventTable = new DataTable();
        eventTable.Columns.Add("Id", typeof(long));
        eventTable.Columns.Add("Name");
        eventTable.Columns.Add("Date", typeof(DateTime));
        eventTable.Columns.Add("Pods");
        eventTable.Columns.Add("Host");
        eventTable.Columns.Add("Address");
        eventTable.Columns.Add("Distance", typeof(Decimal));
        eventTable.Columns.Add("Slots");
        eventTable.Columns.Add("GoogleMap");
        eventTable.Columns.Add("IsSlotsAvailable", typeof(bool));
        eventTable.Columns.Add("IsNoSlotsAvailable", typeof(bool));
        eventTable.Columns.Add("EventType");
        eventTable.Columns.Add("EventTypeImage");
        eventTable.Columns.Add("TempUnavailable", typeof(bool));
        eventTable.Columns.Add("Cancelled", typeof(bool));
        eventTable.Columns.Add("EventNotes");
        eventTable.Columns.Add("EventStatus");
        eventTable.Columns.Add("GoogleAddressVerified");
        eventTable.Columns.Add("HasBreastCancer", typeof(bool));
        eventTable.Columns.Add("IsFemaleOnly", typeof(bool));
        eventTable.Columns.Add("SponseredBy");
        eventTable.Columns.Add("InvitationCode");
        eventTable.Columns.Add("AllowNonMammoPatients", typeof(bool));

        return eventTable;
    }

    protected void dgEvent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                var selectEventLink = e.Row.FindControl("lnkSelectEvent1") as LinkButton;
                if (selectEventLink != null)
                {
                    var eventIdSpan = e.Row.FindControl("spnEventID") as HtmlContainerControl;
                    var eventTypeSpan = e.Row.FindControl("spnEventType") as HtmlContainerControl;
                    if (eventIdSpan != null && eventTypeSpan != null && !string.IsNullOrEmpty(eventTypeSpan.InnerHtml.Trim()) && eventTypeSpan.InnerHtml.Trim().Equals("Private"))
                    {
                        selectEventLink.Attributes.Add("onclick", "return SelectEvent(" + eventIdSpan.InnerHtml.Trim() + ");");
                    }
                }
                break;
        }
    }

    private void StartCall(long calledCustomerid)
    {
        var newCall = new Call();
        var repository = new CallCenterCallRepository();

        if (CallId.HasValue)
        {
            var call = repository.GetById(CallId.Value);

            newCall.CalledInNumber = call.CalledInNumber;
            newCall.CallerNumber = call.CallerNumber;
            newCall.IsIncoming = call.IsIncoming;
        }

        newCall.CreatedByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        newCall.StartTime = DateTime.Now;
        newCall.CallDateTime = DateTime.Now;
        newCall.DateCreated = DateTime.Now;
        newCall.DateModified = DateTime.Now;
        newCall.CalledCustomerId = calledCustomerid;

        if (!string.IsNullOrEmpty(Customer.Tag))
        {
            var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = accountRepository.GetByTag(Customer.Tag);
            newCall.HealthPlanId = account.Id;
        }

        newCall = repository.Save(newCall);
        CallId = newCall.Id;
    }

    private void EndCall(ECall call)
    {
        call.TimeEnd = DateTime.Now.ToString();
        var callcenterDal = new CallCenterDAL();
        callcenterDal.UpdateCall(call);
    }

    private void SaveRequest()
    {
        if (RefundRequestId < 1)
            Response.RedirectUser("/Finance/RefundRequest/Index");

        if (Request.QueryString["resolve"] == null)
        {
            Response.RedirectUser("/Finance/RefundRequest/Edit?id=" + RefundRequestId);
        }

        var repository = IoC.Resolve<IRefundRequestRepository>();
        var refundRequest = repository.Get(RefundRequestId);
        var sessioncontext = IoC.Resolve<ISessionContext>().UserSession;

        refundRequest.RefundRequestResult.ProcessedByOrgRoleUserId = sessioncontext.CurrentOrganizationRole.OrganizationRoleUserId;
        refundRequest.RefundRequestResult.ProcessedOn = DateTime.Now;
        refundRequest.RefundRequestResult.RefundAmount = 0;
        refundRequest.RefundRequestResult.RequestResultType = RequestResultType.RescheduleAppointment;
        refundRequest.RequestStatus = (long)RequestStatus.Resolved;
        ((IRepository<RefundRequest>)repository).Save(refundRequest);
        Response.RedirectUser("/Finance/RefundRequest");


    }

    private void BindReasonDropdown()
    {
        var lookup = IoC.Resolve<ILookupRepository>();
        var reasons =
            lookup.GetByLookupId((long)RescheduleAppointmentReason.HealthFairReason)
                .OrderBy(x => x.RelativeOrder)
                .Select(x => new OrderedPair<long, string> { FirstValue = x.Id, SecondValue = x.DisplayName }).OrderBy(x => x.SecondValue)
                .ToArray();

        RescheduleReasonDropdownList.Items.Clear();
        RescheduleReasonDropdownList.DataSource = reasons;
        RescheduleReasonDropdownList.DataTextField = "SecondValue";
        RescheduleReasonDropdownList.DataValueField = "FirstValue";
        RescheduleReasonDropdownList.DataBind();
        RescheduleReasonDropdownList.Items.Insert(0, (new ListItem("--Select--", "0")));
    }

    private bool EventValidation(long eventId)
    {
        if (PackageRegistrationValidators.EventValidation(CustomerId, eventId))
        {
            IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository =
            new EventCustomerRegistrationViewDataRepository();

            var data = eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(CustomerId, eventId);

            //check dulicate event registration
            if (data != null)
            {
                var packageAndTest = data.PackageName;
                packageAndTest = string.IsNullOrEmpty(packageAndTest) ? data.AdditinalTest : packageAndTest + (string.IsNullOrEmpty(data.AdditinalTest) ? string.Empty : ", " + data.AdditinalTest);

                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = data.FirstName + " " + data.MiddleName + " " + data.LastName + " is already registered for this event (" + data.EventName + " ) at " +
                                        data.EventDate.ToString("dddd dd MMMM yyyy") + " " + data.AppointmentStartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
                                        ". Duplicate registrations for the same customer are not allowed.";

            }
            return false;
        }

        var service = IoC.Resolve<IRefundRequestService>();
        var result = service.CheckifCancelAppointmentRequestExistsforaCustomer(eventId, CustomerId);
        if (result)
        {
            divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = "Customer has cancelled the appointment for this event, the cancellation request is in process. Re-registration is not allowed unless the request is resolved.";
            return false;
        }

        return true;
    }

    private void SetAlaCarteStatus(Event theEvent)
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
        EnableAlaCarte = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));

        if (EnableAlaCarte)
        {
            if (currentSession != null && currentSession.CurrentOrganizationRole.RoleId == (long)Roles.Customer)
                EnableAlaCarte = theEvent.EnableAlaCarteOnline;
            else if (currentSession != null &&
                     currentSession.CurrentOrganizationRole.RoleId == (long)Roles.CallCenterRep || currentSession != null && currentSession.CurrentOrganizationRole.RoleId == (long)Roles.CallCenterManager)
                EnableAlaCarte = theEvent.EnableAlaCarteCallCenter;
            else if (currentSession != null &&
                     (currentSession.CurrentOrganizationRole.RoleId == (long)Roles.Technician || currentSession.CurrentOrganizationRole.RoleId == (long)Roles.NursePractitioner))
                EnableAlaCarte = theEvent.EnableAlaCarteTechnician;
            else if (!(theEvent.EnableAlaCarteOnline || theEvent.EnableAlaCarteCallCenter || theEvent.EnableAlaCarteTechnician))
                EnableAlaCarte = false;
        }
    }

    private void EnableChangePackage(Event theEvent)
    {
        ItemCartControl.Visible = true;
        ItemCartControl.EventId = theEvent.Id;
        ItemCartControl.RoleId = (long)CurrentRole;
        ItemCartControl.PackageAndTestItems();
        ShowPackagePopup = true;
        hfNewEventID.Text = theEvent.Id.ToString();
        SetAlaCarteStatus(theEvent);
    }

    private bool OrderValidation(int eventid)
    {
        var orderId = Convert.ToInt64(ViewState["OrderId"]);

        IOrderRepository orderRepository = new OrderRepository();
        var order = orderRepository.GetOrder(orderId);
        var eventRepository = IoC.Resolve<IEventRepository>();
        var theEvent = eventRepository.GetById(eventid);
        var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
        var package = eventPackageRepository.GetPackageForOrder(order.Id);
        EventPackage newEventPackage = null;
        var independentTestIds = new List<long>();
        var orderTestPrice = 0.0m;
        var newOrderTestPrice = 0.0m;

        if (order.OrderDetails.Any(od => od.IsCompleted && od.DetailType == OrderItemType.EventPackageItem) && package != null)
        {
            int packageId = Convert.ToInt32(package.PackageId);

            var eventPackage = eventPackageRepository.GetByEventAndPackageIds(eventid, packageId);
            if (eventPackage == null)
            {
                EnableChangePackage(theEvent);
                return false;
            }

            newEventPackage = eventPackageRepository.GetByEventAndPackageIds(eventid, packageId);
        }

        if (order.OrderDetails.Any(od => od.IsCompleted && od.DetailType == OrderItemType.EventTestItem))
        {
            var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
            var enableAlaCarte = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
            if (enableAlaCarte)
            {
                if (!(theEvent.EnableAlaCarteOnline || theEvent.EnableAlaCarteCallCenter || theEvent.EnableAlaCarteTechnician))
                    enableAlaCarte = false;
            }

            var testRepository = IoC.Resolve<IEventTestRepository>();
            var testsInOrder = testRepository.GetTestsForOrder(orderId);
            var tests = testRepository.GetTestsForEvent(eventid);
            independentTestIds = testsInOrder.Select(x => x.TestId).ToList();

            orderTestPrice = package == null ? testsInOrder.Sum(x => x.Price) : testsInOrder.Sum(x => x.WithPackagePrice);

            if (!enableAlaCarte || (!testsInOrder.IsNullOrEmpty() && !tests.IsNullOrEmpty() && testsInOrder.Select(t => t.TestId).Any(t => !tests.Select(te => te.TestId).Contains(t))))
            {
                EnableChangePackage(theEvent);
                return false;
            }

            if (newEventPackage != null)
                newOrderTestPrice = tests.Where(x => independentTestIds.Contains(x.TestId)).Sum(x => x.WithPackagePrice);
            else
                newOrderTestPrice = tests.Where(x => independentTestIds.Contains(x.TestId)).Sum(x => x.Price);
        }

        if (package != null && newEventPackage != null)
        {
            ShowDiffrencesesInPackage(newEventPackage, package);
        }

        if ((package != null && newEventPackage != null && package.Price != newEventPackage.Price) || orderTestPrice != newOrderTestPrice)
        {
            var testids = newEventPackage == null ? new List<long>() : newEventPackage.Tests.Select(x => x.TestId);
            var selectedTestIds = new List<long>();

            var pacakgePrice = newEventPackage == null ? 0 : newEventPackage.Price;
            selectedTestIds.AddRange(testids);
            selectedTestIds.AddRange(independentTestIds);

            PackageIdHiddenControl.Text = package != null ? package.PackageId.ToString() : "0";
            TestIdsHiddenControl.Text = string.Join(", ", selectedTestIds);
            CurrentOrderPriceHiddenControl.Text = (pacakgePrice + newOrderTestPrice).ToString("0.00");
            IndependentTestIdsHiddenControl.Text = string.Join(", ", independentTestIds);
            OrderChangedHiddenControl.Text = "true";

            SetPaymentDetails(eventid);
        }

        return true;
    }

    private void SetPaymentDetails(long eventId)
    {
        ChangePackage = true;
        ShowPackagePopup = false;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_showHideProcessPaymentbtn", "showHideProcessPaymentbtn(true);", true);

        if (eventId > 0)
        {
            SetNewOrderDetails(eventId);
            appointmentPaymentControl.Visible = true;
            var slotIds = _ucEventAppointment1.GetAppointmentIds();

            appointmentPaymentControl.SelectedPackageId = PackageIdHiddenControl.Text;
            appointmentPaymentControl.SelectedTestIds = TestIdsHiddenControl.Text;
            appointmentPaymentControl.SelectedIndependentTestIds = IndependentTestIdsHiddenControl.Text;
            appointmentPaymentControl.NewEventId = hfNewEventID.Text;
            appointmentPaymentControl.NewHfSlotIds = slotIds.IsNullOrEmpty() ? "0" : string.Join(",", slotIds);
            appointmentPaymentControl.SetIntialData(eventId, CustomerId, EventCustomerId, EventId);
        }
        else
        {
            appointmentPaymentControl.Visible = false;
        }
    }

    private void ShowDiffrencesesInPackage(EventPackage newEventPackage, EventPackage oldEventPackage)
    {
        var missingTestNames = GetTestDiffrencesBetweenTwoPackages(oldEventPackage, newEventPackage);
        var newTestNames = GetTestDiffrencesBetweenTwoPackages(newEventPackage, oldEventPackage);
        bool showPopup = false;

        differenceOfTests.Visible = false;
        missingTestPanel.Visible = false;
        newTestPanel.Visible = false;

        if (!string.IsNullOrEmpty(missingTestNames) && !string.IsNullOrEmpty(newTestNames))
        {
            differenceOfTests.Visible = true;
            testNotAvilable.InnerText = missingTestNames;
            newTestAdded.InnerText = newTestNames;
            showPopup = true;
        }
        else
        {
            if (!string.IsNullOrEmpty(missingTestNames))
            {
                missingTestPanel.Visible = true;
                TestMissingInPackage.InnerText = missingTestNames;
                showPopup = true;
            }

            if (!string.IsNullOrEmpty(newTestNames))
            {
                newTestPanel.Visible = true;
                newTestInPackage.InnerText = newTestNames;
                showPopup = true;
            }
        }

        if (showPopup)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_showDiffrenceInPackagesPopup", "ShowDiffrenceInPackagesPopup();", true);
        }

    }

    private string GetTestDiffrencesBetweenTwoPackages(EventPackage oldEventPackage, EventPackage newEventPackage)
    {
        var newPackageTestIds = newEventPackage.Tests.Select(x => x.TestId);
        var oldPackageTestIds = oldEventPackage.Tests.Select(x => x.TestId);
        var missingTestNames = string.Empty;

        var missingTestIds = oldPackageTestIds.Where(x => !newPackageTestIds.Contains(x));

        if (!missingTestIds.IsNullOrEmpty())
        {
            if (!missingTestIds.IsNullOrEmpty())
            {
                missingTestNames = string.Join(",", oldEventPackage.Tests.Where(x => missingTestIds.Contains(x.TestId)).Select(x => x.Test.Name));
            }
        }

        return missingTestNames;
    }

    protected void ibtnVerifyInvitation_Click(object sender, ImageClickEventArgs e)
    {
        // verifiy events
        long eventId = 0;
        if (!string.IsNullOrEmpty(hfNewEventID.Text.Trim()))
        {
            eventId = Convert.ToInt64(hfNewEventID.Text);
        }
        var invitationCode = txtInvitationCode.Text.Trim();

        IEventRepository eventRepository = new EventRepository();

        if (!eventRepository.ValidateInvitationCode(eventId, invitationCode))
        {
            divErrorMsg.InnerHtml = "You had enter the wrong invitation code.<br> Please enter correct invitation code and try again.";
            divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
            divErrorMsg.Visible = true;
            return;
        }

        if (!EventValidation(eventId)) return;

        if (IsCustomerTagSame(eventId)) return;

        ShowAppointmentPannel();
    }

    protected void ChangePackage_Click()
    {
        long eventId = 0;

        if (!string.IsNullOrEmpty(hfNewEventID.Text))
        {
            eventId = Convert.ToInt64(hfNewEventID.Text);
        }

        ItemCartControl.Visible = false;

        SetPaymentDetails(eventId);
        ShowAppointmentPannel();
    }

    private int ParseIntoInt(string stringToParse)
    {
        int tempValue;
        int.TryParse(stringToParse, out tempValue);

        return tempValue;
    }

    private bool IsCustomerTagSame(long eventid)
    {
        var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();

        var customerTag = Customer.Tag;
        if (!string.IsNullOrEmpty(customerTag))
        {
            var corporateAccount = corporateAccountRepository.GetbyEventId(eventid);
            if (corporateAccount == null || string.IsNullOrEmpty(corporateAccount.Tag))
            {
                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "You are scheduling a " + customerTag + "  member for a retail event.  This is NOT ALLOWED. Please contact administrator.";
                //Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customerTag + "','');", true);
                return true;
            }

            if (customerTag != corporateAccount.Tag)
            {
                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "You are scheduling a " + customerTag + "  member for a " + corporateAccount.Tag + " event.  This is NOT ALLOWED. Please contact administrator.";
                //Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customerTag + "','" + corporateAccount.Tag + "','" + corporateAccount.AllowRegistrationWithImproperTags + "');", true);
                return true;
            }
        }
        return false;
    }
    private void SetNewOrderDetails(long newEventId)
    {
        var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();

        var eventTestRepository = IoC.Resolve<EventTestRepository>();

        var order = string.Empty;
        decimal orderPrice = 0m;
        var packageId = ParseIntoInt(PackageIdHiddenControl.Text);

        if (packageId > 0)
        {
            var eventPacakge = eventPackageRepository.GetByEventAndPackageIds(newEventId, packageId);

            order = eventPacakge.Package.Name;
            orderPrice = eventPacakge.Price;
        }

        if (!string.IsNullOrEmpty(IndependentTestIdsHiddenControl.Text.Trim()))
        {
            var aditionalTests = IndependentTestIdsHiddenControl.Text.Trim().Split(',');

            aditionalTests = aditionalTests.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (!aditionalTests.IsNullOrEmpty())
            {
                var testIds = aditionalTests.Select(long.Parse);
                var eventTest = eventTestRepository.GetByEventAndTestIds(newEventId, testIds);

                if (!eventTest.IsNullOrEmpty())
                {
                    if (string.IsNullOrEmpty(order))
                    {
                        order = string.Join(", ", eventTest.Select(x => x.Test.Name));
                    }
                    else
                    {
                        order = order + ", " + string.Join(", ", eventTest.Select(x => x.Test.Name));
                    }
                    if (packageId > 0)
                        orderPrice += eventTest.Sum(test => test.WithPackagePrice);
                    else
                        orderPrice += eventTest.Sum(test => test.Price);
                }
            }
        }
        orderpaneldiv.Visible = true;
        spNewpackagename.InnerText = order;
        spNewPackagecost.InnerText = orderPrice.ToString("0.00");
    }

    private void UpdateEventCustomerPreApprovedTest(long eventId, long customerId)
    {
        IoC.Resolve<IEventCustomerPreApprovedTestService>().UpdateEventCustomerPreApprovedTest(eventId, customerId);
    }

    private void DeleteEventCustomerCheckListAnswers(long eventId, long customerId)
    {
        var eventCustomer = IoC.Resolve<EventCustomerRepository>().Get(eventId, customerId);
        if (eventCustomer != null)
            IoC.Resolve<ICheckListAnswerRepository>().DeleteEventCustomerCheckListAnswers(eventCustomer.Id);
    }

    private bool CheckPreApprovedTest(IEnumerable<long> testIdsToCheck)
    {
        var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
        return preApprovedTestRepository.CheckPreApprovedTestForCustomer(CustomerId, testIdsToCheck);
    }

    private void BindEventSearchDropdown(Customer customer)
    {
        BindZipRadiusDropdown();

        if (string.IsNullOrEmpty(customer.Tag) && !CustomerHasMammoTest)
        {
            spEventSearchType.Style.Add(HtmlTextWriterStyle.Display, "none");
            EventSearchTypeDropdownList.Items.Clear();
            EventSearchTypeDropdownList.Visible = false;
            return;
        }

        var filterTypes = new List<OrderedPair<string, string>> { new OrderedPair<string, string>(EventSearchFilterType.All.ToString(), EventSearchFilterType.All.GetDescription()) };
        var selectedValue = EventSearchFilterType.All.ToString();

        if (!string.IsNullOrEmpty(customer.Tag))
        {
            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = corporateAccountRepository.GetByTag(customer.Tag);
            if (account != null)
            {
                if (account.IsHealthPlan)
                {
                    filterTypes.Add(new OrderedPair<string, string>(EventSearchFilterType.HealthPlan.ToString(), EventSearchFilterType.HealthPlan.GetDescription()));
                    selectedValue = EventSearchFilterType.HealthPlan.ToString();
                }
                else
                {
                    filterTypes.Add(new OrderedPair<string, string>(EventSearchFilterType.Corporate.ToString(), EventSearchFilterType.Corporate.GetDescription()));
                    selectedValue = EventSearchFilterType.Corporate.ToString();
                }
            }
        }

        //if (CustomerHasMammoTest)
        //{
        //    filterTypes.Add(new OrderedPair<string, string>(EventSearchFilterType.Mammo.ToString(), EventSearchFilterType.Mammo.GetDescription()));
        //    selectedValue = EventSearchFilterType.Mammo.ToString();
        //}

        EventSearchTypeDropdownList.Items.Clear();
        EventSearchTypeDropdownList.DataSource = filterTypes;
        EventSearchTypeDropdownList.DataTextField = "SecondValue";
        EventSearchTypeDropdownList.DataValueField = "FirstValue";
        EventSearchTypeDropdownList.SelectedValue = selectedValue;
        EventSearchTypeDropdownList.DataBind();

    }

    public string GetSubReason()
    {
        var rescheduleCancelDispositionRepository = IoC.Resolve<IRescheduleCancelDispositionRepository>();
        var lookupIds = RescheduleAppointmentReason.HealthFairReason.GetNameValuePairs().Select(x => (long)x.FirstValue).ToArray();
        var subReasons = rescheduleCancelDispositionRepository.GetByLookupIds(lookupIds);

        return new System.Web.Script.Serialization.JavaScriptSerializer()
            .Serialize(subReasons.Select(x => new { Id = x.Id, DisplayName = x.DisplayName, LookupId = x.LookupId, RelativeOrder = x.RelativeOrder }).OrderBy(x => x.DisplayName));
    }

    private void BindZipRadiusDropdown()
    {
        var zipRadius = Falcon.App.Core.Geo.Enum.ZipRadius.FiveMiles.GetNameValuePairs().OrderBy(x => x.FirstValue);
        ZipRadius.DataSource = zipRadius;
        ZipRadius.DataTextField = "SecondValue";
        ZipRadius.DataValueField = "FirstValue";
        ZipRadius.DataBind();
        ZipRadius.Items.Insert(0, new ListItem("-- Miles --", "0"));
    }
}
