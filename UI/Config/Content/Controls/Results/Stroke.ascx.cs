using System;
using System.Collections.Generic;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Stroke : UserControl
    {
        public long EventId { get; set; }

        public long CustomerId { get; set; }

        protected string VersionNumber { get; set; }

        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                stroke_hip.Visible = false;
                stroke_chat.Visible = true;

            }
            else
            {
                stroke_hip.Visible = true;
                stroke_chat.Visible = false;
            }
            if (!IsPostBack) FillAllStaticGrids();
            strokePhysicianRepeatStudy.Style.Add(HtmlTextWriterStyle.Display, ShowHideRepeatStudyCheckBox ? "block" : "none");
            strokeOtherModalitiesAdditionalImages.Style.Add(HtmlTextWriterStyle.Display, !ShowHideRepeatStudyCheckBox ? "block" : "none");
        }

        public bool ShowHideRepeatStudyCheckBox { get; set; }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                List<StandardFinding<decimal?>> standardFindingList;

                var settings = IoC.Resolve<ISettings>();
                if (settings.StrokeFindingChangeDate.HasValue)
                {
                    var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                    var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(CustomerId, EventId);
                    if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < settings.StrokeFindingChangeDate.Value)
                    {
                        standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.Left, settings.StrokeFindingChangeDate.Value, true);
                    }
                    else
                    {
                        standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.Left, settings.StrokeFindingChangeDate.Value, false);
                    }
                }
                else
                {
                    standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.Left);
                }

                StandardFindingsStrokeGridView.DataSource = standardFindingList;
                StandardFindingsStrokeGridView.DataBind();

                var findingVelocityLicaList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.LICAPSV);
                if (findingVelocityLicaList.Count > 0)
                {
                    LowVelocityLICALabel.InnerText = findingVelocityLicaList[0].Label;
                    LowVelocityLICAIdHiddenfield.Value = findingVelocityLicaList[0].Id.ToString();
                }

                var findingVelocityRicaList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Stroke, (int)ReadingLabels.RICAPSV);
                if (findingVelocityRicaList.Count > 0)
                {
                    LowVelocityRICALabel.InnerText = findingVelocityRicaList[0].Label;
                    LowVelocityRICAIdHiddenfield.Value = findingVelocityRicaList[0].Id.ToString();
                }

                IUnableToScreenStatusRepository unableToScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableToScreenRepository.GetAllUnableToScreenReasons((long)TestType.Stroke) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                UnableScreenReasonStrokeDataList.DataSource = listUnableScreenReason;
                UnableScreenReasonStrokeDataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listincidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.Stroke);

                IncidentalFindingsStrokeSelectedDataList.DataSource = listincidentalFindings;
                IncidentalFindingsStrokeSelectedDataList.DataBind();
            }
        }

    }
}