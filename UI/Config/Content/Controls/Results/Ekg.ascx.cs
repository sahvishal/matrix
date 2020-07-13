using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Ekg : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                ekg_hip.Visible = false;
                ekg_chat.Visible = true;

            }
            else
            {
                ekg_hip.Visible = true;
                ekg_chat.Visible = false;
            }
            if (!IsPostBack)
            {
                ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
                VersionNumber = systemInformationRepository.GetBuildNumber();
                if (!IsResultEntrybyChat)
                {
                    IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                    var standardFindings = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.EKG);

                    EKGFindingsGridView.DataSource = standardFindings;
                    EKGFindingsGridView.DataBind();

                    BundleBranchBlockDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.EKG, (Int32)ReadingLabels.BundleBranchBlock);
                    BundleBranchBlockDatalist.DataBind();

                    InfarctionPatternDatalist.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.EKG, (Int32)ReadingLabels.InfarctionPattern);
                    InfarctionPatternDatalist.DataBind();

                    IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                    var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.EKG) ??
                                                     new List<UnableScreenReason>();

                    if (listUnableScreenReasonData.Count < 1)
                        listUnableScreenReasonData.Add(new UnableScreenReason(0)
                        {
                            DisplayName = "Unable to Screen",
                            Reason = UnableToScreenReason.Other
                        });

                    UnableToScreenEkgDataList.DataSource = listUnableScreenReasonData;
                    UnableToScreenEkgDataList.DataBind();
                }
            }
        }
    }
}