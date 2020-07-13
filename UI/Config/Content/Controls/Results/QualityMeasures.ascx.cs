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
    public partial class QualityMeasures : System.Web.UI.UserControl
    {
        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                QualityMeasures_hip.Visible = false;
                QualityMeasures_chat.Visible = true;

            }
            else
            {
                QualityMeasures_hip.Visible = true;
                QualityMeasures_chat.Visible = false;

            }
            BindControlData();
        }

        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
            var functionalAssessmentScore = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.QualityMeasures, (int)ReadingLabels.FunctionalAssessmentScore);

            ddlFunctionalAssessment.DataSource = GetDropdownllistValues(functionalAssessmentScore);
            ddlFunctionalAssessment.DataValueField = "Key"; //The Value of the DropDownList, to get it you should call ddlDepartments.SelectedValue;
            ddlFunctionalAssessment.DataTextField = "Value";
            ddlFunctionalAssessment.DataBind();


            var painAssessmentScore = standardFindingRepository.GetAllStandardFindings<int>((int)TestType.QualityMeasures, (int)ReadingLabels.PainAssessmentScore);

            ddlPainAssessmentScore.DataSource = GetDropdownllistValues(painAssessmentScore);
            ddlPainAssessmentScore.DataValueField = "Key"; //The Value of the DropDownList, to get it you should call ddlDepartments.SelectedValue;
            ddlPainAssessmentScore.DataTextField = "Value";
            ddlPainAssessmentScore.DataBind();



            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.QualityMeasures) ??
                                                 new List<UnableScreenReason>();

            if (listUnableToScreen.Count < 1)
                listUnableToScreen.Add(new UnableScreenReason(0)
                {
                    DisplayName = "Unable to Screen",
                    Reason = UnableToScreenReason.Other
                });

            if (listUnableToScreen.Count > 0)
            {
                dtlQualityMeasuresSelectedUnableToScreen.DataSource = listUnableToScreen;
                dtlQualityMeasuresSelectedUnableToScreen.DataBind();
            }

            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonQualityMeasures.DataSource = listTestNotPerformedData;

                ddlTestNotPerformedReasonQualityMeasures.DataTextField = "Name";
                ddlTestNotPerformedReasonQualityMeasures.DataValueField = "Id";
                ddlTestNotPerformedReasonQualityMeasures.DataBind();
                ddlTestNotPerformedReasonQualityMeasures.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonQualityMeasures.Visible = false;
            }
        }

        private Dictionary<string, string> GetDropdownllistValues(IEnumerable<StandardFinding<int>> list)
        {
            var ddlListItems = new Dictionary<string, string> { { "-1", "  Select  " } };

            foreach (var standardFinding in list)
            {
                ddlListItems.Add(standardFinding.Id.ToString(), standardFinding.Label);
            }

            return ddlListItems;
        }
    }
}