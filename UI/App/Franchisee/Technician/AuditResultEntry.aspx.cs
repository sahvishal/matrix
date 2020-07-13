using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Service;
using Falcon.App.UI.App.BasePageClass;
using HealthYes.Web.App.Franchisee.Technician;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class AuditResultEntry : BasePage
    {
        protected enum SaveType { ApproveAllAndClose, ApproveAllAndNext };

        protected enum EditResultMode { ResultEntry = 1, ResultPreAudit = 2, ResultCorrection = 3 }

        protected EditResultMode Mode
        {
            get
            {
                if (Request.QueryString["Correction"] != null)
                {
                    return EditResultMode.ResultCorrection;
                }

                return Request.QueryString[0].ToLower() == "modeaudit" ? EditResultMode.ResultPreAudit : EditResultMode.ResultEntry;
            }
        }
        public long RoleId { get; set; }

        public OrganizationRoleUserModel CurrentOrgUser
        {
            get { return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole; }
        }

        protected bool SendToOvereadPhysician = false;

        protected int CustomerId
        {
            get
            {
                return String.IsNullOrEmpty(Request.QueryString["CustomerId"]) ? 0 : Convert.ToInt32(Request.QueryString["CustomerId"]);
            }
        }

        protected int EventId
        {
            get
            {
                return String.IsNullOrEmpty(Request.QueryString["EventId"]) ? 0 : Convert.ToInt32(Request.QueryString["EventId"]);
            }
        }

        protected bool IsMedicare
        {
            get
            {
                return !String.IsNullOrEmpty(Request.QueryString["IsMedicare"]) && Convert.ToBoolean(Request.QueryString["IsMedicare"]);
            }
        }

        protected bool CaptureHaf
        {
            get;
            set;
        }

        protected bool ShowCheckList
        {
            get;
            set;
        }

        protected bool ShowHideFastingStatus { get; set; }

        protected bool CapturePcpConsent
        {
            get;
            set;
        }

        private void GetConductedbyData(Event eventData)
        {
            var eventStaffAssignementRepository = IoC.Resolve<IEventStaffAssignmentRepository>();
            var eventStaffCollection = eventStaffAssignementRepository.GetForEvent(EventId);
            ClientScript.RegisterStartupScript(Page.GetType(), "js_DefaultStaff", "var defaultStaffCollection = null; ", true);
            if (eventStaffCollection != null && eventStaffCollection.Count() > 0)
            {
                var rolesRepository = IoC.Resolve<IEventRoleRepository>();
                var staffRoles = rolesRepository.GetByIds(eventStaffCollection.Select(s => s.StaffEventRoleId).ToArray());

                var orderedPairCollection = new List<OrderedPair<long, long>>();
                foreach (var staffEventRole in staffRoles)
                {
                    var eventStaffMember =
                        eventStaffCollection.Where(st => st.StaffEventRoleId == staffEventRole.Id).First();

                    foreach (var allowedTestId in staffEventRole.AllowedTestIds)
                    {
                        if (orderedPairCollection.Where(op => op.FirstValue == allowedTestId).Count() > 0) continue;
                        orderedPairCollection.Add(new OrderedPair<long, long>(allowedTestId, eventStaffMember.ActualStaffOrgRoleUserId ?? eventStaffMember.ScheduledStaffOrgRoleUserId));
                    }
                }

                if (orderedPairCollection.Count > 0)
                    ClientScript.RegisterStartupScript(Page.GetType(), "js_DefaultStaff_1", "defaultStaffCollection = " + new JavaScriptSerializer().Serialize(orderedPairCollection) + "; ", true);

                var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var nameIdPairs = orgRoleUserRepository.GetNameIdPairofUsersByEventDate(eventStaffCollection.Select(s => (s.ActualStaffOrgRoleUserId ?? s.ScheduledStaffOrgRoleUserId)).ToArray(), eventData.EventDate);

                Conductedby.DataTextField = "SecondValue";
                Conductedby.DataValueField = "FirstValue";
                Conductedby.DataSource = nameIdPairs;
                Conductedby.DataBind();

                Conductedby.Items.Insert(0, new ListItem("--Conducted By--", "-1"));
            }

        }

        protected bool IsNewResultFlow { get; set; }

        protected bool ShowHraQuestionnaire { get; set; }

        protected bool IsChartSignedOff { get; set; }

        protected bool IsEawvTestPurchased { get; set; }

        protected bool IsHealthPlanEvent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initial Code just to hide left hand side panel for this page.
            var masterPage = (TecnicianManualEntry)Page.Master;
            if (masterPage != null) masterPage.HideLeftContainer = true;

            var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = accountRepository.GetbyEventId(EventId);
            CaptureHaf = (account == null || account.CaptureHaf);

            CapturePcpConsent = (account != null && account.CapturePcpConsent);
            IsHealthPlanEvent = (account != null && account.IsHealthPlan);

           
            //var communicationRepository = IoC.Resolve<ICommunicationRepository>();
            EventCustomer eventCustomer = null;
            //var lastCommentAdded = communicationRepository.GetCommentsforPhysician(CustomerId, EventId);

            if (!IsPostBack)
            {
                var setting = IoC.Resolve<ISettings>();
                var eventsRepository = IoC.Resolve<IEventRepository>();
                var eventData = eventsRepository.GetById(EventId);
                eventCustomer = IoC.Resolve<IEventCustomerRepository>().Get(EventId, CustomerId);
                var eventCustomerId = eventCustomer.Id;

                var purchasedTest = IoC.Resolve<ITestResultService>().TestPurchasedByCustomer(eventCustomerId);
                var iseawvTestPurchased = IsEawvTestPurchased = purchasedTest != null ? purchasedTest.Any(x => x.Id == (long)TestType.eAWV) : false;

                IsNewResultFlow = eventData.EventDate >= setting.ResultFlowChangeDate;
                if (IsNewResultFlow)
                    ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "true");
                else
                    ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "false");

                var questionnaireType = QuestionnaireType.None;
                if (account != null && account.IsHealthPlan && eventData != null)
                {
                    questionnaireType = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>().QuestionnaireTypeByAccountIdandEventDate(account.Id, eventData.EventDate);
                }

                var isShowHraQuestioner = questionnaireType == QuestionnaireType.HraQuestionnaire;

                if (eventData.EventDate < setting.ChecklistChangeDate)
                    ShowCheckList = (account != null && account.PrintCheckList);

                var mediaLocation = IoC.Resolve<IMediaRepository>().GetResultMediaFileLocation(CustomerId, EventId);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "js_Location_Url", "function getLocationPrefix() { return '" + mediaLocation.PhysicalPath.Replace("\\", "\\\\") + "'; } function getUrlPrefix() { return '" + mediaLocation.Url + "'; }", true);

                GetConductedbyData(eventData);
                FillStates();

                var currentSession = IoC.Resolve<ISessionContext>();

                ClientScript.RegisterHiddenField("hfTechnicianId", currentSession.UserSession.CurrentOrganizationRole.OrganizationRoleUserId.ToString());
                ClientScript.RegisterHiddenField("hfOrganizationId", currentSession.UserSession.CurrentOrganizationRole.OrganizationId.ToString());

                string pageHeading = "";

                var basicBiometricCutOfDate = setting.BasicBiometricCutOfDate;
                var hideBasicBiometric = (eventData.EventDate.Date >= basicBiometricCutOfDate);
                ShowHideFastingStatus = (eventData.EventDate.Date >= setting.FastingStatusDate);
                BasicBiometric.ShowByCutOffDate = !hideBasicBiometric;

                TestSection.SetSectionShowHide(hideBasicBiometric);

                if (currentSession != null && currentSession.UserSession != null && currentSession.UserSession.CurrentOrganizationRole != null)
                    RoleId = currentSession.UserSession.CurrentOrganizationRole.GetSystemRoleId;


                if (Mode == EditResultMode.ResultCorrection)
                {
                    var result = new CommunicationRepository().GetPhysicianandCommentsforFranchisee(CustomerId, EventId);
                    if (!string.IsNullOrEmpty(result.SecondValue))
                    {
                        PhysicianCommentsDiv.Visible = true;
                        PhysicianCommentsMessageBox.ShowErrorMessage("<b><u>Physician Comments:</u> </b>" + result.SecondValue);
                    }

                    updateWithCorrectionDivTop.Visible = true;
                    saveDivTop.Visible = false;
                    approveDivtop.Visible = false;

                    updateWithCorrectionsDivbottom.Visible = true;
                    saveDivbottom.Visible = false;
                    approveDivbottom.Visible = false;

                    var physicianService = IoC.Resolve<IPhysicianAssignmentService>();
                    var physicianIds = physicianService.GetPhysicianIdsAssignedtoaCustomer(EventId, CustomerId);
                    if (physicianIds != null && result.FirstValue > 0 && physicianIds.Count() == 2 && physicianIds.ElementAt(1) == result.FirstValue)
                    {
                        SendToOvereadPhysician = true;
                    }

                    ClientScript.RegisterHiddenField("ResultStatusInputHidden", "4");

                    pageHeading = "Results Update/Correction";
                }


                if (Mode == EditResultMode.ResultPreAudit) // && isTechTeamConfigured == true)
                {
                    ClientScript.RegisterHiddenField("ResultStatusInputHidden", "4");
                    pageHeading = "Results Pre Audit";

                    saveDivTop.Visible = false;
                    saveDivbottom.Visible = false;

                    if (TestSection.ContainsReviewableTests && !IsNewResultFlow)
                    {
                        skipevaluationdivbottom.Visible = true;
                    }

                    var customerHealthInfo = IoC.Resolve<IHealthAssessmentRepository>().Get(CustomerId, EventId);
                    if (!CaptureHaf || (customerHealthInfo != null && customerHealthInfo.Any()))
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "js_setmedicalhistory", "setMedicalHistory();", true);
                    }

                    var defaultPhysician = IoC.Resolve<IPhysicianRepository>().GetDefaultPhysicianforEvent(EventId);
                    ClientScript.RegisterHiddenField("DefaultPhysician", defaultPhysician.ToString());

                    //var eventCustomerId = IoC.Resolve<IEventCustomerRepository>().Get(EventId, CustomerId).Id;
                    var isCustomerSkipped = IoC.Resolve<IPhysicianEvaluationRepository>().IsMarkedReviewSkip(eventCustomerId);
                    if (isCustomerSkipped)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "js_markcustomerskipped", "$('#skipevaluationcheckbox').attr('checked', true);", true);
                    }

                }
                else if (Mode == EditResultMode.ResultEntry)
                {


                    if (IsNewResultFlow)
                        ClientScript.RegisterHiddenField("ResultStatusInputHidden", "2");
                    else
                        ClientScript.RegisterHiddenField("ResultStatusInputHidden", "3");

                    pageHeading = "Results Edit/Entry";

                    approveDivtop.Visible = false;
                    approveDivbottom.Visible = false;

                }

                HeadingSpan.InnerHtml = pageHeading;

                if (Request.UrlReferrer.AbsolutePath.ToLower().IndexOf("auditresultentry.aspx") < 0)
                    Session["ReferredUrlFirstTimeOpen"] = Request.UrlReferrer;

                CreateIFJSArrays();
                CreateJsArrayforIfuCs();

                //var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var goBackToResultEnteryPage = false;

                EventCustomerResult eventCustomerResult = IoC.Resolve<IEventCustomerResultRepository>().GetByCustomerIdAndEventId(CustomerId, EventId); ;

                if ((Mode == EditResultMode.ResultEntry))
                {
                    if (IsCustomerNoShowOrLeftWithoutScreening(eventCustomer))
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "js_NextCustomer", "customerMarkNoShow();", true);
                        goBackToResultEnteryPage = true;
                    }
                    else
                    {
                        var nextCustomerId = new TestResultRepository().GetNextCustomerEntryandAudit(EventId, CustomerId, IsNewResultFlow);
                        ClientScript.RegisterStartupScript(Page.GetType(), "js_NextCustomer", "setnextCustomerId(" + nextCustomerId + ");", true);
                    }
                }
                else
                {
                    var isChartSignedOff = true;
                    var isQvTestPurchased = purchasedTest != null ? purchasedTest.Any(x => x.Id == (long)TestType.Qv) : false;
                    var isHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire;
                   
                    if (questionnaireType == QuestionnaireType.ChatQuestionnaire)
                    {
                        isChartSignedOff = isQvTestPurchased || (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue);
                    }
                    else
                    {
                        var isEawvTestNotPerformed = IoC.Resolve<ITestNotPerformedRepository>().IsTestNotPerformed(eventCustomer.Id, (long)TestType.eAWV);
                        isChartSignedOff = (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue) || !isShowHraQuestioner || !iseawvTestPurchased || isEawvTestNotPerformed;

                    }
                    IsChartSignedOff = (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue);
                    if (!IsNewResultFlow || isChartSignedOff)
                    {
                        if (IsCustomerNoShowOrLeftWithoutScreening(eventCustomer))
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "js_NextCustomer", "customerMarkNoShow();", true);
                            goBackToResultEnteryPage = true;
                        }
                        else
                        {
                            long nextCustomerId = 0;
                            if (IsNewResultFlow && account != null && (questionnaireType != QuestionnaireType.None))
                            {
                                nextCustomerId = new TestResultRepository().GetNextCustomerForPreAudit(EventId, CustomerId, isHraQuestionnaire);
                            }
                            else
                            {
                                nextCustomerId = new TestResultRepository().GetNextCustomerEntryandAudit(EventId, CustomerId, IsNewResultFlow);
                            }

                            ClientScript.RegisterStartupScript(Page.GetType(), "js_NextCustomer", "setnextCustomerId(" + nextCustomerId + ");", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "js_NextCustomer", "customerChartIsUnsigned();", true);
                    }

                    //if (eventCustomerResult != null && IsNewResultFlow)
                    //{
                    //    var notes = communicationRepository.GetNotesForReversal(eventCustomerResult.Id);
                    //    if (!string.IsNullOrWhiteSpace(notes))
                    //    {
                    //        revertBackNotes.Visible = true;
                    //        ReasonToRevert.InnerText = notes;
                    //    }
                    //}
                }

                if (!goBackToResultEnteryPage)
                {

                    if (eventCustomerResult != null)
                    {
                        //LogAudit(ModelType.View, eventCustomerResult);
                        var priorityInQueue =
                            IoC.Resolve<IPriorityInQueueRepository>().GetByEventCustomerResultId(eventCustomerResult.Id);
                        if (priorityInQueue != null && priorityInQueue.InQueuePriority > 0)
                        {
                            if (!CurrentOrgUser.CheckRole((long)Roles.Technician))
                            {
                                PriorityInQueueCheckbox.Checked = true;
                            }

                            if (priorityInQueue.NoteId == null) return;
                            var noteText = IoC.Resolve<INotesRepository>().Get(priorityInQueue.NoteId.Value);
                            if (noteText != null && !string.IsNullOrEmpty(noteText.Text))
                            {
                                PriorityInQueueText.InnerText = noteText.Text;
                                PriorityInQueueReasonDisplayDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                            }
                            else if (!CurrentOrgUser.CheckRole((long)Roles.Technician))
                            {
                                PriorityInQueueReasonDisplayDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                            }
                        }
                        else
                        {
                            PriorityInQueueCheckbox.Checked = false;
                            PriorityInQueueReasonDisplayDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                        }
                    }
                    else
                    {
                        PriorityInQueueCheckbox.Checked = false;
                        PriorityInQueueReasonDisplayDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }

            }
        }

        //private void GetSmokerDiabeticInformation()
        //{
        //    //Sandeep: Not in use for Healthfair, PHS, Integra. Hence commented it.
        //    //IFraminghamRiskCalculationRepository framinghamRiskCalculationRepository =
        //    //    new FraminghamRiskCalculationRepository();
        //    //OrderedPair<bool, bool> smokerDiabeticInformation =
        //    //    framinghamRiskCalculationRepository.GetSmokerDiabeticInformation(CustomerId);
        //    //if (smokerDiabeticInformation == null)
        //    //{
        //    //    SmokerInfo.Value = string.Empty;
        //    //    DiabeticInfo.Value = string.Empty;
        //    //}
        //    //else
        //    //{
        //    //    SmokerInfo.Value = smokerDiabeticInformation.FirstValue.ToString();
        //    //    DiabeticInfo.Value = smokerDiabeticInformation.SecondValue.ToString();
        //    //}
        //}

        protected string RedirecttoReferrerPageUrl()
        {
            string pageUrl = "/App/Franchisee/Technician/TechnicianEventCustomerResult.aspx?EventID=" + EventId;
            if (Session["ReferredUrlFirstTimeOpen"] != null)
                pageUrl = Session["ReferredUrlFirstTimeOpen"].ToString();

            if (pageUrl.ToLower().IndexOf("customerresult.aspx") >= 0)
            {
                var a = new Uri(pageUrl);
                if (a.Query.ToLower().IndexOf("event") >= 0)
                    return pageUrl;

                if (a.Query.Length > 0)
                    return pageUrl + "&EventId=true";

                return pageUrl + "?EventId=true";
            }
            return pageUrl;
        }

        private void FillStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var countryRepository = IoC.Resolve<ICountryRepository>();

            var countries = countryRepository.GetAll();

            CountryDropDown.DataTextField = "Name";
            CountryDropDown.DataValueField = "Id";
            CountryDropDown.DataSource = countries;
            CountryDropDown.DataBind();

            CountryDropDown.Items.Insert(0, new ListItem("-- Select --", "0"));

            var states = stateRepository.GetAllStates();

            var javascriptSerializer = new JavaScriptSerializer();
            var serialized = javascriptSerializer.Serialize(states);

            //pcp State-Country 
            pcpCountryDropDown.DataTextField = "Name";
            pcpCountryDropDown.DataValueField = "Id";
            pcpCountryDropDown.DataSource = countries;
            pcpCountryDropDown.DataBind();

            pcpCountryDropDown.Items.Insert(0, new ListItem("-- Select --", "0"));


            pcpMailingcountryDropDown.DataTextField = "Name";
            pcpMailingcountryDropDown.DataValueField = "Id";
            pcpMailingcountryDropDown.DataSource = countries;
            pcpMailingcountryDropDown.DataBind();

            pcpMailingcountryDropDown.Items.Insert(0, new ListItem("-- Select --", "0"));

            ClientScript.RegisterStartupScript(Page.GetType(), "js_Country_State", " var stateCountryList = " + serialized + ";", true);
        }

        private void CreateIFJSArrays()
        {
            IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
            var incidentalFindingGroup = incidentalFindingrepository.GetAllIncidentalFindingGroup();

            var isRegistered = false;
            var incidentalFinding = incidentalFindingrepository.GetAllIncidentalFinding().ToList();

            incidentalFindingGroup.ForEach(ifGroup =>
            {
                if (ifGroup.Id == (int)IncidentalFindingGroupType.SonographicAppearance)
                {
                    ifGroup.GroupItems.ForEach(groupItem =>
                    {
                        Page.ClientScript.RegisterArrayDeclaration("js_arrSonographicAppearanceLabel", "'" + groupItem.Label + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrSonographicAppearanceID", groupItem.Id.ToString());
                    });
                }

                if (ifGroup.Id == (int)IncidentalFindingGroupType.AbdominalLocation || ifGroup.Id == (int)IncidentalFindingGroupType.KidneyLocation
                    || ifGroup.Id == (int)IncidentalFindingGroupType.LiverLocation || ifGroup.Id == (int)IncidentalFindingGroupType.ThyriodLocation)
                {
                    var selectedIfs = incidentalFinding.FindAll(ifinding =>
                    {
                        var findingGroup = ifinding.IncidentalFindingGroups.Find(group => group.Id == ifGroup.Id);
                        if (findingGroup != null) return true;

                        return false;
                    });

                    selectedIfs.ForEach(selectedIf => ifGroup.GroupItems.ForEach(groupItem =>
                                                                                     {
                                                                                         Page.ClientScript.RegisterArrayDeclaration("js_arrIFLocationsLabel", "'" + groupItem.Label + "'");
                                                                                         Page.ClientScript.RegisterArrayDeclaration("js_arrIFLocationsID", groupItem.Id.ToString());
                                                                                         Page.ClientScript.RegisterArrayDeclaration("js_arrIFID", selectedIf.Id.ToString());
                                                                                     }));
                }

                if (ifGroup.Id == (int)IncidentalFindingGroupType.Size)
                {
                    Page.ClientScript.RegisterHiddenField("js_if_size", ifGroup.GroupItems.First().Id.ToString());
                }
                if (ifGroup.Id == (int)IncidentalFindingGroupType.Notes)
                {
                    var selectedIfs = incidentalFinding.FindAll(ifinding =>
                    {
                        var findingGroup = ifinding.IncidentalFindingGroups.Find(group => group.Id == ifGroup.Id);
                        if (findingGroup != null) return true;
                        return false;
                    });

                    selectedIfs.ForEach(selectedIf => ifGroup.GroupItems.ForEach(groupItem =>
                    {
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFGroupItemId", "'" + groupItem.Id.ToString() + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFGroupId", "'" + ifGroup.Id.ToString() + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFID", "'" + selectedIf.Id.ToString() + "'");
                        isRegistered = true;
                    }));

                }
                if (ifGroup.Id == (int)IncidentalFindingGroupType.KidneyStones)
                {
                    Page.ClientScript.RegisterHiddenField("js_if_kidney", ifGroup.GroupItems.First().Id.ToString());
                }
            });

            if (!isRegistered)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_Array", "var js_arrIFGroupItemId = new Array(); var js_arrIFGroupId = new Array(); var js_arrIFID = new Array();", true);
            }
        }

        private void CreateJsArrayforIfuCs()
        {
            Page.ClientScript.RegisterArrayDeclaration("js_arrIFUCLabel", "'ucIFCommon.ascx'");
            Page.ClientScript.RegisterArrayDeclaration("js_arrIFUCLabel", "'ucIFLocationWise.ascx'");
            Page.ClientScript.RegisterArrayDeclaration("js_arrIFUCLabel", "'ucIFLocationWiseforKidney.ascx'");
        }


        [WebMethod(EnableSession = true)]
        public static bool SaveSmokerDiabeticInformation(long customerId, bool isSmoker, bool isDiabetic)
        {
            IFraminghamRiskCalculationRepository framinghamRiskCalculationRepository =
                new FraminghamRiskCalculationRepository();
            return framinghamRiskCalculationRepository.SaveSmokerDiabeticInformation(customerId,
                                                                                     isSmoker,
                                                                                     isDiabetic);
        }

        [WebMethod(EnableSession = true)]
        public static decimal? GetFraminghamRisk(int age, bool isGenderMale, int? totalCholestrol, int hdl, int? ldl, int systolic,
                                                            int diastolic, bool isSmoker, bool isDiabetic)
        {
            var testResultService = new TestResultService();
            return testResultService.GetFraminghamRisk(age, isGenderMale, totalCholestrol, hdl, ldl, systolic, diastolic, isSmoker, isDiabetic);
        }

        [WebMethod(EnableSession = true)]
        public static void UpdateRecordforSkipEvaluation(long eventId, long customerId, bool isNewResultFlow)
        {
            try
            {
                //Call API for mark can not be audited now.

                var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                var eventCustomer = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomer == null) return;
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                var defaultPhysician = IoC.Resolve<IPhysicianRepository>().GetDefaultPhysicianforEvent(eventId);
                var orgRoleId = currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
                IoC.Resolve<IPhysicianEvaluationRepository>().SaveCustomerforReviewSkip(eventCustomer.Id, defaultPhysician, orgRoleId, true);
                var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(eventId);

                var questionnaireType = QuestionnaireType.None;

                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(eventId);

                if (account != null && theEvent != null)
                {
                    var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                    questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                }

                var isEawvTestPurchased = IoC.Resolve<TestResultService>().IsTestPurchasedByCustomer(eventCustomer.Id, (long)TestType.eAWV);

                var testResultRepository = new TestResultRepository();

                var isEawvTestNotPerformed = IoC.Resolve<ITestNotPerformedRepository>().IsTestNotPerformed(eventCustomer.Id, (long)TestType.eAWV);
                if (defaultPhysician > 0)
                {
                    if (isNewResultFlow)
                    {
                        var testResultService = IoC.Resolve<ITestResultService>();

                        if (account == null || account.IsHealthPlan == false || isEawvTestNotPerformed || questionnaireType != QuestionnaireType.HraQuestionnaire)
                        {
                            testResultService.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.ArtifactSynced, false, orgRoleId);
                        }
                        else
                        {
                            testResultService.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.NpSigned, false, orgRoleId);
                        }
                    }
                    else
                    {
                        testResultRepository.UpdateStateforSkipEvaluation(eventCustomer.Id, defaultPhysician);
                        eventCustomerResultRepository.SetEventCustomerResultState(eventId, customerId);
                    }
                }

                if (isNewResultFlow && account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire) && isEawvTestPurchased && !isEawvTestNotPerformed)
                {
                    var service = IoC.Resolve<INewResultFlowStateService>();

                    var model = new EhrReadyforCodingViewModel
                    {
                        EventId = eventId,
                        HfCustomerId = customerId,
                        ReadyForCoding = true
                    };

                    service.RunTaskReadyForCodingForVisit(model, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "UpdateRecordforSkipEvaluation");
                }

                //Call API for Ready for coding
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Exception occured while recording for Skip Evaluation! Message:" + ex.Message + "\n\t " + ex.StackTrace);
            }
        }

        [WebMethod(EnableSession = true)]
        public static void SkipEvaluationfornotContainingReviewableTest(long eventId, long customerId, bool isNewResultFlow)
        {
            try
            {
                //Call API for mark can not be audited now.

                var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                var eventCustomer = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                var defaultPhysician = IoC.Resolve<IPhysicianRepository>().GetDefaultPhysicianforEvent(eventId);
                var orgRoleId = currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
                IoC.Resolve<IPhysicianEvaluationRepository>().SaveCustomerforReviewSkip(eventCustomer.Id, defaultPhysician, orgRoleId, false);
                var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(eventId);
                var isEawvTestPurchased = IoC.Resolve<TestResultService>().IsTestPurchasedByCustomer(eventCustomer.Id, (long)TestType.eAWV);
                var isEawvTestNotPerformed = IoC.Resolve<ITestNotPerformedRepository>().IsTestNotPerformed(eventCustomer.Id, (long)TestType.eAWV);
                var testResultRepository = new TestResultRepository();

                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(eventId);

                var orderId = IoC.Resolve<IOrderRepository>().GetOrderIdByEventIdCustomerId(eventId, customerId);
                var isEntrybyHip = IoC.Resolve<IEventTestRepository>().GetTestsForOrder(orderId).Any(et => et.ResultEntryTypeId.HasValue == false || et.ResultEntryTypeId.Value == (long)ResultEntryType.Hip);

                var questionnaireType = QuestionnaireType.None;
                if (account != null && theEvent != null)
                {
                    var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                    questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                }

                if (isNewResultFlow)
                {
                    var testResultService = IoC.Resolve<ITestResultService>();
                    if (!isEntrybyHip)
                    {
                        testResultService.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.ArtifactSynced, false, orgRoleId);
                    }
                    else
                    {
                        if (account == null || account.IsHealthPlan == false || isEawvTestNotPerformed || questionnaireType != QuestionnaireType.HraQuestionnaire)
                        {
                            testResultService.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.ArtifactSynced, false, orgRoleId);
                        }
                        else
                        {
                            testResultService.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)NewTestResultStateNumber.NpSigned, false, orgRoleId);
                        }
                    }
                }
                else
                {
                    testResultRepository.UpdateStateforSkipEvaluation(eventCustomer.Id, null);
                    eventCustomerResultRepository.SetEventCustomerResultState(eventId, customerId);
                }

                if (isNewResultFlow && account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire) && isEawvTestPurchased && !isEawvTestNotPerformed)
                {
                    var service = IoC.Resolve<INewResultFlowStateService>();

                    var model = new EhrReadyforCodingViewModel
                    {
                        EventId = eventId,
                        HfCustomerId = customerId,
                        ReadyForCoding = true
                    };

                    service.RunTaskReadyForCodingForVisit(model, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, "SkipEvaluationfornotContainingReviewableTest");

                }

            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Exception occurred while recording for Skip Evaluation for Not containing re-viewable test(s)! Message:" + ex.Message + "\n\t " + ex.StackTrace);
            }
        }

        [WebMethod(EnableSession = true)]
        public static void UnmarkSkipEvaluation(long eventId, long customerId)
        {
            try
            {
                var eventCustomer = IoC.Resolve<IEventCustomerResultRepository>().GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomer == null) return;
                IoC.Resolve<IPhysicianEvaluationRepository>().DeleteSkipReviewRecord(eventCustomer.Id);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Some Exception occured while Unmarking Skip Evaluation! Message:" + ex.Message + "\n\t " + ex.StackTrace);
            }
        }

        private bool IsCustomerNoShowOrLeftWithoutScreening(EventCustomer eventCustomer)
        {
            return eventCustomer.NoShow || eventCustomer.LeftWithoutScreeningReasonId.HasValue;
        }
    }
}
