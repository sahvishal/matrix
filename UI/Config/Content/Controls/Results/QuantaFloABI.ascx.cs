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
    public partial class QuantaFloABI : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                QuantaFloABI_hip.Visible = false;
                QuantaFloABI_chat.Visible = true;

            }
            else
            {
                QuantaFloABI_hip.Visible = true;
                QuantaFloABI_chat.Visible = false;

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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.QuantaFloABI);

                gvFindingsQuantaFloABI.DataSource = standardFindingList;
                gvFindingsQuantaFloABI.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.QuantaFloABI) ??
                                                     new List<UnableScreenReason>();

                if (listUnableToScreen.Count < 1)
                    listUnableToScreen.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                if (listUnableToScreen.Count > 0)
                {
                    dtlQuantaFloABIUnableToScreenSelected.DataSource = listUnableToScreen;
                    dtlQuantaFloABIUnableToScreenSelected.DataBind();
                }

            }

            SetTestNotPerfomred();
        }

        private void SetTestNotPerfomred()
        {
            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();
            

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                if (IsResultEntrybyChat)
                {
                    ddlTestNotPerformedReasonQuantaFloABI_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonQuantaFloABI_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonQuantaFloABI_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonQuantaFloABI_CHAT.DataBind();
                    ddlTestNotPerformedReasonQuantaFloABI_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonQuantaFloABI.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonQuantaFloABI.DataTextField = "Name";
                    ddlTestNotPerformedReasonQuantaFloABI.DataValueField = "Id";
                    ddlTestNotPerformedReasonQuantaFloABI.DataBind();
                    ddlTestNotPerformedReasonQuantaFloABI.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonQuantaFloABI.Visible = false;
                ddlTestNotPerformedReasonQuantaFloABI_CHAT.Visible = false;
            }
        }
    }


}