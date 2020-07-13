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
    public partial class IFOBT : UserControl
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
                IFOBT_hip.Visible = false;
                IFOBT_chat.Visible = true;
            }
            else
            {
                IFOBT_hip.Visible = true;
                IFOBT_chat.Visible = false;
            }
        }

        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
            var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.IFOBT);

            gvFindingsIFOBT.DataSource = standardFindingList;
            gvFindingsIFOBT.DataBind();

            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.IFOBT) ??
                                                 new List<UnableScreenReason>();

            if (listUnableToScreen.Count < 1)
                listUnableToScreen.Add(new UnableScreenReason(0)
                {
                    DisplayName = "Unable to Screen",
                    Reason = UnableToScreenReason.Other
                });

            if (listUnableToScreen.Count > 0)
            {
                dtlIFOBTSelectedUnableToScreen.DataSource = listUnableToScreen;
                dtlIFOBTSelectedUnableToScreen.DataBind();
            }

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonIFOBT.DataSource = listTestNotPerformedData;
                ddlTestNotPerformedReasonIFOBT.DataTextField = "Name";
                ddlTestNotPerformedReasonIFOBT.DataValueField = "Id";
                ddlTestNotPerformedReasonIFOBT.DataBind();
                ddlTestNotPerformedReasonIFOBT.Items[0].Selected = true;

                ddlTestNotPerformedReasonIFOBT_chat.DataSource = listTestNotPerformedData;
                ddlTestNotPerformedReasonIFOBT_chat.DataTextField = "Name";
                ddlTestNotPerformedReasonIFOBT_chat.DataValueField = "Id";
                ddlTestNotPerformedReasonIFOBT_chat.DataBind();
                ddlTestNotPerformedReasonIFOBT_chat.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonIFOBT.Visible = false;
                ddlTestNotPerformedReasonIFOBT_chat.Visible = false;
            }
        }
    }
}