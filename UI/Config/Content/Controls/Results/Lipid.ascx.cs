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
    public partial class Lipid : System.Web.UI.UserControl
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
                lipid_hip.Visible = false;
                lipid_chat.Visible = true;

            }
            else
            {
                lipid_hip.Visible = true;
                lipid_chat.Visible = false;
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

            if (!IsPostBack)
                SetReadingFindingsGridView();
            var currentSession = IoC.Resolve<ISessionContext>();
            if (currentSession != null && currentSession.UserSession != null && currentSession.UserSession.CurrentOrganizationRole != null)
                RoleId = currentSession.UserSession.CurrentOrganizationRole.GetSystemRoleId;
        }

        private void SetReadingFindingsGridView()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingTc = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol);
                var standardFindingGlucose = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.Glucose);
                var standardFindingHdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.HDL);
                var standardFindingLdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.LDL);
                var standardFindingTriglycerides = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.TriGlycerides);
                var standardFindingTchdlRatio = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio);

                TotalCholestrolFindingGridView.DataSource = standardFindingTc;
                TotalCholestrolFindingGridView.DataBind();

                GlucoseFindingGridView.DataSource = standardFindingGlucose;
                GlucoseFindingGridView.DataBind();

                var jScriptDeserializer = new JavaScriptSerializer();
                Page.ClientScript.RegisterHiddenField("hdlfindingjson", jScriptDeserializer.Serialize(standardFindingHdl));

                var findings = FilterMaleFemalRecordsontheGenderBasis(standardFindingHdl);
                HDLFindingGridView.DataSource = findings;
                HDLFindingGridView.DataBind();

                LDLFindingGridView.DataSource = standardFindingLdl;
                LDLFindingGridView.DataBind();

                TriglyceridesFindingGridView.DataSource = standardFindingTriglycerides;
                TriglyceridesFindingGridView.DataBind();

                TCHDLRatioFindingGridView.DataSource = standardFindingTchdlRatio;
                TCHDLRatioFindingGridView.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Lipid) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenLipidDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenLipidDataList.DataBind();
            }

            SetTestNotPerfomred();
        }

        private void SetTestNotPerfomred()
        {
            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();
            listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

            if (listTestNotPerformedData.Count > 1)
            {
                if (IsResultEntrybyChat)
                {
                    ddlTestNotPerformedReasonLipid_Chat.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonLipid_Chat.DataTextField = "Name";
                    ddlTestNotPerformedReasonLipid_Chat.DataValueField = "Id";
                    ddlTestNotPerformedReasonLipid_Chat.DataBind();
                    ddlTestNotPerformedReasonLipid_Chat.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonLipid.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonLipid.DataTextField = "Name";
                    ddlTestNotPerformedReasonLipid.DataValueField = "Id";
                    ddlTestNotPerformedReasonLipid.DataBind();
                    ddlTestNotPerformedReasonLipid.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonLipid.Visible = false;
                ddlTestNotPerformedReasonLipid_Chat.Visible = false;
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