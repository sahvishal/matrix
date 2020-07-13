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
    public partial class AwvSpiro : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                awvSpiro_hip.Visible = false;
                awvSpiro_chat.Visible = true;

            }
            else
            {
                awvSpiro_hip.Visible = true;
                awvSpiro_chat.Visible = false;
            }
            FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvSpiro);

                gvFindingsAwvSpiro.DataSource = standardFindingList;
                gvFindingsAwvSpiro.DataBind();

                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvSpiro) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                UnableToScreenAwvSpiroDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvSpiroDataList.DataBind();

                if (listUnableScreenReasonData.Count > 0)
                {
                    UnableToScreenAwvSpiroDataList.DataSource = listUnableScreenReasonData;
                    UnableToScreenAwvSpiroDataList.DataBind();
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
                    ddlTestNotPerformedReasonAwvSpiro_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvSpiro_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvSpiro_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvSpiro_CHAT.DataBind();
                    ddlTestNotPerformedReasonAwvSpiro_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvSpiro.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvSpiro.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvSpiro.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvSpiro.DataBind();
                    ddlTestNotPerformedReasonAwvSpiro.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonAwvSpiro.Visible = false;
                ddlTestNotPerformedReasonAwvSpiro_CHAT.Visible = false;
            }
        }


    }
}