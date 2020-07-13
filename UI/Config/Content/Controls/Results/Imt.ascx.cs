using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Imt : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                imt_hip.Visible = false;
                imt_chat.Visible = true;

            }
            else
            {
                imt_hip.Visible = true;
                imt_chat.Visible = false;
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
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.IMT);

                if (standardFindingList != null)
                {
                    var normalFinding = standardFindingList.Where(sfl => sfl.Label.ToLower().Trim().Equals("normal")).FirstOrDefault();
                    var abnormalFinding = standardFindingList.Where(sfl => sfl.Label.ToLower().Trim().Equals("abnormal")).FirstOrDefault();
                    if (normalFinding != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "js_Imt_normal", "var imt_normalFindingId = " + normalFinding.Id + "; ", true);
                    }

                    if (abnormalFinding != null)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "js_Imt_abnormal", "var imt_abnormalFindingId = " + abnormalFinding.Id + "; ", true);
                    }
                }

                StandardFindingsImtGridView.DataSource = standardFindingList;
                StandardFindingsImtGridView.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.IMT) ?? new List<UnableScreenReason>() { new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                //Filling Unable Screen Reason DataLists
                UnableToScreenImtDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenImtDataList.DataBind();
            }
        }
    }
}