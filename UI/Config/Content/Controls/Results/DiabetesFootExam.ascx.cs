using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class DiabetesFootExam : System.Web.UI.UserControl
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                DiabetesFootExam_hip.Visible = false;
                DiabetesFootExam_chat.Visible = true;

            }
            else
            {
                DiabetesFootExam_hip.Visible = true;
                DiabetesFootExam_chat.Visible = false;
            }

            FillAllStaticGrids();
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
            var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Hypertension) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

            if (listUnableScreenReasonData.Count < 1)
                listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
            
            //Filling Unable Screen Reason DataLists
            UnableToScreenDiabetesFootExamDataList.DataSource = listUnableScreenReasonData;
            UnableToScreenDiabetesFootExamDataList.DataBind();
        }
    }
}