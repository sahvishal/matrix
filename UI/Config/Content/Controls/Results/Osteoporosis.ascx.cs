using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class Osteoporosis : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsResultEntrybyChat)
            {
                osteo_hip.Visible = false;
                osteo_chat.Visible = true;

            }
            else
            {
                osteo_hip.Visible = true;
                osteo_chat.Visible = false;
            }
            if (!IsPostBack)
            {
                BindControlData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
                var standardFindingList = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore);

                gvFindingsOsteo.DataSource = standardFindingList;
                gvFindingsOsteo.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Osteoporosis) ??
                                                     new List<UnableScreenReason>();

                if (listUnableToScreen.Count < 1)
                    listUnableToScreen.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                if (listUnableToScreen.Count > 0)
                {
                    dtlOsteoSelectedUnableToScreen.DataSource = listUnableToScreen;
                    dtlOsteoSelectedUnableToScreen.DataBind();
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
                    ddlTestNotPerformedReasonOsteo_CHAT.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonOsteo_CHAT.DataTextField = "Name";
                    ddlTestNotPerformedReasonOsteo_CHAT.DataValueField = "Id";
                    ddlTestNotPerformedReasonOsteo_CHAT.DataBind();
                    ddlTestNotPerformedReasonOsteo_CHAT.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonOsteo.DataSource = listTestNotPerformedData;
                    ddlTestNotPerformedReasonOsteo.DataTextField = "Name";
                    ddlTestNotPerformedReasonOsteo.DataValueField = "Id";
                    ddlTestNotPerformedReasonOsteo.DataBind();
                    ddlTestNotPerformedReasonOsteo.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonOsteo.Visible = false;
                ddlTestNotPerformedReasonOsteo_CHAT.Visible = false;
            }
        }
    }
}