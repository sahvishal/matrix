using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class ViewableResult : UserControl
    {

        protected bool ShowBasicBiometric
        {
            get
            {
                var configRepository = IoC.Resolve<IConfigurationSettingRepository>();
                var val = configRepository.GetConfigurationValue(ConfigurationSettingName.ShowBasicBiometric);

                bool showBasicBiometric = true;

                Boolean.TryParse(val, out showBasicBiometric);

                return showBasicBiometric;
            }
        }

        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public bool IsMedicare { get; set; }
        public bool ContainTestForEvaluation { get; set; }
        protected bool ShowHideFastingStatus { get; set; }
        public string PcpName { get; set; }

        protected string VersionNumber { get; set; }

        private void GetConductedbyData()
        {
            var eventStaffAssignementRepository = IoC.Resolve<IEventStaffAssignmentRepository>();
            var staff = eventStaffAssignementRepository.GetForEvent(EventId);
            if (staff != null && staff.Count() > 0)
            {
                var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var nameIdPairs = orgRoleUserRepository.GetNameIdPairofUsers(
                    staff.Select(s => (s.ActualStaffOrgRoleUserId ?? s.ScheduledStaffOrgRoleUserId)).ToArray());

                Conductedby.DataTextField = "SecondValue";
                Conductedby.DataValueField = "FirstValue";
                Conductedby.DataSource = nameIdPairs;
                Conductedby.DataBind();

                Conductedby.Items.Insert(0, new ListItem("--Conducted By--", "0"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
                VersionNumber = systemInformationRepository.GetBuildNumber();

                var current = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                if (current.CheckRole((long)Roles.Customer))
                {
                    this.Page.Form.Action = Request.Url.AbsolutePath;
                }
                
                var key = Request.QueryString["key"];
                if (!string.IsNullOrEmpty(key))
                {
                    key = key.Replace(" ", "+");
                    CryptographyService cryptographyService = new DigitalDeliveryCryptographyService();
                    string decryptedKey = cryptographyService.Decrypt(key);

                    string[] allKeys;
                    allKeys = decryptedKey.Split('~');

                    EventId = Convert.ToInt64(allKeys[0]);
                    CustomerId = Convert.ToInt64(allKeys[1]);
                    Server.Transfer("/App/Common/Results.aspx?EventId=" + EventId + "&CustomerId=" + CustomerId);
                }
                else
                {
                    long s = 0;
                    if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out s))
                    {
                        EventId = s;
                    }

                    s = 0;
                    if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out s))
                    {
                        CustomerId = s;
                    }
                    IsMedicare = Request.QueryString["IsMedicare"] != null && Convert.ToBoolean(Request.QueryString["IsMedicare"]);
                }

                if (!current.CheckRole((long)Roles.Customer))
                {
                    var eventCustomerResult = IoC.Resolve<IEventCustomerResultRepository>().GetByCustomerIdAndEventId(CustomerId, EventId);
                    if (eventCustomerResult != null)
                    {
                        var priorityInQueue = IoC.Resolve<IPriorityInQueueRepository>().GetByEventCustomerResultId(eventCustomerResult.Id);
                        if (priorityInQueue != null && priorityInQueue.InQueuePriority > 0 && priorityInQueue.NoteId != null)
                        {
                            var noteText = IoC.Resolve<INotesRepository>().Get(priorityInQueue.NoteId.Value);
                            if (noteText != null && !string.IsNullOrEmpty(noteText.Text))
                            {
                                PriorityInQueueMessage.ShowSuccessMessage("<b><u>Priority In Queue Reason:</u> </b>" + noteText.Text);
                                PriorityInQueueMessage.Visible = true;
                            }
                        }
                    }

                }

                var mediaLocation = IoC.Resolve<IMediaRepository>().GetResultMediaFileLocation(CustomerId, EventId);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "js_Location_Url", "function getLocationPrefix() { return '" + mediaLocation.PhysicalPath.Replace("\\", "\\\\") + "'; } function getUrlPrefix() { return '" + mediaLocation.Url + "'; }", true);

                GetConductedbyData();
                var eventsRepository = IoC.Resolve<IEventRepository>();
                var eventData = eventsRepository.GetById(EventId);
                var settings = IoC.Resolve<ISettings>();
                var basicBiometricCutOfDate = settings.BasicBiometricCutOfDate;
                var hideBasicBiometric = (eventData.EventDate.Date >= basicBiometricCutOfDate);

                ShowHideFastingStatus = (eventData.EventDate.Date >= settings.FastingStatusDate);

                BasicBiometric.ShowByCutOffDate = !hideBasicBiometric;
                TestSection.SetSectionShowHide(hideBasicBiometric);

                ContainTestForEvaluation = TestSection.ContainsReviewableTests;

                GetPcpInformation();

                CreateIfjsArrays();
                CreateJsArrayforIfuCs();
            }
        }


        private void CreateIfjsArrays()
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

        private void GetPcpInformation()
        {
            var primaryCarePhysicianRepository = IoC.Resolve<PrimaryCarePhysicianRepository>();
            var primaryCarePhysician = primaryCarePhysicianRepository.Get(CustomerId);

            PcpName = primaryCarePhysician != null && primaryCarePhysician.Name != null ? primaryCarePhysician.Name.FullName : string.Empty;
        }
    }
}
