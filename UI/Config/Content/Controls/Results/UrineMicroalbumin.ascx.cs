using System.Linq;
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
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class UrineMicroalbumin : System.Web.UI.UserControl
    {
        private const string StringForMale = "male - ";
        private const string StringForFemale = "female - ";

        private bool _isMale = true;

        public long RoleId { get; set; }

        protected string VersionNumber { get; set; }
        public bool IsResultEntrybyChat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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
            {
                BindControlData();
            }
            if (IsResultEntrybyChat)
            {
                UrineMicroalbumin_hip.Visible = false;
                UrineMicroalbumin_chat.Visible = true;

            }
            else
            {
                UrineMicroalbumin_hip.Visible = true;
                UrineMicroalbumin_chat.Visible = false;

            }
        }
        public void BindControlData()
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            IStandardFindingRepository standardFindingRepository = new StandardFindingRepository();
            var standardFindingUrineMicroalbumin = standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.UrineMicroalbumin);

            var jScriptDeserializer = new JavaScriptSerializer();
            Page.ClientScript.RegisterHiddenField("UrineMicroalbuminfindingjson", jScriptDeserializer.Serialize(standardFindingUrineMicroalbumin));

            var findings = FilterMaleFemalRecordsontheGenderBasis(standardFindingUrineMicroalbumin);
            StandardFindingsUrineMicroalbuminGridView.DataSource = findings;
            StandardFindingsUrineMicroalbuminGridView.DataBind();

            IUnableToScreenStatusRepository unableScreenRepository = new UnableToScreenStatusRepository();
            var listUnableToScreen = unableScreenRepository.GetAllUnableToScreenReasons((long)TestType.UrineMicroalbumin) ??
                                                 new List<UnableScreenReason>();

            if (listUnableToScreen.Count < 1)
                listUnableToScreen.Add(new UnableScreenReason(0)
                {
                    DisplayName = "Unable to Screen",
                    Reason = UnableToScreenReason.Other
                });

            if (listUnableToScreen.Count > 0)
            {
                dtlUrineMicroalbuminSelectedUnableToScreen.DataSource = listUnableToScreen;
                dtlUrineMicroalbuminSelectedUnableToScreen.DataBind();
            }
            var testNotPerformedReasonRepository = IoC.Resolve<ITestNotPerformedReasonRepository>();
            var listTestNotPerformedData = testNotPerformedReasonRepository.GetAll().ToList();

            if (listTestNotPerformedData.Count > 1)
            {
                listTestNotPerformedData.Insert(0, new TestNotPerformedReason { Name = " Select ", Id = -1 });

                ddlTestNotPerformedReasonUrineMicroalbumin.DataSource = listTestNotPerformedData;

                ddlTestNotPerformedReasonUrineMicroalbumin.DataTextField = "Name";
                ddlTestNotPerformedReasonUrineMicroalbumin.DataValueField = "Id";
                ddlTestNotPerformedReasonUrineMicroalbumin.DataBind();
                ddlTestNotPerformedReasonUrineMicroalbumin.Items[0].Selected = true;

                ddlTestNotPerformedReasonUrineMicroalbumin_chat.DataSource = listTestNotPerformedData;

                ddlTestNotPerformedReasonUrineMicroalbumin_chat.DataTextField = "Name";
                ddlTestNotPerformedReasonUrineMicroalbumin_chat.DataValueField = "Id";
                ddlTestNotPerformedReasonUrineMicroalbumin_chat.DataBind();
                ddlTestNotPerformedReasonUrineMicroalbumin_chat.Items[0].Selected = true;
            }
            else
            {
                ddlTestNotPerformedReasonUrineMicroalbumin.Visible = false;
                ddlTestNotPerformedReasonUrineMicroalbumin_chat.Visible = false;
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