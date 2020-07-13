using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Repositories;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core;
using System.Web.Services;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.UI.App.Common.CreateEventWizard
{
    public partial class Step1 : Page
    {
        protected string ZipCode = string.Empty;

        protected string TechInstructionTip;
        protected string CallCenterInstructionTip;
        protected string PaymentNotes;
        protected string DepositNotes;

        protected long OrganizationRoleUserId
        {
            get
            {
                if (ViewState["OrganizationRoleUserId"] == null) ViewState["OrganizationRoleUserId"] = 0;
                return Convert.ToInt64(ViewState["OrganizationRoleUserId"]);
            }
            set { ViewState["OrganizationRoleUserId"] = value; }
        }

        public long OrganizationId
        {
            get
            {
                var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                    return Convert.ToInt64(_hidFranchiseeId.Value);
                return currentOrgRole.OrganizationId;
            }
        }

        public long? EventId
        {
            get
            {
                long eventId;
                long.TryParse(Request.QueryString["EventID"], out eventId);
                return eventId > 0 ? eventId : (long?)null;
            }
        }

        private int _averageHostPerformanceULimit;

        private int _badHostPerformanceULimit;

        private HostPayment _hostPaymentInfo;
        private HostDeposit _hostDepositInfo;

        private string StandardTeamArrivalTime
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EventStartTime);
            }
        }
        private string StandardTeamDepartureTime
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EventEndTime);
            }
        }

        private string StandardLunchStartTime
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.LunchStartTime);
            }
        }

        protected bool GlobalAskPreQualificationQuestion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            var objMaster = (Franchisor_FranchisorMaster)Master;
            if (objMaster != null)
            {
                objMaster.hideucsearch();
                objMaster.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/Dashboard.aspx\">Dashboard></a>";
                objMaster.settitle("Host Info");
            }

            var otherDal = new OtherDAL();
            _badHostPerformanceULimit = Convert.ToInt32(otherDal.GetConfigurationValue("BadHostPerformanceUpperLimit"));
            _averageHostPerformanceULimit =
                Convert.ToInt32(otherDal.GetConfigurationValue("AverageHostPerformanceUpperLimit"));

            var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
            GlobalAskPreQualificationQuestion = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion));
            if (!IsPostBack)
            {
                Page.Title = "Host Info";
                FillDropDownInfo();
                Bind_ProductList();
                if ((Request.UrlReferrer == null) || (Request.QueryString["Type"] != null && Request.QueryString["Type"].Equals("Create")))
                    RemoveSession();
                chkReminderTask.Attributes.Add("onClick", "return showHidePaymentDue();");
                rbtnMinReqYes.Attributes.Add("onClick", "return showMinReqDetails();");
                rbtnMinReqNo.Attributes.Add("onClick", "return hideMinReqDetails();");
                txtCostOfHost.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
                txtDepositAmount.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
                _txtCostDeliverZip.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
                _txtDepositDeliverZip.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");

                _rbtnYPayment.Attributes.Add("onClick", "return ShowPaymentDetails();");
                _rbtnNPayment.Attributes.Add("onClick", "return HidePaymentDetails();");

                _rbtDepositY.Attributes.Add("onClick", "return ShowDepositDetails();");
                _rbtDepositN.Attributes.Add("onClick", "return HideDepositDetails();");

                var enableAlaCarte = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
                if (enableAlaCarte)
                {
                    EnableAlaCarteOnlineCheckbox.Checked = true;
                    EnableAlaCarteCallCenterCheckbox.Checked = true;
                    EnableAlaCarteTechnicianCheckbox.Checked = true;
                    EnableAlaCarteDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                else
                {
                    EnableAlaCarteDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                }

                DynamicSchedulingNoRadioBtn.Checked = true;
                EnableProductCheckbox.Checked = true;
                AskPreQualificationQuestion.Checked = true;
                RecommendPackageCheckbox.Checked = false;

                EnableForCallCenter.Checked = true;
                EnableForTechnician.Checked = true;

                var enableDynamicSlot = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableDynamicSlot));
                if (enableDynamicSlot)
                {
                    DynamicSlotDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                else
                {
                    DynamicSlotDiv.Style.Add(HtmlTextWriterStyle.Display, "none");

                }

                if (EventId.HasValue)
                {
                    var masterDal = new MasterDAL();
                    EEventWizard objEventWizard =
                        masterDal.GetEventWizardDetails(Convert.ToInt32(EventId.Value));
                    objEventWizard.EditEvent = true;

                    if(!string.IsNullOrEmpty(objEventWizard.ProductType))
                    {
                        foreach(var item in objEventWizard.ProductType.Split(','))
                        {
                            foreach (ListItem eventProductitem in EventProductType.Items)
                            {
                                if (eventProductitem.Value==item)
                                {
                                    eventProductitem.Selected = true;
                                }
                            }   
                        }
                    }

                    if (objEventWizard.Host != null && objEventWizard.Host.Address != null)
                    {
                        objEventWizard.Host.Name = objEventWizard.Host.Name.Replace("'", "&#39");
                        objEventWizard.Host.Address.Address1 = objEventWizard.Host.Address.Address1.Replace("'", "&#39");
                        objEventWizard.Host.Address.Address2 = objEventWizard.Host.Address.Address2.Replace("'", "&#39");
                    }
                    if (objEventWizard.CooperateAccountId > 0)
                    {
                        var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                        if (corporateAccountRepository.IsCorporateAccount(objEventWizard.CooperateAccountId))
                        {
                            ddlCooperateAccounts.SelectedValue = objEventWizard.CooperateAccountId.ToString();
                            ddlEventType.SelectedValue = Convert.ToInt32(EventType.Corporate).ToString();
                        }
                        else
                        {
                            ddlEventType.SelectedValue = Convert.ToInt32(EventType.HealthPlan).ToString();
                            ddlHealthPlan.SelectedValue = objEventWizard.CooperateAccountId.ToString();
                        }                        
                        CaptureInsuranceIdCheckbox.Checked = objEventWizard.CaptureInsuranceId;
                        InsuranceIdRequiredCheckbox.Checked = objEventWizard.InsuranceIdRequired;
                        EnableProductCheckbox.Checked = objEventWizard.EnableProduct;
                    }

                    if (objEventWizard.HospitalPartnerId > 0)
                    {
                        HospitalPartnerYesRadioBtn.Checked = true;
                        ddlHospitalPartner.SelectedValue = objEventWizard.HospitalPartnerId.ToString();
                        AttachHospitalMaterialCheckbox.Checked = objEventWizard.AttachHospitalMaterial;
                        CaptureSsnCheckbox.Checked = objEventWizard.CaptureSsn;
                        RestrictEvaluationCheckbox.Checked = objEventWizard.RestrictEvaluation;
                    }

                    RecommendPackageCheckbox.Checked = objEventWizard.RecommendPackage;
                    AskPreQualificationQuestion.Checked = objEventWizard.AskPreQualificationQuestion;

                    EnableForCallCenter.Checked = objEventWizard.EnableForCallCenter;
                    EnableForTechnician.Checked = objEventWizard.EnableForTechnician;


                    FillHostDetails(objEventWizard);

                    headingEventWizard.InnerText = "Edit Event Wizard";
                    if (objEventWizard.IsDynamicScheduling && !enableDynamicSlot)
                    {
                        DynamicSlotDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                        DynamicSchedulingYesRadioBtn.Disabled = true;
                        DynamicSchedulingNoRadioBtn.Disabled = true;
                    }
                }
                else if (Session["SearchText"] != null)
                {
                    txtSearch.Text = Session["SearchText"].ToString();
                    txtCity.Text = Session["City"].ToString();



                    SearchHost();
                    if (Request.QueryString["Type"] != null && Request.QueryString["HostID"] != null)
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "jscode_selecthost",
                                                           "selectHost(" + Request.QueryString["HostID"] + ");", true);
                    }
                }
                else if (Request.QueryString["Type"] != null && Request.QueryString["Type"].Equals("Create") &&
                         Request.QueryString["HostID"] != null)
                {
                    hfHostID.Value = Request.QueryString["HostID"];
                    SearchHost();
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_selecthost",
                                                       "selectHost(" + Request.QueryString["HostID"] + ");", true);
                }
                // When host details is edited and return to the page.
                else if (Request.QueryString["Type"] != null && Request.QueryString["Type"].Equals("Selected") &&
                         Request.QueryString["HostID"] != null)
                {
                    hfHostID.Value = Request.QueryString["HostID"];
                    SearchHost();
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_selecthost",
                                                       "selectHost(" + Request.QueryString["HostID"] + ");",
                                                       true);
                }
                var objOtherDal = new OtherDAL();
                TechInstructionTip = objOtherDal.GetToolTipByTagName(ToolTipType.EventWizardTechnicianInstructions.ToString());
                CallCenterInstructionTip = objOtherDal.GetToolTipByTagName(ToolTipType.EventWizardInstructionsForCallCenterRep.ToString());

                // set organizationRoleUserId
                SetOrganizationRoleUserId();

                //Step2
                ddlHHStartTime.SelectedValue = StandardTeamArrivalTime.Substring(0, 2);
                ddlMMStartTime.SelectedValue = StandardTeamArrivalTime.Substring(3, 2);
                ddlAMPMStartTime.SelectedValue = StandardTeamArrivalTime.Substring(6, 2);

                ddlHHEndTime.SelectedValue = StandardTeamDepartureTime.Substring(0, 2);
                ddlMMEndTime.SelectedValue = StandardTeamDepartureTime.Substring(3, 2);
                ddlAMPMEndTime.SelectedValue = StandardTeamDepartureTime.Substring(6, 2);

                ddlHHStartTime.Attributes["onChange"] = "checkDuration();";
                ddlMMStartTime.Attributes["onChange"] = "checkDuration();";
                ddlAMPMStartTime.Attributes["onChange"] = "checkDuration();";

                ddlHHEndTime.Attributes["onChange"] = "checkDuration();";
                ddlMMEndTime.Attributes["onChange"] = "checkDuration();";
                ddlAMPMEndTime.Attributes["onChange"] = "checkDuration();";

                var role = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                if (role.CheckRole((long)Roles.FranchisorAdmin) || role.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    divTaskAndSalesRepHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divTaskAndSalesRepDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                else if (role.CheckRole((long)Roles.SalesRep))
                {
                    divTaskAndSalesRepHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divTaskAndSalesRepDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                }

                divToolTip.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(otherDal.GetToolTipByTagName("EventWizardEventStatus"), true);

                ddlHHLunchStartTime.SelectedValue = StandardLunchStartTime.Substring(0, 2);
                ddlMMLunchStartTime.SelectedValue = StandardLunchStartTime.Substring(3, 2);
                ddlAMPMLunchStartTime.SelectedValue = StandardTeamDepartureTime.Substring(6, 2);
                EnableLunchDuration.Checked = true;

                if (ddlEventType.SelectedValue == Convert.ToInt32(EventType.Retail).ToString() && !EventId.HasValue)
                {
                    RecommendPackageCheckbox.Checked = true;
                }
            }

            
        }

        protected void ibtnFind_Click(object sender, ImageClickEventArgs e)
        {
            Page.Title = "Host Info";
            SearchHost();
        }

        protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
        {
            RemoveSession();
            if (EventId.HasValue)
            {
                Response.RedirectUser("/App/Common/EventDetails.aspx?EventID=" + EventId.Value);
            }
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

        protected void ibtnnext_Click(object sender, ImageClickEventArgs e)
        {
            Page.Title = "Event Info";
            var masterDal = new MasterDAL();
            List<EProspect> objProspect = masterDal.GetHostDetailsForEventWizard(hfHostID.Value, 0,
                                                                                 Convert.ToInt32(_hidSalesRep.Value),
                                                                                 Convert.ToInt32(Roles.SalesRep), "");
            HostId = objProspect[0].ProspectID;
            FillDropDown(objProspect[0].Address.Zip);

            var addressRepository = IoC.Resolve<IAddressRepository>();
            var address = addressRepository.GetAddress(objProspect[0].Address.AddressID);

            ddlRegigtrationMode.Attributes["onChange"] = "showHideInvitaionCode();";
            ddlEventStatus.Attributes["onChange"] = "ShowHideEventNotes();ShowHideEventCancellationReason();";
            ClientScript.RegisterStartupScript(typeof(string), "jscode_FirstTimeExecute", "checkDuration(); showHideInvitaionCode();", true);

            if (EventId.HasValue) headingEventWizard.InnerText = "Edit Event Wizard";
            HostNameStep2.InnerText = objProspect[0].OrganizationName;
            spHostAddress.InnerHtml = objProspect[0].Address.Address1 + "<br />" + objProspect[0].Address.City + ", " + objProspect[0].Address.State + " " + objProspect[0].Address.Zip;

            if (string.IsNullOrEmpty(hfPodID.Value))
                BindTerritory(address.ZipCode.Id);
            txtEventDate.Attributes["onChange"] = "return checkEventDate();";
            ddlTerritory.Attributes["onChange"] = "return FillPOD('" + OrganizationId + "');";

            ddlMMLunchStartTime.SelectedValue = StandardLunchStartTime.Substring(3, 2);

            var timeZoneHelper = IoC.Resolve<ITimeZoneHelper>();
            var zipRepository = IoC.Resolve<IZipCodeRepository>();
            var zip = zipRepository.GetZipCode(address.ZipCode.Id);
            var timeZoneHours = Math.Abs((int)zip.TimeZone);
            ddlTimeZone.SelectedValue = timeZoneHelper.GetTimeZones().Where(q => q.Hours == timeZoneHours && q.IsDayLightSaving == zip.IsInDaylightSavingsTime).Select(q => q.Name).FirstOrDefault();

            if (EventId.HasValue)
            {
                EEventWizard objEventWizard =
                    masterDal.GetEventWizardDetails(Convert.ToInt32(EventId.Value));
                objEventWizard.EditEvent = true;
                FillEventDetails(objEventWizard);
                IsEventLocked = objEventWizard.IsLock;
            }
            Step1Div.Style.Add(HtmlTextWriterStyle.Display, "none");
            Step2div.Style.Add(HtmlTextWriterStyle.Display, "block");
            ClientScript.RegisterStartupScript(typeof(string), "jscode_showpod", "checkEventDate();", true);
        }

        protected void gvHostDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dtHost = (DataTable)ViewState["tblHost"];
                DataRow drvCurrent = dtHost.Rows[e.Row.DataItemIndex];
                var googleMapUrl = e.Row.FindControl("_googleMapUrl") as HtmlAnchor;
                if (googleMapUrl != null)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(drvCurrent["Latitude"])) &&
                        !string.IsNullOrEmpty(Convert.ToString(drvCurrent["Logitude"])) &&
                        Convert.ToBoolean(drvCurrent["UseLatLogForMapping"]))
                        googleMapUrl.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" +
                                            Convert.ToString(drvCurrent["Latitude"]) + "," +
                                            Convert.ToString(drvCurrent["Logitude"]) + "(" +
                                            Convert.ToString(drvCurrent["Address1"]) + ")" + "&ie=UTF8&z=16";
                    else
                    {
                        googleMapUrl.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" +
                                            Convert.ToString(drvCurrent["Address1"]) + "," +
                                            Convert.ToString(drvCurrent["City"]) + "," +
                                            Convert.ToString(drvCurrent["State"]) + "," +
                                            Convert.ToString(drvCurrent["Zip"]) +
                                            "&ie=UTF8&z=16";
                    }
                }

                string address2 = Convert.ToString(drvCurrent["Address2"]);
                var pAddress2 = (HtmlContainerControl)e.Row.FindControl("pAddress2");
                pAddress2.Style.Add(HtmlTextWriterStyle.Display, address2.Length > 0 ? "block" : "none");

                var lbtnEditContact = (LinkButton)e.Row.FindControl("lbtnEditContact");
                lbtnEditContact.Text = Convert.ToInt32(drvCurrent["ContactID"]) == 0 ? "Add" : "Edit";

                var rank = (HtmlContainerControl)e.Row.FindControl("spRank");
                var ranking = (HtmlImage)e.Row.FindControl("imgRanking");
                if (Convert.ToInt32(drvCurrent["TotalEvent"]) == 0)
                {
                    rank.InnerText = "-NA-";
                    ranking.Src = "/App/Images/na-sign.gif";
                }
                else
                {
                    if (Convert.ToInt32(drvCurrent["CustomersPerEvent"]) >= 0 &&
                        Convert.ToInt32(drvCurrent["CustomersPerEvent"]) <= _badHostPerformanceULimit)
                    {
                        rank.InnerText = "Bad";
                        ranking.Src = "/App/Images/bad-sign.gif";
                    }
                    else if (Convert.ToInt32(drvCurrent["CustomersPerEvent"]) > _badHostPerformanceULimit &&
                             Convert.ToInt32(drvCurrent["CustomersPerEvent"]) <= _averageHostPerformanceULimit)
                    {
                        rank.InnerText = "Average";
                        ranking.Src = "/App/Images/Average-sign.gif";
                    }
                    else
                    {
                        rank.InnerText = "Good";
                        ranking.Src = "/App/Images/good-sign.gif";
                    }
                }
            }
        }

        protected void gvHostDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["tblHost"] != null)
            {
                var dtHost = (DataTable)ViewState["tblHost"];
                gvHostDetails.PageIndex = e.NewPageIndex;
                gvHostDetails.DataSource = dtHost;
                gvHostDetails.DataBind();
            }
        }

        protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
        {
            divGVHostDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoHostFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            divHostDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
            txtSearch.Text = "";
        }

        protected void lbtnEditContact_Click(object sender, EventArgs e)
        {
            var lbtnEditContact = (LinkButton)sender;
            int contactid = Convert.ToInt32(lbtnEditContact.CommandName);
            int hostid = Convert.ToInt32(lbtnEditContact.CommandArgument);
            if (Convert.ToInt32(hfHostID.Value) > 0)
            {
                if (contactid > 0)
                    Response.RedirectUser("/App/Franchisor/AddNewContact.aspx?Type=Selected&ProspectID=" + hostid +
                                      "&ContactID=" + contactid);
                else
                    Response.RedirectUser("/App/Franchisor/AddNewContact.aspx?Type=Selected&IsHost=True&ProspectID=" +
                                      hostid);
            }
            else
            {
                if (contactid > 0)
                    Response.RedirectUser("/App/Franchisor/AddNewContact.aspx?ContactID=" + contactid);
                else
                    Response.RedirectUser("/App/Franchisor/AddNewContact.aspx?IsHost=True&ProspectID=" + hostid);
            }
        }

        private void BindTerritory(long zipId)
        {
            var territoryRepository = IoC.Resolve<ITerritoryRepository>();
            var territories = territoryRepository.GetTerritoriesFor(zipId, TerritoryType.Pod);
            ddlTerritory.Items.Clear();
            if (territories.Count() > 0)
            {
                ddlTerritory.DataSource = territories;
                ddlTerritory.DataTextField = "Name";
                ddlTerritory.DataValueField = "Id";
                ddlTerritory.DataBind();
                ddlTerritory.Items.Insert(0, new ListItem("Select Territory", "0"));
            }
            else
            {
                ddlTerritory.Items.Insert(0, new ListItem("No Territory Found", "0"));
                BindPod(OrganizationId, 0);
            }
        }


        private void SaveAddressLatitudeLongitude()
        {
            IAddressRepository addressRepository =
                new AddressRepository();
            if (!string.IsNullOrEmpty(_latitudeLongitudeText.Text))
            {
                if (_latitudeLongitudeText.Text.IndexOf(",") != -1)
                {
                    string[] latitudeLogitude = _latitudeLongitudeText.Text.Split(',');
                    long addressId = !string.IsNullOrEmpty(_addressId.Value) ? Convert.ToInt64(_addressId.Value) : 0;
                    if (latitudeLogitude.Length == 2 && addressId > 0)
                    {
                        addressRepository.UpdateAddressLatitudeAndLongitude(addressId, latitudeLogitude[0],
                                                                            latitudeLogitude[1], OrganizationRoleUserId,
                                                                            checkLatLongUseForMap.Checked);
                    }
                }
            }
        }

        private void FillDropDownInfo()
        {
            var masterDal = new MasterDAL();
            //Schedule Method
            // Mode '3' is used for getting All Active Schedule Method
            List<EScheduleMethod> listScheduleMethod = masterDal.GetScheduleMethod("", 3);
            if (listScheduleMethod != null)
            {
                foreach (EScheduleMethod objScheduleMethod in listScheduleMethod)
                    ddlScheduledBy.Items.Add(new ListItem(objScheduleMethod.Name,
                                                          objScheduleMethod.ScheduleMethodID.ToString()));
            }

            // Mode '3' is used for getting All Active Communication Modes
            List<ECommunicationMode> listCommMode = masterDal.GetCommunicationMode(string.Empty, 3);
            if (listCommMode != null)
            {
                foreach (ECommunicationMode objComm in listCommMode)
                    ddlCommunicationMode.Items.Add(new ListItem(objComm.Name, objComm.CommunicationModeID.ToString()));
            }

            ddlCommunicationMode.Items.Insert(0, new ListItem("Select Communication", ""));

            FillState();
            ddlEventType.Items.Clear();

            ddlEventType.Items.Add(new ListItem(EventType.Retail.ToString(), Convert.ToInt32(EventType.Retail).ToString()));
            ddlEventType.Items.Add(new ListItem(EventType.Corporate.ToString(), Convert.ToInt32(EventType.Corporate).ToString()));
            ddlEventType.Items.Add(new ListItem(EventType.HealthPlan.ToString(), Convert.ToInt32(EventType.HealthPlan).ToString()));

            var organizationRepository = IoC.Resolve<IOrganizationRepository>();
           
            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var healthPlanList = corporateAccountRepository.GetAllHealthPlan().OrderBy(x => x.Name);
            var cooperateAccountList = corporateAccountRepository.GetAllOnlyCorporateAccount().OrderBy(x=>x.Name);

            ddlCooperateAccounts.Items.Clear();
            if (cooperateAccountList.Count() > 0)
            {
                ddlCooperateAccounts.DataSource = cooperateAccountList;
                ddlCooperateAccounts.DataTextField = "Name";
                ddlCooperateAccounts.DataValueField = "Id";
                ddlCooperateAccounts.DataBind();
                ddlCooperateAccounts.Items.Insert(0, new ListItem("Select Account", "0"));
            }
            else
                ddlCooperateAccounts.Items.Insert(0, new ListItem("No Accounts Found", "0"));

            if (healthPlanList.Count() > 0)
            {
                ddlHealthPlan.DataSource = healthPlanList;
                ddlHealthPlan.DataTextField = "Name";
                ddlHealthPlan.DataValueField = "Id";
                ddlHealthPlan.DataBind();
                ddlHealthPlan.Items.Insert(0, new ListItem("Select Health Plan", "0"));
            }
            else
                ddlHealthPlan.Items.Insert(0, new ListItem("No Health Plan Found", "0"));

            var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
            var hospitalPartnerlist = hospitalPartnerRepository.GetIdNamePairsforHospitalPartners();
            ddlHospitalPartner.Items.Clear();
            if (hospitalPartnerlist.Count > 0)
            {
                ddlHospitalPartner.DataSource = hospitalPartnerlist;
                ddlHospitalPartner.DataTextField = "SecondValue";
                ddlHospitalPartner.DataValueField = "FirstValue";
                ddlHospitalPartner.DataBind();
                ddlHospitalPartner.Items.Insert(0, new ListItem("Select Hospital partner", "0"));
            }
            else
                ddlHospitalPartner.Items.Insert(0, new ListItem("No Hospital partner Found", "0"));
            // load franchisee and salesRep dropdown
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                _hidSalesRep.Value = "0";
                LoadFranchisee();
                if (_franchiseeDropDownList.SelectedIndex > -1 &&
                    (!string.IsNullOrEmpty(_franchiseeDropDownList.SelectedValue)))
                {
                    LoadSalesRepDropDownList(long.Parse(_franchiseeDropDownList.SelectedValue));
                }
                _divrolewrapper.Style.Add(HtmlTextWriterStyle.Display, "block");
                _spnFranchisee.Style.Add(HtmlTextWriterStyle.Display, "block");
                _spnSalesRep.Style.Add(HtmlTextWriterStyle.Display, "block");
                _divFranchisor.Style.Add(HtmlTextWriterStyle.Display, "block");
                _divFranchisee.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                _hidSalesRep.Value = "0";
                LoadSalesRepDropDownList(0);
                _divrolewrapper.Style.Add(HtmlTextWriterStyle.Display, "block");
                _spnSalesRep.Style.Add(HtmlTextWriterStyle.Display, "block");
                _spnFranchisee.Style.Add(HtmlTextWriterStyle.Display, "none");
                _divFranchisor.Style.Add(HtmlTextWriterStyle.Display, "none");
                _divFranchisee.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                _hidSalesRep.Value = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId.ToString();
                _divrolewrapper.Style.Add(HtmlTextWriterStyle.Display, "none");
                _spnSalesRep.Style.Add(HtmlTextWriterStyle.Display, "none");
                _spnFranchisee.Style.Add(HtmlTextWriterStyle.Display, "none");
                _divFranchisor.Style.Add(HtmlTextWriterStyle.Display, "none");
                _divFranchisee.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        private void FillHostDetails(EEventWizard objEventWizard)
        {
            var objOtherDal = new OtherDAL();
            var masterDal = new MasterDAL();
            List<EProspect> objProspect;
            if (objEventWizard != null && objEventWizard.EventID > 0)
            {
                if (objEventWizard.Franchisee.FranchiseeID > 0)
                {
                    _hidFranchiseeId.Value = objEventWizard.Franchisee.FranchiseeID.ToString();
                    _franchiseeDropDownList.SelectedValue = objEventWizard.Franchisee.FranchiseeID.ToString();
                    if (objEventWizard.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID > 0)
                    {
                        _hidSalesRepId.Value =
                            objEventWizard.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID.ToString();
                        _salesRepDropDownList.SelectedValue =
                            objEventWizard.FranchiseeFranchiseeUser.FranchiseeFranchiseeUserID.ToString();
                    }
                }

                if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                {
                    if (!string.IsNullOrEmpty(objEventWizard.EventDate))
                    {
                        int minDaysToFreezeEventDate =
                            Convert.ToInt32(objOtherDal.GetConfigurationValue("MinimumDaysToFreezeEventDate"));
                        if (Convert.ToDateTime(objEventWizard.EventDate) <
                            DateTime.Now.AddDays(minDaysToFreezeEventDate))
                        {
                            _divSearchHost.Style.Add(HtmlTextWriterStyle.Display, "none");
                            _divRemoveHost.Style.Add(HtmlTextWriterStyle.Display, "none");
                        }

                        else
                        {
                            _divSearchHost.Style.Add(HtmlTextWriterStyle.Display, "block");
                            _divRemoveHost.Style.Add(HtmlTextWriterStyle.Display, "block");
                        }
                    }
                }
                objProspect = masterDal.GetHostDetailsForEventWizard(objEventWizard.Host.HostID.ToString(),
                                                                                 0,
                                                                                 objEventWizard.FranchiseeFranchiseeUser
                                                                                     .FranchiseeFranchiseeUserID,
                                                                                 Convert.ToInt32(Roles.SalesRep), "");
                hfHostID.Value = objEventWizard.Host.HostID.ToString();
                if (objProspect != null && objProspect.Count() > 0)
                {
                    SetHost(objProspect[0]);
                    if (Convert.ToSingle(objProspect[0].ProspectDetails.FacilitiesFee) == 0)
                    {
                        if (objEventWizard.CosttoUseHostSite > 0)
                        {
                            divPayment.Style.Add(HtmlTextWriterStyle.Display, "block");
                            _rbtnYPayment.Checked = true;
                            hfPaymentRequired.Value = "1";
                        }
                        else
                        {
                            divPayment.Style.Add(HtmlTextWriterStyle.Display, "none");
                            _rbtnNPayment.Checked = true;
                            hfPaymentRequired.Value = "0";
                        }
                    }
                    else if (objEventWizard.EventID == 0)
                    {
                        divPayment.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                }

                if (!string.IsNullOrEmpty(objEventWizard.PaymentDueDate))
                {
                    chkReminderTask.Checked = true;
                    txtPaymentDue.Text = Convert.ToDateTime(objEventWizard.PaymentDueDate).ToString("MM/dd/yyyy");

                    if (!string.IsNullOrEmpty(objEventWizard.DepositDueDate))
                        txtDepositDue.Text = Convert.ToDateTime(objEventWizard.DepositDueDate).ToString("MM/dd/yyyy");
                }
                else
                {
                    chkReminderTask.Checked = false;
                }

                ddlScheduledBy.SelectedValue = objEventWizard.ScheduleMethodID.ToString();
                ddlCommunicationMode.SelectedValue = objEventWizard.CommunicationModeID.ToString();

                if (objEventWizard.MinimumSiteRequirements)
                {
                    rbtnMinReqYes.Checked = true;
                    divMinReqDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                    if (objEventWizard.ConfirmVisually)
                        rbtnCrfmVisually.Checked = true;
                    else
                        rbtnCrfmVerbally.Checked = true;
                }
                else
                {
                    rbtnMinReqNo.Checked = true;
                    divMinReqDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                txtComments.Text = objEventWizard.ConfirmComments;
                _txtInstructionForCallCenter.Text = objEventWizard.InstructionForCallCenter;
            }



        }

        private void SetHost(EProspect objProspect)
        {
            var objCommonCode = new CommonCode();

            ClientScript.RegisterStartupScript(typeof(string), "jsCodeFacilityRanking",
                                               "InitiateLoadHostRankingData(" + hfHostID.Value + ");", true);

            if (objProspect != null)
            {
                grdLegend.Style.Add(HtmlTextWriterStyle.Display, "block");
                spHostName.InnerText = objProspect.OrganizationName;
                _taxIdNumber.Text = objProspect.TaxIdNumber;
                pAddress1.InnerText = objProspect.Address.Address1;
                if (objProspect.Address.Address2.Length > 0)
                {
                    pAddress2.InnerText = objProspect.Address.Address2;
                    pAddress2.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                else
                    pAddress2.Style.Add(HtmlTextWriterStyle.Display, "none");

                ZipCode = objProspect.Address.Zip;
                pCityStateZip.InnerHtml = HttpUtility.HtmlEncode(objProspect.Address.City) + ",&nbsp;" + HttpUtility.HtmlEncode(objProspect.Address.State) +
                                          "&nbsp;&nbsp;" + HttpUtility.HtmlEncode(objProspect.Address.Zip);
                aEditHost.HRef = "/App/Common/AddNewHost.aspx?HostID=" + objProspect.ProspectID + (EventId.HasValue ? "&EventId=" + EventId.Value : "");
                if ((objProspect.Address.UseLatLogForMapping) &&
                    (!string.IsNullOrEmpty(objProspect.Address.Latitude)) &&
                    (!string.IsNullOrEmpty(objProspect.Address.Longitude)))
                {
                    aMapHost.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" +
                                    objProspect.Address.Latitude + "," + objProspect.Address.Longitude + "(" +
                                    objProspect.Address.Address1 + ")&ie=UTF8&z=16";
                    checkLatLongUseForMap.Checked = true;
                    //_newGoogleMap.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" + objProspect[0].Address.Latitude + "," + objProspect[0].Address.Longitude + "(" + objProspect[0].Address.Address1 + ")&ie=UTF8&z=16";
                }
                else
                {
                    aMapHost.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" +
                                    objProspect.Address.Address1 + "," + objProspect.Address.City + "," +
                                    objProspect.Address.State + "," + objProspect.Address.Zip + "&ie=UTF8&z=16";
                    checkLatLongUseForMap.Checked = false;
                }
                if ((!string.IsNullOrEmpty(objProspect.Address.Latitude)) &&
                    (!string.IsNullOrEmpty(objProspect.Address.Longitude)))
                    _latitudeLongitudeText.Text = objProspect.Address.Latitude + "," +
                                                  objProspect.Address.Longitude;

                // check/uncheck IsVerified check box
                if (objProspect.Address != null)
                {
                    if (objProspect.Address.IsManuallyVerified.HasValue &&
                        (!string.IsNullOrEmpty(objProspect.Address.Latitude)) &&
                        (!string.IsNullOrEmpty(objProspect.Address.Longitude)))
                    {
                        googleMapInCorrectVirtual.Checked = true;
                        _addressVerified.Value = "true";
                        _googleMapDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                        checkLatLongUseForMap.Enabled = false;
                        _latitudeLongitudeText.Enabled = false;
                    }
                    else if (objProspect.Address.IsManuallyVerified.HasValue)
                    {
                        googleMapCorrectVirtual.Checked = true;
                        _addressVerified.Value = "false";
                        _googleMapDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                        checkLatLongUseForMap.Enabled = false;
                        _latitudeLongitudeText.Enabled = false;
                    }
                    else
                    {
                        googleMapCorrectVirtual.Checked = false;
                        googleMapInCorrectVirtual.Checked = false;
                        _googleMapDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                    googleMapCorrectVirtual.Disabled = true;
                    googleMapInCorrectVirtual.Disabled = true;
                }

                _addressId.Value = objProspect.Address.AddressID.ToString();
                _hostaddress.Value = objProspect.Address.Address1;

                aMapHost.Target = "_blank";
                spTotalEvent.InnerText = objProspect.TotalEvent.ToString();
                spCustPerEvent.InnerText = objProspect.CustomersPerEvent.ToString();
                if (objProspect.Contact != null && objProspect.Contact.Count > 0)
                {
                    spPhHome.InnerText = objCommonCode.FormatPhoneNumberGet(objProspect.Contact[0].PhoneHome);
                    spPhCell.InnerText = objCommonCode.FormatPhoneNumberGet(objProspect.Contact[0].PhoneCell);
                    spEmail.InnerText = objProspect.Contact[0].EMail;

                    if (objProspect.Contact[0].MiddleName.Length > 0)
                        spContactName.InnerText = objProspect.Contact[0].FirstName + " " +
                                                  objProspect.Contact[0].MiddleName + " " +
                                                  objProspect.Contact[0].LastName;
                    else
                        spContactName.InnerText = objProspect.Contact[0].FirstName + " " +
                                                  objProspect.Contact[0].LastName;
                    aEditContact.HRef = "/App/Franchisor/AddNewContact.aspx?Type=Selected&ProspectID=" +
                                        Convert.ToString(objProspect.ProspectID) +
                                        "&ContactID=" + Convert.ToString(objProspect.Contact[0].ContactID)
                                        + (EventId.HasValue ? "&EventId=" + EventId.Value : "");
                }
                else
                {
                    spContactName.InnerText = "-N/A-";
                    spPhHome.InnerText = "-N/A-";
                    spPhCell.InnerText = "-N/A-";
                    spEmail.InnerText = "-N/A-";
                    aEditContact.HRef = "/App/Franchisor/AddNewContact.aspx?Type=Selected&IsHost=True&ProspectID=" +
                                        Convert.ToString(objProspect.ProspectID) + (EventId.HasValue ? "&EventId=" + EventId.Value : "");
                    aEditContact.InnerHtml = "Add";
                }
                if (objProspect.TotalEvent == 0)
                {
                    spRank.InnerText = "-NA-";
                    imgRanking.Src = "/App/Images/na-sign.gif";
                }
                else
                {
                    if (objProspect.CustomersPerEvent >= 0 &&
                        objProspect.CustomersPerEvent <= _badHostPerformanceULimit)
                    {
                        spRank.InnerText = "Bad";
                        imgRanking.Src = "/App/Images/bad-sign.gif";
                    }
                    else if (objProspect.CustomersPerEvent > _badHostPerformanceULimit &&
                             objProspect.CustomersPerEvent <= _averageHostPerformanceULimit)
                    {
                        spRank.InnerText = "Average";
                        imgRanking.Src = "/App/Images/Average-sign.gif";
                    }
                    else
                    {
                        spRank.InnerText = "Good";
                        imgRanking.Src = "/App/Images/good-sign.gif";
                    }
                }
            }




            divGVHostDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoHostFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            divHostDetails.Style.Add(HtmlTextWriterStyle.Display, "block");

            IHostPaymentRepository hostPaymentRepository = new HostPaymentRepository();
            IHostDeositRepository hostDepositRepository = new HostDepositRepository();

            try
            {
                var hostPaymentDetails = hostPaymentRepository.GetById(EventId.Value);

                FillHostPaymentDetail(hostPaymentDetails);
            }
            catch (Exception)
            {
                if (!(_rbtnYPayment.Checked && !string.IsNullOrEmpty(txtCostOfHost.Text)))
                {
                    _rbtnNPayment.Checked = true;
                    divPayment.Style.Add(HtmlTextWriterStyle.Display, "none");
                    txtCostOfHost.Text = null;
                    txtPaymentDue.Text = null;
                }
                else
                {
                    divPayment.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
            }

            try
            {
                var hostDepositDetails = hostDepositRepository.GetById(EventId.Value);
                FillHostDepositDetail(hostDepositDetails);
            }
            catch (Exception)
            {
                if (!(_rbtDepositY.Checked && !string.IsNullOrEmpty(txtDepositAmount.Text)))
                {
                    _rbtDepositN.Checked = true;
                    txtDepositAmount.Text = null;
                    txtDepositDue.Text = null;
                }
            }
        }

        private void SearchHost()
        {
            Session["SearchText"] = txtSearch.Text;
            Session["City"] = txtCity.Text;
            grdLegend.Style.Add(HtmlTextWriterStyle.Display, "none");
            // format phone no.
            var objCommonCode = new CommonCode();

            int hostid;
            int salesRepId = 0;
            try
            {
                Int32.TryParse(txtSearch.Text, out hostid);
            }
            catch
            {
                hostid = 0;
            }
            if (hostid == 0)
            {
                if (!Page.IsPostBack)
                {
                    if (Request["HostID"] != null && Convert.ToString(Request["HostID"]) != "")
                    {
                        hostid = Convert.ToInt32(Request["HostID"]);
                    }
                }
            }
            var masterDal = new MasterDAL();
            List<EProspect> objProspect = null;
            if (_hidSalesRepId.Value != null && Convert.ToString(_hidSalesRepId.Value) != "")
            {
                salesRepId = Convert.ToInt32(_hidSalesRepId.Value);
            }



            var currentSession = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            if (currentSession.CheckRole((long)Roles.SalesRep))
            {
                objProspect = hostid == 0
                                  ? masterDal.GetHostDetailsForEventWizard(txtSearch.Text, 1,
                                                                           currentSession.OrganizationRoleUserId,
                                                                           Convert.ToInt32(Roles.SalesRep),
                                                                           txtCity.Text)
                                  : masterDal.GetHostDetailsForEventWizard(hostid.ToString(), 0,
                                                                           currentSession.OrganizationRoleUserId,
                                                                           Convert.ToInt32(Roles.SalesRep),
                                                                           txtCity.Text);
            }
            else
            {
                objProspect = hostid == 0
                                  ? masterDal.GetHostDetailsForEventWizard(txtSearch.Text, 1,
                                                                           salesRepId,
                                                                           Convert.ToInt32(Roles.SalesRep),
                                                                           txtCity.Text)
                                  : masterDal.GetHostDetailsForEventWizard(hostid.ToString(), 0,
                                                                           salesRepId,
                                                                           Convert.ToInt32(Roles.SalesRep),
                                                                           txtCity.Text);
            }

            var dtHost = new DataTable();
            dtHost.Columns.Add("HostID");
            dtHost.Columns.Add("HostName");
            dtHost.Columns.Add("TaxIdNumber");
            dtHost.Columns.Add("AddressId");
            dtHost.Columns.Add("Address1");
            dtHost.Columns.Add("Address2");
            dtHost.Columns.Add("City");
            dtHost.Columns.Add("State");
            dtHost.Columns.Add("Zip");
            dtHost.Columns.Add("Latitude");
            dtHost.Columns.Add("Logitude");
            dtHost.Columns.Add("TotalEvent");
            dtHost.Columns.Add("TotalCustomer");
            dtHost.Columns.Add("CustomersPerEvent");
            dtHost.Columns.Add("PhoneHome");
            dtHost.Columns.Add("PhoneCell");
            dtHost.Columns.Add("EMail");
            dtHost.Columns.Add("ContactID");
            dtHost.Columns.Add("FacilitiesFee");
            dtHost.Columns.Add("Ranking");
            dtHost.Columns.Add("ContactName");
            dtHost.Columns.Add("DepositsAmount");
            dtHost.Columns.Add("PaymentMethod");
            dtHost.Columns.Add("IsManuallyVerified");
            dtHost.Columns.Add("UseLatLogForMapping");

            if (objProspect != null && objProspect.Count > 0)
            {
                for (int count = 0; count < objProspect.Count; count++)
                {
                    string address2 = "";
                    if (objProspect[count].Address.Address2.Length > 0)
                        address2 = objProspect[count].Address.Address2;
                    string phoneHome = "-N/A-";
                    string phoneCell = "-N/A-";
                    string email = "-N/A-";
                    string contactName = "-N/A-";
                    int contactId = 0;
                    if (objProspect[count].Contact != null && objProspect[count].Contact.Count > 0)
                    {
                        phoneHome = objCommonCode.FormatPhoneNumberGet(objProspect[count].Contact[0].PhoneHome);
                        phoneCell = objCommonCode.FormatPhoneNumberGet(objProspect[count].Contact[0].PhoneCell);
                        email = objProspect[count].Contact[0].EMail;
                        contactId = objProspect[count].Contact[0].ContactID;
                        if (objProspect[count].Contact[0].MiddleName.Length > 0)
                            contactName = objProspect[count].Contact[0].FirstName + " " +
                                          objProspect[count].Contact[0].MiddleName + " " +
                                          objProspect[count].Contact[0].LastName;
                        else
                            contactName = objProspect[count].Contact[0].FirstName + " " +
                                          objProspect[count].Contact[0].LastName;
                    }
                    dtHost.Rows.Add(new object[]
                                        {
                                            objProspect[count].ProspectID,
                                            objProspect[count].OrganizationName,
                                            objProspect[count].TaxIdNumber,
                                            objProspect[count].Address.AddressID,
                                            objProspect[count].Address.Address1,
                                            address2,
                                            objProspect[count].Address.City,
                                            objProspect[count].Address.State,
                                            objProspect[count].Address.Zip,
                                            objProspect[count].Address.Latitude,
                                            objProspect[count].Address.Longitude,
                                            objProspect[count].TotalEvent,
                                            objProspect[count].TotalCustomer,
                                            objProspect[count].CustomersPerEvent,
                                            phoneHome,
                                            phoneCell,
                                            email,
                                            contactId,
                                            objProspect[count].ProspectDetails.FacilitiesFee,
                                            objProspect[count].Ranking,
                                            contactName,
                                            objProspect[count].ProspectDetails.DepositsAmount,
                                            objProspect[count].ProspectDetails.PaymentMethod,
                                            objProspect[count].Address.IsManuallyVerified,
                                            objProspect[count].Address.UseLatLogForMapping
                                        });
                }
                ViewState["tblHost"] = dtHost;
                gvHostDetails.PageIndex = 0;
                gvHostDetails.DataSource = dtHost;
                gvHostDetails.DataBind();
                divGVHostDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                divNoHostFound.Style.Add(HtmlTextWriterStyle.Display, "none");
                // show legend 
                grdLegend.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                divGVHostDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                divNoHostFound.Style.Add(HtmlTextWriterStyle.Display, "block");
                grdLegend.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            divHostDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        [WebMethod(EnableSession = true)]
        public static OrderedPair<string, string> GetHostNotes(long hostId)
        {
            return IoC.Resolve<IHostRepository>().GetCallCenterandTechnicianNotesforgivenHost(hostId);
        }

        private void LoadSalesRepDropDownList(long franchiseeId)
        {
            ISalesRepresentativeRepository salesRepresentativeRepository =
                new SalesRepresentativeRepository();
            if (franchiseeId == 0)
            {
                franchiseeId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
            }
            List<SalesRepresentative> salesRepresentatives = salesRepresentativeRepository.
                GetSalesRepresentativesForFranchisee(franchiseeId).OrderBy(sr => sr.Name.FullName).ToList();
            var namesAndIds = salesRepresentatives.Select(s => new { s.Name.FullName, s.SalesRepresentativeId });
            if (namesAndIds.Count() > 0)
            {
                _salesRepDropDownList.DataSource = namesAndIds;
                _salesRepDropDownList.DataTextField = "FullName";
                _salesRepDropDownList.DataValueField = "SalesRepresentativeId";
                _salesRepDropDownList.DataBind();
                _salesRepDropDownList.Items.Insert(0, new ListItem("Select HSC", "0"));
                _salesRepDropDownList.SelectedValue = "0";
                _hidSalesRepId.Value = _salesRepDropDownList.SelectedValue;
            }
            else
            {
                _salesRepDropDownList.Items.Add(new ListItem("No HSC Found", "0"));
                _hidSalesRep.Value = "0";
            }
        }

        private void LoadFranchisee()
        {
            IOrganizationRepository franchiseeRepository = new OrganizationRepository();
            var franchisees =
                franchiseeRepository.GetOrganizationCollection(OrganizationType.Franchisee).OrderBy(fr => fr.Name).ToList();
            var namesAndIds = franchisees.Select(f => new { f.Name, f.Id });

            _franchiseeDropDownList.DataSource = namesAndIds;
            _franchiseeDropDownList.DataTextField = "Name";
            _franchiseeDropDownList.DataValueField = "Id";
            _franchiseeDropDownList.DataBind();
            _franchiseeDropDownList.Items.Insert(0, new ListItem("Select Franchisee", "0"));
            _franchiseeDropDownList.SelectedValue = "0";
            _hidFranchiseeId.Value = _franchiseeDropDownList.SelectedValue;
        }

        private void SetHostPaymentDefaultInfo(HostPayment hostPaymentInfo)
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            OrganizationRoleUser organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            hostPaymentInfo.PaymentRecordedBy = organizationRoleUser;
            hostPaymentInfo.CreatedDate = DateTime.Now;
            hostPaymentInfo.Status = HostPaymentStatus.Pending;
        }

        private void SetHostDepositDefaultInfo(HostPayment hostDepositInfo)
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            OrganizationRoleUser organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            hostDepositInfo.PaymentRecordedBy = organizationRoleUser;
            hostDepositInfo.CreatedDate = DateTime.Now;
            hostDepositInfo.Status = HostPaymentStatus.Pending;
        }

        private void UpdateHostPaymentInfo(HostPayment hostPaymentInfo, HostDeposit hostDepositInfo)
        {
            if (hostPaymentInfo != null && hostPaymentInfo.Status == HostPaymentStatus.Pending)
            {
                hostPaymentInfo.HostId = Convert.ToInt64(hfHostID.Value);
                hostPaymentInfo.Amount = !string.IsNullOrEmpty(txtCostOfHost.Text)
                                             ? Convert.ToDecimal(txtCostOfHost.Text)
                                             : 0.00m;

                if ((_chkCheckForCost.Checked) && (_chkCreditCardForCost.Checked))
                {
                    hostPaymentInfo.PaymentMode = HostPaymentType.Both;
                }
                else if (_chkCheckForCost.Checked)
                {
                    hostPaymentInfo.PaymentMode = HostPaymentType.Check;
                }
                else if (_chkCreditCardForCost.Checked)
                {
                    hostPaymentInfo.PaymentMode = HostPaymentType.CreditCard;
                }
                hostPaymentInfo.PayableTo = _txtPayableToForCost.Text;
                hostPaymentInfo.MailingOrganizationName = _txtCostMailingOrganization.Text;
                hostPaymentInfo.MailingAttentionOf = _txtAttentionOfForCost.Text;
                hostPaymentInfo.DueDate = string.IsNullOrEmpty(txtPaymentDue.Text)
                                              ? DateTime.Now.AddDays(-1)
                                              : Convert.ToDateTime(txtPaymentDue.Text);
                hostPaymentInfo.Status = HostPaymentStatus.Pending;
                if (hostPaymentInfo.PaymentMailingAddress == null)
                {
                    hostPaymentInfo.PaymentMailingAddress = new Address { ZipCode = new ZipCode() };
                }
                hostPaymentInfo.PaymentMailingAddress.City = _txtCostDeliverCity.Text;
                hostPaymentInfo.PaymentMailingAddress.State = _ddlCostState.SelectedItem.Text;
                hostPaymentInfo.PaymentMailingAddress.StreetAddressLine1 = _txtCostDeliverAddress1.Text;
                hostPaymentInfo.PaymentMailingAddress.StreetAddressLine2 = _txtCostDeliverAddress2.Text;
                hostPaymentInfo.PaymentMailingAddress.ZipCode.Zip = _txtCostDeliverZip.Text;
                hostPaymentInfo.PaymentMailingAddress.Country = "USA";
                // Active - DeActive records
                hostPaymentInfo.IsActive = _rbtnYPayment.Checked;

            }


            if (hostDepositInfo != null && hostDepositInfo.Status == HostPaymentStatus.Pending)
            {
                hostDepositInfo.HostId = Convert.ToInt64(hfHostID.Value);
                hostDepositInfo.Amount = !string.IsNullOrEmpty(txtDepositAmount.Text)
                                             ? Convert.ToDecimal(txtDepositAmount.Text)
                                             : 0.00m;

                if ((_chkCheckForDeposit.Checked) && (_chkCreditCardForDeposit.Checked))
                {
                    hostDepositInfo.PaymentMode = HostPaymentType.Both;
                }
                else if (_chkCheckForDeposit.Checked)
                {
                    hostDepositInfo.PaymentMode = HostPaymentType.Check;
                }
                else if (_chkCreditCardForDeposit.Checked)
                {
                    hostDepositInfo.PaymentMode = HostPaymentType.CreditCard;
                }

                hostDepositInfo.DueDate = string.IsNullOrEmpty(txtDepositDue.Text)
                                              ? DateTime.Now.AddDays(-1)
                                              : Convert.ToDateTime(txtDepositDue.Text);
                hostDepositInfo.PayableTo = _txtPayableToForDeposit.Text;
                hostDepositInfo.MailingAttentionOf = _txtAttentionOfForDeposit.Text;
                hostDepositInfo.MailingOrganizationName = _txtDepositeOrganization.Text;
                hostDepositInfo.DepositApplicablityMode = _rbtAppliedToCost.Checked
                                                              ? DepositType.AppliedToCost
                                                              : DepositType.Refunded;
                if ((!string.IsNullOrEmpty(_txtEventCancelBy.Text)) && (!string.IsNullOrEmpty(txtEventDate.Text)) && EventId.HasValue)
                {
                    TimeSpan noOfDaysBeforeEvent = Convert.ToDateTime(txtEventDate.Text) -
                                                   Convert.ToDateTime(_txtEventCancelBy.Text);
                    hostDepositInfo.DepositFullRefundDueDays = noOfDaysBeforeEvent.Days;
                    // check for eventCanceled by date should be less than or equals to eventDate.
                    //if (noOfDaysBeforeEvent.Days < 0)
                    //{
                    //    ClientScript.RegisterStartupScript(typeof(string), "JSCodeEventCanceledByDate", "alert('The date to cancel the event for complete refund of deposit should be before the event date.');", true);
                    //    return;
                    //}
                }
                else
                {
                    Session["DepositFullRefundDueDate"] = (!string.IsNullOrEmpty(_txtEventCancelBy.Text))
                                                              ? _txtEventCancelBy.Text
                                                              : null;
                }

                if (hostDepositInfo.PaymentMailingAddress == null)
                {
                    hostDepositInfo.PaymentMailingAddress = new Address { ZipCode = new ZipCode() };
                }
                hostDepositInfo.PaymentMailingAddress.City = _txtDepositDeliverCity.Text;
                hostDepositInfo.PaymentMailingAddress.State = _ddlDepositState.SelectedItem.Text;
                hostDepositInfo.PaymentMailingAddress.StreetAddressLine1 = _txtDepositDeliverAddress1.Text;
                hostDepositInfo.PaymentMailingAddress.StreetAddressLine2 = _txtDepositDeliverAddress2.Text;
                hostDepositInfo.PaymentMailingAddress.ZipCode.Zip = _txtDepositDeliverZip.Text;
                hostDepositInfo.PaymentMailingAddress.Country = "USA";
                // Active - DeActive records
                hostDepositInfo.IsActive = _rbtDepositY.Checked;

            }
        }

        private void FillState()
        {
            var masterDal = new MasterDAL();

            int countryId = masterDal.GetCountry(string.Empty, 3).FirstOrDefault().CountryID;
            ClientScript.RegisterHiddenField("hfCountryId", countryId.ToString());

            var stateRepository = IoC.Resolve<IStateRepository>();

            var states = stateRepository.GetAllStates();
            _ddlCostState.Items.Clear();
            _ddlCostState.DataSource = states;
            _ddlCostState.DataTextField = "Name";
            _ddlCostState.DataValueField = "Id";
            _ddlCostState.DataBind();
            _ddlCostState.Items.Insert(0, new ListItem("Select State", "0"));

            _ddlDepositState.Items.Clear();
            _ddlDepositState.DataSource = states;
            _ddlDepositState.DataTextField = "Name";
            _ddlDepositState.DataValueField = "Id";
            _ddlDepositState.DataBind();
            _ddlDepositState.Items.Insert(0, new ListItem("Select State", "0"));
        }

        private Boolean ValidateHostPaymentAddress()
        {
            var otherDal = new OtherDAL();
            EZip zipobj = otherDal.CheckCityZip(_txtCostDeliverCity.Text, _txtCostDeliverZip.Text,
                                                _ddlCostState.SelectedItem.Value);
            if (HostPaymentPaidHidden.Value == "False")
            {
                if (zipobj.CityID == 0)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode",
                                                       "alert('City Name entered for payment of cost is not valid.');",
                                                       true);
                    return false;
                }
                if (zipobj.CityID > 0 && zipobj.ZipID == 0)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode",
                                                       "alert('Zip Code entered for the corresponding city for payment of cost is not valid.');",
                                                       true);
                    return false;
                }
            }
            if (_rbtDepositY.Checked && HostDepositPaidHidden.Value == "False")
            {
                zipobj = otherDal.CheckCityZip(_txtDepositDeliverCity.Text, _txtDepositDeliverZip.Text,
                                               _ddlDepositState.SelectedItem.Value);

                if (zipobj.CityID == 0)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode",
                                                       "alert('City Name entered for payment of deposit is not valid.');",
                                                       true);
                    return false;
                }
                if (zipobj.CityID > 0 && zipobj.ZipID == 0)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode",
                                                       "alert('Zip Code entered for the corresponding city for payment of deposit is not valid.');",
                                                       true);
                    return false;
                }
            }
            return true;
        }

        private void FillHostPaymentDetail(HostPayment hostPaymentInfo)
        {
            if (hostPaymentInfo == null) return;

            txtCostOfHost.Text = hostPaymentInfo.Amount > 0 ? hostPaymentInfo.Amount.ToString("#.##") : "0.00";
            _txtPayableToForCost.Text = hostPaymentInfo.PayableTo;
            _txtAttentionOfForCost.Text = hostPaymentInfo.MailingAttentionOf;
            switch (hostPaymentInfo.PaymentMode)
            {
                case HostPaymentType.Both:
                    _chkCreditCardForCost.Checked = true;
                    _chkCheckForCost.Checked = true;
                    break;
                case HostPaymentType.Check:

                    _chkCheckForCost.Checked = true;
                    break;
                case HostPaymentType.CreditCard:
                    _chkCreditCardForCost.Checked = true;

                    break;
            }
            _txtCostMailingOrganization.Text = hostPaymentInfo.MailingOrganizationName;

            _txtCostDeliverCity.Text = hostPaymentInfo.PaymentMailingAddress.City;
            _ddlCostState.Items.FindByText(hostPaymentInfo.PaymentMailingAddress.State).Selected = true;
            _txtCostDeliverAddress1.Text = hostPaymentInfo.PaymentMailingAddress.StreetAddressLine1;
            _txtCostDeliverAddress2.Text = hostPaymentInfo.PaymentMailingAddress.StreetAddressLine2;
            _txtCostDeliverZip.Text = hostPaymentInfo.PaymentMailingAddress.ZipCode != null
                                          ? hostPaymentInfo.PaymentMailingAddress.ZipCode.Zip
                                          : string.Empty;
            txtPaymentDue.Text = !string.IsNullOrEmpty(Convert.ToString(hostPaymentInfo.DueDate))
                                     ? Convert.ToDateTime(hostPaymentInfo.DueDate).ToString("MM/dd/yyyy")
                                     : null;
            if (hostPaymentInfo.HostPaymentTransactions != null && hostPaymentInfo.HostPaymentTransactions.Count > 0)
            {
                string notes = string.Empty;
                foreach (HostPaymentTransaction hostPaymentTransactions in hostPaymentInfo.HostPaymentTransactions)
                {
                    notes = (!string.IsNullOrEmpty(hostPaymentTransactions.Notes))
                                ? hostPaymentTransactions.Notes + "<br />"
                                : "";
                }
                PaymentNotes = string.IsNullOrEmpty(notes)
                                                ? "No Detail found."
                                                : notes;
            }
            else PaymentNotes = "No Detail found.";

            if (hostPaymentInfo.IsActive)
            {
                _rbtnYPayment.Checked = true;
                divPayment.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                _rbtnNPayment.Checked = true;
                divPayment.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            if (hostPaymentInfo.Status != HostPaymentStatus.Pending)
            {
                _dvPaymentOption.Style.Add(HtmlTextWriterStyle.Display, "none");
                _dvPaymentStatus.Style.Add(HtmlTextWriterStyle.Display, "block");
                ClientScript.RegisterStartupScript(typeof(string), "disablecostediting", "DisableEditing('Cost');",
                                                   true);
            }
        }

        private void FillHostDepositDetail(HostDeposit hostDepositInfo)
        {
            if (hostDepositInfo == null) return;
            _rbtDepositY.Checked = true;
            txtDepositAmount.Text = hostDepositInfo.Amount > 0 ? hostDepositInfo.Amount.ToString("#.##") : "0.00";

            switch (hostDepositInfo.PaymentMode)
            {
                case HostPaymentType.Both:
                    _chkCreditCardForDeposit.Checked = true;
                    _chkCheckForDeposit.Checked = true;
                    break;
                case HostPaymentType.Check:

                    _chkCheckForDeposit.Checked = true;
                    break;
                case HostPaymentType.CreditCard:
                    _chkCreditCardForDeposit.Checked = true;

                    break;
            }
            _txtPayableToForDeposit.Text = hostDepositInfo.PayableTo;
            _txtAttentionOfForDeposit.Text = hostDepositInfo.MailingAttentionOf;
            _txtDepositeOrganization.Text = hostDepositInfo.MailingOrganizationName;
            _txtDepositDeliverCity.Text = hostDepositInfo.PaymentMailingAddress.City;
            _ddlDepositState.Items.FindByText(hostDepositInfo.PaymentMailingAddress.State).Selected = true;
            _txtDepositDeliverAddress1.Text = hostDepositInfo.PaymentMailingAddress.StreetAddressLine1;
            _txtDepositDeliverAddress2.Text = hostDepositInfo.PaymentMailingAddress.StreetAddressLine2;
            _txtDepositDeliverZip.Text = hostDepositInfo.PaymentMailingAddress.ZipCode != null
                                             ? hostDepositInfo.PaymentMailingAddress.ZipCode.Zip
                                             : string.Empty;
            txtDepositDue.Text = hostDepositInfo.DueDate != null
                                     ? Convert.ToDateTime(hostDepositInfo.DueDate).ToString("MM/dd/yyyy")
                                     : null;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["DepositFullRefundDueDate"])))
            {
                _txtEventCancelBy.Text = Convert.ToDateTime(Session["DepositFullRefundDueDate"]).ToShortDateString();
                if (Session["DepositFullRefundDueDate"] != null) Session["DepositFullRefundDueDate"] = null;
            }
            else if ((!string.IsNullOrEmpty(txtEventDate.Text)))
            {
                DateTime eventCancelForFullRefund = Convert.ToDateTime(txtEventDate.Text);
                if (hostDepositInfo.DepositFullRefundDueDays != null)
                {
                    eventCancelForFullRefund =
                        eventCancelForFullRefund.AddDays((long)-hostDepositInfo.DepositFullRefundDueDays);

                    _txtEventCancelBy.Text = eventCancelForFullRefund != null
                                                 ? eventCancelForFullRefund.ToString("MM/dd/yyyy")
                                                 : null;
                }
            }
            else _txtEventCancelBy.Text = "";

            if (hostDepositInfo.HostPaymentTransactions != null && hostDepositInfo.HostPaymentTransactions.Count > 0)
            {
                string notes = string.Empty;
                foreach (HostPaymentTransaction hostDepositTransactions in hostDepositInfo.HostPaymentTransactions)
                {
                    notes = (!string.IsNullOrEmpty(hostDepositTransactions.Notes))
                                ? hostDepositTransactions.Notes + "<br />"
                                : "";
                }
                DepositNotes = string.IsNullOrEmpty(notes)
                                                ? "No Detail found."
                                                : notes;
            }
            else DepositNotes = "No Detail found.";

            switch (hostDepositInfo.DepositApplicablityMode)
            {
                case DepositType.AppliedToCost:
                    _rbtAppliedToCost.Checked = true;
                    break;
                default:
                    _rbtReturnToOffice.Checked = true;
                    break;
            }
            if (hostDepositInfo.IsActive)
            {
                _rbtDepositY.Checked = true;
                ClientScript.RegisterStartupScript(typeof(string), "showdeposit", "ShowDepositDetails();", true);
            }
            else
            {
                _rbtDepositN.Checked = true;
                ClientScript.RegisterStartupScript(typeof(string), "hidedeposit", "HideDepositDetails();", true);
            }
            if (hostDepositInfo.Status != HostPaymentStatus.Pending)
            {
                _dvDepositOption.Style.Add(HtmlTextWriterStyle.Display, "none");
                _dvDepositStatus.Style.Add(HtmlTextWriterStyle.Display, "block");
                ClientScript.RegisterStartupScript(typeof(string), "disabledepositediting",
                                                   "DisableEditing('Deposit');", true);
            }
        }

        private void SetOrganizationRoleUserId()
        {
            OrganizationRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        }

        private void RemoveSession()
        {
            Session["EventPod"] = null;
            Session["EventPodAvailable"] = null;
            Session["SearchText"] = null;
            Session["City"] = null;
        }

        //private void GetAllCorporateAccount()
        //{
        //    var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
        //    var accounts = corporateAccountRepository.GetAll();

        //    var serializer = new JavaScriptSerializer();
        //    foreach (var a in
        //        accounts.Select(corporateAccount => new {corporateAccount.Id, corporateAccount.EnableAlaCarte}))
        //    {
        //        Page.ClientScript.RegisterArrayDeclaration("js_CorporateAccount", serializer.Serialize(a));
        //    }

        //}

        protected void Bind_ProductList() // Method for Binding The Checkbox List  
        {
            ILookupRepository lookupRepository = new LookupRepository();
            var Product = lookupRepository.GetByLookupId((long)ProductType.CHA);

            EventProductType.DataSource = Product;
            EventProductType.DataTextField = "DisplayName";
            EventProductType.DataValueField = "Id";
            EventProductType.DataBind();


        }  

    }
}