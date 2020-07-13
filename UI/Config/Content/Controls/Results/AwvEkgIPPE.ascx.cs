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
    public partial class AwvEkgIPPE : UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                AwvEkgIPPE_hip.Visible = false;
                AwvEkgIPPE_chat.Visible = true;

            }
            else
            {
                AwvEkgIPPE_hip.Visible = true;
                AwvEkgIPPE_chat.Visible = false;
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

                var standardFindings = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvEkgIPPE);

                AwvEkgIppeFindingsGridView.DataSource = standardFindings;
                AwvEkgIppeFindingsGridView.DataBind();

                AwvEkgIppeBundleBranchBlockDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkgIPPE, (Int32)ReadingLabels.BundleBranchBlock);
                AwvEkgIppeBundleBranchBlockDatalist.DataBind();

                AwvEkgIppeInfarctionPatternDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkgIPPE, (Int32)ReadingLabels.InfarctionPattern);
                AwvEkgIppeInfarctionPatternDatalist.DataBind();

                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvEkgIPPE) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvEkgIPPEDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvEkgIPPEDataList.DataBind();

                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonAwvEkgIPPE.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvEkgIPPE.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvEkgIPPE.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvEkgIPPE.DataBind();
                    ddlTestNotPerformedReasonAwvEkgIPPE.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvEkgIPPE.Visible = false;
                }
            }
        }
    }
}