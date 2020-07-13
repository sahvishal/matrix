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
    public partial class PpAaaa : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                Ppaaa_hip.Visible = false;
                Ppaaa_chat.Visible = true;

            }
            else
            {
                Ppaaa_hip.Visible = true;
                Ppaaa_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.PPAAA, (int)ReadingLabels.AortaSize);

                StandardFindingsPpAAAGridView.DataSource = standardFindingList;
                StandardFindingsPpAAAGridView.DataBind();

                var sViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.PPAAA, (int)ReadingLabels.AortaRangeSaggitalView);
                PpSaggitalViewDataList.DataSource = sViewStandardFindingList;
                PpSaggitalViewDataList.DataBind();

                var tViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.PPAAA, (int)ReadingLabels.AortaRangeTransverseView);
                PpTransverseViewDatalist.DataSource = tViewStandardFindingList;
                PpTransverseViewDatalist.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.PPAAA) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenPpAAADataList.DataSource = listUnableScreenReasonData;
                UnableToScreenPpAAADataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.PPAAA);

                IncidentalFindingsSelectedPpAAADataList.DataSource = listIncidentalFindings;
                IncidentalFindingsSelectedPpAAADataList.DataBind();
            }
        }
    }
}