using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
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
    public partial class Hemoglobin : System.Web.UI.UserControl
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
                Hemoglobin_hip.Visible = false;
                Hemoglobin_chat.Visible = true;

            }
            else
            {
                Hemoglobin_hip.Visible = true;
                Hemoglobin_chat.Visible = false;
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
                FillAllStaticGrids();

            var currentSession = IoC.Resolve<ISessionContext>();
            if (currentSession != null && currentSession.UserSession != null && currentSession.UserSession.CurrentOrganizationRole != null)
                RoleId = currentSession.UserSession.CurrentOrganizationRole.GetSystemRoleId;
        }

        public void FillAllStaticGrids()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();
            if (!IsResultEntrybyChat)
            {
                var unableScreenRepository = IoC.Resolve<IUnableToScreenStatusRepository>();
                var listUnableScreenReasonData = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.Hemoglobin) ?? new List<UnableScreenReason> { new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other } };
                IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();

                var standardFindingHemoglobin = standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Hemoglobin, (int)ReadingLabels.Hemoglobin);

                var jScriptDeserializer = new JavaScriptSerializer();
                Page.ClientScript.RegisterHiddenField("hemoglobinfindingjson", jScriptDeserializer.Serialize(standardFindingHemoglobin));

                HemoglobinFindingGridView.DataSource = FilterMaleFemalRecordsontheGenderBasis(standardFindingHemoglobin);
                HemoglobinFindingGridView.DataBind();
                if (listUnableScreenReasonData.Count < 1)
                    listUnableScreenReasonData.Add(new UnableScreenReason { DisplayName = "Unable to Screen", Reason = UnableToScreenReason.Other });

                UnableToScreenHemoglobinDataList.DataSource = listUnableScreenReasonData;
                UnableToScreenHemoglobinDataList.DataBind();
            }
        }

        private IEnumerable<StandardFinding<decimal?>> FilterMaleFemalRecordsontheGenderBasis(IEnumerable<StandardFinding<decimal?>> findings)
        {
            var coll = new List<StandardFinding<decimal?>>();
            var toCheck = _isMale ? StringForMale : StringForFemale;
            var toNotCheck = !_isMale ? StringForMale : StringForFemale;
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