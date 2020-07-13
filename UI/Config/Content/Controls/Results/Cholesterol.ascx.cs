using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
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
    public partial class Cholesterol : UserControl
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
                Cholesterol_hip.Visible = false;
                Cholesterol_chat.Visible = true;

            }
            else
            {
                Cholesterol_hip.Visible = true;
                Cholesterol_chat.Visible = false;
            }
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
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingTc = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Cholesterol, (int)ReadingLabels.TotalCholestrol);

                var standardFindingHdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Cholesterol, (int)ReadingLabels.HDL);
                var standardFindingLdl = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Cholesterol, (int)ReadingLabels.LDL);
                var standardFindingTriglycerides = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Cholesterol, (int)ReadingLabels.TriGlycerides);
                var standardFindingTchdlRatio = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Cholesterol, (int)ReadingLabels.TCHDLRatio);

                CholesterolTotalCholesterolFindingGridView.DataSource = standardFindingTc;
                CholesterolTotalCholesterolFindingGridView.DataBind();



                var jScriptDeserializer = new JavaScriptSerializer();
                Page.ClientScript.RegisterHiddenField("CholesterolHdlfindingjson", jScriptDeserializer.Serialize(standardFindingHdl));

                var findings = FilterMaleFemalRecordsontheGenderBasis(standardFindingHdl);
                HDLCholesterolFindingGridView.DataSource = findings;
                HDLCholesterolFindingGridView.DataBind();

                LDLCholesterolFindingGridView.DataSource = standardFindingLdl;
                LDLCholesterolFindingGridView.DataBind();

                TriglyceridesCholesterolFindingGridView.DataSource = standardFindingTriglycerides;
                TriglyceridesCholesterolFindingGridView.DataBind();

                TCHDLRatioCholesterolFindingGridView.DataSource = standardFindingTchdlRatio;
                TCHDLRatioCholesterolFindingGridView.DataBind();

                IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Cholesterol) ??
                                                 new List<UnableScreenReason>();

                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason(0)
                    {
                        DisplayName = "Unable to Screen",
                        Reason = UnableToScreenReason.Other
                    });

                //Filling Unable Screen Reason DataLists
                UnableToScreenCholesterolDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenCholesterolDataList.DataBind();
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