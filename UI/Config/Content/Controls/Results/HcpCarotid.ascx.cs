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
    public partial class HcpCarotid : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                hcpCarotid_hip.Visible = false;
                hcpCarotid_chat.Visible = true;

            }
            else
            {
                hcpCarotid_hip.Visible = true;
                hcpCarotid_chat.Visible = false;
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

                List<StandardFinding<decimal?>> standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPCarotid, (int)ReadingLabels.Left);

                StandardFindingsHcpCarotidGridView.DataSource = standardFindingList;
                StandardFindingsHcpCarotidGridView.DataBind();

                var findingVelocityLicaList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPCarotid, (int)ReadingLabels.LICAPSV);
                if (findingVelocityLicaList.Count > 0)
                {
                    HcpCarotidLowVelocityLICALabel.InnerText = findingVelocityLicaList[0].Label;
                    HcpCarotidLowVelocityLICAIdHiddenfield.Value = findingVelocityLicaList[0].Id.ToString();
                }

                var findingVelocityRicaList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPCarotid, (int)ReadingLabels.RICAPSV);
                if (findingVelocityRicaList.Count > 0)
                {
                    HcpCarotidLowVelocityRICALabel.InnerText = findingVelocityRicaList[0].Label;
                    HcpCarotidLowVelocityRICAIdHiddenfield.Value = findingVelocityRicaList[0].Id.ToString();
                }

                IUnableToScreenStatusRepository unableToScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableToScreenRepository.GetAllUnableToScreenReasons((long)TestType.HCPCarotid) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                UnableScreenReasonHcpCarotidDataList.DataSource = listUnableScreenReason;
                UnableScreenReasonHcpCarotidDataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listincidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.HCPCarotid);

                IncidentalFindingsHcpCarotidSelectedDataList.DataSource = listincidentalFindings;
                IncidentalFindingsHcpCarotidSelectedDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonHcpCarotid.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonHcpCarotid.DataTextField = "Name";
                    ddlTestNotPerformedReasonHcpCarotid.DataValueField = "Id";
                    ddlTestNotPerformedReasonHcpCarotid.DataBind();
                    ddlTestNotPerformedReasonHcpCarotid.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonHcpCarotid.Visible = false;
                }
            }
        }
    }
}