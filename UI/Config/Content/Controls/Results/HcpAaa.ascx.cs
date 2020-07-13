using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class HcpAaa : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                Hcpaaa_hip.Visible = false;
                Hcpaaa_chat.Visible = true;

            }
            else
            {
                Hcpaaa_hip.Visible = true;
                Hcpaaa_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize);

                StandardFindingsHcpAAAGridView.DataSource = standardFindingList;
                StandardFindingsHcpAAAGridView.DataBind();

                var sViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeSaggitalView);
                HcpSaggitalViewDataList.DataSource = sViewStandardFindingList;
                HcpSaggitalViewDataList.DataBind();

                var tViewStandardFindingList = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeTransverseView);
                HcpTransverseViewDatalist.DataSource = tViewStandardFindingList;
                HcpTransverseViewDatalist.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.HCPAAA) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenHcpAAADataList.DataSource = listUnableScreenReasonData;
                UnableToScreenHcpAAADataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.HCPAAA);

                IncidentalFindingsSelectedHcpAAADataList.DataSource = listIncidentalFindings;
                IncidentalFindingsSelectedHcpAAADataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonHcpaaa.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonHcpaaa.DataTextField = "Name";
                    ddlTestNotPerformedReasonHcpaaa.DataValueField = "Id";
                    ddlTestNotPerformedReasonHcpaaa.DataBind();
                    ddlTestNotPerformedReasonHcpaaa.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonHcpaaa.Visible = false;
                }
            }
        }
    }
}