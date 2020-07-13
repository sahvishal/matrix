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
    public partial class HPylori : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                hpylori_hip.Visible = false;
                hpylori_chat.Visible = true;

            }
            else
            {
                hpylori_hip.Visible = true;
                hpylori_chat.Visible = false;
            }
            if (!IsPostBack)
            {
                BindControlData();
            }
        }

        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HPylori);

                gvFindingsHPylori.DataSource = standardFindingList;
                gvFindingsHPylori.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.HPylori) ??
                                                     new List<UnableScreenReason>();

                if (listUnableToScreen.Count < 1)
                    listUnableToScreen.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                if (listUnableToScreen.Count > 0)
                {
                    dtlHPyloriSelectedUnableToScreen.DataSource = listUnableToScreen;
                    dtlHPyloriSelectedUnableToScreen.DataBind();
                }
            }
        }
    }
}