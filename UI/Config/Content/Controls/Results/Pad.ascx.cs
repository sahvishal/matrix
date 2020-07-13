using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Pad : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }

        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                pad_hip.Visible = false;
                pad_chat.Visible = true;

            }
            else
            {
                pad_hip.Visible = true;
                pad_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.PAD);
                //if (standardFindingList.Count > 0 && standardFindingList.First().WorstCaseOrder.HasValue)
                //    standardFindingList = standardFindingList.OrderBy(f => f.WorstCaseOrder).ToList();
                //else
                //{
                standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();
                //}

                gvFindingsPAD.DataSource = standardFindingList;
                gvFindingsPAD.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReason = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.PAD) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReason.Count < 1)
                    listUnableScreenReason.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                // Filling Unable To Screen Reason List for ASI
                dtlPADUnableToScreenSelected.DataSource = listUnableScreenReason;
                dtlPADUnableToScreenSelected.DataBind();

                IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
                var listIncidentalFindings = incidentalFindingrepository.GetAllIncidentalFinding((long)TestType.PAD);

                dtlPADIncidentalFindingsSelected.DataSource = listIncidentalFindings;
                dtlPADIncidentalFindingsSelected.DataBind();
            }
        }
    }
}