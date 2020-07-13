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
    public partial class Dpn : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                dpn_hip.Visible = false;
                dpn_chat.Visible = true;
            }
            else
            {
                dpn_hip.Visible = true;
                dpn_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.DPN);

                gvFindingsDpn.DataSource = standardFindingList;
                gvFindingsDpn.DataBind();

                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Hypertension) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                //Filling Unable Screen Reason DataLists
                UnableToScreenDpnDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenDpnDataList.DataBind();
            }
            SetTestNotPerfomred();
        }

        private void SetTestNotPerfomred()
        {
            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();
            listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

            if (listTestNotPerformedData.Count > 1)
            {
                if (IsResultEntrybyChat)
                {
                    ddlTestNotPerformedReasonDpn_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonDpn_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonDpn_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonDpn_CHAT.DataBind();
                    ddlTestNotPerformedReasonDpn_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonDpn.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonDpn.DataTextField = "Name";
                    ddlTestNotPerformedReasonDpn.DataValueField = "Id";
                    ddlTestNotPerformedReasonDpn.DataBind();
                    ddlTestNotPerformedReasonDpn.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonDpn.Visible = false;
                ddlTestNotPerformedReasonDpn_CHAT.Visible = false;
            }
        }
    }
}