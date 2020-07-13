using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Lead : System.Web.UI.UserControl
    {
        public long EventId { get; set; }

        public long CustomerId { get; set; }

        protected bool HideDiagnosisCodeLead { get; set; }

        protected string VersionNumber { get; set; }

        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                lead_hip.Visible = false;
                lead_chat.Visible = true;

            }
            else
            {
                lead_hip.Visible = true;
                lead_chat.Visible = false;
            }
            if (!IsPostBack) FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lead, (int)ReadingLabels.Left);

                StandardFindingsLeadGridView.DataSource = standardFindingList;
                StandardFindingsLeadGridView.DataBind();

                var findingVelocityLeftList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lead, (int)ReadingLabels.LeftCFAPSV);
                if (findingVelocityLeftList.Count > 0)
                {
                    LowVelocityLeftLabel.InnerText = findingVelocityLeftList[0].Label;
                    LowVelocityLeftIdHiddenfield.Value = findingVelocityLeftList[0].Id.ToString();
                }

                var findingVelocityRightList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lead, (int)ReadingLabels.RightCFAPSV);
                if (findingVelocityRightList.Count > 0)
                {
                    LowVelocityRightLabel.InnerText = findingVelocityRightList[0].Label;
                    LowVelocityRightIdHiddenfield.Value = findingVelocityRightList[0].Id.ToString();
                }

                IUnableToScreenStatusRepository unableToScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableToScreenRepository.GetAllUnableToScreenReasons((long)TestType.Lead) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                UnableScreenReasonLeadDataList.DataSource = listUnableScreenReason;
                UnableScreenReasonLeadDataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listincidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.Lead);

                IncidentalFindingsLeadSelectedDataList.DataSource = listincidentalFindings;
                IncidentalFindingsLeadSelectedDataList.DataBind();


                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonLead.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonLead.DataTextField = "Name";
                    ddlTestNotPerformedReasonLead.DataValueField = "Id";
                    ddlTestNotPerformedReasonLead.DataBind();
                    ddlTestNotPerformedReasonLead.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonLead.Visible = false;
                }

                var eventRepository = IoC.Resolve<IEventRepository>();
                var settings = IoC.Resolve<ISettings>();
                var theEventData = eventRepository.GetById(EventId);

                HideDiagnosisCodeLead = settings.ChangeLeadReadingDate.HasValue && theEventData.EventDate >= settings.ChangeLeadReadingDate.Value;
            }
        }
    }
}