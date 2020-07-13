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
    public partial class AwvEkg : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                awvEkg_hip.Visible = false;
                awvEkg_chat.Visible = true;

            }
            else
            {
                awvEkg_hip.Visible = true;
                awvEkg_chat.Visible = false;
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

                var standardFindings = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvEkg);

                AwvEkgFindingsGridView.DataSource = standardFindings;
                AwvEkgFindingsGridView.DataBind();

                AwvEkgBundleBranchBlockDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkg, (Int32)ReadingLabels.BundleBranchBlock);
                AwvEkgBundleBranchBlockDatalist.DataBind();

                AwvEkgInfarctionPatternDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkg, (Int32)ReadingLabels.InfarctionPattern);
                AwvEkgInfarctionPatternDatalist.DataBind();


                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvEkg) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvEkgDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvEkgDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvEkg.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvEkg.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvEkg.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvEkg.DataBind();
                    ddlTestNotPerformedReasonAwvEkg.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvEkg.Visible = false;
                }
            }
        }
    }
}