using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class MyBioCheckAssessment : System.Web.UI.UserControl
    {
        private const string StringForMale = "male - ";
        private const string StringForFemale = "female - ";

        private bool _isMale = true;

        public long RoleId { get; set; }

        protected string VersionNumber { get; set; }

        public bool IsResultEntrybyChat { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsResultEntrybyChat)
            {
                mybiocheck_hip.Visible = false;
                mybiocheck_chat.Visible = true;
                
            }
            else
            {
                mybiocheck_hip.Visible = true;
                mybiocheck_chat.Visible = false;
                
            }
            long customerId;

            if (long.TryParse(Request.QueryString["CustomerId"], out customerId))
            {
                var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(customerId);
                _isMale = customer.Gender == Gender.Female ? false : true;
            }
            else if (long.TryParse(Request.QueryString["EventCustomerId"], out customerId))
            {
                var eventCustomer = IoC.Resolve<IEventCustomerResultRepository>().GetById(customerId);
                if (eventCustomer != null)
                {
                    var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(eventCustomer.CustomerId);
                    _isMale = customer.Gender == Gender.Female ? false : true;
                }
            }

            var currentSession = IoC.Resolve<ISessionContext>();
            if (currentSession != null && currentSession.UserSession != null && currentSession.UserSession.CurrentOrganizationRole != null)
                RoleId = currentSession.UserSession.CurrentOrganizationRole.GetSystemRoleId;

            if (!IsPostBack)
                SetReadingFindingsGridView();
        }

        private void SetReadingFindingsGridView()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingTc = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TotalCholestrol);
                var standardFindingGlucose = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.Glucose);
                var standardFindingHdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL);
                var standardFindingLdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.LDL);
                var standardFindingTriglycerides = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TriGlycerides);
                var standardFindingTchdlRatio = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TCHDLRatio);

                MyBioCheckTotalCholestrolFindingGridView.DataSource = standardFindingTc;
                MyBioCheckTotalCholestrolFindingGridView.DataBind();

                GlucoseMyBioCheckFindingGridView.DataSource = standardFindingGlucose;
                GlucoseMyBioCheckFindingGridView.DataBind();

                var jScriptDeserializer = new JavaScriptSerializer();
                Page.ClientScript.RegisterHiddenField("hdlfindingjson", jScriptDeserializer.Serialize(standardFindingHdl));

                var findings = FilterMaleFemalRecordsontheGenderBasis(standardFindingHdl);
                HDLMyBioCheckFindingGridView.DataSource = findings;
                HDLMyBioCheckFindingGridView.DataBind();

                LDLMyBioCheckFindingGridView.DataSource = standardFindingLdl;
                LDLMyBioCheckFindingGridView.DataBind();

                TriglyceridesMyBioCheckFindingGridView.DataSource = standardFindingTriglycerides;
                TriglyceridesMyBioCheckFindingGridView.DataBind();

                TCHDLRatioMyBioCheckFindingGridView.DataSource = standardFindingTchdlRatio;
                TCHDLRatioMyBioCheckFindingGridView.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.MyBioCheckAssessment) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenMyBioCheckAssessmentDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenMyBioCheckAssessmentDataList.DataBind();


                var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
                var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

                if (listTestNotPerformedData.Count > 1)
                {
                    listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                    ddlTestNotPerformedReasonMyBioCheckAssessment.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonMyBioCheckAssessment.DataTextField = "Name";
                    ddlTestNotPerformedReasonMyBioCheckAssessment.DataValueField = "Id";
                    ddlTestNotPerformedReasonMyBioCheckAssessment.DataBind();
                    ddlTestNotPerformedReasonMyBioCheckAssessment.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonMyBioCheckAssessment.Visible = false;
                }
            }
        }

        private IEnumerable<StandardFinding<int?>> FilterMaleFemalRecordsontheGenderBasis(IEnumerable<StandardFinding<int?>> findings)
        {
            var coll = new List<StandardFinding<int?>>();
            string toCheck = _isMale ? StringForMale : StringForFemale;
            string toNotCheck = !_isMale ? StringForMale : StringForFemale;
            if (string.IsNullOrEmpty(toCheck)) return findings;

            foreach (var finding in findings)
            {
                if (finding.Label.ToLower().IndexOf(toCheck) != 0 && finding.Label.ToLower().IndexOf(toNotCheck) >= 0)
                    continue;
                if (finding.Label.ToLower().IndexOf(toCheck) >= 0)
                    finding.Label = finding.Label.Substring(finding.Label.ToLower().IndexOf(toCheck) + toCheck.Length);

                coll.Add(finding);
            }
            return coll;
        }
    }
}