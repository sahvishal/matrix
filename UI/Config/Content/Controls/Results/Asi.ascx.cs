using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Asi : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                asi_hip.Visible = false;
                asi_chat.Visible = true;

            }
            else
            {
                asi_hip.Visible = true;
                asi_chat.Visible = false;
            }
            if (!IsPostBack) BindControlData();
        }

        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.ASI, (int)ReadingLabels.ASI);

                StandardFindingsASIGridView.DataSource = standardFindingList;
                StandardFindingsASIGridView.DataBind();

                IUnableToScreenStatusRepository unableScreenReasonRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableScreenReasonRepository.GetAllUnableToScreenReasons((long)TestType.ASI) ?? new List<UnableScreenReason>() { new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                // Filling Unable To Screen Reason List for ASI
                ASIUnableToScreenSelectedDataList.DataSource = listUnableScreenReason;
                ASIUnableToScreenSelectedDataList.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.ASI);

                ASIIncidentalFindingsSelectedDataList.DataSource = listIncidentalFindings;
                ASIIncidentalFindingsSelectedDataList.DataBind();

            }
        }
    }
}