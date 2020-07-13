using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Phq9 : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                phq9_hip.Visible = false;
                phq9_chat.Visible = true;

            }
            else
            {
                phq9_hip.Visible = true;
                phq9_chat.Visible = false;

            }
            FillAllStaticGrids();
        }
        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.PHQ9) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

            //Filling Unable Screen Reason DataLists
            UnableToScreenPhq9DataList.DataSource = listUnableScreenReasonData;
            UnableToScreenPhq9DataList.DataBind();

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonPhq9.DataSource = listTestNotPerformedData;

                ddlTestNotPerformedReasonPhq9.DataTextField = "Name";
                ddlTestNotPerformedReasonPhq9.DataValueField = "Id";
                ddlTestNotPerformedReasonPhq9.DataBind();
                ddlTestNotPerformedReasonPhq9.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonPhq9.Visible = false;
            }
        }
    }
}