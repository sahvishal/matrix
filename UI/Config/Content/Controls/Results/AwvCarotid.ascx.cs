using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
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
    public partial class AwvCarotid : UserControl
    {
        public long EventId { get; set; }

        public long CustomerId { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                awvCarotid_hip.Visible = false;
                awvCarotid_chat.Visible = true;
            }
            else
            {
                awvCarotid_hip.Visible = true;
                awvCarotid_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvCarotid, (int)ReadingLabels.Left);

                StandardFindingsAwvCarotidGridView.DataSource = standardFindingList;
                StandardFindingsAwvCarotidGridView.DataBind();

                var findingVelocityLicaList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvCarotid, (int)ReadingLabels.LICAPSV);
                if (findingVelocityLicaList.Count > 0)
                {
                    LowVelocityLICALabel.InnerText = findingVelocityLicaList[0].Label;
                    LowVelocityLICAIdProximalHiddenfield.Value = findingVelocityLicaList[0].Id.ToString();
                }

                var findingVelocityRicaList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvCarotid, (int)ReadingLabels.RICAPSV);
                if (findingVelocityRicaList.Count > 0)
                {
                    LowVelocityRICALabel.InnerText = findingVelocityRicaList[0].Label;
                    LowVelocityRICAIdProximalHiddenfield.Value = findingVelocityRicaList[0].Id.ToString();
                }

                IUnableToScreenStatusRepository unableToScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableToScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvCarotid) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                UnableScreenReasonAwvCarotidDataList.DataSource = listUnableScreenReason;
                UnableScreenReasonAwvCarotidDataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listincidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.AwvCarotid);

                IncidentalFindingsAwvCarotidSelectedDataList.DataSource = listincidentalFindings;
                IncidentalFindingsAwvCarotidSelectedDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvCarotid.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvCarotid.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvCarotid.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvCarotid.DataBind();
                    ddlTestNotPerformedReasonAwvCarotid.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvCarotid.Visible = false;
                }
            }
        }

    }
}