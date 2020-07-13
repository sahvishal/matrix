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
    public partial class Spiro : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                spiro_hip.Visible = false;
                spiro_chat.Visible = true;

            }
            else
            {
                spiro_hip.Visible = true;
                spiro_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Spiro);

                gvFindingsSpiro.DataSource = standardFindingList;
                gvFindingsSpiro.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Spiro) ??
                                                     new List<UnableScreenReason>();

                if (listUnableToScreen.Count < 1)
                    listUnableToScreen.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                if (listUnableToScreen.Count > 0)
                {
                    dtlSpiroSelectedUnableToScreen.DataSource = listUnableToScreen;
                    dtlSpiroSelectedUnableToScreen.DataBind();
                }
            }

            SetTestNotPerformed();
        }

        private void SetTestNotPerformed()
        {
            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();
            
            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                if (IsResultEntrybyChat)
                {
                    ddlTestNotPerformedReasonSpiro_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonSpiro_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonSpiro_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonSpiro_CHAT.DataBind();
                    ddlTestNotPerformedReasonSpiro_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonSpiro.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonSpiro.DataTextField = "Name";
                    ddlTestNotPerformedReasonSpiro.DataValueField = "Id";
                    ddlTestNotPerformedReasonSpiro.DataBind();
                    ddlTestNotPerformedReasonSpiro.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonSpiro.Visible = false;
                ddlTestNotPerformedReasonSpiro_CHAT.Visible = false;
            }
        }
    }
}