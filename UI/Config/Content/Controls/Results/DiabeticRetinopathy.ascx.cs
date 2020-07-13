using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class DiabeticRetinopathy : System.Web.UI.UserControl
    {
        protected long EventId { get; set; }
        protected long CustomerId { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            long eventId = 0;
            long customerId = 0;
            if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out eventId))
            {
                EventId = eventId;
            }

            if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out customerId))
            {
                CustomerId = customerId;
            }
            FillAllStaticGrids();
            if (IsResultEntrybyChat)
            {
                DiabeticRetinopathy_hip.Visible = false;
                DiabeticRetinopathy_chat.Visible = true;

            }
            else
            {
                DiabeticRetinopathy_hip.Visible = true;
                DiabeticRetinopathy_chat.Visible = false;
            }
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.DiabeticRetinopathy) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason() { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });
                //Filling Unable Screen Reason DataLists
                UnableToScreenDiabeticRetinopathyDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenDiabeticRetinopathyDataList.DataBind();
                
                var standardFindingRepository = new StandardFindingRepository();

                DiabeticRetinopathyHighestLevelOfSpecificity.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.DiabeticRetinopathy, (Int32)ReadingLabels.DiabeticRetinopathyHighestLevelOfSpecificity);
                DiabeticRetinopathyHighestLevelOfSpecificity.DataBind();

                DiabeticRetinopathyMacularEdemaLevelOfSpecificity.DataSource = standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.DiabeticRetinopathy, (Int32)ReadingLabels.MacularEdemaHighestLevelOfSpecificity);
                DiabeticRetinopathyMacularEdemaLevelOfSpecificity.DataBind();
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
                    ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT.DataBind();
                    ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT.Items[0].Selected = true;
                }
                else
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonDiabeticRetinopathy.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonDiabeticRetinopathy.DataTextField = "Name";
                    ddlTestNotPerformedReasonDiabeticRetinopathy.DataValueField = "Id";
                    ddlTestNotPerformedReasonDiabeticRetinopathy.DataBind();
                    ddlTestNotPerformedReasonDiabeticRetinopathy.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonDiabeticRetinopathy.Visible = false;
                ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT.Visible = false;
            }
        }
    }
}