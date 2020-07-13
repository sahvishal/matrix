using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Diabetes : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsResultEntrybyChat)
            {
                Diabetes_hip.Visible = false;
                Diabetes_chat.Visible = true;

            }
            else
            {
                Diabetes_hip.Visible = true;
                Diabetes_chat.Visible = false;
            }
            FillAllStaticGrids();
        }
        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Diabetes) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingGlucose = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Diabetes, (int)ReadingLabels.Glucose);
                GlucoseFindingGridView.DataSource = standardFindingGlucose;
                GlucoseFindingGridView.DataBind();
                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenDiabetesDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenDiabetesDataList.DataBind();
            }
        }
    }
}