using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Controllers;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Other;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Franchisor;
using Falcon.Entity.Other;
using Falcon.DataAccess.Master;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Common.CreateEventWizard
{
    public partial class Step1 : Page
    {
        private Int16 _defaultDayForHostPayment = -14;

        private long HostId { get; set; }

        public string CurrentRole
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;
            }
        }

        public OrganizationRoleUserModel CurrentOrganizationRole
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            }
        }

        public int EventSuspentionCutoffDays
        {
            get { return IoC.Resolve<ISettings>().EventSuspentionCutoffDays; }
        }

        public bool IsEventLocked { get; set; }


        protected void Step2CancelImgButton_Click(object sender, ImageClickEventArgs e)
        {
            if (EventId.HasValue)
                Response.RedirectUser("/App/Common/EventDetails.aspx?EventID=" + EventId.Value);
            else
            {
                var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    Response.RedirectUser("/App/Franchisor/Dashboard.aspx");
                }
                else if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    Response.RedirectUser("/App/Franchisee/Dashboard.aspx");
                }
                else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    Response.RedirectUser("/App/Franchisee/SalesRep/Dashboard.aspx");
                }
            }

        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Page.Title = "Host Info";
            Step1Div.Style.Add(HtmlTextWriterStyle.Display, "block");
            Step2div.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (!string.IsNullOrEmpty(hfHostID.Value))
            {
                var masterDal = new MasterDAL();
                List<EProspect> objProspect = null;
                var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    objProspect = masterDal.GetHostDetailsForEventWizard(hfHostID.Value,
                                                                             0,
                                                                             Convert.ToInt64(_hidSalesRepId.Value),
                                                                             Convert.ToInt32(Roles.SalesRep), "");
                }
                else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    objProspect = masterDal.GetHostDetailsForEventWizard(hfHostID.Value,
                                                                             0,
                                                                             currentOrgRole.OrganizationRoleUserId,
                                                                             Convert.ToInt32(Roles.SalesRep), "");
                }


                if (objProspect != null && objProspect.Count() > 0)
                    SetHost(objProspect[0]);
            }
            if (rbtnMinReqYes.Checked)
                Page.ClientScript.RegisterStartupScript(typeof(string), "js_showshowMinReqDetails", "showMinReqDetails();", true);
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), "js_hideMinReqDetails", "hideMinReqDetails();", true);
        }

        protected void ibtnSaveClose_Click(object sender, ImageClickEventArgs e)
        {
            Page.Title = "Event Info";

            //var eventRepository = IoC.Resolve<IEventRepository>();
            //var eventData = eventRepository.CheckDuplicateEventCreationOnSameHost(Convert.ToInt64(hfHostID.Value), Convert.ToDateTime(txtEventDate.Text), EventId.HasValue ? EventId.Value : 0);
            //if (eventData != null)
            //{
            //    divtopmessage.InnerHtml = "An Event is already scheduled at <i>" + eventData.Name + "</i> on <i>" + eventData.EventDate.ToString("MM/dd/yyyy") + "</i>.";
            //    divtopmessage.Style["display"] = "block";
            //    ClientScript.RegisterStartupScript(typeof(string), "JSCode_MaintainAfterFiledPostback", "maintainAfterPostBack();", true);
            //    return;
            //}
            SaveEvent(false);

        }

        //protected void ibtnNext_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (Session["EventWizard"] != null)
        //    {
        //        var objEventWizard = (EEventWizard)Session["EventWizard"];
        //        if (objEventWizard.EventID == 0)
        //        {
        //            var masterDal = new MasterDAL();
        //            EEvent objEvent = masterDal.CheckDuplicateEventRegistration(objEventWizard.Host.HostID, txtEventDate.Text);
        //            if (objEvent != null && !string.IsNullOrEmpty(objEvent.Name))
        //            {
        //                divtopmessage.InnerHtml = "An Event is already scheduled at <i>" + objEvent.Host.Name + "</i> on <i>" + Convert.ToDateTime(objEvent.EventDate).ToString("MM/dd/yyyy") + "</i>.";
        //                divtopmessage.Style["display"] = "block";
        //                ClientScript.RegisterStartupScript(typeof(string), "JSCode_MaintainAfterFiledPostback", "maintainAfterPostBack();", true);
        //                return;
        //            }
        //        }
        //        SaveEvent(true);
        //    }
        //}

        protected void lnkGenerate_Click(object sender, EventArgs e)
        {
            txtInvitationCode.Text = GenerateInvitationCode();
        }

        protected void ibtnAtach_Click(object sender, ImageClickEventArgs e)
        {
            Page.Title = "Event Info";
            if (string.IsNullOrEmpty(hfPodID.Value)) return;

            var selectedPodIds = hfPodID.Value.Split(',');

            var podIds = new List<long>();
            podIds.AddRange(selectedPodIds.Select(id => Convert.ToInt64(id)));

            BindPodDetails(podIds, EventId.HasValue ? EventId.Value : 0);

            IPodController podController = new PodController();

            var role = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            long organizationId = role.CheckRole((long)Roles.FranchisorAdmin) ? Convert.ToInt64(_hidFranchiseeId.Value) : role.OrganizationId;

            var podList = podController.GetPodsAvailableForEvent(organizationId, Convert.ToInt64(ddlTerritory.SelectedValue));

            podList.RemoveAll(pl => podIds.Contains(pl.Id));

            ddlPOD.Items.Clear();
            if (podList.Count > 0)
            {
                ddlPOD.DataSource = podList;
                ddlPOD.DataTextField = "Name";
                ddlPOD.DataValueField = "Id";
                ddlPOD.DataBind();
                ddlPOD.Items.Insert(0, new ListItem("Select Pod", "0"));
            }
            else
                ddlPOD.Items.Insert(0, new ListItem("No Pod Found", "0"));

            //if (EventId.HasValue)
            //{
            //    var masterDal = new MasterDAL();

            //    EEventWizard objEventWizard = masterDal.GetEventWizardDetails(Convert.ToInt32(EventId.Value));
            //    //  objEventWizard.EditEvent = true;
            //    SetEventPackageDetails(objEventWizard);
            //}

            ClientScript.RegisterStartupScript(typeof(string), "jscode", "maintainAfterPostBack(); ", true);
        }

        protected void lnkRemovePod_Click(object sender, EventArgs e)
        {
            Page.Title = "Event Info";
            if (string.IsNullOrEmpty(hfPodID.Value)) return;

            var podid = ((LinkButton)sender).CommandArgument;

            var selectedPodIds = hfPodID.Value.Split(',');
            var podIds = new List<long>();
            podIds.AddRange(selectedPodIds.Where(id => id != podid).Select(id => Convert.ToInt64(id)));

            BindPodDetails(podIds, EventId.HasValue ? EventId.Value : 0);

            IPodController podController = new PodController();

            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            long organizationId = currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) ? Convert.ToInt64(_hidFranchiseeId.Value) : currentOrgRole.OrganizationId;

            var podList = podController.GetPodsAvailableForEvent(organizationId, Convert.ToInt64(ddlTerritory.SelectedValue));

            podList.RemoveAll(pl => podIds.Contains(pl.Id));

            ddlPOD.Items.Clear();
            if (podList.Count > 0)
            {
                ddlPOD.DataSource = podList;
                ddlPOD.DataTextField = "Name";
                ddlPOD.DataValueField = "Id";
                ddlPOD.DataBind();
                ddlPOD.Items.Insert(0, new ListItem("Select Pod", "0"));
            }
            else
                ddlPOD.Items.Insert(0, new ListItem("No Pod Found", "0"));

            ClientScript.RegisterStartupScript(typeof(string), "jscode", "maintainAfterPostBack(); ", true);
        }

        protected void grdSelectPackage_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var txtEpPrice = (TextBox)e.Row.FindControl("txtEPPrice");
                var chkRowChild = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
                var ddlPackageScreeningTime = (DropDownList)e.Row.FindControl("ddlPackageScreeningTime");

                var package = e.Row.DataItem as Core.Marketing.Domain.Package;

                txtEpPrice.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");

                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin) || currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    txtEpPrice.Enabled = true;
                    chkRowChild.Disabled = false;
                    if (package != null)
                        ddlPackageScreeningTime.SelectedValue = package.ScreeningTime.ToString();
                }

                //if (PackageTimeOnlyCheckbox.Checked)
                //{
                var ddlPackageScreeningRoom = (DropDownList)e.Row.FindControl("ddlPackageScreeningRoom");
                BindPodRoomDropDown(ddlPackageScreeningRoom);
                //}
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                var chkSelectAllPackage = (CheckBox)e.Row.FindControl("chkSelectAllPackage");
                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin) || currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    chkSelectAllPackage.Enabled = true;
                }

                //if (PackageTimeOnlyCheckbox.Checked)
                //{
                //    this.grdSelectPackage.Columns[6].Visible = true;
                //}
            }
        }

        private void BindPodRoomDropDown(DropDownList dropDownList)
        {
            if (!string.IsNullOrEmpty(hfPodID.Value))
            {
                var podRoomList = IoC.Resolve<IPodRoomRepository>().GetByPodId(Convert.ToInt64(hfPodID.Value));
                if (podRoomList.Any())
                {
                    dropDownList.DataSource = podRoomList;
                    dropDownList.DataTextField = "RoomNo";
                    dropDownList.DataValueField = "Id";
                    dropDownList.DataBind();
                }
                dropDownList.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }

        protected void testGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var txtEventTestPrice = (TextBox)e.Row.FindControl("_txtEventTestPrice");
                var txtEventTestWithPackagePrice = (TextBox)e.Row.FindControl("_txtEventTestWithPackagePrice");
                var chkTestSelected = (HtmlInputCheckBox)e.Row.FindControl("chkTestSelected");
                var ddlTestScreeningTime = (DropDownList)e.Row.FindControl("ddlTestScreeningTime");

                var test = e.Row.DataItem as Test;

                txtEventTestPrice.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
                txtEventTestWithPackagePrice.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin) || currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    txtEventTestPrice.Enabled = true;
                    txtEventTestWithPackagePrice.Enabled = true;
                    chkTestSelected.Disabled = false;
                    if (test != null)
                        ddlTestScreeningTime.SelectedValue = test.ScreeningTime.ToString();
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                var chkSelectAllTest = (CheckBox)e.Row.FindControl("chkSelectAllTest");
                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin) || currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    chkSelectAllTest.Enabled = true;
                }
            }
        }

        protected void LoadPackageLinkBtn_Click(object sender, EventArgs e)
        {
            Page.Title = "Event Info";
            BindPackages(null);

            BindTests(null);

            ClientScript.RegisterStartupScript(typeof(string), "jscode", "maintainAfterPostBack(); ", true);
        }

        /// <summary>
        /// Fills the drop down.
        /// </summary>
        private void FillDropDown(string hostZipCode)
        {
            //fill minute dropdown
            for (int count = 0; count < 60; count += 5)
            {
                string mm = count.ToString();
                if (mm.Length == 1)
                    mm = "0" + mm;
                ddlMMStartTime.Items.Add(new ListItem(mm, mm));
                ddlMMEndTime.Items.Add(new ListItem(mm, mm));
                ddlMMLunchStartTime.Items.Add(new ListItem(mm, mm));
            }

            //ddlMMLunchStartTime.Items.Insert(0, new ListItem("Select", "0"));
            ddlScheduleTemplate.Items.Clear();
            ddlScheduleTemplate.Items.Add(new ListItem("Select Schedule Template", "0"));
            List<EScheduleTemplate> arrscheduletemplate;
            var masterDal = new MasterDAL();

            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            arrscheduletemplate = currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) ? masterDal.GetEventScheduleTemplate(string.Empty, 0, 0) : masterDal.GetEventScheduleTemplate("", currentOrgRole.OrganizationId, 1);
            if (arrscheduletemplate.Count > 0)
            {
                foreach (var objscheduletemplate in arrscheduletemplate)
                {
                    ddlScheduleTemplate.Items.Add(new ListItem(objscheduletemplate.Name, objscheduletemplate.ScheduleTemplateID.ToString()));
                }
                ClientScript.RegisterStartupScript(typeof(string), "jscode", "CheckChangeDropDown(); ", true);
            }
            ddlRegigtrationMode.Items.Clear();
            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Public.ToString(), Convert.ToInt32(RegistrationMode.Public).ToString()));
                ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Private.ToString(), Convert.ToInt32(RegistrationMode.Private).ToString()));
            }
            else
            {
                ITerritoryRepository territoryRepository = new TerritoryRepository();
                var salesRepTerritoryList =
                    territoryRepository.GetTerritoriesForSalesRepByZipCode(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                        hostZipCode);
                if (salesRepTerritoryList != null && salesRepTerritoryList.Count > 0)
                {
                    foreach (var salesRepTerritory in salesRepTerritoryList)
                    {
                        if (salesRepTerritory != null)
                        {
                            switch (salesRepTerritory.SalesRepTerritoryAssignments.Single().EventTypeSetupPermission
                                )
                            {
                                case (RegistrationMode.Private):
                                    if (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Private.ToString()) == null)
                                        ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Private.ToString(),
                                                                            Convert.ToInt32(RegistrationMode.Private).
                                                                                ToString()));
                                    break;
                                case (RegistrationMode.Public):
                                    if (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Public.ToString()) == null)
                                        ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Public.ToString(),
                                                                            Convert.ToInt32(RegistrationMode.Public).
                                                                                ToString()));
                                    break;
                                case (RegistrationMode.Both):
                                    if (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Public.ToString()) == null)
                                        ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Public.ToString(),
                                                                            Convert.ToInt32(RegistrationMode.Public).
                                                                                ToString()));
                                    if (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Private.ToString()) == null)
                                        ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Private.ToString(),
                                                                            Convert.ToInt32(RegistrationMode.Private).
                                                                                ToString()));
                                    break;

                            }
                        }
                    }
                }
                else
                {
                    ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Public.ToString(), Convert.ToInt32(RegistrationMode.Public).ToString()));
                    ddlRegigtrationMode.Items.Add(new ListItem(RegistrationMode.Private.ToString(), Convert.ToInt32(RegistrationMode.Private).ToString()));
                }


            }


            List<EEventActivityTemplate> arreventactivitytemplate = null;

            arreventactivitytemplate = masterDal.GetEventActivityTemplateEventWizard(HostId);

            ddlEventTaskTemplate.Items.Add(new ListItem("Select Event Task Template", "0"));
            if (arreventactivitytemplate != null)
            {
                foreach (EEventActivityTemplate t in arreventactivitytemplate)
                {
                    ddlEventTaskTemplate.Items.Add(new ListItem(t.Name, t.EventActivityTemplateID.ToString()));
                }
            }

            //fill Event Status dropdown

            ddlEventStatus.DataSource = Enum.GetNames(typeof(EventStatus));
            ddlEventStatus.DataBind();

            var lookupRepository = IoC.Resolve<ILookupRepository>();

            var lookups = lookupRepository.GetByLookupId((long)EventCancellationReason.DateChange);
            ddlEventCancellationReason.Items.Insert(0, new ListItem("--Select--", "-1"));
            foreach (var listItem in lookups)
            {
                ddlEventCancellationReason.Items.Add(new ListItem(listItem.DisplayName, listItem.Id.ToString()));
            }

            // Show message as Wraning In case (Private/Public) setup permission for event
            if ((ddlRegigtrationMode.Items.FindByText(RegistrationMode.Private.ToString()) == null) && (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Public.ToString()) == null))
            {
                _divMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
                _messageControlPrivatePublic.ShowSuccessMessage("You are only allowed to setup <b>public/private</b> events in zip code " + hostZipCode + ".If you think this is incorrect, please contact your supervisor.");
            }
            else if (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Private.ToString()) == null)
            {
                _divMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
                _messageControlPrivatePublic.ShowSuccessMessage("You are only allowed to setup <b>public</b> events in zip code " + hostZipCode + ".If you think this is incorrect, please contact your supervisor.");
            }
            else if (ddlRegigtrationMode.Items.FindByText(RegistrationMode.Public.ToString()) == null)
            {
                _divMessage.Style.Add(HtmlTextWriterStyle.Display, "block");
                _messageControlPrivatePublic.ShowSuccessMessage("You are only allowed to setup <b>private</b> events in zip code " + hostZipCode + ".If you think this is incorrect, please contact your supervisor.");
            }
        }

        /// <summary>
        /// Generates the invitation code.
        /// </summary>
        /// <returns></returns>
        private string GenerateInvitationCode()
        {
            Boolean bolValid = false;
            string strTempCode;
            const string strCouponPrefix = "IC";
            do
            {
                IRandomStringGenerator randomStringGenerator = new RandomStringGenerator();
                strTempCode = strCouponPrefix + randomStringGenerator.GetRandomNumericString(7);
                bolValid = ValidateInvitationCode(strTempCode);

            } while (bolValid == false);

            return strTempCode;
        }

        /// <summary>
        /// Validates the invitation code.
        /// </summary>
        /// <param name="strInvitationCode">The STR invitation code.</param>
        /// <returns></returns>
        private Boolean ValidateInvitationCode(string strInvitationCode)
        {
            var masterDal = new MasterDAL();
            return masterDal.CheckDuplicateInvitationCode(strInvitationCode);
        }

        /// <summary>
        /// Saveevents the specified bolcontinue.
        /// </summary>
        /// <param name="bolcontinue">if set to <c>true</c> [bolcontinue].</param>
        private void SaveEvent(bool bolcontinue)
        {
            /* check if the day is blocked then return*/
            if (CheckEventDay() == false)
            {
                return;
            }

            /* Filling Event Details in the object */
            var objEventWizard = new EEventWizard();
            Event oldEventDetail = null;
            if (EventId.HasValue)
            {
                objEventWizard.EventID = Convert.ToInt32(EventId.Value);
                var eventRepository = IoC.Resolve<IEventRepository>();
                oldEventDetail = eventRepository.GetById(objEventWizard.EventID);
            }

            if (!SetHostDetail(objEventWizard))
                return;
            var masterDal = new MasterDAL();

            /* Filing Pod */
            var eventPodEditModels = new List<EventPodEditModel>();
            FillEventPodEditModels(eventPodEditModels);
            var podIds = eventPodEditModels.Select(epem => epem.PodId).ToList();

            objEventWizard.TerritoryId = Convert.ToInt64(ddlTerritory.SelectedValue);

            objEventWizard.RecommendPackage = RecommendPackageCheckbox.Checked;
            objEventWizard.AskPreQualificationQuestion = AskPreQualificationQuestion.Checked;
            objEventWizard.EventStatus = Convert.ToInt32(Enum.Parse(typeof(EventStatus), ddlEventStatus.SelectedValue));
            objEventWizard.EventCancellationReason = Convert.ToInt64(ddlEventCancellationReason.SelectedValue);
            objEventWizard.EnableForCallCenter = EnableForCallCenter.Checked;
            objEventWizard.EnableForTechnician = EnableForTechnician.Checked;

            // Test And Package Dependency Rule Check:
            var ids = new List<long>();
            var selectedTestIds = new List<long>();

            string packageIds = string.Empty;
            string testIds = string.Empty;
            // get selected packageIds

            var recommendPackageForBoth = 0;
            var recommendPackageForMale = 0;
            var recommendPackageForFemale = 0;

            var mostPopularForBoth = 0;
            var mostPopularForMale = 0;
            var mostPopularForFemale = 0;

            var bestValueForBoth = 0;
            var bestValueForMale = 0;
            var bestValueForFemale = 0;
            var isMostPopularBestValue = false;
            var isCorporateEvent = (EventType)Convert.ToInt32(ddlEventType.SelectedValue) == EventType.Corporate;

            foreach (GridViewRow grv in grdSelectPackage.Rows)
            {
                var chkChild = grv.FindControl("chkRowChild") as HtmlInputCheckBox;
                var hfPackageId = grv.FindControl("hfPackageID") as HiddenField;
                var mostPopular = grv.FindControl("MostPopular") as HtmlInputCheckBox;
                var bestValue = grv.FindControl("BestValue") as HtmlInputCheckBox;

                if (chkChild != null && hfPackageId != null && chkChild.Checked)
                {
                    packageIds = packageIds + hfPackageId.Value + ",";
                    ids.Add(Convert.ToInt64(hfPackageId.Value));
                    var hfPackageGenderId = grv.FindControl("hfPackageGenderId") as HiddenField;

                    if (objEventWizard.RecommendPackage)
                    {

                        var chkRecommendSelected = grv.FindControl("chkRecommendSelected") as HtmlInputCheckBox;

                        if (hfPackageGenderId != null && chkRecommendSelected != null && chkRecommendSelected.Checked)
                        {
                            var packageGender = (Gender)Convert.ToInt64(hfPackageGenderId.Value);
                            if (packageGender == Gender.Unspecified)
                                recommendPackageForBoth++;
                            else if (packageGender == Gender.Male)
                                recommendPackageForMale++;
                            else if (packageGender == Gender.Female)
                                recommendPackageForFemale++;
                        }
                    }

                    if (!isCorporateEvent)
                    {
                        if (hfPackageGenderId != null && mostPopular != null && mostPopular.Checked)
                        {
                            var packageGender = (Gender)Convert.ToInt64(hfPackageGenderId.Value);
                            if (packageGender == Gender.Unspecified)
                                mostPopularForBoth++;
                            else if (packageGender == Gender.Male)
                                mostPopularForMale++;
                            else if (packageGender == Gender.Female)
                                mostPopularForFemale++;
                        }


                        if (hfPackageGenderId != null && bestValue != null && bestValue.Checked)
                        {
                            var packageGender = (Gender)Convert.ToInt64(hfPackageGenderId.Value);
                            if (packageGender == Gender.Unspecified)
                                bestValueForBoth++;
                            else if (packageGender == Gender.Male)
                                bestValueForMale++;
                            else if (packageGender == Gender.Female)
                                bestValueForFemale++;
                        }

                        if (mostPopular != null && mostPopular.Checked && bestValue != null && bestValue.Checked)
                        {
                            isMostPopularBestValue = true;
                        }
                    }

                }
            }

            // get selected testIds))
            foreach (GridViewRow grv in _testGrid.Rows)
            {
                var chkTestSelected = grv.FindControl("chkTestSelected") as HtmlInputCheckBox;
                var testIdHiddenField = grv.FindControl("hfTestId") as HiddenField;
                if (chkTestSelected != null && testIdHiddenField != null && chkTestSelected.Checked)
                {
                    testIds = testIds + testIdHiddenField.Value + ",";
                    selectedTestIds.Add(Convert.ToInt64(testIdHiddenField.Value));
                }
            }

            var scriptMessage = "";
            if (recommendPackageForBoth > 1 || (recommendPackageForBoth > 0 && (recommendPackageForMale > 0 || recommendPackageForFemale > 0)))
            {
                scriptMessage = "A package available for both the genders is already selected for recommendation";
                ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                return;
            }
            if (recommendPackageForMale > 1)
            {
                scriptMessage = "A package available for Male customer is already selected for recommendation";
                ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                return;
            }
            if (recommendPackageForFemale > 1)
            {
                scriptMessage = "A package available for Female customer is already selected for recommendation";
                ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                return;
            }

            if (!isCorporateEvent)
            {
                if (isMostPopularBestValue)
                {
                    scriptMessage = "A same package can not be marked as Most Popular and Best Value";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }

                if (mostPopularForBoth > 1 || (mostPopularForBoth > 0 && (mostPopularForMale > 0 || mostPopularForFemale > 0)))
                {
                    scriptMessage = "A package available for both the genders is already selected for Most Popular";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_MostPopular", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }
                if (mostPopularForMale > 1)
                {
                    scriptMessage = "A package available for Male customer is already selected for Most Popular";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_MostPopular", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }
                if (mostPopularForFemale > 1)
                {
                    scriptMessage = "A package available for Female customer is already selected for Most Popular";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_MostPopular", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }

                if (bestValueForBoth > 1 || (bestValueForBoth > 0 && (bestValueForMale > 0 || bestValueForFemale > 0)))
                {
                    scriptMessage = "A package available for both the genders is already selected for Best Value";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }
                if (bestValueForMale > 1)
                {
                    scriptMessage = "A package available for Male customer is already selected for Best Value";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }
                if (bestValueForFemale > 1)
                {
                    scriptMessage = "A package available for Female customer is already selected for Best Value";
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_RecommendPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                    return;
                }

            }

            scriptMessage = CheckForPackageIncludedTests(packageIds, testIds);
            if (!string.IsNullOrEmpty(scriptMessage))
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForTestAndPackage", "maintainAfterPostBack();alert('" + scriptMessage + "');", true);
                return;
            }

            if (objEventWizard.EventID > 0)
            {
                scriptMessage = CheckForStaticDynamicScheduling(objEventWizard.EventID, DynamicSchedulingYesRadioBtn.Checked, oldEventDetail);
                if (!string.IsNullOrEmpty(scriptMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForSchedulingType", "maintainAfterPostBack(); alert('" + scriptMessage + "');", true);
                    return;
                }
            }

            if (objEventWizard.EventID > 0)
            {
                scriptMessage = CheckForIsPackageTimeOnly(objEventWizard.EventID, PackageTimeOnlyCheckbox.Checked, oldEventDetail);
                if (!string.IsNullOrEmpty(scriptMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForSchedulingType", "maintainAfterPostBack(); alert('" + scriptMessage + "');", true);
                    return;
                }
            }

            if (DynamicSchedulingYesRadioBtn.Checked)
            {
                scriptMessage = CheckForPackageTestScreeningTime(packageIds, testIds);
                if (!string.IsNullOrEmpty(scriptMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForTestAndPackageScreeningTime", "maintainAfterPostBack(); screeningTimeMessage('" + scriptMessage + "');", true);
                    return;
                }
                if (PackageTimeOnlyCheckbox.Checked)
                {
                    if (objEventWizard.EventID > 0)
                    {
                        if (CheckAnyCustomerIsRegisteredInEvent(packageIds))
                        {
                            ClientScript.RegisterStartupScript(typeof(string), "JSCode_CheckPackageChange", "alert('Customers are already registered for the event. You cannot change the Package rooms for the event.');maintainAfterPostBack();", true);
                            return;
                        }
                    }

                    scriptMessage = CheckForPackageTestRoom(packageIds);
                    if (!string.IsNullOrEmpty(scriptMessage))
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForTestAndPackageScreeningTime", "maintainAfterPostBack(); screeningPackageRoomValidateMessage('" + scriptMessage + "');", true);
                        return;
                    }
                }

                scriptMessage = CheckForPodRoomTest(selectedTestIds, eventPodEditModels);
                if (!string.IsNullOrEmpty(scriptMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForPodTestNotIncluded", "maintainAfterPostBack(); screeningTimeMessage('" + scriptMessage + "');", true);
                    return;
                }

                if (objEventWizard.EventID > 0)
                {
                    scriptMessage = CheckForPodRoomChange(objEventWizard.EventID, eventPodEditModels, oldEventDetail);
                    if (!string.IsNullOrEmpty(scriptMessage))
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForSlotIntervalChange", "maintainAfterPostBack(); alert('" + scriptMessage + "');", true);
                        return;
                    }
                }
            }

            if (objEventWizard.EventID > 0 && objEventWizard.EventStatus == (int)EventStatus.Active)
            {
                scriptMessage = CheckForHafTemplateChange(objEventWizard.EventID, oldEventDetail);
                if (!string.IsNullOrEmpty(scriptMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForHafTemplateChange", "maintainAfterPostBack(); alert('" + scriptMessage + "');", true);
                    return;
                }
            }

            // Check for test depedent Rule
            if (!string.IsNullOrEmpty(testIds))
            {
                string testDependentMessage = CheckTestDependentOnTests(testIds);
                if (!string.IsNullOrEmpty(testDependentMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForTestAndTest", "maintainAfterPostBack(); alert('" + testDependentMessage + "');", true);
                    return;
                }
            }

            if (objEventWizard.EventID > 0 && CheckForPodPackageChange(objEventWizard.EventID) == false)
            {
                return;
            }

            objEventWizard.Name = objEventWizard.Host.Name;
            objEventWizard.ScheduleTemplateID = ddlScheduleTemplate.SelectedIndex > 0
                                                    ? Convert.ToInt32(ddlScheduleTemplate.SelectedItem.Value)
                                                    : 0;
            objEventWizard.EventType = new EEventType
                                           {
                                               EventTypeID = Convert.ToInt32(ddlRegigtrationMode.SelectedValue),
                                               Name = ddlRegigtrationMode.SelectedItem.Text
                                           };


            //objEventWizard.Active = true;

            //objEventWizard.EventStatus = Convert.ToInt32(Enum.Parse(typeof(EventStatus), ddlEventStatus.SelectedValue));
            objEventWizard.Notes = txtNotes.Text;
            objEventWizard.Rescheduled = ddlEventStatus.SelectedItem.Text == "Reschedule";

            objEventWizard.EventDate = txtEventDate.Text;
            objEventWizard.TimeZone = ddlTimeZone.SelectedItem.Text;
            objEventWizard.InvitationCode = txtInvitationCode.Text.Trim();

            objEventWizard.TeamArrivalTime = ddlHHStartTime.SelectedItem.Text + ":" + ddlMMStartTime.SelectedItem.Text +
                                             " " + ddlAMPMStartTime.SelectedValue;

            objEventWizard.TeamDepartureTime = ddlHHEndTime.SelectedItem.Text + ":" + ddlMMEndTime.SelectedItem.Text +
                                               " " + ddlAMPMEndTime.SelectedValue;

            objEventWizard.EventStartTime =
                Convert.ToDateTime(objEventWizard.TeamArrivalTime).AddMinutes(30).ToString("hh:mm tt");
            var min = new TimeSpan(0, 30, 0);
            objEventWizard.EventEndTime =
                Convert.ToDateTime(objEventWizard.TeamDepartureTime).Subtract(min).ToString("hh:mm tt");

            objEventWizard.EventActivityTemplateID = Convert.ToInt32(ddlEventTaskTemplate.SelectedValue);

            objEventWizard.HSCSalesRepID = objEventWizard.FranchiseeFranchiseeUser != null &&
                                           objEventWizard.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID > 0
                                               ? objEventWizard.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID
                                               : 0;

            objEventWizard.EnableAlaCarteOnline = EnableAlaCarteOnlineCheckbox.Checked;
            objEventWizard.EnableAlaCarteCallCenter = EnableAlaCarteCallCenterCheckbox.Checked;
            objEventWizard.EnableAlaCarteTechnician = EnableAlaCarteTechnicianCheckbox.Checked;

            objEventWizard.IsFemaleOnly = FemaleOnlyCheckbox.Checked;

            objEventWizard.AllowNonMammoPatients = (EventType)Convert.ToInt32(ddlEventType.SelectedValue) == EventType.HealthPlan ? AllowNonMammoPatientsCheckbox.Checked : true;
            
            var ProducType = new List<string>();
            foreach (ListItem item in EventProductType.Items)
            {
                if(item.Selected)
                ProducType.Add(item.Value);
            }

            objEventWizard.ProductType = String.Join(",", ProducType);
            objEventWizard.IsDynamicScheduling = DynamicSchedulingYesRadioBtn.Checked;
            objEventWizard.IsPackageTimeOnly = PackageTimeOnlyCheckbox.Checked;
            if (objEventWizard.IsDynamicScheduling)
            {
                if (EnableLunchDuration.Checked)
                {
                    objEventWizard.LunchStartTime = Convert.ToDateTime(txtEventDate.Text + " " + ddlHHLunchStartTime.SelectedItem.Text + ":" + ddlMMLunchStartTime.SelectedItem.Text + " " + ddlAMPMLunchStartTime.SelectedValue);
                    objEventWizard.LunchDuration = Convert.ToInt32(ddlLunchDuration.SelectedValue);
                }
                else
                {
                    objEventWizard.LunchStartTime = null;
                    objEventWizard.LunchDuration = null;
                }

                objEventWizard.FixedGroupScreeningTime = Convert.ToInt32(ddlFixedAncillaryScreeningTime.SelectedValue);
            }
            else
            {
                objEventWizard.LunchStartTime = null;
                objEventWizard.LunchDuration = null;

                objEventWizard.FixedGroupScreeningTime = null;
            }

            if (oldEventDetail != null)
            {
                objEventWizard.IsManual = oldEventDetail.IsManual;
                objEventWizard.UpdatedByAdmin = oldEventDetail.UpdatedByAdmin;
            }

            if (!string.IsNullOrEmpty(objEventWizard.EventDate))
            {
                var currentUserSystemRoleId = CurrentOrganizationRole.GetSystemRoleId;
                var eventDate = DateTime.Parse(objEventWizard.EventDate);

                if (!IsEventLocked)
                {
                    if ((objEventWizard.EventStatus == (int)EventStatus.Suspended && eventDate <= DateTime.Today.AddDays(EventSuspentionCutoffDays)) || (objEventWizard.EventStatus != (int)EventStatus.Suspended && eventDate > DateTime.Today.AddDays(EventSuspentionCutoffDays)))
                    {
                        objEventWizard.IsManual = true;
                    }
                    else if (objEventWizard.EventStatus == (int)EventStatus.Suspended && eventDate > DateTime.Today.AddDays(EventSuspentionCutoffDays))
                    {
                        objEventWizard.IsManual = false;
                    }
                }

                if (objEventWizard.EventStatus == (int)EventStatus.Active && eventDate > DateTime.Today.AddDays(EventSuspentionCutoffDays) && currentUserSystemRoleId == (long)Roles.FranchisorAdmin)
                {
                    objEventWizard.UpdatedByAdmin = CurrentOrganizationRole.OrganizationRoleUserId;
                }
            }


            if (DynamicSchedulingYesRadioBtn.Checked && objEventWizard.EventID > 0)
            {
                scriptMessage = CheckForDuration(objEventWizard, oldEventDetail);
                if (!string.IsNullOrEmpty(scriptMessage))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_AlterForLunchReschedule", "maintainAfterPostBack(); alert('" + scriptMessage + "');", true);
                    return;
                }
            }

            /*Fill Package Details*/
            var objlEPackage = new List<EEventPackage>();
            FillEventPackage(objEventWizard, objlEPackage);
            objEventWizard.EventPackage = objlEPackage;

            /*Begin Fill Test Package Details*/

            var tests = new List<ETest>();
            FillEventTest(objEventWizard, tests);
            objEventWizard.EventTest = tests;

            /*End Fill Test Package Details*/


            Int64 returnresult = 0;
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var organizationRoleUser =
                organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            if (organizationRoleUser != null)
                objEventWizard.UpdatedByOrganizationRoleUser = organizationRoleUser.Id;

            // check for eventCanceled by date should be less than or equals to eventDate.
            if (!CheckHostPaymentInfo(objEventWizard))
            {
                divtopmessage.InnerText =
                    "The date to cancel the event for complete refund of deposit should be before the event date.Please go back and change date.";
                divtopmessage.Style["display"] = "block";
                return;
            }
            if ((EventType)Convert.ToInt32(ddlEventType.SelectedValue) == EventType.Corporate)
            {
                objEventWizard.CooperateAccountId = Convert.ToInt64(ddlCooperateAccounts.SelectedValue);
                objEventWizard.CaptureInsuranceId = CaptureInsuranceIdCheckbox.Checked;
                objEventWizard.InsuranceIdRequired = InsuranceIdRequiredCheckbox.Checked;
                objEventWizard.EnableProduct = EnableProductCheckbox.Checked;
            }
            else if ((EventType)Convert.ToInt32(ddlEventType.SelectedValue) == EventType.HealthPlan)
            {
                objEventWizard.CooperateAccountId = Convert.ToInt64(ddlHealthPlan.SelectedValue);
                objEventWizard.CaptureInsuranceId = CaptureInsuranceIdCheckbox.Checked;
                objEventWizard.InsuranceIdRequired = InsuranceIdRequiredCheckbox.Checked;
                objEventWizard.EnableProduct = EnableProductCheckbox.Checked;
            }
            else
            {
                objEventWizard.CaptureInsuranceId = false;
                objEventWizard.InsuranceIdRequired = false;
                objEventWizard.EnableProduct = true;
            }

            if (HospitalPartnerYesRadioBtn.Checked)
            {
                objEventWizard.HospitalPartnerId = Convert.ToInt64(ddlHospitalPartner.SelectedValue);
                objEventWizard.AttachHospitalMaterial = AttachHospitalMaterialCheckbox.Checked;
                objEventWizard.CaptureSsn = CaptureSsnCheckbox.Checked;
                objEventWizard.RestrictEvaluation = RestrictEvaluationCheckbox.Checked;
            }

            objEventWizard.HealthAssessmentTemplateId = Convert.ToInt64(hfHealthAssessmentTemplateId.Value);

            var resetIsAppointmentConfirmFlag = false;

            if (oldEventDetail != null)
            {

                long hostId;
                DateTime newEventDate;

                long.TryParse(hfHostID.Value, out hostId);

                if (DateTime.TryParse(objEventWizard.EventDate, out newEventDate))
                {
                    if (oldEventDetail.EventDate != newEventDate)
                    {
                        resetIsAppointmentConfirmFlag = true;
                    }
                }

                if (hostId > 0 && hostId != oldEventDetail.HostId)
                {
                    resetIsAppointmentConfirmFlag = true;
                }
            }

            try
            {
                using (var scope = new TransactionScope())
                {
                    IEnumerable<EventPodRoom> oldPodRooms = null;
                    if (oldEventDetail != null)
                    {
                        var eventPodRoomRepository = IoC.Resolve<IEventPodRoomRepository>();
                        oldPodRooms = eventPodRoomRepository.GetByEventIdAndPodIds(oldEventDetail.Id, oldEventDetail.PodIds);
                    }

                    var isNew = objEventWizard.EventID == 0;
                    returnresult = masterDal.SaveEventWizard(objEventWizard, isNew
                                                             ? Convert.ToInt32(EOperationMode.Insert)
                                                             : Convert.ToInt32(EOperationMode.Update),
                                                         currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(), currentSession.CurrentOrganizationRole.RoleId.ToString());
                    if (returnresult <= 0)
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Event save was unsuccessful.');maintainAfterPostBack();", true);
                        return;
                    }

                    objEventWizard.EventID = Convert.ToInt32(returnresult);
                    SaveEventPod(eventPodEditModels, objEventWizard.EventID);
                    if (objEventWizard.IsDynamicScheduling)
                        CreateSlots(isNew, objEventWizard.EventID, oldEventDetail, oldPodRooms);

                    if (resetIsAppointmentConfirmFlag)
                    {
                        var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                        eventCustomerRepository.UpddateIsAppointmentConfirmed(oldEventDetail.Id);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Event save was unsuccessful." + ex.Message.Replace("'", "") + " ');maintainAfterPostBack();", true);
                return;
            }

            SaveEventStaff(objEventWizard.EventID, podIds, organizationRoleUser.Id);
            SaveHostPaymentDetail(objEventWizard);

            if (bolcontinue)
            {
                Response.RedirectUser("/App/common/CreateEventWizard/step3.aspx");
            }
            else
            {
                RemoveSession();
                if (Request.QueryString["Referrer"] != null)
                {
                    string strReferrer = Request.QueryString["Referrer"];
                    if ((strReferrer != string.Empty) && (strReferrer == "Calendar"))
                    {
                        Response.RedirectUser(ResolveUrl("~/App/Common/Calendar.aspx"));
                    }
                }
                else if (Request.QueryString["Parent"] != null)
                {
                    //Response.RedirectUser(ViewState["ReferedURL"].ToString());
                    Response.RedirectUser("/App/Common/EventDetails.aspx?EventID=" + objEventWizard.EventID);
                }
                else
                {
                    Response.RedirectUser("/App/Common/EventDetails.aspx?EventID=" + objEventWizard.EventID);
                }
            }

        }

        private void FillEventTest(EEventWizard objEventWizard, List<ETest> tests)
        {
            foreach (GridViewRow grv in _testGrid.Rows)
            {
                var chkTestSelected = grv.FindControl("chkTestSelected") as HtmlInputCheckBox;
                var testIdHiddenField = grv.FindControl("hfTestId") as HiddenField;
                var txtEventTestPrice = (TextBox)grv.FindControl("_txtEventTestPrice");
                var txtEventTestWithPackaagePrice = (TextBox)grv.FindControl("_txtEventTestWithPackagePrice");
                var chkAlaCarteSelected = grv.FindControl("chkAlaCarteSelected") as HtmlInputCheckBox;
                var ddlTestScreeningTime = (DropDownList)grv.FindControl("ddlTestScreeningTime");
                if (chkTestSelected != null && testIdHiddenField != null && chkTestSelected.Checked)
                {
                    var test = new ETest
                        {
                            TestID = Convert.ToInt32(testIdHiddenField.Value),
                            RecommendedPrice = Convert.ToSingle(txtEventTestPrice.Text),
                            ShowInAlaCarte = chkAlaCarteSelected != null && chkAlaCarteSelected.Checked,
                            ScreeningTime =
                                objEventWizard.IsDynamicScheduling ? Convert.ToInt32(ddlTestScreeningTime.SelectedValue) : 0,
                            WithPackagePrice = Convert.ToDecimal(txtEventTestWithPackaagePrice.Text)
                        };
                    tests.Add(test);
                }
            }
        }

        private void FillEventPackage(EEventWizard objEventWizard, List<EEventPackage> objlEPackage)
        {
            foreach (GridViewRow grv in grdSelectPackage.Rows)
            {
                var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                var hfPackageId = (HiddenField)grv.FindControl("hfPackageID");
                var txtEpPrice = (TextBox)grv.FindControl("txtEPPrice");
                var ddlPackageScreeningTime = (DropDownList)grv.FindControl("ddlPackageScreeningTime");
                var chkRecommendSelected = grv.FindControl("chkRecommendSelected") as HtmlInputCheckBox;
                var mostPopular = grv.FindControl("MostPopular") as HtmlInputCheckBox;
                var bestValue = grv.FindControl("bestValue") as HtmlInputCheckBox;
                var ddlPackageScreeningRoom = (DropDownList)grv.FindControl("ddlPackageScreeningRoom");

                var ismostPopular = mostPopular != null && mostPopular.Checked;

                var isBestValue = bestValue != null && bestValue.Checked;

                long? podRoomID = null;
                if (objEventWizard.IsPackageTimeOnly)
                    podRoomID = Convert.ToInt64(ddlPackageScreeningRoom.SelectedValue);


                if (chkChild.Checked)
                {
                    var objEPackage = new EEventPackage
                        {
                            Package = new EPackage
                                {
                                    PackageID = Convert.ToInt32(hfPackageId.Value),
                                    RecommendedPrice = Convert.ToSingle(txtEpPrice.Text)
                                },
                            PackagePrice = Convert.ToSingle(txtEpPrice.Text),
                            ScreeningTime = objEventWizard.IsDynamicScheduling ? Convert.ToInt32(ddlPackageScreeningTime.SelectedValue) : 0,
                            IsRecommended = objEventWizard.RecommendPackage && chkRecommendSelected != null && chkRecommendSelected.Checked,
                            MostPopular = ismostPopular,
                            BestValue = isBestValue,
                            PodRoomID = podRoomID
                        };

                    objlEPackage.Add(objEPackage);
                }
            }
        }

        private void FillEventPodEditModels(List<EventPodEditModel> eventPodEditModels)
        {
            if (!string.IsNullOrEmpty(hfPodID.Value))
            {
                foreach (GridViewRow grv in gvPOD.Rows)
                {
                    var podIdHiddenField = grv.FindControl("hfPodId") as HiddenField;
                    if (podIdHiddenField != null)
                    {
                        var eventPodEditModel = new EventPodEditModel()
                            {
                                PodId = Convert.ToInt64(podIdHiddenField.Value)
                            };

                        if (DynamicSchedulingYesRadioBtn.Checked)
                        {
                            var roomGridView = grv.FindControl("RoomGridView") as GridView;
                            if (roomGridView != null)
                            {
                                var eventPodRoomEditModels = new List<EventPodRoomEditModel>();
                                foreach (GridViewRow roomGridViewRow in roomGridView.Rows)
                                {
                                    var hfRoomNo = roomGridViewRow.FindControl("hfRoomNo") as HiddenField;
                                    var txtDuration = roomGridViewRow.FindControl("txtDuration") as TextBox;
                                    if (hfRoomNo != null && txtDuration != null)
                                    {
                                        var eventPodRoomEditModel = new EventPodRoomEditModel
                                            {
                                                RoomNo = Convert.ToInt32(hfRoomNo.Value),
                                                Duration = Convert.ToInt32(txtDuration.Text)
                                            };

                                        var testGridView = roomGridViewRow.FindControl("TestGridView") as GridView;
                                        if (testGridView != null)
                                        {
                                            var eventPodRoomTestEditModels = new List<EventPodRoomTestEditModel>();
                                            foreach (GridViewRow testGridViewRow in testGridView.Rows)
                                            {
                                                var hfTestId = testGridViewRow.FindControl("hfTestId") as HiddenField;
                                                var chkIsSelected =
                                                    testGridViewRow.FindControl("chkIsSelected") as HtmlInputCheckBox;
                                                if (hfTestId != null && chkIsSelected != null)
                                                {
                                                    var eventPodRoomTestEditModel = new EventPodRoomTestEditModel
                                                        {
                                                            TestId = Convert.ToInt64(hfTestId.Value),
                                                            IsSelected = chkIsSelected.Checked
                                                        };
                                                    eventPodRoomTestEditModels.Add(eventPodRoomTestEditModel);
                                                }
                                            }
                                            eventPodRoomEditModel.EventPodRoomTests = eventPodRoomTestEditModels;
                                        }
                                        eventPodRoomEditModels.Add(eventPodRoomEditModel);
                                    }
                                }
                                eventPodEditModel.EventPodRooms = eventPodRoomEditModels;
                            }
                        }
                        eventPodEditModels.Add(eventPodEditModel);
                    }
                }
            }
        }

        private void SaveEventStaff(long eventId, List<long> podIds, long scheduledByOrgRoleId)
        {
            var eventStaffAssignmentService = IoC.Resolve<IEventStaffAssignmentService>();

            eventStaffAssignmentService.SavePodDefaultTeamToEventStaff(eventId, podIds, scheduledByOrgRoleId);

        }

        private bool SetHostDetail(EEventWizard objEventWizard)
        {
            var masterDal = new MasterDAL();
            List<EProspect> objProspect = masterDal.GetHostDetailsForEventWizard(hfHostID.Value, 0,
                                                                                 Convert.ToInt32(_hidSalesRep.Value),
                                                                                 Convert.ToInt32(Roles.SalesRep), "");
            if (objProspect != null && objProspect.Count > 0)
            {
                objEventWizard.Host = new EHost
                                          {
                                              HostID = Convert.ToInt32(hfHostID.Value),
                                              Name = objProspect[0].OrganizationName,
                                              TaxIdNumber =
                                                  (!string.IsNullOrEmpty(_taxIdNumber.Text))
                                                      ? _taxIdNumber.Text
                                                      : objProspect[0].TaxIdNumber,
                                              Address = new EAddress
                                                            {
                                                                Address1 = objProspect[0].Address.Address1,
                                                                Address2 = objProspect[0].Address.Address2,
                                                                City = objProspect[0].Address.City,
                                                                State = objProspect[0].Address.State,
                                                                Zip = objProspect[0].Address.Zip
                                                            }
                                          };
                objEventWizard.Host.Prospect = new EProspect
                                                   {
                                                       Ranking = objProspect[0].Ranking,
                                                       ProspectDetails = new EProspectDetails
                                                                             {
                                                                                 FacilitiesFee =
                                                                                     objProspect[0].ProspectDetails.
                                                                                     FacilitiesFee
                                                                             }
                                                   };
            }
            if (_rbtnYPayment.Checked)
            {
                if (ValidateHostPaymentAddress() == false) return false;
            }
            SetHostPaymentInfo(objEventWizard);

            // Save Address Verification
            SaveAddressLatitudeLongitude();

            objEventWizard.CosttoUseHostSite = !string.IsNullOrEmpty(txtCostOfHost.Text)
                                                   ? Convert.ToSingle(txtCostOfHost.Text)
                                                   : 0.00f;
            objEventWizard.DepositAmount = !string.IsNullOrEmpty(txtDepositAmount.Text)
                                               ? Convert.ToSingle(txtDepositAmount.Text)
                                               : 0.00f;

            objEventWizard.ScheduleMethodID = Convert.ToInt32(ddlScheduledBy.SelectedValue);
            objEventWizard.CommunicationModeID = Convert.ToInt32(ddlCommunicationMode.SelectedValue);
            objEventWizard.MinimumSiteRequirements = rbtnMinReqYes.Checked;
            if (rbtnMinReqNo.Checked)
            {
                objEventWizard.ConfirmVisually = false;
                objEventWizard.ConfirmComments = "";
            }
            else
            {
                objEventWizard.ConfirmVisually = rbtnCrfmVisually.Checked;
                objEventWizard.ConfirmComments = txtComments.Text;
                objEventWizard.InstructionForCallCenter = _txtInstructionForCallCenter.Text;
            }



            switch ((Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId)
            {
                case Roles.FranchisorAdmin:


                    objEventWizard.Franchisee = new EFranchisee
                                                    {
                                                        FranchiseeID = Convert.ToInt32(_hidFranchiseeId.Value)
                                                    };
                    objEventWizard.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser
                                                                  {
                                                                      FranchiseeFranchiseeUserID =
                                                                          Convert.ToInt32(_hidSalesRepId.Value)
                                                                  };
                    break;
                case Roles.FranchiseeAdmin:

                    objEventWizard.Franchisee = new EFranchisee
                                                    {
                                                        FranchiseeID =
                                                            Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId)
                                                    };

                    objEventWizard.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser
                                                                  {
                                                                      FranchiseeFranchiseeUserID =
                                                                          Convert.ToInt32(_hidSalesRepId.Value)
                                                                  };
                    break;
                case Roles.SalesRep:

                    objEventWizard.Franchisee = new EFranchisee
                                                    {
                                                        FranchiseeID =
                                                            Convert.ToInt32(
                                                                IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId)
                                                    };
                    objEventWizard.FranchiseeFranchiseeUser = new EFranchiseeFranchiseeUser
                                                                  {
                                                                      FranchiseeFranchiseeUserID =
                                                                          Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                                                                  };
                    break;
            }
            return true;
        }

        private void SetHostPaymentInfo(EEventWizard objEventWizard)
        {
            objEventWizard.CosttoUseHostSite = !string.IsNullOrEmpty(txtCostOfHost.Text)
                                                   ? Convert.ToSingle(txtCostOfHost.Text)
                                                   : 0.00f;
            // todo: need to remove dependancy to event wizard
            objEventWizard.PayByCheck = _chkCheckForCost.Checked;
            objEventWizard.PayByCreditCard = _chkCreditCardForCost.Checked;

            if (chkReminderTask.Checked)
            {
                objEventWizard.PaymentDueDate = !string.IsNullOrEmpty(txtPaymentDue.Text)
                                                    ? txtPaymentDue.Text
                                                    : DateTime.Now.AddDays(-1).ToShortDateString();
            }
            else objEventWizard.PaymentDueDate = "";

            if ((_rbtDepositY.Checked) && (_rbtnYPayment.Checked))
            {
                objEventWizard.DepositAmount = !string.IsNullOrEmpty(txtDepositAmount.Text)
                                                   ? Convert.ToSingle(txtDepositAmount.Text)
                                                   : 0.00f;
                if (chkReminderTask.Checked)
                {
                    objEventWizard.DepositDueDate = !string.IsNullOrEmpty(txtDepositDue.Text)
                                                        ? txtDepositDue.Text
                                                        : DateTime.Now.AddDays(-1).ToShortDateString();
                }
                else objEventWizard.DepositDueDate = "";
            }
            else objEventWizard.DepositDueDate = "";

            if ((objEventWizard.EventID == 0) && (!_rbtnYPayment.Checked))
            {
                return;
            }
            _hostPaymentInfo = new HostPayment();
            _hostDepositInfo = new HostDeposit();
            if (objEventWizard.EventID > 0)
            {
                IHostPaymentRepository hostPaymentRepository = new HostPaymentRepository();
                IHostDeositRepository hostDepositRepository = new HostDepositRepository();
                try
                {
                    _hostPaymentInfo = hostPaymentRepository.GetById(objEventWizard.EventID);
                }
                catch (Exception)
                {
                    if (_rbtnYPayment.Checked)
                    {
                        SetHostPaymentDefaultInfo(_hostPaymentInfo);
                    }
                    else
                    {
                        _hostPaymentInfo = null;
                        objEventWizard.PaymentDueDate = "";
                    }
                }

                try
                {
                    _hostDepositInfo = hostDepositRepository.GetById(objEventWizard.EventID);
                }
                catch (Exception)
                {
                    if ((_rbtDepositY.Checked) && (_rbtnYPayment.Checked))
                    {
                        SetHostDepositDefaultInfo(_hostDepositInfo);
                    }
                    else
                    {
                        _hostDepositInfo = null;
                        objEventWizard.DepositDueDate = "";
                    }
                }
            }
            else
            {
                if (_rbtnYPayment.Checked)
                {
                    SetHostPaymentDefaultInfo(_hostPaymentInfo);
                }
                else
                {
                    _hostPaymentInfo = null;
                    objEventWizard.PaymentDueDate = "";
                }
                if ((_rbtDepositY.Checked) && (_rbtnYPayment.Checked))
                    SetHostDepositDefaultInfo(_hostDepositInfo);
                else
                {
                    _hostDepositInfo = null;
                    objEventWizard.DepositDueDate = "";
                }
            }
            UpdateHostPaymentInfo(_hostPaymentInfo, _hostDepositInfo);
        }

        private Boolean CheckEventDay()
        {
            var otherDal = new OtherDAL();
            EBlockedDay[] objBlockedDay = otherDal.GetBlockedDayForCalendar(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, txtEventDate.Text, txtEventDate.Text, 0).ToArray();

            if (objBlockedDay.Length > 0)
            {
                ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('You cannot Host event on " + txtEventDate.Text + " ! This date is blocked for event due to an important reason.' );maintainAfterPostBack();", true);
                return false;
            }
            return true;
        }

        private void FillEventDetails(EEventWizard objEventWizard)
        {

            ddlTerritory.SelectedValue = objEventWizard.TerritoryId.ToString();
            ddlScheduleTemplate.SelectedValue = objEventWizard.ScheduleTemplateID.ToString();
            if (objEventWizard.EventType != null)
                ddlRegigtrationMode.SelectedValue = objEventWizard.EventType.EventTypeID.ToString();

            if (!string.IsNullOrEmpty(objEventWizard.EventDate))
                txtEventDate.Text = Convert.ToDateTime(objEventWizard.EventDate).ToString("MM/dd/yyyy");

            txtInvitationCode.Text = objEventWizard.InvitationCode;
            txtNotes.Text = objEventWizard.Notes;
            ddlEventStatus.SelectedValue = Convert.ToString(Enum.Parse(typeof(EventStatus), objEventWizard.EventStatus.ToString()));

            if (objEventWizard.EventCancellationReason.HasValue)
            {
                ddlEventCancellationReason.SelectedValue = objEventWizard.EventCancellationReason.Value.ToString();
            }

            if (Convert.ToString(Enum.Parse(typeof(EventStatus), objEventWizard.EventStatus.ToString())) == EventStatus.Canceled.ToString())
            {
                ViewState["EventStatus"] = EventStatus.Canceled.ToString();
            }
            else ViewState["EventStatus"] = null;

            ClientScript.RegisterStartupScript(typeof(string), "jscode_setEventStatus", "ShowHideEventNotes(); ShowHideEventCancellationReason();", true);

            if (!string.IsNullOrEmpty(objEventWizard.TeamArrivalTime))
            {
                objEventWizard.TeamArrivalTime =
                    Convert.ToDateTime(objEventWizard.TeamArrivalTime).ToString("hh:mm tt");
                ddlHHStartTime.SelectedValue = objEventWizard.TeamArrivalTime.Substring(0, 2);
                ddlMMStartTime.SelectedValue = objEventWizard.TeamArrivalTime.Substring(3, 2);
                ddlAMPMStartTime.SelectedValue = objEventWizard.TeamArrivalTime.Substring(6, 2);
            }
            if (!string.IsNullOrEmpty(objEventWizard.TeamDepartureTime))
            {
                objEventWizard.TeamDepartureTime =
                    Convert.ToDateTime(objEventWizard.TeamDepartureTime).ToString("hh:mm tt");
                ddlHHEndTime.SelectedValue = objEventWizard.TeamDepartureTime.Substring(0, 2);
                ddlMMEndTime.SelectedValue = objEventWizard.TeamDepartureTime.Substring(3, 2);
                ddlAMPMEndTime.SelectedValue = objEventWizard.TeamDepartureTime.Substring(6, 2);
            }

            if (objEventWizard.LunchStartTime.HasValue && objEventWizard.LunchDuration.HasValue && objEventWizard.LunchDuration.Value > 0)
            {
                ddlHHLunchStartTime.SelectedValue = objEventWizard.LunchStartTime.Value.ToString("hh:mm tt").Substring(0, 2);
                ddlMMLunchStartTime.SelectedValue = objEventWizard.LunchStartTime.Value.ToString("hh:mm tt").Substring(3, 2);
                ddlAMPMLunchStartTime.SelectedValue = objEventWizard.LunchStartTime.Value.ToString("hh:mm tt").Substring(6, 2);
                ddlLunchDuration.SelectedValue = objEventWizard.LunchDuration.Value.ToString();
                EnableLunchDuration.Checked = true;
                PackageTimeOnlyCheckbox.Checked = objEventWizard.IsPackageTimeOnly;
            }
            else
            {
                ddlHHLunchStartTime.SelectedValue = StandardLunchStartTime.Substring(0, 2);
                ddlMMLunchStartTime.SelectedValue = StandardLunchStartTime.Substring(3, 2);
                ddlAMPMLunchStartTime.SelectedValue = StandardTeamDepartureTime.Substring(6, 2);
                EnableLunchDuration.Checked = false;
            }

            if (objEventWizard.FixedGroupScreeningTime.HasValue && objEventWizard.FixedGroupScreeningTime.Value > 0)
                ddlFixedAncillaryScreeningTime.SelectedValue = objEventWizard.FixedGroupScreeningTime.Value.ToString();

            ddlEventTaskTemplate.SelectedValue = objEventWizard.EventActivityTemplateID.ToString();

            //ddlSalesRep.SelectedValue = objEventWizard.HSCSalesRepID.ToString();
            if (!string.IsNullOrEmpty(objEventWizard.EventDate))
                BindPod(objEventWizard.Franchisee.FranchiseeID, objEventWizard.TerritoryId);

            /* Filling Pod Details & Team Member info ************************ */
            if (objEventWizard.EventPod != null && objEventWizard.EventPod.Count > 0)
            {
                var podIds = objEventWizard.EventPod.Select(ep => (long)ep.Pod.PodID);
                BindPodDetails(podIds, objEventWizard.EventID);
            }

            /**************Fill Package Details************/

            SetEventPackageDetails(objEventWizard);
            //if (objEventWizard.EventPackage != null && objEventWizard.EventPackage.Count > 0)
            //{
            //    var packageIds = objEventWizard.EventPackage.Select(ep => (long)ep.Package.PackageID).ToList();

            //    BindPackages(packageIds);
            //    foreach (GridViewRow grv in grdSelectPackage.Rows)
            //    {
            //        var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
            //        var hfPackageId = (HiddenField)grv.FindControl("hfPackageID");
            //        var txtEpPrice = (TextBox)grv.FindControl("txtEPPrice");
            //        var ddlPackageScreeningTime = (DropDownList)grv.FindControl("ddlPackageScreeningTime");
            //        var chkRecommendSelected = grv.FindControl("chkRecommendSelected") as HtmlInputCheckBox;
            //        var packageGender = grv.FindControl("PackageGender") as HtmlContainerControl;

            //        var mostPopular = (HtmlInputCheckBox)grv.FindControl("MostPopular");
            //        var bestValue = (HtmlInputCheckBox)grv.FindControl("BestValue");

            //        for (int count = 0; count < objEventWizard.EventPackage.Count; count++)
            //        {
            //            if (objEventWizard.EventPackage[count].Package.PackageID == Convert.ToInt32(hfPackageId.Value))
            //            {
            //                chkChild.Checked = true;
            //                txtEpPrice.Text = objEventWizard.EventPackage[count].PackagePrice.ToString();
            //                ddlPackageScreeningTime.SelectedValue = objEventWizard.EventPackage[count].ScreeningTime.ToString();
            //                chkRecommendSelected.Checked = objEventWizard.EventPackage[count].IsRecommended;
            //                mostPopular.Checked = objEventWizard.EventPackage[count].MostPopular;
            //                bestValue.Checked = objEventWizard.EventPackage[count].BestValue;
            //                break;
            //            }
            //            else
            //                chkChild.Checked = false;
            //        }
            //    }
            //}
            //// Package is not selected for this event while the event has been created.
            //else
            //{
            //    BindPackages(null);
            //    if (objEventWizard.EditEvent)
            //    {
            //        foreach (GridViewRow grv in grdSelectPackage.Rows)
            //        {
            //            var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
            //            chkChild.Checked = false;
            //        }
            //    }
            //}

            /**************Fill Test Details************/

            if (objEventWizard.EventTest != null && objEventWizard.EventTest.Count > 0)
            {
                var testIds = objEventWizard.EventTest.Select(et => (long)et.TestID).ToList();
                BindTests(testIds);

                foreach (GridViewRow grv in _testGrid.Rows)
                {
                    var chkChild = grv.FindControl("chkTestSelected") as HtmlInputCheckBox;
                    var testIdHiddenField = grv.FindControl("hfTestId") as HiddenField;
                    var txtTestPrice = grv.FindControl("_txtEventTestPrice") as TextBox;
                    var txtTestWithPackagePrice = grv.FindControl("_txtEventTestWithPackagePrice") as TextBox;
                    var chkAlaCarteSelected = grv.FindControl("chkAlaCarteSelected") as HtmlInputCheckBox;
                    var ddlTestScreeningTime = (DropDownList)grv.FindControl("ddlTestScreeningTime");
                    for (int count = 0; count < objEventWizard.EventTest.Count; count++)
                    {
                        if (objEventWizard.EventTest[count].TestID == Convert.ToInt32(testIdHiddenField.Value))
                        {
                            chkChild.Checked = true;
                            txtTestPrice.Text = objEventWizard.EventTest[count].RecommendedPrice.ToString("0.00");
                            txtTestWithPackagePrice.Text = objEventWizard.EventTest[count].WithPackagePrice.ToString("0.00");
                            chkAlaCarteSelected.Checked = objEventWizard.EventTest[count].ShowInAlaCarte;
                            ddlTestScreeningTime.SelectedValue = objEventWizard.EventTest[count].ScreeningTime.ToString();
                            break;
                        }
                        else
                            chkChild.Checked = false;
                    }
                }
            }

            EnableAlaCarteOnlineCheckbox.Checked = objEventWizard.EnableAlaCarteOnline;
            EnableAlaCarteCallCenterCheckbox.Checked = objEventWizard.EnableAlaCarteCallCenter;
            EnableAlaCarteTechnicianCheckbox.Checked = objEventWizard.EnableAlaCarteTechnician;
            FemaleOnlyCheckbox.Checked = objEventWizard.IsFemaleOnly;
            AllowNonMammoPatientsCheckbox.Checked = objEventWizard.AllowNonMammoPatients;
            if (objEventWizard.IsDynamicScheduling)
                DynamicSchedulingYesRadioBtn.Checked = true;
            else
                DynamicSchedulingNoRadioBtn.Checked = true;

            if (objEventWizard.HealthAssessmentTemplateId.HasValue && objEventWizard.HealthAssessmentTemplateId.Value > 0)
                hfHealthAssessmentTemplateId.Value = objEventWizard.HealthAssessmentTemplateId.Value.ToString();
            /**************************************************/
            //if (CheckStandardEventTime(objEventWizard) && IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId == (int)Roles.SalesRep && ddlEventStatus.SelectedItem.Text == EventStatus.Suspended.ToString())
            //{
            //    ddlEventStatus.Enabled = false;
            //}
        }

        private void SetEventPackageDetails(EEventWizard objEventWizard)
        {
            if (objEventWizard.EventPackage != null && objEventWizard.EventPackage.Count > 0)
            {
                var packageIds = objEventWizard.EventPackage.Select(ep => (long)ep.Package.PackageID).ToList();

                BindPackages(packageIds);
                foreach (GridViewRow grv in grdSelectPackage.Rows)
                {
                    var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                    var hfPackageId = (HiddenField)grv.FindControl("hfPackageID");
                    var txtEpPrice = (TextBox)grv.FindControl("txtEPPrice");
                    var ddlPackageScreeningTime = (DropDownList)grv.FindControl("ddlPackageScreeningTime");
                    var ddlPackageScreeningRoom = (DropDownList)grv.FindControl("ddlPackageScreeningRoom");
                    var hdfPackageScreeningRoomID = (HiddenField)grv.FindControl("hdfPackageScreeningRoomID");
                    var chkRecommendSelected = grv.FindControl("chkRecommendSelected") as HtmlInputCheckBox;
                    var packageGender = grv.FindControl("PackageGender") as HtmlContainerControl;

                    var mostPopular = (HtmlInputCheckBox)grv.FindControl("MostPopular");
                    var bestValue = (HtmlInputCheckBox)grv.FindControl("BestValue");

                    for (int count = 0; count < objEventWizard.EventPackage.Count; count++)
                    {
                        if (objEventWizard.EventPackage[count].Package.PackageID == Convert.ToInt32(hfPackageId.Value))
                        {
                            chkChild.Checked = true;
                            txtEpPrice.Text = objEventWizard.EventPackage[count].PackagePrice.ToString();
                            ddlPackageScreeningTime.SelectedValue = objEventWizard.EventPackage[count].ScreeningTime.ToString();
                            ddlPackageScreeningRoom.SelectedValue = objEventWizard.EventPackage[count].PodRoomID.ToString();
                            hdfPackageScreeningRoomID.Value = objEventWizard.EventPackage[count].PodRoomID.ToString();
                            chkRecommendSelected.Checked = objEventWizard.EventPackage[count].IsRecommended;
                            mostPopular.Checked = objEventWizard.EventPackage[count].MostPopular;
                            bestValue.Checked = objEventWizard.EventPackage[count].BestValue;
                            break;
                        }
                        else
                            chkChild.Checked = false;
                    }
                }
            }
            // Package is not selected for this event while the event has been created.
            else
            {
                BindPackages(null);
                if (objEventWizard.EditEvent)
                {
                    foreach (GridViewRow grv in grdSelectPackage.Rows)
                    {
                        var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                        chkChild.Checked = false;
                    }
                }
            }
        }

        private void BindPod(long organizationId, long territoryId)
        {
            IPodController podController = new PodController();
            var podList = podController.GetPodsAvailableForEvent(organizationId, territoryId);

            ddlPOD.Items.Clear();
            if (podList.Count > 0)
            {
                ddlPOD.DataSource = podList;
                ddlPOD.DataTextField = "Name";
                ddlPOD.DataValueField = "Id";
                ddlPOD.DataBind();
                ddlPOD.Items.Insert(0, new ListItem("Select Pod", "0"));
            }
            else
                ddlPOD.Items.Insert(0, new ListItem("No Pod Found", "0"));
        }

        private void BindPackages(IEnumerable<long> packageIdsInEvent)
        {
            //fill All Packages
            long accountId = 0;
            var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
            if ((EventType)Convert.ToInt32(ddlEventType.SelectedValue) == EventType.Corporate)
            {
                accountId = Convert.ToInt64(ddlCooperateAccounts.SelectedValue);
            }
            else if ((EventType)Convert.ToInt32(ddlEventType.SelectedValue) == EventType.HealthPlan)
            {
                accountId = Convert.ToInt64(ddlHealthPlan.SelectedValue);
            }

            var packages = eventPackageSelectorService.GetEventPackage(accountId, Convert.ToInt64(ddlHospitalPartner.SelectedValue), Convert.ToInt64(ddlTerritory.SelectedValue),
                                                            (EventType)Convert.ToInt32(ddlEventType.SelectedValue));

            if (packageIdsInEvent != null && packageIdsInEvent.Any())
            {
                var idsInpackages = packages.Select(pk => pk.PackageId).ToArray();
                var packageIds = packageIdsInEvent.Where(p => !idsInpackages.Contains(p)).Select(p => p).ToArray();
                var packageRepository = IoC.Resolve<IUniqueItemRepository<Core.Marketing.Domain.Package>>();
                var packagesInEvent = packageRepository.GetByIds(packageIds);
                if (packagesInEvent != null && packagesInEvent.Any())
                {
                    var packageEditModels = AutoMapper.Mapper.Map<IEnumerable<Core.Marketing.Domain.Package>, IEnumerable<EventPackageEditModel>>(packagesInEvent);
                    packages = packages.Concat(packageEditModels);
                }


                foreach (var package in packages)
                {
                    package.IsSelectedByDefaultforEvent = packageIdsInEvent.Contains(package.PackageId);
                }
            }
            if (packages != null && packages.Count() > 0)
            {
                grdSelectPackage.DataSource = packages.OrderByDescending(p => p.IsSelectedByDefaultforEvent).ThenBy(p => p.Name);
                grdSelectPackage.DataBind();

                NoPackageAvailableDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                PackageAvailableDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                NoPackageAvailableSpan.InnerText = "";
            }
            else
            {
                grdSelectPackage.DataSource = null;
                grdSelectPackage.DataBind();

                NoPackageAvailableDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                PackageAvailableDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                switch ((EventType)Convert.ToInt32(ddlEventType.SelectedValue))
                {
                    case EventType.Corporate:
                        NoPackageAvailableSpan.InnerText = "No " + EventType.Corporate + " type package found. Please select event type as " + EventType.Retail;
                        break;
                    case EventType.Retail:
                        NoPackageAvailableSpan.InnerText = "No " + EventType.Retail + " type package found. Please select event type as " + EventType.Corporate;
                        break;

                }

            }
        }

        private void BindTests(IEnumerable<long> testIdsInEvent)
        {
            // Fill Test 

            var testRepository = IoC.Resolve<ITestRepository>();
            var tests = testRepository.GetAll();

            if (testIdsInEvent != null && testIdsInEvent.Count() > 0)
            {
                var idsInTests = tests.Select(t => t.Id).ToArray();
                testIdsInEvent = testIdsInEvent.Where(t => !idsInTests.Contains(t)).Select(t => t).ToArray();
                var uniqueItemRepository = IoC.Resolve<IUniqueItemRepository<Test>>();
                var testsInEvent = uniqueItemRepository.GetByIds(testIdsInEvent);
                if (testsInEvent != null && testsInEvent.Count() > 0)
                    tests.Concat(testsInEvent);

                foreach (var test in tests)
                {
                    test.IsSelectedByDefaultforEvent = testIdsInEvent.Contains(test.Id);
                }
            }
            if (tests != null && tests.Count > 0)
            {
                _testGrid.DataSource = tests.OrderBy(t => t.RelativeOrder);
                _testGrid.DataBind();
                _testDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                _testGrid.DataSource = null;
                _testGrid.DataBind();
                _testDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }

        private bool CheckForPodPackageChange(int eventId)
        {
            string packageIds = "";
            foreach (GridViewRow grv in grdSelectPackage.Rows)
            {
                var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                var hfPackageID = (HiddenField)grv.FindControl("hfPackageID");

                if (chkChild.Checked)
                {
                    packageIds += hfPackageID.Value + ",";
                }
            }
            if (!string.IsNullOrEmpty(packageIds))
                packageIds = packageIds.Substring(0, packageIds.Length - 1);

            var franchisorDal = new FranchisorDAL();
            int returnResult = franchisorDal.CheckPodPackageChange(packageIds, eventId);
            if (returnResult == 0)
            {
                ClientScript.RegisterStartupScript(typeof(string), "JSCode_CheckPackageChange", "alert('The package/test which you are trying to remove has been availed by the customer registered for this event. You cannot remove this package/test.');maintainAfterPostBack();", true);
                return false;
            }
            return true;
        }

        private void SaveHostPaymentDetail(EEventWizard objEventWizard)
        {
            string currentEventStatus = Convert.ToString(Enum.Parse(typeof(EventStatus), objEventWizard.EventStatus.ToString()));

            if (_hostPaymentInfo != null)
            {
                IHostPaymentRepository hostPaymentRepository = new HostPaymentRepository();


                if (_hostPaymentInfo.EventId == 0)
                {
                    _hostPaymentInfo.EventId = objEventWizard.EventID;
                }
                // Change Payment status:Receivable
                if (currentEventStatus == EventStatus.Canceled.ToString() && _hostPaymentInfo.Status == HostPaymentStatus.Paid)
                {
                    _hostPaymentInfo.Status = HostPaymentStatus.Receivable;
                }
                else if (currentEventStatus == EventStatus.Active.ToString())
                {
                    // Change Payment status:Receivable to Paid (If Event Active)
                    if (ViewState["EventStatus"] != null && Convert.ToString(ViewState["EventStatus"]) == EventStatus.Canceled.ToString())
                    {
                        _hostPaymentInfo.Status = HostPaymentStatus.Paid;
                    }
                }

                try
                {
                    var addressService = IoC.Resolve<IAddressService>();
                    addressService.SaveAfterSanitizing(_hostPaymentInfo.PaymentMailingAddress);

                    hostPaymentRepository.Save(_hostPaymentInfo);
                }
                catch (Exception)
                {
                    //send message to users
                    //log into logger
                    //IoC.Resolve<ILogger>().LogException(exception, IoC.Resolve<ISessionContext>(), "string with info" );
                }
            }
            else
            {
                if (objEventWizard.EventID > 0)
                {
                    IHostPaymentRepository hostPaymentRepository = new HostPaymentRepository();
                    try
                    {
                        var hostPaymentInfo = hostPaymentRepository.GetById(objEventWizard.EventID);
                        if (currentEventStatus == "Canceled")
                        {
                            if (hostPaymentInfo.Status == HostPaymentStatus.Paid)
                                hostPaymentInfo.Status = HostPaymentStatus.Receivable;
                            hostPaymentRepository.Save(hostPaymentInfo);
                        }
                        else if (currentEventStatus == EventStatus.Active.ToString())
                        {
                            // Change Payment status:Receivable to Paid (If Event Active)
                            if (ViewState["EventStatus"] != null &&
                                Convert.ToString(ViewState["EventStatus"]) == EventStatus.Canceled.ToString())
                            {
                                hostPaymentInfo.Status = HostPaymentStatus.Paid;
                                hostPaymentRepository.Save(hostPaymentInfo);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            if (_hostDepositInfo != null)
            {
                IHostDeositRepository hostDepositRepository = new HostDepositRepository();

                if (_hostDepositInfo.EventId == 0)
                {
                    _hostDepositInfo.EventId = objEventWizard.EventID;
                }
                // Change Payment status:Receivable
                if (currentEventStatus == "Canceled" && _hostDepositInfo.Status == HostPaymentStatus.Paid)
                {
                    _hostDepositInfo.Status = HostPaymentStatus.Receivable;
                }
                else if (currentEventStatus == EventStatus.Active.ToString())
                {
                    // Change Payment status:Receivable to Paid (If Event Active)
                    if (ViewState["EventStatus"] != null &&
                        Convert.ToString(ViewState["EventStatus"]) == EventStatus.Canceled.ToString())
                    {
                        _hostDepositInfo.Status = HostPaymentStatus.Paid;
                    }
                }
                var addressService = IoC.Resolve<IAddressService>();
                addressService.SaveAfterSanitizing(_hostDepositInfo.PaymentMailingAddress);

                hostDepositRepository.Save(_hostDepositInfo);
            }
            else
            {
                if (objEventWizard.EventID > 0)
                {
                    IHostDeositRepository hostDepositRepository = new HostDepositRepository();
                    try
                    {
                        var hostDepositInfo = hostDepositRepository.GetById(objEventWizard.EventID);
                        if (currentEventStatus == "Canceled")
                        {
                            if (hostDepositInfo.Status == HostPaymentStatus.Paid)
                                hostDepositInfo.Status = HostPaymentStatus.Receivable;
                            hostDepositRepository.Save(hostDepositInfo);
                        }
                        else if (currentEventStatus == EventStatus.Active.ToString())
                        {
                            // Change Payment status:Receivable to Paid (If Event Active)
                            if (ViewState["EventStatus"] != null &&
                                Convert.ToString(ViewState["EventStatus"]) == EventStatus.Canceled.ToString())
                            {
                                hostDepositInfo.Status = HostPaymentStatus.Paid;
                            }
                            hostDepositRepository.Save(hostDepositInfo);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private bool CheckHostPaymentInfo(EEventWizard objEventWizard)
        {
            if ((Convert.ToDateTime(objEventWizard.EventDate) - DateTime.Now).Days < 14)
            {
                _defaultDayForHostPayment = -1;
            }

            if (_hostPaymentInfo != null)
            {
                if (_hostPaymentInfo.DueDate.ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                {
                    _hostPaymentInfo.DueDate =
                        Convert.ToDateTime(objEventWizard.EventDate).AddDays(_defaultDayForHostPayment);

                }
                if (!string.IsNullOrEmpty(objEventWizard.PaymentDueDate))
                {
                    objEventWizard.PaymentDueDate = _hostPaymentInfo.DueDate.ToString();
                }
            }
            if (_hostDepositInfo != null)
            {
                if (objEventWizard.EventID == 0 && Session["DepositFullRefundDueDate"] != null)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["DepositFullRefundDueDate"])))
                    {
                        TimeSpan noOfDaysBeforeEvent = Convert.ToDateTime(objEventWizard.EventDate) -
                                                       Convert.ToDateTime(Session["DepositFullRefundDueDate"]);
                        _hostDepositInfo.DepositFullRefundDueDays = noOfDaysBeforeEvent.Days;
                        // check for eventCanceled by date should be less than or equals to eventDate.
                        if (noOfDaysBeforeEvent.Days < 0 && _hostDepositInfo.IsActive) return false;
                    }
                }
                else if (_hostDepositInfo.DepositFullRefundDueDays < 0 && _hostDepositInfo.IsActive)
                {
                    return false;
                }

                if (_hostDepositInfo.DueDate.ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                {
                    _hostDepositInfo.DueDate =
                        Convert.ToDateTime(objEventWizard.EventDate).AddDays(_defaultDayForHostPayment);
                }
                if (!string.IsNullOrEmpty(objEventWizard.DepositDueDate))
                {
                    objEventWizard.DepositDueDate = _hostDepositInfo.DueDate.ToString();
                }
            }
            return true;
        }

        private bool CheckStandardEventTime(EEventWizard objEventWizard)
        {
            if (objEventWizard != null)
            {
                if (!string.IsNullOrEmpty(objEventWizard.TeamArrivalTime) && !string.IsNullOrEmpty(objEventWizard.TeamDepartureTime))
                {
                    if (Convert.ToDateTime(StandardTeamArrivalTime) != Convert.ToDateTime(objEventWizard.TeamArrivalTime) || Convert.ToDateTime(StandardTeamDepartureTime) != Convert.ToDateTime(objEventWizard.TeamDepartureTime))
                        return true;
                }
            }
            return false;
        }



        private string CheckForPackageIncludedTests(string packageIds, string testIds)
        {
            string confirmScript = string.Empty;

            if (!string.IsNullOrEmpty(packageIds))
                packageIds = packageIds.Substring(0, packageIds.Length - 1);

            if (!string.IsNullOrEmpty(testIds))
                testIds = testIds.Substring(0, testIds.Length - 1);
            if (string.IsNullOrEmpty(packageIds)) return "";
            var masterDal = new MasterDAL();
            var returnTestIds = masterDal.CheckPackageTestDependencyRule(packageIds, testIds);

            if (!string.IsNullOrEmpty(returnTestIds))
            {
                string[] testIdstoSelect = returnTestIds.Split(',');

                foreach (GridViewRow grv in _testGrid.Rows)
                {
                    var testIdHiddenField = grv.FindControl("hfTestId") as HiddenField;
                    var testName = grv.FindControl("_testName") as HtmlContainerControl;

                    for (int i = 0; i < testIdstoSelect.Length; i++)
                    {
                        if (testIdHiddenField != null && (!string.IsNullOrEmpty(testIdHiddenField.Value)) && testIdHiddenField.Value == testIdstoSelect[i])
                        {
                            confirmScript = (testName != null) && (!string.IsNullOrEmpty(testName.InnerHtml)) ? confirmScript + testName.InnerHtml.Trim() + ", " : confirmScript;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(confirmScript))
            {
                confirmScript = confirmScript.Replace('\'', '"').Trim();
                confirmScript = confirmScript.Substring(0, confirmScript.Length - 1);
                confirmScript = "You need to select " + confirmScript + " as they are the part of the packages which will be offered for the event.";
            }
            return confirmScript;
        }

        private string CheckTestDependentOnTests(string testIds)
        {
            if (string.IsNullOrEmpty(testIds)) return "";
            var masterDal = new MasterDAL();
            var testList = masterDal.CheckDependentOnTests(testIds);
            string testMessage = string.Empty;

            if (testList != null && testList.Count > 0)
            {
                foreach (ETest test in testList)
                {
                    testMessage = testMessage + test.Name + " cannot be offered without offering the " +
                                      test.Description + ".\\n";
                }
            }
            return testMessage;
        }

        private string CheckForPackageTestScreeningTime(string packageIds, string testIds)
        {
            string confirmScript = string.Empty;

            if (!string.IsNullOrEmpty(packageIds))
            {
                var tempPackageIds = new List<long>();
                var tempRoomPackageIds = new List<long>();
                foreach (GridViewRow grv in grdSelectPackage.Rows)
                {
                    var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                    var hfPackageId = (HiddenField)grv.FindControl("hfPackageID");
                    var ddlPackageScreeningTime = (DropDownList)grv.FindControl("ddlPackageScreeningTime");

                    if (chkChild.Checked && Convert.ToInt32(ddlPackageScreeningTime.SelectedValue) < 1)
                    {
                        tempPackageIds.Add(Convert.ToInt64(hfPackageId.Value));
                    }
                }

                if (!tempPackageIds.IsNullOrEmpty())
                {
                    var packageRepository = IoC.Resolve<IUniqueItemRepository<Core.Marketing.Domain.Package>>();
                    var packages = packageRepository.GetByIds(tempPackageIds);
                    confirmScript = "<ul>";
                    confirmScript = packages.Aggregate(confirmScript, (current, package) => current + "<li>" + package.Name.Replace("'", "\\\'") + "</li>");
                    confirmScript = confirmScript.Trim();
                    confirmScript += "</ul>";
                    confirmScript = "Screening time for some of the packages are missing. To apply Dynamic Scheduling, Please enter screening time for following package(s): <br/><br/>" + confirmScript;
                    return confirmScript;
                }
            }

            if (!string.IsNullOrEmpty(testIds))
            {
                var tempTestIds = new List<long>();
                foreach (GridViewRow grv in _testGrid.Rows)
                {
                    var chkTestSelected = (HtmlInputCheckBox)grv.FindControl("chkTestSelected");
                    var hfPackageId = (HiddenField)grv.FindControl("hfTestId");
                    var ddlTestScreeningTime = (DropDownList)grv.FindControl("ddlTestScreeningTime");
                    if (chkTestSelected.Checked && Convert.ToInt32(ddlTestScreeningTime.SelectedValue) < 0)
                    {
                        tempTestIds.Add(Convert.ToInt64(hfPackageId.Value));
                    }
                }

                if (!tempTestIds.IsNullOrEmpty())
                {
                    var testRepository = IoC.Resolve<IUniqueItemRepository<Test>>();
                    var tests = testRepository.GetByIds(tempTestIds);
                    confirmScript = "<ul>";
                    confirmScript = tests.Aggregate(confirmScript, (current, test) => current + "<li>" + test.Name.Replace("'", "\\\'") + "</li>");
                    confirmScript = confirmScript.Trim();
                    confirmScript += "</ul>";
                    confirmScript = "Screening time for some of the tests are missing. To apply Dynamic Scheduling, Please enter screening time for following test(s): <br/><br/>" + confirmScript;
                    return confirmScript;
                }
            }
            return confirmScript;
        }

        private string CheckForPackageTestRoom(string packageIds)
        {
            string confirmScript = string.Empty;

            if (!string.IsNullOrEmpty(packageIds))
            {
                foreach (GridViewRow grv in grdSelectPackage.Rows)
                {
                    var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                    var hfPackageId = (HiddenField)grv.FindControl("hfPackageID");
                    var ddlPackageScreeningRoom = (DropDownList)grv.FindControl("ddlPackageScreeningRoom");
                    var lblPackageName = (Label)grv.FindControl("lblPackageName");
                    long packageId = Convert.ToInt64(hfPackageId.Value);
                    long packageScreeningRoomId = Convert.ToInt64(ddlPackageScreeningRoom.SelectedValue);

                    if (chkChild.Checked && packageScreeningRoomId > 0)
                    {
                        var message = ValidateRoomForTest(packageId, ddlPackageScreeningRoom.SelectedItem.ToString(), lblPackageName.Text);
                        if (!string.IsNullOrEmpty(message))
                            confirmScript = confirmScript + message + "<br /> ";
                    }
                }
                if (!string.IsNullOrEmpty(confirmScript))
                {
                    return confirmScript;
                }
            }
            return confirmScript;
        }

        private string ValidateRoomForTest(long packageId, string roomNo, string packageName)
        {
            var packageTests = IoC.Resolve<ITestRepository>().GetTestsByPackageIds(new List<long>() { packageId });
            var selectedTestIds = new List<long>();
            var message = string.Empty;

            foreach (GridViewRow grv in gvPOD.Rows)
            {
                var roomGridView = grv.FindControl("RoomGridView") as GridView;
                if (roomGridView != null)
                {
                    foreach (GridViewRow roomGridViewRow in roomGridView.Rows)
                    {
                        var hfRoomNo = roomGridViewRow.FindControl("hfRoomNo") as HiddenField;
                        if (hfRoomNo != null && hfRoomNo.Value == roomNo)
                        {
                            var testGridView = roomGridViewRow.FindControl("TestGridView") as GridView;
                            if (testGridView != null)
                            {
                                foreach (GridViewRow testGridViewRow in testGridView.Rows)
                                {
                                    var hfTestId = testGridViewRow.FindControl("hfTestId") as HiddenField;
                                    var chkIsSelected =
                                        testGridViewRow.FindControl("chkIsSelected") as HtmlInputCheckBox;
                                    if (hfTestId != null && chkIsSelected != null && chkIsSelected.Checked)
                                    {
                                        selectedTestIds.Add(Convert.ToInt64(hfTestId.Value));
                                    }
                                }
                            }
                        }
                    }

                }
            }
            var expectTestList = packageTests.Select(x => x.Id).Except(selectedTestIds);
            if (expectTestList.Any())
            {
                message = "&#8226; Package " + packageName + " contains tests " + string.Join(", ", packageTests.Where(x => expectTestList.Contains(x.Id)).Select(x => x.Alias)) + " which are not available in Room " + roomNo;
            }
            return message;
        }

        private bool CheckAnyCustomerIsRegisteredInEvent(string packageIds)
        {
            bool flag = false;

            if (!PackageTimeOnlyCheckbox.Checked) return flag;

            if (string.IsNullOrEmpty(packageIds)) return flag;

            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
            var evenCustomers = eventCustomerRepository.GetbyEventId(EventId.Value);

            if (evenCustomers == null || evenCustomers.Count() == 0 || evenCustomers.Where(x => x.AppointmentId != null).Count() == 0) return flag;

            foreach (GridViewRow grv in grdSelectPackage.Rows)
            {
                var chkChild = (HtmlInputCheckBox)grv.FindControl("chkRowChild");
                var ddlPackageScreeningRoom = (DropDownList)grv.FindControl("ddlPackageScreeningRoom");
                var hdfPackageScreeningRoomID = (HiddenField)grv.FindControl("hdfPackageScreeningRoomID");

                long roomID = 0;

                if (hdfPackageScreeningRoomID != null && hdfPackageScreeningRoomID.Value != "")
                {
                    roomID = Convert.ToInt64(hdfPackageScreeningRoomID.Value);
                }

                if (roomID != 0)
                {
                    long packageScreeningRoomId = Convert.ToInt64(ddlPackageScreeningRoom.SelectedValue);

                    if (chkChild.Checked && packageScreeningRoomId > 0 && roomID != packageScreeningRoomId)
                    {
                        flag = true;
                        break;
                    }
                }
            }

            return flag;
        }


        private string CheckForStaticDynamicScheduling(long eventId, bool isDynamicScheduling, Event oldEvent)
        {
            string confirmScript = string.Empty;

            if (oldEvent != null && isDynamicScheduling != oldEvent.IsDynamicScheduling)
            {
                var customerRegistered = GetCustomerRegistered(eventId);

                if (customerRegistered)
                    confirmScript =
                        "Customers are already registered for the event. You cannot change the scheduling for the event.";
            }

            return confirmScript;
        }

        private string CheckForIsPackageTimeOnly(long eventId, bool isPackageTimeOnly, Event oldEvent)
        {
            string confirmScript = string.Empty;

            if (oldEvent != null && oldEvent.IsPackageTimeOnly && isPackageTimeOnly != oldEvent.IsPackageTimeOnly)
            {
                var customerRegistered = GetCustomerRegistered(eventId);

                if (customerRegistered)
                    confirmScript =
                        "Customers are already registered for the event. You cannot change the Package Time Only for the event.";
            }

            return confirmScript;
        }

        private string CheckForPodRoomChange(long eventId, List<EventPodEditModel> eventPodEditModels, Event oldEvent)
        {
            string confirmScript = string.Empty;

            var customerRegistered = GetCustomerRegistered(eventId);

            if (customerRegistered)
            {
                var existingPodIds = oldEvent.PodIds;
                var currentPodIds = eventPodEditModels.Select(m => m.PodId).ToArray();
                var isSame = existingPodIds.Count() == currentPodIds.Count() && existingPodIds.All(m => currentPodIds.Contains(m));

                if (!isSame)
                    confirmScript = "Customers are already registered for the event. You cannot change the pod for the event.";
                else
                {
                    var eventPodRoomRepository = IoC.Resolve<IEventPodRoomRepository>();
                    var existingPodRooms = eventPodRoomRepository.GetByEventIdAndPodIds(eventId, existingPodIds);
                    var currentPodRooms = eventPodEditModels.SelectMany(m => m.EventPodRooms);

                    if (existingPodRooms != null && existingPodRooms.Any())
                    {
                        foreach (var currentPodRoom in currentPodRooms)
                        {
                            var existingPodRoom = existingPodRooms.SingleOrDefault(m => m.RoomNo == currentPodRoom.RoomNo);
                            if (existingPodRoom == null)
                                confirmScript = "Customers are already registered for the event. You cannot add room " + currentPodRoom.RoomNo + " in the pod for the event.";
                            else if (existingPodRoom.Duration != currentPodRoom.Duration)
                                confirmScript = "Customers are already registered for the event. You cannot change duration for room " + currentPodRoom.RoomNo + " in the pod for the event.";

                            if (!string.IsNullOrEmpty(confirmScript))
                                return confirmScript;
                        }

                        foreach (var existingPodRoom in existingPodRooms)
                        {
                            var currentPodRoom = currentPodRooms.SingleOrDefault(m => m.RoomNo == existingPodRoom.RoomNo);
                            if (currentPodRoom == null)
                                confirmScript = "Customers are already registered for the event. You cannot remove room " + existingPodRoom.RoomNo + " in the pod for the event.";
                            else if (existingPodRoom.Duration != currentPodRoom.Duration)
                                confirmScript = "Customers are already registered for the event. You cannot change duration for room " + currentPodRoom.RoomNo + " in the pod for the event.";

                            if (!string.IsNullOrEmpty(confirmScript))
                                return confirmScript;
                        }
                    }
                }
            }
            return confirmScript;

        }

        private string CheckForPodRoomTest(IEnumerable<long> testIds, List<EventPodEditModel> eventPodEditModels)
        {
            string confirmScript = string.Empty;
            var selectedPodRoomTestIds = eventPodEditModels.SelectMany(epem => epem.EventPodRooms.SelectMany(m => m.EventPodRoomTests.Where(t => t.IsSelected).Select(t => t.TestId))).Distinct();
            var notIncludedTestIds = testIds.Where(t => !selectedPodRoomTestIds.Contains(t)).Select(t => t);

            if (notIncludedTestIds != null && notIncludedTestIds.Any())
            {
                var testRepository = IoC.Resolve<IUniqueItemRepository<Test>>();
                var tests = testRepository.GetByIds(notIncludedTestIds);
                confirmScript = "<ul>";
                confirmScript = tests.Aggregate(confirmScript, (current, test) => current + "<li>" + test.Alias.Replace("'", "\\\'") + "</li>");
                confirmScript = confirmScript.Trim();
                confirmScript += "</ul>";
                confirmScript = "Following test(s) are not available in pod attached with the event: <br/><br/>" + confirmScript;
                return confirmScript;
            }
            return confirmScript;
        }

        private bool GetCustomerRegistered(long eventId)
        {
            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
            var eventCustomers = eventCustomerRepository.GetbyEventId(eventId);

            var customerRegistered = false;
            if (eventCustomers != null && eventCustomers.Count() > 0)
            {
                customerRegistered = eventCustomers.Where(ec => ec.AppointmentId.HasValue).Any();
            }
            return customerRegistered;
        }

        public string CheckForDuration(EEventWizard eventWizard, Event oldEvent)
        {
            string confirmScript = string.Empty;

            var customerRegistered = GetCustomerRegistered(eventWizard.EventID);
            if (customerRegistered && oldEvent != null)
            {
                if (Convert.ToDateTime(oldEvent.EventStartTime.ToShortTimeString()) < Convert.ToDateTime(eventWizard.EventStartTime))
                {
                    confirmScript = "Customers are already registered for the event. You cannot change Team arrival time for the event.";
                }
                else if (Convert.ToDateTime(oldEvent.EventEndTime.ToShortTimeString()) > Convert.ToDateTime(eventWizard.EventEndTime))
                {
                    confirmScript = "Customers are already registered for the event. You cannot change Team departure time for the event.";
                }
                else if (oldEvent.LunchDuration != eventWizard.LunchDuration)
                {
                    confirmScript = "Customers are already registered for the event. You cannot change Lunch duration for the event.";
                }
                else if (oldEvent.LunchStartTime != eventWizard.LunchStartTime)
                {
                    confirmScript = "Customers are already registered for the event. You cannot change Lunch start time for the event.";
                }

            }

            return confirmScript;
        }

        public string CheckForHafTemplateChange(long eventId, Event oldEvent)
        {
            string confirmScript = string.Empty;

            if (!oldEvent.HealthAssessmentTemplateId.HasValue || oldEvent.HealthAssessmentTemplateId.Value == Convert.ToInt64(hfHealthAssessmentTemplateId.Value))
                return confirmScript;

            var healthAssessmentRepository = IoC.Resolve<IHealthAssessmentRepository>();
            var customersFilledHaf = healthAssessmentRepository.GetCustomerIdsforFilledHealthAssmtFormbyEventId(eventId);
            if (customersFilledHaf != null && customersFilledHaf.Any())
            {
                confirmScript = "Customer(s) Registered for the event have already filled their HAF. You cannot change the Health Assessment Form Template.";
                hfHealthAssessmentTemplateId.Value = oldEvent.HealthAssessmentTemplateId.Value.ToString();
            }
            return confirmScript;
        }

        private void SaveEventPod(IEnumerable<EventPodEditModel> models, long eventId)
        {
            var eventPodService = IoC.Resolve<IEventPodService>();
            eventPodService.SaveEventPod(models, eventId);
        }

        private void BindPodDetails(IEnumerable<long> podIds, long eventId)
        {
            if (podIds.Any())
            {
                var eventPodService = IoC.Resolve<IEventPodService>();
                var eventPodList = eventPodService.GetEventPodEditModels(eventId, podIds);

                gvPOD.DataSource = eventPodList;

                hfPodID.Value = string.Join(",", podIds.Select(p => p.ToString()));
            }
            else
            {
                hfPodID.Value = "";
                gvPOD.DataSource = null;
            }
            gvPOD.DataBind();
        }

        protected void gvPOD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var eventPodEditModel = e.Row.DataItem as EventPodEditModel;
                var roomGridView = (GridView)e.Row.FindControl("RoomGridView");
                if (eventPodEditModel.EventPodRooms != null && eventPodEditModel.EventPodRooms.Any())
                    roomGridView.DataSource = eventPodEditModel.EventPodRooms;
                else
                    roomGridView.DataSource = null;
                roomGridView.DataBind();
            }
        }

        protected void RoomGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var eventPodRoomEditModel = e.Row.DataItem as EventPodRoomEditModel;
                var testGridView = (GridView)e.Row.FindControl("TestGridView");
                if (eventPodRoomEditModel.EventPodRoomTests != null && eventPodRoomEditModel.EventPodRoomTests.Any())
                    testGridView.DataSource = eventPodRoomEditModel.EventPodRoomTests;
                else
                    testGridView.DataSource = null;
                testGridView.DataBind();
            }
        }

        private void CreateSlots(bool isNew, long eventId, Event oldEvent, IEnumerable<EventPodRoom> oldPodRooms)
        {
            var slotService = IoC.Resolve<IEventSchedulingSlotService>();
            var eventRepository = IoC.Resolve<IEventRepository>();
            var eventPodRoomRepository = IoC.Resolve<IEventPodRoomRepository>();

            var currentEvent = eventRepository.GetById(eventId);
            var currentPodRooms = eventPodRoomRepository.GetByEventIdAndPodIds(eventId, currentEvent.PodIds);

            if (isNew)
                slotService.SaveEventSlot(eventId, currentEvent.EventDate, currentEvent.EventStartTime, currentEvent.EventEndTime, currentEvent.LunchStartTime, currentEvent.LunchDuration, currentPodRooms);
            else
            {
                bool reCreateSlots = (oldEvent.EventStartTime != currentEvent.EventStartTime) || (oldEvent.EventEndTime != currentEvent.EventEndTime);

                var isCustomerRegistered = GetCustomerRegistered(eventId);

                if (!reCreateSlots)
                {
                    reCreateSlots = (oldEvent.LunchDuration.HasValue && !currentEvent.LunchDuration.HasValue)
                                     || (!oldEvent.LunchDuration.HasValue && currentEvent.LunchDuration.HasValue)
                                     || (oldEvent.LunchDuration.HasValue && currentEvent.LunchDuration.HasValue && oldEvent.LunchDuration.Value != currentEvent.LunchDuration.Value);
                }
                if (!reCreateSlots)
                {
                    reCreateSlots = (oldEvent.LunchStartTime.HasValue && !currentEvent.LunchStartTime.HasValue)
                                     || (!oldEvent.LunchStartTime.HasValue && currentEvent.LunchStartTime.HasValue)
                                     || (oldEvent.LunchStartTime.HasValue && currentEvent.LunchStartTime.HasValue && oldEvent.LunchStartTime.Value != currentEvent.LunchStartTime.Value);

                }
                if (!reCreateSlots)
                {
                    var existingPodIds = oldEvent.PodIds;
                    var currentPodIds = currentEvent.PodIds;
                    var isSame = existingPodIds.Count() == currentPodIds.Count() && existingPodIds.All(m => currentPodIds.Contains(m));
                    reCreateSlots = !isSame;
                }
                if (!reCreateSlots)
                {
                    foreach (var currentPodRoom in currentPodRooms)
                    {
                        var existingPodRoom = oldPodRooms.SingleOrDefault(m => m.RoomNo == currentPodRoom.RoomNo);
                        if (existingPodRoom == null)
                            reCreateSlots = true;
                        else if (existingPodRoom.Duration != currentPodRoom.Duration)
                            reCreateSlots = true;

                        if (reCreateSlots)
                            break;
                    }
                }
                if (!reCreateSlots)
                {
                    foreach (var existingPodRoom in oldPodRooms)
                    {
                        var currentPodRoom = currentPodRooms.SingleOrDefault(m => m.RoomNo == existingPodRoom.RoomNo);
                        if (currentPodRoom == null)
                            reCreateSlots = true;
                        else if (existingPodRoom.Duration != currentPodRoom.Duration)
                            reCreateSlots = true;

                        if (reCreateSlots)
                            break;
                    }
                }

                if (reCreateSlots && !isCustomerRegistered)
                    slotService.SaveEventSlot(eventId, currentEvent.EventDate, currentEvent.EventStartTime, currentEvent.EventEndTime, currentEvent.LunchStartTime, currentEvent.LunchDuration, currentPodRooms);
                else if (reCreateSlots && isCustomerRegistered && oldEvent != null)
                {
                    if (Convert.ToDateTime(oldEvent.EventStartTime.ToShortTimeString()) > Convert.ToDateTime(currentEvent.EventStartTime.ToShortTimeString()))
                    {
                        slotService.AddEventSlots(eventId, currentEvent.EventDate, currentEvent.EventStartTime, oldEvent.EventStartTime, currentEvent.LunchStartTime, currentEvent.LunchDuration, currentPodRooms);
                    }
                    if (Convert.ToDateTime(oldEvent.EventEndTime.ToShortTimeString()) < Convert.ToDateTime(currentEvent.EventEndTime.ToShortTimeString()))
                    {
                        slotService.AddEventSlots(eventId, currentEvent.EventDate, oldEvent.EventEndTime, currentEvent.EventEndTime, currentEvent.LunchStartTime, currentEvent.LunchDuration, currentPodRooms);
                    }
                }
            }
        }

    }

    public partial class Step2 : Step1
    {

    }
}