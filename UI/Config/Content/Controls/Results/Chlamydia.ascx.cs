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
    public partial class Chlamydia : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControlData();
            }
            if (IsResultEntrybyChat)
            {
                chlamydia_hip.Visible = false;
                chlamydia_chat.Visible = true;

            }
            else
            {
                chlamydia_hip.Visible = true;
                chlamydia_chat.Visible = false;
            }
        }

        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
            var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Chlamydia);

            gvFindingsChlamydia.DataSource = standardFindingList;
            gvFindingsChlamydia.DataBind();

            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Chlamydia) ??
                                                 new List<UnableScreenReason>();

            if (listUnableToScreen.Count < 1)
                listUnableToScreen.Add(new UnableScreenReason(0)
                {
                    DisplayName = "Unable to Screen",
                    Reason = UnableToScreenReason.Other
                });

            if (listUnableToScreen.Count > 0)
            {
                dtlChlamydiaSelectedUnableToScreen.DataSource = listUnableToScreen;
                dtlChlamydiaSelectedUnableToScreen.DataBind();
            }

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonChlamydia.DataSource = listTestNotPerformedData;
                ddlTestNotPerformedReasonChlamydia.DataTextField = "Name";
                ddlTestNotPerformedReasonChlamydia.DataValueField = "Id";
                ddlTestNotPerformedReasonChlamydia.DataBind();
                ddlTestNotPerformedReasonChlamydia.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonChlamydia.Visible = false;
            }
        }
    }
}