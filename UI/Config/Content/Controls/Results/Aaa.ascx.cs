using System;
using System.Collections.Generic;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Aaa : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                aaa_hip.Visible = false;
                aaa_chat.Visible = true;

            }
            else
            {
                aaa_hip.Visible = true;
                aaa_chat.Visible = false;
            }

            if (!IsPostBack) FillAllStaticGrids();
        }

        public bool ShowHideRepeatStudyCheckBox { get; set; }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {

                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AAA, (int)ReadingLabels.AortaSize);

                StandardFindingsAAAGridView.DataSource = standardFindingList;
                StandardFindingsAAAGridView.DataBind();

                var sViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AAA, (int)ReadingLabels.AortaRangeSaggitalView);
                SaggitalViewDataList.DataSource = sViewStandardFindingList;
                SaggitalViewDataList.DataBind();

                var tViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AAA, (int)ReadingLabels.AortaRangeTransverseView);
                TransverseViewDatalist.DataSource = tViewStandardFindingList;
                TransverseViewDatalist.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AAA) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenAAADataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAAADataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.AAA);

                IncidentalFindingsSelectedAAADataList.DataSource = listIncidentalFindings;
                IncidentalFindingsSelectedAAADataList.DataBind();

                physicianRepeatStudy.Style.Add(HtmlTextWriterStyle.Display, ShowHideRepeatStudyCheckBox ? "block" : "none");

                aaaOtherModalitiesAdditionalImages.Style.Add(HtmlTextWriterStyle.Display, !ShowHideRepeatStudyCheckBox ? "block" : "none");
            }
        }
    }
}