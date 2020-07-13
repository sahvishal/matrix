using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
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
    public partial class AwvLipid : UserControl
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
                AwvLipid_hip.Visible = false;
                AwvLipid_chat.Visible = true;
            }
            else
            {
                AwvLipid_hip.Visible = true;
                AwvLipid_chat.Visible = false;
            }
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            long customerId;
            if (long.TryParse(Request.QueryString["CustomerId"], out customerId))
            {
                var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(customerId);
                _isMale = customer.Gender != Gender.Female;
            }
            else if (long.TryParse(Request.QueryString["EventCustomerId"], out customerId))
            {
                var eventCustomer = IoC.Resolve<IEventCustomerResultRepository>().GetById(customerId);
                if (eventCustomer != null)
                {
                    var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(eventCustomer.CustomerId);
                    _isMale = customer.Gender != Gender.Female;
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
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingTc = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvLipid, (int)ReadingLabels.TotalCholestrol);

                var standardFindingHdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvLipid, (int)ReadingLabels.HDL);
                var standardFindingLdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvLipid, (int)ReadingLabels.LDL);
                var standardFindingTriglycerides = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvLipid, (int)ReadingLabels.TriGlycerides);
                var standardFindingTchdlRatio = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvLipid, (int)ReadingLabels.TCHDLRatio);

                AwvLipidTotalCholestrolFindingGridView.DataSource = standardFindingTc;
                AwvLipidTotalCholestrolFindingGridView.DataBind();



                var jScriptDeserializer = new JavaScriptSerializer();
                Page.ClientScript.RegisterHiddenField("AwvLipidHdlfindingjson", jScriptDeserializer.Serialize(standardFindingHdl));

                var findings = FilterMaleFemalRecordsontheGenderBasis(standardFindingHdl);
                HDLAwvLipidFindingGridView.DataSource = findings;
                HDLAwvLipidFindingGridView.DataBind();

                LDLAwvLipidFindingGridView.DataSource = standardFindingLdl;
                LDLAwvLipidFindingGridView.DataBind();

                TriglyceridesAwvLipidFindingGridView.DataSource = standardFindingTriglycerides;
                TriglyceridesAwvLipidFindingGridView.DataBind();

                TCHDLRatioAwvLipidFindingGridView.DataSource = standardFindingTchdlRatio;
                TCHDLRatioAwvLipidFindingGridView.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.AwvLipid) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenAwvLipidDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenAwvLipidDataList.DataBind();
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
                    ddlTestNotPerformedReasonAwvLipid_Chat.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvLipid_Chat.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvLipid_Chat.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvLipid_Chat.DataBind();
                    ddlTestNotPerformedReasonAwvLipid_Chat.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonAwvLipid.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonAwvLipid.DataTextField = "Name";
                    ddlTestNotPerformedReasonAwvLipid.DataValueField = "Id";
                    ddlTestNotPerformedReasonAwvLipid.DataBind();
                    ddlTestNotPerformedReasonAwvLipid.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonAwvLipid.Visible = false;
                ddlTestNotPerformedReasonAwvLipid_Chat.Visible = false;
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