using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Application;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class AwvABI : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                awvAbi_hip.Visible = false;
                awvAbi_chat.Visible = true;

            }
            else
            {
                awvAbi_hip.Visible = true;
                awvAbi_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvABI);

                standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();

                gvFindingsAwvAbi.DataSource = standardFindingList;
                gvFindingsAwvAbi.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvABI) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                // Filling Unable To Screen Reason List for ASI
                dtlAwvAbiUnableToScreenSelected.DataSource = listUnableScreenReason;
                dtlAwvAbiUnableToScreenSelected.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.AwvABI);

                dtlAwvAbiIncidentalFindingsSelected.DataSource = listIncidentalFindings;
                dtlAwvAbiIncidentalFindingsSelected.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvAbi.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvAbi.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvAbi.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvAbi.DataBind();
                    ddlTestNotPerformedReasonAwvAbi.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvAbi.Visible = false;
                }
            }
        }
    }
}