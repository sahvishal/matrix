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
    public partial class FloChecABI : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                FloChecABI_hip.Visible = false;
                FloChecABI_chat.Visible = true;

            }
            else
            {
                FloChecABI_hip.Visible = true;
                FloChecABI_chat.Visible = false;
            }
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
            var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.FloChecABI);
            
            standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();


            gvFindingsFloChecABI.DataSource = standardFindingList;
            gvFindingsFloChecABI.DataBind();

            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableScreenReason = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.FloChecABI) ??
                                             new List<UnableScreenReason>();

            if (listUnableScreenReason.Count < 1)
                listUnableScreenReason.Add(new UnableScreenReason(0)
                {
                    DisplayName = "Unable to Screen",
                    Reason = UnableToScreenReason.Other
                });

            // Filling Unable To Screen Reason List for ASI
            dtlFloChecABIUnableToScreenSelected.DataSource = listUnableScreenReason;
            dtlFloChecABIUnableToScreenSelected.DataBind();

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonFloChecABI.DataSource = listTestNotPerformedData;
                ddlTestNotPerformedReasonFloChecABI.DataTextField = "Name";
                ddlTestNotPerformedReasonFloChecABI.DataValueField = "Id";
                ddlTestNotPerformedReasonFloChecABI.DataBind();
                ddlTestNotPerformedReasonFloChecABI.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonFloChecABI.Visible = false;
            }
        }
    }
}