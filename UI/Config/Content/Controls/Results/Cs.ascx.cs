using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class Cs : System.Web.UI.UserControl
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
                cs_hip.Visible = false;
                cs_chat.Visible = true;

            }
            else
            {
                cs_hip.Visible = true;
                cs_chat.Visible = false;
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
                    ddlTestNotPerformedReasonCs_Chat.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonCs_Chat.DataTextField = "Name";
                    ddlTestNotPerformedReasonCs_Chat.DataValueField = "Id";
                    ddlTestNotPerformedReasonCs_Chat.DataBind();
                    ddlTestNotPerformedReasonCs_Chat.Items[0].Selected = true;
                }
                else
                {
                    ddlTestNotPerformedReasonCs.DataSource = listTestNotPerformedData;

                    ddlTestNotPerformedReasonCs.DataTextField = "Name";
                    ddlTestNotPerformedReasonCs.DataValueField = "Id";
                    ddlTestNotPerformedReasonCs.DataBind();
                    ddlTestNotPerformedReasonCs.Items[0].Selected = true;
                }
            }
            else
            {
                ddlTestNotPerformedReasonCs.Visible = false;
                ddlTestNotPerformedReasonCs_Chat.Visible = false;
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